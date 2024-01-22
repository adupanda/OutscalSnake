using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    public static GameState Instance { get { return instance; } }
    [SerializeField]
    private GameObject snakeHeadObject;
    public GameObject snakeHeadRef;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        snakeHeadRef = Instantiate(snakeHeadObject);
    }


}
