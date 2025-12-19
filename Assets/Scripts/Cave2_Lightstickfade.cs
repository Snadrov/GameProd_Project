using UnityEngine;

public class Cave2_Lightstickfade : MonoBehaviour
{
    [SerializeField] Light pointLight; 

    [SerializeField] float timeToDecrease = 40f; 
    [SerializeField] float lightStartIntensity = 4f; 
    [SerializeField] float lightEndIntensity = 0.2f; 
    float timer = 0f; 

    void Start()
    {
        pointLight.intensity = lightStartIntensity;
    }

    void Update()
    {
        timer += Time.deltaTime / timeToDecrease;
        pointLight.intensity = Mathf.Lerp(lightStartIntensity, lightEndIntensity, timer); 
    }
}
