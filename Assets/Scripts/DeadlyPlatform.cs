using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;

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
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);

        float objectWidth = boxCollider2D.bounds.size.x / 2;

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            FindObjectOfType<GameControl>().GameOver();
        }
    }
}
