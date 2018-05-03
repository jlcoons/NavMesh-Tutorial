using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public static HUDScript HUDInstance = null;
    public Text scoreText;

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
}
