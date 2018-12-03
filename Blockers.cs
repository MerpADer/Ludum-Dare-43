using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockers : MonoBehaviour {

    private bool IsInRoom = false;
    public GameObject SacrificePowers;

	void Start () {
        SacrificePowers.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (IsInRoom && Input.GetKeyDown(KeyCode.E))
        {
            SacrificePowers.SetActive(true);
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsInRoom = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsInRoom = false;
            Debug.Log("Not In Room");
        }
    }
}
