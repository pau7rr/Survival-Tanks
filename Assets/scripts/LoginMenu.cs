using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
   // public InputField user;
    public TextMeshProUGUI user;
    public TextMeshProUGUI contraseña;
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
        SceneManager.LoadScene(1);
        if (user.text != null && contraseña.text != null) {
            Debug.Log(user.text);
            //StartCoroutine(CallLogin(user.text, contraseña.text));
            
        }
       
    }
    public IEnumerator CallLogin(string User, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", User.TrimEnd('\u200b'));
        form.AddField("password", password.TrimEnd('\u200b'));
        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/api/login", form);
        yield return www.Send ();
        if (www.error != null)
        {
            Debug.LogWarning("Error" + www.error);
        }
        else {
            Debug.LogWarning("Response" + www.downloadHandler.text);
        }

    }
}


