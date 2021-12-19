using UnityEngine;

public class IscaController : MonoBehaviour
{
    [SerializeField] IscaMovimento movimento;

    [SerializeField] GameObject forsa;

    [SerializeField] GameObject pescador;

    public bool isUnderAgua = false;

    public bool isFisgando = false;

    private Rigidbody2D corpo;
    private Vector3 posOrigem;

    private GameObject peixe;

    Animator pescadorAnimator;

    private int nPuxadas;
    private int tipoPeixe;

    public void EscolherForsa() {
        //animar o lansamento
        pescadorAnimator.SetBool("preparar", true);

        forsa.SetActive(true);
    }

    public void LansarIsca() {
        //desanimar o lansamento
        pescadorAnimator.SetBool("preparar", false);

        float valor = forsa.GetComponent<ForsaController>().Retornar();
        forsa.SetActive(false);
        corpo.AddForce( new Vector2(-valor, 50f) );
        corpo.gravityScale = .7f;
    }

    public void Afundar() {
        isUnderAgua = true;
        corpo.position = new Vector3(corpo.position.x, 0.08f, 0);
        corpo.AddForce( new Vector2(-1f, -5f) );

        corpo.gravityScale = 0.2f;
    }

    public void Carretar() {
        corpo.AddForce( new Vector2(10f, 1f) );
    }

    public void GuardarIsca() {
        transform.position = posOrigem;

        isUnderAgua = false;
        movimento.isLansada = false;

        corpo.velocity = Vector3.zero;
        corpo.gravityScale = 0;
    }

    public void Fisgar(int tipo, GameObject sprite) {
        forsa.SetActive(true);

        isFisgando = true;
        peixe = sprite;
        nPuxadas = 0;
        tipoPeixe = tipo;

        corpo.velocity = Vector3.zero;
        corpo.gravityScale = 0;
        Flip();

        forsa.GetComponent<ForsaController>().ChamarAlvo();
        
    }

    void DesFisgar() {
        isFisgando = false;

        forsa.SetActive(false);
        Flip();
        GuardarIsca();
    }

    public void ChecarAlvo() {
        bool puxada = forsa.GetComponent<ForsaController>().Alvar();

        // se acertou o alvo
        if (puxada) {
            nPuxadas+=1;

            if (nPuxadas < tipoPeixe+1) {
                forsa.GetComponent<ForsaController>().ChamarAlvo();
            }
            else {
                Pescar();
            }
        }
        // se quebrou a linha
        else {
            Quebrar();
        }
    }

    public void Pescar() {
        pescador.GetComponent<PescadorController>().Pegar(peixe);

        peixe.GetComponent<PeixeController>().SerPescado();

        DesFisgar();
        
    }

    void Quebrar() {
        pescador.GetComponent<PescadorController>().Perder();

        peixe.GetComponent<PeixeController>().Fugir();

        DesFisgar();
    }

    public void Flip()
	{
		// Multiply the peixe's x local scale by -1.
		Vector3 posTemp = transform.localScale;
		posTemp.x *= -1;
		transform.localScale = posTemp;
	}

    void Start()
    {
        corpo = gameObject.GetComponent<Rigidbody2D>();

        pescadorAnimator = pescador.GetComponent<Animator>();

        posOrigem = transform.position;
    }

    void FixedUpdate()
    {
        if (isUnderAgua) {
            corpo.velocity = Vector3.zero;
        }
    }
}
