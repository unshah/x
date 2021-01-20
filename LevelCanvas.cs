using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour
{

    public GameObject[] levels;
    //public GameObject[] carsNotAvailable;

    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void onNext()
    {
        if (i <=0 && i>=0)
        {
            levels[i].SetActive(false);
            i++;
            levels[i].SetActive(true);
        }
    }

    public void onPrevious()
    {
        if (i > 0 && i<=1)
        {
            levels[i].SetActive(false);
            i--;
            levels[i].SetActive(true);
        }
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadMorning()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void loadNight()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
}
