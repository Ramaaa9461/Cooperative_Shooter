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
                    Debug.Log("murio player 1");
                    
                }
                if (hit.transform.gameObject.CompareTag("Player2"))
                {
                    Debug.Log("murio player 2");
                }
            }
        }
                Debug.DrawRay(weapon.position, transform.TransformDirection(Vector3.forward) * 100 , Color.yellow);



    }
}
