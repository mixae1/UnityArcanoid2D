using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSteel : BonusBase
{
    public BallScript[] ballScripts;

    public int bonusId;
    protected new void Start()
    {
        base.Start();
        ballScripts = FindObjectsOfType<BallScript>();
    }
    public override void BonusActivate() {
        foreach (var bs in ballScripts)
        {
            bs.spriteRenderer.color = Color.grey;
            bs.damage = 40;
        }
    }
}
