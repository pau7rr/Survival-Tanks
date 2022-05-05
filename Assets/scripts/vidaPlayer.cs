
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BayatGames.SaveGameFree;
public class vidaPlayer : MonoBehaviour
{
    public float vida = TankStats.health;
    public int monedas = 0;
    public TextMeshProUGUI textomonedas;
    public Image barraDeVida;
    public Transform t;
    //contador
    private float minutos;
    TankStats ts = new TankStats();
    void Start()
    {
        vida = TankStats.health;
        //Cargar datos
        if (SaveGame.Load<int>("guardado") == 1) { vida = SaveGame.Load<float>("vida"); t.position = SaveGame.Load<Vector3>("pos"); monedas = SaveGame.Load<int>("monedas"); }
        vida = Mathf.Clamp(vida, 0, TankStats.health);
        barraDeVida = GameObject.FindGameObjectWithTag("vida").GetComponent<Image>();
        
    }
    // Update is called once per frame
    void Update()
    { // declarar valor de la vida, minimo y maximo
        textomonedas.text = ""+monedas;
        barraDeVida.fillAmount = Mathf.Clamp(vida / TankStats.health, 0, 1f);
        if (vida <= 0) {  StartCoroutine(mandarMonedas()); StartCoroutine(mandarstats()); SaveGame.Save<int>("guardado", 0); Destroy(this.gameObject); }

     

    }

    [PunRPC]
    public void bajarvida(float daño) { vida = vida - daño; }
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
        }

    }

    public IEnumerator mandarstats()
    {
        //variables
        int rondas = GameObject.FindGameObjectWithTag("rondas").GetComponent<Rondas>().getrondas();
        int kills = ts.getKills();
        int disparos = ts.getDisparos();
        int disparosA = ts.getDisparosAcertados();
        WWWForm form = new WWWForm();
        form.AddField("user_id", TankStats.id);
        form.AddField("round", rondas);
        form.AddField("kills", kills);
        form.AddField("time_played", 5 );
        form.AddField("shots", disparos);
        form.AddField("successful_shots", disparosA);
        Debug.LogWarning(TankStats.id);
        Debug.LogWarning(rondas);
        Debug.LogWarning(kills);
        Debug.LogWarning(disparosA);
        Debug.LogWarning(disparos);
        // Debug.LogWarning(TankStats.id, );
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
