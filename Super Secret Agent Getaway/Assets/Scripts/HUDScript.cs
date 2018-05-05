using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public static HUDScript HUDInstance = null;
    public Text scoreText;
    public Text summaryText;
    public Text continueText;
    public Text gameOverText;
    public GameObject roundSummary;

    private void Awake()
    {
        if (HUDInstance == null)
        {
            HUDInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncrementScore(int round, float time)
    {
        scoreText.text = string.Format("Round {0} Score: {1}", round, (int)time);
    }

    public void RoundSummary ()
    {
        summaryText.text = scoreText.text;
        scoreText.text = "";
        gameOverText.text = "";
        continueText.text = "Press Space to continue.";
        roundSummary.SetActive(true);
    }

    public void GameSummary(float[] scores)
    {
        scoreText.text = "";
        gameOverText.text = "Game Over";
        summaryText.text = string.Format("Round 1 Score: {0}{1}Round 2 Score: {2}{3}Round 3 Score: {4}", 
            (int)scores[0], System.Environment.NewLine, (int)scores[1], System.Environment.NewLine, (int)scores[2]);
        continueText.text = "Press Space to continue.";
        roundSummary.SetActive(true);
    }
}
