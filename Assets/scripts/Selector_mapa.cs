using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class Selector_mapa : MonoBehaviour
{
    GameObject music;
    public Animator iconAnimator;
    // Start is called before the first frame update
    void Start()
    {
        TankStats player = new TankStats();
        StartCoroutine(TankSetup(player.getToken(), player.getNombre(), player.getid()));
        if (GameObject.Find("MenuMusic(Clone)") == null)
        {
            Instantiate(music);
        }

        if (GameObject.Find("MenuMusic(Clone)") != null)
        {
            music = GameObject.Find("MenuMusic(Clone)");
        }

    }

    public void desierto() {
        Destroy(music);
        SceneManager.LoadScene(3);
    }
    public void volver()
    {
        SceneManager.LoadScene(1);
    }

    public void Bosque()
    {
        Destroy(music);
        SceneManager.LoadScene(6);
    }
    public void Mazzmorra()
    {
        Destroy(music);
        SceneManager.LoadScene(5);
    }
    public void Pueblo()
    {
        Destroy(music);
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator TankSetup(string token, string nombre, int id)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://survival-tanks-api.herokuapp.com/api/usertank");
        request.SetRequestHeader("Authorization", "Bearer " + token);
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
            player.Stats(tank.strengh, tank.health, tank.speed, tank.tower, tank.body, tank.track, tank.bullet, token, id, nombre);
        }

    }

}
