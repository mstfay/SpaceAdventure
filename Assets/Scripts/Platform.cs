using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;
    bool movement;
    float randomSpeed;

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
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        //randomSpeed = Random.Range(0.2f, 0.8f);
        if (Options.EasyValueRead() == 1)
        {
            randomSpeed = Random.Range(0.2f, 0.8f);
        }
        if (Options.MediumValueRead() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1.0f);
        }
        if (Options.HardValueRead() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);
        }

        float objectWidth = polygonCollider2D.bounds.size.x / 2;

        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    // Update is called once per frame
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
        if (collider.gameObject.tag == "Foots")
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJump();
        }
    }
}
