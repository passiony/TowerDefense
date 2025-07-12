using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物的可行走路径
/// </summary>
public class Path : MonoBehaviour
{
    public Transform[] points;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[(i + 1)].position);
        }
    }

    public Transform GetPoint(int index)
    {
        return points[index];
    }
}