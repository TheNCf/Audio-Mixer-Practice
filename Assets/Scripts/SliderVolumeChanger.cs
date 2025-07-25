using UnityEngine;

public class SliderVolumeChanger : VolumeChangerAbstract
{
    [SerializeField] private AudioMixerGroupInfo _audioMixerGroupInfo;
    [SerializeField] private SoundMuter _soundMuter;

    public float CurrentVolume { get; private set; }

    private void Awake()
    {
        CurrentVolume = PlayerPrefs.GetFloat(_audioMixerGroupInfo.AudioMixerParameter.ToString());
        ChangeVolume(CurrentVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_audioMixerGroupInfo.AudioMixerParameter.ToString(), CurrentVolume);
    }

    public void ChangeVolume(float volume)
    {
        if (_soundMuter.Muted)
            return;

        ChangeMixerVolume(volume, _audioMixerGroupInfo);
        CurrentVolume = volume;
    }
}
