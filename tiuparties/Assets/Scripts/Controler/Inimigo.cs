using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Personagem personagem;

    [SerializeField] GameObject nomeMesh;

    Asao asao;

    void EscreverMesh() {
        nomeMesh.GetComponent<TextMesh>().text = personagem.nome;
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
