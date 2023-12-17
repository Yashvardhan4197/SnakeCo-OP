using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Player director+Object
    private Vector2 _direction = new Vector2(1, 0);
    [SerializeField] GameObject player1;


    //Player2 Director+Object
    private Vector2 _direction2= new Vector2(1, 0);
    [SerializeField] GameObject player2;

    //Tails
    public List<Transform> _segments1List;
    [SerializeField] Transform segment1Prefab;

    //Player2 Tails
    public List<Transform> _segments2List;
    [SerializeField] Transform segment2Prefab;

    //UI-Elements
    [SerializeField] private PauseController pauseController;
    [SerializeField] public GameObject GameOverController;
    [SerializeField]MainLevelUIController mainLevelUIController;
    //[SerializeField] FoodController foodcontroller;
    private bool isdead = false;
    public int count = 0;
    public int speed=1;


    private void Start()
    {
        _segments1List = new List<Transform>();
        _segments2List = new List<Transform>();
        _segments1List.Add(player1.transform);
        _segments2List.Add(player2.transform);
        Time.timeScale = 1;  
        if (PlayersManager.Instance.GetNumberOfPlayers()==1)
        {
           player2.SetActive(false);
        }
        else
        {
            player2.SetActive(true);
            _segments2List.Add(player2.transform);
        }

    }
    private void Update()
    {
        //GoBack
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseTab();
        }
        //Player1-Input
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_direction.y != -speed)
            {
                _direction = new Vector2(0, speed);
                player1.transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if (_direction.y != +speed)
            {
                _direction = new Vector2(0, -speed);
                player1.transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        else if( Input.GetKeyDown(KeyCode.D))
        {
            if (_direction.x != -speed)
            {
                _direction = new Vector2(speed, 0);
                player1.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.A)) 
        {
            if (_direction.x != +speed)
            {
                _direction = new Vector2(-speed, 0);
                player1.transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }

        //Player2
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_direction2.y != -speed)
            {
                _direction2 = new Vector2(0, speed);
                player2.transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_direction2.y != +speed)
            {
                _direction2 = new Vector2(0, -speed);
                player2.transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_direction2.x != -speed)
            {
                _direction2 = new Vector2(speed, 0);
                player2.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_direction2.x != +speed)
            {
                _direction2 = new Vector2(-speed, 0);
                player2.transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }


    }

    private void FixedUpdate()
    {
        for (int i = _segments1List.Count - 1; i > 0; i--)
        {
            _segments1List[i].position = _segments1List[i - 1].position;
        }
        player1.transform.position=new Vector3(
            Mathf.RoundToInt( player1.transform.position.x)+ _direction.x,
            Mathf.RoundToInt(player1.transform.position.y)+ _direction.y,
            0);

        if (PlayersManager.Instance.GetNumberOfPlayers() == 2)
        {

            for (int i = _segments2List.Count - 1; i > 0; i--)
            {
                _segments2List[i].position = _segments2List[i - 1].position;
            }
            player2.transform.position = new Vector3(
                Mathf.RoundToInt(player2.transform.position.x) + _direction2.x,
                Mathf.RoundToInt(player2.transform.position.y) + _direction2.y,
                0);
        }
    }
    private void OpenPauseTab()
    {
        if (isdead == false)
        {
            pauseController.PauseGame();
        }
    }
    public void GrowPlayer(int pNumber)
    {
        if (pNumber == 1)
        {
            for (int i = 0; i < Random.Range(1f, 3f); i++)
            {
                Transform segment = Instantiate(segment1Prefab);
                segment.position = _segments1List[_segments1List.Count - 1].position;
                _segments1List.Add(segment);
            }
            if (PlayersManager.Instance.GetNumberOfPlayers() == 1)
            {
                mainLevelUIController.ChangeScore(1);
            }
            else
            {
                mainLevelUIController.UpdateMultiplayerScore(1, 1);
            }
        }
        else if(pNumber == 2)
        {
            for (int i = 0; i < Random.Range(1f, 3f); i++)
            {
                Transform segment = Instantiate(segment2Prefab);
                segment.position = _segments2List[_segments2List.Count - 1].position;
                _segments2List.Add(segment);
            }
            mainLevelUIController.UpdateMultiplayerScore(1, 2);
        }
    }
    public void ReducePlayer(int pNumber)
    {
        if (pNumber==1)
        {
            if (_segments1List.Count > 1)
            {
                int lasttail = _segments1List.Count - 1;
                Destroy(_segments1List[lasttail].gameObject);
                _segments1List.RemoveAt(_segments1List.Count - 1);
                if (PlayersManager.Instance.GetNumberOfPlayers() == 1)
                {
                    mainLevelUIController.ChangeScore(-1);
                }
                else
                {
                    mainLevelUIController.UpdateMultiplayerScore(-1, 1);
                }
            }
        }
        else if(pNumber==2)
        {
            if (_segments2List.Count > 1)
            {
                int lasttail = _segments2List.Count - 1;
                Destroy(_segments2List[lasttail].gameObject);
                _segments2List.RemoveAt(_segments2List.Count - 1);
            }
            mainLevelUIController.UpdateMultiplayerScore(-1, 2);
        }
    }

    public void PointsMultiplier(int pNumber)
    {
        StartCoroutine(startMultiplier(pNumber));
    }

    public void isDead(bool dead)
    {
        isdead = dead;
    }


    //ScoreMultiplier CoRoutines
    IEnumerator startMultiplier(int pNumber)
    {
        if(pNumber == 1)
        {
            mainLevelUIController.scorePower1 = true;
        }
        else
        {
            mainLevelUIController.scorePower2 = true;
        }
        mainLevelUIController.setPlayerMultiplierUI();
        yield return new WaitForSeconds(3f);
        if(pNumber == 1)
        {
            mainLevelUIController.scorePower1=false;
        }
        else
        {
            mainLevelUIController.scorePower2=false;
        }
        mainLevelUIController.setPlayerMultiplierUI();
    }


    //ShieldUICalling
    public void ShieldUICallfromTrigger(int pNumber,bool state)
    {
        mainLevelUIController.setPlayerShieldUI(pNumber, state);
    }


    //GameOverCallings
    public void GameOver()
    {
        mainLevelUIController.GameOverbutwhichOne();
    }

}
