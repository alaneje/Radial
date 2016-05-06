using UnityEngine;
using System.Collections;

public class crossHairScrupt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 mouseScreen = Input.mousePosition;

		//finds where the mouse is at
		Vector3 mouse = Camera.main.ScreenToWorldPoint (mouseScreen);

		//roatates the gameobject towards the mouses position

		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
	
	}
}
