using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandAttributes : MonoBehaviour
{

    public string islandName;
    public bool hasBlacksmith;
    public bool hasGunsmith;
    public bool hasTavern;
    public bool hasWardsmith;
    public bool hasArchetier;
    public bool hasSpecial;

    private bool isDiscovered;


    public void SetDiscovered()
    {
        isDiscovered = true;
    }

    public bool GetDiscovered()
    {
        return isDiscovered;
    }

    public string GetName()
    {
        return islandName;
    }

    // Use this for initialization
    void Start ()
    {
        isDiscovered = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

}
