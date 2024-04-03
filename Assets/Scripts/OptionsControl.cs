using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsControl : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton;

    void Start()
    {
        if (PlayerPreferences.ReadEasy() == 1)
        {
            easyButton.interactable = false;
            mediumButton.interactable = true;
            hardButton.interactable = true;
        }
        if (PlayerPreferences.ReadMedium() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = false;
            hardButton.interactable = true;
        }
        if (PlayerPreferences.ReadHard() == 1)
        {
            easyButton.interactable = true;
            mediumButton.interactable = true;
            hardButton.interactable = false;
        }
    }

    public void SelectedLevelButton(string level)
    {
        switch (level)
        {
            case "easy":
                PlayerPreferences.SelectedEasy(1);
                PlayerPreferences.SelectedMedium(0);
                PlayerPreferences.SelectedHard(0);
                easyButton.interactable = false;
                mediumButton.interactable = true;
                hardButton.interactable = true;
                break;

            case "medium":
                PlayerPreferences.SelectedEasy(0);
                PlayerPreferences.SelectedMedium(1);
                PlayerPreferences.SelectedHard(0);
                easyButton.interactable = true;
                mediumButton.interactable = false;
                hardButton.interactable = true;
                break;

            case "hard":
                PlayerPreferences.SelectedEasy(0);
                PlayerPreferences.SelectedMedium(0);
                PlayerPreferences.SelectedHard(1);
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
