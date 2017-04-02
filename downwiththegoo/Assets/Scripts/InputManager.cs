using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	//Attributes
	GameObject player;
	int jump = 0;
	public float moveForce;
	public float jumpForce = 30000;

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
			player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce*Time.deltaTime );
		}
		if (Input.GetKey(KeyCode.A))
		{
			player.GetComponent<Rigidbody>().AddForce(Vector3.left * moveForce * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			player.GetComponent<Rigidbody>().AddForce(Vector3.right * moveForce*Time.deltaTime);
		}
	}

	public void ResetJump()
	{
		jump = 0;
		//Debug.Log("reset");
	}
}
