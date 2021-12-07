using UnityEngine;

public class LinhaController : MonoBehaviour
{
    private LineRenderer linha;
    
    void Start()
    {
        linha = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        linha.SetPosition(1, transform.parent.position);
    }
}
