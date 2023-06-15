using UnityEngine;

public class GridIcon : MonoBehaviour
{
    public int X, Y;
    public GameObject IconPrefab;
    public int PrefabType;

    public Vector2 Position => new(X, Y);


    public void Eliminate()
    {
        
    }
}