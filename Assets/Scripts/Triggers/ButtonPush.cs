using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    private Animator animator;

    private void Awake(){
        animator=GetComponent<Animator>();
    }

    public void DownButton(){
        animator.SetBool("Push",true);
    }

    public void UpButton(){
        animator.SetBool("Push",false);
    }
}
