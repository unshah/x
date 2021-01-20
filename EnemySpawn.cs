using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    int CarNo ;
    public GameObject[] Enemy_Cars;
    public GameObject Coin;
    public GameObject Fuel;
    public bool fuelTankEmpty = false;

    float timer;
    float fuelTimer;
    public float delayTimer = .2f;
    public float delayFuelTimer = .5f;



    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {

            timer -= Time.deltaTime;
            {
                if (timer <= .1)
                {
                    Vector3 CoinPos = new Vector3(Random.Range(-2.50f, 2.5f), transform.position.y, transform.position.z);
                    Instantiate(Coin, CoinPos, transform.rotation);
                }
            }

            if (timer <= 0)
            {

                Vector3 CarPos = new Vector3(Random.Range(-2.50f, 2.5f), transform.position.y, transform.position.z);
                CarNo = Random.Range(0, 8);
                Instantiate(Enemy_Cars[CarNo], CarPos, transform.rotation);
                timer = delayTimer;
            }

            if (GameObject.Find("Player").GetComponent<PlayerCar>().fuel < 0.2 && fuelTankEmpty == false)
            {
                Vector3 CoinPos = new Vector3(Random.Range(-2.50f, 2.5f), transform.position.y, transform.position.z);
                Instantiate(Fuel, CoinPos, transform.rotation);
                fuelTankEmpty = true;
            }

        }

    }
}

