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

    public GameObject chickSpawner;
    public GameObject duckSpawner;
    public GameObject rabbitSpawner;
    public GameObject parrotSpawner;
    public GameObject penguinSpawner;
    private void Awake()
    {
        setText();
    }

    
    private void setText()
    {
        if (chickText.gameObject.activeSelf)
        {
            chickText.text = "x" + chickCount.ToString();
        }
        if (parrotText.gameObject.activeSelf)
        {
            parrotText.text = "x" + parrotCount.ToString();
        }
        if (penguinText.gameObject.activeSelf)
        {
            penguinText.text = "x" + penguinCount.ToString();
        }
        if (rabbitText.gameObject.activeSelf)
        {
            rabbitText.text = "x" + rabbitCount.ToString();
        }
        if (duckText.gameObject.activeSelf)
        {
            duckText.text = "x" + duckCount.ToString();
        }
        
        
        
        
        
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

