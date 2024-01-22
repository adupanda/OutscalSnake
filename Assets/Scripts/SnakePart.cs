using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakePart : MonoBehaviour
{
    [SerializeField]
    float boundCorrection = 0.5f;

    
    [SerializeField] public Sprite snakeBody;
    [SerializeField] public Sprite snakeTail;


    public Vector2 currentPosition;
    public  Vector2 previousPosition;


    Vector2 moveDir;
    Vector3 rotation;

    GameObject snake1;
    GameObject snake2;


    private void Awake()
    {
        snake1 = GameState.Instance.snakeHead1Ref;
        snake2 = GameState.Instance.snakeHead2Ref;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenWrap();
    }

    private void ScreenWrap()
    {
        //Get Screen position of object in pixels
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //Gets All screen sides in world units
        float rightSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        float topSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        if (screenPos.y > Screen.height)
        {
            
            transform.position = new Vector2(transform.position.x, bottomSideOfScreen + boundCorrection);
        }

        if (screenPos.y < 0)
        {

            transform.position = new Vector2(transform.position.x, topSideOfScreen - boundCorrection);
        }
        if (screenPos.x > Screen.width)
        {
            float roundedValue = Mathf.CeilToInt(leftSideOfScreen);
            transform.position = new Vector2(roundedValue, transform.position.y);
        }
        if (screenPos.x < 0)
        {
            float roundedValue = Mathf.FloorToInt(rightSideOfScreen);
            transform.position = new Vector2(roundedValue, transform.position.y);
        }
    }


    public void MoveTo(Vector2 newPos)
    {
        if (!this.gameObject.GetComponent<SnakeHead>())
        {
            previousPosition = transform.position;
            currentPosition = newPos;
            transform.position = currentPosition;
            CheckForDeath();
        }

        
    }
    
    public void CheckForDeath()
    {
        if(snake1.transform.position == new Vector3(currentPosition.x,currentPosition.y,0) && snake1.GetComponent<SnakeHead>().isShieldActive == false)
        {
            GameState.Instance.winnerText.gameObject.SetActive(true);
            GameState.Instance.winnerText.text = snake2.GetComponent<SnakeHead>().snakeName + " Wins";
            KillSnake();
            
           
            
        }
        else if(snake2.transform.position == new Vector3(currentPosition.x, currentPosition.y, 0) && snake2.GetComponent<SnakeHead>().isShieldActive == false)
        {
            GameState.Instance.winnerText.gameObject.SetActive(true);
            GameState.Instance.winnerText.text = snake1.GetComponent<SnakeHead>().snakeName + " Wins";
            KillSnake();
            

        }
    }

    void KillSnake()
    {
        SoundManager.Instance.Play(Sounds.playerDeath);
        snake1.SetActive(false);
        snake2.SetActive(false);
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        bool reloading = false;
        while(!reloading)
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(0);
            reloading = true;
        }
    }
}
