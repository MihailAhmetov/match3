using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFinder : MonoBehaviour
{
    private Board _board;

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
                    MatchGem(currentGem);
                    MatchGem(leftGem);
                    MatchGem(rightGem);
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
                    MatchGem(currentGem);
                    MatchGem(aboveGem);
                    MatchGem(belowGem);
                }
            }
        }
    }

    private void MatchGem(Gem gem)
    {
        gem.IsMatched = true;
    }

}
