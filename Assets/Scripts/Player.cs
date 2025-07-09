using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject hitEffect;
    public Image hpBar;
    public int MaxHP = 10;
    public int HP = 10;
    
    private void OnTriggerEnter(Collider other)
    {
        if (HP <= 0) return;
        
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.OnDead();

            var effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, 2);

            HP--;
            RefreshHP();
            GameForm.Instance.SetHP(HP);
            if (HP <= 0)
            {
                Debug.Log("Game Over");
                GameOver.Instance.ShowOver(false);
            }
        }
    }

    void RefreshHP()
    {
        hpBar.fillAmount = (float)HP / MaxHP;
    }
}