// Script für Ballsteuerung 
// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpielerController: MonoBehaviour {

    public float speed;
    
    public RigidbodyConstraints constraints;
    
    private Rigidbody rb;
    
    
            
        
    void Start ()
    {
        rb = GetComponent<Rigidbody>();       
               
        rb.constraints = RigidbodyConstraints.None;                
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);                
    }


   
}