using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject hitEffect;
    public int HP = 10;
    
    private void OnTriggerEnter(Collider other)
    {
        if (HP <= 0) return;
        
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            var effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, 2);

            HP--;
            GameForm.Instance.SetHP(HP);
            if (HP <= 0)
            {
                Debug.Log("游戏结束");
            }
        }
    }
}