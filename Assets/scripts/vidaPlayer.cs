using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public float vida = 100;
    public int monedas = 0;
    public TextMeshProUGUI textomonedas;
    public Image barraDeVida;
    void Start()
    {

        vida = Mathf.Clamp(vida, 0, 100);
        barraDeVida = GameObject.FindGameObjectWithTag("vida").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    { // declarar valor de la vida, minimo y maximo
        textomonedas.text = ""+monedas;
        barraDeVida.fillAmount = Mathf.Clamp(vida / 100, 0, 1f);
        if (vida <= 0) { Destroy(this.gameObject); }
    }

}
