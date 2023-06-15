using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private GameObject[] iconPrefabs;
    
    private IconTable _iconTable;
    
    private static BoardManager _instance;
    public static BoardManager Instance
    {
        get
        {
            if (_instance) return _instance;
            _instance = FindObjectOfType<BoardManager>();
            return _instance;
        }
    }

    private void Start()
    {
        CameraAlign();
        BoardSetup();
    }

    void CameraAlign()
    {
        Camera.main.transform.position = new Vector3((float)(width - 1) / 2, (float)(height - 1) / 2, -10);
    }

    void BoardSetup()
    {
        _iconTable = new IconTable(width, height);
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var index = Random.Range(0, iconPrefabs.Length);
                var iconPrefab = iconPrefabs[index];
                _iconTable.InstantiateByIndex(x, y, iconPrefab, index);
            }
        }
    }


    public GridIcon GetByIndex(int x, int y)
    {
        return null;
    }

    public void Swap(GridIcon o1, GridIcon o2)
    {
        UpdateIndex(o1, o2.X, o2.Y);
        Match();
    }

    private bool Match()
    {
        return false;
    }

    void UpdateIndex(GridIcon gi, int newX, int newY)
    {
    }


    class IconTable
    {
        private readonly GridIcon[,] _table;

        private readonly int _width, _height;

        public IconTable(int width, int height)
        {
            _width = width;
            _height = height;
            _table = new GridIcon[width, height];
        }
        
        public bool Swap(int x, int y, GridIcon source)
        {
            if (x >= _width || y >= _height)
            {
                return false;
            }

            var target = _table[x, y];
            
            (source.X, source.Y, target.X, target.Y) = (target.X, target.Y, source.X, source.Y);
            
            var sourceTransform = source.transform;
            var targetTransform = target.transform;
            (sourceTransform.position, targetTransform.position) = (targetTransform.position, sourceTransform.position);
            
            return true;
        }

        public GridIcon InstantiateByIndex(int x, int y, GameObject iconPrefab, int iconType)
        {
            var iconGo = Instantiate(iconPrefab, new Vector2(x, y), Quaternion.identity);
            iconGo.transform.SetParent(BoardManager.Instance.transform);
            var gridIcon = iconGo.GetComponent<GridIcon>();
            gridIcon.X = x;
            gridIcon.Y = x;
            gridIcon.PrefabType = iconType;
            _table[x, y] = gridIcon;
            return gridIcon;
        }
    }
}