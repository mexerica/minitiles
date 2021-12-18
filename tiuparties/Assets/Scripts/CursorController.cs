using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] GameObject inimigosController;
    [SerializeField] GameObject aliadosController;
    [SerializeField] GameObject[] boxes;
    BoxController boxAtual;

    //0=menu/1=inimigos/2=aliados/3=secundaria/4=confirmar
    List<int> estagios = new List<int>{0};

    //habilidade e alvo pra passar pro controller de turno
    Habilidade hblt;
    Personagem passivo = new Personagem();

    public void Mover(int axis) {
        Vector3 temp = boxAtual.GetPosicao(axis);
        transform.position = temp;
    }

    void ResetarEstagios() {
        //desativa as caixas auxiliares
            boxes[3].SetActive(false);
            boxes[4].SetActive(false);
            //reseta a lista de estagios do cursor
            estagios = new List<int>{0};
    }

    public void SetEstagioBack() {
        if (estagios.Count > 1) {
            if (estagios[estagios.Count-1] > 2) {
                boxAtual.gameObject.SetActive(false);
            }
            estagios.RemoveAt(estagios.Count-1);

            MudarBox();
        }
        else {
            aliadosController.GetComponent<AliadosController>().SetAntePersonagem();
        }
    }
    public void SetEstagioFwrd() {
        // escolher a habilidade que foi...escolhida
        // ou alvo...
        switch (estagios[estagios.Count-1]) {
            case 0:
                hblt = boxAtual.proximosIndices[boxAtual.indice];
                break;
            case 1:
                passivo = inimigosController.GetComponent<InimigosController>()
                    .inimigos[boxAtual.indice].GetComponent<Inimigo>().inimigo;
                break;
            case 2:
                passivo = aliadosController.GetComponent<AliadosController>()
                    .aliados[boxAtual.indice].GetComponent<Aliado>().aliado;
                break;
            case 3:
                hblt = boxAtual.proximosIndices[boxAtual.indice];
                break;
        }

        // ativar a proxima caixinha
        switch (boxAtual.proximosIndices[boxAtual.indice].proximoIndice) {
            case 0:
                // se o char acabou de escolher
                if (aliadosController.GetComponent<AliadosController>().indice == 3) {
                    if (estagios[estagios.Count-1] == 4) {
                        TerminarEscolha();
                    }
                    else {
                        estagios.Add(4);
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
                estagios.Add(boxAtual.proximosIndices[boxAtual.indice].proximoIndice);
                MudarBox();
                break;
            // se se arrapendeu das escolhas feitas
            case 4:
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
