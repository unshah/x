using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Car : MonoBehaviour
{
    public float speed = 2 ;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Money")
        {
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
