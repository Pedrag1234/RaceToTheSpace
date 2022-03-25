using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunBehaviour : MonoBehaviour
{

    public Camera cam;

    public GameObject m_BluePortal;
    public GameObject m_OrangePortal;

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

        if (Input.GetMouseButtonDown(1))
        {
            GameObject orangePortal = GameObject.FindGameObjectWithTag("Orange Portal");

            string s = string.Format("Blue Portal pos = {0}", worldPoint);
            Debug.Log(s);

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
    }

    private bool isPlaceable(GameObject obj)
    {

        Collider2D testCollider = obj.GetComponent<Collider2D>();

        Debug.Log((Vector2)testCollider.bounds.center);

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
}
