using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSteel : BonusBase
{
    protected new void Start()
    {
        base.Start();
        ballScripts = FindObjectsOfType<BallScript>();
    }
    public override void BonusActivate() {
        foreach (var bs in ballScripts)
        {
            if (bs == null) {
                continue;
            }
            bs.spriteRenderer.color = Color.grey;
            bs.damage = 40;
        }
    }
}
