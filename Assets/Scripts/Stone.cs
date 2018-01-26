using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : WallTile {

	// Use this for initialization
	void Start () {
		base.Start ();
		isMinable = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		base.Update() ;
	}
}
