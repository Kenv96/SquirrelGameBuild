using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] squirrels;
    public SquirrelPicker squirrelPick;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(squirrels[squirrelPick.squirrelChoice], GameObject.FindWithTag("Player").transform);
    }
}
