using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    #region Header OBJECT REFERENCES
    [Space(10)]
    [Header("OBJECT REFERENCES")]
    #endregion Header OBJECT REFERENCES
    #region Tooltip
    [Tooltip("Populate with the return all button gameobject")]
    #endregion
    [SerializeField] private GameObject verticalButtonsGroup;
    #region Tooltip
    [Tooltip("Populate with the return to main menu button gameobject")]
    #endregion
    [SerializeField] private GameObject returnToMainMenuButton;
    #region Tooltip
    [Tooltip("Populate with the return to story button gameobject")]
    #endregion
    [SerializeField] private GameObject storyButton;
    #region Tooltip
    [Tooltip("Populate with the story panel")]
    #endregion
    [SerializeField] private GameObject storyPanel;
    #region Tooltip
    [Tooltip("Populate with the settings panel")]
    #endregion
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Fader fader;

    private bool isInstructionSceneLoaded = false;
    private bool isHighScoresSceneLoaded = false;

    private void Start()
    {
        // Play Music
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);

        // Load Character selector scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);

        returnToMainMenuButton.SetActive(false);
    }

    /// <summary>
    /// Called from the Play Game / Enter The Dungeon Button
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    /// <summary>
    /// Called from the High Scores Button
    /// </summary>
    public void LoadHighScores()
    {
        verticalButtonsGroup.SetActive(false);
        storyButton.SetActive(false);
        storyPanel.SetActive(false);
        settingsPanel.SetActive(false);
        isHighScoresSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load High Score scene additively
        SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Called from the Return To Main Menu Button
    /// </summary>
    public void LoadCharacterSelector()
    {
        returnToMainMenuButton.SetActive(false);

        if (isHighScoresSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("HighScoreScene");
            isHighScoresSceneLoaded = false;
        }
        else if (isInstructionSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("InstructionsScene");
            isInstructionSceneLoaded = false;
        }

        verticalButtonsGroup.SetActive(true);
        storyButton.SetActive(true);
        storyPanel.SetActive(false);
        settingsPanel.SetActive(false);

        // Load character selector scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Called from the Instructions Button
    /// </summary>
    public void LoadInstructions()
    {
        verticalButtonsGroup.SetActive(false);
        storyButton.SetActive(false);
        storyPanel.SetActive(false);
        settingsPanel.SetActive(false);
        isInstructionSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load instructions scene additively
        SceneManager.LoadScene("InstructionsScene", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Quit the game - this method is called from the onClick event set in the inspector
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowStoryRecap()
    {
        fader.gameObject.SetActive(true);
        StartCoroutine(ShowStoryRecapCo());
    }

    IEnumerator ShowStoryRecapCo()
    {
        yield return fader.FadeOutCo(2f);
        storyPanel.SetActive(true);
        yield return fader.FadeInCo(2f);
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    #region Validation
#if UNITY_EDITOR
    // Validate the scriptable object details entered
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(verticalButtonsGroup), verticalButtonsGroup);
        HelperUtilities.ValidateCheckNullValue(this, nameof(returnToMainMenuButton), returnToMainMenuButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(storyButton), storyButton);
        HelperUtilities.ValidateCheckNullValue(this, nameof(storyPanel), storyPanel);
        HelperUtilities.ValidateCheckNullValue(this, nameof(settingsPanel), settingsPanel);
    }
#endif
    #endregion
}
