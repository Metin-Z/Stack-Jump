using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ComboController : MonoBehaviour
{
    CanvasManager _canvas;
    BlockSpawner _blockS;
    bool playercol = false;
    public GameObject combo_txt;
    private void Start()
    {
        _canvas = FindObjectOfType<CanvasManager>();
        _blockS = FindObjectOfType<BlockSpawner>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playercol = true;
        }
        if (playercol == true)
        {
            if (Mathf.Abs(_blockS.SpawnedBlocks[1].transform.position.x - transform.position.x) <= 0.15f)
            {
                Debug.Log("<color=#21ff3e> <b> COMBO </b> </color>");
                _canvas.score += 2;
                StartCoroutine(CColor());
                Instantiate(combo_txt,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+0.25f,gameObject.transform.position.z),Quaternion.identity);
            }
        }
    }
    public IEnumerator CColor()
    {
        Color block = new Color(99, 90, 82);
        for (int i = 0; i < _blockS.SpawnedBlocks.Count; i++)
        {
            yield return new WaitForSeconds(0.05f);
            _blockS.SpawnedBlocks[i].GetComponent<MeshRenderer>().material.DOColor(_blockS.ComboColor, 1);
        }
        StartCoroutine(OColor());
    }
    public IEnumerator OColor()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 1; i < _blockS.SpawnedBlocks.Count; i++)
        {
            yield return new WaitForSeconds(0.05f);
            _blockS.SpawnedBlocks[i].GetComponent<MeshRenderer>().material.DOColor(_blockS.BaseColor, 1);
        }
        gameObject.GetComponent<ComboController>().enabled = false;
    }
}
