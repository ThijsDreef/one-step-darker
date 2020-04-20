using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Interactable {
    GameObject crate = null;

    IEnumerator moveBox() {
        yield return new WaitForSeconds(2.0f);
        int steps = 30;
        Vector3 step = -new Vector3(0, 1.55f, 0) / steps;
        for (int i = 0; i < steps; i++) {
            crate.transform.position += step;
            yield return new WaitForFixedUpdate();
        }
        SFX.Instance.playSound(SoundType.FALL);
    }

    public override bool isFree() {
        return crate != null;
    }
    public override void interact(GameObject player) {
        if (!player.GetComponent<PlayerBehaviour>()) {
            Vector2Int pos = grid.convertPosToGrid(this.transform.position);
            crate = player;
            StartCoroutine(moveBox());
        }
    }

}
