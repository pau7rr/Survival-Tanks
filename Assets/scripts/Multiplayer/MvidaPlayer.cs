using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MvidaPlayer : MonoBehaviour
{
    public float vida = TankStats.health;
    public int monedas = 0;
    public TextMeshProUGUI textomonedas;
    public Image barraDeVida;
    public PhotonView pv;
    //contador
    private float minutos;
    TankStats ts = new TankStats();
    void Start()
    {
        vida = TankStats.health;
        vida = Mathf.Clamp(vida, 0, TankStats.health);
        barraDeVida = GameObject.FindGameObjectWithTag("vida").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    { // declarar valor de la vida, minimo y maximo
      //textomonedas.text = ""+monedas;
        if (pv.IsMine)
        {
            barraDeVida.fillAmount = Mathf.Clamp(vida / TankStats.health, 0, 1f);
            if (vida <= 0) { StartCoroutine(mandarMonedas()); ts.settiempoP(Time.timeSinceLevelLoad); StartCoroutine(mandarstats()); Deestroy(); }
        }


    }

    [PunRPC]
    public void bajarvida(float daño) {
        if (pv.IsMine) {
            vida = vida - daño;
            
            Debug.LogWarning("klk");
        }
       
    }


    [PunRPC]
    private void Deestroy()
    {
        PhotonNetwork.Destroy(gameObject);
        Destroy(this.gameObject);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
    public IEnumerator mandarMonedas()
    {
        WWWForm form = new WWWForm();
        form.AddField("coins", monedas);
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
        }

    }

    public IEnumerator mandarstats()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", TankStats.id);
        form.AddField("round", GameObject.FindGameObjectWithTag("rondas").GetComponent<Rondas>().getrondas());
        form.AddField("kills", ts.getKills());
        form.AddField("time_played", (int)ts.getTiempo());
        form.AddField("shots", ts.getDisparos());
        form.AddField("successful_shots", ts.getDisparosAcertados());
        UnityWebRequest www = UnityWebRequest.Post("https://survival-tanks-api.herokuapp.com/api/updateSoloStats", form);
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
        }

    }


}
