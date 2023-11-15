using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBase : MonoBehaviour
{
    public string text = "+100";
    public Color backgroundColor = Color.yellow;
    public Color textColor = Color.black;
    public Text textComponent;
    public PlayerScript player;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                BonusActivate();
                Destroy(gameObject);
                break;
            }
            case "Wall": {
                Debug.Log("Bottom wall");
                Destroy(gameObject);
                break;
            }
        } 
    }

    public virtual void BonusActivate() {
        player.gameData.points += 100;
    }
}
