using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmLoading : MonoBehaviour

{
    // Dictionary to hold pairs of background images and corresponding audio clips
    private Dictionary<string, AudioClip> backgroundMusicMap;

    // Reference to the AudioSource component
    private AudioSource audioSource;

    // Serialized AudioClip variables
    //[SerializeField] private AudioClip ParkBGM;
    //[SerializeField] private AudioClip CityBGM; // example of another AudioClip


    void Awake()
    {
        // Ensure this GameObject persists across scenes
        DontDestroyOnLoad(gameObject);

        // Initialize the AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // Enable looping

        // Initialize the dictionary
        backgroundMusicMap = new Dictionary<string, AudioClip>();

        AudioClip ClownBGM = Resources.Load<AudioClip>("ClownBGM");
        AudioClip NakedBGM = Resources.Load<AudioClip>("NakedBGM");
        AudioClip NeutralBGM = Resources.Load<AudioClip>("NeutralBGM");

        backgroundMusicMap.Add("Neutral Text", NeutralBGM);
        backgroundMusicMap.Add("Clown Text", ClownBGM);
        backgroundMusicMap.Add("Naked Text", NakedBGM);
        backgroundMusicMap.Add("Meme Text", NeutralBGM);


        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the background image in the scene
        // Assuming the background image is attached to a GameObject with a specific tag
        GameObject backgroundImageObject = GameObject.FindWithTag("IdentifierImage");

        if (backgroundImageObject != null)
        {
            // Get the name of the background image
            string backgroundImageName = backgroundImageObject.name;

            // Find the corresponding audio clip
            if (backgroundMusicMap.TryGetValue(backgroundImageName, out AudioClip clip))
            {
                // Play the audio clip
                audioSource.clip = clip;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("No audio clip found for background image: " + backgroundImageName);
            }
        }
        else
        {
            Debug.LogWarning("No background image found in the scene.");
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event when this GameObject is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Add other methods as needed
}
