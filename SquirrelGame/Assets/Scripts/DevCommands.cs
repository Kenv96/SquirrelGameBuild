using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCommands : MonoBehaviour
{
    public Transform player;
    public GameObject acorn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightBracket)) {
            for(int i = 0; i < 50; i++) {
                Instantiate(acorn, player.transform);
            }
        }
    }
}
