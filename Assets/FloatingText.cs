using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Transform camera;
    public Transform unit;
    public Transform canvas;

    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = Camera.main.transform;
        unit = transform.parent;
        canvas = FindFirstObjectByType<Canvas>().transform;
        
        transform.SetParent(canvas);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == null)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position); //face camera
        transform.position = unit.position + offset;
    }
}
