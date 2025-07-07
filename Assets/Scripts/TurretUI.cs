using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 炮塔的3D UI
/// </summary>
public class TurretUI : MonoBehaviour
{
    public Button upgradeBtn;
    public Button destroyBtn;
    
    private Turret turret;
    void Awake()
    {
        turret = gameObject.GetComponentInParent<Turret>();
        upgradeBtn.onClick.AddListener(OnUpgradeClick);
        destroyBtn.onClick.AddListener(OnDestroyClick);
    }

    private void OnDestroyClick()
    {
        Destroy(turret.gameObject);
        GameForm.Instance.AddCoin(turret.GetDestroyPrice());
        ///TODO:添加底座Box的还原
    }

    private void OnUpgradeClick()
    {
        if (turret.CanUpgrade())
        {
            if (GameForm.Instance.CanBuy(turret.GetUpgradePrice()))
            {
                GameForm.Instance.SubCoin(turret.GetUpgradePrice());
                turret.Upgrade();
            }
        }
    }
}
