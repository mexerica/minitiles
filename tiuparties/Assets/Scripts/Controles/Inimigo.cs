using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Personagem personagem;

    [SerializeField] GameObject nomeMesh;

    [SerializeField] Aliados aliados;

    Asao asao;

    void EscreverMesh() {
        nomeMesh.GetComponent<TextMesh>().text = personagem.nome;
    }

    void EscolherAsao() {
        asao = new Asao(
            personagem,
            personagem.classe.opsoes[0],
            aliados.aliados[Random.Range(0,4)].personagem
        );
    }

    public void Agir() {
        EscolherAsao();

        asao.Agir();
        asao = new Asao();
    }

    public void Apanhar() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        EscreverMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
