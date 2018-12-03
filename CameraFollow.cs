using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Objective;
    public Vector3 offset;

	void Start () {
		
	}
	
	void Update () {
        gameObject.transform.position = new Vector3(Objective.transform.position.x + 
            offset.x, Objective.transform.position.y + offset.y, -10);
	}
}
