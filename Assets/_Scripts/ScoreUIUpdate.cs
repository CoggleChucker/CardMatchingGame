using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIUpdate : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    // Start is called before the first frame update
    void Start()
    {
        MyEventsManager.instance.onScoreChanged += UpdateScoreText;
        MyEventsManager.instance.onComboChanged += UpdateComboText;
    }

    private void OnDestroy()
    {
        MyEventsManager.instance.onScoreChanged -= UpdateScoreText;
        MyEventsManager.instance.onComboChanged -= UpdateComboText;
    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text= newScore.ToString();
    }

    private void UpdateComboText(int newCombo)
    {
        comboText.text = "x" + newCombo.ToString();
    }
}
