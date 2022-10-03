using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Shoot Stuff")]
    public Transform[] target;
    public Transform emptyPos;
    [Space(10)]
    public Rigidbody Ball;
    public float waitTime;
    public float mainTime = 5;

    [Header("Loop Stuff")]
    public float firstStage;
    public float secondStage;
    public float nextStage = 10;


    private void Start()
    {
        // ObjectsList[Random.Range(0, ObjectsList.Length)].SetActive(true);

    }
    void Update()
    {
        //transform.LookAt(target);
        Loop();
        Aim();
    }

    void Aim()
    {
        waitTime += Time.deltaTime;

        int RandomCount = Random.Range(0, target.Length);

        if (waitTime >= mainTime)
        {
            for (int i = 0; i < RandomCount; i++)
            {              
                if (target[i].gameObject.activeSelf)
                {
                    emptyPos = target[i];
                    Invoke("Shoot", 1);
                }
            }

            waitTime = 0;
        }

        // When game Start
        if (waitTime <= mainTime)
        {
            transform.LookAt(emptyPos);
        }
    }

    void Shoot()
    {
        Rigidbody clone;

        clone = Instantiate(Ball, transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * 35);
    }

    void Loop()
    {
        int RandomCount = Random.Range(0, target.Length);

        //first stage
        firstStage += Time.deltaTime * 2;

        if (firstStage >= nextStage)
        {
            for (int i = 0; i <= RandomCount; i++)
            {
                target[i].gameObject.SetActive(true);
            }

            firstStage = 0;
        }

        //destroy stage
        secondStage += Time.deltaTime * 2;

        if (secondStage >= nextStage - 0.1f)
        {
            for (int j = 0; j < target.Length; j++)
            {
                target[j].gameObject.SetActive(false);
            }

            secondStage = 0;
        }
    }
}
