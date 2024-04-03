using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject deadlyPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPosition;
    Vector2 playerPosition;

    [SerializeField]
    float distanceBetweenPlatform = default;

    void Start()
    {
        MakePlatform();
    }

    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y < 
            Camera.main.transform.position.y + ScreenCalculator.Instance.Width)
        {
            PlacePlatform();
        }
    }

    void MakePlatform()
    {
        platformPosition = new Vector2 (0, 0);
        playerPosition = new Vector2 (0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);

        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Movement = true;

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add (platform);
            platform.GetComponent<Platform>().Movement = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Gold>().OpenGold();
            }
            NextPlatformPosition();
        }

        GameObject deadlyPlatform = Instantiate(deadlyPlatformPrefab, platformPosition, Quaternion.identity);
        deadlyPlatform.GetComponent<DeadlyPlatform>().Movement = true;
        platforms.Add(deadlyPlatform);
        NextPlatformPosition(); 
    }

    void PlacePlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;

            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Gold>().CloseGold();
                float randomGold = Random.Range(0.0f, 1.0f);
                if (randomGold > 0.5f) // Daha az altýn için sayýyý büyült.
                {
                    platforms[i + 5].GetComponent<Gold>().OpenGold();
                }
            }

            NextPlatformPosition();

        }
    }

    void NextPlatformPosition()
    {
        platformPosition.y += distanceBetweenPlatform;
        /// SequentialPosition();
        MixedPosition();
    }

    void MixedPosition()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
        }
    }

    bool direction = true;

    void SequentialPosition()
    {
        if (direction)
        {
            platformPosition.x = ScreenCalculator.Instance.Width / 2;
            direction = false;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.Instance.Width / 2;
            direction = true;
        }
    }
}
