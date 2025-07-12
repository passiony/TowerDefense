using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 设置页面
/// </summary>
public class SettingForm : MonoBehaviour
{
    public Button resumeBtn;
    public Button quitBtn;
    
    void Start()
    {
        resumeBtn.onClick.AddListener(OnResumeClick);        
        quitBtn.onClick.AddListener(OnQuitClick);        
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void OnResumeClick()
    {
        gameObject.SetActive(false);
    }
    
    private void OnQuitClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }

}
