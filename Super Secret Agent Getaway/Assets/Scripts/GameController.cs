using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static string state = "PLAY";
    public static GameController instance = null;
    public HUDScript hudScript;
    public GameObject[] northSpawns;
    public GameObject[] southSpawns;
    public GameObject[] eastSpawns;
    public GameObject[] westSpawns;
    private GameObject[][] allSpawns = new GameObject[][];
    private int[] occupied = new int[6];
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
        allSpawns = [northSpawns, eastSpawns, southSpawns, westSpawns];
    }
	
	// Update is called once per frame
	void Update () {
        if (state.Equals("PLAY"))
        {
            scores[round] += Time.deltaTime;
            hudScript.IncrementScore(round + 1, scores[round]);
        }
	}

    public void EndRound()
    {
        if (round < 3)
        {
            state = "BETWEEN_ROUNDS";
            hudScript.RoundSummary(round + 1, scores[round]);
            round++;
        }
        else
        {
            state = "GAME_OVER";
        }
    }

    public void StartRound()
    {
        hudScript.roundSummary.SetActive(false);
        int enemyWall = Random.Range(0, 4);
        int playerWall = (enemyWall + 2) % 4;
        occupied = [0, 0, 0, 0, 0, 0];
        for (int i = 0; i < 4; i++)
        {
            // Spawn enemy at random point on enemy wall

        }

        state = "PLAY";
    }
}