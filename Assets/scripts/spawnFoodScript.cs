using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFoodScript : MonoBehaviour
{

    public GameObject food;
    public float spawnCountdown = 10f;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnCountdown;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        
       if(timer <= 0f)
            {
            Vector2 randomPosition = new Vector2(Random.Range(-10, 10), Random.Range(-5, 5));
            Instantiate(food, randomPosition, Quaternion.identity);
            timer = spawnCountdown;
            }
    }
}
