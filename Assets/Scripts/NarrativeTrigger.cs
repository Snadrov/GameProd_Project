using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    public NarrativeManager manager;
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        manager.TriggerNext();
    }
}
