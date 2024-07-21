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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            health -= 1;
            if(health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        if(other.gameObject.tag == "chick")
        {
            Destroy(other.gameObject);
            scoreManager.CollectFood();
            
        }
        if(other.gameObject.tag == "parrot")
        {
            Destroy(other.gameObject);
            scoreManager.DecreaseScore();
        }
       

    }
}
