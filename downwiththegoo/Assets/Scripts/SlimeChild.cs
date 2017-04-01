using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeChild : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] temp = GameObject.FindGameObjectsWithTag("EdgeVert");
		for (int i=0; i < temp.Length; i++)
		{
			Physics2D.IgnoreCollision(temp[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
