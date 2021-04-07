using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float constanteDeConversao = (4.0f / 10.5f);
    public AudioClip coffinSong;

    public AudioSource CoffinSource;
    public AudioSource BackgroundSong;
    private float coffinVolume;
    private bool TriggerCoffinSong;
    private bool IsCoffinSongPlaying;
    // Start is called before the first frame update
    void Start()
    {
        TriggerCoffinSong = false;
        IsCoffinSongPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayCoffinSong(float volume)
    {   
        if(IsCoffinSongPlaying)
        {
            CoffinSource.volume = volume;
        } else
        {
            CoffinSource.PlayOneShot(coffinSong, 0.6f);
            BackgroundSong.Pause();
            IsCoffinSongPlaying = true;
        }
    }

    public void StopCoffinSong()
    {
        if(IsCoffinSongPlaying)
        {
            BackgroundSong.UnPause();
            CoffinSource.Stop();
            IsCoffinSongPlaying = false; 
        }
    }

}
