using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunBehaviour : MonoBehaviour
{

    public Camera cam;

    public GameObject m_BluePortal;
    public GameObject m_OrangePortal;


    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPoint = Input.mousePosition;
        worldPoint.z = Mathf.Abs(cam.transform.position.z);
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(worldPoint);
        mouseWorldPosition.z = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue Portal");

            if(bluePortal != null)
            {
                Destroy(bluePortal);
            }

            Instantiate(m_BluePortal, mouseWorldPosition, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");

            if(orangePortal != null)
            {
                Destroy(orangePortal);
            }

            Instantiate(m_OrangePortal, mouseWorldPosition, Quaternion.identity);
        }
    }
}
