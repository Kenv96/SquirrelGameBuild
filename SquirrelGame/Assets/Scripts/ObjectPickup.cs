using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public Score score;
    public AudioClip pickupSound;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        score.acorns += 1;
        AudioSource.PlayClipAtPoint(pickupSound, transform.position, 0.3f);
        Destroy(gameObject);
    }
}
