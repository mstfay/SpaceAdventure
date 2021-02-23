using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab;

    [SerializeField]
    GameObject fatalPlatformPrefab;

    [SerializeField]
    GameObject playerPrefab;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPosition;
    Vector2 playerPosition;

    [SerializeField]
    float distanceBetweenPlatforms;
    
    /// <summary>
    /// Kamera en üst platforma geldiğinde platformlar yeni pozisyonuna geçer.
    /// </summary>
    void Start()
    {
        PlatformProduce();
    }

    // Update is called once per frame
    void Update()
    {
        if (platforms[platforms.Count - 1].transform.position.y <
            Camera.main.transform.position.y + ScreenCalculator.instance.Height)
        {
            PlatformPlacement();
        }
    }

    /// <summary>
    /// Platform üretme kodları.
    /// </summary>
    void PlatformProduce()
    {
        platformPosition = new Vector2(0, 0);
        playerPosition = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
        GameObject firstPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
        player.transform.parent = firstPlatform.transform;
        platforms.Add(firstPlatform);
        NextPlatformPosition();
        firstPlatform.GetComponent<Platform>().Movement = true;
        firstPlatform.GetComponent<Gold>().GoldOff();

        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Movement = true;
            if (i % 2 == 0)
            {
                platform.GetComponent<Gold>().GoldOn();
            }
            NextPlatformPosition();
        }
        GameObject fatalPlatform = Instantiate(fatalPlatformPrefab, platformPosition, Quaternion.identity);
        fatalPlatform.GetComponent<FatalPlatform>().Movement = true;
        platforms.Add(fatalPlatform);
        NextPlatformPosition();
    }

    /// <summary>
    /// Ekrandan kaybolan platformları kameranın üstüne yerleştirme metodu.
    /// </summary>
    void PlatformPlacement()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPosition;
            // Yeniden konumlanan platformlardaki tag'ı platform olan oyun objelerinin 
            // üzerinde rastgele olarak altın beliriyor.
            if (platforms[i + 5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Gold>().GoldOff();
                float randomGold = Random.Range(0.0f, 1.0f);
                if (randomGold > 0.5f)
                {
                    platforms[i + 5].GetComponent<Gold>().GoldOn();
                }
            }
            NextPlatformPosition();
        }
    }
    void NextPlatformPosition()
    {
        platformPosition.y += distanceBetweenPlatforms;
        LinePlatform();
        
    }

    void RandomPlatform()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;
        }
    }

    bool yon = true;
    void LinePlatform()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (yon)
        {
            platformPosition.x = ScreenCalculator.instance.Width / 2;
            yon = false;
        }
        else
        {
            platformPosition.x = -ScreenCalculator.instance.Width / 2;
            yon = true;
        }
    }
}
