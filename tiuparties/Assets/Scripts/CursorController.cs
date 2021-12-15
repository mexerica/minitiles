using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject[] boxes;
    BoxController boxAtual;

    //0=menu/1=inimigos/2=aliados/3=secundaria/4=confirmar
    int estagio = 0;

    public void Mover(int axis) {
        Vector3 temp = boxAtual.GetPosicao(axis);
        transform.position = temp;
    }

    public void SetEstagio(int axis) {
        estagio = axis;

        MudarBox();
    }

    void MudarBox() {
        boxAtual = boxes[estagio].GetComponent<BoxController>();

        Mover(0);
    }

    void Start() {
        MudarBox();
    }
}
