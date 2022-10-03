using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BlockSpawner : MonoBehaviour
{
    PlayerController _player;
    public GameObject BLOCK;
    public List<Transform> BlockSpawnPoses;
    public List<Transform> SpawnedBlocks;
    public Color BaseColor;
    public Color ComboColor;
    public int randomPos;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        StartCoroutine(SpawnBlock());
    }
     IEnumerator SpawnBlock()
    {      
        randomPos = Random.Range(0,2);
       GameObject newblock = Instantiate(BLOCK,new Vector3(BlockSpawnPoses[randomPos].position.x,SpawnedBlocks[0].transform.position.y+0.9471047f, BlockSpawnPoses[randomPos].position.z),Quaternion.identity);
        //SpawnedBlocks.Remove(SpawnedBlocks.FirstOrDefault());
        SpawnedBlocks.Insert(0,newblock.transform);
        yield return new WaitForSeconds(2.2f);
        StartCoroutine(SpawnBlock());
    }
    private void Update()
    {
        if (SpawnedBlocks.Count >=8)
        {
            Destroy(SpawnedBlocks.LastOrDefault().gameObject);
            SpawnedBlocks.Remove(SpawnedBlocks.LastOrDefault());
        }
    }
}