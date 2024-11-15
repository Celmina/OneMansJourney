using UnityEngine;

public class DeleteExample : MonoBehaviour, IInteractable
{
    public ObjectiveHandler objectiveHandler;
    public string eventTag;
    public void Interact()
    {
        Destroy(gameObject);
        objectiveHandler.UpdateObjective(eventTag);
    }
}
