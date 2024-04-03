using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;

    int gold;
    int highGold;

    bool gainScore = true;
    
    [SerializeField]
    TextMeshProUGUI scoreText = default;

    [SerializeField]
    TextMeshProUGUI goldText = default;

    [SerializeField]
    TextMeshProUGUI gameOverScoreText = default;

    [SerializeField]
    TextMeshProUGUI gameOverGoldText = default;

    void Start()
    {
        goldText.text = " x " + gold;
    }

    void Update()
    {
        if (gainScore)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Score: " + score;
        }
    }

    public void GainGold()
    {
        FindObjectOfType<SoundEffectControl>().GoldAudio();
        gold++;
        goldText.text = " x " + gold;
    }

    public void GameOver()
    {
        if (PlayerPreferences.ReadEasy() == 1)
        {
            highScore = PlayerPreferences.ReadEasyScore();
            highGold = PlayerPreferences.ReadEasyGold();
            if (score > highScore)
            {
                PlayerPreferences.SelectedEasyScore(score);
            }
            if (gold > highGold)
            {
                PlayerPreferences.SelectedEasyGold(gold);
            }
        }

        if (PlayerPreferences.ReadMedium() == 1)
        {
            highScore = PlayerPreferences.ReadMediumScore();
            highGold = PlayerPreferences.ReadMediumGold();
            if (score > highScore)
            {
                PlayerPreferences.SelectedMediumScore(score);
            }
            if (gold > highGold)
            {
                PlayerPreferences.SelectedMediumGold(gold);
            }
        }

        if (PlayerPreferences.ReadHard() == 1)
        {
            highScore = PlayerPreferences.ReadHardScore();
            highGold = PlayerPreferences.ReadHardGold();
            if (score > highScore)
            {
                PlayerPreferences.SelectedHardScore(score);
            }
            if (gold > highGold)
            {
                PlayerPreferences.SelectedHardGold(gold);
            }
        }

        gainScore = false;
        gameOverScoreText.text = "Score: " + score;
        gameOverGoldText.text = " x " + gold;
    }
}
