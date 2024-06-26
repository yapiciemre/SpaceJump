using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Feet")
        {
            GetComponentInParent<Gold>().CloseGold();
            FindObjectOfType<Score>().GainGold();
        }
    }
}
