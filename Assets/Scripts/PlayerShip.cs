﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float rotationSpeed = 10.0f;

    new Rigidbody2D rigidbody2D;
    Vector3 steerDirection = Vector3.up;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    internal void OnRotateClick()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        steerDirection = worldPos - transform.position;
        steerDirection.z = 0;
        steerDirection.Normalize();
    }

    void FixedUpdate()
    {
        rigidbody2D.AddForce(transform.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Vector2 velocity = rigidbody2D.velocity;
        if (velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = velocity.normalized * maxSpeed;
        }
        transform.up = Vector3.RotateTowards(transform.up, steerDirection, rotationSpeed * Time.fixedDeltaTime, 0);
    }
}
