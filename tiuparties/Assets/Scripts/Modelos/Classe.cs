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
        alvo.hp -= 15;
        Debug.Log(ativo.nome + " bateu msm em " + alvo.nome);
    }

}
