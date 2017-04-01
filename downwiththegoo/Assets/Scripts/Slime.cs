using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {
    // initial attributes - Jordan
    // states to handle slime color
    private enum ColorState {
        Blue,
        Red,
        Green
    };
    private ColorState currentColorState;

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
        currentColorState = ColorState.Blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Handle movement of the slime
    void Move() {
        // STUB
    }

    // Handle jumping of the slime
    void Jump() {
        // STUB
    }

}
