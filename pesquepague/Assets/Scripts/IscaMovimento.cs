using UnityEngine;

public class IscaMovimento : MonoBehaviour
{
    [SerializeField] IscaController controller;

    public bool isLansada = false;

    void Start()
    {
        
    }

    void Update() {
        if (isLansada == false) {
            if ( Input.GetKeyDown("left") ) {
                controller.EscolherForsa();
            }
            else if (Input.GetKeyUp("left")) {
                controller.LansarIsca();
                isLansada = true;
            }
        }
        else if (Input.GetKey("right")
                 && controller.isUnderAgua
                 && !controller.isFisgando) {
            controller.Carretar();
        }
        else if (Input.GetKeyDown("right") && controller.isFisgando) {
            controller.ChecarAlvo();
        }
    }
}
