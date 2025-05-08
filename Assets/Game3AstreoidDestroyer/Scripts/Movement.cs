using System;
using System.Numerics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Mathematics;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed=1f;

    [SerializeField] private float reverseSpeed=1f;
    private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed=1;
    [SerializeField] private float bulletSpeed=8f;

    [Header("Object Referances")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        HandleShooting();

    }

    void FixedUpdate()
    {
        GoForward();
        TurnLeftRight();
        GoBack();
    }

    void GoForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
          rb.AddForce(transform.up*speed);
        }
        else
        {
            rb.linearVelocity*=0.9f;
        }
    }
    void TurnLeftRight()
    {
        float rotationInput=0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationInput=1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationInput=-1f;
        }
        rb.angularVelocity=rotationSpeed*rotationInput;
    }
    void GoBack()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.up*reverseSpeed);
        }
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet=Instantiate(bulletPrefab,bulletSpawn.position,quaternion.identity);

            UnityEngine.Vector2 shipVelocity=rb.linearVelocity;
            UnityEngine.Vector2 shipDirection=transform.up;
            float shipForwardSpeed=UnityEngine.Vector2.Dot(shipVelocity,shipDirection);
            if (shipForwardSpeed<0){shipForwardSpeed=0;}
            bullet.linearVelocity=shipDirection*shipForwardSpeed;
            bullet.AddForce(bulletSpeed*transform.up,ForceMode2D.Impulse);
            //wtf man wtf
        }
    }
   




   
   
    // [SerializeField] private float shipAcceleration=10f;
    // [SerializeField] private float shipMaxVelocity=10f;
    // [SerializeField] private float shipRotationSpeed=180f;

    // private Rigidbody2D rb;
    // private bool isAlive=true;
    // private bool isAccelerating=false;

    // private void Start()
    // {
    //     rb=GetComponent<Rigidbody2D>();
    // }
    // private void Update()
    // {
    //     if (isAlive)
    //     {
    //         HandleShipAcceleration();
    //         HandleShipRotation();
    //     }
    // }

    // private void FixedUpdate()
    // {
    //     if (isAlive&&isAccelerating)
    //     {
    //     rb.AddForce(shipAcceleration*transform.up);
    //     rb.linearVelocity=UnityEngine.Vector2.ClampMagnitude(rb.linearVelocity,shipMaxVelocity);
    //     }
       
    // }

    // private void HandleShipRotation()
    // {
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         transform.Rotate(shipRotationSpeed*Time.deltaTime*transform.forward);
    //     }
    //     else if (Input.GetKey(KeyCode.D))
    //     {
    //         transform.Rotate(-shipRotationSpeed*Time.deltaTime*transform.forward);
    //     }
    // }

    // private void HandleShipAcceleration()
    // {
    //     isAccelerating=Input.GetKey(KeyCode.W);
    // }



}
