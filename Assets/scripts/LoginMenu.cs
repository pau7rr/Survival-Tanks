using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System;

public class LoginMenu : MonoBehaviour
{
   // public InputField user;
    public TextMeshProUGUI user;
    public TextMeshProUGUI contraseña;
    public GameObject contra;
    public Animator iconAnimator;
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MenuMusic(Clone)") == null)
        {
            Instantiate(music);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        //SceneManager.LoadScene(1);
        if (user.text != null && contraseña.text != null) {
            iconAnimator.Play("In");
            StartCoroutine(CallLogin(user.text, contra.GetComponent<TMP_InputField>().text));
            
        }
       
    }
    public IEnumerator CallLogin(string User, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", User.TrimEnd('\u200b'));
        form.AddField("password", password.TrimEnd('\u200b'));
        UnityWebRequest www = UnityWebRequest.Post("https://survival-tanks-api.herokuapp.com/api/login", form);
        yield return www.Send ();
        
        if (www.error != null)
        {
            Debug.LogWarning("Error" + www.error);
            iconAnimator.Play("Out");
        }
        else {
            string respuesta = www.downloadHandler.text;
            string[] token = respuesta.Split('"');
            string id = token[12].TrimEnd(new Char[] { ',' }).TrimStart(new Char[] { ':' });
            if (respuesta.Contains("\"success\":true")) { StartCoroutine(TankSetup(token[7], token[15], System.Int32.Parse(id)));}
            
        }

    }


    public IEnumerator TankSetup(string token, string nombre, int id)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://survival-tanks-api.herokuapp.com/api/usertank");
        request.SetRequestHeader("Authorization", "Bearer " + token );
        yield return request.Send();

        if (request.error != null)
        {
            Debug.LogWarning("Error" + request.error);
        }
        else
        {
            string respuesta = request.downloadHandler.text;
            TankPlayer tank = new TankPlayer();
            tank = JsonUtility.FromJson<TankPlayer>(respuesta);
            TankStats player = new TankStats();
            player.Stats(tank.strengh,tank.health,tank.speed,tank.tower,tank.body,tank.track, tank.bullet ,token, id, nombre);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(TankEnemySetup());
        }

    }


    public IEnumerator TankEnemySetup()
    {
        string token = TankStats.token;
        UnityWebRequest request = UnityWebRequest.Get("https://survival-tanks-api.herokuapp.com/api/getAllTanks");
         yield return request.Send();

        if (request.error != null)
        {
            Debug.LogWarning("Error" + request.error);
        }
        else
        {
            string respuesta = request.downloadHandler.text;
            DatosEnemigos datos = new DatosEnemigos();
            datos = JsonUtility.FromJson<DatosEnemigos>(respuesta);
            //parseamos los datos
            DatosEnemigosParseado de = new DatosEnemigosParseado();
            de.setEnemys(datos.data[0], datos.data[1], datos.data[2]);
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(1);
        }

    }
}


