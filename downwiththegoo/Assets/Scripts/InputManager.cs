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

        //Update through call method from event trigger
        Manager.ColorState color = GameObject.Find("Player").GetComponent<Slime>().currentColor;

		//Handle jumpss
		if (Input.GetKey(KeyCode.Space)&& jump == 0)
		{
			Debug.Log("SPACE");
			jump = 1;
			player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * Time.deltaTime );
		}
        if (color == Manager.ColorState.Blue || color == Manager.ColorState.Red)
        {
            if (Input.GetKey(KeyCode.A))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.left * moveForce * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.right * moveForce * Time.deltaTime);
            }
        }
        if (color == Manager.ColorState.Yellow || color == Manager.ColorState.Green)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * moveForce * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.down * moveForce * Time.deltaTime);
            }
        }

    }

    public void ResetJump()
	{
		jump = 0;
		Debug.Log("reset");
	}
}
