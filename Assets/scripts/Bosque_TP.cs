using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosque_TP : MonoBehaviour
{
    public GameObject tp1;
    public GameObject tp1_2;
    public GameObject tp2;
    public GameObject tp2_1;
    public GameObject camara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float p = col.transform.position.z;

            if (this.name == "tp1") {

                col.transform.position = new Vector3(tp1_2.transform.position.x + 2, tp1_2.transform.position.y, 1); //col.transform.position = tp1_2.transform.position;
                col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, 1);
                //camara.transform.position = tp1_2.transform.position;
            }
            if (this.name == "tp1 - 2") {
                col.transform.position = new Vector3(tp1.transform.position.x - 2, tp1.transform.position.y, 1);  //tp1.transform.position;
                col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, 1);
               // camara.transform.position = tp1.transform.position;
                Debug.LogWarning("");
            }
            if (this.name == "tp2") {
                col.transform.position = new Vector3(tp2_1.transform.position.x , tp2_1.transform.position.y - 2, 1);
                col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, 1);
               // camara.transform.position = tp2_1.transform.position;
            }
            if (this.name == "tp2 - 1") {
                col.transform.position = new Vector3(tp2.transform.position.x, tp2.transform.position.y + 2, 1); // col.transform.position = tp2.transform.position;
                col.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, 1);
               // camara.transform.position = tp2.transform.position;
            }

        }
    }

}
