using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class MainMenuManagerScript : MonoBehaviour
{
    // load all panels
    // [] ALT GR + 8/9
    #region Input declaration

    [Header("_____________PANELS______________")]
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public GameObject creditsPanel;
    
    [Header("_____________AUDIO_SLIDER_SETTINGS______________")]
    [SerializeField] public AudioMixer audioMixer;
    
    [SerializeField] public Slider masterVolumeSlider;
    [SerializeField] public TMPro.TextMeshProUGUI masterVolumeText;
    [SerializeField] public Slider musicVolumeSlider;
    [SerializeField] public TMPro.TextMeshProUGUI musicVolumeText;
    [SerializeField] public Slider sfxVolumeSlider;
    [SerializeField] public TMPro.TextMeshProUGUI sfxVolumeText;

    [HideInInspector] public string notVisibleInInspector = "ich bin unsichtbar im Inspektor.";
    
    private bool _lightIsOn;
    private int amountOfStudentsInClass101 = 15;
    private float pivotPositionOfMyFirstButton = 0.5f;

    //------------PlayerPrefs-----------//
    private string _firstRunInPP = "isTheGameRunningForTheFirstTime";
    private int firstRunInt = 0; // default 0 == game is running for the first time (true)

    private string _fullscreenTogglePP = "isFullScreenToggleOn";
    private int fullscreenInt = 0; // default value 0 == fullscreen is on (true) 

    private string _masterSliderInPP = "masterVolume";
    private float masterVolumeFloat;
    private string _musicSliderInPP = "musicVolume";
    private float musicVolumeFloat;
    private string _sfxSliderInPP = "sfxVolume";
    private float sfxVolumeFloat;
    
    #endregion
    
    //Shift + 7 for / to use for comments
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // disable all panels except Main Menu panel
        Debug.Log(message:"Make only Main Menu Panel visible");
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        
        //-----Check if the game is running for the first time---------// 

        // load player prefs to get all variable values
        LoadMainMenuSavedSettings();

        // if game is running for the first time >> load default settings
        if (firstRunInt == 0) // [isTheGameRunningForTheFirstTime , firstRunInt] in PlayerPrefs
        {
            LoadMainMenuDefaultSettings(); 
            PlayerPrefs.SetInt(_firstRunInPP, 1); //set firstRunInt to 1, because the user has run the game for the first time 
        }
        else
        {
            LoadMainMenuSavedSettings();
        }
        //else >>> load saved settings
    }
    
    //----PlayerPref funktion

    #region PlayerPref fuctions

    private void LoadMainMenuDefaultSettings()
    {
        PlayerPrefs.SetInt(_firstRunInPP, 0); // game is running for the first time in true 
        PlayerPrefs.SetInt(_fullscreenTogglePP, 0); //full screen is on by default 

        // Load interface with new settings !!!!!!!!!
    }

    private void LoadMainMenuSavedSettings()
    {
        firstRunInt = PlayerPrefs.GetInt(_firstRunInPP, firstRunInt);
        fullscreenInt = PlayerPrefs.GetInt(_fullscreenTogglePP, fullscreenInt);
        
    }

    //___Settingspanel Function
    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    public void CloseSettingsPanel()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    
    public void OpenCreditsPanel()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void SetFullScreen(bool getFullScreenBoolFromToggle)
    {
        // if user clicks on toggle
        Screen.fullScreen = getFullScreenBoolFromToggle;
        Debug.Log("FullScreen Function Test");

        // save Player toggle
        if (getFullScreenBoolFromToggle == true) // toggle is on == fullscreen i on 
        {
            PlayerPrefs.SetInt(_fullscreenTogglePP, 0); // save fullscreen
        }
        else
        {
            {
                PlayerPrefs.SetInt(_fullscreenTogglePP, 1); // save fullscreen as windowed  
            }
        }
    }

    public void ChangeMasterVolume()
    {
        masterVolumeFloat = masterVolumeSlider.value; // Get slider value (between 0.0001 and 1)
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(masterVolumeFloat*20)); // Set audio volume
        masterVolumeText.text = ((masterVolumeFloat * 100).ToString("0") + "%");   // set label text
        // update percent text > (between 0.0001 and 1) * 100 = (between 1
        PlayerPrefs.SetFloat( _masterSliderInPP ,masterVolumeFloat);    // save float  in Player settings 
    }

    public void ChangeMusicVolume()
    {
        musicVolumeFloat = musicVolumeSlider.value;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolumeFloat*20));
        musicVolumeText.text = ((musicVolumeFloat * 100).ToString("0") + "%");
        PlayerPrefs.SetFloat( _musicSliderInPP, musicVolumeFloat);
    }

    public void ChangeSFXVolume()
    {
        sfxVolumeFloat = sfxVolumeSlider.value;
        audioMixer.SetFloat("SfxVolume", Mathf.Log10(sfxVolumeFloat*20));
        sfxVolumeText.text = ((sfxVolumeFloat * 100).ToString("0") + "%");
        PlayerPrefs.SetFloat( _sfxSliderInPP, sfxVolumeFloat);
    }

 
    #endregion
    
}
