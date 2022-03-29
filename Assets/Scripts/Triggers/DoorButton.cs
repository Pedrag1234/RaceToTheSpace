using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private DoorSetActive door;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player" || collider.tag == "Box"){
            door.OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.tag == "Player" || collider.tag == "Box")
        {
            door.CloseDoor();
        }
    }

    private void OnTriggerStay2D(Collider2D collider){
        if(collider.tag == "Player" || collider.tag == "Box"){
            door.OpenDoor();
        }
    }
}
