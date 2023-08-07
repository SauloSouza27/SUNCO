using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[Serializable]
class SaveData
{
    public int savedInt;
    public float savedFloat;
    public bool savedBool;
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int money = 150;
    public Vector3 waterPosition = new Vector3(0.5f, 0, -3.77f);
    [SerializeField] private float waterLife = 10;
    //References
    public ShopController shopController;
    public UiController uiController;
    public MouseController mouseController;
    //Save Data (yet to implement)
    int intToSave;
    float floatToSave;
    bool boolToSave;
    //
    public int MaximumRobots;
    

    //Canvas
    [SerializeField] private GameObject hudCanvas;
    [SerializeField] private GameObject EndGameCanvas;
    [SerializeField] private GameObject WinGameCanvas;

    void Awake()
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
    public void WinGame()
    {
        hudCanvas.SetActive(false);
        EndGameCanvas.SetActive(false);
        WinGameCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void RefreshUi()
    {
        uiController.ChangeMoney(money);
        uiController.ChangeWater(waterLife);
        uiController.ChangeCapacity();
    }
    public void DamageWater(float damage)
    {
        waterLife -= damage;
        if (waterLife <= 0)
        {
            hudCanvas.SetActive(false);
            WinGameCanvas.SetActive(false);
            EndGameCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            uiController.ChangeWater(waterLife);
        }
    }
    public bool SpendMoney(int cost)
    {
        if (money >= cost)
        {
            money -= cost;
            uiController.ChangeMoney(money);
            return true;
        }
        return false;
    }
    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedInt = intToSave;
        data.savedFloat = floatToSave;
        data.savedBool = boolToSave;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            intToSave = data.savedInt;
            floatToSave = data.savedFloat;
            boolToSave = data.savedBool;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
                      + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/MySaveData.dat");
            intToSave = 0;
            floatToSave = 0.0f;
            boolToSave = false;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
}