using UnityEngine;

public class PlayerMoney : MonoBehaviour
{

    public int TotalMoney = 0;


    public void AddMoney(int amount)
    {
        TotalMoney += amount;
        Debug.Log("Total Money: " + TotalMoney);
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
