using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnDamage(float hit)
    {
        HP -= hit;
        m_EnemyUI.SetHPPercent(HP / MaxHP);

        if (HP <= 0)
        {
            // gameObject.GetComponent<EnemyMove>().StopMove();
            Destroy(gameObject, 1);
            GameForm.Instance.AddCoin(Coin);
        }
    }
}