using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed;
    float acceleration; //Hýzlanma
    float maxSpeed;

    bool movement; //Hareket

    void Start()
    {
        movement = true;

        if (PlayerPreferences.ReadEasy() == 1)
        {
            speed = 0.3f;
            acceleration = 0.03f;
            maxSpeed = 1.5f;
        }

        if (PlayerPreferences.ReadMedium() == 1)
        {
            speed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 2.0f;
        }

        if (PlayerPreferences.ReadHard() == 1)
        {
            speed = 0.8f;
            acceleration = 0.08f;
            maxSpeed = 2.5f;
        }

    }

    void Update()
    {
        if (movement)
        {
            moveToCam();
        }
    }

    void moveToCam() //Kamerayý Hareket Ettir.
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void GameOver()
    {
        movement = false;
    }
}