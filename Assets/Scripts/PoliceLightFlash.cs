using UnityEngine;

public class PoliceLightFlash : MonoBehaviour
{
    public Light policeLight;

    public Color redColor = Color.red;
    public Color blueColor = Color.blue;

    public float flashSpeed = 0.5f;

    private float timer;
    private bool isRed = true;

    void Start()
    {
        if (policeLight == null)
            policeLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= flashSpeed)
        {
            timer = 0f;
            isRed = !isRed;

            policeLight.color = isRed ? redColor : blueColor;
        }
    }
}

