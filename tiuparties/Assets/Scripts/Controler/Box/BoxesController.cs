using System.Collections.Generic;
using UnityEngine;

public class BoxesController : MonoBehaviour
{
    public GameObject boxOpsoes;
    public GameObject boxHabilidades;
    public GameObject boxItems;

    [SerializeField] GameObject boxAliados;
    [SerializeField] GameObject boxInimigos;

    [SerializeField] GameObject boxDescrisao;
    [SerializeField] GameObject boxConfirmar;

    public BoxController boxAtivo;

    public void SetBoxAtivo(int indice) {
        switch (indice) {
            case 0:
                boxAtivo = boxOpsoes.GetComponent<BoxController>();
                break;
            case 1:
                boxAtivo = boxAliados.GetComponent<BoxController>();
                break;
            case 2:
                boxAtivo = boxInimigos.GetComponent<BoxController>();
                break;
            case 3:
                boxAtivo = boxHabilidades.GetComponent<BoxController>();
                break;
            case 4:
                boxAtivo = boxItems.GetComponent<BoxController>();
                break;
            case 5:
                boxAtivo = boxDescrisao.GetComponent<BoxController>();
                break;
            case 6:
                boxAtivo = boxConfirmar.GetComponent<BoxController>();
                break;
        }
        
    }

    public void ResetarBoxes() {
        boxHabilidades.SetActive(false);
        boxItems.SetActive(false);
        boxDescrisao.SetActive(false);
        boxConfirmar.SetActive(false);
    }


}
