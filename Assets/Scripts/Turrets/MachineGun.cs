using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 机枪Gun
///     负责机枪的射击，瞄准目标
/// </summary>
public class MachineGun : IGun
{
    public GameObject hitEffect;
    public float hitDamage = 1;

    private GameObject target;
    private float fireTime;
    private AudioSource m_AudioSource;

    void Start()
    {
        m_AudioSource = gameObject.GetComponent<AudioSource>();
    }

    protected override void SeekEnemys()
    {
        var cols = Physics.OverlapSphere(transform.position, seekRange, LayerMask.GetMask("Enemy"));
        if (cols.Length > 0)
        {
            target = cols[0].gameObject;
        }
        else
        {
            target = null;
            fireTime = 0;
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
            if (fireTime > fireRate) //1f
            {
                fireTime = 0;
                foreach (var firepoint in firepoints)
                {
                    var hitpoint = target.GetComponent<EnemyMove>().hitPoint;
                    var hit = Instantiate(hitEffect, hitpoint);
                    hit.transform.localPosition = Vector3.zero;
                    target.GetComponent<Enemy>().OnDamage(hitDamage);
                    m_AudioSource.Play();
                    Destroy(hit, 2);
                }
            }
        }
    }
}