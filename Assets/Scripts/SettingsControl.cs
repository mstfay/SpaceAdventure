using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;
    // Start is called before the first frame update
    void Start()
    {
        if(Options.EasyValueRead() == 1)
        {
            easyButton.interactable = false;
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }
        if (Options.MediumValueRead() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }
        if (Options.HardValueRead() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
    }

    
    public void OptionSelected(string level)
    {
        switch (level)
        {
            case "easy":
                Options.EasyValueAssignment(1);
                Options.MediumValueAssignment(0);
                Options.HardValueAssignment(0);
                easyButton.interactable = false;
                mediumButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "medium":
                Options.EasyValueAssignment(0);
                Options.MediumValueAssignment(1);
                Options.HardValueAssignment(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                Options.EasyValueAssignment(0);
                Options.MediumValueAssignment(0);
                Options.HardValueAssignment(1);
                easyButton.interactable = true;
                mediumButton.interactable = true;
                hardButton.interactable = false;
                break;
            default:
                break;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
