using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovimento : MonoBehaviour
{
    public CharController controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

    }

    void FixedUpdate() {
        controller.Move(
            horizontalMove * Time.fixedDeltaTime,
            verticalMove * Time.fixedDeltaTime
        );
    }
}
