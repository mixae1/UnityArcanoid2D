using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusNorm : BonusBase
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
            bs.damage = 1;
            bs.spriteRenderer.color = Color.white;
        }
    }
}
