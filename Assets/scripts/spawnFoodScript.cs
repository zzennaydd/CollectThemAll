using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFoodScript : MonoBehaviour
{

    public GameObject food;
    public float spawnCountdown = 1f;
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
            Vector2 randomPosition = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-4, 2.2f));
            Instantiate(food, randomPosition, Quaternion.identity);
            timer = spawnCountdown;
            }
    }
}
