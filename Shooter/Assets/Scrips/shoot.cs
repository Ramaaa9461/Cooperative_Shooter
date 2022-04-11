using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    [SerializeField] KeyCode shootKey;
    [SerializeField] KeyCode reloadKey;
    [SerializeField] Transform weapon;
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject flashEffect;
    [SerializeField] GameObject bulletHolePrefab;
    [SerializeField] int damage = 10;
    [SerializeField] int maxAmmo = 120;
    [SerializeField] int magCapacity = 30;

    public int currentAmmo { get; private set; }

    Vector3 initLocalPositionWeapon;
    float recoilForce = 4f;
    RaycastHit hit;
    private float reloadTime;

    void Awake()
    {
        initLocalPositionWeapon = weapon.localPosition;
        currentAmmo = maxAmmo;
        EventManager.current.updateBulletEvent.Invoke(currentAmmo, maxAmmo);
    }
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            if (currentAmmo > 0)
            {

                raycastShoot();
                currentAmmo--;
                EventManager.current.updateBulletEvent.Invoke(currentAmmo, maxAmmo);
            }


        }
        if (Input.GetKeyDown(reloadKey))
        {
            //Reload();
            StartCoroutine(ReloadWeapon());
        }
        //  Debug.DrawRay(muzzle.transform.position , muzzle.transform.forward * 100f, Color.black);

        weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition, initLocalPositionWeapon, Time.deltaTime * 5f);
    }
    IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(reloadTime);
        if (maxAmmo > magCapacity)
        {
        currentAmmo = magCapacity;
        }

        maxAmmo -= magCapacity;
        EventManager.current.updateBulletEvent.Invoke(currentAmmo, maxAmmo);
    }
    //private void Reload()
    //{
    //    if (currentAmmo < maxAmmo)
    //    {
    //        currentAmmo = maxAmmo;
    //    }
    //}

    private void raycastShoot()
    {
        GameObject flashWeapon = Instantiate(flashEffect, muzzle.transform.position, Quaternion.Euler(muzzle.forward), weapon.transform);
        Destroy(flashWeapon, 0.6f);

        addRecoile();


        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, 100f))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                hit.transform.gameObject.GetComponent<Life>().recibeDamage(damage);
            }
            else
            {
                GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 4f);
            }
        }


    }

    private void addRecoile()
    {
        weapon.transform.position = weapon.transform.position - weapon.transform.forward * (recoilForce / 50f);
    }
}
