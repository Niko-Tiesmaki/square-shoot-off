using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthbar;

    public Animator animator;

    public int hp = 100;

    // Start is called before the first frame update
   public void TakeDamage (int damage)
    {
        hp -= damage;

        healthbar.SetHealth(hp);
        
        if (hp <= 0)
        {
            animator.Play("Deathanimation");
            StartCoroutine(OnDeath());
            
        }
    }
    private IEnumerator OnDeath()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        FindObjectOfType<GameManager>().EndGame();
    }
}
