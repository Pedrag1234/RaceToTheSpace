using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    [SerializeField]
    private float m_Range = 5f;

    [SerializeField]
    private Transform m_Target;
    
    [SerializeField]
    private DoorSetActive door;

    private Vector2 m_TargetDirection;

    public bool playerDetected = false;


    // Update is called once per frame
    void Update()
    {

        m_TargetDirection = m_Target.position - transform.position;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, m_TargetDirection, m_Range);

        if (ray.collider != null)
        {
            if(ray.collider.gameObject.tag == "Player")
            {
                if (!playerDetected)
                {
                    playerDetected = true;
                }
                    
            }
        }
        else
        {
            if (playerDetected)
            {
                playerDetected = false;

            }
        }

        if (playerDetected)
        {
            gameObject.transform.up = m_TargetDirection;
            door.OpenDoor();
        }
        else
            door.CloseDoor();
    }
}

