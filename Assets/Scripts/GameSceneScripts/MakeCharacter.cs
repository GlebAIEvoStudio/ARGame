#region usings 
using System;
using System.Collections;
    using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
#endregion

public class MakeCharacter : MonoBehaviour
{
    #region attributes
        private bool firsttap = true;
        private Alonso AlonsoScript;
        private List<GameObject> planes = new List<GameObject>();
        public GameObject character;
    #endregion

    public void Update()
    {
        var updatable_planes = GameObject.FindGameObjectsWithTag("ARPlane");
        planes.AddRange(updatable_planes);
    }

    public void Make_Character()
    {
        if(firsttap)
        {
            AlonsoScript = character.GetComponent<Alonso>();
            var rand = new System.Random();
            int i = rand.Next(planes.Count-1);
            character.transform.position = planes[i].transform.position;
            //Instantiate(character,planes[i].transform.position+character.transform.lossyScale/2,character.transform.rotation);
            //Instantiate(character,new Vector3((float)-0.005, (float)-0.5, 3), new quaternion(0,0,0,0));
            character.SetActive(true);
            firsttap = !firsttap;
            //AlonsoScript.AlonsoSpawned();
        }
        else
        {
            AlonsoScript.speed = AlonsoScript.speed + (float)0.05;
            if(AlonsoScript.speed == 1)
            {
                AlonsoScript.speed = 0;
            }
        }
    }
}
