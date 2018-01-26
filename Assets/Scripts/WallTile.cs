using UnityEngine;
using System.Collections;

public class WallTile : MonoBehaviour {

	public bool inMiningQueue = false;
	public Material matWhenInQueue;

	public bool isMinable;

	Renderer ownRenderer;
	bool materialSet = false;

	// Use this for initialization
	protected void Start () {
		ownRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	protected void Update () {
		if (inMiningQueue && !materialSet) {
			ownRenderer.material = matWhenInQueue;
			materialSet = true;
		}
	}
}
