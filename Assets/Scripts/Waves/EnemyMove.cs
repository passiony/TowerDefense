using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌军行走的逻辑
/// </summary>
public class EnemyMove : MonoBehaviour
{
    private Path path;
    public float speed = 1;
    public Transform hitPoint;
    
    private bool startMove;
    private int index = 0;
    
    public void StartMove(Path path)
    {
        this.path = path;
        startMove = true;
    }
    
    void Update()
    {
        if (startMove)
        {
            var nextPoint = path.GetPoint(index);
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.LookRotation(nextPoint.position - transform.position), 360);
            
            if (Vector3.Distance(transform.position, nextPoint.position) < 0.1f)
            {
                index++;
                if (index >= path.points.Length)
                {
                    startMove = false;
                }
            }
        }
    }

    public void StopMove()
    {
        startMove = false;
    }
}
