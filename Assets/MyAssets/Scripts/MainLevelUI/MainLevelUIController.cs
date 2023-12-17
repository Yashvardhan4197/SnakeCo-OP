using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainLevelUIController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI highScore;

    [SerializeField] GameObject ScoreSinglePlayer;
    [SerializeField] GameObject HighScoreSinglePlayer;

    [SerializeField] GameObject Score1stPlayer;
    [SerializeField] GameObject Score2ndPlayer;

    [SerializeField] TextMeshProUGUI score1stPlayerText;
    [SerializeField] TextMeshProUGUI score2ndPlayerText;

    [SerializeField] GameObject GameOverUISinglePlayer;
    [SerializeField] GameObject GameOverUIMultiPlayer;
    [SerializeField] GameObject ImageWhoWon;


    //GamePowersSetup
    [SerializeField] GameObject Player1Multiplier;
    [SerializeField] GameObject Player2Multiplier;
    [SerializeField] GameObject Player1Shield;
    [SerializeField] GameObject Player2Shield;
    

    //variables
    int maxScore;
    int score;
    public bool scorePower1;
    public bool scorePower2;
    int scoreMulti_1;
    int scoreMulti_2;
    void Start()
    {
        score = 0;
        scoreMulti_1 = 0;
        scoreMulti_2 = 0;
        scorePower1 = false;
        scorePower2 = false;
        maxScore = PlayerPrefs.GetInt("HighScore",0);
        RefreshUI();
        GameOverUISinglePlayer.SetActive(false);
        GameOverUIMultiPlayer.SetActive(false);
        if (PlayersManager.Instance.GetNumberOfPlayers() == 1)
        {
            ScoreSinglePlayer.SetActive(true);
            HighScoreSinglePlayer.SetActive(true);
            Score1stPlayer.SetActive(false);
            Score2ndPlayer.SetActive(false);
            Player2Multiplier.SetActive(false);
            Player2Shield.SetActive(false);
        }
        else if (PlayersManager.Instance.GetNumberOfPlayers() == 2)
        {
            ScoreSinglePlayer.SetActive(false);
            HighScoreSinglePlayer.SetActive(false);
            Score1stPlayer.SetActive(true);
            Score2ndPlayer.SetActive(true);
        }

    }

    

    private void setHighScore(int scor)
    {
        PlayerPrefs.SetInt("HighScore", scor);
        PlayerPrefs.Save();
    }

    private void RefreshUI()
    {
        if (PlayersManager.Instance.GetNumberOfPlayers() == 1)
        {
           
            currentScore.text = "" + score;
            highScore.text = "" + PlayerPrefs.GetInt("HighScore", 0);
        }
        else
        {
            score1stPlayerText.text = "" + scoreMulti_1;
            score2ndPlayerText.text = "" + scoreMulti_2;
        }
    }

    public void ChangeScore(int G_Rscore)
    {
        if (G_Rscore == -1)
        {
            if (score > 0)
            {
                score--;
            }
        }
        else if(G_Rscore == 1)
        {
            if (scorePower1 == false)
            {
                score++;
            }
            else if(scorePower1==true)
            {
                score = score + 2;
            }
            //if (score > maxScore)
            //{
            //    maxScore = score;
            //    setHighScore(maxScore);
            //}
        }
        RefreshUI();
    }

    public void UpdateMultiplayerScore(int GR1,int pNumber)
    {
        if (pNumber == 1)
        {
            if (GR1 == -1)
            {
                if (scoreMulti_1 > 0)
                {
                    scoreMulti_1--;
                }
                
            }
            else
            {
                if (scorePower1 == false)
                {
                    scoreMulti_1++;
                }
                else if(scorePower1 == true)
                {
                    scoreMulti_1=scoreMulti_1+2;
                }
            }
        }
        if (pNumber == 2)
        {
            if (GR1 == -1)
            {
                if (scoreMulti_2 > 0)
                {
                    scoreMulti_2--;
                }

            }
            else
            {
                if (scorePower2 == false)
                {
                    scoreMulti_2++;
                }
                else if (scorePower2 == true)
                {
                    scoreMulti_2=scoreMulti_2+2;
                }
            }
        }

        RefreshUI();
    }

    public void GameOverbutwhichOne()
    {
        if (PlayersManager.Instance.GetNumberOfPlayers() == 1)
        {
            GameOverUISinglePlayer.SetActive(true);
            ImageWhoWon.GetComponent<Image>().color = Color.red;

            if (score > maxScore)
            {
                maxScore = score;
                setHighScore(maxScore);
                RefreshUI();
            }
        }
        if (PlayersManager.Instance.GetNumberOfPlayers() == 2)
        {
            GameOverUIMultiPlayer.SetActive(true);
            if (scoreMulti_1 > scoreMulti_2)
            {
                ImageWhoWon.GetComponent<Image>().color = Color.red;
            }
            else if(scoreMulti_2>scoreMulti_1)
            {
                ImageWhoWon.GetComponent<Image>().color = Color.green;
            }
            else
            {

            }
        }
    }


    //PowersUIHandler
    public void setPlayerMultiplierUI()
    {
        if(scorePower1 == true)
        {
            Player1Multiplier.GetComponent<Image>().color = Color.yellow;
        }
        else if(scorePower1 == false)
        {
            Player1Multiplier.GetComponent<Image>().color = Color.white;
        }

        //
        if(scorePower2 == true)
        {
            Player2Multiplier.GetComponent<Image>().color = Color.yellow;
        }
        else if(scorePower2 ==false)
        {
            Player2Multiplier.GetComponent<Image>().color = Color.white;
        }
    }
   
    public void setPlayerShieldUI(int pNumber,bool shieldStatus)
    {
        if(pNumber == 1)
        {
            if(shieldStatus == true)
            {
                Player1Shield.GetComponent<Image>().color = Color.blue;
            }
            else
            {
                Player1Shield.GetComponent <Image>().color = Color.white;
            }
        }
        if(pNumber == 2)
        {
            if (shieldStatus == true)
            {
                Player2Shield.GetComponent<Image>().color = Color.blue;
            }
            else
            {
                Player2Shield.GetComponent <Image>().color = Color.white;
            }
        }
    }
}
