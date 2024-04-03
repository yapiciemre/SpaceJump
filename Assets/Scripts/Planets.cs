using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();
    List<GameObject> usedPlanets = new List<GameObject>();

    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Planets");

        for (int i = 1; i < 13; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer sRenderer = planet.AddComponent<SpriteRenderer>();
            sRenderer.sprite = (Sprite)sprites[i];

            Color spriteColor = sRenderer.color; // Gezegenlerin parlaklýgýný kýsmak için biraz.
            spriteColor.a = 0.2f; // Gezegenlerin parlaklýgýný kýsmak için biraz. ALFA DEGERI. 0.2f
            sRenderer.color = spriteColor; // Gezegenlerin parlaklýgýný kýsmak için biraz.

            planet.name = sprites[i].name;
            sRenderer.sortingLayerName = "Planet";
            Vector2 position = planet.transform.position;
            position.x = -10;
            planet.transform.position = position;
            planets.Add(planet);
        }
    }

    public void MakePlanet(float refY)
    {
        float height = ScreenCalculator.Instance.Height;
        float width = ScreenCalculator.Instance.Width;

        // 1.Bölge
        float xValue1 = Random.Range(0.0f, width);
        float yValue1 = Random.Range(refY, refY + height);
        GameObject planet1 = RandomPlanets();
        planet1.transform.position = new Vector2(xValue1, yValue1);

        // 2.Bölge
        float xValue2 = Random.Range(-width, 0.0f);
        float yValue2 = Random.Range(refY, refY + height);
        GameObject planet2 = RandomPlanets();
        planet2.transform.position = new Vector2(xValue2, yValue2);

        // 3.Bölge
        float xValue3 = Random.Range(-width, 0.0f);
        float yValue3 = Random.Range(refY - height, refY);
        GameObject planet3 = RandomPlanets();
        planet3.transform.position = new Vector2(xValue3, yValue3);

        // 4.Bölge
        float xValue4 = Random.Range(0.0f, width);
        float yValue4 = Random.Range(refY - height, refY);
        GameObject planet4 = RandomPlanets();
        planet4.transform.position = new Vector2(xValue4, yValue4);
    }

    GameObject RandomPlanets()
    {
        if (planets.Count > 0)
        {
            int random;
            if (planets.Count == 1)
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, planets.Count - 1);
            }
            
            GameObject planet = planets[random];
            planets.Remove(planet);
            usedPlanets.Add(planet);
            return planet;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planets.Add(usedPlanets[i]);
            }
            usedPlanets.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject planet = planets[random];
            planets.Remove(planet);
            usedPlanets.Add(planet);
            return planet;
        }
    }
}
