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

    private MatchFinder _matchFinder;

    public int XSize => _xSize;
    public int YSize => _ySize;
    public Gem[,] GemsOnBoard => _gemsOnBoard;

    private void Awake()
    {
        _matchFinder = FindObjectOfType<MatchFinder>();
    }

    private void Start()
    {
        _gemsOnBoard = new Gem[_xSize, _ySize];

        GenerateBoard();
    }

    private void Update()
    {
        _matchFinder.FindAllMatches();
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

                int gemToUseIndex = Random.Range(0, _availableGemTemplates.Length);
                
                int iteraions = 0;
                while (CheckStartMatches(new Vector2Int(i,j), _availableGemTemplates[gemToUseIndex]))
                {
                    gemToUseIndex = Random.Range(0, _availableGemTemplates.Length);
                    iteraions++;
                    //Debug.Log(iterations);
                }

                SpawnGem(new Vector2Int(i, j), gemToUseIndex);
            }
        }
    }

    private void SpawnGem(Vector2Int position, int gemToUseIndex)
    {
        Gem gem = Instantiate(_availableGemTemplates[gemToUseIndex], new Vector3(position.x, position.y, 0f), Quaternion.identity);

        gem.transform.parent = this.transform;
        gem.name = $"Gem - {position.x}, {position.y}";

        _gemsOnBoard[position.x, position.y] = gem;

        gem.SetupGem(position, this);
    }

    private bool CheckStartMatches(Vector2Int positionToCheck, Gem gemToCheck)
    {
        if (positionToCheck.x > 1)
        {
            if (_gemsOnBoard[positionToCheck.x - 1, positionToCheck.y].Type == gemToCheck.Type &&
                    _gemsOnBoard[positionToCheck.x - 2, positionToCheck.y].Type == gemToCheck.Type)
                return true;
        }

        if (positionToCheck.y > 1)
        {
            if (_gemsOnBoard[positionToCheck.x, positionToCheck.y - 1].Type == gemToCheck.Type &&
                    _gemsOnBoard[positionToCheck.x, positionToCheck.y - 2].Type == gemToCheck.Type)
                return true;
        }

        return false;
    }

   
}