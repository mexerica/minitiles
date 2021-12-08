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
        else if (outro.tag == "Peixe") {
            outro.GetComponent<PeixeController>().Flip();
        }
    }

    void Start() {
        isca = player.GetComponent<IscaController>();
    }
}
