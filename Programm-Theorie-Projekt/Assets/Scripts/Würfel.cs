using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Würfel : Target
{
    private int i;
    private bool hit = false;

    
    //POLYMORPHISM
    void Update()
    {
        Rotate();
        Move();
        
       if (hit)
        {
            Shrink();
        }
    }
       
    
    //POLYMORPHISM
    public override void GetHit()
    {
        hit = true;                   
    }

    private void Shrink()
    {
        if (i <80)
            transform.localScale = transform.localScale * .98f;
        else
            GameObject.Destroy(gameObject);
    }
}
