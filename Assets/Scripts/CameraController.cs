using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;
    float yOffset = 10f;
    float zOffset = -3.5f;

    Vector3 playerPos;

    void FixedUpdate()
    {
        playerPos = player.transform.position;
        Vector3 newPos = new Vector3(playerPos.x, playerPos.y + yOffset, playerPos.z + zOffset);
        gameObject.transform.position = newPos;
    }


}
