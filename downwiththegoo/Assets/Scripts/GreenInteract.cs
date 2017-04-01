using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenInteract : ColorChangeInteract {
    //constructor takes a color to pass up to ColorChangeInteract which passes to Interactable
    public GreenInteract (Manager.ColorState a_color) : base (a_color) {

    }
}
