using UnityEngine;
using UnityEngine.UI;

public class ShipActionButton : MonoBehaviour
{

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Show()
    {
        image.enabled = true;
    }

    public void Hide()
    {
        image.enabled = false;
    }
}
