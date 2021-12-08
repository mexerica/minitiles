using UnityEngine;

public class PeixesSpawner : MonoBehaviour
{
    public GameObject[] peixes;

    public int[] quantidades;

    void Spawnar(GameObject peixe, int i) {
        Vector3 ponto = new Vector3(
            Random.Range(-.4f, 0),
            Random.Range(-(((i+1)*.13f)-.05f), -(((i)*.13f)-.05f)),
            0
        );
        GameObject p = Instantiate(peixe, ponto, Quaternion.identity);
        p.transform.parent = transform;
        p.GetComponent<PeixeController>().tipo = i;
    }

    public int Popular() {
        int cont = 0;
        for (int i=0; i<peixes.Length; i++) {
            for (int j=0; j<quantidades[i]; j++) {
                Spawnar(peixes[i], i);
                cont += 1;
            }
        }
        return cont;
    }

    void Start() {
        
    }
}
