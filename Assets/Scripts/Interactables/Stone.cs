using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Interactable {
    public override bool isFree() {
        return false;
    }
}
