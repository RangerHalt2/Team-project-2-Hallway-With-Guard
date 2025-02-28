using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenShot : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lifeTime = 3f;

    private Rigidbody rb;

    [SerializeField] private GameObject greenPortal;
    private GreenPortal liveGreenPortal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    private void Awake()
    {
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(7, 8);
        liveGreenPortal = GameObject.FindFirstObjectByType<GreenPortal>();
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
        if (collision.gameObject.tag == "Portal")
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.tag != "Painting")
        {
            Destroy(gameObject);
            return;
        }
        PlacePortal(collision);
        Destroy(gameObject);
    }

    void PlacePortal(Collision hit)
    {

        Vector3 hitNormal = hit.contacts[0].normal;

        Quaternion rotation = Quaternion.LookRotation(hitNormal, hit.transform.up);
        GameObject obj = Instantiate(greenPortal, transform.position, rotation);

        //FixOverhangs(obj); //LB: The overhang fix is not working;

        if (obj != null && liveGreenPortal != null)
        {
            Destroy(liveGreenPortal.gameObject);
        }
    }

    private void FixOverhangs(GameObject obj)
    {
        List<Vector3> testPoints = new List<Vector3>()
        {
            new Vector3(-1.1f, 0f, 0.1f),
            new Vector3(1.1f, 0f, 0.1f),
            new Vector3(0f, -2.1f, 0.1f),
            new Vector3(0f, 2.1f, 0.1f)
        };

        List<Vector3> testDir = new List<Vector3>()
        {
             Vector3.right,
            -Vector3.right,
             Vector3.up,
            -Vector3.up
        };

        for(int i = 0; i < 4; i++)
        {
            RaycastHit hit;
            Vector3 raycastPOS = obj.transform.TransformPoint(testPoints[i]);
            Vector3 raycastDir = obj.transform.TransformDirection(testDir[i]);

            if (Physics.Raycast(raycastPOS, raycastDir, out hit, 2.1f, 9))
            {
                var offset = hit.point - raycastPOS;
                obj.transform.Translate(offset, Space.World);
            }
            else
                Debug.Log("Did not raycast hit " + i);

        }

    }


}
