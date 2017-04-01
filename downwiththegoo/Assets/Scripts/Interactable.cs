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

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "EdgeVert" || other.tag == "CenterVert") {
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

<<<<<<< HEAD
			if (change == Color.red || change == Color.blue) {
				player.SetGravity();
			}
		}
=======
                if (change == Color.blue)
                {
                    player.ResetGravity();
                }
            }
        }
>>>>>>> cf5fbbb40f9786708688f02de10c74ff5e498807
	}

    void OnCollisionEnter2D(Collision2D other) {
		Debug.Log("wall check");
		if (type == InteractType.Wall)
		{
			if (this.transform.position.x > other.transform.position.x) {
				Debug.Log("right");
				GameObject.Find("Center").GetComponent<Rigidbody2D>().AddForce(Vector2.right * stickForce * Time.deltaTime);
			}

			if (this.transform.position.x < other.transform.position.x) {
				Debug.Log("wrong");
				GameObject.Find("Center").GetComponent<Rigidbody2D>().AddForce(Vector2.left * stickForce * Time.deltaTime);
			}

			player.currentColor = Manager.ColorState.Green;
			player.GetComponent<SlimeMesh>().blueMat.color = Color.green;

			GameObject.Find("InputManager").GetComponent<InputManager>().resetJump();
			player.SetGravity();
		}
    }
}
