using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate (Vector3.up * speed * Time.deltaTime, space.self);
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		//gets rid of the bullet if it hits something
		if((other.gameObject.tag == "Floor")||(other.gameObject.tag == "Wall")||(other.gameObject.tag == "Brawler"))
		{

			Destroy (gameObject);
		}
	}
	
}
