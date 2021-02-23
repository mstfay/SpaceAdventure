using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    List<GameObject> planets = new List<GameObject>();

    
    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");
        for (int i = 1; i < 17; i++)
        {
            GameObject planet = new GameObject();
            SpriteRenderer sRenderer = planet.AddComponent<SpriteRenderer>();
            sRenderer.sprite = (Sprite)sprites[i];
            planet.name = sprites[i].name;
            sRenderer.sortingLayerName = "Planets";
            planets.Add(planet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
