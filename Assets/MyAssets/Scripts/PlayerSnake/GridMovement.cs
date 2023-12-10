using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private void Update()
    {
        Vector3 screenPos= Camera.main.WorldToScreenPoint(transform.position); 

        float topSideOfScreen=Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)).y;
        float bottomSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0,0)).y;

        float rightSideOfScreen=Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x;
        if (screenPos.x < 0)
        {
            Debug.Log(rightSideOfScreen);
            transform.position = new Vector2(rightSideOfScreen, transform.position.y);
        }
        if(screenPos.x > Screen.width)
        {
            transform.position = new Vector2(leftSideOfScreen, transform.position.y);
        }
        if (screenPos.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topSideOfScreen);
        }
        if (screenPos.y > Screen.height)
        {
            transform.position = new Vector2(transform.position.x, bottomSideOfScreen);
        }
        
    }
}
