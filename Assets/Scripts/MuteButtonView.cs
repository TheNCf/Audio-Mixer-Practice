using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuteButtonView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;

    private string _mute = "Mute";
    private string _unmute = "Unmute";

    private void Start()
    {
        ChangeText();
    }

    public void ChangeText()
    {
        if (PlayerPrefs.GetInt(PlayerPrefsKeyNames.IsVolumeMuted) == 0)
            _buttonText.text = _mute;
        else
            _buttonText.text = _unmute;

        Debug.Log(PlayerPrefs.GetInt(PlayerPrefsKeyNames.IsVolumeMuted));
    }
}
