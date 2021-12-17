using System.Collections.Generic;
using UnityEngine;

public class Aliado : MonoBehaviour
{
    public Personagem aliado;

    [SerializeField] GameObject boxOpsoes;

    [SerializeField] GameObject boxNome;

    [SerializeField] GameObject boxHabilidades;

    [SerializeField] Animator animator;

    void EscreverBox() {
        boxNome.transform.GetChild(0).GetComponent<TextMesh>().text = aliado.nome;
        boxNome.transform.GetChild(1).GetComponent<TextMesh>().text = aliado.hp + "/";
        boxNome.transform.GetChild(2).GetComponent<TextMesh>().text = aliado.hpMax.ToString();
    }

    public void SetAtivo() {
        // preencher os textos das caixinhas
        PreencherOpsoes();
        PreencherHabilidades();

        // anima o char
        animator.SetBool("isSelecionado", true);

        // muda a cor da caixinha
        boxNome.GetComponent<SpriteRenderer>().color =
            new Color(57f/255f, 181f/255f, 74f/255f);
    }
    public void SetInativo() {
        // apaga os textos do personagem
        boxOpsoes.GetComponent<BoxController>().ApagarTextos();
        boxHabilidades.GetComponent<BoxController>().ApagarTextos();

        // anima o char
        animator.SetBool("isSelecionado", false);

        // muda a cor da caixinha
        boxNome.GetComponent<SpriteRenderer>().color =
            new Color(1f, 1f, 1f);
    }

    void PreencherOpsoes() {
        List<int> indices = new List<int>();
        List<string> textos = new List<string>();
        BoxController script = boxOpsoes.GetComponent<BoxController>();

        int i=0;
        foreach (Habilidade opsao in aliado.classe.opsoes) {
            //adiciona o indice na lista
            indices.Add(opsao.proximoIndice);
            // adicionando o texto na lista pra escrever
            textos.Add(opsao.nome);
            i++;
        }
        // adicionando os indices na caixa
        script.SetProximosIndices(indices);
        // mudando o texto da caixa
        script.EscreverTextos(textos, i);
    }

    void PreencherHabilidades() {
        List<int> indices = new List<int>();
        List<string> textos = new List<string>();
        BoxController script = boxHabilidades.GetComponent<BoxController>();

        int nHabilidades = aliado.classe.habilidades.Length;
        for(int i=0; i<nHabilidades*2; i+=2) {
            // adicionando os indices na lista
            indices.Add(aliado.classe.habilidades[i/2].proximoIndice);
            // adicionando o texto na lista pra escrever
            textos.Add(aliado.classe.habilidades[i/2].nome);
            textos.Add(aliado.classe.habilidades[i/2].custo + "hp");
        }
        // adicionando os indices na caixa
        script.SetProximosIndices(indices);
        // mudando o texto da caixa
        script.EscreverTextos(textos, nHabilidades);
    }

    void Start()
    {
        EscreverBox();
    }

    void Update()
    {
        
    }
}
