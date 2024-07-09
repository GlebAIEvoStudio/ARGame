#region usings 
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using System;
    using System.Linq;
    using UnityEngine.XR.ARFoundation;
    using Unity.XR.CoreUtils;
using Unity.VisualScripting;
#endregion

public class GameManager : MonoBehaviour
{
    #region attributes
        public GameObject ARPlaneGO;
        private ARPlanes ARPScript;
        private bool planes_vis = false;
        private List<GameObject> planes = new List<GameObject>();
        private List<GameObject> trash = new List<GameObject>();
        [SerializeField] private List<string> tags;
    #endregion

    void Start()
    {
        ARPScript = ARPlaneGO.GetComponent<ARPlanes>();
    }

    void Update()
    {
        var trash = new List<GameObject>();
        for(int i = 0; i<tags.Count; i++)
        {
            var updatable_trash = GameObject.FindGameObjectsWithTag(tags[i]);
            trash.AddRange(updatable_trash);
        }

        #region about planes vis _to del
        // var updatable_planes = GameObject.FindGameObjectsWithTag("ARPlane");
        // planes.AddRange(updatable_planes);
        // planes = planes.Distinct().ToList<GameObject>();
        // if(planes_vis)
        // {
            
        // }
        // else
        // {
        //     PlaneManager.planePrefab = null;
        // }
        // for(int i = 0; i < planes.Count; i++)
        // {
        //     if(planes_vis)
        //     {

        //     }
        //     planes[i].GetComponent<LineRenderer>().enabled = planes_vis;
        //     planes[i].GetComponent<MeshRenderer>().enabled = planes_vis;
        // }
        #endregion

    }

    public void ClearScene()
    {
        trash = AddArryToList(trash, GameObject.FindGameObjectsWithTag("Rift"));
        Debug.Log("Clear scene");
        for(int i = 0; i<trash.Count; i++)
        {
            Destroy(trash[i]);
        }
        if(GameObject.FindGameObjectWithTag("Character").activeSelf)
        {
            Destroy(GameObject.FindGameObjectWithTag("Character"));
        }
    }

    public void VisualisePlanes()
    {
        ARPScript.VisualisePlanes(planes_vis);
        planes_vis = !planes_vis;
    }

    private List<GameObject> AddArryToList(List<GameObject> list, GameObject[] array)
    {
        foreach(GameObject go in array)
        {
            list.Add(go);
        }
        return list;
    }
}