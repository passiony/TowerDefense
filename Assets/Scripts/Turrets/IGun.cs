using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮塔的基类
///    子类：
///     MachineGun
///     RocketGun
///     LaserGun
/// </summary>
public abstract class IGun : MonoBehaviour
{
    public Transform gunHead;
    public Transform[] firepoints;

    public float seekRange = 3;
    public float fireRate = 1f;
    
    /// <summary>
    /// 1.扫描目标
    /// 2.攻击目标
    /// </summary>
    public virtual void Update()
    {
        SeekEnemys();
        AttackTarget();
    }

    protected virtual void SeekEnemys(){}
    
    protected virtual void AttackTarget(){}

}