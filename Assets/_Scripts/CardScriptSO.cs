using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/newCard")]
public class CardScriptSO : ScriptableObject
{
    public int cardID;
    public Sprite cardImage;
}
