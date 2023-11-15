using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 ballInitialForce;
    Rigidbody2D rb;
    GameObject playerObj;
    float deltaX;
    AudioSource audioSrc;
    public AudioClip hitSound;
    public AudioClip loseSound;
    public GameDataScript gameData;
    private PauseManager pauseManager;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deltaX = transform.position.x;
        audioSrc = Camera.main.GetComponent<AudioSource>();
        pauseManager = PauseManager.Instance();
    }

    void Update()
    {
        if (pauseManager.paused)
        {
            return;
        }
        if (rb.isKinematic)
            if (Input.GetButtonDown("Fire1"))
            {
                rb.isKinematic = false;
                rb.AddForce(ballInitialForce);
            }
            else
            {
                var pos = transform.position;
                pos.x = playerObj.transform.position.x + deltaX;
                transform.position = pos;
            }
        if (!rb.isKinematic && Input.GetKeyDown(KeyCode.J))
        {
            var v = rb.velocity;
            if (Random.Range(0, 2) == 0)
                v.Set(v.x - 0.1f, v.y + 0.1f);
            else
                v.Set(v.x + 0.1f, v.y - 0.1f);
            rb.velocity = v;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bonus") return;

        if (gameData.sound)
            audioSrc.PlayOneShot(loseSound, 5);
        Destroy(gameObject);
        playerObj.GetComponent<PlayerScript>().BallDestroyed();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bonus") return;

        if (gameData.sound)
            audioSrc.PlayOneShot(hitSound, 5);
    }

    public void BonusUpdate(int effect)
    {
        switch(effect)
        {
            case 1:
            {
                spriteRenderer.color = Color.red;
                tag = "FireBall";
                break;
            }
            case 2:
            {
                spriteRenderer.color = Color.grey;
                tag = "SteelBall";
                break;
            }
            case 3:
            {
                spriteRenderer.color = Color.white;
                tag = "Ball";
                break;
            }
        }
    }

}