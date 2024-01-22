using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        previousPosition = transform.position;
        currentPosition = newPos;
        transform.position = currentPosition;
    }
    
}
