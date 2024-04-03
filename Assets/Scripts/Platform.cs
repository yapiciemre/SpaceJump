using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    float randomSpeed;
    bool movement;

    float min, max;

    public bool Movement 
    {  
        get 
        { 
            return movement; 
        } 
        set 
        {  
            movement = value; 
        } 
    }

    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();


        // Platform hýzlarý seviyeye göre deðiþiklik kýsmý.(Kafana göre ayarla düzgün olsun)
        if (PlayerPreferences.ReadEasy() == 1)
        {
            randomSpeed = Random.Range(0.2f, 0.8f);
        }

        if (PlayerPreferences.ReadMedium() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1.0f);
        }

        if (PlayerPreferences.ReadHard() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);
        }

        float objectWidth = polygonCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.Instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.Instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    void Update()
    {
        if (movement)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Feet")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJump();
        }
    }
}
