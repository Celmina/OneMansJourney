using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public Animator Animator;
    void Start()
    { 
        inventory = FindFirstObjectByType<Inventory>();
        if (inventory == null)
        {
            Debug.Log("No Inventory found");
        }
    }
    public void Interact()
    {
        if (!Animator){
            inventory.addItem(gameObject);
        } 
        else {
        switch (gameObject.name){
            case "Hache":
                Animator.Play("AxeGone");
                break;
            case "Radio":
                Animator.Play("RadioGone");
                break;
            case "battery":
                Animator.Play("batteryGone");
                break;
            case "battery (1)":
                Animator.Play("battery1Gone");
                break;
            case "battery (2)":
                Animator.Play("battery2Gone");
                break;
            case "battery (3)":
                Animator.Play("battery3Gone");
                break;
            case "Fuel Tank":
                Animator.Play("FuelGone");
                break;
            case "rust_key":
                Animator.Play("KeyGone");
                break;
        }
        inventory.addItem(gameObject);
        }
    }
}
