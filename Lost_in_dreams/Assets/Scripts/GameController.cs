using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   public int totalScore;
   public Text ScoreText;
   public string Nextlvl;
   public GameObject GameOver;
   public GameObject Congratulations;
   public static GameController instance;
   
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText() 
    {
        ScoreText.text = totalScore.ToString();
    }

    public void ShowCongratulations() 
    {
        Congratulations.SetActive(true);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(Nextlvl);
    }

    public void ShowGameOver() 
    {
        GameOver.SetActive(true);
    }

    public void RestartGame(string lvlName) 
    {
        SceneManager.LoadScene(lvlName);
    }
 }
