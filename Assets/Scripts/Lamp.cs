using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {
    float value = 180;

    [SerializeField]
    float speed;

    float delta = 10.0f;
    void Start() {
        
    }

    void Update() {
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }
}
