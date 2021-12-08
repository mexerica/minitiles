using System.Collections;
using UnityEngine;

public class Terminar : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Fechar());
    }

    IEnumerator Fechar() {
        yield return new WaitForSeconds(4);

        Application.Quit();
    }
}
