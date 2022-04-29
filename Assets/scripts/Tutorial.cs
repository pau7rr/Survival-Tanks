using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private GameObject[] enemigos;
   
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        Debug.LogWarning(enemigos.Length);
        if (enemigos.Length == 0)
        {

            SceneManager.LoadScene(1);
        }
        }
}
