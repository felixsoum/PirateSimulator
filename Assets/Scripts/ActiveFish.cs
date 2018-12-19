using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFish : MonoBehaviour
{
    private bool isDragging;
    new Camera camera;

    Vector3 initialPos;
    public Action<ActiveFish> OnReset;

    internal void StartDrag()
    {
        initialPos = transform.localPosition;
        camera = Camera.main;
        this.isDragging = true;
    }

    void Update()
    {
        if (isDragging)
        {
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                transform.localPosition = initialPos;
                OnReset(this);
                return;
            }
            Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }
}
