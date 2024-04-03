using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementControl : MonoBehaviour
{
    float backgroundLocation;
    float distance = 10.24f; //Mesafe

    void Start()
    {
        backgroundLocation = transform.position.y;
        FindObjectOfType<Planets>().MakePlanet(backgroundLocation);
    }

    void Update()
    {
        if (backgroundLocation + distance < Camera.main.transform.position.y)
        {
            placeBackground();
        }
    }

    void placeBackground() //Arka Plan Yerleþtir.
    {
        backgroundLocation += (distance * 2);
        FindObjectOfType<Planets>().MakePlanet(backgroundLocation);
        Vector2 newPosition = new Vector2(0, backgroundLocation);
        transform.position = newPosition;
    }
}