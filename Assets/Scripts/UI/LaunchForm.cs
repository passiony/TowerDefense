using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchForm : MonoBehaviour
{
    public Button startBtn;
    public Button quitBtn;

    void Start()
    {
        startBtn.onClick.AddListener(() => { SceneManager.LoadScene("LevelSelect"); });
        quitBtn.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }
}