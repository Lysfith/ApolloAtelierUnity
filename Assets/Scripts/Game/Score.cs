using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Composant qui affiche le score du joueur
/// </summary>
public class Score : MonoBehaviour
{
    public TMP_Text Text;


    public void UpdateScore(int score)
    {
        Text.text = $"Score: {score}";
    }
}
