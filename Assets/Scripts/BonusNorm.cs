using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusNorm : BonusBase
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
            bs.damage = 1;
            bs.spriteRenderer.color = Color.white;
        }
    }
}
