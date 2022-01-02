using System.Collections.Generic;
using UnityEngine;

public class Aliado : MonoBehaviour
{
    public Personagem personagem;

    [SerializeField] GameObject boxNome;

    [SerializeField] GameObject boxesController;

    [SerializeField] Animator animator;

    Asao asao;

    void EscreverBoxStats() {
        boxNome.transform.GetChild(0).GetComponent<TextMesh>().text = personagem.nome;
        TextMesh hpAtual = boxNome.transform.GetChild(1).GetComponent<TextMesh>();
        if (personagem.hp < personagem.hpMax * 0.25f)
            hpAtual.color = new Color(235f/255f, 5f/255f, 0);
        else
            hpAtual.color = new Color(1f, 1f, 1f);
        hpAtual.text = personagem.hp + "/";
        
        boxNome.transform.GetChild(2).GetComponent<TextMesh>().text = personagem.hpMax.ToString();
    }

    public void SetAtivo() {
        // preencher os textos das opsoes
        boxesController.GetComponent<BoxesController>()
            .boxOpsoes.GetComponent<Habilidades>()
            .PreencherOpsoes(personagem.classe.opsoes);
        // preencher os textos das habilidades
        boxesController.GetComponent<BoxesController>()
            .boxHabilidades.GetComponent<Habilidades>()
            .PreencherHabilidades(personagem.classe.habilidades);

        // anima o char
        animator.SetBool("isSelecionado", true);

        // muda a cor da caixinha
        boxNome.GetComponent<SpriteRenderer>().color =
            new Color(57f/255f, 181f/255f, 74f/255f);
    }
    public void SetInativo() {
        // anima o char
        animator.SetBool("isSelecionado", false);

        // muda a cor da caixinha
        boxNome.GetComponent<SpriteRenderer>().color =
            new Color(1f, 1f, 1f);
    }

    public void SetAsao(Habilidade hblt, Personagem alvo) {
        asao = new Asao(personagem, hblt, alvo);
    }
    public void SetAsao(Item itm, Personagem alvo) {
        asao = new Asao(personagem, itm, alvo);
    }

    public void Agir() {
        asao.Agir();
        asao = new Asao();
    }

    public void Apanhar() {
        
    }

    void Start()
    {
        EscreverBoxStats();
    }

    void Update()
    {
        
    }
}
