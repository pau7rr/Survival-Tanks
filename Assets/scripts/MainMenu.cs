using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject music;
    void Start()
    {
        if (GameObject.Find("MenuMusic") == null)
        {
            Debug.LogWarning("Creamos musica");
            Instantiate(music);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        SceneManager.LoadScene(2);
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
