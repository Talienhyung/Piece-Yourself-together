using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int currentSongIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    public void PlayNextSong()
    {
        currentSongIndex++;
        if (currentSongIndex >= playlist.Length)
        {
            currentSongIndex = 0;
        }
        audioSource.clip = playlist[currentSongIndex];
        audioSource.Play();
    }
}
