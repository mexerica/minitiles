using System.Collections.Generic;
using UnityEngine;

public class AliadosController : MonoBehaviour
{
    public GameObject[] aliados;

    [SerializeField] Aliado personagemAtivo;

    public int indice;

    public GameObject boxItems;
    [SerializeField] Item[] items;

    Asao[] asoes;

    public void SetAntePersonagem() {
        if (indice > 0) {
            indice -= 1;
            personagemAtivo.SetInativo();
            personagemAtivo = aliados[indice % aliados.Length].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }
    public void SetProximoPersonagem(Habilidade hblt, Personagem passivo) {
        asoes[indice] = new Asao(
            personagemAtivo.aliado, hblt, passivo
        );

        indice += 1;

        personagemAtivo.SetInativo();
        
        if (indice>=aliados.Length) {
            // se todos os personagens já escolheram
            TerminarTurno();
        }
        else {
            // se ainda não
            personagemAtivo = aliados[indice].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }

    // trocar Habildiade por Item quando eu tiver coragem
    void PreencherItems() {
        List<Habilidade> itemsLista = new List<Habilidade>();
        List<string> textos = new List<string>();
        BoxController script = boxItems.GetComponent<BoxController>();

        int nItems = items.Length;
        for(int i=0; i<nItems*2; i+=2) {
            // adicionando os indices na lista
            Habilidade temp = new Habilidade();
            temp.nome = items[i/2].nome;
            temp.custo = items[i/2].quantidade;
            temp.proximoIndice = items[i/2].proximoIndice;

            itemsLista.Add( temp );
            // adicionando o texto na lista pra escrever
            textos.Add(items[i/2].nome);
            textos.Add(items[i/2].quantidade.ToString());
        }
        // adicionando os indices na caixa
        script.SetProximosIndices(itemsLista);
        // mudando o texto da caixa
        script.EscreverTextos(textos, nItems);
    }

    void ComesarTurno() {
        indice = 0;
        personagemAtivo = aliados[indice].GetComponent<Aliado>();
        personagemAtivo.SetAtivo();

        asoes = new Asao[4];
    }

    void TerminarTurno() {
        foreach (Asao asao in asoes) {
            Debug.Log(asao);
        }

        ComesarTurno();
    }

    void Start()
    {
        PreencherItems();
        
        ComesarTurno();
    }
}
