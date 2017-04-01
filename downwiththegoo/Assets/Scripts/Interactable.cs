using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    protected Manager.ColorState color;
    public Slime player;
    protected bool colliding;
	// Use this for initialization
	void Start () {
        colliding = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other) {
        colliding = true;
    }
}
