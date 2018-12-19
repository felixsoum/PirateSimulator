using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float maxSpeed = 10.0f;

    new Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2D.AddForce(transform.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Vector2 velocity = rigidbody2D.velocity;
        if (velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = velocity.normalized * maxSpeed;
        }
    }
}
