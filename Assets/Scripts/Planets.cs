using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();
    List<GameObject> usingPlanets = new List<GameObject>();

    
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");
        for (int i = 1; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer sRenderer = planet.AddComponent<SpriteRenderer>();
            sRenderer.sprite = (Sprite)sprites[i];
            Color spriteColor = sRenderer.color;
            spriteColor.a = 0.75f;
            sRenderer.color = spriteColor;
            planet.name = sprites[i].name;
            sRenderer.sortingLayerName = "Planets";
            Vector2 position = planet.transform.position;
            position.x = -10;
            planet.transform.position = position;
            planets.Add(planet);
        }
    }

    public void PlacePlanet(float refY)
    {
        float height = ScreenCalculator.instance.Height;
        float width = ScreenCalculator.instance.Width;

        //1. Bölge
        float xValue1 = Random.Range(0.0f, width);
        float yValue1 = Random.Range(refY, refY + height);
        GameObject planet1 = RandomPlanet();
        planet1.transform.position = new Vector2(xValue1, yValue1);

        //2. Bölge
        float xValue2 = Random.Range(-width, 0.0f);
        float yValue2 = Random.Range(refY, refY + height);
        GameObject planet2= RandomPlanet();
        planet2.transform.position = new Vector2(xValue2, yValue2);

        //3. Bölge
        float xValue3 = Random.Range(-width, 0.0f);
        float yValue3 = Random.Range(refY - height, refY);
        GameObject planet3 = RandomPlanet();
        planet3.transform.position = new Vector2(xValue3, yValue3);

        //4. Bölge
        float xValue4 = Random.Range(0.0f, width);
        float yValue4 = Random.Range(refY - height, refY);
        GameObject planet4 = RandomPlanet();
        planet4.transform.position = new Vector2(xValue4, yValue4);

    }

    GameObject RandomPlanet()
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
            usingPlanets.Add(planet);
            return planet;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                planets.Add(usingPlanets[i]);
            }
            usingPlanets.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject planet = planets[random];
            planets.Remove(planet);
            usingPlanets.Add(planet);
            return planet;
        }
    }
}
