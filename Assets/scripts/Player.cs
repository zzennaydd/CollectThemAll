using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : AnimalHolder
{
    public float speed = 0.5f;
    public float health = 5;
    public Rigidbody2D rigidbody2D;
    public ScoreManager scoreManager;
    public AnimalData enemydata;
    public AnimalData chickdata;
    public AnimalData parrotdata;
    public AnimalData duckdata;
    public AnimalData rabbitdata;
    public AnimalData penguindata;
    public GameObject chickicon;
    public GameObject parroticon;
    public GameObject duckicon;
    public GameObject rabbiticon;
    public GameObject penguinicon;
    public int x;

    public bool isGameEnd = false;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * 0.5f; // Hareket miktarını azalt
        float verticalMove = Input.GetAxis("Vertical") * 0.5f;     // Hareket miktarını azalt

        Vector3 moveDirection = new Vector2(horizontalMove, verticalMove);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);

        Vector3 newPosition = transform.position + moveDirection * 10 * Time.deltaTime;

        transform.position = newPosition;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!isGameEnd)
            {
                health -= 1;
                if (health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                }
            }
            else
            {
                Destroy(collision.gameObject);
                ChangeAnimal(enemydata);
            }
          
            
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("chick"))
        {
            scoreManager.chickCount++;
            scoreManager.AdjustOtherScores("chick");
            if (scoreManager.chickCount >= 10 )
            {
                scoreManager.chickCount = -10;
                scoreManager.chickSpawner.SetActive(false);
                ChangeAnimal(chickdata);
                chickicon.SetActive(false);
                x++;
                if (x == 5)
                {
                    isGameEnd = true;
                }
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("parrot"))
        {
            scoreManager.parrotCount++;
            scoreManager.AdjustOtherScores("parrot");
            if (scoreManager.parrotCount >= 10)
            {
                scoreManager.parrotCount = -10;
                scoreManager.parrotSpawner.SetActive(false);
                ChangeAnimal(parrotdata);
                parroticon.SetActive(false);
                x++;
                if (x == 5)
                {
                    isGameEnd = true;
                }
            }
            
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("rabbit"))
        {
            scoreManager.rabbitCount++;
            scoreManager.AdjustOtherScores("rabbit");
            if (scoreManager.rabbitCount >= 10)
            {
                scoreManager.rabbitCount = -10;
                scoreManager.rabbitSpawner.SetActive(false);
                ChangeAnimal(rabbitdata);
                rabbiticon.SetActive(false);
                x++;
                if (x == 5)
                {
                    isGameEnd = true;
                }
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("duck"))
        {
            scoreManager.duckCount++;
            scoreManager.AdjustOtherScores("duck");
            if (scoreManager.duckCount >= 10)
            {
                scoreManager.duckCount = -10;
                scoreManager.duckSpawner.SetActive(false);
                ChangeAnimal(duckdata);
                duckicon.SetActive(false);
                x++;
                if (x == 5)
                {
                    isGameEnd = true;
                }
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("penguin"))
        {
            scoreManager.penguinCount++;
            scoreManager.AdjustOtherScores("penguin");
            if (scoreManager.penguinCount >= 10)
            {
                scoreManager.penguinCount = -10;
                scoreManager.penguinSpawner.SetActive(false);
                ChangeAnimal(penguindata);
                penguinicon.SetActive(false);
                x++;
                if (x == 5)
                {
                    isGameEnd = true;
                }
            }
            Destroy(other.gameObject);
        }


    }
}
