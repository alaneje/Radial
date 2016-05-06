using UnityEngine;
using System.Collections;

public class BrawlerScript : MonoBehaviour {

	GameObject player;

	public Vector2 distanceVector;

	public float distance;

	public float speed;

	public float chargeSpeed;

	public bool attacking;

	public float timer;

	public bool attacked;

	public GameObject attack;

	public float xDirection;

	public float offset;

	float facing;

	int moveDirection;

	public float health;

	Quaternion correctRot;

	// Use this for initialization
	void Start () {
	
		//finds the player
		player = GameObject.FindGameObjectWithTag ("Player");

		attacking = false;
		attacked = false;

		offset = 1;

		//makes the brawler start facing the right way
		if (transform.position.x > 11) {
			moveDirection = -1;
			correctRot = new Quaternion (0, 180,0,0);
		} else {
			moveDirection = 1;
			correctRot = new Quaternion (0, 0,0,0);
		}


	}
	
	// Update is called once per frame
	void Update () {


		//works out whether the player is behind or in front of the brawler
		xDirection = player.transform.position.x - transform.position.x;

		if (health < 0)
		{
			Destroy (gameObject);
		}

		//pauses the brawlers update while it attacks
		if(attacking == true)
		{


			timer -= Time.deltaTime;

			//ends the brawlers attack sequence
			if(timer<0)
			{
				attacking = false;

				//ensures the brawler continues in the correct direction
				transform.rotation = correctRot;
			}

			//actually attacks
			if((attacked == false)&&(timer<1))
			{
				if (xDirection > 0)
				{
					transform.rotation = new Quaternion (0,0,0,0);
				}
				else
				{
					transform.rotation = new Quaternion (0,180,0,0);
				}

				//initiates a collision box 
				Instantiate(attack,new Vector2(transform.position.x+(offset*facing),transform.position.y),Quaternion.identity); 

				attacked = true;
			}


			return;
		}



		distanceVector = player.transform.position - transform.position;

		//works out how far away the player is as a float
		distance = Mathf.Sqrt((distanceVector.x*distanceVector.x) + (distanceVector.y*distanceVector.y));

		//if the player is more than 2 units away the brawler will just keep going
		if (distance > 2) {

			transform.rotation = correctRot;

			transform.Translate(new Vector3(moveDirection,0,0) * speed * Time.deltaTime, Space.World);

			correctRot = transform.rotation;

		}

		//makes the brawler attack if the player is close enough and starts the timer. this can be changed to match up with the attack anim
		else if (distance < 1)
		{
			attacked = false;
			attacking = true;
			timer = 2;


		}

		//makes the brawler charge the player
		else if (distance<2)
		{


			if (xDirection > 0)
			{
				transform.rotation = new Quaternion (0,0,0,0);
			}
			else
			{
				transform.rotation = new Quaternion (0,180,0,0);
			}

			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chargeSpeed*Time.deltaTime);


		}

	


		//checks which direction to face based on the player
		if (xDirection < 0)
		{
			
			facing = -1;
		}
		else
		{
			facing = 1;
		}



	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//change direction if wall or other brawler
		if((col.gameObject.tag == "Wall")||(col.gameObject.tag == "Brawler"))
		{
			speed = -speed;

			transform.Rotate (new Vector3(0,180,0));

			correctRot = transform.rotation;

	
		}



	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			health --;
		}
	}


}
