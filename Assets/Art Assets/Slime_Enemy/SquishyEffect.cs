using UnityEngine;

public class SquishyEffect : MonoBehaviour
{
    public float squishSpeed = 2f; // Speed of the squish animation
    public float squishAmount = 0.1f; // How much the object squishes

    private Vector3 startScale; // Initial scale of the object

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale; // Save the initial scale
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the squish effect using Mathf.Sin for smooth up/down movement
        float squishFactor = Mathf.Sin(Time.time * squishSpeed) * squishAmount;

        // Apply the squish effect to the object's local scale
        transform.localScale = new Vector3(startScale.x + squishFactor, startScale.y + squishFactor, startScale.z + squishFactor);
    }
}
