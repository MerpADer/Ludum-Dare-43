using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int Speed;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int health = 3;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(Speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-Speed, 0f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "LightBullet")
        {
            health -= 1;
        }
        if (collision.transform.tag == "HeavyBullet")
        {
            health -= 3;
        }
    }

}
