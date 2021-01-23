using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storeCanvas : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject Nem;
    public GameObject[] lockedText;
    public GameObject[] buyButton;
    public GameObject[] selectButton;
    public GameObject[] AS;
    //public GameObject[] carsNotAvailable;

    int jreepBought;
    int razorBought = 0;
    int waltorBought;
    int smutzBought;

    int razorsel;
    int jreepsel;
    int waltersel;
    int smutzsel;

    int i = 0;
    string carNumber;
    public int razorPrice;
    public int jreepPrice;
    public int walterPrice;
    public int smutzPrice;

    int jreepUHS = 200;
    int walterUHS = 300;
    int smutzUHS = 500;

    // Start is called before the first frame update
    void Start()
    {
        int HS = PlayerPrefs.GetInt("Player Score");

        PlayerPrefs.GetInt("razorBought");

        /*if (HS >= jreepUHS && PlayerPrefs.GetInt("jreepBought") == 0)
            {
                lockedText[0].SetActive(false);
                buyButton[0].SetActive(true);   
        }

        else if (HS >= walterUHS && PlayerPrefs.GetInt("waltorBought") == 0)
            {
                lockedText[1].SetActive(false);
                buyButton[1].SetActive(true);
        }

        else if (HS >= smutzUHS && PlayerPrefs.GetInt("smutzBought") == 0)
            {
                lockedText[2].SetActive(false);
                buyButton[2].SetActive(true);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Code for next button
   public void onNext()
    {
        if (i <=2 && i>=0)
        {
            cars[i].SetActive(false);
            i++;
            cars[i].SetActive(true);
        }
    }

    // Code for previous button
    public void onPrevious()
    {
        if (i >= 1 && i<=4)
        {
            cars[i].SetActive(false);
            i--;
            cars[i].SetActive(true);
        }
    }

    // Loads the scene 0
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Function used to buy the car 
    public void buyCarRazor ()
    {
        int coins = PlayerPrefs.GetInt("Player Money");
        if (coins > razorPrice)
        {
            coins = coins - razorPrice;
            PlayerPrefs.SetInt("Player Money", coins);
            buyButton[0].SetActive(false);
            selectButton[0].SetActive(true);
            PlayerPrefs.SetInt("razorsel", 0);
            PlayerPrefs.SetInt("razorBought", 1);
        }
        else
        {
            Nem.SetActive(true);
        }    
    }

    public void buyCarJreep()
    {
        int coins = PlayerPrefs.GetInt("Player Money");
        if (coins > jreepPrice && PlayerPrefs.GetInt("jreepBought") == 0)
        {
            coins = coins - jreepPrice;
            PlayerPrefs.SetInt("Player Money", coins);
            buyButton[1].SetActive(false);
            selectButton[1].SetActive(true);
            PlayerPrefs.SetInt("jreepsel", 0);
            PlayerPrefs.SetInt("jreepBought", 1);
        }
        else
        {
            Nem.SetActive(true);
        }
        
    }

    public void buyCarWalter()
    {
        int coins = PlayerPrefs.GetInt("Player Money");
        if (coins > walterPrice && PlayerPrefs.GetInt("walterBought")==0)
        {
            coins = coins - walterPrice;
            PlayerPrefs.SetInt("Player Money", coins);
            buyButton[2].SetActive(false);
            selectButton[2].SetActive(true);
            PlayerPrefs.SetInt("waltersel", 0);
            PlayerPrefs.SetInt("walterBought", 1);

        }
        else
        {
            Nem.SetActive(true);
        }
        
    }

    public void buyCarSmutz()
    {
        int coins = PlayerPrefs.GetInt("Player Money");
        if (coins > smutzPrice && PlayerPrefs.GetInt("smutzBought") == 0)
        {
            coins = coins - smutzPrice;
            PlayerPrefs.SetInt("Player Money", coins);
            buyButton[3].SetActive(false);
            selectButton[3].SetActive(true);
            PlayerPrefs.SetInt("smutzsel", 0);
            PlayerPrefs.SetInt("smutzBought", 1);
        }
        else
        {
            Nem.SetActive(true);
        }
        
    }
    public void selectRazor()
    {
        if (PlayerPrefs.GetInt("razorsel") >=0)
        {
            selectButton[0].SetActive(false);
            buyButton[0].SetActive(false);
            PlayerPrefs.SetInt("carNumber", 0);
            GameObject.Find("Player").GetComponent<PlayerCar>().playerCars[1].SetActive(true);
            AS[0].SetActive(true);
            PlayerPrefs.SetInt("razorsel", 1);
            PlayerPrefs.SetInt("jreepsel", 0);
            PlayerPrefs.SetInt("waltersel", 0);

            if (PlayerPrefs.GetInt("jreepBought") == 1)
            {
                AS[1].SetActive(false);
                selectButton[1].SetActive(true);
            }

            if (PlayerPrefs.GetInt("walterBought") == 1)
            {
                AS[2].SetActive(false);
                selectButton[2].SetActive(true);
            }
                
            if (PlayerPrefs.GetInt("smutzBought") == 1)
            {
                AS[3].SetActive(false);
                selectButton[3].SetActive(true);
            }
               
        }

    }

    public void selectJreep()
    {
        if (PlayerPrefs.GetInt("jreepsel") >= 0)
        {

            selectButton[1].SetActive(false);
            buyButton[1].SetActive(false);
            PlayerPrefs.SetInt("carNumber", 1);
            PlayerPrefs.SetInt("jreepsel", 2);
            PlayerPrefs.SetInt("razorsel", 1);
            PlayerPrefs.SetInt("waltersel", 1);
            AS[1].SetActive(true);

            if (PlayerPrefs.GetInt("razorBought") == 1)
            {
                AS[0].SetActive(false);
                selectButton[0].SetActive(true);
            }

            if (PlayerPrefs.GetInt("walterBought") == 1)
            {
                AS[2].SetActive(false);
                selectButton[2].SetActive(true);
            }

            if (PlayerPrefs.GetInt("smutzBought") == 1)
            {
                AS[3].SetActive(false);
                selectButton[3].SetActive(true);
            }
        }

    }

    public void selectWalter()
    {
        if (PlayerPrefs.GetInt("waltersel") >= 0)
        {
            selectButton[2].SetActive(false);
            buyButton[2].SetActive(false);
            PlayerPrefs.SetInt("carNumber", 2);
            PlayerPrefs.SetInt("waltersel", 1);
            AS[2].SetActive(true);

            if (PlayerPrefs.GetInt("jreepBought") == 1)
            {
                AS[1].SetActive(false);
                selectButton[1].SetActive(true);
            }

            if (PlayerPrefs.GetInt("razorBought") == 1)
            {
                AS[0].SetActive(false);
                selectButton[0].SetActive(true);
            }

            if (PlayerPrefs.GetInt("smutzBought") == 1)
            {
                AS[3].SetActive(false);
                selectButton[3].SetActive(true);
            }
        }

    }

    public void selectSmutz()
    {
        if (PlayerPrefs.GetInt("jreepsel") >= 0)
        {
            buyButton[3].SetActive(false);
            selectButton[3].SetActive(false);
            PlayerPrefs.SetInt("carNumber", 3);
            PlayerPrefs.SetInt("smutzsel", 1);
            AS[3].SetActive(true);

            if (PlayerPrefs.GetInt("jreepBought") == 1)
            {
                AS[1].SetActive(false);
                selectButton[1].SetActive(true);
            }

            if (PlayerPrefs.GetInt("walterBought") == 1)
            {
                AS[2].SetActive(false);
                selectButton[2].SetActive(true);
            }

            if (PlayerPrefs.GetInt("razorBought") == 1)
            {
                AS[0].SetActive(false);
                selectButton[0].SetActive(true);
            }
        }

    }
    public void oK()
    {
        Nem.SetActive(false);
    }
}
