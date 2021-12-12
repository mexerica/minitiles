using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject[] boxes;
    BoxController boxAtual;

    //0=menu/1=inimigos/2=submenu/3=confirmar
    int estagio = 0;

    public void Mover(int axis) {
        Vector3 temp = boxAtual.GetPosicao(axis);
        transform.position = temp;
    }

    public void SetEstagio(int axis) {
        int temp = estagio + axis;
        if (temp >= 0) {
            if (temp <= 3) {
                estagio += axis;
            }
            else {
                estagio = 0;
            }
        }

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
