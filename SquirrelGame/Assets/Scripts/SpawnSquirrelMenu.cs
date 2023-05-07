using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSquirrelMenu : MonoBehaviour
{
    public SquirrelPicker squirrelPick;
    public SquirrelArray squirrels;

    public void RightButton()
    {
        if(squirrelPick.squirrelChoice < squirrelPick.maxSquirrels)
        {
            Destroy(GameObject.FindWithTag("SquirrelPreview"));
            squirrelPick.squirrelChoice += 1;
            Instantiate(squirrels.squirrels[squirrelPick.squirrelChoice], GameObject.Find("SquirrelPoint").transform);
        }
    }

    public void LeftButton()
    {
        if (squirrelPick.squirrelChoice > 0)
        {
            squirrelPick.squirrelChoice -= 1;
            Destroy(GameObject.FindWithTag("SquirrelPreview"));
            Instantiate(squirrels.squirrels[squirrelPick.squirrelChoice], GameObject.Find("SquirrelPoint").transform);
        }
    }

    public void BackToMain()
    {
        Destroy(GameObject.FindWithTag("SquirrelPreview"));
    }
}
