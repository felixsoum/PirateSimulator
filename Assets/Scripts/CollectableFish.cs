﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFish : CollectableActor
{
    public override void OnCollectEnd()
    {
        Player.AddFish();
    }

    public override void OnCollectStart()
    {
    }

}
