using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public static bool Gamepause = false;
    public GameObject pausemenu;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Gamepause) { Resume(); } else {
                Pause();
            }
        }
    }

    void Pause() {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        player.GetComponent<player_move>().enabled = false;
        Gamepause = true;
    }


    public void Reiniciar()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        
    }

    public void Salir()
    {

        SceneManager.LoadScene(1);
    }
    public void Resume() {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        Gamepause = false;
        player.GetComponent<player_move>().enabled = true;
    }
}
