using UnityEngine;

public class CursorMovimento : MonoBehaviour
{
    [SerializeField] CursorController controller;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    bool isMovendo = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1")) {
            controller.SetEstagioFwrd();
        }
        else if (Input.GetButtonDown("Fire2")) {
            controller.SetEstagioBack();
        }
    }

    void FixedUpdate() {
        
        if (!isMovendo) {
            if (horizontalMove > 0) {
                controller.Mover(4);
                isMovendo = true;
            }
            else if (horizontalMove < 0) {
                controller.Mover(-4);
                isMovendo = true;
            }
            if (verticalMove > 0) {
                controller.Mover(-1);
                isMovendo = true;
            }
            else if (verticalMove < 0) {
                controller.Mover(1);
                isMovendo = true;
            }
        }
        else if (horizontalMove == 0 && verticalMove == 0) {
            isMovendo = false;
        }
    }
}
