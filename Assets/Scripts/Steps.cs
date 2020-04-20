using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour {

    private float maxLightRange;
    private float colouredMaxLightRange;
    private AudioSource source;

    [SerializeField]
    private Light colouredLight;
    [SerializeField]
    private Light WhiteLight;

    public float mult;
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
        source = GetComponent<AudioSource>();
        colouredMaxLightRange = colouredLight.range;
        maxLightRange = WhiteLight.range;
    }
    private void Update() {
        source.volume = 0.25f + ((float)steps / maxSteps) * 0.75f;
        mult += ((((float)Mathf.Clamp(steps, 0, 10) / 10) * 0.5f + (((float)steps/maxSteps) * 0.5f)) - mult) * Time.deltaTime;
        colouredLight.range = colouredMaxLightRange * mult + (Mathf.Sin(Time.time * 0.5f) * 0.5f + 0.5f) * mult;
        WhiteLight.range = maxLightRange * mult + (Mathf.Sin(Time.time * 1.0f + 10.0f) * 0.5f + 0.5f) * 3.0f * mult;
    }



}
