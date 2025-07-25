using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVolumeChanger : VolumeChangerAbstract
{
    [SerializeField] private AudioMixerGroupInfo _audioMixerGroupInfo;
    [SerializeField] private SoundMuter _soundMuter;

    private Slider _slider;

    public float CurrentVolume { get; private set; }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        CurrentVolume = PlayerPrefs.GetFloat(_audioMixerGroupInfo.AudioMixerParameter.ToString());
        ChangeVolume(CurrentVolume);
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_audioMixerGroupInfo.AudioMixerParameter.ToString(), CurrentVolume);
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        CurrentVolume = volume;

        if (_soundMuter.IsMuted)
            return;

        ChangeMixerVolume(volume, _audioMixerGroupInfo);
    }
}
