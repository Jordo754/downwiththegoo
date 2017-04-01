using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeInteract {
    //color that this changes player to
    private Manager.ColorState color;
    public Manager.ColorState InteractColor {
        get { return color; }
    }

    //constructor
    public ColorChangeInteract (Manager.ColorState a_color) {
        color = a_color;
    }

    public Color ChangeColor () {

        if (this.color == Manager.ColorState.Blue) {
            return Color.blue;
        }

        else if (this.color == Manager.ColorState.Red) {
            return Color.red;
        }

        else if (this.color == Manager.ColorState.Green) {
            return Color.green;
        }

        else {
            return Color.white;
        }

    }
}
