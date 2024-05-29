using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UIElementController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sizeSlider;
    public Toggle soundToggle;
    public Toggle lightToggle;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeUpText;
    public GameObject targetObject;  // The object whose size will be adjusted
    public Light sceneLight;         // The light to toggle

    private AudioSource backgroundAudio;
    private float timer;
    private bool isTimerActive;
    private const float timerDuration = 61f;  // Example duration of 1 minute and 1 second
    void Start()
    {
        // Find the AudioSource component on the UIManager GameObject
        backgroundAudio = GetComponent<AudioSource>();

        if (backgroundAudio == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }

        // Initialize timer
        timer = 0f;
        isTimerActive = true;
        timeUpText.gameObject.SetActive(false);

        // Initialize UI elements with current values
        volumeSlider.value = backgroundAudio.volume;
        soundToggle.isOn = !backgroundAudio.mute;

        // Add listeners for UI elements
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
        sizeSlider.onValueChanged.AddListener(AdjustSize);
        soundToggle.onValueChanged.AddListener(ToggleSound);
        lightToggle.onValueChanged.AddListener(ToggleLight);
    }

    void Update()
    {
        // Update the timer if it is active
        if (isTimerActive)
        {
            timer += Time.deltaTime;
            int hours = Mathf.FloorToInt(timer / 3600);
            int minutes = Mathf.FloorToInt((timer % 3600) / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            if (timer >= timerDuration)
            {
                isTimerActive = false;
                timeUpText.gameObject.SetActive(true);
            }
        }

#if UNITY_IOS || UNITY_ANDROID
        Debug.Log("Running on mobile");
        // Mobile-specific code here
#elif UNITY_STANDALONE
        Debug.Log("Running on PC");
        // PC-specific code here
#endif
    }

    void AdjustVolume(float value)
    {
        if (backgroundAudio != null)
        {
            backgroundAudio.volume = value;
            Debug.Log("Volume adjusted to: " + value);
        }
    }

    void AdjustSize(float value)
    {
        targetObject.transform.localScale = Vector3.one * value;
        Debug.Log("Size adjusted to: " + value);
    }

    void ToggleSound(bool isOn)
    {
        if (backgroundAudio != null)
        {
            backgroundAudio.mute = !isOn;
            Debug.Log("Sound toggled: " + (isOn ? "On" : "Off"));
        }
    }

    void ToggleLight(bool isOn)
    {
        sceneLight.enabled = isOn;
        Debug.Log("Light toggled: " + (isOn ? "On" : "Off"));
    }
}