using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> ConsumableList = new List<GameObject>();


    

    [SerializeField]
    int maxConsumableCount;

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public int currentConsumableCount;
   
    private bool _spawnConsumable = true;

    public List<Vector2> positions = new List<Vector2>();

    public List<GameObject> consumableListRef;

    bool GenerateRandomChance(float chance)
    {
        if (Random.Range(1, 100) <= chance)
        {
            return true;
        }
        else { return false; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        


        StartCoroutine(ConsumableCoroutine());
    }

    void SpawnConsumable()
    {
        foreach (var item in ConsumableList)
        {
            
            if (GenerateRandomChance(item.GetComponent<Consumables>().chanceToSpawn))
            {
                if(MassBurnerCheck(item))
                {
                    Vector3 SpawnPos = new Vector2(Random.Range(-28, 28), Random.Range(-16, 16));

                    GameObject newConsumable = Instantiate(item, SpawnPos, Quaternion.identity);
                    currentConsumableCount++;
                    positions.Add(SpawnPos);
                    consumableListRef.Add(newConsumable);
                }
                
                
            }
        }
    }

    
    bool MassBurnerCheck(GameObject itemToCheck)
    {
        int mB = 0;
        
            if(itemToCheck.GetComponent<MassBurner>())
            {
                mB++;
                if (mB < GameState.Instance.snakeHead1Ref.GetComponent<SnakeHead>().snakeLength - 1 && mB < GameState.Instance.snakeHead2Ref.GetComponent<SnakeHead>().snakeLength - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        

       
    }
    IEnumerator ConsumableCoroutine()
    {
        while(_spawnConsumable)
        {
            if(currentConsumableCount < maxConsumableCount)
            {
                SpawnConsumable();
            }

            yield return new WaitForSeconds(5);
        }
    }
                
}
