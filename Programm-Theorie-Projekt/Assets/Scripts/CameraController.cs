using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Spieler;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - Spieler.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Spieler.transform.position + offset;
	}
}
