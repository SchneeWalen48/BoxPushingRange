using UnityEngine;

public class ClickPusher : MonoBehaviour
{
    [SerializeField] private float maxDistance = 30f;
    [SerializeField] private float impulseStrength = 0.02f;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        Ray ray = cam.ScreenPointToRay( Input.mousePosition );

        if(!Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            return;
        }

        Rigidbody targetRigidbody = hit.rigidbody;
        if(targetRigidbody == null || targetRigidbody.isKinematic)
        {
            return;
        }

        Vector3 force = ray.direction * impulseStrength * 0.1f;

        targetRigidbody.AddForceAtPosition(force, hit.point, ForceMode.Impulse);

    }
}
