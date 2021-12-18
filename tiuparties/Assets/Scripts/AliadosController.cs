using UnityEngine;

public class AliadosController : MonoBehaviour
{
    public GameObject[] aliados;

    [SerializeField] Aliado personagemAtivo;

    public int indice;

    Asao[] asoes;

    public void SetAntePersonagem() {
        if (indice > 0) {
            indice -= 1;
            personagemAtivo.SetInativo();
            personagemAtivo = aliados[indice % aliados.Length].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }
    public void SetProximoPersonagem(Habilidade hblt, Personagem passivo) {
        asoes[indice] = new Asao(
            personagemAtivo.aliado, hblt, passivo
        );

        indice += 1;

        personagemAtivo.SetInativo();
        
        if (indice>=aliados.Length) {
            // se todos os personagens já escolheram
            TerminarTurno();
        }
        else {
            // se ainda não
            personagemAtivo = aliados[indice].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }

    void ComesarTurno() {
        indice = 0;
        personagemAtivo = aliados[indice].GetComponent<Aliado>();
        personagemAtivo.SetAtivo();

        asoes = new Asao[4];
    }

    void TerminarTurno() {
        foreach (Asao asao in asoes) {
            Debug.Log(asao);
        }

        ComesarTurno();
    }

    void Start()
    {
        ComesarTurno();
    }
}
