using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TabuleiroController : MonoBehaviour
{
    public int tamanho;

    // é bom q seja par, maior q zero e menor q tamanho-2
    // e quando e digo é bom, eu quero dizer q vai crashar caso contrário
    public int nEventos;

    public GameObject tilemap;
    public GameObject eventosmap;
    public GameObject collidermap;

    public TileBase caminhoTile;
    public TileBase vazio;

    List<int> SetEventos() {
        List<int> iEventos = new List<int>();
            
        // a quantidade de intervalos pra distribuir os eventos
        int nIntervals = (tamanho-2)/nEventos;

        // numero de subdivisoes do subarray
        double nMinMax = ((double)nEventos/(double)nIntervals);

        // primeiro e ultimo
        int min = (int)System.Math.Floor(nMinMax);
        int max = (int)System.Math.Ceiling(nMinMax);

        // pra não ter um número atrás do outro
        int bias = 0;

        for (int i=1; i<=nIntervals; i++) {
            // primeira parte
            if(i==1) {
                int temp = (int)(nEventos/min);
                for(int j=1; j<=min; j++) {
                    int r = Random.Range(2, temp+1);
                    int n = ((r+bias)+(temp*(j-1)))+(nEventos*(i-1));
                    iEventos.Add( n );

                    // pra não ter um número atrás do outro
                    if (r == temp) bias = 1;
                    else bias = 0;
                }
            }
            // última parte
            else if(i==nIntervals) {
                int temp = (int)(nEventos/min);
                for(int j=1; j<=min; j++) {
                    int r = Random.Range(2, temp-1);
                    int n = ((r+bias)+(temp*(j-1)))+(nEventos*(i-1));
                    iEventos.Add( n );

                    if (r == temp-2) bias = 1;
                    else bias = 0;
                }
            }
            // partes do meio
            else {
                int temp = (int)(nEventos/max);
                for(int j=1;j<=max; j++) {
                    int r = Random.Range(1, temp);
                    int n = ((r+bias)+(temp*(j-1)))+(nEventos*(i-1));
                    iEventos.Add( n );

                    if (r == temp-1) bias = 1;
                    else bias = 0;
                }
            }
        }

        return iEventos;
    }

    Vector3Int EscolherDirecao(Vector3Int atual, Vector3Int antes) {
        Vector3Int direcao = atual;

        // se vem da esquerda
        if (antes.y > atual.y) {
            // aleatorio de duas opções
            if( Random.Range(0, 2) == 0 )
                direcao.x += 1;
            else
                direcao.y -= 1;
        }
        // se vem da direita
        else if (antes.y < atual.y) {
            // aleatorio de duas opções
            if( Random.Range(0, 2) == 0 )
                direcao.x += 1;
            else
                direcao.y += 1;
        }
        // se vem de traz
        else {
            // aleatorio de tres opções
            int escolha = Random.Range(0, 3);
            if( escolha == 0 )
                direcao.x += 1;
            else if (escolha == 1)
                direcao.y -= 1;
            else
                direcao.y += 1;
        }

        return direcao;
    }

    // gera as posicoes onde o tabuleiro vai ser gerado
    List<Vector3Int> GerarCaminho() {
        List<Vector3Int> caminho = new List<Vector3Int>();

        Vector3Int antes = new Vector3Int(0, 0, 0);
        caminho.Add(antes);

        Vector3Int atual = new Vector3Int(1, 0, 0);
        caminho.Add(atual);

        for (int i=2; i<tamanho; i++) {
            Vector3Int temp = EscolherDirecao(atual, antes);
            antes = atual;
            atual = temp;
            caminho.Add(temp);
        }

        return caminho;
    }

    void GerarTabuleiro(List<Vector3Int> caminho, List<int> eventos){
        Tilemap mapa = tilemap.GetComponent<Tilemap>();

        eventosmap.GetComponent<EventosController>().SetEventTile(
            caminho[0], 1
        );

        for (int i=1; i<(tamanho-1); i++) {
            if (eventos.Contains(i)) {
                int r = Random.Range(2, 6);
                eventosmap.GetComponent<EventosController>().SetEventTile(
                    caminho[i], r
                );
            }
            else
                mapa.SetTile(caminho[i], caminhoTile);
        }

        eventosmap.GetComponent<EventosController>().SetEventTile(
            caminho[tamanho-1], 6
        );
    }

    List<Vector3Int> GetVizinhos(Vector3Int tile) {
        List<Vector3Int> vizinhos = new List<Vector3Int>();
        for (int i=-1; i<2; i++) {
            for (int j=-1; j<2; j++) {
                if (i==0 && j==0)
                    continue;
                vizinhos.Add( new Vector3Int(tile.x + i, tile.y+j, 0) );
            }
        }
        return vizinhos;
    }

    void GerarParedes(List<Vector3Int> caminho) {
        Tilemap mapa = collidermap.GetComponent<Tilemap>();

        foreach (Vector3Int passo in caminho) {
            List<Vector3Int> vizinhos = GetVizinhos( passo );

            foreach (Vector3Int vizinho in vizinhos) {
                if (tilemap.GetComponent<Tilemap>().GetTile(vizinho) == null &&
                    eventosmap.GetComponent<Tilemap>().GetTile(vizinho) == null) {
                    mapa.SetTile(vizinho, vazio);
                }
            }
        }
        
    }

    void Start()
    {
        // gera o indice dos eventos aleatorios
        List<int> iEventos = SetEventos();

        // gera o caminho que vai ser criado
        List<Vector3Int> tiles = GerarCaminho();

        // cria o caminho andavel e as paredes em volta dele
        GerarTabuleiro( tiles, iEventos );
        GerarParedes( tiles );

    }

}
