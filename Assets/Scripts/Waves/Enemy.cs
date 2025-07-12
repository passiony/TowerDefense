using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌军
///     只负责维护血量，生存和死亡
/// </summary>
public class Enemy : MonoBehaviour
{
    public float MaxHP = 3;
    public float HP;
    public int Coin = 10;
    private EnemyUI m_EnemyUI;

    private void Awake()
    {
        HP = MaxHP;
        m_EnemyUI = gameObject.GetComponentInChildren<EnemyUI>();
        m_EnemyUI.SetHPPercent(HP / MaxHP);
    }

    /// <summary>
    /// 受伤掉血
    /// </summary>
    /// <param name="hit"></param>
    public void OnDamage(float hit)
    {
        HP -= hit;
        m_EnemyUI.SetHPPercent(HP / MaxHP);

        if (HP <= 0)
        {
            // gameObject.GetComponent<EnemyMove>().StopMove();
            GameForm.Instance.AddCoin(Coin);
            OnDead();
        }
    }

    /// <summary>
    /// 死亡逻辑
    /// </summary>
    public void OnDead()
    {
        HP = 0;
        Destroy(gameObject, 0.2f);
        //死亡爆炸特效
        WaveManager.Instance.CheckGameOver();
    }
    
}