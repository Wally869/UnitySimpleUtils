using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRPG2D : MonoBehaviour
{
    public Transform mTarget;
    public Vector2 mSizeMapInUnits;


    private Vector3 _mPositionTracking; // = new Vector3(0f, 0f, 0f);

    private float _mCameraSize;
    private float _mWidthCameraSize;

    void Start()
    {
        Camera cam = GetComponent<Camera>();


        _mPositionTracking = new Vector3(mTarget.position.x, mTarget.position.y, cam.transform.position.z);


        // Ensure camera is orthographic, get vertical size data (size is 1/2 height of viewport)
        // then compute the equivalent width size based on resolution and cache both values
        cam.orthographic = true;
        _mCameraSize = cam.orthographicSize;
        _mWidthCameraSize = cam.pixelWidth / (float)cam.pixelHeight * _mCameraSize;

    }


    private void LateUpdate()
    {
        _mPositionTracking.x = mTarget.position.x;
        _mPositionTracking.y = mTarget.position.y;

        // Check if outside of map is visible on both x and y axis and adjust camera position accordingly
        if (_mPositionTracking.y - _mCameraSize < 0)
        {
            _mPositionTracking.y = _mCameraSize;

        } else if (_mPositionTracking.y + _mCameraSize > mSizeMapInUnits.y)
        {
            _mPositionTracking.y = mSizeMapInUnits.y - _mCameraSize;

        } 

        if (_mPositionTracking.x - _mWidthCameraSize < 0)
        {
            _mPositionTracking.x = _mWidthCameraSize;

        }
        else if (_mPositionTracking.x + _mWidthCameraSize > mSizeMapInUnits.x)
        {
            _mPositionTracking.x = mSizeMapInUnits.x - _mWidthCameraSize;

        } 

        transform.position = _mPositionTracking;

    }
}
