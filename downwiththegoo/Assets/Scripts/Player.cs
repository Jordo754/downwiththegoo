using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Floor")
            Debug.Log("Floor hit");
            GameObject.Find("InputManager").GetComponent<InputManager>().ResetJump();
    }
}
