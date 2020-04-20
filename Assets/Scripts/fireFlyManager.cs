using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fireFlyManager : MonoBehaviour {
    public Material fireFlyMat;
    public Material fireFlyTrailMat;
    public Steps steps;
    [Range(0.0f, 4.0f)]
    public float lightValue;

    public Color FireFlyColor;

    [SerializeField]
    private float LightStartValue = 2f;
    void Start() {
        lightValue = LightStartValue;
        
    }

    void Update() {
        lightValue = LightStartValue * (1.0f - steps.mult);
        fireFlyMat.color = (Color.white * (1.0f - steps.mult));
        fireFlyTrailMat.color = (Color.white * (1.0f - steps.mult));
        fireFlyMat.SetVector("_EmissionColor", FireFlyColor * lightValue);
    }
}
