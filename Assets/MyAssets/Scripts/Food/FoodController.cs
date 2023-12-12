using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
   [SerializeField] Sprite MassGainer;
   [SerializeField] Sprite MassReducer;
    float height;
    float width;

    private void Awake()
    {
        
    }
    private void Start()
    {
        SpawnFood();
    }
    public void SpawnFood()
    {
        gameObject.transform.position=new Vector3(Random.Range(4,(width*2-4)), Random.Range(4,(height*2-4)),0);
        int count = Random.Range(0, 1);
        if (count== 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MassGainer;
            gameObject.tag = "MassGainer";
        }
        if(count== 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MassReducer;
            gameObject.tag = "MassReducer";
        }
    }

}
