using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    //public vars
    public Slime player;
    public Manager.ColorState color;

    //type of interactable
    public enum InteractType {
        ColorChange,
        Trap
    }
    private InteractType type;
    public InteractType Type {
        get { return type; }
        set { value = type; }
    }

    //references to ColorChange/Trap
    private ColorChangeInteract colorChanger;
    private TrapInteract trap;

	// Use this for initialization
	void Start () {
        if (tag == "ColorChange") {
            type = InteractType.ColorChange;
            colorChanger = new ColorChangeInteract(color);
        }

        if (tag == "Trap") {
            type = InteractType.Trap;
            trap = new TrapInteract(color);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (type == InteractType.ColorChange)
		{
			Color change = colorChanger.ChangeColor();
			player.CurrentColor = colorChanger.InteractColor;

			//switch these for Mesh / Primitive
			//player.GetComponent<Renderer>().material.color = change;
			player.GetComponent<SlimeMesh>().blueMat.color = change;

			//uncomment for mesh
			//get each child box and change their mat color
			GameObject[] children = GameObject.FindGameObjectsWithTag("EdgeVert");
			foreach (GameObject child in children)
			{
				child.GetComponent<Renderer>().material.color = change;
			}

			if (change == Color.blue)
			{
				player.ResetGravity();
			}
		}
	}
    void OnTriggerEnter(Collider other) {
        if (type == InteractType.ColorChange) {
            player.GetComponent<Renderer>().material.color = colorChanger.ChangeColor();
            player.CurrentColor = colorChanger.InteractColor;
        }

        if (type == InteractType.Trap) {
            if (trap.KillPlayer(player.CurrentColor)) {
                player.CurrentPlayerState = Slime.PlayerState.Dead;
            }
        }
    }
}
