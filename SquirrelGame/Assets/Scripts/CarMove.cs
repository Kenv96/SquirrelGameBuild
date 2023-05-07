using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 15.0f;
    public Vector3 direction;
    //Start is called before the first frame update
    void Start()
    {
        if (transform.position.z > -200)
        {
            if (transform.position.z > 0 && transform.position.x > -100 && transform.position.x < 100)
            {
                direction.z = -1;
            }

            if (transform.position.z < 0 && transform.position.x > -100 && transform.position.x < 100)
            {
                direction.z = 1;
            }

            if (transform.position.x > 0 && transform.position.z > -100 && transform.position.z < 100)
            {
                direction.x = -1;
            }

            if (transform.position.x < 0 && transform.position.z > -100 && transform.position.z < 100)
            {
                direction.x = 1;
            }
        }
        if (transform.position.z <= -200)
        {
            if (transform.position.z < -275)
            {
                direction.z = 1;
            }

            if (transform.position.z > -275)
            {
                direction.z = -1;
            }
        }

    }
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
