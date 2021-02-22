using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Options
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

    public static string musicOn = "musicOn";

    public static void EasyValueAssignment(int easy)
    {
        PlayerPrefs.SetInt(Options.easy, easy);
    }





    /// <summary>
    /// ZORLUK DERECESİ KAYDETMEK İCİN OLUSTURULAN BÖLÜM
    /// </summary>
    /// <returns></returns>
    public static int EasyValueRead()
    {
        return PlayerPrefs.GetInt(Options.easy);
    }

    public static void MediumValueAssignment(int medium)
    {
        PlayerPrefs.SetInt(Options.medium, medium);
    }

    public static int MediumValueRead()
    {
        return PlayerPrefs.GetInt(Options.medium);
    }

    public static void HardValueAssignment(int hard)
    {
        PlayerPrefs.SetInt(Options.hard, hard);
    }

    public static int HardValueRead()
    {
        return PlayerPrefs.GetInt(Options.hard);
    }



    /// <summary>
    /// PUAN KAYDETMEK İCİN KULLANILAN KISIM
    /// </summary>
    /// <param name="easy"></param>
    public static void EasyScoreValueAssignment(int easyScore)
    {
        PlayerPrefs.SetInt(Options.easyScore, easyScore);
    }

    public static int EasyScoreValueRead()
    {
        return PlayerPrefs.GetInt(Options.easyScore);
    }

    public static void MediumScoreValueAssignment(int mediumScore)
    {
        PlayerPrefs.SetInt(Options.mediumScore, mediumScore);
    }

    public static int MediumScoreValueRead()
    {
        return PlayerPrefs.GetInt(Options.mediumScore);
    }

    public static void HardScoreValueAssignment(int hardScore)
    {
        PlayerPrefs.SetInt(Options.hardScore, hardScore);
    }

    public static int HardScoreValueRead()
    {
        return PlayerPrefs.GetInt(Options.hardScore);
    }




    /// <summary>
    /// ZORLUK DERECESINDE TOPLANAN  ALTINLARI KAYDEDER.
    /// </summary>
    /// <param name="easyScore"></param>
    public static void EasyGoldValueAssignment(int easyGold)
    {
        PlayerPrefs.SetInt(Options.easyGold, easyGold);
    }

    public static int EasyGoldValueRead()
    {
        return PlayerPrefs.GetInt(Options.easyGold);
    }

    public static void MediumGoldValueAssignment(int mediumGold)
    {
        PlayerPrefs.SetInt(Options.mediumGold, mediumGold);
    }

    public static int MediumGoldValueRead()
    {
        return PlayerPrefs.GetInt(Options.mediumGold);
    }

    public static void HardGoldValueAssignment(int hardGold)
    {
        PlayerPrefs.SetInt(Options.hardGold, hardGold);
    }

    public static int HardGoldValueRead()
    {
        return PlayerPrefs.GetInt(Options.hardGold);
    }

    public static void MusicOnValueAssignment(int musicOn)
    {
        PlayerPrefs.SetInt(Options.musicOn, musicOn);
    }

    public static int MusicOnValueRead()
    {
        return PlayerPrefs.GetInt(Options.musicOn);
    }



    /// <summary>
    /// Zorluk derecesi kayıt var mı sorgusu yapar.
    /// </summary>
    /// <returns></returns>
    public static bool HaveISave()
    {
        if(PlayerPrefs.HasKey(Options.easy) || PlayerPrefs.HasKey(Options.medium) || PlayerPrefs.HasKey(Options.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Müzik ile alakalı olarak bir kayıt var mı sorgusu yapar.
    /// </summary>
    /// <returns></returns>
    public static bool MusicHaveISave()
    {
        if (PlayerPrefs.HasKey(Options.musicOn))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
