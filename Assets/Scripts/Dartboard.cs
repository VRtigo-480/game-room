using UnityEngine;
using TMPro;
using System.Collections.Generic;


public class Dartboard : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int totalScore = 0;

    public List<DartboardSection> boardSections;

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class DartboardSection : ScriptableObject {

    public int score;
    public GameObject sectionObject;

    public DartboardSection(int score, GameObject sectionObject) {
        this.score = score;
        this.sectionObject = sectionObject;
    }
}