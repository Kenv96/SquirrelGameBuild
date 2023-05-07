using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenSky : MonoBehaviour
{
    public Transform player;
    public float surfaceSky;
    public float undergroundSky;

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < 0)
        {
            RenderSettings.skybox.SetFloat("_Exposure", undergroundSky);
        }
        else
        {
            RenderSettings.skybox.SetFloat("_Exposure", surfaceSky);
        }
    }
}
