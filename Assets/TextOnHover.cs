using UnityEngine;
using TMPro;

public class TextOnHover : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public TextMeshProUGUI hoverText;
    

    void Start()
    {
        if (hoverText != null)
        {
            hoverText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Hover Text reference is missing!");
        }
    }

    void Update()
    {
        if (hoverText == null || InteractorSource == null) return;

        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider != null && hitInfo.collider.gameObject.CompareTag("Hoverable"))
            {
                hoverText.gameObject.SetActive(true);
                hoverText.transform.rotation = Quaternion.LookRotation(hoverText.transform.position - transform.position);
                hoverText.transform.position = transform.position + transform.forward * 0.5f;
            }
            else if (hoverText.gameObject.activeSelf)
            {
                hoverText.gameObject.SetActive(false);
            }
        }
        else if (hoverText.gameObject.activeSelf)
        {
            hoverText.gameObject.SetActive(false);
        }
    }
}