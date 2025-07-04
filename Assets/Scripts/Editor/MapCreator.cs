using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 关卡编辑器
/// 编辑器脚本：做一些编辑器的工作，节省开发者的体力
/// </summary>
public class MapCreator : Editor
{
    [MenuItem("Tool/Create Map")]
    public static void CreateMap()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i * 1.1f, 0, j * 1.1f);
                cube.transform.localScale = new Vector3(1, 0.2f, 1);
            }
        }

        Debug.Log("Create Map Success");
    }
}