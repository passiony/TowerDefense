using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用户输入管理器
/// </summary>
public class InputManager : MonoBehaviour
{
    private Camera mainCamera;

    public GameObject[] turrets;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Map"))
                {
                    //点中了地块，种植炮塔
                    var box = hit.collider.GetComponent<Box>();
                    if (box.IsOn == false)
                    {
                        box.IsOn = true;

                        var cubeCenter = hit.collider.transform.position;
                        var position = cubeCenter + new Vector3(0, 0.1f, 0);
                        var go = Instantiate(turrets[0], position, Quaternion.identity);
                    }
                }
                else if (hit.collider.CompareTag("Turret")) //点中了炮塔,做升级或拆除
                {
                    var turret = hit.collider.GetComponent<Turret>();
                    turret.Upgrade();
                }
            }
        }
    }
}