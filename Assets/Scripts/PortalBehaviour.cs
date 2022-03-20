using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform m_Destination;

    public bool color = false;
    public float distance = 0.2f;


    public float timeBetweenTP = 1;


    void Start()
    {
        timeBetweenTP = 0;
        if (color == true)
        {
            if (GameObject.FindGameObjectWithTag("Blue Portal") != null)
            {
                m_Destination = GameObject.FindGameObjectWithTag("Blue Portal").transform;
            }
        }
        else {
            if (GameObject.FindGameObjectWithTag("Orange Portal") != null)
            {
                m_Destination = GameObject.FindGameObjectWithTag("Orange Portal").transform;
            }
        }
    }

    private void Update()
    {
        if(timeBetweenTP > 0)
        {
            timeBetweenTP -= Time.deltaTime;
        }

        if(m_Destination == null)
        {
            if (color == true)
            {
                if (GameObject.FindGameObjectWithTag("Blue Portal") != null)
                {
                    m_Destination = GameObject.FindGameObjectWithTag("Blue Portal").transform;
                }
               
            }
            else
            {
                if(GameObject.FindGameObjectWithTag("Orange Portal") != null)
                {
                    m_Destination = GameObject.FindGameObjectWithTag("Orange Portal").transform;
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Vector2.Distance(transform.position, collision.transform.position) > distance && collision.tag == "Player" && timeBetweenTP <= 0)
        {
            collision.transform.position = new Vector2(m_Destination.position.x, m_Destination.position.y);
            timeBetweenTP = 1;
        }
    }
}
