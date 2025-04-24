using UnityEditor.Tilemaps;
using UnityEngine;

public class MainMenuManagerScript : MonoBehaviour
{
    // load all panels
    // [] ALT GR + 8/9
    #region Input declaration

    [Header("_____________PANELS______________")]
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject settingsPanel;
    [SerializeField] public GameObject creditsPanel;

    [HideInInspector] public string notVisibleInInspector = "ich bin unsichtbar im Inspektor.";
    
    private bool _lightIsOn;
    private int amountOfStudentsInClass101 = 15;
    private float pivotPositionOfMyFirstButton = 0.5f;

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
    
}
