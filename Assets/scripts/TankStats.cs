using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats
{
    static public int strengh;
    static public int health;
    static public int speed;
    static public string tower;
    static public string body;
    static public string track;
    static public string bullet;
    static public string token;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Stats(int fuerza, int vida, int vel, string torre, string b, string ruedas, string bala, string tok) {
        strengh = fuerza;
        health = vida;
        speed = vel;
        tower = torre;
        body = b;
        track = ruedas;
        bullet = bala;
        token = tok;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
