using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource hoverAudioSource;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverAudioSource != null)
        {
            hoverAudioSource.pitch = Random.Range(minPitch, maxPitch);
            hoverAudioSource.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
	if (hoverAudioSource.isPlaying)
    	{
        	hoverAudioSource.Stop();
    	}
    }
}
