using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    [SerializeField] float velocityX;
    [SerializeField] float velocityY;
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
           player1.transform.position += player1.transform.forward * velocityY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player1.transform.position -= player1.transform.forward * velocityY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player1.transform.eulerAngles += Vector3.down * velocityX * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player1.transform.eulerAngles += Vector3.up * velocityX * Time.deltaTime;
        }



        if (Input.GetKey(KeyCode.W))
        {
            player2.transform.position += player2.transform.forward * velocityY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player2.transform.position -= player2.transform.forward * velocityY * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player2.transform.eulerAngles += Vector3.down * velocityX * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player2.transform.eulerAngles += Vector3.up * velocityX * Time.deltaTime;
        }
    
    
    }
}
