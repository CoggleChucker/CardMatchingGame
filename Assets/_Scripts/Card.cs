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

    public void SetupCard(int value)
    {
        CardScriptSO cardScript = Array.Find(GameManager.instance.cards, Card => Card.cardID == value);
        spriteImage.sprite = cardScript.cardImage;
        spriteImage.enabled = false;
    }

    public void OnCardClicked()
    {
        GetComponent<Button>().interactable = false;
        spriteImage.enabled = true;
        StartCoroutine(HideCard());
    }

    IEnumerator HideCard()
    {
        yield return new WaitForSeconds(hideTime);
        spriteImage.enabled = false;
        GetComponent<Button>().interactable = true;
    }
}
