using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMP_Text Text;


    public void UpdateScore(int score)
    {
        Text.text = $"Score: {score}";
    }
}
