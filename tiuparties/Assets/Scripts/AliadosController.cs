using UnityEngine;

public class AliadosController : MonoBehaviour
{
    [SerializeField] GameObject[] aliados;

    [SerializeField] Aliado personagemAtivo;

    int indice = -1;

    public void SetAntePersonagem() {
        if (indice > 0) {
            indice -= 1;
            personagemAtivo.SetInativo();
            personagemAtivo = aliados[indice % aliados.Length].GetComponent<Aliado>();
            personagemAtivo.SetAtivo();
        }
    }
    public void SetProximoPersonagem() {
        indice += 1;

        if (personagemAtivo != null)
            personagemAtivo.SetInativo();
        
        if (indice>=aliados.Length) {
            TerminarTurno();

            indice = 0;
            personagemAtivo = aliados[indice].GetComponent<Aliado>();
        }
        else {
            personagemAtivo = aliados[indice].GetComponent<Aliado>();
        }
        
        personagemAtivo.SetAtivo();
    }

    void TerminarTurno() {
        Debug.Log("Pode vir me limpar.");
    }

    void Start()
    {
        SetProximoPersonagem();
    }

    void Update()
    {
        
    }
}
