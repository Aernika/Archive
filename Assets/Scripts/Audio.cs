using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public int volAudio;
    public List<GameObject> picVolume;
    void Start()
    {
        volAudio = 3;
        //audioMixer.SetFloat("volume", 0);
    }
    public void BtnVolume()
    {
        volAudio += 1;
        if (volAudio == 4) volAudio = 1;
        float volume = (float)(volAudio * 0.3333);
        //audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        foreach (GameObject pic in picVolume)
        {
            pic.SetActive(false);
        }
        picVolume[volAudio - 1].SetActive(true);
    }
}
