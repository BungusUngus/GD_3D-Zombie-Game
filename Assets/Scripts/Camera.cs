using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    public float yPos;
    public float zPos;

    void Start()
    {
        player = GameObject.Find("Test Player"); // The player
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yPos, player.transform.position.z - zPos);
    }
}
