using UnityEngine;

public class IscaMovimento : MonoBehaviour
{
    public IscaController controller;

    [Range(1f, 75f)] public float forsa = 75f;

    public bool isLansada = false;

    float horizontalMove = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * forsa;

    }

    void FixedUpdate() {
        if ( horizontalMove < 0 && isLansada == false) {
            controller.LansarIsca(horizontalMove);
            isLansada = true;
        }
        else if (horizontalMove > 0 && controller.isUnderAgua) {
            controller.Carretar();
        }
    }
}
