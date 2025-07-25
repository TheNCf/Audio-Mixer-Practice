using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMuter : VolumeChangerAbstract
{
    [SerializeField] private List<AudioMixerGroupInfo> _audioMixerGroupInfos;

    private float _volumeDisabled = 0.0001f;

    public bool Mute => PlayerPrefs.GetInt(PlayerPrefsKeyNames.IsVolumeMuted) == 1;

    private void Start()
    {
        ToggleAllMixers(Mute);
    }

    public void ChangeMute()
    {
        if (Mute)
            PlayerPrefs.SetInt(PlayerPrefsKeyNames.IsVolumeMuted, 0);
        else
            PlayerPrefs.SetInt(PlayerPrefsKeyNames.IsVolumeMuted, 1);

        ToggleAllMixers(Mute);
    }

    private void ToggleAllMixers(bool mute)
    {
        foreach (var mixerInfo in _audioMixerGroupInfos)
        {
            if (mute)
                ChangeMixerVolume(_volumeDisabled, mixerInfo);
            else
                ChangeMixerVolume(PlayerPrefs.GetFloat(mixerInfo.AudioMixerParameter.ToString()), mixerInfo);
        }
    }
}
