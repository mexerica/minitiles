using UnityEngine;

public class InimigosController : MonoBehaviour
{
    public Inimigos inimigos;

    public AliadosController aliados;

    public void MandarAgir() {
        aliados.ComesarTurno();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
