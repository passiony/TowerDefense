using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 火箭炮的子弹
/// </summary>
public class Bullet : MonoBehaviour
{
    public float speed = 2;
    public float explodeRange = 2;
    public float bulletDamage = 1;
    public GameObject hitEffect;

    private GameObject Target { get; set; }
    private bool fired;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    public void FireTarget(GameObject target)
    {
        this.Target = target;
        fired = true;
    }

    private void Update()
    {
        if (fired)
        {
            if (Target)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * speed);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var hit = Instantiate(hitEffect);
            hit.transform.position = transform.position;
            Destroy(hit, 2);

            var cols = Physics.OverlapSphere(transform.position, explodeRange, LayerMask.GetMask("Enemy"));
            foreach (var colItem in cols)
            {
                var enemy = colItem.GetComponent<Enemy>();
                enemy.OnDamage(bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}