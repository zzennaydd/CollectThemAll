using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : AnimalHolder
{
    public float visionRange = 5.0f; 
    public float speed = 2.0f;
    public float followDuration = 3.0f;
    public float wanderRadius = 3.0f; 
    public float closeEnoughDistance = 0.1f;

    private Transform player;
    private Rigidbody2D rb;
    private bool isFollowing = false;
    private bool isWaiting = false;
    private Vector2 wanderTarget;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Wander());
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= visionRange && !isWaiting)
        {
            StopCoroutine(Wander());
            StartCoroutine(FollowPlayer());
        }
    }

    IEnumerator FollowPlayer()
    {
        isFollowing = true;

        while (Vector2.Distance(transform.position, player.position) <= visionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
            yield return null;
        }

        rb.velocity = Vector2.zero; 
        isFollowing = false;
        isWaiting = true;

        yield return new WaitForSeconds(followDuration); 

        isWaiting = false;
        StartCoroutine(Wander()); 
    }

    IEnumerator Wander()
    {
        while (true)
        {
            if (!isFollowing)
            {
                
                Vector2 randomDirection = Random.insideUnitCircle * wanderRadius;
                wanderTarget = (Vector2)transform.position + randomDirection;

                while (Vector2.Distance(transform.position, wanderTarget) > closeEnoughDistance)
                {
                    Vector2 direction = (wanderTarget - (Vector2)transform.position).normalized;
                    rb.velocity = direction * speed * 0.5f; 
                    yield return null;
                }
            }

            yield return null;
        }
    }
}