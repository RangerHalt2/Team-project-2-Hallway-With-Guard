using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public float floatSpeed = 1f;   // Speed of the floating motion
    public float floatHeight = 0.5f; // Height of the floating motion

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Store the initial position
    }

    // Update is called once per frame
    void Update()
    {
        // Use Mathf.Sin to create a smooth up and down motion
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        // Optional: Debug log to check if position is changing
        //Debug.Log(transform.position);
    }
}
