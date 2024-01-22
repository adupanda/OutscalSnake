using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPower : Consumables
{
    
    protected override void ConsumableEffect(GameObject snakeObject)
    {
        snakeObject.GetComponent<SnakeHead>().ApplySpeedUp();


    }

    
}
