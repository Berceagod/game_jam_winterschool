using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip footstepClip; // Sunetul de pași
    private AudioSource audioSource;
    private Rigidbody2D rb;

    public float stepInterval = 0.5f; // Intervalul dintre pași
    private float stepTimer;

    void Start()
    {
        // Inițializare componente
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        if (audioSource == null)
        {
            Debug.LogError("Nu există AudioSource pe obiectul player!");
        }

        if (rb == null)
        {
            Debug.LogError("Nu există Rigidbody2D pe player!");
        }
    }

    void Update()
    {
        // Verifică dacă playerul se mișcă și este pe sol (presupunând că folosești o metodă de verificare a terenului)
        if (IsGrounded() && rb.linearVelocity.magnitude > 0.2f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= stepInterval)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; // Resetează timerul când jucătorul nu se mișcă
        }
    }

    void PlayFootstep()
    {
        if (footstepClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(footstepClip);
        }
        else
        {
            Debug.LogWarning("Lipsea AudioClip sau AudioSource!");
        }
    }

    bool IsGrounded()
    {
        // Poți modifica această metodă în funcție de sistemul tău de verificare a solului
        // Ex: verifică o coliziune cu un obiect etichetat "Ground"
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }
}
