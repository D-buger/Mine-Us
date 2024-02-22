using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OreBorderLine"))
        {
            PlayManager.Instance.orePool.Push(this.gameObject);
            PlayManager.Instance.spawnOre.Spawn();
        }
    }
}
