using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance = null;
    public HUDScript hudScript;
    private static int round = 0;
    private static float[] scores = new float[3];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        scores[round] += Time.deltaTime;
        hudScript.IncrementScore(round+1, scores[round]);
	}

    public void EndRound()
    {
        round++;
        SceneManager.LoadScene("Main");
    }
}
