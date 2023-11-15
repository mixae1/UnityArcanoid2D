using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsBonus : BonusBase
{
    public override void BonusActivate()
    {
        player.gameData.points += 200;
    }
}
