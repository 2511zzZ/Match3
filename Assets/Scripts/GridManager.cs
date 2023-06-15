using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private GridTile gridTile;
    
    void Start()
    {
        GenerateGrid();   
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var relativeX = x - (float)(width - 1) / 2;
                var relativeY = y - (float)(height - 1) / 2;

                var tile = Instantiate(gridTile, new Vector3(relativeX, relativeY), Quaternion.identity);
                tile.name = $"Tile {x} {y}";
                var isAlterColor = (x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0);
                tile.SetAlterColor(isAlterColor);
            }
        }
    }
}
