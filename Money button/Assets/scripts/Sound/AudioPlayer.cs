using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip[] _sounds;

    public void PlaySound(int index)
    {
        _audio.pitch = Random.Range(0.85f, 1.15f);
        _audio.PlayOneShot(_sounds[index]);
    }

    public void PlaySound(AudioClip sound)
    {
        _audio.PlayOneShot(sound);
    }
}
