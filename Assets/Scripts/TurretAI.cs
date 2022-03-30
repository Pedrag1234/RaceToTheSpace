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
    private Transform m_TurretCannonEnd;

    [SerializeField]
    private float m_ShotForce;

    [SerializeField]
    private GameObject m_Projectile;

    [SerializeField]
    private string m_tag;

    [SerializeField]
    private float m_FireRate;

    float TimeToFire = 0;


    private Vector2 m_TargetDirection;

    public bool playerDetected = false;

    private void Awake()
    {
        m_tag = m_Projectile.tag;
    }

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
            m_TurretCannon.transform.up = m_TargetDirection;

            if(Time.time > TimeToFire)
            {
                TimeToFire = Time.time + 1 / m_FireRate;
                ShootProjectile();
            }
        }
    }

    private void ShootProjectile()
    {
        GameObject bullet = Instantiate(m_Projectile,m_TurretCannonEnd.position,Quaternion.identity);
        if(m_tag == "Missile")
        {
            bullet.GetComponent<MissileBehaviour>().setUp(m_TurretCannonEnd.up);
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(m_TargetDirection * m_ShotForce);
        }
    }

    void OnDrawGizmos()
    {

        // Then draw it
        Gizmos.DrawRay(transform.position, m_TargetDirection);

    }
}
