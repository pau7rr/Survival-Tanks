using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DatosEnemigosParseado
{
    private static EnemyStat normal;
    private static EnemyStat pequeño;
    private static EnemyStat pesado;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setEnemys(EnemyStat e1, EnemyStat e2 , EnemyStat e3) {
        normal = e1;
        pequeño = e2;
        pesado = e3;
    }

    public EnemyStat getE1() {
        return normal;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
