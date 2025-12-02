using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;

public class Cave_LightTrigger : MonoBehaviour
{
    float lightIntensityMin = 0f; 
    float lightIntesityMax = 4f;
    float timeToIncrease = 2f; 
    bool increaseIntesity = false; 

    [SerializeField] Light pointLight;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] PlayableDirector playableDirector; 

    void Start()
    {
        meshRenderer.enabled = false; 
        pointLight.intensity = 0f; 
        playableDirector.enabled = false; 
    }

    void Update()
    {
        if (increaseIntesity)
        {
            pointLight.intensity = Mathf.Lerp(pointLight.intensity, lightIntesityMax, timeToIncrease * Time.deltaTime); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            meshRenderer.enabled = true; 
            increaseIntesity = true; 
            playableDirector.enabled = true; 
        }
    }
}
