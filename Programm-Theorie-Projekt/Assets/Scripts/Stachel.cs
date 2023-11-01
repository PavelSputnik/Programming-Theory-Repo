using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Stachel : Target
{
    public float fleeSpeed;
    public float fleeDistance;
    
    
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
            targetbody.AddForce(new Vector3(0, 90, 0) * fleeSpeed*Time.deltaTime,ForceMode.Impulse);
           
        }
        
    }

}
