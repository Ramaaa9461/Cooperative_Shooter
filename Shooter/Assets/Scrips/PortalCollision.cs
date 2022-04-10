using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    [SerializeField] Transform exit;
    float offset = 1;

    public void teleportPlayer(Transform player)
    {
        player.position = new Vector3(exit.transform.position.x, player.transform.position.y, exit.position.z + (exit.forward.z + offset));
    }

}
