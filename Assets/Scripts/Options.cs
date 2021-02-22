using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Options
{
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    public static void EasyValueAssignment(int easy)
    {
        PlayerPrefs.SetInt(Options.easy, easy);
    }

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
}
