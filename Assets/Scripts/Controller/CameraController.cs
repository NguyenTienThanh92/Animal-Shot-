using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {
        var Player = PlayerController.Instance;
        Transform player = Player.transform;
        Vector3 newPos = new Vector3(player.position.x, player.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, 1f);

    }
}
