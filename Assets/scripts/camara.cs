using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
     GameObject player;
    public Vector3 offset = new Vector3(0, 0, 1);


    void Start()
    {
       player = GameObject.Find("player");
    }

    void FixedUpdate()
    {
        if (player) {
            transform.position = new Vector3(
                player.transform.position.x + offset.x,
                player.transform.position.y + offset.y,
               - 100
                ) ;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, -0.2f, -46f),
            Mathf.Clamp(player.transform.position.y, -58, 35f),
            -100
            );
    }
}
