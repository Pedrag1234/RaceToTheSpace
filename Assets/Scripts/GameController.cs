using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public Text score;
    public string highscore;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){ //todo: update condition to show score (gameover/gamefinished)
        var scores = score.text.Split(' ');
        int[] times = new int[3];

        for(int i=0;i<scores.Length;i++){
            times[i]=Int32.Parse(scores[i].Remove(scores[i].Length-1));
        }
        
            int secondsScore=times[0]*3600+times[1]*60+times[2];
            PlayerPrefs.SetString ("highscore", score.text);
            Score scoreToAdd = new Score(score.text,secondsScore);
            scoreManager.AddScore(scoreToAdd);
            scoreManager.SaveScore();

        }

        //press U to delete score
        if(Input.GetKeyDown(KeyCode.U)){ 
            PlayerPrefs.DeleteAll();
        }
        
    }
}
