using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] int initLife = 100;
    [SerializeField] int currentLife = 0;
    void Start()
    {
        currentLife = initLife;
    }

    public void recibeDamage(int damage)
    {
        if (currentLife > 0) 
        {
            currentLife -= damage;
        }
        else
        {
            currentLife = 0;
            transform.gameObject.SetActive(false);
        }


    }
}
