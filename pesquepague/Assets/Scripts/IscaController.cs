using UnityEngine;

public class IscaController : MonoBehaviour
{
    public IscaMovimento movimento;

    public bool isUnderAgua = false;

    private Rigidbody2D corpo;
    private Vector3 posOrigem;

    public void LansarIsca(float forsa) {
        corpo.AddForce( new Vector2(forsa, 50f) );
        corpo.gravityScale = .7f;
    }

    public void Carretar() {
        corpo.AddForce( new Vector2(10f, -2f) );
    }

    public void Afundar() {
        isUnderAgua = true;
        corpo.gravityScale = 0.2f;
    }

    public void GuardarIsca() {
        transform.position = posOrigem;
        isUnderAgua = false;
        movimento.isLansada = false;
        corpo.velocity = Vector3.zero;
        corpo.gravityScale = 0;
    }

    void Start()
    {
        corpo = gameObject.GetComponent<Rigidbody2D>();
        posOrigem = transform.position;
    }

    void FixedUpdate()
    {
        if (isUnderAgua) {
            corpo.velocity = Vector3.zero;
        }
    }
}
