using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunBehaviour : MonoBehaviour
{

    public Camera cam;

    public GameObject m_BluePortal;
    public GameObject m_OrangePortal;

    public Transform m_PlayeRaypoint;

    public GameObject crosshair;


    private void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       

        Vector3 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            if (hasDirectLineOfSight(m_PlayeRaypoint.position, worldPoint))
            {
                GameObject bluePortal = GameObject.FindGameObjectWithTag("Blue Portal");


                if (bluePortal != null)
                {
                    Destroy(bluePortal);
                }

                GameObject portal = Instantiate(m_BluePortal, worldPoint, Quaternion.identity);

                if (!isPlaceable(portal))
                {
                    Destroy(bluePortal);
                }
            }
            else
            {
                crosshair.GetComponent<CursorController>().setCrosshairColour(Color.red);
            }
            
               
        }

        if (Input.GetMouseButtonDown(1))
        {

            if(hasDirectLineOfSight(m_PlayeRaypoint.position, worldPoint))
            {
                GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");

                if (orangePortal != null)
                {
                    Destroy(orangePortal);
                }

                GameObject portal = Instantiate(m_OrangePortal, worldPoint, Quaternion.identity);

                if (!isPlaceable(portal))
                {
                    Destroy(orangePortal);
                }
            }
            else
            {
                crosshair.GetComponent<CursorController>().setCrosshairColour(Color.red);
            }
        }
        
    }

    private bool isPlaceable(GameObject obj)
    {

        Collider2D testCollider = obj.GetComponent<Collider2D>();

        Collider2D[] colliders = Physics2D.OverlapBoxAll(testCollider.bounds.center, testCollider.bounds.size,90f);


        Debug.Log(colliders.Length);
        if (colliders.Length > 1)
        {
            Destroy(obj);
            crosshair.GetComponent<CursorController>().setCrosshairColour(Color.red);
            return false;
        }
        else
        {
            crosshair.GetComponent<CursorController>().setCrosshairColour(Color.green);
            return true;
        }
            
    }

    private bool hasDirectLineOfSight(Vector3 source, Vector3 dest)
    {
        Vector3 dir = dest - source;

        float distance = Vector3.Distance(dest,source);

        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(source,dir,distance);

        foreach(RaycastHit2D raycastHit2d in raycastHits)
        {
            if(raycastHit2d.collider.tag != "Player" 
                && raycastHit2d.collider.tag != "Box"
                && raycastHit2d.collider.tag != "Blue Portal"
                && raycastHit2d.collider.tag != "Orange Portal")
            {
                return false;
            }
        }

        return true;
    }
}
