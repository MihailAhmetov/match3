using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GemType
{ 
    blue, 
    green, 
    purple, 
    red, 
    yellow 
} 
public abstract class Gem : MonoBehaviour
{
    [SerializeField] private Vector2Int _positionIndex;

    private Board _board;

    public GemType Type { get; protected set; }
    public bool IsMatched;

    private void OnMouseDown()
    {
        //Debug.Log(gameObject.name);
        DisableGem();
        //moveCount--
    }

    private void DisableGem()
    {
        gameObject.SetActive(false);
    }

    public void SetupGem(Vector2Int position, Board board)
    {
        _positionIndex = position;
        _board = board;
    }
}
