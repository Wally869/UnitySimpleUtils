using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="new GameObjectDrawPool", menuName="ScriptableObjects/Game Object Draw Pool")]
public class GameObjectDrawPool : ScriptableObject
{
    public GameObject[] mGameObjects;
    public float[] mDrawProbabilities;


    private float[] _mCumulativeProbabilities;
    private System.Random _mRand;


    public void CheckInitialized()
    {
        if (_mRand is null)
        {
            _mRand = new System.Random();

            _mCumulativeProbabilities = new float[mDrawProbabilities.Length - 1];
            for (int i = 0; i < _mCumulativeProbabilities.Length; i++)
            {
                _mCumulativeProbabilities[i] = mDrawProbabilities[i];

                if (i > 0)
                {
                    _mCumulativeProbabilities[i] += _mCumulativeProbabilities[i - 1];

                }

            }
        }

    }


    public GameObject Draw_Single()
    {
        CheckInitialized();

        float randomValue = (float)_mRand.NextDouble();

        int k = 0;
        do
        {
            if (randomValue < _mCumulativeProbabilities[k])
            {
                break;

            }

            k++;

        } while (k < _mCumulativeProbabilities.Length);


        return mGameObjects[k];

    }

    public GameObject[] Draw_Multiple(int drawCount)
    {
        CheckInitialized();

        GameObject[] drawnObjects = new GameObject[drawCount];

        int k;
        float randomValue;
        for (int idDraw = 0; idDraw < drawCount; idDraw++)
        {
            randomValue = (float)_mRand.NextDouble();

            k = 0;
            do
            {
                if (randomValue < _mCumulativeProbabilities[k])
                {
                    break;

                }

                k++;

            } while (k < _mCumulativeProbabilities.Length);

            drawnObjects[idDraw] = mGameObjects[k];
        }


        return drawnObjects;

    }


    public void TestDraw()
    {
        CheckInitialized();

        float randomValue = (float)_mRand.NextDouble();

        int k = 0;
        do
        {
            if (randomValue < _mCumulativeProbabilities[k])
            {
                break;

            }

            k++;

        } while (k < _mCumulativeProbabilities.Length);

        Debug.Log((randomValue, k));
        

    }



}
