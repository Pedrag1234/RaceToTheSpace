using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private bool grabed=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabed){
            transform.position=player.transform.position + new Vector3(0.6f,1,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position=collision.gameObject.transform.position + new Vector3(0.6f,1,0);
            grabed=true;
        }
    }
}
