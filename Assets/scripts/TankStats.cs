using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats
{
    static public int strengh = 20;
    static public int health = 100;
    static public int maxhealth;
    static public int speed = 3;
    static public string tower;
    static public string body;
    static public string track;
    static public string bullet;
    static public string token;
    static public int id;
    static public string nombre;
    //STATS
    static private int kills;
    static private int disparos;
    static private int disparosAcertados;
    static private float tiempoPartida;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void sumardisparo() { disparos += 1; }
    public void sumardisparoAcertado() { disparosAcertados += 1; }
    public void sumarKill() { kills += 1; }

    public void settiempoP(float tiempo) { tiempoPartida = tiempo; }

    public float getTiempo() { return tiempoPartida; }

    public int getKills() { return kills; }

    public string getToken() { return token; }

    //skin
    public string getBody() { return body; }

    public string getTower() { return tower; }

    public string getTrack() { return track; }

    public string getBullet() { return bullet; }
    public string getNombre() { return nombre; }

    public int getid() { return id; }
    public int getDisparos() { return disparos; }

    public int getDisparosAcertados() { return disparosAcertados; }
    public void Stats(int fuerza, int vida, int vel, string torre, string b, string ruedas, string bala, string tok, int id2, string name) {
        strengh = fuerza;
        health = vida;
        speed = vel;
        tower = torre;
        body = b;
        track = ruedas;
        bullet = bala;
        token = tok;
        maxhealth = vida;
        id = id2;
        nombre = name;
    }

    public void StatsBase(int fuerza, int vida, int vel)
    {
        strengh = fuerza;
        health = vida;
        speed = vel;
        maxhealth = vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
