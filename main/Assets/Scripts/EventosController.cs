using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventosController : MonoBehaviour
{
    public TileBase[] tiles; 

    public TileBase veioTile;

    private List<Evento> eventos;
    private Tilemap tilemapa;

    // escolhe o tile certo pro serviço
    public void SetEventTile(Vector3Int pos, int indice) {
        tilemapa.SetTile(pos, tiles[indice-1]);

        eventos.Add( new Evento(pos, indice) );
    }

    // acha o tile na posicao procurada
    Evento GetEventTile(Vector3Int pos) {
        foreach (Evento evento in eventos) {
            if (evento.posicao == pos) {
                return evento;
            }
        }
        return null;
    }

    // switch com os 6 tipos de evento
    void IniciaEvento(Evento evento) {
        switch (evento.tipo) {
            // voltar pro começo
            case 1:
                break;
            case 2:
                tilemapa.SetTile(evento.posicao, veioTile);
                break;
            case 3:
                tilemapa.SetTile(evento.posicao, veioTile);
                break;
            case 4:
                System.Diagnostics.Process.Start("pesquepague.exe");
                break;
            case 5:
                System.Diagnostics.Process.Start("navinha.tic.exe");
                break;
            // chegar no final
            default:
                break;
        }
    }

    // quando o jogador passa por cima do tile
    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            Vector3Int pos = gameObject.GetComponent<Tilemap>().WorldToCell(
                outro.transform.position
            );

            Evento temp = GetEventTile(pos);
            if (temp != null)
                IniciaEvento( temp );
        }
    }

    void Awake() {
        eventos = new List<Evento>();

        tilemapa = gameObject.GetComponent<Tilemap>();
    }
}
