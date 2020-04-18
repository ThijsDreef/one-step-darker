using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DEBUGclickPosition : MonoBehaviour {
    [SerializeField]
    PlayerBehaviour playerBehaviour;

    private void Start() {
        playerBehaviour = this.GetComponent<PlayerBehaviour>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SetTarget();
        }
    }

    void SetTarget() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit)) {
           playerBehaviour.SetTarget(hit.point);
           playerBehaviour.moveTo();
        }
    }

}
