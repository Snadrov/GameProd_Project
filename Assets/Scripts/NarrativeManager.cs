using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NarrativeManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource narrationSource;
    public AudioClip[] narrationClips; // Size = 5

    [Header("Guide Particles")]
    public ParticleSystem guideParticles;

    [Header("Guide Targets")]
    public Transform[] spotlightTargets; // Size = 5 (A, B, C, D, Exit)

    [Header("Settings")]
    public float startDelay = 3f;

    private int currentAudioIndex = 0;
    private bool waitingForTrigger = false;

    void Start()
    {
        // IMPORTANT: disable particles at start
        guideParticles.gameObject.SetActive(false);
        StartCoroutine(StartFirstAudio());
    }

    IEnumerator StartFirstAudio()
    {
        yield return new WaitForSeconds(startDelay);
        PlayAudio(0);
    }

    void PlayAudio(int index)
    {
        narrationSource.clip = narrationClips[index];
        narrationSource.Play();
        StartCoroutine(WaitForAudioEnd(index));
    }

    IEnumerator WaitForAudioEnd(int index)
    {
        yield return new WaitWhile(() => narrationSource.isPlaying);

        MoveGuide(index);
        waitingForTrigger = true;
    }

    void MoveGuide(int index)
    {
        guideParticles.transform.position = spotlightTargets[index].position;
        guideParticles.gameObject.SetActive(true);
        guideParticles.Play();
    }

    public void TriggerNext()
    {
        if (!waitingForTrigger) return;

        waitingForTrigger = false;

        guideParticles.Stop();
        guideParticles.gameObject.SetActive(false);

        currentAudioIndex++;

        if (currentAudioIndex < narrationClips.Length)
        {
            PlayAudio(currentAudioIndex);
        }
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
