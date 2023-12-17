using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int Players = 1;
    private static PlayersManager instance;
    public static PlayersManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NumberOfPlayers(int i)
    {
        Players = i;
        
    }
    public int GetNumberOfPlayers()
    {
        return Players;
    }
}
