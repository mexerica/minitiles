using UnityEngine;

public class AliadosController : MonoBehaviour
{
    [SerializeField] GameObject[] aliados;

    public GameObject opsoesBox;

    Aliado personagemAtivo;

    void SetOpsoesTexto() {
        int i=0;
        foreach (Habilidade opsao in personagemAtivo.aliado.classe.opsoes) {
            opsoesBox.transform.GetChild(i).GetComponent<TextMesh>().text = opsao.nome;
            i++;
        }
        opsoesBox.GetComponent<BoxController>().quantidade = i;
    }

    void Start()
    {
        personagemAtivo = aliados[0].GetComponent<Aliado>();

        SetOpsoesTexto();
    }

    void Update()
    {
        
    }
}
