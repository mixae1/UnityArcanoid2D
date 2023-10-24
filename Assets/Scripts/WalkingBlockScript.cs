using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using TMPro;

public class WalkingBlockScript : BlockScript
{
    //const float maxWalkingSpeed = 2.;
    //[Range(0.01, maxWalkingSpeed)]
    public float walkingSpeed = 0.05f;

    new void OnCollisionEnter2D(Collision2D collision)
    {
        string temp = collision.collider.gameObject.tag;
        if (temp == "Block" || temp == "Wall")
        {
            walkingSpeed *= -1;
        }
        else
        {
            base.OnCollisionEnter2D(collision);           
        }
    }

    void FixedUpdate()
    {
        var pos = transform.position;
        pos.x = pos.x + walkingSpeed;
        transform.position = pos;
    }
}
