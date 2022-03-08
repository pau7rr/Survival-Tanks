using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIdisparo : MonoBehaviour
{
    public float tiempoentredisparos ;
    public GameObject bala;
    public float start_tiempoentredisparos ;
    public GameObject jugador;
    public float bulledspeed = 17f;
    public Transform spawnbala;
    public Transform spawnbala2;
    public bool disparodoble;
    private Camera camara;
    //calcular distancia
    float distanciaDisparo;
    float maxx;
    float maxy;
    // Start is called before the first frame update
    void Start()
    {
        tiempoentredisparos = start_tiempoentredisparos;
        jugador = GameObject.FindGameObjectWithTag("Player");
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per fra
    void Update()
    {
        //SI LA CAMARA VE EL ENEMIGO DISPARA
        Vector3 viewPos = camara.WorldToViewportPoint(this.transform.position);
       
            if (viewPos.x <= 1 && viewPos.x >= 0 && viewPos.y <= 1 && viewPos.y >= 0) {
           
            if (tiempoentredisparos <= 0)
            {
                if (!disparodoble)
                {
                    GameObject balaspawned = Instantiate(bala, spawnbala.position, spawnbala.rotation);
                    Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
                    cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
                }
                else
                {
                    GameObject balaspawned = Instantiate(bala, spawnbala.position, spawnbala.rotation);
                    Rigidbody2D cuerpo = balaspawned.GetComponent<Rigidbody2D>();
                    cuerpo.AddForce(spawnbala.up * bulledspeed, ForceMode2D.Impulse);
                    //bala 2

                    GameObject balaspawned2 = Instantiate(bala, spawnbala2.position, spawnbala2.rotation);
                    Rigidbody2D cuerpo2 = balaspawned2.GetComponent<Rigidbody2D>();
                    cuerpo2.AddForce(spawnbala2.up * bulledspeed, ForceMode2D.Impulse);

                }

                tiempoentredisparos = start_tiempoentredisparos;
            }
            else
            {
                tiempoentredisparos -= Time.deltaTime;
            }
        }
       
    }

    private bool IsVisible(Camera c) {
        Debug.LogWarning("dispara");
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) > 0)
            {
                return false;
            }
            else { return true; }
        }
        return false;
    }

}
