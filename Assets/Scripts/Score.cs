using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    int score;
    int highScore;

    int gold;
    int highGold;

    bool collectScore = true;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text goldText;

    [SerializeField]
    Text gameOverScoreText;

    [SerializeField]
    Text GameOverGoldText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = " X " + gold;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectScore)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Score: " + score;
        }        
    }

    public void CollectGold()
    {
        gold++;
        goldText.text = " X " + gold;
    }

    public void GameOver()
    {
        if (Options.EasyValueRead() == 1)
        {
            highScore = Options.EasyScoreValueRead();
            highGold = Options.EasyGoldValueRead();
            if (score > highScore)
            {
                Options.EasyScoreValueAssignment(score);
            }
            if (gold > highGold)
            {
                Options.EasyGoldValueAssignment(gold);
            }
        }

        if (Options.MediumValueRead() == 1)
        {
            highScore = Options.MediumScoreValueRead();
            highGold = Options.MediumGoldValueRead();
            if (score > highScore)
            {
                Options.MediumScoreValueAssignment(score);
            }
            if (gold > highGold)
            {
                Options.MediumGoldValueAssignment(gold);
            }
        }

        if (Options.HardValueRead() == 1)
        {
            highScore = Options.HardScoreValueRead();
            highGold = Options.HardGoldValueRead();
            if (score > highScore)
            {
                Options.HardScoreValueAssignment(score);
            }
            if (gold > highGold)
            {
                Options.HardGoldValueAssignment(gold);
            }
        }
        collectScore = false;
        gameOverScoreText.text = "Score: " + score;
        GameOverGoldText.text = " X " + gold;
    }
}
