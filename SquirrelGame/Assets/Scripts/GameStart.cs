using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject[] thingstodisable;
    public GameObject[] thingstoenable;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < thingstoenable.Length; i++)
        {
            thingstoenable[i].SetActive(true);
        }

        for (int i = 0; i < thingstodisable.Length; i++)
        {
            thingstodisable[i].SetActive(false);
        }

        PauseMenu.isPaused= false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
