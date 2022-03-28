using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private bool grabed=false;
    private bool notrealesed=false;
    private bool colliding=false;



    // Update is called once per frame
    void Update()
    {
        if(colliding){
           
            if(grabed){
                if (player.GetComponent<PlayerController>().getIsFacingRight()) {
                    transform.position = player.transform.position + new Vector3(0.8f, 1, 0);
                }
                else
                {
                    transform.position = player.transform.position + new Vector3(-0.8f, 1, 0);
                }
            }

            if(Input.GetKeyDown(KeyCode.E) && !grabed && !notrealesed){
                
                grabed=true;
                notrealesed=true;
            }

            if(Input.GetKeyDown(KeyCode.E) && grabed && !notrealesed){
                
                grabed=false;
                notrealesed=true;
            }

            if(Input.GetKeyUp(KeyCode.E)){
                notrealesed=false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colliding=true;
        }
    }
}
