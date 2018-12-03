using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour {

    private int TimesInRoom;

    public GameObject Blockers;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            if (TimesInRoom == 0)
            {
                Blockers.SetActive(true);
                TimesInRoom++;
            }
            else
            {
                return;
            }
        }
    }

}
