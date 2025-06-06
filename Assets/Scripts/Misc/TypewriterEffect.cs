using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    [Header(" Elements ")]
    [TextArea(3, 10)]
    [SerializeField] private List<string> textList = new List<string>();

    private Coroutine typingCoroutine;

    [Header(" Settings ")]
    [SerializeField] private float delay = 0.05f;

    private const string FirstTimeKey = "IsFirstTimePlay";

    [Header(" Sounds ")]
    [SerializeField] private List<AudioClip> storySounds = new List<AudioClip>();
    [SerializeField] private AudioSource storyAudioSource;

    [Header(" UI ")]
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private Button skipButton;
    [SerializeField] private Fader fader;

    private void OnEnable()
    {
        skipButton.interactable = true;
    }

    private void OnDisable()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        fader.FadeIn(2f);
    }

    void Start()
    {
        CheckFirstTimePlay();
    }

    void CheckFirstTimePlay(bool saveFirstTime = false)
    {
        if (!IsFirstTimePlay())
        {
            gameObject.SetActive(true);

            if (saveFirstTime)
                SaveFirstTimePlay();
        }

        else gameObject.SetActive(false);
    }

    private bool IsFirstTimePlay()
    {
        return PlayerPrefs.HasKey(FirstTimeKey);
    }

    private void SaveFirstTimePlay()
    {
        PlayerPrefs.SetInt(FirstTimeKey, 1);
        PlayerPrefs.Save();
    }

    public void StartTyping(int textIndex)
    {
        if (textList.Count == 0)
        {
            Debug.LogWarning("Chưa có text nào trong danh sách!");
            return;
        }

        if (textIndex < 0 || textIndex >= textList.Count)
        {
            Debug.LogWarning("Text Index không hợp lệ, gán về 0");
            textIndex = 0;
        }

        if (textIndex == textList.Count - 1)
        {
            CheckFirstTimePlay(true);
            skipButton.interactable = false;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        ResetText();
        typingCoroutine = StartCoroutine(ShowText(textIndex));
    }

    IEnumerator ShowText(int textIndex)
    {
        string fullText = textList[textIndex];

        if (textIndex < storySounds.Count)
        {
            storyAudioSource.clip = storySounds[textIndex];
            storyAudioSource.Play();
        }

        foreach (char c in fullText)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(delay);
        }
    }

    public void ResetText()
    {
        textDisplay.text = "";
    }

    public void SkipStory()
    {
        storyAudioSource.Stop();
        fader.gameObject.SetActive(true);
        StartCoroutine(FadeOutCo());

        if (!IsFirstTimePlay())
            CheckFirstTimePlay(true);
    }

    IEnumerator FadeOutCo()
    {
        yield return fader.FadeOutCo(2f);
        gameObject.SetActive(false);
    }
}
