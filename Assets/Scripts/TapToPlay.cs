using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    PlayerController _player;
    BlockSpawner _spawner;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _spawner = FindObjectOfType<BlockSpawner>();
        StartCoroutine(PlayerC());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.GetComponent<PlayerController>().enabled = true;
            _spawner.GetComponent<BlockSpawner>().enabled = true;
            Destroy(gameObject);
        }
    }
    IEnumerator PlayerC()
    {
        yield return new WaitForSeconds(0.2f);
        _player.GetComponent<PlayerController>().enabled = false;
    }
}
