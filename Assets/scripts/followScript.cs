using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : AnimalHolder
{
    public float visionRange = 5f;
    public float speed = 0.5f;
    public float followDuration = 3.0f; 
    public float wanderRadius = 5.0f;
    public float closeEnoughDistance = 0.1f;
    public float ignorePlayerDuration = 3.0f; 
    public float escapeDistance = 2.0f; 

    private Transform player;
    private Rigidbody2D rb;
    private bool isFollowing = false;
    private bool isWaiting = false;
    private Vector2 wanderTarget;

    protected override void Start()
    {
        base.Start();
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
            StartCoroutine(HandlePlayerEncounter());
        }
    }

    IEnumerator HandlePlayerEncounter()
    {
        
        Vector2 escapeDirection = (transform.position - player.position).normalized;
        Vector2 escapeTarget = (Vector2)transform.position + escapeDirection * escapeDistance;

        float escapeStartTime = Time.time;

        while (Vector2.Distance(transform.position, escapeTarget) > closeEnoughDistance)
        {
            Vector2 direction = (escapeTarget - (Vector2)transform.position).normalized;
            rb.velocity = direction * speed;
            yield return null;
        }

        rb.velocity = Vector2.zero;

        isWaiting = true;

       
        yield return new WaitForSeconds(ignorePlayerDuration);

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