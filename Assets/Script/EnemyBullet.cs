using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 15f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)

    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(30);
        }

        Destroy(gameObject);
    }
  

}
