using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificePower : MonoBehaviour {

    public bool[] Powers = new bool[5];
    public GameObject[] UItext = new GameObject[5];
    public GameObject SacrificePowers;

    public void Sacrifice(int ChosenPower)
    {
        Powers[ChosenPower] = false;
        Destroy(UItext[ChosenPower]);
        SacrificePowers.SetActive(false);
    }

}
