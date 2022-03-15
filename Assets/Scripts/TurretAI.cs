using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [SerializeField]
    private float m_Range = 5f;

    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private GameObject m_TurretCannon;

    [SerializeField]
    private float m_TurretRadius = 45f;


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
                Debug.Log("Can Raycast");
                if (!playerDetected)
                {
                    playerDetected = true;
                    Debug.Log("Player Detected");
                }
                   
            }
        }
        else
        {
            Debug.Log("Cannot Raycast");
            if (playerDetected)
            {
                Debug.Log("Player Out of range");
                playerDetected = false;

            }
        }

        if (playerDetected)
        {
            m_TurretCannon.transform.up = m_TargetDirection;
        }
    }

    void OnDrawGizmos()
    {

        // Create the ray you want to check
        float rayLength = 3f;

        // Then draw it
        Gizmos.DrawRay(transform.position, m_TargetDirection);

    }
}
