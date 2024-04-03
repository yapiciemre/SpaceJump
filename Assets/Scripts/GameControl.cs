using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject joystick;
    public GameObject jumpingButton;
    public GameObject sign;
    public GameObject menuButton;
    public GameObject slider;

    void Start()
    {
        gameOverPanel.SetActive(false);
        OpenUI();
    }

    public void GameOver()
    {
        FindObjectOfType<SoundEffectControl>().GameOverAudio();
        gameOverPanel.SetActive(true);
        FindObjectOfType<Score>().GameOver();
        FindObjectOfType<PlayerMovement>().GameOver();
        FindObjectOfType<CameraMovement>().GameOver();
        CloseUI();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    void OpenUI()
    {
        joystick.SetActive(true);
        jumpingButton.SetActive(true);
        sign.SetActive(true);
        menuButton.SetActive(true);
        slider.SetActive(true);
    }

    void CloseUI()
    {
        joystick.SetActive(false);
        jumpingButton.SetActive(false);
        sign.SetActive(false);
        menuButton.SetActive(false);
        slider.SetActive(false);
    }
}
