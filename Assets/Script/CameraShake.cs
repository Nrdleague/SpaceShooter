using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraShake : MonoBehaviour
{
    private bool _isShaking = false;
    private float _duration = 0.5f;
    private float _magnitude = 0.5f;

    public IEnumerator CameraShakeRoutine()
    {
        Vector3 defualtPosition = transform.position;
        float elapsed = 0f;

        while(elapsed < _duration)
        {

            float xPosition = Random.Range(-0.5f, 0.5f) * _magnitude;
            float yPosition = Random.Range(-0.5f, 0.5f) * _magnitude;
            transform.position = new Vector3(xPosition, yPosition, -10f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = defualtPosition;
    }

    public void startShaking()
    {
        StartCoroutine(CameraShakeRoutine());   
    }



}
