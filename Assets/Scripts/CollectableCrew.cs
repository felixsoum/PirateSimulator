using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCrew : CollectableActor
{
    [SerializeField]GameObject bodySprite;

    public override void OnCollectEnd()
    {
        Player.AddCrew();
    }

    public override void OnCollectStart()
    {
        bodySprite.SetActive(true);
    }
}
