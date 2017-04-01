using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	//Attributes
	GameObject player;
	int jump = 0;
	public float moveForce=30000;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("CenterVert");
	}
	
	// Update is called once per frame
	void Update () {
		//Handle jumpss
		if (Input.GetKey(KeyCode.Space)&& jump == 0)
		{
			Debug.Log("SPACE");
			jump = 1;
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveForce*Time.deltaTime );
		}
	}

	void resetJump()
	{
		jump = 0;
	}
}
