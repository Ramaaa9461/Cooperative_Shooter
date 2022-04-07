using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] KeyCode Up;
    [SerializeField] KeyCode Down;
    [SerializeField] KeyCode Right;
    [SerializeField] KeyCode Left;

    [SerializeField] float velocityX;
    [SerializeField] float velocityY;

    Vector3 dir;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(Up))
        {
        
            rigidbody.MovePosition(transform.forward * velocityY * Time.deltaTime;
        }
        if (Input.GetKey(Down))
        {
            rigidbody.MovePosition(-transform.forward * velocityY * Time.deltaTime);
        }
        if (Input.GetKey(Left))
        {
          //  rigidbody.MoveRotation()
            transform.eulerAngles += Vector3.down * velocityX * Time.deltaTime;
        }
        if (Input.GetKey(Right))
        {
            transform.eulerAngles += Vector3.up * velocityX * Time.deltaTime;
        }

    }
}
