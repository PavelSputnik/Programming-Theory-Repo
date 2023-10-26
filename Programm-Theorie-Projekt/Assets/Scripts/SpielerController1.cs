// Script für Ballsteuerung und Kollision mit PickUp-Objekten 
// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class SpielerController1 : MonoBehaviour {

    public float speed;
    public Text countText;
    public static bool wandUmschalter; //für Script Wandsenker
    public static bool säulenUmschalter; // für Script Säulensenker
    public static bool kugel8tot; // wenn Kugel8 getroffen
    public static int count;
    public RigidbodyConstraints constraints;
    public PlayableDirector playDir;

    private Rigidbody rb;
    private Transform playerTransform;
    
    private float zeit;
    private float bestzeit;
    private float min;
    private float sec;
    private float gesamtzeit;
        
        
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        speed = Menus.ballSpeed;
        count = 0;
        SetCountText();
        playerTransform = GameObject.Find("Spielerball").transform;
        wandUmschalter = true;
        säulenUmschalter = true;
        rb.constraints = RigidbodyConstraints.None;                
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);                
    }


    // Kollision mit Objekt, das Tag "* Pick Up" hat

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Würfel Pick Up"))
        {
            playDir = other.gameObject.GetComponentInParent<PlayableDirector>();
            playDir.Play();            
            count = count + 1;
            SetCountText();
            other.gameObject.tag = "Untagged";
        }

        if (other.gameObject.CompareTag("Pyramiden Pick Up"))
        {
            playDir = other.gameObject.GetComponentInParent<PlayableDirector>();
            playDir.Play();
            count = count + 1;
            SetCountText();
            other.gameObject.tag = "Untagged";
        }

        if (other.gameObject.CompareTag("Münzen Pick Up"))
        {
            Animator anim = other.gameObject.GetComponent<Animator>();
            anim.enabled = true;
            playDir = other.gameObject.GetComponentInParent<PlayableDirector>();
            playDir.Play();
            count = count + 1;
            SetCountText();
            other.gameObject.tag = "Untagged";
        }

        if (other.gameObject.CompareTag("Stachelkugel Pick Up"))
        {
            playDir = other.gameObject.GetComponentInParent<PlayableDirector>();
            playDir.Play();
            count = count + 1;
            SetCountText();
            other.gameObject.tag = "Untagged";
        }

        if (other.gameObject.CompareTag("Kugel"))
        {
            playDir = other.gameObject.GetComponentInParent<PlayableDirector>();
            playDir.Play();
            Rigidbody constr = other.gameObject.GetComponent<Rigidbody>();
            constr.constraints = RigidbodyConstraints.None;
            count = count + 1;
            SetCountText();            
        }


    }

    
    // Punktezähler 

    void SetCountText()
     {
         countText.text = "Punkte: " + count.ToString();                 
     }
        
}