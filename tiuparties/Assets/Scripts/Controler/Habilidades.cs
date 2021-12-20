using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    public Habilidade[] habilidades;

    public int quantidade;

    public void PreencherOpsoes(Habilidade[] opsoes) {
        List<string> textos = new List<string>();
        BoxController script = gameObject.GetComponent<BoxController>();
        habilidades = opsoes;

        int i=0;
        foreach (Habilidade opsao in opsoes) {
            // adicionando o texto na lista pra escrever
            textos.Add(opsao.nome);
            i++;
        }
        // mudando o texto da caixa
        script.SetPossibilidades(textos);
        script.SetQuantidade(i);
        script.EscreverTextos();
    }

    public void PreencherHabilidades(Habilidade[] hbldds) {
        List<string> textos = new List<string>();
        BoxController script = gameObject.GetComponent<BoxController>();
        habilidades = hbldds;

        int nHabilidades = hbldds.Length;
        for(int i=0; i<nHabilidades*2; i+=2) {
            // adicionando o texto na lista pra escrever
            textos.Add(hbldds[i/2].nome);
            textos.Add(hbldds[i/2].custo + "hp");
        }
        // mudando o texto da caixa
        script.SetPossibilidades(textos);
        script.SetQuantidade(nHabilidades);
        script.EscreverTextos();
    }
}
