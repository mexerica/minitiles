using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int indice = 0;

    [SerializeField] Vector3[] posicoes;

    public List<string> possibilidades;

    [SerializeField] int quantidade;

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

    public void SetPossibilidades(List<string> lista) {
        possibilidades = lista;
    }

    public void SetQuantidade(int qnt) {
        quantidade = qnt;
    }

    public void EscreverTextos() {
        ApagarTextos();

        for (int i=0; i<possibilidades.Count; i++) {
            transform.GetChild(i).GetComponent<TextMesh>().text = possibilidades[i];
        }
    }

    void ApagarTextos() {
        for(int i=0; i<transform.childCount-1; i++) {
            transform.GetChild(i).GetComponent<TextMesh>().text = "";
        }
    }

    public void SetAtivo() {
        gameObject.SetActive(true);
    }
    public void SetInativo() {
        gameObject.SetActive(false);
    }

}
