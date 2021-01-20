using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text coinText;
    int coins;
    public int playerMoney;
    public int highScore;
    int previousHS;
    int previousCoins;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        previousHS = highScore;

        highScore = PlayerPrefs.GetInt("Player Score");
        highScoreText.text ="High Score: " + highScore.ToString();

        coins = PlayerPrefs.GetInt("Player Money");
        coinText.text = "Coins: " + coins.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void play()
    {
        SceneManager.LoadScene(1);  
    }
    public void store()
    {
        SceneManager.LoadScene(2);
    }
}
