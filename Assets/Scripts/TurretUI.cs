using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 炮塔的3D UI
/// </summary>
public class TurretUI : MonoBehaviour
{
    public Button bottomBtn;
    public Button upgradeBtn;
    public Button destroyBtn;
    public Transform pivot;
    
    public Turret turret { get; set; }
    
    private static TurretUI _instance;
    public static TurretUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TurretUI>(true);
            }
            return _instance;
        }
    }
    
    void Awake()
    {
        bottomBtn.onClick.AddListener(OnBottomClick);
        upgradeBtn.onClick.AddListener(OnUpgradeClick);
        destroyBtn.onClick.AddListener(OnDestroyClick);
    }

    private void OnBottomClick()
    {
        gameObject.SetActive(false);
        turret = null;
    }

    public void ShowUI(Turret turret)
    {
        this.turret = turret;
        gameObject.SetActive(true);
    }
    
    private void OnEnable()
    {
        //每次打开都会判断是否可升级
        upgradeBtn.interactable = turret.CanUpgrade() && GameForm.Instance.CanBuy(turret.GetUpgradePrice());
        
        //设置pivot的UI位置，通过turret的世界坐标系位置转屏幕坐标系
        pivot.position = Camera.main.WorldToScreenPoint(turret.transform.position);
    }

    private void OnDestroyClick()
    {
        gameObject.SetActive(false);
        turret.box.IsOn = false;//底座Box的还原
        Destroy(turret.gameObject);
        GameForm.Instance.AddCoin(turret.GetDestroyPrice());
    }

    private void OnUpgradeClick()
    {
        gameObject.SetActive(false);
        if (turret.CanUpgrade())
        {
            if (GameForm.Instance.CanBuy(turret.GetUpgradePrice()))
            {
                GameForm.Instance.SubCoin(turret.GetUpgradePrice());
                turret.Upgrade();
            }
        }
    }
}
