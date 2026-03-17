using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Card : MonoBehaviour
{
    public int value;
    public Image spriteImage;
    public float hideTime = 1f;
    public float intialDelay = 3f;

    public void SetupCard(int value)
    {
        CardScriptSO cardScript = Array.Find(GameManager.instance.cards, Card => Card.cardID == value);
        this.value = value;
        spriteImage.sprite = cardScript.cardImage;
        spriteImage.enabled = false;
    }

    public void OnCardClicked()
    {
        GetComponent<Button>().interactable = false;
        spriteImage.enabled = true;
        MyEventsManager.instance.ActivateOnCardClicked(this);
    }

    public void UnturnCard()
    {
        StartCoroutine(HideCard(hideTime));
    }

    public void TurnCard()
    {
        spriteImage.enabled = true;
        GetComponent<Button>().interactable = false;
        StartCoroutine(HideCard(intialDelay));
    }

    public void MatchFound()
    {
       StartCoroutine(DeactivateCard());
    }

    IEnumerator HideCard(float hidingTime)
    {
        yield return new WaitForSeconds(hidingTime);
        spriteImage.enabled = false;
        GetComponent<Button>().interactable = true;
    }

    IEnumerator DeactivateCard()
    {
        yield return new WaitForSeconds(hideTime);
        gameObject.SetActive(false);
    }
}
