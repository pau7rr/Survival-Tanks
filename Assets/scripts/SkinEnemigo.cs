using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinEnemigo : MonoBehaviour
{
    public SpriteRenderer body;
    public SpriteRenderer torre;
    public SpriteRenderer rueda1;
    public SpriteRenderer rueda2;
    public Sprite[] spriteArray;
    private int contador = 0;
   private string bodyrute;
    private string towerroute;
    private string trackroute;

    
    // Start is called before the first frame update
    void Start()
    {
        DatosEnemigosParseado de = new DatosEnemigosParseado();
   
            bodyrute = de.getE1().body.Split('/')[6];
            towerroute = de.getE1().tower.Split('/')[6];
            trackroute = de.getE1().track.Split('/')[6];
     
      //  Debug.LogWarning(bodyrute);
       
        AsyncOperationHandle<Sprite[]> body = Addressables.LoadAssetAsync<Sprite[]>(bodyrute);
        AsyncOperationHandle<Sprite[]> tower = Addressables.LoadAssetAsync<Sprite[]>(towerroute);
        AsyncOperationHandle<Sprite[]> track = Addressables.LoadAssetAsync<Sprite[]>(trackroute);
        body.Completed += LoadSpritesWhenReady;
        tower.Completed += LoadSpritesWhenReady;
        track.Completed += LoadSpritesWhenReady;
    }
    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
            contador += 1;
            if (contador == 1) { ChangeBodySprite(); }
            if (contador == 2) { ChangeTowerSprite(); }
            if (contador == 3) { ChangeTrackSprite(); }
        }
    }

    void ChangeBodySprite()
    {
        body.sprite = spriteArray[0];
    }

    void ChangeTowerSprite()
    {
        torre.sprite = spriteArray[0];
    }
    void ChangeTrackSprite()
    {
        rueda1.sprite = spriteArray[0];
        rueda2.sprite = spriteArray[0];
    }

}
