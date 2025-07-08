using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Image hpProgress;
    
    public void SetHPPercent(float value)
    {
        hpProgress.fillAmount = value;
    }
}
