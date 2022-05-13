using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkinEnemigo2 : MonoBehaviour
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
        Debug.LogWarning("tracj:" + de.getE2().body);
        Debug.LogWarning("trac2:" + de.getE2().body.Split('/')[6]);
        bodyrute = de.getE2().body.Split('/')[6];
        towerroute = de.getE2().tower.Split('/')[6];
        trackroute = de.getE1().track.Split('/')[6];

        Debug.LogWarning(bodyrute);

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
        Debug.LogWarning("cambiado body:");
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
