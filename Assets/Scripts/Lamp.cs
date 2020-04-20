using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    [SerializeField]
    float min = -5;
    [SerializeField]
    float max = 5;

    [SerializeField]
    float value = 0;
    void Start() {
        
    }

    void Update() {
        value = Mathf.Lerp(min, max, Mathf.PingPong(Time.time,1 ));
        transform.rotation = Quaternion.Euler(0, 0, 180 + value);
    }
}
