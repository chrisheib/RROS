using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public float cameraVerticalMovespeed;
	public float cameraHorizontalMovespeed;
	public GameObject afterMined;
	GameControl gameControl;

	Vector3 targetPosition;
	GameObject targetObject;

	void Start(){
		gameControl = FindObjectOfType<GameControl> ();
	}

	// Update is called once per frame
	void Update () {
		CameraMovement();
		DetectClick ();
	}
		
	void CameraMovement(){
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		horizontalMovement = horizontalMovement * Time.deltaTime * cameraHorizontalMovespeed;
		verticalMovement = verticalMovement * Time.deltaTime * cameraVerticalMovespeed;

		GameObject camera = GameObject.FindWithTag ("MainCamera");

		float oldYPosition = camera.transform.position.y;
		camera.transform.Translate (horizontalMovement, verticalMovement, 0);
		Vector3 pos = camera.transform.position;
		pos.y = oldYPosition;
		camera.transform.position = pos;
	}

	void DetectClick(){
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Camera camera = Camera.main;
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				GameObject objectHit = hit.transform.gameObject;
				Debug.Log ("hit" + hit.transform.position.ToString());

				WallTile wall = objectHit.GetComponent<WallTile>();
				if (wall){
					Debug.Log ("is wall tile");
					if (wall.isMinable) {
						gameControl.addMiningOrder(new MiningOrder(wall));	 
					}
				}
			}
		}
	}
}
