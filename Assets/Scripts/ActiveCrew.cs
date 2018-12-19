using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCrew : MonoBehaviour
{
    [SerializeField] GameDirector gameDirector;
    public string CrewName { get; set; }
    public float HungerValue { get; set; }
    public float TiredValue { get; internal set; }
    public float HappyValue { get; internal set; } = 1.0f;

    private void Update()
    {
        HungerValue += 0.01f * Time.deltaTime;
        TiredValue += 0.005f * Time.deltaTime;
        HappyValue -= 0.01f * Time.deltaTime;
    }

    internal void Activate()
    {
        gameObject.SetActive(true);
    }

    internal void Feed()
    {
        HungerValue = 0;
    }
}
