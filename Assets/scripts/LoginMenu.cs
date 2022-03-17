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
public class LoginMenu : MonoBehaviour
{
   // public InputField user;
    public TextMeshProUGUI user;
    public TextMeshProUGUI contraseña;
    public GameObject contra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        //SceneManager.LoadScene(1);
        if (user.text != null && contraseña.text != null) {
            
            Debug.Log(contra.GetComponent<TMP_InputField>().text);
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
        }
        else {
            string respuesta = www.downloadHandler.text;
            Debug.LogWarning(respuesta);
           string[] token = respuesta.Split('"');
            Debug.LogWarning("TOKEN:: " + token[7]);
            if (respuesta.Contains("\"success\":true")) { StartCoroutine(TankSetup(token[7]));}
            
        }

    }


    public IEnumerator TankSetup(string token)
    {
        Debug.LogWarning(token);
        UnityWebRequest request = UnityWebRequest.Get("https://survival-tanks-api.herokuapp.com/api/usertank");
        request.SetRequestHeader("Authorization", "Bearer " + token );
        // request.SetRequestHeader("Authorization", "Bearer " + "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiI3MSIsImp0aSI6IjFmZTBjMWViZWU4YTUyM2M2ODU1NGJlYmU0NDc0YjFiNTM2YzQ0NDJiNzlkMGU5MDVkY2E5MDRkMGNhNDYyYjBjMGFiNjZlZGNhYTM4MWMyIiwiaWF0IjoxNjQ1MTk1MTEzLjU3MzMzMSwibmJmIjoxNjQ1MTk1MTEzLjU3MzMzNSwiZXhwIjoxNjc2NzMxMTEzLjU1OTQzNywic3ViIjoiNDMxIiwic2NvcGVzIjpbXX0.Qs8Kzuzux4b-8yNNWdiCDtU8QfEaF84-qp7xxqU2nsoI3LYfyGGhuzCGZuuPvXAdw0q5F1PqM2qUrdjTIDQKKOsAy2SwocMHhMXtbbpDHyFkCiY5vs9KMj0N3nusGQxp79j4mnKdRpqZC5r7hr0iRcwsxqcLqXYc0QN9h1iLgbV3DK4TQCvItixg8A9fMpaOOP4nqahcxmEUuACIuuuL43vJKsX0VuoEUIdAgC5BpGXN3I8Q4kOmtR9DLgBgzGPTLriTw62jL_fsFc_cKvQx0-53qLdWfyJYXM8VFmTYk9HD3x1puRNPiDp4Yv64VEUB8ZTO_n_i9fZs0HzNHL-N8l2qvEpL7sLM0dEdoMu2j6Jq6ZXLxe1fWquikWYGSEA1YKgGxXErw03_AGlIb8B3gPWlq2GNZeMgKpWH_iDEPqSIInPCpLlkZESOMkffKbvIS99FQpEgYoItAKemDAAOjUTAiV95DHJNEfZ2yXu0ne867Z2-fXFUN1d13NnxN-MyCLXUzENrd1ZhX1oVDgkfC7IP7ezU8WURLD09w_oFWywrvtALamTf_buk-r6_jhzkp6VkYAmBmqgLqlaDwS4AMSoz4eO0qZBk4bSuDGktzu358lhCJ45BEoyF0H96puNnmlBgcGojzIABnaFFScOYhSKaF7YNevuusO7zw-T8YAw");
        yield return request.Send();

        if (request.error != null)
        {
            Debug.LogWarning("Error" + request.error);
        }
        else
        {
            string respuesta = request.downloadHandler.text;
            Debug.LogWarning(respuesta);
            TankPlayer tank = new TankPlayer();
            tank = JsonUtility.FromJson<TankPlayer>(respuesta);
            TankStats player = new TankStats();
            player.Stats(tank.strengh,tank.health,tank.speed,tank.tower,tank.body,tank.track, tank.bullet ,token, tank.id);
            Debug.LogWarning(TankStats.id);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(1);
        }

    }
}


