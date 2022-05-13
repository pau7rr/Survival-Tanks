using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class SkinBalaEnemigo2: MonoBehaviour
{
    int tipo;
    public SpriteRenderer bala;
    DatosEnemigosParseado de = new DatosEnemigosParseado();
    private Sprite[] spriteArray;
    string bullet;
    // Start is called before the first frame update
    void Awake()
    {

        bullet = de.getE2().bullet.Split('/')[4];
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
