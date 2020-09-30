using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public enum gameTime
    {
        waiting, moving
    }

    public gameTime currentTime = gameTime.moving;
    public int width, height;
    private BackgroundTile[,] allTiles;
    public GameObject[] dots;
    public GameObject[,] allDots;
    public GameObject tilePrefab;
    public Dot curDot;
    public int offset;
    int max = 100;
    int j = 0;

    private ScoreText score;
    public int scorePiece;
    public int streak;
    public MatchFinder matchFinder;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreText>();
        matchFinder = FindObjectOfType<MatchFinder>();
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        
        setUp();
    }

    public void setUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int x=0; x< height; x++)
            {
                Vector2 tempPos = new Vector2(i, x + offset);
                GameObject bgTile = Instantiate(tilePrefab, tempPos ,Quaternion.identity) as GameObject;
                bgTile.transform.parent = this.transform;
                bgTile.name = "( " + i + ", " + x + " )";
                int dotUse = Random.Range(0, dots.Length);

                while (initMatches(i, x, dots[dotUse]) && j < max)
                {
                    j++;
                    dotUse = Random.Range(0, dots.Length);
                }
                j = 0;
                GameObject dot = Instantiate(dots[dotUse], tempPos, Quaternion.identity);
                dot.GetComponent<Dot>().column = i;
                dot.GetComponent<Dot>().row = x;
                dot.transform.parent = this.transform;
                dot.name = "( " + i + ", " + x + " )";
                allDots[i, x] = dot;
            }
        }
    }

    private bool initMatches(int col, int row, GameObject piece)
    {
        if (col > 1 && row > 1)
        {
            if (allDots[col -1, row].tag == piece.tag && allDots[col -2, row].tag ==piece.tag)
            {
                return true;
            }
            if (allDots[col, row-1].tag == piece.tag && allDots[col, row-2].tag == piece.tag)
            {
                return true;
            }
        }
        else if (col <= 1 || row <= 1)
        {
            if (row > 1)
            {
                if (allDots[col, row - 1].tag == piece.tag && allDots[col, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (col > 1)
            {
                if (allDots[col - 1, row].tag == piece.tag && allDots[col - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Destroy1(int col, int row)
    {
        if (allDots[col, row].GetComponent<Dot>().isMatched)
        {
            if (matchFinder.curMatches.Count == 4 || matchFinder.curMatches.Count == 7)
            {
                matchFinder.checkBombs();
            }
            matchFinder.curMatches.Remove(allDots[col, row]);
            score.incScore(10 * streak);
            Destroy(allDots[col, row]);
            allDots[col, row] = null;
        }
    }

    public void destroyMatch()
    {
        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                if (allDots[i, x] != null)
                {
                    Destroy1(i, x);
                }
            }
        }
        StartCoroutine(shiftRow());
    }

    private IEnumerator shiftRow()
    {
        int nullCount = 0;
        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                if (allDots[i, x] == null)
                {
                    nullCount++;
                }
                else if (nullCount > 0)
                {
                    allDots[i, x].GetComponent<Dot>().row -= nullCount;
                    allDots[i, x] = null;
                }
            }
            nullCount = 0;
        }
        
        yield return new WaitForSeconds(.4f);
        StartCoroutine(FillBoard());

    }

    public void refill()
    {
        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                if (allDots[i, x] == null)
                {
                    Vector2 temp = new Vector2(i, x + offset);
                    int dotUse = Random.Range(0, dots.Length);
                    GameObject gamePiece = Instantiate(dots[dotUse], temp, Quaternion.identity);
                    allDots[i, x] = gamePiece;
                    gamePiece.GetComponent<Dot>().column = i;
                    gamePiece.GetComponent<Dot>().row = x;
                }
            }
        }
    }

    public bool Matched()
    {
        for (int i = 0; i < width; i++)
        {
            for (int x = 0; x < height; x++)
            {
                if (allDots[i, x] != null)
                {
                    if (allDots[i, x].GetComponent<Dot>().isMatched)
                    {
                        return true;
                    }
                    
                }
            }
        }
        return false;
    }

    public IEnumerator FillBoard()
    {
        refill();
        yield return new WaitForSeconds(.5f);
        while (Matched())
        {
            streak ++;
            score.setStreak(streak);
            yield return new WaitForSeconds(.5f);
            destroyMatch();
        }
        matchFinder.curMatches.Clear();
        curDot = null;
        yield return new WaitForSeconds(.5f);
        currentTime = gameTime.moving;
        streak = 1;
        score.setStreak(streak);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
