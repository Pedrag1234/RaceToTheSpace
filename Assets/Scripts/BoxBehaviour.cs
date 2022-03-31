using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform m_GrabPoint;

    [SerializeField]
    private Transform m_rayPoint;

    [SerializeField]
    private float m_rayDistance;

    private GameObject m_grabbedObject;
    private int m_layerIndex;



    private void Awake()
    {
        m_layerIndex = LayerMask.NameToLayer("Boxes");
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit2D hit = Physics2D.Raycast(m_rayPoint.position,transform.right,m_rayDistance);

        if(hit != null && hit.collider != null && hit.collider.gameObject.layer == m_layerIndex)
        {
            if(Input.GetKeyDown(KeyCode.E) && m_grabbedObject == null)
            {
                m_grabbedObject = hit.collider.gameObject;
                m_grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                m_grabbedObject.transform.position = m_GrabPoint.position;
                m_grabbedObject.transform.SetParent(transform);
            }
            else if (Input.GetKeyDown(KeyCode.E) && m_grabbedObject != null)
            {
                m_grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                m_grabbedObject.transform.SetParent(null);
                m_grabbedObject = null;
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

}
