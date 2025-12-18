using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public NarrativeManager manager;
    public string nextSceneName = "NextScene";

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        manager.LoadNextScene(nextSceneName);
    }
}

