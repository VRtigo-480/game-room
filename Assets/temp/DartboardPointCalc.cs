using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
public class DartboardPointCalc : MonoBehaviour
{
    public int pointValue;
    public TextMeshProUGUI pointText;


    public void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.CompareTag("Dart")) {
            int score = GetCurrentScore();
            score += pointValue;
            pointText.text = score.ToString();
        } else return;
    }

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
