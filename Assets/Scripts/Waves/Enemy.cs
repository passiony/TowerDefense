using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 3;
    public int Coin = 10;
    
    public void OnDamage(float hit)
    {
        HP -= hit;
        if (HP <= 0)
        {
            // gameObject.GetComponent<EnemyMove>().StopMove();
            Destroy(gameObject,1);
            GameForm.Instance.AddCoin(Coin);
        }
    }
}
