using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{

    Camera cam;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos=cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject bluePortal=GameObject.FindGameObjectWithTag("blue portal");

            if(bluePortal!=null)
            {
                Destroy(bluePortal);
            }

            Instantiate(portal,new Vector3(cursorPos.x,cursorPos.y,0),Quaternion.identity);

            bluePortal=this.GameObject;
        } 
    }
}
