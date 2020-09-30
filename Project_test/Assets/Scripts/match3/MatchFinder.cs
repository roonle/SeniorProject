using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MatchFinder : MonoBehaviour
{
    public Board board;
    public List<GameObject> curMatches = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    public void findMatchStart()
    {
        StartCoroutine(findMatches());
    }
    // Update is called once per frame
    public IEnumerator findMatches()
    {
        yield return new WaitForSeconds(.2f);
        for (int i = 0; i < board.width; i++)
        {
            for (int x = 0; x < board.height; x++)
            {
                GameObject curDot = board.allDots[i, x];
                if (curDot != null)
                {
                    if (i > 0 && i < board.width -1)
                    {
                        GameObject leftDot = board.allDots[i-1, x];
                        GameObject rightDot = board.allDots[i + 1, x];
                        if (leftDot != null &&rightDot != null)
                        {
                            if (leftDot.tag == curDot.tag && rightDot.tag == curDot.tag)
                            {

                                if (curDot.GetComponent<Dot>().isRowBomb || leftDot.GetComponent<Dot>().isRowBomb || rightDot.GetComponent<Dot>().isRowBomb)
                                {
                                    curMatches.Union(getRowDots(x));
                                    Debug.Log(getRowDots(x));
                                }

                                if (curDot.GetComponent<Dot>().isColBomb)
                                {
                                    curMatches.Union(getColumnDots(i));
                                       
                                }
                                if (leftDot.GetComponent<Dot>().isColBomb)
                                {
                                    curMatches.Union(getColumnDots(i-1));

                                }
                                if (rightDot.GetComponent<Dot>().isColBomb)
                                {
                                    curMatches.Union(getColumnDots(i+1));

                                }

                                if (!curMatches.Contains(leftDot))
                                {
                                    curMatches.Add(leftDot);
                                }
                                leftDot.GetComponent<Dot>().isMatched = true;
                                if (!curMatches.Contains(rightDot))
                                {
                                    curMatches.Add(rightDot);
                                }
                                rightDot.GetComponent<Dot>().isMatched = true;
                                if (!curMatches.Contains(curDot))
                                {
                                    curMatches.Add(curDot);
                                }
                                curDot.GetComponent<Dot>().isMatched = true;
                            }
                        }
                    }
                    if (x > 0 && x < board.height - 1)
                    {
                        GameObject upDot = board.allDots[i, x +1];
                        GameObject downDot = board.allDots[i, x-1];
                        if (upDot != null && downDot != null)
                        {
                            if (upDot.tag == curDot.tag && downDot.tag == curDot.tag)
                            {

                                if (curDot.GetComponent<Dot>().isColBomb || upDot.GetComponent<Dot>().isColBomb || downDot.GetComponent<Dot>().isColBomb)
                                {
                                    curMatches.Union(getColumnDots(i));
                                    Debug.Log(getColumnDots(i));
                                }

                                if (curDot.GetComponent<Dot>().isRowBomb)
                                {
                                    curMatches.Union(getRowDots(x));

                                }
                                if (downDot.GetComponent<Dot>().isRowBomb)
                                {
                                    curMatches.Union(getRowDots(x-1));

                                }
                                if (upDot.GetComponent<Dot>().isRowBomb)
                                {
                                    curMatches.Union(getRowDots(x+1));

                                }

                                if (!curMatches.Contains(upDot))
                                {
                                    curMatches.Add(upDot);
                                }
                                upDot.GetComponent<Dot>().isMatched = true;
                                if (!curMatches.Contains(downDot))
                                {
                                    curMatches.Add(downDot);
                                }
                                downDot.GetComponent<Dot>().isMatched = true;
                                if (!curMatches.Contains(curDot))
                                {
                                    curMatches.Add(curDot);
                                }
                                curDot.GetComponent<Dot>().isMatched = true;
                            }
                        }
                    }
                }
            }
        }
    }

    List<GameObject> getColumnDots(int column)
    {
        List<GameObject> dot = new List<GameObject>();
        for (int x = 0; x < board.height; x++)
        {
            if (board.allDots[column, x] != null)
            {
                dot.Add(board.allDots[column, x]);
                board.allDots[column, x].GetComponent<Dot>().isMatched = true;
            }
        }

            return dot;
    }

    List<GameObject> getRowDots(int row)
    {
        List<GameObject> dot = new List<GameObject>();
        for (int x = 0; x < board.width; x++)
        {
            if (board.allDots[x, row] != null)
            {
                dot.Add(board.allDots[x, row]);
                board.allDots[x, row].GetComponent<Dot>().isMatched = true;
            }
        }

        return dot;
    }

    public void checkBombs()
    {
        if (board.curDot.isMatched)
        {
            board.curDot.isMatched = false;
            int bombType = Random.Range(0, 50);
            if (bombType < 25)
            {
                board.curDot.makeRowBomb();
            }
            else if (bombType >= 25)
            {
                board.curDot.makeColBomb();
            }
            
        }
        else if (board.curDot.otherDot != null)
        {
            Dot otherDot = board.curDot.otherDot.GetComponent<Dot>();
            if (otherDot.isMatched)
            {
                otherDot.isMatched = false;
                int bombType = Random.Range(0, 50);
                if (bombType < 25)
                {
                    otherDot.makeRowBomb();
                }
                else if (bombType >= 25)
                {
                    otherDot.makeColBomb();
                }
            }
        }
    }
}
