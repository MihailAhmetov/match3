using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private Vector2Int _positionIndex;
    private Board _board;

    public void SetupGem(Vector2Int position, Board board)
    {
        _positionIndex = position;
        _board = board;
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        //disable gem
        //moveCount--
    }

    private void DisableGem()
    {

    }
}
