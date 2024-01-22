using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Snake Head = Player Controller

public class SnakeHead : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float moveDelay = 0.5f;

    SnakePart thisSnakePart;


    int snakeLength = 0;

    Vector2 previousPos;

    [SerializeField]
    KeyCode Up;
    [SerializeField]
    KeyCode Down;
    [SerializeField]
    KeyCode Left;
    [SerializeField]
    KeyCode Right;

    public Vector2 buttonPressed;

    Vector2 moveDirection;

    public Vector3 rotationDirection;

    [SerializeField]
    GameObject snakePartObject;

    SpriteRenderer spriteRenderer;
    [SerializeField]
    List<GameObject> snakeParts = new List<GameObject>();

    
    

    private void Awake()
    {
        thisSnakePart = GetComponent<SnakePart>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        snakeLength = 0;
        snakeParts.Add(gameObject);
        snakeLength++;

        StartCoroutine(MoveCoroutine());
        buttonPressed = transform.up;
    }

    public void AddPart()
    {
        
        
        GameObject snakePartRef = Instantiate(snakePartObject, snakeParts[snakeParts.Count-1].transform.position,Quaternion.identity);
        snakeParts.Add(snakePartRef);
        snakeLength++;
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
            transform.position += new Vector3(buttonPressed.x * speed,buttonPressed.y*speed,0);
            transform.rotation = Quaternion.Euler(rotationDirection);
            moveDirection = buttonPressed;
            foreach(var item in snakeParts)
            {
                if(item != this.gameObject)
                {
                    int partIndex = snakeParts.IndexOf(item);
                    
                    if (snakeParts[partIndex - 1] != null)
                    {
                        item.GetComponent<SnakePart>().MoveTo(snakeParts[partIndex - 1].GetComponent<SnakePart>().previousPosition);
                        Debug.Log(snakeParts[partIndex - 1].GetComponent<SnakePart>().previousPosition);
                    }
                }
               
                
            }
            yield return new WaitForSeconds(moveDelay);
        }
        
    }
}
