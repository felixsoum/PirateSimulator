using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackgroundHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameDirector gameDirector;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameDirector.OnBackgroundClick();
    }
}
