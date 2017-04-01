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
        player.CurrentColor = this.color;

        if (this.color == Manager.ColorState.Blue) {
            player.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        }

        else if (this.color == Manager.ColorState.Red) {
            player.gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 1);
        }

        else if (this.color == Manager.ColorState.Green) {
            player.gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 1);
        }

        else {
            player.gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 1);
        }

    }
}
