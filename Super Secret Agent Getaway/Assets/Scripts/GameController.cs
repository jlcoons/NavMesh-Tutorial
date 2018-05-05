using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static string state = "PLAY";
    public static GameController instance = null;
    public HUDScript hudScript;
    public GameObject player;
    public GameObject[] chasers = new GameObject[4];
    public GameObject[] northSpawns = new GameObject[6];
    public GameObject[] southSpawns = new GameObject[6];
    public GameObject[] eastSpawns = new GameObject[6];
    public GameObject[] westSpawns = new GameObject[6];
    private GameObject[][] allSpawns = new GameObject[4][];
    private GameObject spawnPoint = null;
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
        allSpawns[0] = northSpawns;
        allSpawns[1] = eastSpawns;
        allSpawns[2] = southSpawns;
        allSpawns[3] = westSpawns;
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
        if (round < 2)
        {
            state = "BETWEEN_ROUNDS";
            hudScript.RoundSummary();
            round++;
        }
        else
        {
            state = "GAME_OVER";
            hudScript.GameSummary(scores);
        }
    }

    public void StartRound()
    {
        if (state.Equals("GAME_OVER"))
        {
            round = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = 0;
            }
        }

        hudScript.roundSummary.SetActive(false);

        int enemyWall = Random.Range(0, 4);
        int playerWall = (enemyWall + 2) % 4;
        int randomPoint = 0;
        // Set all points to unoccupied
        for (int i = 0; i < occupied.Length; i++)
        {
            occupied[i] = 0;
        }

        for (int i = 0; i < chasers.Length; i++)
        {
            // Pick point on enemy wall to spawn at
            randomPoint = Random.Range(0, 6);
            // Make sure that the spawn point is not already occupied
            while (occupied[randomPoint] == 1)
            {
                randomPoint = Random.Range(0, 6);
            }
            // "Spawn" enemy
            spawnPoint = allSpawns[enemyWall][randomPoint];
            chasers[i].transform.position = spawnPoint.transform.position;
            chasers[i].transform.rotation = spawnPoint.transform.rotation;
            occupied[randomPoint] = 1;
        }

        // "Spawn" player
        randomPoint = Random.Range(0, 6);
        spawnPoint = allSpawns[playerWall][randomPoint];
        player.transform.position = spawnPoint.transform.position;
        player.transform.rotation = spawnPoint.transform.rotation;

        state = "PLAY";
    }
}