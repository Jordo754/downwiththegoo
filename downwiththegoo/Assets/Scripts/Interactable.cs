using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    protected Manager.ColorState color;
    public Slime player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    bool CheckCollisions () {
        if (player.gameObject.transform.position.x > this.gameObject.transform.position.x || )

        return false;
    }
}
