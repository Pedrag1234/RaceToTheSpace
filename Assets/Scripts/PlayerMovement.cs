using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 20f;

    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private Animator animator;


    bool m_Jump = false;


    float currentMove = 0f;


    // Update is called once per frame
    private void Update()
    {
        currentMove = Input.GetAxisRaw("Horizontal") * m_MovementSpeed;

        if(Mathf.Abs(currentMove) > 1f)
        {
            if (animator.GetBool("StartRun"))
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("StartRun",true);
            }
        }
        else
        {
            animator.SetBool("StartRun", false);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {

           animator.SetBool("StartJump", true);
           animator.SetBool("JumpEnded", false); 
           m_Jump = true;

        }

        animator.SetFloat("FallSpeed", controller.getFallSpeed());
    }

    public void OnLanding()
    {
        animator.SetBool("JumpEnded",true );
    }

    private void FixedUpdate()
    {
        controller.MoveCharacter(currentMove * Time.deltaTime, m_Jump);

        m_Jump = false ;
    }
}
