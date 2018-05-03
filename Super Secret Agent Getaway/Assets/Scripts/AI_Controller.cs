using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour {

    public NavMeshAgent agent;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.state.Equals("PLAY"))
        {
            agent.SetDestination(player.transform.position);
        }
	}
}
