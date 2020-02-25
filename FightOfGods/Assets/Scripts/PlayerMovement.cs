using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetKeyDown(KeyCode.D))
        {
           animator.SetInteger("AnimState", 2); 
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("AnimState", 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("AnimState", 2);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("AnimState", 0);
        }








        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Grounded", false);
            animator.SetFloat("AirSpeed", -1);
            animator.SetInteger("AnimState", 0);

        }
        else
        {
            //animator.SetFloat("AirSpeed", 0);
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

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        //crouch = false;

    }
}
