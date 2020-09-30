using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public int column, row;
    public int prevCol, prevRow;
    public int targetX, targetY;
    public GameObject otherDot;
    private Board board;
    private Vector2 firstClick;
    private Vector2 lastTouch;
    private Vector3 mousePos;
    private Vector2 tempPos;
    private float moveDirection = 0;
    public double moveResist = .01;
    public bool isMatched = false;
    public MatchFinder matchFinder;
    private ScoreText score;
    public bool isColBomb, isRowBomb;
    public GameObject colBomb, rowBomb;

    // Start is called before the first frame update


    /*public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRowBomb = true;
            GameObject bomb = Instantiate(rowBomb, transform.position, Quaternion.identity);
            bomb.transform.parent = this.transform;
            Debug.Log("bomb:" + bomb.transform.parent);
        }
    }*/
    void Start()
    {
        score = FindObjectOfType<ScoreText>();
        isColBomb = false;
        isRowBomb = false;
        board = FindObjectOfType<Board>();
        matchFinder = FindObjectOfType<MatchFinder>();
        /*targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
        prevRow = row;
        prevCol = column;*/
    }

    // Update is called once per frame
    void Update()
    {
        //findMatch();
        /*if (isMatched)
        {
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(0f, 0f, 0f, .2f);
        }*/
        targetX = column;
        targetY = row;
        if (Mathf.Abs(targetX - transform.position.x) > .1)
        {
            tempPos = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPos, .3f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
            matchFinder.findMatchStart();
        }
        else
        {
            tempPos = new Vector2(targetX, transform.position.y);
            transform.position = tempPos;
            //board.allDots[column, row] = this.gameObject;
        }
        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {
            tempPos = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPos, .3f);
            if (board.allDots[column, row] != this.gameObject)
            {
                board.allDots[column, row] = this.gameObject;
            }
            matchFinder.findMatchStart();
        }
        else
        {
            tempPos = new Vector2(transform.position.x, targetY);
            transform.position = tempPos;
            //board.allDots[column, row] = this.gameObject;
        }
    }

    private void OnMouseDown()
    {
        if (board.currentTime == Board.gameTime.moving)
        {
            mousePos = Input.mousePosition;
            mousePos.z = 1;
            firstClick = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(firstClick);
        }
    }

    private void OnMouseUp()
    {
        if (board.currentTime == Board.gameTime.moving)
        {
            mousePos = Input.mousePosition;
            mousePos.z = 1;
            lastTouch = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(lastTouch);
            score.updateTurns();
            calculateAngle();
        }
    }

    void calculateAngle()
    {
        if (Mathf.Abs(lastTouch.y - firstClick.y) > moveResist || Mathf.Abs(lastTouch.x - firstClick.x) > moveResist)
        {
            moveDirection = Mathf.Atan2(lastTouch.y - firstClick.y, lastTouch.x - firstClick.x) * 180 / Mathf.PI;
            moveDots();
            Debug.Log(moveDirection);
            board.curDot = this;
            board.currentTime = Board.gameTime.waiting;
        }
        else
        {
            board.currentTime = Board.gameTime.moving;
            
        }
    }

    void moveDots()
    {
        if (moveDirection> -45 && moveDirection <= 45 && column < board.width -1)
        {
            //move right
            otherDot = board.allDots[column + 1, row];
            prevRow = row;
            prevCol = column;
            otherDot.GetComponent<Dot>().column -= 1;
            column += 1;
        }
        else if (moveDirection > 45 && moveDirection <= 135 && column < board.height -1)
        {
            //move up
            otherDot = board.allDots[column, row +1];
            prevRow = row;
            prevCol = column;
            otherDot.GetComponent<Dot>().row -= 1;
            row += 1;
        }
        else if ((moveDirection > 135 || moveDirection <= -135) && column >0)
        {
            //Left right
            otherDot = board.allDots[column - 1, row];
            prevRow = row;
            prevCol = column;
            otherDot.GetComponent<Dot>().column += 1;
            column -= 1;
        }
        else if (moveDirection < -45 && moveDirection >= -135 && row > 0)
        {
            //move down
            otherDot = board.allDots[column, row-1];
            prevRow = row;
            prevCol = column;
            otherDot.GetComponent<Dot>().row += 1;
            row -= 1;
        }
        StartCoroutine(checkMove());
    }

    public void findMatch()
    {
        if (column > 0 && column < board.width -1)
        {
            GameObject leftDot = board.allDots[column - 1, row];
            GameObject rightDot = board.allDots[column + 1, row];
            if (leftDot != null && rightDot != null)
            {
                if (leftDot.tag == this.gameObject.tag && rightDot.tag == this.gameObject.tag)
                {
                    leftDot.GetComponent<Dot>().isMatched = true;
                    rightDot.GetComponent<Dot>().isMatched = true;
                    isMatched = true;
                }
            }
        }
        if (row > 0 && row < board.height -1)
        {
            GameObject upDot = board.allDots[column, row + 1];
            GameObject downDot = board.allDots[column, row - 1];
            if (upDot != null && downDot != null)
            {
                if (upDot.tag == this.gameObject.tag && downDot.tag == this.gameObject.tag)
                {
                    upDot.GetComponent<Dot>().isMatched = true;
                    downDot.GetComponent<Dot>().isMatched = true;
                    isMatched = true;
                }
            }
        }
    }

    public IEnumerator checkMove()
    {
        yield return new WaitForSeconds(.5f);
        if (otherDot != null)
        {
            if (!isMatched && !otherDot.GetComponent<Dot>().isMatched)
            {
                otherDot.GetComponent<Dot>().row = row;
                otherDot.GetComponent<Dot>().column = column;
                row = prevRow;
                column = prevCol;
                yield return new WaitForSeconds(.5f);
                board.curDot = null;
                board.currentTime = Board.gameTime.moving;
            }
            else
            {
                board.destroyMatch();
            }
            //otherDot = null;
        }
        
    }

    public void makeRowBomb()
    {
        isRowBomb = true;
        GameObject bomb = Instantiate(rowBomb, transform.position, Quaternion.identity);
        bomb.transform.parent = this.transform;
    }

    public void makeColBomb()
    {
        isColBomb = true;
        GameObject bomb = Instantiate(colBomb, transform.position, Quaternion.identity);
        bomb.transform.parent = this.transform;
    }
}
