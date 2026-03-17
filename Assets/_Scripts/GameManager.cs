using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    #region Singleton And Awake
    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    #endregion /Singleton And Awake

    public CardScriptSO[] cards;

    public Transform levelCompleteUI;

    private void Start()
    {
        MyEventsManager.instance.onGameWon += ShowLevelCompleteUI;
    }

    private void OnDestroy()
    {
        MyEventsManager.instance.onGameWon -= ShowLevelCompleteUI;
    }

    private void ShowLevelCompleteUI()
    {
        levelCompleteUI.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
}
