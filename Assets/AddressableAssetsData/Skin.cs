using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Skin : MonoBehaviour
{
    public SpriteRenderer torreB;
    public SpriteRenderer body;
    public SpriteRenderer torre;
    public SpriteRenderer gunconector;
    public SpriteRenderer rueda1;
    public SpriteRenderer rueda2;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    void Start()
    {
        TankStats ts = new TankStats();
        
        AsyncOperationHandle<Sprite[]> body = Addressables.LoadAssetAsync<Sprite[]>("Assets/assets/TankConstructor/Images/Towers/HeavyTowerA.png");
        body.Completed += LoadSpritesWhenReady;

        /*
        Addressables.LoadAssetsAsync<Sprite>("MySprites", sprite =>
        {
            ts.getBody();
            // Unused area
        }).Completed += DidLoad;*/
    }
    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            spriteArray = handleToCheck.Result;
            ChangeSprite();
        }
    }



    void ChangeSprite()
    {
        body.sprite = spriteArray[0];
    }

    private void DidLoad(AsyncOperationHandle<IList<Sprite>> iListOfSprites)
    {
        foreach (var item in iListOfSprites.Result)
        {
            Debug.Log("ITEM NAME IS: " + item.name.ToString());
        }
    }

    }
