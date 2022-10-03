using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    PlayerController _player;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (_player != null)
        {
            gameObject.transform.position = new Vector3(transform.position.x, _player.transform.position.y + 2, transform.position.z);

        }
    }
}
