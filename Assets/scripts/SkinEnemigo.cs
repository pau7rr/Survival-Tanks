using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinEnemigo : MonoBehaviour
{
    public SpriteRenderer torreB;
    [SerializeField] public SpriteRenderer body;
    public SpriteRenderer torre;
    public SpriteRenderer gunconector;
    public SpriteRenderer rueda1;
    public SpriteRenderer rueda2;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private int contador = 0;
    private List<Sprite> sprites = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        TankStats ts = new TankStats();
        string bodyrute = ts.getBody().Split('/')[4];
        string towerroute = ts.getTower().Split('/')[4];
        string trackroute = ts.getTrack().Split('/')[4];

        Debug.LogWarning(bodyrute);
        AsyncOperationHandle<Sprite[]> body = Addressables.LoadAssetAsync<Sprite[]>(bodyrute);
        AsyncOperationHandle<Sprite[]> tower = Addressables.LoadAssetAsync<Sprite[]>(bodyrute);
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
            if (contador == 1) { ChangeTrackSprite(); }
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
