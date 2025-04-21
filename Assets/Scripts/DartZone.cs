using UnityEngine;

public class DartZone : MonoBehaviour {

  public int pointValue;
  public Dartboard dartboard;
  public void IncrementScore() {
    dartboard.pointText.text = $"{GetCurrentScore() + pointValue}";
  }

  private int GetCurrentScore() {
        string scoreText = dartboard.pointText.text;
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