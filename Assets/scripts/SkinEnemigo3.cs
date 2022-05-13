using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinEnemigo3 : MonoBehaviour
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
        bodyrute = de.getE3().body.Split('/')[6];
        towerroute = de.getE3().tower.Split('/')[6];
        trackroute = de.getE3().track.Split('/')[6];

        AsyncOperationHandle<Sprite[]> body2 = Addressables.LoadAssetAsync<Sprite[]>(bodyrute);
        AsyncOperationHandle<Sprite[]> tower2 = Addressables.LoadAssetAsync<Sprite[]>(towerroute);
        AsyncOperationHandle<Sprite[]> track2 = Addressables.LoadAssetAsync<Sprite[]>(trackroute);
        body2.Completed += LoadSpritesWhenReady;
        tower2.Completed += LoadSpritesWhenReady;
        track2.Completed += LoadSpritesWhenReady;
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
