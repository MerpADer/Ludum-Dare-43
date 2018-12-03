using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    private CameraFollow cam;
    private bool triggering;

    public string Words;
    public Text text;

	void Start () {
        cam = FindObjectOfType<CameraFollow>();
	}
	
	void Update () {
        if(triggering && Input.GetKeyDown(KeyCode.E))
        {
            text.text = Words;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggering = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggering = false;
            text.text = "";
        }
    }

}
