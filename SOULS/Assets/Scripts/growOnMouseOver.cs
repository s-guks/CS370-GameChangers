using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growOnMouseOver : MonoBehaviour
{
    [SerializeField]
    private Vector3 finalScaleMultiplier = new Vector3(1.08f, 1.05f, 1.08f);
    [SerializeField]
    private AnimationCurve animationCurve;

    bool IsMouseOver = false;
    Vector3 initScale, currentScale, finalScale;
    bool isAnimating = false;

    Coroutine co = null;
    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        finalScale = new Vector3(initScale.x * finalScaleMultiplier.x, initScale.y * finalScaleMultiplier.y, initScale.z * finalScaleMultiplier.z);
    }

    void OnMouseEnter()
    {
        Grow(true);
    }

    void OnMouseExit()
    {
        Grow(false);
    }

    public void Grow(bool isMouseOver)
    {
        IsMouseOver = isMouseOver;

        if(isAnimating)
            return;
        //else
        if(co != null)
            StopCoroutine(co);
        
        currentScale = transform.localScale;

        co = StartCoroutine(AnimateGrow());
    }

    IEnumerator AnimateGrow()
    {
        float elapsed = 0.0f;
        isAnimating = true;
        while(isAnimating){
            if(IsMouseOver)
                transform.localScale = Vector3.Lerp(currentScale, finalScale, animationCurve.Evaluate(elapsed));
            else
                transform.localScale = Vector3.Lerp(currentScale, initScale, animationCurve.Evaluate(elapsed));
        
            elapsed += Time.deltaTime;
            
            if(elapsed >= animationCurve[animationCurve.length-1].time) 
            {
                isAnimating = false;
                if(IsMouseOver) //ensures animations end at correct scale
                    transform.localScale = finalScale;
                else
                    transform.localScale = initScale;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
