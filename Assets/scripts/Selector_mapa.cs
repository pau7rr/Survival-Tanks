using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_mapa : MonoBehaviour
{
    GameObject music;
    // Start is called before the first frame update
    void Start()
    {
       // music = GameObject.Find("MenuMusic");
        if (GameObject.Find("MenuMusic") != null)
        {
            music = GameObject.Find("MenuMusic");
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
}
