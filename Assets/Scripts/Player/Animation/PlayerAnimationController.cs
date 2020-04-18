using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo stateInfo;
    PlayerBehaviour playerBehaviour;
    void Start() {
        animator = this.GetComponent<Animator>();
        playerBehaviour = this.GetComponent<PlayerBehaviour>();
    }

    void Update() {
        checkAnimationState();
    }

    void OnAnimatorMove() {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsTag("Walking") || !stateInfo.IsTag("Idle")) {
            animator.ApplyBuiltinRootMotion();
        }
    }

    void checkAnimationState() {

        if (playerBehaviour.facingRight) {
            animator.SetFloat("RightLeft", 1);
        }
        else if (!playerBehaviour.facingRight) {
            animator.SetFloat("RightLeft", -1);
        }

        if(playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.idle) {
            animator.SetBool("Idle", true);
        }
        else {
            animator.SetBool("Idle", false);
        }
        if (playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.rotating) {
            animator.SetBool("Turning", true);
        }
        else {
            animator.SetBool("Turning", false);
        }
        if (playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.moving) {
            animator.SetBool("Walking", true);
        }
        else {
            animator.SetBool("Walking", false);
        }
    }
}
