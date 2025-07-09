using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI m_Title;
    public Button m_QuitBtn;

    public static GameOver _instance;

    public static GameOver Instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = FindObjectOfType<GameOver>(true);
            }

            return _instance;
        }
    }

    void Start()
    {
        m_QuitBtn.onClick.AddListener(OnQuitClick);        
    }

    public void ShowOver(bool win)
    {
        gameObject.SetActive(true);
        if (win)
        {
            m_Title.text = "Game Win";
        }
        else
        {
            m_Title.text = "Game Lost";
        }
    }
    
    private void OnQuitClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
