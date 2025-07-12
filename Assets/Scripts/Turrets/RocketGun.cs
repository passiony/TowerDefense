using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// 机枪Gun
///     负责机枪的射击，瞄准目标
/// </summary>
public class RocketGun : IGun
{
    public GameObject bullet;
    public float bulletSpeed = 2;
    public float bulletDamage = 1;

    private GameObject target;
    private float fireTime;

    protected override void SeekEnemys()
    {
        var cols = Physics.OverlapSphere(transform.position, seekRange, LayerMask.GetMask("Enemy"));
        if (cols.Length > 0)
        {
            target = cols[0].gameObject;
        }
    }

    protected override void AttackTarget()
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
                    var hit = Instantiate(bullet);
                    hit.transform.position = firepoint.position;
                    hit.transform.rotation = firepoint.rotation;
                    hit.GetComponent<Bullet>().FireTarget(target);
                }
            }
        }
    }
}