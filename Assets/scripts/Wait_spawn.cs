using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait_spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        
        
    }

    // Update is called once per frame
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = true;
        }
    }
    }
