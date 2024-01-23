using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Snake Head = Player Controller

public class SnakeHead : MonoBehaviour
{



    public string headClip;
    public string bodyClip;
    
    
    int PlayerScore;

    [SerializeField]
    public float moveDelay = 0.1f;

    [SerializeField]
    float shieldDuration;

    [SerializeField]
    Sprite shieldHeadSprite;

    SnakePart thisSnakePart;

    public string snakeName;

    public Sprite snakePartSprite;

    Vector2 previousPos;

    public bool isShieldActive = false;

    public Sprite snakeHeadSprite;

    [SerializeField]
    public KeyCode Up;
    [SerializeField]
    public KeyCode Down;
    [SerializeField]
    public KeyCode Left;
    [SerializeField]
    public KeyCode Right;

    Vector2 buttonPressed;

    Vector2 moveDirection;

    Vector3 rotationDirection;

    [SerializeField]
    GameObject snakePartObject;

    public int snakeLength;
    
    public List<GameObject> snakeParts = new List<GameObject>();
    [SerializeField]
    private float speedUpPercentage;
    [SerializeField]
    private Sprite speedHeadSprite;
    [SerializeField]
    private float speedUpDuration;
    private bool isScoreBoosted;
    [SerializeField]
    private float scoreBoostDuration;
    [SerializeField]
    private Sprite scoreBoostHeadSprite;

    public ScoreTextController scoreTextController;

    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisSnakePart = GetComponent<SnakePart>();
        
        
    }

   

    public int  GetPlayerScore()
    {
        return PlayerScore;
    }
    public void AddScore(int amount)
    {
        if(isScoreBoosted)
        {
            PlayerScore += amount*2;
        }
        else
        {
            PlayerScore += amount;
        }
        
        scoreTextController.SetScoreText(PlayerScore);
    }
    public void RemoveScore(int amount)
    {
        PlayerScore-= amount;   
    }

    // Start is called before the first frame update
    void Start()
    {
        snakeLength = 0;
        snakeParts.Add(gameObject);
        snakeLength += 1;

        StartCoroutine(MoveCoroutine());
        buttonPressed = transform.up;
        snakeHeadSprite = spriteRenderer.sprite;
    }


    public void AddPart(int numOfParts)
    {
        
        for(int i=0 ; i<numOfParts; i++)
        {
            GameObject snakePartRef = Instantiate(snakePartObject, snakeParts[snakeParts.Count - 1].GetComponent<SnakePart>().previousPosition, Quaternion.identity);
            snakePartRef.GetComponent<SpriteRenderer>().sprite = snakePartSprite;
            snakeParts.Add(snakePartRef);
            snakeLength++;
            AddScore(10);
        }
        
        
    }


    public void RemovePart(int numOfParts)
    {
        for (int i = 0; i < numOfParts; i++)
        {
            Destroy(snakeParts[snakeParts.Count - 1]);
            snakeParts.Remove(snakeParts[snakeParts.Count - 1]);
            snakeLength--;
            RemoveScore(10);
        }

       
        
    }
    // Update is called once per frame
    void Update()
    {
        MoveInput();

        



    }

    void MoveInput()
    {
        if(Input.GetKeyDown(Up) && moveDirection.y == 0)
        {
            buttonPressed = new Vector2(0,1);
            rotationDirection = new Vector3(0, 0, 0);
           
        }
        if (Input.GetKeyDown(Down) && moveDirection.y == 0)
        {
            buttonPressed = new Vector2(0, -1);
            rotationDirection = new Vector3(0, 0, 180);
            

        }
        if(Input.GetKeyDown(Left) && moveDirection.x == 0)
        {
            buttonPressed = new Vector2(-1, 0);
            rotationDirection = new Vector3(0, 0, 90);
            
        }
        if(Input.GetKeyDown(Right) && moveDirection.x == 0)
        {
            buttonPressed = new Vector2(1, 0);
            rotationDirection = new Vector3(0, 0, -90);
            
        }
    }
    

    IEnumerator MoveCoroutine()
    {
        bool _isMoving = false;
        while (_isMoving == false)
        {

            previousPos = transform.position;
            thisSnakePart.previousPosition = previousPos;
            transform.position += new Vector3(buttonPressed.x,buttonPressed.y,0);
            
            transform.rotation = Quaternion.Euler(rotationDirection);
            moveDirection = buttonPressed;
            
            foreach(var item in snakeParts)
            {
                if(item != this.gameObject)
                {
                    int partIndex = snakeParts.IndexOf(item);
                    
                    if (snakeParts[partIndex - 1] != null)
                    {
                        if(item)
                        {
                            item.GetComponent<SnakePart>().MoveTo(snakeParts[partIndex - 1].GetComponent<SnakePart>().previousPosition);
                        }
                        
                        
                    }
                    
                }
                item.GetComponent<SnakePart>().ScreenWrap();

            }
            yield return new WaitForSeconds(moveDelay);
        }
        
    }

    public void ApplyShield()
    {
        StartCoroutine(ShieldCoroutine());
    }

    IEnumerator ShieldCoroutine()
    {
        isShieldActive = true;

        spriteRenderer.sprite = shieldHeadSprite;
        bool shieldLoop = false;
        while (!shieldLoop)
        {

            yield return new WaitForSeconds(shieldDuration);
            isShieldActive = false;
            spriteRenderer.sprite =snakeHeadSprite;
            shieldLoop = true;

            
        }
    }

    public void ApplySpeedUp()
    {
        StartCoroutine(SpeedupLifetime());
    }

    IEnumerator SpeedupLifetime()
    {
        moveDelay *= (speedUpPercentage / 100);

        spriteRenderer.sprite = speedHeadSprite;
        bool speedUpLoop = false;
        while (!speedUpLoop)
        {

            yield return new WaitForSeconds(speedUpDuration);
            moveDelay = 0.1f;
            spriteRenderer.sprite = snakeHeadSprite;
            speedUpLoop = true;

            
        }
    }

    public void ApplyScoreBoost()
    {
        StartCoroutine(ScoreBoostLifetime());
    }
    IEnumerator ScoreBoostLifetime()
    {
        isScoreBoosted = true;

        spriteRenderer.sprite = scoreBoostHeadSprite;
        bool scoreBoostLoop = false;
        while (!scoreBoostLoop)
        {

            yield return new WaitForSeconds(scoreBoostDuration);
            isScoreBoosted = false;
            spriteRenderer.sprite = snakeHeadSprite;
            scoreBoostLoop = true;


        }
    }
}
