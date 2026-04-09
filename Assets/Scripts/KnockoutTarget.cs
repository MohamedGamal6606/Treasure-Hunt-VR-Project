using UnityEngine;

public class KnockoutTarget : MonoBehaviour
{
    private Animator animator;
    private GameManager gameManager;
    public bool IsKnockedOut { get; private set; } = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void GetKnockedOut(Vector3 shotDirection)
    {
        if (IsKnockedOut) return;
        IsKnockedOut = true;

        animator.SetBool("targetHit", true);
        gameManager.OnTargetKnockedOut();
    }
}