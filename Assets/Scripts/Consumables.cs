using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumables : MonoBehaviour
{
    public int chanceToSpawn;

    private void Start()
    {
        
    }

    protected void Update()
    {
        if (GameState.Instance.snakeHeadRef.transform.position == this.transform.position)
        {
            ConsumableEffect();
            
            LevelManager.Instance.currentConsumableCount--;
            Vector2 finalPosition = this.transform.position;
            LevelManager.Instance.positions.Remove(finalPosition);
            Destroy(gameObject);
        }
    }

    protected abstract void ConsumableEffect();
    
}
