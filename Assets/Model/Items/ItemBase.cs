using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour {

    public virtual void useItem(){
        Debug.Log("Using item");
    }
}
