using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumables : MonoBehaviour
{
    public int chanceToSpawn;

    [SerializeField]
    protected float lifetime;

    

    protected virtual void Start()
    {

        StartCoroutine(RemoveCoroutine());
    }

    protected void Update()
    {
        if (GameState.Instance.snakeHead1Ref.transform.position == this.transform.position )
        {
            ConsumableEffect(GameState.Instance.snakeHead1Ref);
            RemoveConsumable();
            
            
        }
        else if(GameState.Instance.snakeHead2Ref.transform.position == transform.position)
        {
            ConsumableEffect(GameState.Instance.snakeHead2Ref);

            RemoveConsumable();
        }
    }

    protected abstract void ConsumableEffect(GameObject snakeObject);
    
    protected virtual void RemoveConsumable()
    {
        LevelManager.Instance.currentConsumableCount--;
        Vector2 finalPosition = this.transform.position;
        LevelManager.Instance.positions.Remove(finalPosition);
        LevelManager.Instance.consumableListRef.Remove(this.gameObject);
        StopAllCoroutines();
        DestroyImmediate(gameObject);
    }
    
    IEnumerator RemoveCoroutine()
    {
        bool isAlive = true;
        while(isAlive)
        {
            
            yield return new WaitForSeconds(lifetime);
            RemoveConsumable();
            
        }
    }
}
