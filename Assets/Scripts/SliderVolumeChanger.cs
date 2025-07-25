using UnityEngine;

public class SliderVolumeChanger : VolumeChangerAbstract
{
    [SerializeField] private AudioMixerGroupInfo _audioMixerGroupInfo;

    public float CurrentVolume => PlayerPrefs.GetFloat(_audioMixerGroupInfo.AudioMixerParameter.ToString());

    private void Start()
    {
        ChangeVolume(CurrentVolume);
    }

    public void ChangeVolume(float volume)
    {
        if (PlayerPrefs.GetInt(PlayerPrefsKeyNames.IsVolumeMuted) == 1)
            return;

        ChangeMixerVolume(volume, _audioMixerGroupInfo);
        PlayerPrefs.SetFloat(_audioMixerGroupInfo.AudioMixerParameter.ToString(), volume);
    }
}
