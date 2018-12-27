using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(CharacterController2D))]
public class PlayerMovement : MonoBehaviour {

    private CharacterController2D playerMotor;
    private PlayerState playerState;
    private Animator animator;

    private float moveDir_X;

    private bool isJump = false;
    private bool isCrouch = false;
    private bool FacingRight = true;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        playerMotor = GetComponent<CharacterController2D>();
        playerState = GetComponent<PlayerState>();

    }
	
	// Update is called once per frame
	void Update () {

        moveDir_X = Input.GetAxisRaw("Horizontal")*playerState.GetSpeed();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        animator.SetFloat("Speed", Mathf.Abs( moveDir_X));

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            isJump = true;
            animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("Crouch");
            isCrouch = true;
            //animator.SetBool("Crouch", isCrouch);
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            isCrouch = false;
            //animator.SetBool("Crouch", isCrouch);
        }

        if(mousePosition.x> transform.position.x)
        {
            FacingRight = true;
        }else if (mousePosition.x< transform.position.x)
        {
            FacingRight = false;
        }


    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
        Debug.Log("OnLanding()");
    }

    public void OnCrouching(bool _isCrouch)
    {
        animator.SetBool("Crouch", _isCrouch);
    }

    private void FixedUpdate()
    {
        playerMotor.Move(moveDir_X*Time.deltaTime, isCrouch, isJump, FacingRight);
            isJump = false;
        
    }
}
