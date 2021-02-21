using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score;

    int gold;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = " X " + gold;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)Camera.main.transform.position.y;
        scoreText.text = "Score: " + score;
    }

    public void CollectGold()
    {
        gold++;
        goldText.text = " X " + gold;
    }
}
