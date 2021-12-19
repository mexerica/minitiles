using UnityEngine;
using UnityEngine.SceneManagement;

public class PescadorController : MonoBehaviour
{
    [SerializeField] GameObject peixes;

    [SerializeField] int objetivoPeixes = 3;

    int nPescados;

    int qntPeixes;

    void Pendurar(GameObject peixe) {
        Transform carcasa = Instantiate(
            peixe.transform.GetChild(0),
            new Vector3(
                .38f+((float)nPescados/50f),
                .40f-((float)nPescados/100f),
                0
            ),
            Quaternion.Euler(0, 0, (nPescados*5)-100)
        );
        carcasa.parent = transform;
    }

    public void Pegar(GameObject peixe) {
        nPescados += 1;

        Pendurar(peixe);

        if (nPescados >= objetivoPeixes) {
            SceneManager.LoadScene("401");
        }

    }

    public void Perder() {
        qntPeixes -= 1;

        if (qntPeixes <= 0) {
            SceneManager.LoadScene("404");
        }
    }

    void Start()
    {
        nPescados = 0;
        qntPeixes = peixes.GetComponent<PeixesSpawner>().Popular();
    }

    void Update()
    {
        
    }
}
