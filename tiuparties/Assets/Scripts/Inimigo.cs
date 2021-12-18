using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Personagem inimigo;

    [SerializeField] GameObject nomeMesh;

    void EscreverMesh() {
        nomeMesh.GetComponent<TextMesh>().text = inimigo.nome;
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
