using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ladder : Interactable {
    private bool player;
    private bool fired = false;
    public override bool isFree() {
        return player;
    }
    public override void interact(GameObject o) {
        player = o.GetComponent<PlayerBehaviour>()? true : false;
        if (player && !fired) {
            Game.Instance.nextLevel();
            fired = true;
        }
    }
}
