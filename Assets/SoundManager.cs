using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playHoverSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playHoverSound = Resources.Load<AudioClip>("Half Life Button Hover_Select Sound Effect (mp3cut.net)");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (){
        audioSrc.PlayOneShot(playHoverSound);   
    }
}
