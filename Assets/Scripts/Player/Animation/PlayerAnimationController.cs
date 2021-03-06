﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo stateInfo;
    PlayerBehaviour playerBehaviour;
    private bool KickedOnce = false;
    void Start() {
        animator = this.GetComponent<Animator>();
        playerBehaviour = this.GetComponent<PlayerBehaviour>();
    }

    void Update() {
        checkAnimationState();
    }

    void OnAnimatorMove() {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsTag("Walking") || !stateInfo.IsTag("Idle") || !stateInfo.IsTag("Kicking")) {
            animator.ApplyBuiltinRootMotion();
        }
    }

    void checkAnimationState()
    {

        if (playerBehaviour.facingRight)
        {
            animator.SetFloat("RightLeft", 1);
        }
        else if (!playerBehaviour.facingRight)
        {
            animator.SetFloat("RightLeft", -1);
        }

        if (playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.idle)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
        if (playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.rotating)
        {
            animator.SetBool("Turning", true);
        }
        else
        {
            animator.SetBool("Turning", false);
        }
        if (playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.moving)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (playerBehaviour.currentPlayerState == PlayerBehaviour.playerState.kick && !animator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            animator.SetBool("KickBool", true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Kick")) {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)) {
                animator.SetBool("KickBool", false);
                playerBehaviour.isKicking = false;
            }
        }
    }
}
