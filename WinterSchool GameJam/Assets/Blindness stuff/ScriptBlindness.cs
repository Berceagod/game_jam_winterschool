using UnityEngine;

public class BlindnessRemover : MonoBehaviour
{
    [SerializeField] private GameObject blindnessCanvas; 
    // Asigură-te că tragi Canvas-ul negru în această referință, din Inspector.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificăm dacă obiectul care a intrat în trigger are tag-ul "Player"
        if (collision.CompareTag("Player"))
        {
            // Dezactivăm Canvas-ul negru
            blindnessCanvas.SetActive(false);

            // (Opțional) Distrugem obiectul de "ochi" după ce și-a făcut treaba
            // Destroy(gameObject);
        }
    }
}
