using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] GameObject aliadosController;
    [SerializeField] GameObject[] boxes;
    BoxController boxAtual;

    //0=menu/1=inimigos/2=aliados/3=secundaria/4=confirmar
    List<int> estagios = new List<int>{0};

    public void Mover(int axis) {
        Vector3 temp = boxAtual.GetPosicao(axis);
        transform.position = temp;
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
        if (boxAtual.proximosIndices[boxAtual.indice] == 0) {
            boxes[3].SetActive(false);
            boxes[4].SetActive(false);
            estagios = new List<int>{0};
            aliadosController.GetComponent<AliadosController>().SetProximoPersonagem();
        }
        else {
            estagios.Add(boxAtual.proximosIndices[boxAtual.indice]);
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
