using UnityEngine;

public class Aliado : MonoBehaviour
{
    public Personagem aliado;

    public GameObject box;

    void EscreverBox() {
        box.transform.GetChild(0).GetComponent<TextMesh>().text = aliado.nome;
        box.transform.GetChild(1).GetComponent<TextMesh>().text = aliado.hp + "/";
        box.transform.GetChild(2).GetComponent<TextMesh>().text = aliado.hpMax.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        EscreverBox();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
