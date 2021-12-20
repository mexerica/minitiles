using UnityEngine;

public class LayerFix : MonoBehaviour
{
    [SerializeField] int ordem;

    void Start()
    {
        for (int i = 0; i< transform.childCount-1; i++) {
            Renderer temp = transform.GetChild(i).GetComponent<Renderer>();
            temp.sortingLayerName = "Secundaria";
            temp.sortingOrder = ordem;
        }
    }
}
