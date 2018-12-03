using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Rigidbody2D rb;
    public Enemy02 Enemy;
    public int Speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemy = GetComponentInParent<Enemy02>();
        gameObject.transform.position = Enemy.transform.position;
        if (Enemy.Isleft)   {Speed = -Speed;}

    }

    void Update()
    {
        rb.velocity = new Vector2(Speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
