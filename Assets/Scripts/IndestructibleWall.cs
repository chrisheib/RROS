using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndestructibleWall : WallTile {

	// Use this for initialization
	void Start () {

		base.Start ();
		isMinable = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}
}
