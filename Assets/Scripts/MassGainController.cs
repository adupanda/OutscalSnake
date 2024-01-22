using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGainController : Consumables
{
    protected override void ConsumableEffect()
    {
        
        if (GameState.Instance.snakeHeadRef.transform.position == this.transform.position)
        {
            GameState.Instance.snakeHeadRef.GetComponent<SnakeHead>().AddPart();
            
        }
        
        
    }

    


}
