using JetBrains.Annotations;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private GameObject currency;  
    [SerializeField] private GameObject Player;
    public int Money_Amount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player) 
        {
             
            CollectMoney();
        }
    }

     

    private void CollectMoney()
    {
        PlayerMoney playerMoney = Player.GetComponent<PlayerMoney>();
        if (playerMoney != null)
        {
            playerMoney.AddMoney(Money_Amount);


     
        }
        else
        {

        }

        Destroy(currency);
    }


 
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }
        
}


    
