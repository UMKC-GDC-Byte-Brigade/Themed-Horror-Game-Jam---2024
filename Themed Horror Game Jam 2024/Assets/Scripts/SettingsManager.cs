using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider brightnessSlider;
    public Slider volumeSlider;

    private const string BrightnessPrefKey = "Brightness";
    private const string VolumePrefKey = "Volume";

    // Static properties to access brightness and volume
    public static float Brightness
    {
        get => PlayerPrefs.GetFloat(BrightnessPrefKey, 1.0f);
        private set
        {
            PlayerPrefs.SetFloat(BrightnessPrefKey, value);
            PlayerPrefs.Save();
        }
    }

    public static float Volume
    {
        get => PlayerPrefs.GetFloat(VolumePrefKey, 1.0f);
        private set
        {
            PlayerPrefs.SetFloat(VolumePrefKey, value);
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        // Load saved values or set defaults if no values exist
        brightnessSlider.value = Brightness;
        volumeSlider.value = Volume;

        // Add listeners for when the slider values are changed
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnBrightnessChanged(float value)
    {
        Brightness = value;  // Update static property, which saves to PlayerPrefs
    }

    private void OnVolumeChanged(float value)
    {
        Volume = value;  // Update static property, which saves to PlayerPrefs
    }

    private void OnDisable()
    {
        // Ensure values are saved when the object is disabled
        PlayerPrefs.Save();
    }
}
