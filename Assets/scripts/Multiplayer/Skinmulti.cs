using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Photon.Pun;

public class Skinmulti : MonoBehaviour
{
    private PhotonView pv;
    public SpriteRenderer body;
    public SpriteRenderer torre;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private int contador = 0;
    void Start()
    {
        if (!pv.IsMine) { return; }
        TankStats ts = new TankStats();
        string bodyrute = ts.getBody().Split('/')[4];
        string towerroute = ts.getTower().Split('/')[4];
        AsyncOperationHandle<Sprite[]> body = Addressables.LoadAssetAsync<Sprite[]>(bodyrute);
        AsyncOperationHandle<Sprite[]> tower = Addressables.LoadAssetAsync<Sprite[]>(towerroute);
        body.Completed += LoadSpritesWhenReady;
        tower.Completed += LoadSpritesWhenReady;

    }


    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
            contador += 1;
            if (contador == 1) { ChangeBodySprite(); }
            if (contador == 2) { ChangeTowerSprite(); }
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
}
