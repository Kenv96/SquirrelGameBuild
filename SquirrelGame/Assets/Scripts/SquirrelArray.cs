using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelArray : MonoBehaviour
{
    public GameObject[] squirrels;
    public SquirrelPicker squirrelPick;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        Instantiate(squirrels[squirrelPick.squirrelChoice], GameObject.Find("SquirrelPoint").transform);
    }
}
