using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] KeyCode shootKey;
    [SerializeField] Transform weapon;
    [SerializeField] int damage = 10;


    Vector3 initLocalPositionWeapon;
    Vector3 initRotationWeapon;
    float recoilForce = 4f;
    RaycastHit hit;


    void Start()
    {
        initLocalPositionWeapon = weapon.localPosition;
        initRotationWeapon = weapon.eulerAngles;

    }
    void Update()
    {
        if (Input.GetKeyUp(shootKey))
        {

            addRecoilForce();

            raycastShoot();

        }

        weapon.transform.localPosition = Vector3.Lerp(weapon.transform.localPosition, initLocalPositionWeapon, Time.deltaTime * 5f);
    }

    private void raycastShoot()
    {

        if (Physics.Raycast(weapon.position, transform.TransformDirection(Vector3.forward), out hit, 100f))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                hit.transform.gameObject.GetComponent<Life>().recibeDamage(damage);
            }
        }

    }

    private void addRecoilForce()
    {
        weapon.transform.position = weapon.transform.position - weapon.transform.forward * (recoilForce / 50f);
    }
}
