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
                    if (i > 0 && i < _board.XSize - 1)
                    {
                        Gem leftGem = _board.GemsOnBoard[i - 1, j];
                        Gem rightGem = _board.GemsOnBoard[i + 1, j];

                        if(leftGem != null && rightGem != null)
                        {
                            if(leftGem.Type == currentGem.Type && rightGem.Type == currentGem.Type)
                            {
                                currentGem.IsMatched = true;
                                leftGem.IsMatched = true;
                                rightGem.IsMatched = true;
                            }
                        }
                    }
                }
            }
        }
    }

    
}
