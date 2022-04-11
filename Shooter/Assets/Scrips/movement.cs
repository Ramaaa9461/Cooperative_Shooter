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

    CharacterController characterController;
    Vector3 directionMove;
    private float jumpHeight = 1.9f;
    private float gravityScale = 20f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();


    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Portal")
        {
            hit.gameObject.GetComponent<PortalCollision>().teleportPlayer(transform);
        }
    }

    void Movement()
    {

        if (Input.GetKey(Up))
        {
            characterController.SimpleMove(transform.forward * velocityY);
        }
        if (Input.GetKey(Down))
        {
            characterController.SimpleMove(-transform.forward * velocityY);
        }

        if (Input.GetKey(Left))
        {
            transform.eulerAngles += Vector3.down * velocityX * Time.deltaTime;
        }
        if (Input.GetKey(Right))
        {
            transform.eulerAngles += Vector3.up * velocityX * Time.deltaTime;
        }

    }
}
