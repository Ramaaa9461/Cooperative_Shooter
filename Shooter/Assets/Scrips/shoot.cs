using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] KeyCode shootKey;
    [SerializeField] Transform weapon;
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject flashEffect;
    [SerializeField] int damage = 10;


    Vector3 initLocalPositionWeapon;
    float recoilForce = 4f;
    RaycastHit hit;


    void Start()
    {
        initLocalPositionWeapon = weapon.localPosition;

    }
    void Update()
    {
        if (Input.GetKeyUp(shootKey))
        {

            addRecoile();

            raycastShoot();

        }
     //  Debug.DrawRay(muzzle.transform.position , muzzle.transform.forward * 100f, Color.black);

        weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition,initLocalPositionWeapon, Time.deltaTime * 5f);
    }

    private void raycastShoot()
    {
        GameObject flashWeapon = Instantiate(flashEffect, muzzle.transform.position, Quaternion.Euler(muzzle.forward), weapon.transform);
        Destroy(flashWeapon, 0.6f);

        
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, 100f))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                hit.transform.gameObject.GetComponent<Life>().recibeDamage(damage);
            }
        }


    }

    private void addRecoile()
    {
        weapon.transform.position = weapon.transform.position - weapon.transform.forward * (recoilForce / 50f);
    }
}
