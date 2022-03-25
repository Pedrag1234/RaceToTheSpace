using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    Vector3 targetPos;

    public SpriteRenderer crosshair;

    private Color currentColor = Color.white;

    float timeBetweenReset = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;

        crosshair = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = -1;
       
        this.transform.position = targetPos;

        

        if(timeBetweenReset >= 0 && currentColor != Color.white)
        {
            timeBetweenReset -= Time.deltaTime;
        }
        else
        {
            timeBetweenReset = 1f;
            currentColor = Color.white;
        }

        crosshair.color = currentColor;
    }

    public void setCrosshairColour(Color color)
    {
        currentColor = color;
        timeBetweenReset = 1f;
    }
}
