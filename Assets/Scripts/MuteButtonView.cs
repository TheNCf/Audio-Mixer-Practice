using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private SoundMuter _soundMuter;

    private Button _button;

    private string _mute = "Mute";
    private string _unmute = "Unmute";

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeText);
    }

    private void Start()
    {
        StartCoroutine(ChangeTextOnNextFrame());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeText);
    }

    public void ChangeText()
    {
        if (_soundMuter.IsMuted)
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
