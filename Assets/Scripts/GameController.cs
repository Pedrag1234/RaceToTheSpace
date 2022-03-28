using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;



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

    public void FinishLine(){
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

        SceneManager.LoadScene(2);

    }

    // Update is called once per frame
    void Update()
    {
        

        //press U to delete score
        if(Input.GetKeyDown(KeyCode.U)){ 
            PlayerPrefs.DeleteAll();
        }
        
    }
}
