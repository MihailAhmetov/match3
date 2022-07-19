using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _xSize;
    [SerializeField] private int _ySize;

    [SerializeField] private GameObject _backgroundTileTemplate;

    [SerializeField] private Gem[] _availableGemTemplates;
    [SerializeField] private Gem[,] _gemsOnBoard;

    private void Start()
    {
        _gemsOnBoard = new Gem[_xSize, _ySize];

        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < _xSize; i++)
        {
            for (int j = 0; j < _ySize; j++)
            {
                Vector2 position = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(_backgroundTileTemplate, position, Quaternion.identity);

                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = $"BG Tile - {i}, {j}";

                SpawnGem(new Vector2Int(i, j));
            }
        }
    }

    private void SpawnGem(Vector2Int position)
    {
        int gemToUseIndex = Random.Range(0, _availableGemTemplates.Length);
        Gem gem = Instantiate(_availableGemTemplates[gemToUseIndex], new Vector3(position.x, position.y, 0f), Quaternion.identity);

        gem.transform.parent = this.transform;
        gem.name = $"BG Tile - {position.x}, {position.y}";

        _gemsOnBoard[position.x, position.y] = gem;

        gem.SetupGem(position, this);
    }
}
