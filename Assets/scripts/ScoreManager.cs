using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int chickCount;
    public int parrotCount;
    
    public void CollectFood()
    {
        chickCount++;
        scoreText.text = "Chick: " + chickCount.ToString();


        if(chickCount>= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void DecreaseScore()
    {
        if(chickCount > 0)
        {
            chickCount++;
            scoreText.text = "Chick:" + chickCount.ToString();
        }
    }
}
