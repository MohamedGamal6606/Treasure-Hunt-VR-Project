using UnityEngine;

public class ColliderFollow : MonoBehaviour
{
    public Transform head;
    public CapsuleCollider collider;

    void Update()
    {
        float height = Mathf.Clamp(head.localPosition.y, 1f, 2f);
        collider.height = height;

        Vector3 center = head.localPosition;
        collider.center = new Vector3(center.x, height / 2, center.z);
    }

}

