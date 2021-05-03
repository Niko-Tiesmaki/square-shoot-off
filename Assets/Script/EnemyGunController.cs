using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public Transform Enemy;

    public Transform Player;

    public Transform Firepoint;

    public SpriteRenderer GunS;

    public Rigidbody2D EnemyBulletPrefab;

    public float shootingRate = 0.25f;

    private float shootCooldown;


    void Start()
    {
        Player = FindObjectOfType<PlayerController>().transform;
        shootCooldown = 0f;
    }
    void LateUpdate()
    {

        Vector3 moveDirection = Enemy.transform.position - Player.transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        GunS.flipY = transform.eulerAngles.z >= 90 || transform.eulerAngles.z <= -90;

    }

    void Update()
    {
        if (!Player) return;
        if(Time.time > shootCooldown)
        {
            shootCooldown = Time.time + shootingRate;
            Instantiate(EnemyBulletPrefab, Firepoint.position, Firepoint.rotation);
        }
        
    }

    
}