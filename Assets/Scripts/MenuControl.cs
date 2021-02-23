using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] musicIcons;

    [SerializeField]
    Button musicButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Options.HaveISave() == false)
        {
            Options.EasyValueAssignment(1);
        }
        if (Options.MusicHaveISave() == false)
        {
            Options.MusicOnValueAssignment(1);
        }
        CheckTheMusicOption();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("Score");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Music()
    {
        if (Options.MusicOnValueRead() == 1)
        {
            Options.MusicOnValueAssignment(0);
            MusicControl.instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
        else
        {
            Options.MusicOnValueAssignment(1);
            MusicControl.instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }
    }

    void CheckTheMusicOption()
    {
        if (Options.MusicOnValueRead() == 1)
        {
            musicButton.image.sprite = musicIcons[1];
            MusicControl.instance.PlayMusic(true);
        }
        else
        {
            musicButton.image.sprite = musicIcons[0];
            MusicControl.instance.PlayMusic(false);
        }
    }
}
