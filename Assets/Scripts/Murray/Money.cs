using UnityEngine;



public class Money : MonoBehaviour
{
    [SerializeField] private GameObject currency; 
    [SerializeField] private GameObject player;    
    public int moneyAmount = 10;                 

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the money's trigger
        if (other.gameObject == player)
        {
            CollectMoney();
        }
    }

    private void CollectMoney()
    {
         
        PlayerMoney playerMoney = player.GetComponent<PlayerMoney>();
        if (playerMoney != null)
        {
             
            playerMoney.AddMoney(moneyAmount);

             
            Destroy(currency);
        }
        
    }


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
