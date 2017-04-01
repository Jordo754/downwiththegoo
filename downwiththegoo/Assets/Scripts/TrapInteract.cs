using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInteract : Interactable {
    //constructor takes a color to pass up to Interactable
    public TrapInteract (Manager.ColorState a_color) {
        base.color = a_color;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
