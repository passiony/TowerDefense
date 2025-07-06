using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gun的根，控制不同等级
///     控制种炮塔，升级，拆除
/// </summary>
public class Turret : MonoBehaviour
{
    public IGun[] Levels;
    public int level = 0;
    
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
}
