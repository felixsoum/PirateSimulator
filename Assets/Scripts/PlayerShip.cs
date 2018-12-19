using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float rotationSpeed = 10.0f;
    [SerializeField] float crewSpeedBonus = 1.0f;
    [SerializeField] GameObject usableFishPrefab;
    [SerializeField] Transform fishStock;
    [SerializeField] List<ActiveCrew> activeCrews = new List<ActiveCrew>();
    [SerializeField] GameDirector gameDirector;
    new Rigidbody2D rigidbody2D;
    Vector3 steerDirection = Vector3.up;
    List<ActiveFish> activeFishes = new List<ActiveFish>();
    ActiveFish currentlyDraggedFish;

    int workingCrew;

    void Awake()
    {
        activeCrews[0].CrewName = "교";
        activeCrews[1].CrewName = "보미짱";
        activeCrews[2].CrewName = "울칠";
        activeCrews[3].CrewName = "훈";
        activeCrews[4].CrewName = "설티";
        activeCrews[5].CrewName = "예리한";
        rigidbody2D = GetComponent<Rigidbody2D>();
        foreach (var activeCrew in activeCrews)
        {
            activeCrew.gameObject.SetActive(false);
        }
    }

    internal void OnRotateClick()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        steerDirection = worldPos - transform.position;
        steerDirection.z = 0;
        steerDirection.Normalize();
    }

    void Update()
    {
        if (currentlyDraggedFish != null && Input.GetMouseButtonUp(0))
        {
            foreach (var activeCrew in activeCrews)
            {
                if (!activeCrew.gameObject.activeInHierarchy)
                {
                    continue;
                }

                var fishPos = currentlyDraggedFish.transform.position;
                fishPos.z = 0;
                var crewPos = activeCrew.transform.position;
                crewPos.z = 0;

                float distance = Vector3.Distance(fishPos, crewPos);
                if (distance <= 0.1f)
                {
                    Destroy(currentlyDraggedFish.gameObject);
                    activeCrew.Feed();
                    break;
                }
            }
        }
    }

    void FixedUpdate()
    {
        float realSpeed = speed + crewSpeedBonus * workingCrew;
        rigidbody2D.AddForce(transform.up * realSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Vector2 velocity = rigidbody2D.velocity;

        float realMaxSpeed = maxSpeed + crewSpeedBonus * workingCrew;

        if (velocity.magnitude > realMaxSpeed)
        {
            rigidbody2D.velocity = velocity.normalized * realMaxSpeed;
        }
        transform.up = Vector3.RotateTowards(transform.up, steerDirection, rotationSpeed * Time.fixedDeltaTime, 0);
    }

    public void AddFish()
    {
        var fish = Instantiate(usableFishPrefab, fishStock);
        float fishRandomPos = 0.25f;
        fish.transform.localPosition = new Vector3(UnityEngine.Random.Range(-fishRandomPos, fishRandomPos), 
            UnityEngine.Random.Range(-fishRandomPos, fishRandomPos), 0);

        ActiveFish fishComponent = fish.GetComponent<ActiveFish>();
        fishComponent.OnReset = OnFishReset;
        activeFishes.Add(fishComponent);
    }

    private void OnFishReset(ActiveFish activeFish)
    {
        activeFishes.Add(activeFish);
        currentlyDraggedFish = null;
    }

    public void AddCrew()
    {
        workingCrew = Mathf.Min(workingCrew + 1, activeCrews.Count);
        foreach (var activeCrew in activeCrews)
        {
            if (!activeCrew.gameObject.activeInHierarchy)
            {
                activeCrew.Activate();
                break;
            }
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float distanceToFish = Vector3.Distance(fishStock.transform.position, mousePos);
        if (activeFishes.Count > 0 &&
            distanceToFish <= 0.5f)
        {
            activeFishes[0].StartDrag();
            currentlyDraggedFish = activeFishes[0];
            activeFishes.RemoveAt(0);
        }

        foreach (var activeCrew in activeCrews)
        {
            float distance = Vector3.Distance(activeCrew.transform.position, mousePos);
            if (activeCrew.gameObject.activeInHierarchy && distance <= 0.1f)
            {
                gameDirector.OnCrewClick(activeCrew);
            }
        }
    }
}
