using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public Text easyScore, easyGold, mediumScore, mediumGold, hardScore, hardGold;
    // Start is called before the first frame update
    void Start()
    {
        easyScore.text = "Score: " + Options.EasyScoreValueRead();
        easyGold.text = "gold" + Options.EasyGoldValueRead();
               
        mediumScore.text = "Score: " + Options.MediumScoreValueRead();
        mediumGold.text = " X " + Options.MediumGoldValueRead();

        hardScore.text = "Score: " + Options.HardScoreValueRead();
        hardGold.text = " X " + Options.HardGoldValueRead();
    }

   

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
