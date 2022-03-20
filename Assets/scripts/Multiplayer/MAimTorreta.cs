using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAimTorreta : MonoBehaviour
{
    

    public GameObject myPlayer;
    private PhotonView pv;

    void FixedUpdate()
    {
        if (!pv.IsMine) { return; }
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);


    }

    // Start is called before the first frame update
    void Start()
    {
        pv = myPlayer.GetComponent<PhotonView>();
    }
}
