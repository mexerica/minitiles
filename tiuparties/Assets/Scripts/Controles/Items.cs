using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Item[] items;

    public int quantidade;

    public void PreencherItems() {
        List<string> textos = new List<string>();
        BoxController script = gameObject.GetComponent<BoxController>();

        int nItems = items.Length;
        for(int i=0; i<nItems*2; i+=2) {
            // adicionando o texto na lista pra escrever
            textos.Add(items[i/2].nome);
            textos.Add(items[i/2].quantidade.ToString());
        }
        // mudando o texto da caixa
        script.SetPossibilidades(textos);
        script.SetQuantidade(nItems);
        script.EscreverTextos();
    }

    public void UseItem(Item itm, Personagem alvo) {

    }

    void Start() {
        PreencherItems();
    }
}
