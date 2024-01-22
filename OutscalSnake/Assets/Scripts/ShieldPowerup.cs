using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : Consumables
{
    
    protected override void ConsumableEffect(GameObject snakeObject)
    {
        snakeObject.GetComponent<SnakeHead>().ApplyShield();
        
        
    }

    

    
}
