using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private static FoodController instance;
    public static FoodController Instance { get { return instance; } }


   [SerializeField] GridManager gridManager;
    [SerializeField] PlayerController playerController1;
    [SerializeField] GameObject massGainerObj;
    [SerializeField] GameObject massReducerObj;
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject Multiplier;
    private Transform Powers;
    float height;
    float width;
    bool start = false;
    Vector3 position;
    private List<Transform>Foods = new List<Transform>();


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    { 
        height = gridManager.getHeight();
        width = gridManager.getWidth();
        StartCoroutine(SpawnFood());
        StartCoroutine(startPowerupSpawn());
    }

       
    IEnumerator SpawnFood()
    {
        while (true)
        {
            int count = Random.Range(0, 2);
            if (start == false || count == 1)
            {
                Transform tempFood = SpawnGainer();
                Foods.Add(tempFood);
                start = true;
            }
            else if (count==0&&playerController1._segments1List.Count - 1 > 2)
            {
                Transform tempFood = SpawnReducer();
                Foods.Add(tempFood);
            }

            yield return new WaitForSeconds(Random.Range(1f, 3f));


            if (Foods.Count-1 > 2)
            {
                for(int i=0;i<Foods.Count-2;i++)
                {
                    yield return new WaitForSeconds(3f);
                    Destroy(Foods[i].gameObject);
                    Foods.RemoveAt(i);
                }
            }
        }

    }

    public void DestroyFood(Transform playerPos)
    {
        for (int i = Foods.Count - 1; i >= 0; i--)
        {
            if (Vector2.Distance(playerPos.position, Foods[i].position) < 1f)
            {
                Destroy(Foods[i].gameObject);
                Foods.RemoveAt(i);
            }
        }
    }


    public void DestroyPower(Transform playerPos)
    {
        if (Vector2.Distance(playerPos.position, Powers.position) < 1f)
        {
            Destroy(Powers.gameObject);
        }
    }
    private Transform SpawnGainer()
    {
        position = RandomizePosition();
        Transform foodGainer = Instantiate(massGainerObj.transform);
        foodGainer.position = position;
        foodGainer.gameObject.tag = "MassGainer";
        return foodGainer;

    }
    private Transform SpawnReducer()
    {
        position = RandomizePosition();
        Transform foodReducer = Instantiate(massReducerObj.transform);
        foodReducer.position = position;
        foodReducer.gameObject.tag = "MassReducer";
        return foodReducer;
    }

    private Vector2 RandomizePosition()
    {
        int x = Mathf.RoundToInt(Random.Range(-width + 2, (width - 2)));
        int y=Mathf.RoundToInt(Random.Range(- height + 2, (height -2)));

        Vector2 position = new Vector2(x, y);
        return position;
    }



    IEnumerator startPowerupSpawn()
    {
        while (true)
        {
            if (Powers != null)
            {
               Destroy(Powers.gameObject);
            }
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            Powers = PowerUpSpawner();
            yield return new WaitForSeconds(Random.Range(3f, 5f));

        }
    }


    private Transform PowerUpSpawner()
    {
        int temp = Random.Range(0, 2);
        Debug.Log(temp);
        position = RandomizePosition();
        switch (temp)
        {
            case 0:
                {
                    Transform powerUp = Instantiate(Shield.transform);
                    powerUp.gameObject.tag = "Shield";
                    powerUp.position = position;
                    return powerUp;
                }
            case 1:
                {
                    Transform powerUp = Instantiate(Multiplier.transform);
                    powerUp.gameObject.tag = "Multiplier";
                    powerUp.position = position;
                    return powerUp;
                }
        }
        return null;
    }



}
