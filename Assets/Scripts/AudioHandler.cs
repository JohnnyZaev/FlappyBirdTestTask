using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class AudioHandler : MonoBehaviour
{
    [SerializeField] private AudioClip wingSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip pointSound;
    
    private AudioSource _audioSource;
    private float _volume;
    [Inject]private Slider _volumeSlider;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        _volumeSlider.value = _volume;
        _audioSource.volume = _volume;
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

    public void ChangeVolumeValue()
    {
        PlayerPrefs.SetFloat("Volume", _volume);
        _volume = _volumeSlider.value;
        _audioSource.volume = _volume;
    }
}
