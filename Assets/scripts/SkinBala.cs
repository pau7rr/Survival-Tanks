using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinBala : MonoBehaviour
{
    public SpriteRenderer bala;
    private TankStats t = new TankStats();
    private Sprite[] spriteArray;
    // Start is called before the first frame update
    void Awake()
    {
      string bullet = t.getBullet().Split('/')[4];
        AsyncOperationHandle<Sprite[]> bulletS = Addressables.LoadAssetAsync<Sprite[]>(bullet);
        bulletS.Completed += LoadSpritesWhenReady;
    }

    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
            ChangeBulletSprite();
        }
    }

    void ChangeBulletSprite()
    {
        bala.sprite = spriteArray[0];
    }

}
