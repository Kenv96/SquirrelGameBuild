using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Transform playerspawn;
    public GameObject player;
    public Score score;
    public int requiredScore;
    public GameObject[] thingstodisable;
    public GameObject[] thingstoenable;
    public bool isexit = false;
    public bool goingUnder;
    public bool progression = false;
    public GameObject fadeTransition;
    // Start is called before the first frame update

    public void TeleportPlayer()
    {
        player.transform.position = playerspawn.transform.position;
        player.transform.rotation = playerspawn.transform.rotation;
        Time.timeScale = 1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (score.acorns >= requiredScore)
            {
                StartCoroutine(TeleportTrasition());
            }
        }
    }

    IEnumerator TeleportTrasition()
    {

        fadeTransition.GetComponent<Animator>().Play("ScreenFadeOUT");
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(1);

        Time.timeScale = 1.0f;

        if (progression)
        {
            progression = false;
            DisplayScore.level += 1;
        }
        for (int i = 0; i < thingstoenable.Length; i++)
        {
            thingstoenable[i].SetActive(true);
        }

        for (int i = 0; i < thingstodisable.Length; i++)
        {
            thingstodisable[i].SetActive(false);
        }
        if (isexit == true)
        {
            SceneManager.LoadScene("Main Menu");
        }
        else
        {
            if (goingUnder == true)
            {
                RenderSettings.ambientIntensity = 0.35f;
            }
            else
            {
                RenderSettings.ambientIntensity = 1.00f;
            }
            TeleportPlayer();
        }
    }
}
