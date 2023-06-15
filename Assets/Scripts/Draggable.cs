using System;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 _startPosition;


    private void OnMouseDown()
    {
        _startPosition = transform.position;
    }

    private void OnMouseUp()
    {
        var endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var (dx, dy) = NormalizeDrag(_startPosition, endPosition);
        var currentIcon = GetComponent<GridIcon>();
        var targetIcon = BoardManager.Instance.GetByIndex(currentIcon.X + dx, currentIcon.Y + dy);
        if (targetIcon != null)
        {
            BoardManager.Instance.Swap(gameObject.GetComponent<GridIcon>(), targetIcon);   
        }
    }

    private (int, int) NormalizeDrag(Vector2 startPosition, Vector2 endPosition)
    {
        var move = endPosition - startPosition;
        var absX = Math.Abs(move.x);
        var absY = Math.Abs(move.y);
        if (absX > absY)
        {
                return move.x < 0 ? (-1, 0) : (1, 0);
        }

        return move.y < 0 ? (0, -1) : (0, 1);
    }
}
