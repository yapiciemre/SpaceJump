using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{
    public TextMeshProUGUI easyScore, easyGold, mediumScore, mediumGold, hardScore, hardGold;

    void Start()
    {
        easyScore.text = "Score: " + PlayerPreferences.ReadEasyScore();
        easyGold.text = " x " + PlayerPreferences.ReadEasyGold();

        mediumScore.text = "Score: " + PlayerPreferences.ReadMediumScore();
        mediumGold.text = " x " + PlayerPreferences.ReadMediumGold();

        hardScore.text = "Score: " + PlayerPreferences.ReadHardScore();
        hardGold.text = " x " + PlayerPreferences.ReadHardGold();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
