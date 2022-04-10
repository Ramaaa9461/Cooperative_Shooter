using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] KeyCode shootKey;
    [SerializeField] Transform weapon;

    RaycastHit hit;
  
    void Update()
    {
        if (Input.GetKeyUp(shootKey)) 
        {

            if (Physics.Raycast(weapon.position, transform.TransformDirection(Vector3.forward), out hit, 100f))
            {
                if (hit.transform.gameObject.CompareTag("Player1") )
                {
                    hit.transform.gameObject.GetComponent<Life>().recibeDamage(10);
                }
                if (hit.transform.gameObject.CompareTag("Player2"))
                {
                    hit.transform.gameObject.GetComponent<Life>().recibeDamage(10);
                }
            }
        }
              //  Debug.DrawRay(weapon.position, transform.TransformDirection(Vector3.forward) * 100 , Color.yellow);



    }
}
