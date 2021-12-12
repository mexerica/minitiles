using System;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int quantidade;

    public int indice = 0;

    [SerializeField] Vector3[] posicoes;

    public Vector3 GetPosicao(int i) {
        int temp = indice + i;

        if (temp == quantidade) {
            indice = 0;
        }
        else if (temp == -1) {
            indice = quantidade-1;
        }
        else if (temp < -1) {
            temp = indice - i;
            if (temp >= 0 && temp < quantidade)
                indice = temp;
            else
            indice = 0;
        }
        else if (temp > quantidade) {
            temp = indice - i;
            if (temp >= 0 && temp < quantidade)
                indice = temp;
            else
                indice = quantidade - 1;
        }
        else
            indice = temp;

        return posicoes[indice];
    }

}
