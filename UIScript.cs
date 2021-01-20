using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public Text moneyText;
    public Text healthText;

    public Scrollbar fuelBar;

    public GameObject GameOver;
    public GameObject GamePause;

    public Text scoreText;
    public Text goScore;

    public int gameScore = 0;
    public int levelCoin = 0;
    public int gcoins;


    // Start is called before the first frame update
    void Start()
    {
        gcoins = PlayerPrefs.GetInt("Player Money");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            gameScore += 1;
        }

        levelCoin = GameObject.Find("Player").GetComponent<PlayerCar>().Money;

        moneyText.text = "Money: " + levelCoin;

        healthText.text = "Health: " + GameObject.Find("Player").GetComponent<PlayerCar>().health;

        scoreText.text = "Score: " + gameScore;

        fuelBar.size = GameObject.Find("Player").GetComponent<PlayerCar>().fuel;

        goScore.text = "Score : " + gameScore;

        if (GameObject.Find("Player").GetComponent<PlayerCar>().health == 0)
        {
            GameObject.Find("Player").GetComponent<PlayerCar>().leftButton.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerCar>().rightButton.SetActive(false);
            // Time.timeScale = 0;
            gameOver();
        }

    }

    public class pauseButton 
        {
            void onPause()
            {
            Time.timeScale = 0;
            }
        }

    public void gameOver()
    {
        if (gameScore > PlayerPrefs.GetInt("Player Score"))
        {
            PlayerPrefs.SetInt("Player Score", gameScore);
        }

        GameObject.Find("Player").GetComponent<PlayerCar>().player.SetActive(false);
        GameOver.SetActive(true);
       

        gcoins += levelCoin;

        PlayerPrefs.SetInt("Player Money", gcoins); 
        
        Time.timeScale = 0;
       

    }

    public void pause()
    {
        GameObject.Find("Player").GetComponent<PlayerCar>().leftButton.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerCar>().rightButton.SetActive(false);
        Time.timeScale = 0;
        GamePause.SetActive(true);
    }

    public void resume()
    {
        GameObject.Find("Player").GetComponent<PlayerCar>().leftButton.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerCar>().rightButton.SetActive(true);
        GamePause.SetActive(false);
        Time.timeScale = 1;
    }

    public void mainLoad()
    {
        SceneManager.LoadScene(0);
    }
    
}   


