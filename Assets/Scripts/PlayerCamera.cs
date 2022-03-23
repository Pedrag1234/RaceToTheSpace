using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool m_IsTeleporting;

    [SerializeField]
    private Vector3 m_Destination;

    public float speed = 0.055f;

    //UI text
    public Text timerText;

    public float secondsCount;
    public int minuteCount;
    public int hourCount;

    // Start is called before the first frame update
    void Start()
    {
        m_Destination = player.transform.position;
        m_IsTeleporting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!m_IsTeleporting)
        {
            transform.position = player.transform.position + new Vector3(0, 2.5f, -12);

            UpdateTimerUI();
        }
        else
        {
            Debug.Log(Vector3.Distance(transform.position, m_Destination));

            if(Vector3.Distance(transform.position,m_Destination) <= 11)
            {
                m_IsTeleporting = false ;

                transform.position = player.transform.position + new Vector3(0, 2.5f, -12);

                UpdateTimerUI();
            }
            else
            {
                Vector3 res = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 2.5f, -12), speed);
                Debug.Log(res);
                transform.position = res; 

                
                UpdateTimerUI();
            }
        }
    }

    //update timer 
    public void UpdateTimerUI(){
         secondsCount += Time.deltaTime;
         timerText.text = hourCount +"H "+ minuteCount +"M "+(int)secondsCount + "S";
         if(secondsCount >= 60){
             minuteCount++;
             secondsCount = 0;
         }else if(minuteCount >= 60){
             hourCount++;
             minuteCount = 0;
         }    
    }

    public void teleportCamera(Vector3 destination)
    {
        m_Destination = destination;
        m_IsTeleporting=true;
    }
}