using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject shipCamera;
    [SerializeField] PlayerShip playerShip;
    [SerializeField] GameObject collectableFishPrefab;
    [SerializeField] int initialFishCount = 100;
    [SerializeField] float mapSize = 100.0f;

    private bool isMainView = true;

    private void Awake()
    {
        for (int i = 0; i < initialFishCount; i++)
        {
            Instantiate(collectableFishPrefab, new Vector3(UnityEngine.Random.Range(-mapSize, mapSize),
                UnityEngine.Random.Range(-mapSize, mapSize), 0), Quaternion.identity);
        }
    }

    public void ToggleCamera()
    {
        isMainView = !isMainView;
        mainCamera.SetActive(isMainView);
        shipCamera.SetActive(!isMainView);
    }

    internal void OnBackgroundClick()
    {
        if (isMainView)
        {
            playerShip.OnRotateClick();
        }
    }
}
