using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    public static GameState Instance { get { return instance; } }
    [SerializeField]
    private GameObject snakeHeadObject;
    public GameObject snakeHead1Ref;
    public GameObject snakeHead2Ref;

    [SerializeField]
    string snakeGreenheadanim;
    [SerializeField]
    string snakeBlueheadanim;
    [SerializeField]
    string snakeGreenBodyanim;
    [SerializeField]
    string snakeBlueBodyanim;




    


    [SerializeField]
    KeyCode Player1Up;
    [SerializeField]
    KeyCode Player1Down;
    [SerializeField]
    KeyCode Player1Left;
    [SerializeField]
    KeyCode Player1Right;

    [SerializeField]
    KeyCode Player2Up;
    [SerializeField]
    KeyCode Player2Down;
    [SerializeField]
    KeyCode Player2Left;
    [SerializeField]
    KeyCode Player2Right;

    [SerializeField]
    Vector2 snakeHead1Spawn;
    [SerializeField]
    Vector2 snakeHead2Spawn;
    [SerializeField]
    private string player1Name;
    [SerializeField]
    private string player2Name;
    [SerializeField]
    ScoreTextController scoreTextController1;
    [SerializeField]
    ScoreTextController scoreTextController2;

    [SerializeField]
    Sprite snake1HeadSprite;
    [SerializeField]
    Sprite snake1BodySprite;
    [SerializeField]
    Sprite snake2HeadSprite;
    [SerializeField]
    Sprite snake2BodySprite;

    

    public TextMeshProUGUI winnerText;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        snakeHead1Ref = Instantiate(snakeHeadObject,snakeHead1Spawn,Quaternion.identity).GetComponentInChildren<SnakeHead>().gameObject;
        snakeHead2Ref = Instantiate(snakeHeadObject, snakeHead2Spawn, Quaternion.identity).GetComponentInChildren<SnakeHead>().gameObject;
        
        SetControlsAndName();

        winnerText.gameObject.SetActive(false);
    }

    void SetControlsAndName()
    {
        SnakeHead snakeHead1 = snakeHead1Ref.GetComponent<SnakeHead>();
        snakeHead1.Up = Player1Up;
        snakeHead1.Down = Player1Down;
        snakeHead1.Left = Player1Left;
        snakeHead1.Right = Player1Right;
        snakeHead1.snakePartSprite = snake1BodySprite;
        snakeHead1.snakeName = player1Name;
        snakeHead1.headClip = snakeGreenheadanim;
        snakeHead1.bodyClip = snakeGreenBodyanim;
        
        snakeHead1.scoreTextController = scoreTextController1;
        snakeHead1Ref.GetComponent<SpriteRenderer>().sprite = snake1HeadSprite;
        
        SnakeHead snakeHead2 = snakeHead2Ref.GetComponent<SnakeHead>();
        snakeHead2.Up = Player2Up;
        snakeHead2.Down = Player2Down;
        snakeHead2.Left = Player2Left;
        snakeHead2.Right = Player2Right;
        snakeHead2.snakePartSprite = snake2BodySprite;
        snakeHead2.snakeName = player2Name;
        snakeHead2.headClip = snakeBlueheadanim;
        snakeHead2.bodyClip = snakeBlueBodyanim;
        snakeHead2.scoreTextController = scoreTextController2;
        snakeHead2Ref.GetComponent<SpriteRenderer>().sprite = snake2HeadSprite;

        
    }
}
