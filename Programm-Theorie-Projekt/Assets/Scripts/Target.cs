
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float xRot;
    public float yRot;
    public float zRot;

    [SerializeField]
    private float xMove;
    [SerializeField]
    private float zMove;

    //ENCAPSULATION
    public GameObject Spielerball { get; private set; }    
    public Rigidbody targetbody { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Spielerball = GameObject.Find("Spielerball");
        targetbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    //ABSTRACTION
    public virtual void Rotate()
    {
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
        
    }

    //ABSTRACTION
    public virtual void Move()
    {
        transform.position = transform.position + new Vector3(Random.Range(-xMove,xMove),0,Random.Range(-zMove,zMove) * Time.deltaTime); 
    }

    public virtual void Flee()
    {

    }

    //ABSTRACTION
    public virtual void GetHit()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Spielerball)
        {
            GetHit();
        }
    }
}
