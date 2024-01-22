using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MassGainController : Consumables
{
    
    
    protected override void ConsumableEffect(GameObject snakeObject)
    {
        
      
        snakeObject.GetComponent<SnakeHead>().AddPart(1);

       


    }

    


}
