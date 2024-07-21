using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI chickText;
    public TextMeshProUGUI parrotText;
    public TextMeshProUGUI rabbitText;
    public TextMeshProUGUI duckText;
    public TextMeshProUGUI penguinText;
    public int chickCount;
    public int parrotCount;
    public int penguinCount;
    public int rabbitCount;
    public int duckCount;
    private void Awake()
    {
        setText();
    }

    public void CollectFood()
    {
        
        setText();
    }

    public void DecreaseScore()
    {
        if(chickCount > 0)
        {
            chickCount--;
            setText();
        }
    }
    private void setText()
    {
        chickText.text = "x" + chickCount.ToString();
        parrotText.text = "x" + parrotCount.ToString();
        penguinText.text = "x" + penguinCount.ToString();
        rabbitText.text = "x" + rabbitCount.ToString();
        duckText.text = "x" + duckCount.ToString();
    }

   public void AdjustOtherScores(string animal)
    {
        if (animal != "chick" && chickCount > 0)
        {
            chickCount--;
        }
        if (animal != "parrot" && parrotCount > 0)
        {
            parrotCount--;
        }
        if (animal != "rabbit" && rabbitCount > 0)
        {
            rabbitCount--;
        }
        if (animal != "duck" && duckCount > 0)
        {
            duckCount--;
        }
        if (animal != "penguin" && penguinCount > 0)
        {
            penguinCount--;
        }
        setText();
    }
 
}
