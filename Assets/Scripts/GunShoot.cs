using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public Transform muzzle;
    public float range = 50f;
    public InputActionReference triggerAction; // Assign in Inspector

    void OnEnable() { triggerAction.action.Enable(); }
    void OnDisable() { triggerAction.action.Disable(); }

    void Update()
    {
        if (triggerAction.action.WasPressedThisFrame())
        {
            Debug.Log("Trigger pulled, shooting!");
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(muzzle.position, muzzle.forward);
        Debug.DrawRay(muzzle.position, muzzle.forward * range, Color.red, 1f);
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            KnockoutTarget target = hit.collider.GetComponent<KnockoutTarget>();
            if (target != null)
            {
                Debug.Log("Hit target: " + target.name);
                target.GetKnockedOut(ray.direction);
            }
        }
    }
}