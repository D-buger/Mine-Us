using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private PlayerMove playerMove;
    private Transform player;

    private float playerCameraDistance;

    private void Start()
    {
        playerMove = PlayManager.Instance.player;
        player = playerMove.gameObject.transform;

        playerCameraDistance = player.position.y - transform.position.y;

        playerMove.playerMoveAction += 
            () => transform.position = new Vector3(transform.position.x, player.position.y - playerCameraDistance, transform.position.z);
    }
}
