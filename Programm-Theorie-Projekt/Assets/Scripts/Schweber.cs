using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Schweber : MonoBehaviour {

    public GameObject Plattform;
    private bool Auslöser;
    public PlayableDirector SchweberAnim;

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
            SchweberAnim.Play();
            // Animator anim = Plattform.gameObject.GetComponent<Animator>();
            // anim.SetBool("beladen", true);
        }
    }
}
