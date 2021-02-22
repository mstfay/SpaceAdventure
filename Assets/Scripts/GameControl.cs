using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject jumpButton;
    public GameObject signBoard;
    public GameObject menuButton;
    public GameObject slider;

    

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        UIOn();
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        UIOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UIOn()
    {
        joystick.SetActive(true);
        jumpButton.SetActive(true);
        signBoard.SetActive(true);
        menuButton.SetActive(true);
        slider.SetActive(true);
    }

    void UIOff()
    {
        joystick.SetActive(false);
        jumpButton.SetActive(false);
        signBoard.SetActive(false);
        menuButton.SetActive(false);
        slider.SetActive(false);
    }
}
