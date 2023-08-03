using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] GameObject buttonWarden, buttonSentinel, buttonTarget;
    [SerializeField] GameObject targetWarden;
    [SerializeField] int[] robotPrices = new int[3] {50,50,50};

    public void Start()
    {
        
    }
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
        switch (robot)
        {
            case 0:
                if(GameManager.instance.money > robotPrices[0])
                {

                }
                break;
            case 1:

                break;
            case 2:

                break;
        }
    }
}
