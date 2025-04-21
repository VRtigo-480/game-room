using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class DartboardPointCalc : MonoBehaviour
{
    public int pointValue;
    public TextMeshProUGUI pointText;

    private int GetCurrentScore() {
        string scoreText = pointText.text;
        if (scoreText.Length > 0) {
            if (int.TryParse(scoreText, out int score)) {
                return score;
            }
        } else {
            Debug.LogError("Score text format is incorrect: " + scoreText);
        }
        return 0;
    }
}
