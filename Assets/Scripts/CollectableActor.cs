using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableActor : MonoBehaviour
{
    private Vector3 targetPos;
    private bool isCollected;
    float collectedTime;
    public PlayerShip Player { get; set; }
    public abstract void OnCollectStart();
    public abstract void OnCollectEnd();
    public GameDirector Game { get; set; }

    private void Update()
    {
        if (isCollected)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, 10.0f * Time.deltaTime);
            collectedTime += Time.deltaTime;
            if (collectedTime >= 1)
            {
                OnCollectEnd();
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isCollected && Vector3.Distance(Player.transform.position, transform.position) <= 5f
            && Game.IsFishing)
        {
            OnCollectStart();
            targetPos = Player.transform.position;
            targetPos.z = 0;
            isCollected = true;
        }
    }
}
