using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewPanel : MonoBehaviour
{
    [SerializeField] Text crewName;
    [SerializeField] Image hungerBar;
    [SerializeField] Image tiredBar;
    [SerializeField] Image happyBar;
    private ActiveCrew activeCrew;

    void Awake()
    {
        crewName.text = "";
    }

    void Update()
    {
        if (activeCrew == null)
        {
            return;
        }
        hungerBar.transform.localScale = new Vector3(activeCrew.HungerValue, 1, 1);
        tiredBar.transform.localScale = new Vector3(activeCrew.TiredValue, 1, 1);
        happyBar.transform.localScale = new Vector3(activeCrew.HappyValue, 1, 1);
    }

    internal void OnCrewClick(ActiveCrew activeCrew)
    {
        gameObject.SetActive(true);
        this.activeCrew = activeCrew;
        crewName.text = "Name: " + activeCrew.CrewName;
    }
}
