using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioSource coinsound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroycoin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.LogWarning("d");
            coinsound.Play();
            Destroy(this.gameObject);
            col.GetComponent<vidaPlayer>().monedas += 1;
        }
    }

    public IEnumerator Destroycoin()
    {

        yield return new WaitForSeconds(13f);
        Destroy(this.gameObject);
        

    }

}
