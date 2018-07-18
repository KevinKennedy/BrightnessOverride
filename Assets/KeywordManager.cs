using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public BrightnessOverrideComponent BrightnessOverride;
    public GameObject Content;

    // Use this for initialization
    void Start()
    {
        keywords.Add("Off", () =>
        {
            this.BrightnessOverride.Brightness = 0f;
        });

        keywords.Add("On", () =>
        {
            this.BrightnessOverride.Brightness = 1.0f;
        });

        keywords.Add("Darker", () =>
        {
            this.BrightnessOverride.Brightness -= 0.1f;
        });
        
        keywords.Add("Brighter", () =>
        {
            this.BrightnessOverride.Brightness += 0.1f;
        });

        keywords.Add("Hide", () =>
        {
            this.Content.SetActive(false);
        });

        keywords.Add("Show", () =>
        {
            this.Content.SetActive(true);
        });

        keywords.Add("Quit", () =>
        {
            Application.Quit();
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}