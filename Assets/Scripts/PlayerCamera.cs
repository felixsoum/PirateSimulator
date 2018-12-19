using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    private float z;

    private void Awake()
    {
        z = transform.position.z;
    }

    private void Update()
    {
        Vector3 pos = target.transform.position;
        pos.z = z;
        transform.position = pos;
    }
}
