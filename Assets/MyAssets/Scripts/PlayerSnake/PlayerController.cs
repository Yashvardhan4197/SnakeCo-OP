using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _direction = new Vector2(1, 0);
    [SerializeField] GameObject player1;
    private List<Transform> _segments1List;
    [SerializeField] Transform segment1Prefab;
    [SerializeField] private GameObject Pausetab;
    private bool isPaused = false;
    public int count = 0;
    public int speed=1;

    private void Start()
    {
        _segments1List = new List<Transform>();
        _segments1List.Add(player1.transform);
        Time.timeScale = 1;  
        if (count == 1)
        {
           // player2.SetActive(false);
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
        
    }

    private void FixedUpdate()
    {
        for (int i = _segments1List.Count - 1; i > 0; i--)
        {
            _segments1List[i].position = _segments1List[i - 1].position;
        }
        player1.transform.position=new Vector3(
            Mathf.Round( player1.transform.position.x)+ _direction.x,
            Mathf.Round(player1.transform.position.y)+ _direction.y,
            0);
    }
    private void OpenPauseTab()
    {
        if (isPaused == false)
        {
            Pausetab.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;   
        }
        else if (isPaused == true)
        {
            Pausetab.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }
    private void GrowPlayer1()
    {
        Transform segment = Instantiate(segment1Prefab);
        segment.position= _segments1List[_segments1List.Count-1].position;
        _segments1List.Add(segment);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Food")
        {
            GrowPlayer1();
            count = Random.Range(1, 3);
            Debug.Log("hELLO");
        }
    }

}
