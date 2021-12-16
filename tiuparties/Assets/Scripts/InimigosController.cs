using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosController : MonoBehaviour
{
    [SerializeField] GameObject[] inimigos;

    public GameObject nomesBox;

    void SetNomesTexto() {
        for (int i=0; i<inimigos.Length; i++) {
            nomesBox.transform.GetChild(i).GetComponent<TextMesh>().text = 
                inimigos[i].GetComponent<Inimigo>().inimigo.nome;
        }
    }

    void Start()
    {
        SetNomesTexto();
    }

    void Update()
    {
        
    }
}
