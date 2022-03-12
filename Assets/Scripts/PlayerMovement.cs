using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 20f;

    [SerializeField]
    private PlayerController controller;


    bool m_Jump = false;
    int m_NJumps = 2;


    float currentMove = 0f;


    // Update is called once per frame
    private void Update()
    {
        currentMove = Input.GetAxisRaw("Horizontal") * m_MovementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            
            if (controller.isGrounded())
            {
                
                m_NJumps = 2;
                m_Jump = true;
                m_NJumps--;
            }
            else
            {
                if(m_NJumps > 0)
                {
                   
                    m_Jump = true;
                    m_NJumps--;
                }
            }
        }

    }

    private void FixedUpdate()
    {
        controller.MoveCharacter(currentMove * Time.deltaTime, m_Jump);
        m_Jump = false ;
    }
}
