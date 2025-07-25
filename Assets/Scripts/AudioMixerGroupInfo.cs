using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class AudioMixerGroupInfo : MonoBehaviour
{
    [field: SerializeField] public AudioMixerGroup AudioMixerGroup { get; private set;}
    [field: SerializeField] public AudioMixerParameter AudioMixerParameter { get; private set;}
}
