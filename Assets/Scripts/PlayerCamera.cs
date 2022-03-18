using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    //UI text
    public Text timerText;

    public float secondsCount;
    public int minuteCount;
    public int hourCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=player.transform.position + new Vector3(5,2.5f,-10);

        UpdateTimerUI();
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
}