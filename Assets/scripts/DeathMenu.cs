using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private GameObject player;
    public GameObject pane;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<vidaPlayer>().vida <= 0) { pane.SetActive(true); Time.timeScale = 0f; }
    }

    public void Reiniciar()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

    }

    public void Salir()
    {

        SceneManager.LoadScene(1);
    }
   
    public void Mapa()
    {
        SceneManager.LoadScene(2);
    }

}
