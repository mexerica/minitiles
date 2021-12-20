using System.Collections.Generic;
using UnityEngine;

public class Aliado : MonoBehaviour
{
    public Personagem personagem;

    [SerializeField] GameObject boxNome;

    [SerializeField] GameObject boxesController;

    [SerializeField] Animator animator;

    public Asao asao;

    void EscreverBoxStats() {
        boxNome.transform.GetChild(0).GetComponent<TextMesh>().text = personagem.nome;
        boxNome.transform.GetChild(1).GetComponent<TextMesh>().text = personagem.hp + "/";
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

    void Start()
    {
        EscreverBoxStats();
    }

    void Update()
    {
        
    }
}
