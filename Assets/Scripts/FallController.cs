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
            collSide = -200f;
        }
        else if (transform.parent.position.x == -7)
        {
            collSide = 200f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(_bSpawner.GetComponent<BlockSpawner>());
            collision.rigidbody.AddForce(transform.right * collSide);
            collision.transform.GetComponent<Animator>().enabled = false;
            StartCoroutine(KnocbackTime());
        }
    }
    public IEnumerator KnocbackTime()
    {
        yield return new WaitForSeconds(0.7f);
        Instantiate(Exp, new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z), Quaternion.identity);
        Destroy(_player.gameObject);
        _canvas.retry_BTN.SetActive(true);
    }
}