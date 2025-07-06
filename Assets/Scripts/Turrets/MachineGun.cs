using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// 机枪Gun
///     负责机枪的射击，瞄准目标
/// </summary>
public class MachineGun : IGun
{
    public Transform gunHead;
    public Transform[] firepoints;
    public GameObject hitEffect;

    public float seekRange = 3;
    public float fireRate = 1f;
    public float bulletDamage = 1;

    private GameObject target;
    private float fireTime;

    void Start()
    {
    }

    /// <summary>
    /// 1.扫描目标
    /// 2.攻击目标
    /// </summary>
    void Update()
    {
        SeekEnemys();
        AttackTarget();
    }

    void SeekEnemys()
    {
        var cols = Physics.OverlapSphere(transform.position, seekRange, LayerMask.GetMask("Enemy"));
        if (cols.Length > 0)
        {
            target = cols[0].gameObject;
        }
    }

    void AttackTarget()
    {
        if (target != null)
        {
            var dir = target.transform.position - transform.position;
            dir.y = 0;
            gunHead.rotation = Quaternion.LookRotation(dir);

            //子弹的发射间隔
            fireTime += Time.deltaTime;
            if (fireTime > fireRate)//1f
            {
                fireTime = 0;
                foreach (var firepoint in firepoints)
                {
                    var hitpoint = target.GetComponent<EnemyMove>().hitPoint;
                    var hit = Instantiate(hitEffect, hitpoint);
                    hit.transform.localPosition = Vector3.zero;
                    target.GetComponent<Enemy>().OnDamage(bulletDamage);
                    Destroy(hit, 2);
                }
            }
        }
    }
}