using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private TMP_Text[] bestScoreTexts;
    private UIManager uiManager;
    public void Start()
    {
        uiManager = UIManager.Instance();
        UpdateScoreLines();

        if(uiManager.playerName.Length > 0) { 
            inputField.text = uiManager.playerName;
        }

        quitButton.SetActive(uiManager.showQuitButton);
    }
    private void UpdateScoreLines()
    {
        for(var i = 0; i < uiManager.bestScores.Count; i++)
        {
            bestScoreTexts[i].text = (i+1).ToString() + ") " + uiManager.bestScores[i].asString();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void SetPlayerName(string text)
    {
        uiManager.SetPlayerName(inputField.textComponent.text);
    }
    public void QuitTheGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
