using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Path path;
    public float speed = 1;

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
}
