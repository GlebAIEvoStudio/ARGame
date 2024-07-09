#region usings 
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.XR.ARFoundation;
    using UnityEngine.XR.ARSubsystems;
#endregion
public class Alonso : MonoBehaviour
{
    #region attributes
    
        public float speed = 0;
        public bool walk = false;
        private bool spawned = false;
        public Animator animator;
        private ARRaycastManager ARRaycastManagerScript;
        private List<ARRaycastHit> Hits;
        private List<GameObject> planes = new List<GameObject>();
        [SerializeField] public List<LayerMask> layerMasks;
    #endregion

    public void Start()
    {

    }

    public void Update() 
    {
        animator.SetFloat("speed", speed);
        //animator.SetFloat("pow", GetRandomFloat(0,1));
        // Touch touch = Input.GetTouch(0);
        // var rand = new System.Random();
        // ARRaycastManagerScript.Raycast(touch.position, Hits);
        // if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        // {
        // 
        // }
    }

    // public void AlonsoSpawned()
    // {
    //     //animator = GetComponent<Animator>();
    //     animator.SetBool("walk", walk);
    //     spawned = true;
    // }

    private bool V3CheckTheMask(Vector3 position, Vector3 rotation, LayerMask mask)
    {
        Ray ray = new Ray(position, rotation*Mathf.Infinity);
        return Physics.Raycast(ray, /*out hit,*/ mask);
    }

    private float GetRandomFloat(int min, int max)
    {
        var floatrand = new System.Random();
        float frand = floatrand.Next(min, max);
        return frand;
    }
}
