using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public enum SkyBoxType { Day, Night }

    [SerializeField] private Light worldLight;
    [SerializeField] private Material day;
    [SerializeField] private Material night;


    private void Awake()
    {
        int type = Random.Range(0, System.Enum.GetValues(typeof(SkyBoxType)).Length);
        ChangeSkyBox((SkyBoxType)type);
    }

    private void LateUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);

        if (Input.GetKey(KeyCode.N))
        {
            ChangeSkyBox(SkyBoxType.Night);
        }
        if (Input.GetKey(KeyCode.M))
        {
            ChangeSkyBox(SkyBoxType.Day);
        }

    }

    private void ChangeSkyBox(SkyBoxType type)
    {
        switch (type)
        {
            case SkyBoxType.Day:
                RenderSettings.skybox = day;
                worldLight.colorTemperature = 4000;
                worldLight.shadowStrength = 1.0f;
                break;
            case SkyBoxType.Night:
                RenderSettings.skybox = night;
                worldLight.colorTemperature = 7300;
                worldLight.shadowStrength = 0.6f;
                break;
        }
    }
}
