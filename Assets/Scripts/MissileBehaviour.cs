using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class MissileBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private Rigidbody2D m_Rigidbody;

    [SerializeField]
    private float m_Speed= 4f;

    [SerializeField]
    private float m_RotationSpeed = 200f;

    // Start is called before the first frame update
    void Awake()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)m_Target.position - m_Rigidbody.position;

        direction.Normalize();

        float rotation = Vector3.Cross(direction, transform.up).z;

        m_Rigidbody.angularVelocity = -rotation * m_RotationSpeed;

        m_Rigidbody.velocity =  transform.up * m_Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setUp(Vector3 up)
    {
         m_Rigidbody.transform.up = up;
    }
}
