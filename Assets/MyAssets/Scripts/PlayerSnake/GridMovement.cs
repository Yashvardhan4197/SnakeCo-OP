using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField]private GridManager gridManager;
    private void Update()
    {

        float height = gridManager.getHeight();
        float width = gridManager.getWidth();

        if (transform.position.x < -width)
        {
            transform.position = new Vector2(width-1,transform.position.y);
        }
        if(transform.position.x > width)
        {
            transform.position = new Vector2(-width,transform.position.y);
        }

        if (transform.position.y < -height)
        {
            transform.position = new Vector2(transform.position.x,height-1);
        }
        if (transform .position.y > height)
        {
            transform.position = new Vector2(transform.position.x, -height);
        }
    }
}
