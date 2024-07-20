using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class foodCollect : AnimalHolder
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "player")
        {
            ScoreManager.chickCount += 1;
            Destroy(gameObject);
        }
    }
}
