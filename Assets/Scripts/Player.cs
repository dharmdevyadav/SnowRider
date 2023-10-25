using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float AddTorqueLeft =150f;
   
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2d;
    [SerializeField] float SpeedUp =210f;
    [SerializeField] float BasicSpeed =120f;
    bool canMove = true;
    void Start()
    {
        
        rb2d=GetComponent<Rigidbody2D>();
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();

        // transform.position += new Vector3(1.5f,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            SpeedBooster();

            RotatePlayer();
        }
       
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += new Vector3(0.05f, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(-0.05f,0, 0);
        //}
    }
    public void DisableControl()
     {
        canMove = false;

     }

    void SpeedBooster()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
           // Debug.Log("Speed at high Level now.");
            surfaceEffector2d.speed = SpeedUp;
        }
        else
        {
            //Debug.Log("Speed at basic Level now.");
            surfaceEffector2d.speed = BasicSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(AddTorqueLeft);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-AddTorqueLeft);
        }
    }
}
