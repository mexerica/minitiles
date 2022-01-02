using UnityEngine;

public class Classe : MonoBehaviour
{
    [SerializeField] string nome;

    public Habilidade[] opsoes;

    public Habilidade[] habilidades;

    Personagem ativo;
    Personagem alvo;

    public void UseHabilidade(Personagem ativo, Habilidade hblt, Personagem alvo) {
        this.ativo = ativo;
        this.alvo = alvo;

        Invoke(hblt.metodo, 0);
    }

    void Attack() {
        Debug.Log(ativo.nome + " bateu msm em " + alvo.nome);
        alvo.hp -= (int)(ativo.ataque - alvo.defesa);
    }
    void AttackAll() {
        Debug.Log("taqueitudomundo");
    }

    void Defend() {
        ativo.defesa *= 2;
        Debug.Log("defendi");
    }
    void DefendOutro() {
        ativo.defesa *= 1.5f;
        alvo.defesa *= 2;
        Debug.Log("te defendi");
    }

    void Run() {
        Debug.Log("corre porra");
        transform.parent.GetComponent<AliadosController>().TerminarBatalha();
    }

    void Steal() {
        Debug.Log("roubei nada kkkk");
    }

    void Detect() {
        Debug.Log("detectei");
    }

    void Invisibility() {
        Debug.Log("vo sumi kk");
    }

    void SneakAttack() {
        Debug.Log("facadanascosta");
    }

    void Smoke() {
        Debug.Log("fuma fumassa");
    }

    void Protect() {
        Debug.Log("I protec");
    }

    void Cover() {
        Debug.Log("I cover");
    }

    void Unite() {
        Debug.Log("Nós atac unido");
    }

    void Fire() {
        Debug.Log("fogo");
    }

    void Ice() {
        Debug.Log("gelo");
    }

    void Thunder() {
        Debug.Log("trovão");
    }

    void Cure() {
        Debug.Log("curazinha");
    }

    void Haste() {
        Debug.Log("bora");
    }

    void Counter() {
        Debug.Log("call an ambulance! for you!!!");
    }

    void Charge() {
        Debug.Log("haaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    }

    void Berserk() {
        Debug.Log("me segura!");
    }

}
