using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliadosController : MonoBehaviour
{
    [SerializeField] Aliado[] aliados;

    Aliado personagemAtivo;

    void Start()
    {
        personagemAtivo = aliados[0];
    }

    void Update()
    {
        
    }
}
