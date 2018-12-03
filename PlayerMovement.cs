using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool IsGrounded = true;
    private SacrificePower pow;

    public AudioSource LightShootAudio;
    public AudioSource HeavyShootAudio;
    public int ADspeed;
    public int JumpSpeed;
    public GameObject LightBullet;
    public GameObject HeavyBullet;
    public bool Isleft;
    public GameObject Death;
    public GameObject Guide;
    public GameObject Gun;

    public int Health;
    public int numOfHearts;
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

	void Start () {
        pow = FindObjectOfType<SacrificePower>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Death.SetActive(false);
        spriteRenderer.flipX = true;
	}
	
	void Update () {
        anim.SetFloat("Velocity", rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A) && !Isleft && pow.Powers[1] == true) { transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); }
        if (Input.GetKey(KeyCode.A) && pow.Powers[1] == true)
        {
            rb.transform.Translate(Vector3.left * ADspeed * Time.deltaTime);
            Isleft = true;
            anim.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.A)) { anim.SetBool("IsWalking", false);}
        if (Input.GetKeyDown(KeyCode.D) && Isleft && pow.Powers[1] == true) { transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); }
        if (Input.GetKey(KeyCode.D) && pow.Powers[1] == true)
        {
            rb.transform.Translate(Vector3.right * ADspeed * Time.deltaTime);
            Isleft = false;
            anim.SetBool("IsWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.D)) { anim.SetBool("IsWalking", false); }
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded && pow.Powers[0] == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpSpeed);
            IsGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && pow.Powers[3] == true) { Instantiate(LightBullet, Gun.transform.position, transform.rotation); LightShootAudio.Play(); }
        if (Input.GetKeyDown(KeyCode.Q) && pow.Powers[4] == true) { Instantiate(HeavyBullet, Gun.transform.position, transform.rotation); HeavyShootAudio.Play(); }
        if (Input.GetKey(KeyCode.Tab)) { Guide.SetActive(true); }
        if (Input.GetKeyUp(KeyCode.Tab)) { Guide.SetActive(false); }
        if (Input.GetKeyDown(KeyCode.LeftShift) && pow.Powers[2] == true) { ADspeed += 5; }
        if (Input.GetKeyUp(KeyCode.LeftShift) && pow.Powers[2] == true) { ADspeed -= 5; }

        if (Health == 0)
        {
            Death.SetActive(true);
        }

        if (Health > numOfHearts)
        {
            Health = numOfHearts;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else {
                Hearts[i].sprite = EmptyHeart;
            }
            if(i < numOfHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Health -= 1;
            rb.velocity = new Vector2(0, 0);
        }
    }

}
