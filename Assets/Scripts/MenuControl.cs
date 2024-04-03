using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] muteIcon = default;

    [SerializeField]
    Button muteButton = default;

    void Start()
    {
        if (PlayerPreferences.AnySave() == false)
        {
            PlayerPreferences.SelectedEasy(1);
        }

        if (PlayerPreferences.AnyMute() == false)
        {
            PlayerPreferences.SelectedMuteOpen(1);
        }

        CheckMuteOptions();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("High Score");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Mute()
    {
        if (PlayerPreferences.ReadMuteOpen() == 1)
        {
            PlayerPreferences.SelectedMuteOpen(0);
            MuteControl.instance.PlayMusic(false);
            muteButton.image.sprite = muteIcon[0];
        }
        else
        {
            PlayerPreferences.SelectedMuteOpen(1);
            MuteControl.instance.PlayMusic(true);
            muteButton.image.sprite = muteIcon[1];
        }
    }

    void CheckMuteOptions()
    {
        if (PlayerPreferences.ReadMuteOpen() == 1)
        {
            muteButton.image.sprite = muteIcon[1];
            MuteControl.instance.PlayMusic(true);
        }
        else
        {
            muteButton.image.sprite = muteIcon[0];
            MuteControl.instance.PlayMusic(false);
        }
    }
}
