using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public Transform player;

    public Transform Firepoint;
    
    public SpriteRenderer GunS;

    public GameObject bulletPrefab;

    public GameObject FireEffectPrefab;

    void Start()
    {
        
    }
    void LateUpdate()
    {

        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);

        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GunS.flipY = transform.eulerAngles.z >= 90 || transform.eulerAngles.z <= -90;
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        Instantiate(FireEffectPrefab, Firepoint.position, Firepoint.rotation);
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
        
    }
}