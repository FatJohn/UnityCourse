using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider DifficultySlider;

    private LevelManager levelManager;
    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        musicManager = FindObjectOfType<MusicManager>();

        VolumeSlider.value = PlayerPrefManager.GetMasterVolume();
        DifficultySlider.value = PlayerPrefManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        musicManager.SetVolume(VolumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefManager.SetMasterVolume(VolumeSlider.value);
        PlayerPrefManager.SetDifficulty(DifficultySlider.value);

        levelManager.LoadLevel("01a Start");
    }

    public void SetDefault()
    {
        VolumeSlider.value = 0.8f;
        DifficultySlider.value = 2f;
    }
}
