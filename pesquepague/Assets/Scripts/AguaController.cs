using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaController : MonoBehaviour
{
    public GameObject player;
    IscaController isca;

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            if (!isca.isUnderAgua) {
                isca.Afundar();
            }
            else {
                isca.GuardarIsca();
            }
        }
    }

    void Start() {
        isca = player.GetComponent<IscaController>();
    }
}
