using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class ToggleLights : MonoBehaviour
{
    public bool mTargetState = true;
    public LightType mTargetLightType = LightType.Point;

    
    public void ToggleLightsOfType(LightType targetLightType)
    {
        Light[] lights = FindObjectsOfType<Light>();

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].type == targetLightType)
            {
                lights[i].enabled = !lights[i].enabled;

            }
        }
    }

    public void ToggleLightsOfType()
    {
        ToggleLightsOfType(mTargetLightType);
    }


    public void SetStateLightsOfType(LightType targetLightType, bool targetState = true)
    {
        Light[] lights = FindObjectsOfType<Light>();

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].type == targetLightType)
            {
                lights[i].enabled = targetState;

            }
        }
    }

    public void SetStateLightsOfType()
    {
        SetStateLightsOfType(mTargetLightType, mTargetState);
    }


}
