using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;

    void Start()
    {
        // Load volume setting as soon as the game or sound settings menu starts.
        float savedVolume = PlayerPrefs.GetFloat("SavedMasterVolume", 100);
        SetVolume(savedVolume);
    }

    public void SetVolume(float _value)
    {
        if (_value < 1f)
        {
            _value = 0.001f; // Prevents muting completely which could cause issues with logarithmic calculations
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }
}
