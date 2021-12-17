using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int indice = 0;

    [SerializeField] int quantidade;

    public List<int> proximosIndices;

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

    public void SetProximosIndices(List<int> lista) {
        proximosIndices = lista;
    }

    public void EscreverTextos(List<string> textos, int qnt) {
        for (int i=0; i<textos.Count; i++) {
            transform.GetChild(i).GetComponent<TextMesh>().text = textos[i];
        }
        quantidade = qnt;
    }

    public void ApagarTextos() {
        for(int i=0; i<transform.childCount-1; i++) {
            transform.GetChild(i).GetComponent<TextMesh>().text = "";
        }
    }

}
