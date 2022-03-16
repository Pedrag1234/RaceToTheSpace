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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding){
           
            if(grabed){
                transform.position=player.transform.position + new Vector3(0.6f,1,0);
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
