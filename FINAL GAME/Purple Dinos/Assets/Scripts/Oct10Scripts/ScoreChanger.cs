using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
{
    public TMP_Text HUDText;

    public void changeHealth(int amount)
    {
        HUDText.text = "Boo Boo: " + amount;
    }
}
