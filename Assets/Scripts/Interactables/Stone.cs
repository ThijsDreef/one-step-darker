using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Interactable {
    public override bool isFree() {
        return false;
    }

    private void Start() {
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
}
