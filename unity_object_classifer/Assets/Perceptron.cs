using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class trainingset
{
    public double[] input;
    public double output;
}
public class Perceptron : MonoBehaviour
{
    public trainingset[] ts;
    public double[] weights = { 0, 0 };
    public double totalerror = 0;
    double bias = 0;

    public void train(int epoch)
    {
        setrandomweight();
        for (int i = 0; i < epoch; i++)
        {
            totalerror = 0;
            for (int j = 0; j < ts.Length; j++)
            {
                updateweight(j);
            }
            Debug.Log("Total Error : " + totalerror);
        }
    }
    public double DotProductBias(double[] w, double[] ip)
    {
        if (w == null || ip == null) return -1;
        if (w.Length != ip.Length) return -1;
        double db=0;
        for(int i=0;i<weights.Length;i++)
        {
            db += w[i] * ip[i];
        }
        db += bias;
        return db;
    }
    public double calcOutput(int j)
    {
        double db = DotProductBias(weights, ts[j].input);
        if (db > 0) return 1;
        return 0;
    }
    private void setrandomweight()
    {
        for(int i=0;i<weights.Length;i++)
        {
            weights[i] = UnityEngine.Random.Range(-1f, 1f);
        }
        bias = UnityEngine.Random.Range(-1f, 1f);
    }

    public void updateweight(int i)
    {
        double error = ts[i].output - calcOutput(i);
        totalerror += Mathf.Abs((float)error);
        for(int j=0;j<weights.Length;i++)
        {
            weights[j] = weights[j] + ts[i].input[j] * error;
        }
        bias += error;
    }
    // Start is called before the first frame update
    void Start()
    {
        train(200);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
