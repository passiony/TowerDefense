using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameForm : MonoBehaviour
{
    public Button settingBtn;
    public GameObject settingForm;
    public TextMeshProUGUI m_Coin;
    public TextMeshProUGUI m_HP;
    public int CoinNum = 200;
    public TextMeshProUGUI m_WaveNum;
    public Button[] turretButtons;
    
    public static GameForm Instance;
    
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        settingBtn.onClick.AddListener(OnSettingClick);
        m_Coin.text = CoinNum.ToString();
        for (int i = 0; i < turretButtons.Length; i++)
        {
            int index = i;
            var button = turretButtons[i];
            button.onClick.AddListener(() =>
            {
                OnTurrectClick(index);
            });
        }
    }

    private void OnSettingClick()
    {
        settingForm.SetActive(true);
    }

    /// <summary>
    ///  Turret 按钮点击
    /// </summary>
    /// <param name="index"></param>
    private void OnTurrectClick(int index)
    {
        var turret = InputManager.Instance.turrets[index];
        if (CanBuy(turret.prices[0]))
        {
            SubCoin(turret.prices[0]);
            InputManager.Instance.CreateTurret(index);
        }
    }

    public bool CanBuy(int coin)
    {
        return CoinNum >= coin;
    }
    
    public void AddCoin(int coin)
    {
        CoinNum += coin;
        m_Coin.text = CoinNum.ToString();
    }
    
    public void SubCoin(int coin)
    {
        CoinNum -= coin;
        m_Coin.text = CoinNum.ToString();
    }
    
    public void SetHP(int hp)
    {
        m_HP.text = hp.ToString();
    }

    public void SetWaveNum(int wave,int totalWave)
    {
        m_WaveNum.text = $"{wave}/{totalWave}";
    }
}