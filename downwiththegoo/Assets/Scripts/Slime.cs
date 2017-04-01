using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {
    // initial attributes - Jordan
    // states to handle slime color
    private Manager.ColorState currentColor;
    public Manager.ColorState CurrentColor {
        get { return currentColor; }
        set { currentColor = value; }
    }

    // states to handle slime player state
    private enum PlayerState {
        Alive,
        Dead,
        Disabled
    }
    private PlayerState currentPlayerState;
    
	// Use this for initialization
	void Start () {
        // starts alive and blue
        currentPlayerState = PlayerState.Alive;
        currentColor = Manager.ColorState.Blue;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    // Handle movement of the slime
    void Move () {
        // check for Left and Right movement
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 0.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 0.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }

    // Handle jumping of the slime
    void Jump () {
        // STUB
    }

}
