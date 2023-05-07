using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public Score score;
    public static int level;
    public TextMeshProUGUI text;
    public GameObject winlightHood;
    public int passHood;
    public GameObject winlightSewer;
    public int passSewer;
    public GameObject winlightHwy;
    public int passHwy;
    void Start()
    {
        score.acorns = 0;
        level = 1;
    }
    void Update()
    {
        if (level == 1) text.text = score.acorns.ToString() + "/" + passHood.ToString();
        if (level == 2) text.text = score.acorns.ToString() + "/" + passSewer.ToString();
        if (level == 3) text.text = score.acorns.ToString() + "/" + passHwy.ToString();


        //add score (REMOVE)
        if (Input.GetKeyUp(KeyCode.K))
        {
            score.acorns += 10;
        }

        if(score.acorns >= passHood)
        {
            winlightHood.SetActive(true);
        }
        if (score.acorns >= passSewer)
        {
            winlightSewer.SetActive(true);
        }
        if (score.acorns >= passHwy)
        {
            winlightHwy.SetActive(true);
        }
    }
}
