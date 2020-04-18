using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : Interactable {
    public override void interact(GameObject o) {
        Debug.Log("new level");
    }
}
