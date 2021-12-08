using UnityEngine;

public class PeixeController : MonoBehaviour
{
    [Range(.0001f, .01f)] public float velocidade = .004f;

    public int tipo;

    private bool isFisgado = false;
    private bool isEsquerdando = true;

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            IscaController controller = outro.GetComponent<IscaController>();

            if (!controller.isFisgando) {
                isFisgado = true;
                controller.Fisgar(tipo, gameObject);

                transform.position = outro.transform.position;
                if (isEsquerdando) Flip();
            }
        }
    }

    public void SerPescado() {
        Destroy(gameObject);
    }

    public void Fugir() {
        Destroy(gameObject);
    }

    public void Flip()
	{
		// Switch the way the peixe is labelled as facing.
		isEsquerdando = !isEsquerdando;

		// Multiply the peixe's x local scale by -1.
		Vector3 posTemp = transform.localScale;
		posTemp.x *= -1;
		transform.localScale = posTemp;
	}

    void FixedUpdate() {
        if (!isFisgado) {
            if (isEsquerdando) {
                transform.position += new Vector3(-velocidade, 0, 0);
            }
            else {
                transform.position += new Vector3(velocidade, 0, 0);
            }
        }
    }
}
