using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Interactable {
    public bool canBePushedThatWay = false;
    Vector3 targetPosition;

    public override bool isFree() {
        return canBePushedThatWay;
    }

    private IEnumerator pushed() {
        int steps = 100;
        Vector3 step = (targetPosition - this.transform.position) / steps;
        for (int i = 0; i < steps; i++) {
            this.transform.position += step;
            yield return null;
        }
    }

    public override void interact(GameObject player) {
        Vector2Int pos = grid.convertPosToGrid(this.transform.position);
        Vector2Int dir = pos - grid.convertPosToGrid(player.transform.position);
        canBePushedThatWay = grid.checkMove(pos + dir, this.gameObject) && player.GetComponent<PlayerBehaviour>();
        if (canBePushedThatWay) {
            targetPosition = grid.convertGridPosToWorld(pos + dir);
            targetPosition.y = 0.0f;
            grid.grid[pos.x][pos.y] = null;
            
            grid.grid[pos.x + dir.x][pos.y + dir.y] = this;
            StartCoroutine("pushed");
        }
    }
}
