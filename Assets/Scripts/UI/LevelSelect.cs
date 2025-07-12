using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 关卡选择
/// </summary>
public class LevelSelect : MonoBehaviour
{
    public Button backBtn;
    public Transform ScrollContent;
    public GameObject LevelPrefab;
    public int LevelCount = 20;
    
    void Start()
    {
        backBtn.onClick.AddListener(OnBackClick);
        for (int i = 0; i < LevelCount; i++)
        {
            int index = i+1;
            var go = Instantiate(LevelPrefab, ScrollContent);
            go.SetActive(true);
            go.GetComponentInChildren<TextMeshProUGUI>().text = $"Level {index}";
            go.GetComponent<Button>().onClick.AddListener(() =>
            {
                var levelName = "Level" + index;
                SceneManager.LoadScene(levelName);
            });
        }
    }

    private void OnBackClick()
    {
        SceneManager.LoadScene("Launch");
    }
}
