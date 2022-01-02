using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Item[] items;

    Personagem alvo;

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
        this.alvo = alvo;

        Invoke(itm.metodo, 0);

        itm.quantidade-=1;
        PreencherItems();
    }

    void Potion() {
        alvo.hp += 50;
        Debug.Log("poção, de boa");
    }

    void Antidote() {
        Debug.Log("sai veneno");
    }

    void Revive() {
        Debug.Log("uma pá e uma ideia na cabeça");
    }

    void Bomb() {
        alvo.hp -= 100;
        Debug.Log("papara papara");
    }

    void Start() {
        PreencherItems();
    }
}
