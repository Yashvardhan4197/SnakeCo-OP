using UnityEngine;

public class triggerScript : MonoBehaviour
{
    private void Awake()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("CollisionHappened");  
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("MassReducer") || gameObject.CompareTag("MassGainer"))
            {
                FoodController.Instance.DestroyFood(collision.transform);
            }
            else
            {
                FoodController.Instance.DestroyPower(collision.transform);
            }
        }
        
    }
}
