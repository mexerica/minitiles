using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comecar : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Abrir());
    }

    IEnumerator Abrir() {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("400");
    }
}
