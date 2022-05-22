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
            player.Stats(tank.strengh, tank.health, tank.speed, tank.tower, tank.body, tank.track, tank.bullet, token, id, nombre);
        }

    }

}
