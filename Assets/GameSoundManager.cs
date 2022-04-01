using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public static AudioClip playJumpSound;
    public static AudioClip playShotSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playJumpSound = Resources.Load<AudioClip>("X2Download (mp3cut.net)");
        playShotSound= Resources.Load<AudioClip>("X2Download.com-Laser Gun Sound Effect(360p) (mp3cut.net)");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string option){
        switch(option){
            case "jump":
                audioSrc.PlayOneShot(playJumpSound); 
                break;
            case "shot":
                audioSrc.PlayOneShot(playShotSound); 
                break;
        }
          
    }
}
