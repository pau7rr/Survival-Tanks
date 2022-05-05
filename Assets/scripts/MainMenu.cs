using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject music;
    public GameObject modal;
    public GameObject botonMulti;
    public GameObject botonsi;
    public GameObject botonno;
    int guardado;
    void Start()
    {
         guardado = SaveGame.Load<int>("guardado");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
        if (guardado == 1) { modal.SetActive(true); botonMulti.SetActive(false); botonno.SetActive(true); botonsi.SetActive(true); } else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void CargarPartida()
    {
        //check de la musica
        if (GameObject.Find("MenuMusic") != null)
        {
            music = GameObject.Find("MenuMusic");
        }
        if (GameObject.Find("MenuMusic(Clone)") != null)
        {
            music = GameObject.Find("MenuMusic(Clone)");
        }
        Destroy(music);
        int mapa = SaveGame.Load<int>("mapa");
        SceneManager.LoadScene(mapa);
    }
    public void QuitarDatos()
    {
        SaveGame.Save<int>("guardado", 0);
        SceneManager.LoadScene(2);
    }

    public void Tuto()
    {
        SceneManager.LoadScene(13);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Multi()
    {
        SceneManager.LoadScene(7);
    }

    public void Logout()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); 
    }
}
