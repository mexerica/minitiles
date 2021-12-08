using UnityEngine;

public class PescadorController : MonoBehaviour
{
    public GameObject peixes;

    public int objetivoPeixes = 3;

    int nPescados;

    int qntPeixes;

    void Pendurar(GameObject peixe) {
        Transform carcasa = Instantiate(
            peixe.transform.GetChild(0),
            new Vector3(.42f+(nPescados/100), .38f+(nPescados/50), 0),
            Quaternion.Euler(0, 0, (nPescados*5)-100)
        );
        carcasa.parent = transform;
    }

    public void Pegar(GameObject peixe) {
        nPescados += 1;

        Pendurar(peixe);

        if (nPescados >= objetivoPeixes) {
            Application.Quit();
        }

    }

    public void Perder() {
        qntPeixes -= 1;

        if (qntPeixes <= 0) {
            Application.Quit();
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
