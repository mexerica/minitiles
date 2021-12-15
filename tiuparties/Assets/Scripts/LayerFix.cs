using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerFix : MonoBehaviour
{
    public int ordem;

    void Start()
    {
        for (int i = 0; i< transform.childCount-1; i++) {
            Renderer temp = transform.GetChild(i).GetComponent<Renderer>();
            temp.sortingLayerName = "Secundaria";
            temp.sortingOrder = ordem;
        }
    }
}
