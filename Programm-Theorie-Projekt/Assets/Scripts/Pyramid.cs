using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Pyramid : Target
{
    public float fleeDistance;
    public float fleeSpeed;   
    
    void Update()
    {
        Rotate();
        Move();
        Flee();
    }

    //POLYMORPHISM
    public override void Flee()
    {
            
   
        Vector3 actualDistance  = transform.position - Spielerball.transform.position;
        
        if (actualDistance.magnitude<fleeDistance)
        {
            targetbody.AddForce(new Vector3(actualDistance.x, 0, actualDistance.z) * fleeSpeed*Time.deltaTime,ForceMode.Impulse);            
        }
        
    }

}
