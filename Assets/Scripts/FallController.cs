using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FallController : MonoBehaviour
{
    BlockSpawner _bSpawner;
    CanvasManager _canvas;
    PlayerController _player;
    public GameObject Exp;
    float collSide;
    private void Start()
    {
        _bSpawner = FindObjectOfType<BlockSpawner>();
        _canvas = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<PlayerController>();
        if (transform.parent.position.x == 7)
        {
            collSide = -250f;
        }
        else if (transform.parent.position.x == -7)
        {
            collSide = 250f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _bSpawner.GetComponent<BlockSpawner>().enabled = false;
            collision.rigidbody.AddForce(transform.right * collSide);
            collision.transform.GetComponent<Animator>().enabled = false;
            StartCoroutine(KnocbackTime());
        }
    }
    public IEnumerator KnocbackTime()
    {
        yield return new WaitForSeconds(0.45f);
        Instantiate(Exp, new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z), Quaternion.identity);
        Destroy(_player.gameObject);
        _canvas.retry_BTN.SetActive(true);
        Time.timeScale = 0;
    }
}