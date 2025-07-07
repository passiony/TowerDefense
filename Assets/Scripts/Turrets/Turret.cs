using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Gun的根，控制不同等级
///     控制种炮塔，升级，拆除
/// </summary>
public class Turret : MonoBehaviour
{
    public int[] prices = { 30, 20, 30 };
    public int level = 0;
    public IGun[] Levels;

    private void Start()
    {
        RefreshTurret();
    }

    void RefreshTurret()
    {
        foreach (var gun in Levels)
        {
            gun.gameObject.SetActive(false);
        }

        Levels[level].gameObject.SetActive(true);
    }

    public void Upgrade()
    {
        if (level < 2)
        {
            level++;
            RefreshTurret();
        }
    }

    public bool CanUpgrade()
    {
        return level < 2;
    }
    
    public int GetUpgradePrice()
    {
        return prices[level + 1];
    }

    public int GetDestroyPrice()
    {
        return (int)(prices[level] / 2f);
    }
    
    public void SetEnable(bool enable)
    {
        this.enabled = enable;
        foreach (var gun in Levels)
        {
            gun.enabled = enable;
        }

        this.GetComponent<BoxCollider>().enabled = enable;
    }

    public void ShowUI()
    {
        transform.Find("TurretUI").gameObject.SetActive(true);
    }
}