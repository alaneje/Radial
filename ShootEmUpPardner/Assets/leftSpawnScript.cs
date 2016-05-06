using UnityEngine;
using System.Collections;

public class leftSpawnScript : MonoBehaviour {

	public float timer;

	public GameObject brawler;
	// Use this for initialization
	void Start () {
	
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//spawn a brawler ever 4 seconds
		timer += Time.deltaTime;

		if (timer > 4) {
			Instantiate (brawler, transform.position, Quaternion.identity);
			timer = 0;
		}
	
	}
}
