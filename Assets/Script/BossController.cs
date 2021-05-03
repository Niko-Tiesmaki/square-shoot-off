using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossController : MonoBehaviour
{

    public Transform player;

    public float speed = 200f;

    public float nextWaypontDistance = 3f;

    public SpriteRenderer Boss;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOffPath = false;

    Seeker seeker;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        seeker = GetComponent<Seeker>();

        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        

    }
    void Update()
    {
        Boss.flipX = rb.velocity.x < 0; 
    }

    void UpdatePath()
    {
        if (!player) return;
        if(seeker.IsDone())
        seeker.StartPath(rb.position, player.position, OnPathComplete);
    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;
     

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOffPath = true;
            return;

        }
        else
        {
            reachedEndOffPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypontDistance)
        {
            currentWaypoint++;
        }
    }
}
