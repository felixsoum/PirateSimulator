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
    [SerializeField] GameObject collectableCrewPrefab;
    [SerializeField] CrewPanel crewPanel;
    [SerializeField] int initialFishCount = 100;
    [SerializeField] int initialCrewCount = 20;
    [SerializeField] float mapSize = 100.0f;
    public bool IsFishing { get; set; }
    private bool isMainView = true;

    private void Awake()
    {
        for (int i = 0; i < initialFishCount; i++)
        {
            var fishObject = Instantiate(collectableFishPrefab, new Vector3(UnityEngine.Random.Range(-mapSize, mapSize),
                UnityEngine.Random.Range(-mapSize, mapSize), 0), Quaternion.identity);

            var collectable = fishObject.GetComponent<CollectableActor>();
            collectable.Player = playerShip;
            collectable.Game = this;
        }

        for (int i = 0; i < initialCrewCount; i++)
        {
            var crewObject = Instantiate(collectableCrewPrefab, new Vector3(UnityEngine.Random.Range(-mapSize, mapSize),
                UnityEngine.Random.Range(-mapSize, mapSize), 0), Quaternion.identity);

            var collectable = crewObject.GetComponent<CollectableActor>();
            collectable.Player = playerShip;
            collectable.Game = this;

        }
    }

    public void ToggleCamera()
    {
        isMainView = !isMainView;
        mainCamera.SetActive(isMainView);
        shipCamera.SetActive(!isMainView);
        if (isMainView)
        {
            crewPanel.gameObject.SetActive(false);

        }
    }

    internal void OnBackgroundClick()
    {
        if (isMainView && !IsFishing)
        {
            playerShip.OnRotateClick();
        }
    }

    internal void OnCrewClick(ActiveCrew activeCrew)
    {
        crewPanel.OnCrewClick(activeCrew);
    }

    public void ActivateSteer()
    {
        IsFishing = false;
    }

    public void ActivateFishing()
    {
        IsFishing = true;

    }
}
