using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private DoorSetActive door;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.GetComponent<CharacterController>()!=null){
            door.OpenDoor();
        }
    }
}