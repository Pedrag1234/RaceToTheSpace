using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private DoorAnimator door;
    [SerializeField] private ButtonPush tip;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player" || collider.tag == "Box"){
            door.OpenDoor();
            tip.DownButton();
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.tag == "Player" || collider.tag == "Box")
        {
            door.CloseDoor();
            tip.UpButton();
        }
    }

    private void OnTriggerStay2D(Collider2D collider){
        if(collider.tag == "Player" || collider.tag == "Box"){
            door.OpenDoor();
        }
    }
}
