using UnityEngine;

public class SoundMuter : VolumeChangerAbstract
{
    [SerializeField] private AudioMixerGroupInfo _audioMixerGroupInfoMaster;
    [SerializeField] private SliderVolumeChanger _masterSliderVolumeChanger;

    private float _volumeDisabled = 0.0001f;

    public bool Muted { get; private set; }

    private void Start()
    {
        Muted = PlayerPrefs.GetInt(PlayerPrefsKeyNames.IsVolumeMuted) == 1;
        ToggleMixerMute(Muted);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeyNames.IsVolumeMuted, Muted ? 1 : 0);
    }

    public void ChangeMute()
    {
        Muted = !Muted;
        ToggleMixerMute(Muted);
    }

    private void ToggleMixerMute(bool muted)
    {
        if (muted)
            ChangeMixerVolume(_volumeDisabled, _audioMixerGroupInfoMaster);
        else
            ChangeMixerVolume(_masterSliderVolumeChanger.CurrentVolume, _audioMixerGroupInfoMaster);
    }
}
