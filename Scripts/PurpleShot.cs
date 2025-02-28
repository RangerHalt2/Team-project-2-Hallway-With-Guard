using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleShot : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lifeTime = 3f;

    private Rigidbody rb;

    [SerializeField] private GameObject purplePortal;
    private PurplePortal livePurplePortal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    private void Awake()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(7, 8);
        livePurplePortal = GameObject.FindFirstObjectByType<PurplePortal>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlacePortal(collision);
        Destroy(gameObject);
    }

    void PlacePortal(Collision hit)
    {

        Vector3 hitNormal = hit.contacts[0].normal;

        Quaternion rotation = Quaternion.LookRotation(hitNormal, hit.transform.up);

        List<Vector3> dirs = new List<Vector3>
        {
            Vector3.right,
            -Vector3.right,
            Vector3.up,
            -Vector3.up
        };

        //Check for bad placements
        for (int i = 0; i < 4; i++)
        {

        }

        Object obj = Instantiate(purplePortal, transform.position, rotation);
        if (obj != null && livePurplePortal != null)
        {
            Destroy(livePurplePortal.gameObject);
        }
    }
}
