using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BonusBase : MonoBehaviour
{
    public int bonusId;
    public string text = "+100";
    public Color backgroundColor = Color.yellow;
    public Color textColor = Color.black;
    public Text textComponent;
    public PlayerScript player;
    private SpriteRenderer spriteRenderer;
    public BallScript[] ballScripts;

    protected void Start() {
        textComponent = GetComponentInChildren<Text>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballScripts = FindObjectsOfType<BallScript>();
        UpdateSpriteAndText();
    }

    public void UpdateSpriteAndText() {
        Debug.Log("Update sprite and text");
        if (spriteRenderer is not null) {
            spriteRenderer.color = backgroundColor;
        }

        if (textComponent is not null) {
            textComponent.text = text;
            textComponent.color = textColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        string tag = other.tag;

        switch (tag) {
            case "Player": {
                BonusActivate(bonusId);
                Destroy(gameObject);
                break;
            }
            case "LoseCollider": {
                Debug.Log("Bottom wall");
                Destroy(gameObject);
                break;
            }
        } 
    }

    public virtual void BonusActivate(int bonus) {

        if(bonus == 0)
        {
            player.gameData.points += 100;
        }
        else
        {
            foreach (var bs in ballScripts)
            {
                bs.BonusUpdate(bonus);
            }
        }
    }
}
