using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public float HorizontalMovementValue
    {
        get => horizontalMovementValue;
        set => horizontalMovementValue = value;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = GetInputHorizontal() * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        
    }

    public void Jump()
    {
        animator.SetBool("IsJumping", true);
        jump = true;
    }

    public void onLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public float GetInputHorizontal()
    {
        #if UNITY_EDITOR
            return Input.GetAxisRaw("Horizontal") + HorizontalMovementValue;
        #elif UNITY_ANDROID
            return HorizontalMovementValue;
        #else
            return Input.GetAxisRaw("Horizontal");
        #endif
    }

    private float horizontalMovementValue;
}
