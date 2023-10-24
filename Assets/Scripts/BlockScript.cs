using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // using TMPro;
public class BlockScript : MonoBehaviour
{
    public GameObject textObject;
    Text textComponent;
    public int hitsToDestroy;
    public int points;
    PlayerScript playerScript;
    protected void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
        playerScript = GameObject.FindGameObjectWithTag("Player")
                        .GetComponent<PlayerScript>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        string temp = collision.collider.gameObject.tag;
        
        if (temp != "Ball")
            return;
        
        hitsToDestroy--;
        if (hitsToDestroy == 0)
        {
            Destroy(gameObject);
            playerScript.BlockDestroyed(points);
        }
        else if (textComponent != null)
            textComponent.text = hitsToDestroy.ToString();
    }
}
