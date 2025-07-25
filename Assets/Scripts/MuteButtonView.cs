using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuteButtonView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private SoundMuter _soundMuter;

    private string _mute = "Mute";
    private string _unmute = "Unmute";

    private void Start()
    {
        StartCoroutine(ChangeTextOnNextFrame());
    }

    public void ChangeText()
    {
        if (_soundMuter.Muted)
            _buttonText.text = _unmute;
        else
            _buttonText.text = _mute;
    }

    private IEnumerator ChangeTextOnNextFrame()
    {
        yield return new WaitForEndOfFrame();

        ChangeText();
    }
}
