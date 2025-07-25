using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundMuter : VolumeChangerAbstract
{
    [SerializeField] private AudioMixerGroupInfo _audioMixerGroupInfoMaster;
    [SerializeField] private SliderVolumeChanger _masterSliderVolumeChanger;

    private Button _button;

    private float _volumeDisabled = 0.0001f;

    public bool IsMuted { get; private set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeMute);
    }

    private void Start()
    {
        IsMuted = PlayerPrefs.GetInt(PlayerPrefsKeyNames.IsVolumeMuted) == 1;
        ToggleMixerMute(IsMuted);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeyNames.IsVolumeMuted, IsMuted ? 1 : 0);
        _button.onClick.RemoveListener(ChangeMute);
    }

    public void ChangeMute()
    {
        IsMuted = !IsMuted;
        ToggleMixerMute(IsMuted);
    }

    private void ToggleMixerMute(bool muted)
    {
        if (muted)
            ChangeMixerVolume(_volumeDisabled, _audioMixerGroupInfoMaster);
        else
            ChangeMixerVolume(_masterSliderVolumeChanger.CurrentVolume, _audioMixerGroupInfoMaster);
    }
}
