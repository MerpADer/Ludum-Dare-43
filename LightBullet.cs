using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBullet : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject Gun;
    public int Speed;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (FindObjectOfType<PlayerMovement>().Isleft)
        {
            Speed = -Speed;
        }
        
	}
	
	void Update () {
        rb.velocity = new Vector2(Speed, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
