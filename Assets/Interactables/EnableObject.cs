using UnityEngine;

public class EnableObject : MonoBehaviour, IInteractable
{
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0.1f);
        gameObject.GetComponent<Collider>().isTrigger = true;
    }
    public void Interact()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        gameObject.GetComponent<Collider>().isTrigger = false;
    }
}
