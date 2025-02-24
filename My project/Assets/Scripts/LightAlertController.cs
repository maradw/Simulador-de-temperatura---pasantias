using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightAlertController : MonoBehaviour
{
    Renderer _alarmRenderer;

    Color _baseColor;
    float _baseTransparency;
    float _renderT;
    void Start()
    { 
         _alarmRenderer = GetComponent<Renderer>();
        _baseColor = _alarmRenderer.material.color;
        _baseTransparency = _alarmRenderer.material.color.a;
    }


    void Update()
    {
        
    }
    void LightsOn()
    {

        // _alarmRenderer.material.SetColor("_Color", Color.green);
        //_alarmRenderer.material.SetColor("_Color_base", Color.green);
        //parpadeo de luces
        StartCoroutine(FadeIn());
    }
    void OnEnable()
    {
        ControlPanel.OnSimulatorOnOff += LightsOn;
    }
    void OnDisable()
    {
        ControlPanel.OnSimulatorOnOff -= LightsOn;
    }
    public void CallFadeOut()
    {
        StartCoroutine(FadeIn());

    }
    IEnumerator FadeIn()
    {

        Color startColor = _baseColor; 
        Color endColor = Color.red;    

        
        float duration = 2f;

        float startTransparency = 0;
        float endTransparency = 1;

        // Comienza el fade
        for (float color = 0f; color <= 1f; color += 0.15f)
        {
            _baseColor = Color.Lerp(startColor, endColor, color);
            _baseTransparency = Mathf.Lerp(startTransparency, endTransparency, color);
           // _alarmRenderer.material.SetFloat("_Transparency",1) ;
            _alarmRenderer.material.color = _baseColor;
            _alarmRenderer.material.SetFloat("_Transparency", _baseTransparency);

            yield return new WaitForSeconds(duration * 0.15f); 
        }
        

        _alarmRenderer.material.color = endColor;




        /*//currentColor = fadeImage.color;
        for (float color = 1f; color >= -1; color = color - 0.15f)
        {
            _baseColor = Color.green;
            _baseColor = Color.red; 
            //currentColor.a = color;
            //fadeImage.color = currentColor;
            yield return new WaitForSeconds(0.2f);
        }*/
    }

}
