using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    //public vars
    public Slime player;
    public Manager.ColorState color;
	public int stickForce;

    //type of interactable
    public enum InteractType {
        ColorChange,
        Trap,
		Wall
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
			stickForce = -1;

		}

        if (tag == "Trap") {
            type = InteractType.Trap;
            trap = new TrapInteract(color);
			stickForce = -1;

		}

		if (tag == "Wall")
		{
			type = InteractType.Wall;
			colorChanger = new ColorChangeInteract(color);
			stickForce = 5000;
		}
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "EdgeVert" || other.tag == "CenterVert") {
            if (type == InteractType.ColorChange)
            {
                //recieve the color to change to
                Color change = colorChanger.ChangeColor();

                //set new color state
                player.CurrentColor = colorChanger.InteractColor;

                //change mat color
                player.GetComponent<SkinnedMeshRenderer>().materials[0].color = change;

                //set gravity now if red or blue
                if (change == Color.red || change == Color.blue)
                {
                    player.SetGravity();
                }
            }
        }
	}

    void OnCollisionEnter(Collision other) {
        if (type == InteractType.Wall && player.currentColor == Manager.ColorState.Green)
		{
			if (this.transform.position.x > other.transform.position.x) {

			}

			if (this.transform.position.x < other.transform.position.x) {

			}

            player.colliding = true;
            GameObject.Find("InputManager").GetComponent<InputManager>().ResetJump();
            player.SetGravity();
            player.GetComponent<Rigidbody>().drag = 0;
            player.GetComponent<Rigidbody>().angularDrag = 0;
        }
    }

    void OnCollisionExit(Collision other) {
        if (type == InteractType.Wall) {
            player.ResetGravity();
            player.colliding = false;
        }
    }
}
