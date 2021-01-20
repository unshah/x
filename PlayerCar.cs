using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public float sensitivity;
    public float maxPos = 2.4f;
    public float minPos = -2.4f;
    public int health   = 100;
    public int Money = 0;
    public int gameMoney;
    int totalMoney;
    public float fuel = 1f;
    public int carSpeed = 5;
    public float delayTimer = 0.0f;

    public GameObject player;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject[] playerCars;
    public GameObject carExplosion;


    private float ScreenWidth;
    private Rigidbody2D playerBody;
    private Vector3 touchPosition;
    private Vector3 direction;

    Vector3 position;


    // Start is called before the first frame update
  private void Start()
    {
        

        position = transform.position;
        //ScreenWidth = Screen.width;
        playerBody = GetComponent<Rigidbody2D>();
        
        if(PlayerPrefs.GetInt("carNumber") == 0)
        {
            playerCars[0].SetActive(true);
            playerCars[1].SetActive(false);
            playerCars[2].SetActive(false);
            playerCars[3].SetActive(false);
        }
        
        else if (PlayerPrefs.GetInt("carNumber") == 1)
        {
            playerCars[0].SetActive(false);
            playerCars[1].SetActive(true);
            playerCars[2].SetActive(false);
            playerCars[3].SetActive(false);
        }
        else if(PlayerPrefs.GetInt("carNumber") == 2)
        {
            playerCars[0].SetActive(false);
            playerCars[1].SetActive(false);
            playerCars[2].SetActive(true);
            playerCars[3].SetActive(false);
        }
        else if (PlayerPrefs.GetInt("carNumber") == 3)
        {
            playerCars[0].SetActive(false);
            playerCars[1].SetActive(false);
            playerCars[2].SetActive(false);
            playerCars[3].SetActive(true);
        }
        leftButton.SetActive(true);
        rightButton.SetActive(true);
    }

    // Update is called once per frame
   private void Update()
    {
        /*if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            playerBody.velocity = new Vector2(direction.x, direction.y) * sensitivity;

            if (touch.phase == TouchPhase.Ended)
            {
                playerBody.velocity = Vector2.zero;
            }
           
        }*/
        // position.x += Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime;

           position = transform.position;
           position.x = Mathf.Clamp(position.x, -2.7f, 2.7f);
           transform.position = position;

        if (delayTimer >0)
        {
            delayTimer -= Time.deltaTime;
        }
        if (delayTimer < 0)
        {
            carExplosion.SetActive(false);
            delayTimer = 0.0f;
        }
        fuel -= .001f;

        if (fuel == 0)
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas").GetComponent<UIScript>().gameOver();
        }
             
    }
    void FixedUpdate()
    {
        /*{
            #if UNITY_EDITOR
            movePlayer(Input.GetAxis("Horizontal"));
            #endif
        }

        private void movePlayer(float horizontalInput)
        {   //move player
            playerBody.AddForce(new Vector2(horizontalInput * sensitivity * Time.deltaTime, 0));
        }

        public void onLeft()
        {
            //position.x -= sensitivity * Time.deltaTime;
        }

        public void onRight()
        {
           //position.x += sensitivity * Time.deltaTime;
        }*/
    }

    public void moveRight()
    {
        playerBody.velocity = new Vector2(carSpeed, 0);
    }

    public void moveLeft()
    {
        playerBody.velocity = new Vector2(-carSpeed, 0);
    }

    public void setVelocityZero()
    {
        playerBody.velocity = Vector2.zero;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10;
            Destroy(collision.gameObject);
            carExplosion.SetActive(true);
            delayTimer = 0.5f;
        }

        else if (collision.gameObject.tag == "Police")
        {
            carExplosion.SetActive(true);
            delayTimer = 0.5f;
            health = 0;
            leftButton.SetActive(false);
            rightButton.SetActive(false);
           
            GameObject.Find("Canvas").GetComponent<UIScript>().gameOver();
        }

        else if (collision.gameObject.tag == "Money")
        {
            Money += 10;
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Player_Money", Money);
        }

        else if (collision.gameObject.tag == "Ambulance")
        {
            health += 20;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Fuel")
        {
            GameObject.Find("AI Spawn").GetComponent<EnemySpawn>().fuelTankEmpty = false;
            fuel += .8f;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "boost")
        {
            GameObject.Find("Player").GetComponent<MoveTrack>().speed -= 10.0f;
        }
    }

    public void gameCoins()
    {
       // gameMoney += PlayerPrefs.GetInt("Player_Money") ;
    }

    
   
        
    
}
