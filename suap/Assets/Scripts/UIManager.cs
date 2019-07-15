using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image oil;
    public Transform lightN;

    private int lightState;

    void Start()
    {
        lightState = 0; //초기 상태;
    }

    void Update()
    {
        OilCheck();
    }

    public void SetFillAmount(float amount)
    {
        oil.fillAmount += amount;
    }

    private void OilCheck()
    {
        oil.fillAmount -= 0.0005f;

        if(lightState == 0)
        {
            if(oil.fillAmount <= 0.7f)
            {
                StartCoroutine(LightFadeInOut(true));
                lightState = 1;
                return;
            }

        }else if(lightState == 1)
        {
            if (oil.fillAmount <= 0.3f)
            {
                StartCoroutine(LightFadeInOut(true));
                lightState = 2;
                return;

            }
            else if(oil.fillAmount > 0.7f)
            {
                StartCoroutine(LightFadeInOut(false));
                lightState = 0;
                return;
            }
        }
        else
        {
            if (oil.fillAmount > 0.3f)
            {
                StartCoroutine(LightFadeInOut(false));
                lightState = 1;
                return;
            }
        }
    }

    private IEnumerator LightFadeInOut(bool isFadeIn)
    {
        Vector3 lightLocalScale = lightN.localScale;
        if (isFadeIn)
        {
            Debug.Log("FadeInStart");
            while((lightN.localScale.x > (lightLocalScale.x - 1)))
            {
                lightN.localScale -= new Vector3(0.05f, 0.05f, 0);
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            Debug.Log("FadeOutStart");
            while ((lightN.localScale.x < (lightLocalScale.x + 1)))
            {
                lightN.localScale += new Vector3(0.05f, 0.05f, 0);
                yield return new WaitForEndOfFrame();
            }
        }
        yield break;
    }
}
