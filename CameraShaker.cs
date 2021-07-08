using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public Vector3 mReferencePosition;

    public float mShakeStrength;
    public float mShakeDuration = 1f;
    

    private System.Random _mRand;

    void Start()
    {
        _mRand = new System.Random();

    }



    public void Shake() {
        mReferencePosition = transform.position;
        StartCoroutine(Coroutine_Shake());

    }


    IEnumerator Coroutine_Shake() {
        float elapsed = 0f;

        Vector3 displacement = new Vector3();
        do {
            displacement.x = ((float)_mRand.NextDouble()) * 2f - 1f;
            displacement.y = ((float)_mRand.NextDouble()) * 2f - 1f;
            
            transform.position = mReferencePosition + displacement * mShakeStrength;


            yield return null;

            elapsed += Time.deltaTime;

        } while (elapsed < mShakeDuration);

        transform.position = mReferencePosition;

        yield return null;
    }
}
