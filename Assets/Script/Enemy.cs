using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 150;

    // Start is called before the first frame update
   public void TakeDamage (int damage)
    {
        hp -= damage;
        
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
