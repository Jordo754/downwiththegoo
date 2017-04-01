using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueInteract : ColorChangeInteract {
    //constructor takes a color to pass up to ColorChangeInteract which passes to Interactable
    public BlueInteract (Manager.ColorState a_color) : base (a_color) {

    }
}
