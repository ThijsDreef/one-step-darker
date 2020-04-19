using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour {
    public enum playerState{
        idle,
        rotating,
        moving,
        climbing,
        death
    }

    [SerializeField]
    public playerState currentPlayerState;
    public bool facingRight;
    public bool isReadyForNextCommand = false;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    [SerializeField]
    float playerMovementSpeed;

    void Start() {
        isReadyForNextCommand = true;
        currentPlayerState = playerState.idle;
        //targetPosition = new Vector3(5, 0, 5);
       // StartCoroutine(PlayerStructure());
    }

    void Update() {
        if(currentPlayerState == playerState.moving) {
            //Debug.Log("Moving");
            //Debug.Log(targetPosition);
            PlayerWalk();
            float distance = Vector3.Distance(transform.position, targetPosition);
            if (distance < 0.2f) {
                isReadyForNextCommand = true;
            }
            if(distance < 0.1f) {
                transform.position = targetPosition;
                StartCoroutine(SetIdle());
            }
        }

        if (currentPlayerState == playerState.rotating) {
            //Debug.Log("rotating");
            if (1 - Mathf.Abs(Quaternion.Dot(transform.rotation, targetRotation)) < 0.001f) {
                currentPlayerState = playerState.moving;
            }
        }

        if (currentPlayerState == playerState.idle) {
            //Debug.Log("Idle");
        }
    }

    private void PlayerWalk() {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * playerMovementSpeed);
    }

    private void setRotationTarget() {
        Vector3 lookPos = targetPosition - transform.position;
        lookPos.y = 0;
        targetRotation = Quaternion.LookRotation(lookPos);
    }

    public void setTurnSide() {
        Vector3 cross = Vector3.Cross(transform.rotation * Vector3.forward, targetRotation * Vector3.forward);
        facingRight = cross.y < 0;
    }

    //For actual useage in game
    public void SetTarget(Vector3 position) {
        targetPosition = position;
        setRotationTarget();
        setTurnSide();
    }

    public void moveTo() {
        isReadyForNextCommand = false;
        currentPlayerState = playerState.rotating;
    }

    public IEnumerator SetIdle() {
        yield return new WaitForSeconds(0.1f);
        if(isReadyForNextCommand == true) {
            currentPlayerState = playerState.idle;
        }
    }
}
