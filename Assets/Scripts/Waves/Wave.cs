using System;
using UnityEngine;

/// <summary>
/// 单个波次
/// </summary>
[Serializable]
public class Wave
{
    public GameObject enemy;
    public int enemyCount;
    public float interval;
}
