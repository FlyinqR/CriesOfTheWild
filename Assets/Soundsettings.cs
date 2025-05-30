using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Soundsettings : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Slider soundslider;
    [SerializeField] AudioMixer masterMixer;
    private float _value;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SaveMasterVolume", 100));
    }

    public void SetVolume(float _value)
    {
        if(_value < 1){
            _value = .00f;
        }
        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundslider.value);

    }

    public void RefreshSlider(float _value)
    {
        soundslider.value = _value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
