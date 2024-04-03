using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPreferences
{
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    public static string easyScore = "easyScore";
    public static string mediumScore = "mediumScore";
    public static string hardScore = "hardScore";
    
    public static string easyGold = "easyGold";
    public static string mediumGold = "mediumGold";
    public static string hardGold = "hardGold";

    public static string muteOpen = "muteOpen";

    public static void SelectedEasy(int easy)
    {
        PlayerPrefs.SetInt(PlayerPreferences.easy, easy);
    }

    public static int ReadEasy()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.easy);
    }

    public static void SelectedMedium(int medium)
    {
        PlayerPrefs.SetInt(PlayerPreferences.medium, medium);
    }

    public static int ReadMedium()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.medium);
    }

    public static void SelectedHard(int hard)
    {
        PlayerPrefs.SetInt(PlayerPreferences.hard, hard);
    }

    public static int ReadHard()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.hard);
    }

    //-Score
    public static void SelectedEasyScore(int easyScore)
    {
        PlayerPrefs.SetInt(PlayerPreferences.easyScore, easyScore);
    }

    public static int ReadEasyScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.easyScore);
    }

    public static void SelectedMediumScore(int mediumScore)
    {
        PlayerPrefs.SetInt(PlayerPreferences.mediumScore, mediumScore);
    }

    public static int ReadMediumScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.mediumScore);
    }

    public static void SelectedHardScore(int hardScore)
    {
        PlayerPrefs.SetInt(PlayerPreferences.hardScore, hardScore);
    }

    public static int ReadHardScore()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.hardScore);
    }

    //-Gold
    public static void SelectedEasyGold(int easyGold)
    {
        PlayerPrefs.SetInt(PlayerPreferences.easyGold, easyGold);
    }

    public static int ReadEasyGold()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.easyGold);
    }

    public static void SelectedMediumGold(int mediumGold)
    {
        PlayerPrefs.SetInt(PlayerPreferences.mediumGold, mediumGold);
    }

    public static int ReadMediumGold()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.mediumGold);
    }

    public static void SelectedHardGold(int hardGold)
    {
        PlayerPrefs.SetInt(PlayerPreferences.hardGold, hardGold);
    }

    public static int ReadHardGold()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.hardGold);
    }

    //-muteOpen
    public static void SelectedMuteOpen(int muteOpen)
    {
        PlayerPrefs.SetInt(PlayerPreferences.muteOpen, muteOpen);
    }

    public static int ReadMuteOpen()
    {
        return PlayerPrefs.GetInt(PlayerPreferences.muteOpen);
    }

    public static bool AnySave()
    {
        if (PlayerPrefs.HasKey(PlayerPreferences.easy) || 
            PlayerPrefs.HasKey(PlayerPreferences.medium) || PlayerPrefs.HasKey(PlayerPreferences.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool AnyMute()
    {
        if (PlayerPrefs.HasKey(PlayerPreferences.muteOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
