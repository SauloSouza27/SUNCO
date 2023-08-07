using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] GameObject buttonWarden, buttonSentinel, buttonTarget;
    [SerializeField] int[] robotPrices = new int[3] { 50, 50, 50 };
    
    public void ShowUnityShop()
    {
        if (!buttonWarden.activeSelf)
        {
            Debug.Log("Ativo");
            buttonWarden.SetActive(true);
            buttonSentinel.SetActive(true);
            buttonTarget.SetActive(true);
        }
        else
        {
            Debug.Log("Desativado");
            buttonWarden.SetActive(false);
            buttonSentinel.SetActive(false);
            buttonTarget.SetActive(false);
        }
    }

    public void BuyRobot(int robot)
    {
        if (GameManager.instance.mouseController.robotCount < GameManager.instance.MaximumRobots)
            switch (robot)
            {
                case 0:
                    if (GameManager.instance.SpendMoney(robotPrices[0]))
                    {
                        GameManager.instance.mouseController.AddRobot(0);
                    }
                    else
                    {
                        Debug.Log("Not Enough Money");
                    }
                    break;
                case 1:
                    if (GameManager.instance.SpendMoney(robotPrices[1]))
                    {                        
                        GameManager.instance.mouseController.AddRobot(1);
                    }
                    else
                    {
                        Debug.Log("Not Enough Money");
                    }
                    break;
                case 2:
                    if (GameManager.instance.SpendMoney(robotPrices[2]))
                    {                       
                        GameManager.instance.mouseController.AddRobot(2);
                    }
                    else
                    {
                        Debug.Log("Not Enough Money");
                    }
                    break;
            }
    }

    public void BuyUpgrade(int Upgrade)
    {
        
    }
}
