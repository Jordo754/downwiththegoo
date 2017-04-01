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
    public enum PlayerState {
        Alive,
        Dead,
        Disabled
    }
    private PlayerState currentPlayerState;

    public PlayerState CurrentPlayerState {
        get { return currentPlayerState; }
        set { currentPlayerState = value; }
    }

    //respawn position (if we add checkpoints)
    private Vector3 respawnPosition;

    // Use this for initialization
    void Start () {
        // starts alive and blue
        currentPlayerState = PlayerState.Alive;
        currentColor = Manager.ColorState.Blue;
        respawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //reset player to respawn position, alive, and blue if dead
        if (currentPlayerState == PlayerState.Dead) {
            transform.position = respawnPosition;
            currentColor = Manager.ColorState.Blue;
            GetComponent<Renderer>().material.color = Color.blue;
            currentPlayerState = PlayerState.Alive;
        }
	}

    // Handle movement of the slime - OBSOLETE
    /*void Move () {
        // check for Left and Right movement
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 0.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 0.5f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }*/

    // Handle jumping of the slime
    void Jump () {
        // STUB
    }

}
