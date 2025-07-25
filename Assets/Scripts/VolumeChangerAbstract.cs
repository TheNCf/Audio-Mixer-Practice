using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChangerAbstract : MonoBehaviour
{
    private float _volumeTodBMultiplier = 20.0f;

    public virtual void ChangeMixerVolume(float volume, AudioMixerGroupInfo audioMixerGroupInfo)
    {
        string parameter = audioMixerGroupInfo.AudioMixerParameter.ToString();
        float dBVolume = Mathf.Log10(volume) * _volumeTodBMultiplier;
        audioMixerGroupInfo.AudioMixerGroup.audioMixer.SetFloat(parameter, dBVolume);
    }
}
