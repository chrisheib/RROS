using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Worker : MonoBehaviour {

	public UnityEngine.AI.NavMeshAgent navAgent{ get; set; }
	public enum State {free, mining};

	public State state = State.free;
	//GameObject targetObject;
	GameControl gameControl;
	WallTile wallToMine;

	// Use this for initialization
	void Start () {
		navAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		gameControl = FindObjectOfType<GameControl> ();
		reset ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CheckArrived ();
	}

	void CheckArrived(){
		if (state == State.mining) {
			if (navAgent.remainingDistance == 0f) {
				state = State.free;
				mine (wallToMine);
				reset ();
			}
		}
	}

	void reset(){
		reportFree ();
		state = State.free;
		//targetObject = null;
		wallToMine = null;
	}

	void reportFree(){
		gameControl.incFreeWorkerCount ();
	}

	void mine(WallTile tile){

		//Instantiate(afterMined, tile.transform.parent.position,Quaternion.identity);
		Destroy(tile.transform.gameObject);

	}

	public void mineTile(WallTile target, UnityEngine.AI.NavMeshPath path){
		if (state != State.free) { 
			throw new Exception("mineTile: Worker is not free to mine! Make sure to check if you should place a mining order!");
		}

		state = State.mining;
		navAgent.path = path;
		Debug.Log ("path is set! my name: " + this.name);
		wallToMine = target;
		gameControl.decFreeWorkerCount ();
	}
}
