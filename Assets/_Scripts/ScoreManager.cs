using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton And Awake
    public static ScoreManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion /Singleton And Awake

    public int scorePerMatch = 100;
    private int currentScore = 0;
    private int currentCombo = 1;


    // Start is called before the first frame update
    void Start()
    {
        MyEventsManager.instance.onMatchSuccess += MatchSuccess;
        MyEventsManager.instance.onMatchFailed += MatchFailed;
    }

    private void AddScore()
    {
        currentScore += scorePerMatch * currentCombo;
        MyEventsManager.instance.ActivateOnScoreChanged(currentScore);
    }

    private void OnDestroy()
    {
        MyEventsManager.instance.onMatchSuccess -= MatchSuccess;
        MyEventsManager.instance.onMatchFailed -= MatchFailed;
    }

    private void MatchFailed()
    {
        ResetCombo();
    }

    private void MatchSuccess()
    {
        AddScore();
        IncrementCombo();
    }

    private void IncrementCombo()
    {
        currentCombo++;
        MyEventsManager.instance.ActivateOnComboChanged(currentCombo);
    }
    public void ResetCombo()
    {
        currentCombo = 1;
        MyEventsManager.instance.ActivateOnComboChanged(currentCombo);
    }
}
