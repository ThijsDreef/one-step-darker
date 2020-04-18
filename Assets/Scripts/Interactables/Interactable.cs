using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    protected GameGrid grid;
    
    public void setGrid(GameGrid grid) {
        this.grid = grid;
    }

    public virtual bool isFree() {
        return true;
    }

    public virtual void onEnter() {

    }

    public virtual void onExit() {

    }

    public virtual void interact(GameObject player) {

    }
}
