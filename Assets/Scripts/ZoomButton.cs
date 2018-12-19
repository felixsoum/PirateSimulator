using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomButton : MonoBehaviour
{
    [SerializeField] Sprite mainSprite;
    [SerializeField] Sprite shipSprite;
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Toggle()
    {
        image.sprite = image.sprite == mainSprite ? shipSprite : mainSprite;
    }


}
