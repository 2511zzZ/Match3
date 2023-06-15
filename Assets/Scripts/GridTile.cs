using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [SerializeField] private Color baseColor, alterColor;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAlterColor(bool alter)
    {
        _spriteRenderer.color = alter ? alterColor : baseColor;
    }
}
