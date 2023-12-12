using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private float height;
    private float width;

    private void Awake()
    {
        transform.position = Vector3.zero;
        height=transform.localScale.y;
        width=transform.localScale.x;
    }
    public float getHeight()
    {
        return height/2;
    }
    public float getWidth()
    {
        return width/2;
    }
}
