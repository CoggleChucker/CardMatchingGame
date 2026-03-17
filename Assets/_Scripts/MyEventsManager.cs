using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyEventsManager : MonoBehaviour
{
    #region Singleton And Awake
    public static MyEventsManager instance { get; private set; }
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

    public Action<Card> onCardClicked;
    public Action onGameWon;
    public Action onMatchSuccess;
    public Action onMatchFailed;
    public Action<int> onScoreChanged;
    public Action<int> onComboChanged;

    public void ActivateOnCardClicked(Card currentCard)
    {
        onCardClicked?.Invoke(currentCard);
    }

    public void ActivateOnGameWon()
    {
        onGameWon?.Invoke();
    }

    public void ActivateOnMatchSuccess()
    {
        onMatchSuccess?.Invoke();
    }

    public void ActivateOnMatchFailed()
    {
        onMatchFailed?.Invoke();
    }

    public void ActivateOnScoreChanged(int newScore)
    {
        onScoreChanged?.Invoke(newScore);
    }

    public void ActivateOnComboChanged(int currentCombo)
    {
        onComboChanged?.Invoke(currentCombo);
    }
}
