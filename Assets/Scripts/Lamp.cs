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

    [SerializeField]
    Steps steps;

    [SerializeField]
    Light pointLight;
    float colouredMaxLightRange;
    void Start() {
        colouredMaxLightRange = pointLight.range;
    }

    void Update() {
        pointLight.range = colouredMaxLightRange * steps.mult + (Mathf.Sin(Time.time * 2.0f) * 0.5f + 0.5f) * .25f * steps.mult;
        value = Mathf.Lerp(min, max, Mathf.PingPong(Time.time,1 ));
        transform.rotation = Quaternion.Euler(0, 0, 180 + value);
    }
}
