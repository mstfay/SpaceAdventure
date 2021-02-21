using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Foots")
        {
            GetComponentInParent<Gold>().GoldOff();
            FindObjectOfType<Score>().CollectGold();
        }
        
    }
}
