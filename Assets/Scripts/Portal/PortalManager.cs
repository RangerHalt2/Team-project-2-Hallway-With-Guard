//Purpose: This manager will prevent the creation of more than 1 type of portal. The process is deleting all but the oldest portals if there are more than 1 portals placed.
//Author: Logan Baysinger.
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField] private GreenPortal greenFab;
    [SerializeField] private PurplePortal purpleFab;

    private GreenPortal[] greenPortals;
    private PurplePortal[] purplePortals;

    void Update()
    {
        greenPortals = Resources.FindObjectsOfTypeAll<GreenPortal>();
        purplePortals = Resources.FindObjectsOfTypeAll<PurplePortal>();

        if (greenPortals.Length > 2)
        {
            float indexToKeep = 0;
            float time1 = 0;
            float time2 = 0;
            for (int i = 0; i < greenPortals.Length - 1; i++)
            {
                if (i == greenPortals.Length - 1) break;
                time1 = Time.time - greenPortals[i].startTime;
                time2 = Time.time - greenPortals[i + 1].startTime;
                float timeKept = Time.time - greenPortals[(int)indexToKeep].startTime;
                if (timeKept < time1 && timeKept < time2)
                {
                    continue;
                }
                if (time1 > time2)
                    indexToKeep = i + 1;
                if (time1 < time2)
                    indexToKeep = i;
            }

            for (int i = 0; i < greenPortals.Length; i++)
            {
                if (greenPortals.Length <= 2) break;
                if (i == indexToKeep) continue;
                if (greenPortals[i].gameObject != greenFab.gameObject)
                    Destroy(greenPortals[i].gameObject);
            }
        }
        /*
         * THE TWO MUST BE DONE INDIVIDUALLY, THE PORTAL SYSTEM IS NOT REFINED ENOUGH FOR IT NOT TO BE.
         */
        if(purplePortals.Length > 2)
        {
            float indexToKeep = 0;
            float time1 = 0;
            float time2 = 0;
            for (int i = 0; i < purplePortals.Length - 1; i++)
            {
                if (i == purplePortals.Length - 1) break;
                time1 = Time.time - purplePortals[i].startTime;
                time2 = Time.time - purplePortals[i + 1].startTime;
                float timeKept = Time.time - purplePortals[(int)indexToKeep].startTime;
                if (timeKept < time1 && timeKept < time2)
                {
                    continue;
                }
                if (time1 > time2)
                    indexToKeep = i + 1;
                if (time1 < time2)
                    indexToKeep = i;
            }

            for (int i = 0; i < purplePortals.Length; i++)
            {
                if (purplePortals.Length <= 2) break;
                if (i == indexToKeep) continue;
                if (purplePortals[i].gameObject != purpleFab.gameObject)
                    Destroy(purplePortals[i].gameObject);
            }
        }

    }
}
