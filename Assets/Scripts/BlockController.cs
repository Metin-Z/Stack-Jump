using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockController : MonoBehaviour
{
    Vector3 target;
    public float randomSpeed;
    void Start()
    {
        if (transform.position.x ==7)
        {
            target = new Vector3(-7, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == -7)
        {
            target = new Vector3(7, transform.position.y, transform.position.z);
        }

        randomSpeed = Random.Range(4,8);
    }
    void Update()
    {   
        transform.position = Vector3.MoveTowards(transform.position, target, randomSpeed * Time.deltaTime);
    }
}
