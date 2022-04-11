using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponInfo_UI : MonoBehaviour
{
    [SerializeField] TMP_Text totalBullets;
    [SerializeField] TMP_Text currentBullets;
    
    
    void OnEnable()
    {
        EventManager.current.updateBulletEvent.AddListener(updateBullets);
    }

    public void updateBullets(int newCurrentBullets, int newTotalBullets)
    {
        if (newCurrentBullets <= 0 )
        {
            currentBullets.color = Color.red;
        }
        else
        {
            currentBullets.color = Color.white;
        }

        currentBullets.text = newCurrentBullets.ToString();
        totalBullets.text = newTotalBullets.ToString();

    }

}
