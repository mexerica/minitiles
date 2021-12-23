using System.Collections.Generic;
using UnityEngine;

public class AliadosController : MonoBehaviour
{
    public Aliados aliados;

    [SerializeField] Aliado personagemAtivo;

    public int atual;

    public void GuardarAsao(Habilidade hblt, Personagem passivo) {
        personagemAtivo.SetAsao(hblt, passivo);
        SetProximoPersonagem();
    }
    public void GuardarAsao(Item itm, Personagem passivo) {
        personagemAtivo.SetAsao(itm, passivo);
        SetProximoPersonagem();
    }

    public void SetAntePersonagem() {
        if (atual > 0) {
            atual -= 1;
            personagemAtivo.SetInativo();
            personagemAtivo = aliados.aliados[atual % aliados.quantidade].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }
    void SetProximoPersonagem() {
        atual += 1;

        personagemAtivo.SetInativo();
        
        if (atual>=aliados.quantidade) {
            // se todos os personagens já escolheram
            TerminarTurno();
        }
        else {
            // se ainda não
            personagemAtivo = aliados.aliados[atual].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }

    void ComesarTurno() {
        // vai ter q adicionar um teste pra ver se o char ta vivo
        atual = 0;
        personagemAtivo = aliados.aliados[atual].GetComponent<Aliado>();
        personagemAtivo.SetAtivo();
    }

    void TerminarTurno() {
        foreach (Aliado aliado in aliados.aliados) {
           aliado.Agir();
        }

        ComesarTurno();
    }

    void Start()
    {
        ComesarTurno();
    }
}
