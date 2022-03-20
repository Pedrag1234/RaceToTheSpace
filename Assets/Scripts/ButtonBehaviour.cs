using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private bool pressed=false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!pressed)
            transform.position=transform.position - new Vector3(0,0.5f,0);
        
        pressed=true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(pressed)
            transform.position=transform.position - new Vector3(0,-0.5f,0);

        pressed=false;

    }
}
