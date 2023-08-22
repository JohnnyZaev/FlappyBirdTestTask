using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip wingSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip pointSound;
    
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public enum Sounds
    {
        Wing,
        Hit,
        Point
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.Wing:
                _audioSource.PlayOneShot(wingSound);
                break;
            case Sounds.Hit:
                _audioSource.PlayOneShot(hitSound);
                break;
            case Sounds.Point:
                _audioSource.PlayOneShot(pointSound);
                break;
        }
    }
}
