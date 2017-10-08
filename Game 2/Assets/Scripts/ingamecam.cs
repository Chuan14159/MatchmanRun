using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingamecam : MonoBehaviour {
    public GameObject Matchman;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(Matchman.transform.position.x, Matchman.transform.position.y, -15);
	}
}
