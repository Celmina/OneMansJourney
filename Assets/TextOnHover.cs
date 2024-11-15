using UnityEngine;
using TMPro;

public class TextOnHover : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public TextMeshProUGUI hoverText;
    void Start()
    {
        hoverText.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.CompareTag("Hoverable"))
            {
                hoverText.gameObject.SetActive(true);
                hoverText.transform.rotation = Quaternion.LookRotation(hoverText.transform.position - transform.position); //face camera
                hoverText.transform.position = transform.position + transform.forward * 0.5f;
            }
        }
        else
        {
            hoverText.gameObject.SetActive(false);
        }
    }
}