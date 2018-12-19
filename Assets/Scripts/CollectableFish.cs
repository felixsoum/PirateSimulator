using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFish : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
