using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInteract {
    //color of the trap
    private Manager.ColorState color;
    public Manager.ColorState TrapColor {
        get { return color; }
    }

    //constructor takes a color to pass up to Interactable
    public TrapInteract (Manager.ColorState a_color) {
        color = a_color;
    }

    public bool KillPlayer(Manager.ColorState playerColor) {
        if (playerColor == color) {
            return false;
        }

        return true;
    }
}
