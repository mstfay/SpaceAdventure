using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    GameObject gold;

    public void GoldOn()
    {
        gold.SetActive(true);
    }
    public void GoldOff()
    {
        gold.SetActive(false);
    }
}
