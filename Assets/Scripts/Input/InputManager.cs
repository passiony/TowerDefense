using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 用户输入管理器
/// </summary>
public class InputManager : MonoBehaviour
{
    private Camera mainCamera;
    public GameForm gameForm;
    public Turret[] turrets;
    public int turretId;

    public static InputManager Instance;
    private GameObject dragTurret;

    void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    void Update()
    {
        ProcessClick();

        ProcessDrag();
    }

    void ProcessClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Box"))
                {
                    if (dragTurret)
                    {
                        //点中了地块，种植炮塔
                        var box = hit.collider.GetComponent<Box>();
                        if (box.IsOn == false)
                        {
                            box.IsOn = true;
                            var cubeCenter = hit.collider.transform.position;
                            var position = cubeCenter + new Vector3(0, 0.1f, 0);
                            dragTurret.transform.position = position;
                            dragTurret.GetComponent<Turret>().SetEnable(true);
                            dragTurret = null;
                        }
                    }
                }
                if (hit.collider.CompareTag("Turret")) //点中了炮塔,做升级或拆除
                {
                    hit.collider.GetComponent<Turret>().ShowUI();
                }
            }
        }
    }

    void ProcessDrag()
    {
        if (dragTurret)
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit,100,LayerMask.GetMask("Plane")))
            {
                dragTurret.transform.position = hit.point;
            }
        }
    }

    public void CreateTurret(int id)
    {
        var prefab = turrets[id];
        var go = Instantiate(prefab.gameObject);
        dragTurret = go;
        dragTurret.GetComponent<Turret>().SetEnable(false);
    }
}