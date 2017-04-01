using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeInteract : Interactable {
    //constructor
    public ColorChangeInteract (Manager.ColorState a_color) {
        base.color = a_color;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (colliding) {
            ChangeColor();
        }
	}

    void ChangeColor () {
        Debug.Log("Changing Color");
        player.CurrentColor = this.color;

        if (this.color == Manager.ColorState.Blue) {
            player.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }

        else if (this.color == Manager.ColorState.Red) {
            player.GetComponent<Renderer>().material.color = Color.red;
        }

        else if (this.color == Manager.ColorState.Green) {
            player.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

        else {
            player.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }

    }
}
