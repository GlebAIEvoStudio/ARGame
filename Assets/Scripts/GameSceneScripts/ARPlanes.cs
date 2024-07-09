using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlanes : MonoBehaviour
{
   #region attributes
        private LineRenderer lr;
        private MeshRenderer mr;
    #endregion

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        mr = GetComponent<MeshRenderer>();
    }

    public void VisualisePlanes(bool par)
    {
        lr.enabled = par;
        mr.enabled = par;
    }
}
