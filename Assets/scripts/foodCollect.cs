using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class foodCollect : AnimalHolder
{
    public ScoreManager scoreManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            scoreManager.chickCount += 1;
            Destroy(this.gameObject);
        }
    }
}
