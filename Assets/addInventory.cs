using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    public Image radio;
    public Image hatche;
    public Image fuelTank;
    
    public GameObject Radio;
    public GameObject Hatche;
    public GameObject FuelTank;
    
    private Inventory inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        radio.gameObject.SetActive(false);
        hatche.gameObject.SetActive(false);
        fuelTank.gameObject.SetActive(false);
    }

    void Update()
    {
        if (inventory.checkInventory(Radio))
        {
            radio.gameObject.SetActive(true);
        }
        
        if (inventory.checkInventory(Hatche))
        {
            hatche.gameObject.SetActive(true);
        }
        
        if (inventory.checkInventory(FuelTank))
        {
            fuelTank.gameObject.SetActive(true);
        }
    }
}