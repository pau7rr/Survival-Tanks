using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vidaPlayer : MonoBehaviour
{
    public float vida = TankStats.health;
    public int monedas = 0;
    public TextMeshProUGUI textomonedas;
    public Image barraDeVida;
    void Start()
    {
        vida = TankStats.health;
        vida = Mathf.Clamp(vida, 0, TankStats.health);
        barraDeVida = GameObject.FindGameObjectWithTag("vida").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    { // declarar valor de la vida, minimo y maximo
        textomonedas.text = ""+monedas;
        barraDeVida.fillAmount = Mathf.Clamp(vida / TankStats.health, 0, 1f);
        if (vida <= 0) { Destroy(this.gameObject); StartCoroutine(mandarMonedas()); SceneManager.LoadScene(1); }
    }



    public IEnumerator mandarMonedas()
    {
        WWWForm form = new WWWForm();
        form.AddField("coins",monedas);
        UnityWebRequest www = UnityWebRequest.Post("https://survival-tanks-api.herokuapp.com/api/user/addCoins", form);
        www.SetRequestHeader("Authorization", "Bearer " + TankStats.token);
        yield return www.Send();

        if (www.error != null)
        {
            Debug.LogWarning("Error" + www.error);
        }
        else
        {
            string respuesta = www.downloadHandler.text;
            Debug.LogWarning(respuesta);
            yield return  new WaitForSeconds(4f);
        }

    }


}
