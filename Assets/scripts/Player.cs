using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : AnimalHolder
{
    public float speed;
    public float health = 5;
    public Rigidbody2D rigidbody2D;
    public ScoreManager scoreManager;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector2(horizontalMove, verticalMove);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        // transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        //rigidbody2D.AddForce(moveDirection * speed);
        rigidbody2D.velocity = moveDirection * speed;
       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            health -= 1;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
          
            
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("chick"))
        {
            scoreManager.chickCount++;
            scoreManager.AdjustOtherScores("chick");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("parrot"))
        {
            scoreManager.parrotCount++;
            scoreManager.AdjustOtherScores("parrot");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("rabbit"))
        {
            scoreManager.rabbitCount++;
            scoreManager.AdjustOtherScores("rabbit");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("duck"))
        {
            scoreManager.duckCount++;
            scoreManager.AdjustOtherScores("duck");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("penguin"))
        {
            scoreManager.penguinCount++;
            scoreManager.AdjustOtherScores("penguin");
            Destroy(other.gameObject);
        }


    }
}
