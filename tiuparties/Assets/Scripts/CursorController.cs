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
        // se o char acabou de escolher
        if (boxAtual.proximosIndices[boxAtual.indice].proximoIndice == 0) {
            // manda a habilidade escolhida e a vitima pro aliados controller
            Habilidade hblt = new Habilidade();
            Personagem passivo = new Personagem();
            switch (estagios[estagios.Count-1]) {
                case 0:
                    hblt = boxAtual.proximosIndices[boxAtual.indice];
                    break;
                case 1:
                    hblt = boxes[estagios[estagios.Count-2]].GetComponent<BoxController>()
                        .proximosIndices[
                            boxes[estagios[estagios.Count-2]].GetComponent<BoxController>().indice
                        ];
                    passivo = inimigosController.GetComponent<InimigosController>()
                        .inimigos[boxAtual.indice].GetComponent<Inimigo>().inimigo;
                    break;
                case 2:
                    hblt = boxes[estagios[estagios.Count-2]].GetComponent<BoxController>()
                        .proximosIndices[
                            boxes[estagios[estagios.Count-2]].GetComponent<BoxController>().indice
                        ];
                    passivo = aliadosController.GetComponent<AliadosController>()
                        .aliados[boxAtual.indice].GetComponent<Aliado>().aliado;
                    break;
                case 3:
                    hblt = boxAtual.proximosIndices[boxAtual.indice];
                    break;
                case 4:
                    break;
            }
            ResetarEstagios();
            //manda ativar o proximo personagem
            aliadosController.GetComponent<AliadosController>()
                .SetProximoPersonagem(hblt, passivo);
        }
        // se ainda não
        else {
            estagios.Add(boxAtual.proximosIndices[boxAtual.indice].proximoIndice);
        }

        MudarBox();
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
