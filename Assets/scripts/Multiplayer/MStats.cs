using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MStats : MonoBehaviour
{
    static private bool primero = false;
    static public int victorias = 0;
    static public int derrotas = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool getSpawn() { return primero; }
    public void setSpawn(bool s) { primero = s; }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reseteo()
    {
        victorias = 0;
        derrotas = 0;
    }
}