using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderVolumeView : MonoBehaviour
{
    [SerializeField] private SliderVolumeChanger _volumeChanger;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        ChangeValue();
    }

    private void ChangeValue()
    {
        _slider.value = _volumeChanger.CurrentVolume;
    }
}
