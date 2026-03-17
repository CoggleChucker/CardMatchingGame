using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    #region Singleton And Awake
    public static MatchManager instance { get; private set; }
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

    private Card selectedCard = null;
    private int maxMatchNumber = 0;

    public AudioSource matchSuccessSound;
    public AudioSource matchFailedSound;
    public AudioSource gameWonSound;

    // Start is called before the first frame update
    void Start()
    {
        MyEventsManager.instance.onCardClicked += CheckForMatch;
    }

    private void OnDestroy()
    {
        MyEventsManager.instance.onCardClicked -= CheckForMatch;
    }
    private void CheckForMatch(Card card)
    {
        if (selectedCard == null)
        {
            selectedCard = card;
        }
        else
        {
            if(card.value == selectedCard.value)
            {
                Debug.Log("Match!");
                card.MatchFound();
                selectedCard.MatchFound();
                selectedCard = null;
                matchSuccessSound.Play();
                MyEventsManager.instance.ActivateOnMatchSuccess();
                maxMatchNumber--;
                if (maxMatchNumber <= 0)
                {
                    Debug.Log("Game Won!"); 
                    gameWonSound.Play();
                    MyEventsManager.instance.ActivateOnGameWon();
                }
            }

            else
            {
                Debug.Log("Not a match!");
                card.UnturnCard();
                selectedCard.UnturnCard();
                selectedCard = null;
                matchFailedSound.Play();
                MyEventsManager.instance.ActivateOnMatchFailed();
            }
        }
    }

    public void SetMaxMatchNumber(int maxMatches)
    {
        maxMatchNumber = maxMatches;
    }
}
