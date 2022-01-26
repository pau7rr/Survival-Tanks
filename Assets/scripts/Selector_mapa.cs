using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_mapa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void desierto() {

        SceneManager.LoadScene(3);
    }
    public void volver()
    {

        SceneManager.LoadScene(1);
    }

    public void Bosque()
    {

        SceneManager.LoadScene(6);
    }
    public void Mazzmorra()
    {

        SceneManager.LoadScene(5);
    }
    public void Pueblo()
    {

        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
