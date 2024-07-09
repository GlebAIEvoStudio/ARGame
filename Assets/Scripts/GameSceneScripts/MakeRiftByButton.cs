#region usings
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using System;
    using Unity.VisualScripting;
#endregion
public class MakeRiftByButton : MonoBehaviour
{   

    #region attributes
        public TextMeshProUGUI Button_Text;
        private RaycastHit hit;
        [SerializeField] private double RandomRangeOfRiftSpawn;
        [SerializeField] private int Seconds_For_Timer = 3;
        [SerializeField] private GameObject Rift;
        [SerializeField] private LayerMask layerMaskPlane;
    #endregion

    public void MakeRift()
    {
        StartCoroutine(InstantiateRift(Seconds_For_Timer));
    }

    IEnumerator InstantiateRift(int left)
    {
        while (true)
        {
            Button_Text.text = left.ToString();
            if (left < 1)
            {
                var rand = new System.Random();       
                GameObject[] planes = GameObject.FindGameObjectsWithTag("ARPlane");
                int i = rand.Next(planes.Length-1);
                Vector3 RayPos = new Vector3(GetRandomFloat(-RandomRangeOfRiftSpawn,RandomRangeOfRiftSpawn), 3, GetRandomFloat(-RandomRangeOfRiftSpawn,RandomRangeOfRiftSpawn));
                while(true)
                {
                    if(CheckTheGround(RayPos+planes[i].transform.position))
                    {

                        Instantiate(Rift, hit.point + Rift.transform.lossyScale/2, Rift.transform.rotation);
                        break;
                    }
                    RayPos = new Vector3(GetRandomFloat(-RandomRangeOfRiftSpawn,RandomRangeOfRiftSpawn), 3, GetRandomFloat(-RandomRangeOfRiftSpawn,RandomRangeOfRiftSpawn));
                }
                Button_Text.text = "Rift spawned";
                yield return new WaitForSeconds(1);
                Button_Text.text = "Make rift again";
                StopCoroutine(InstantiateRift(Seconds_For_Timer));
                break;
            }
            left--;
            yield return new WaitForSeconds(1);
        }
    }
    private float GetRandomFloat(double min, double max)
    {
        var floatrand = new Unity.Mathematics.Random();
        double frand = floatrand.NextDouble(min,max);
        return (float)frand;
    }

    private bool CheckTheGround(Vector3 position)
    {
        Ray ray = new Ray(position, -transform.up*5f);
        return Physics.Raycast(ray, out hit, layerMaskPlane);
    }
}