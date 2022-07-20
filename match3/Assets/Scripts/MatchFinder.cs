using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchFinder : MonoBehaviour
{
    private Board _board;
    [SerializeField] private List<Gem> _currentMatches = new List<Gem>(); 
    private void Awake()
    {
        _board = FindObjectOfType<Board>();
    }

    public void FindAllMatches()
    {
        for (int i = 0; i < _board.XSize; i++)
        {
            for (int j = 0; j < _board.YSize; j++)
            {
                Gem currentGem = _board.GemsOnBoard[i, j];

                if (currentGem != null)
                {
                    FindHorizontalMatches(i, j, currentGem);
                    FindVerticalMatches(i, j, currentGem);
                }
            }
        }

        if(_currentMatches.Count > 0)
            _currentMatches = _currentMatches.Distinct().ToList();
    }

    private void FindHorizontalMatches(int i, int j, Gem currentGem)
    {
        if (i > 0 && i < _board.XSize - 1)
        {
            Gem leftGem = _board.GemsOnBoard[i - 1, j];
            Gem rightGem = _board.GemsOnBoard[i + 1, j];

            if (leftGem != null && rightGem != null)
            {
                if (leftGem.Type == currentGem.Type && rightGem.Type == currentGem.Type)
                {
                    MatchGems(currentGem, leftGem, rightGem);
                    AddCurrentMatches(currentGem, leftGem, rightGem);
                }
            }
        }
    }

    private void FindVerticalMatches(int i, int j, Gem currentGem)
    {
        if (j > 0 && j < _board.YSize - 1)
        {
            Gem aboveGem = _board.GemsOnBoard[i, j - 1];
            Gem belowGem = _board.GemsOnBoard[i, j + 1];

            if (aboveGem != null && belowGem != null)
            {
                if (aboveGem.Type == currentGem.Type && belowGem.Type == currentGem.Type)
                {
                    MatchGems(currentGem, aboveGem, belowGem);
                    AddCurrentMatches(currentGem, aboveGem, belowGem);
                }
            }
        }
    }

    private void AddCurrentMatches(Gem gem1, Gem gem2, Gem gem3)
    {
        _currentMatches.Add(gem1);
        _currentMatches.Add(gem2);
        _currentMatches.Add(gem3);
    }

    private void MatchGems(Gem gem1, Gem gem2, Gem gem3)
    {
        gem1.IsMatched = true;
        gem2.IsMatched = true;
        gem3.IsMatched = true;
    }

}
