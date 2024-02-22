using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOre : MonoBehaviour
{
    [SerializeField] Rect spawnPointRect;

    [SerializeField] float SpawnDepth;

    private ObjectPool pool;
    private Vector2 previousPos;

    private void Start()
    {
        pool = PlayManager.Instance.orePool;
        previousPos = PlayManager.Instance.player.gameObject.transform.position;
        Spawn();
        Spawn();
    }

    public void Spawn()
    {
        float newYPos = previousPos.y - SpawnDepth + Random.Range(spawnPointRect.yMin, spawnPointRect.yMax);
        float newXPos = Random.Range(spawnPointRect.xMin, spawnPointRect.xMax);
        Vector2 newPos = new Vector2(newXPos, newYPos);
        previousPos = newPos;

        GameObject newOre = pool.Pop();
        newOre.transform.position = newPos;
    }


}
