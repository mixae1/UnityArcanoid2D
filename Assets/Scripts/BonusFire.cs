using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFire : BonusBase
{
    public BallScript[] ballScripts;

    protected new void Start()
    {
        base.Start();
        ballScripts = FindObjectsOfType<BallScript>();
    }
    public virtual void BonusActivate() {
        foreach (var bs in ballScripts)
        {

        }
    }
}
