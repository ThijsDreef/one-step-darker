using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour {

    private float maxLightRange;
    private float colouredMaxLightRange;

    [SerializeField]
    private Light colouredLight;
    [SerializeField]
    private Light WhiteLight;

    private float mult;
    private int steps = 0;
    private int maxSteps = 0;

    public void setZero() {
        steps = 0;
    }

    public bool canTakeStep() {
        return steps > 0;
    }

    public void stepDown() {
        steps--;
    }

    public void setSteps(int s) {
        steps = s;
        maxSteps = s;
    }

    private void Start() {
        mult = 1;
        colouredMaxLightRange = colouredLight.range;
        maxLightRange = WhiteLight.range;
    }
    private void Update() {
        mult += (((float)steps / maxSteps) - mult) * Time.deltaTime;
        colouredLight.range = colouredMaxLightRange * mult + (Mathf.Sin(Time.time * 2.0f) * 0.5f + 0.5f) * 2.0f * mult;
        WhiteLight.range = maxLightRange * mult + (Mathf.Sin(Time.time * 1.0f + 10.0f) * 0.5f + 0.5f) * 3.0f * mult;
    }



}
