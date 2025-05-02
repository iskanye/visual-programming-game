using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class MoneyTile : TileBase
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Money moneyPrefab;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = sprite;
        tileData.colliderType = Tile.ColliderType.Sprite;
        tileData.gameObject = moneyPrefab.gameObject;
    }

    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        if (go)
        {
            go.SetActive(Random.Range(0, 2) == 1);
        }
        return true;
    }
}
