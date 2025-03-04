using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightAlertController : MonoBehaviour
{
    Renderer _alarmRenderer;

    Color _baseColor = Color.gray;
    float _baseTransparency;
    float _renderT;
    void Start()
    { 
         _alarmRenderer = GetComponent<Renderer>();
        _baseColor = _alarmRenderer.material.color;
    }


    void Update()
    {
        
    }
    void LightsOn()
    {
        StartCoroutine(CallCoroutines()); 
    }
    void OnEnable()
    {
        ControlPanel.OnSimulatorOn += LightsOn;
        ControlPanel.OnEmergency += EmergencyStop;
    }
    void OnDisable()
    {
        ControlPanel.OnSimulatorOn -= LightsOn;
        ControlPanel.OnEmergency -= EmergencyStop;
    }
    IEnumerator CallCoroutines()
    {
        yield return StartCoroutine(FadeIn()); 
        yield return StartCoroutine(LightsStart());
    }
    
    IEnumerator FadeIn()
    {

        Color startColor = _baseColor;
        Color endColor = Color.green;    
        
        float duration = 2f;

        float startTransparency = 0.2f;
        float endTransparency = 1;


        for (float color = 0f; color <= 1f; color += 0.15f)
        {
            _baseColor = Color.Lerp(startColor, endColor, color);
            _baseTransparency = Mathf.Lerp(startTransparency, endTransparency, color);

            _alarmRenderer.material.color = _baseColor;
            _alarmRenderer.material.SetFloat("_Transparency", _baseTransparency);
            _alarmRenderer.material.SetColor("_Color_base",_baseColor);
            yield return new WaitForSeconds(duration * 0.1f); 
        }
        _baseColor = Color.gray;
        _alarmRenderer.material.SetColor("_Color_base", _baseColor);
    }
    IEnumerator LightsStart()
    {
        _alarmRenderer.material.SetColor("_Color_base", _baseColor);
        _alarmRenderer.material.SetColor("_Color", _baseColor);

        yield return new WaitForSeconds(0.2f);
    }
    void EmergencyStop()
    {
        StopAllCoroutines(); 
        StartCoroutine(BlinkLight());
        

    }
    IEnumerator BlinkLight()
    {
        Color color1 = Color.red;
        float blinkDuration = 0.5f;
        int blinkTimes = 8;

        for (int i = 0; i < blinkTimes; i++)
        {
            _alarmRenderer.material.SetColor("_Color", Color.red);
            _alarmRenderer.material.SetColor("_Color_base", Color.red);
            yield return new WaitForSeconds(blinkDuration);

            _alarmRenderer.material.SetColor("_Color", _baseColor);
            _alarmRenderer.material.SetColor("_Color_base", _baseColor);
            yield return new WaitForSeconds(blinkDuration);
        }
    }


}
