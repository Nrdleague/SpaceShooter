using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = this.transform.position;
    }

    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        

        float elaspedTime = 0f;
        
        while(elaspedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(yOffset, xOffset, originalPos.z);    

            elaspedTime += Time.deltaTime;

            yield return null;  


        }
        Debug.LogError("Camera did not return to original position");
        transform.localPosition = originalPos;  
    }


}
