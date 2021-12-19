using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] GameObject aliadosController;
    [SerializeField] GameObject inimigosController;
    [SerializeField] GameObject[] boxes;
    BoxController boxAtual;

    //0=menu/1=inimigos/2=aliados/3=habilidades/4=itens/5=confirmar
    List<int> estagios = new List<int>{0};

    //habilidade/item e alvo pra passar pro controller de turno
    Habilidade hblt;
    Item item;
    Personagem passivo;

    public void Mover(int axis) {
        Vector3 temp = boxAtual.GetPosicao(axis);
        transform.position = temp;
    }

    void ResetarEstagios() {
        //desativa as caixas auxiliares
        boxes[3].SetActive(false);
        boxes[4].SetActive(false);
        boxes[5].SetActive(false);
        //reseta a lista de estagios do cursor
        estagios = new List<int>{0};
    }

    public void SetEstagioBack() {
        // se dá pra voltar mais
        if (estagios.Count > 1) {
            // desativa a box se precisar
            if (estagios[estagios.Count-1] > 2) {
                boxAtual.gameObject.SetActive(false);
            }
            estagios.RemoveAt(estagios.Count-1);

            MudarBox();
        }
        // se já voltou tudo
        else {
            aliadosController.GetComponent<AliadosController>().SetAntePersonagem();
        }
    }
    public void SetEstagioFwrd() {
        // escolher a habilidade que foi...escolhida
        // ou alvo...
        switch (estagios[estagios.Count-1]) {
            //caixas com habilidades/items
            case 0:
            case 3:
            case 4:
                hblt = boxAtual.proximosIndices[boxAtual.indice];
                passivo = new Personagem();
                break;
            //caixa com inimigos
            case 1:
                passivo = inimigosController.GetComponent<InimigosController>()
                    .inimigos[boxAtual.indice].GetComponent<Inimigo>().inimigo;
                break;
            //caixa com aliados
            case 2:
                passivo = aliadosController.GetComponent<AliadosController>()
                    .aliados[boxAtual.indice].GetComponent<Aliado>().aliado;
                break;
        }

        // ativar a proxima caixinha
        switch (boxAtual.proximosIndices[boxAtual.indice].proximoIndice) {
            // se o char acabou de escolher
            case 0:
                // se todos os chars já escolheram
                if (aliadosController.GetComponent<AliadosController>().indice == 3) {
                    // se ele confirmou as escolhas
                    if (estagios[estagios.Count-1] == 5) {
                        TerminarEscolha();
                    }
                    // vai pra caixa de confirmar escolhas
                    else {
                        estagios.Add(5);
                        MudarBox();
                    }
                }
                // se ainda não
                else {
                    TerminarEscolha();
                }
                break;
            // se ainda ta escolhendo
            case 1:
            case 2:
            case 3:
            case 4:
                // vai pra proxima caixa
                estagios.Add(boxAtual.proximosIndices[boxAtual.indice].proximoIndice);
                MudarBox();
                break;
            // se se arrapendeu das escolhas feitas
            case 5:
            default:
                SetEstagioBack();
                break;
        }
    }

    void TerminarEscolha() {
        // reseta os boxes
        ResetarEstagios();
        MudarBox();
        //manda ativar o proximo personagem
        aliadosController.GetComponent<AliadosController>()
            .SetProximoPersonagem(hblt, passivo);
    }

    void MudarBox() {
        boxAtual = boxes[estagios[estagios.Count-1]].GetComponent<BoxController>();
        if (estagios[estagios.Count-1] > 2) {
            boxAtual.gameObject.SetActive(true);
        }

        Mover(0);
    }

    void Start() {
        MudarBox();
    }
}
