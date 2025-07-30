using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
        void OnTriggerExit2D(Collider2D finishLineCollider)
        {
            if (finishLineCollider.CompareTag("Player"))
            {
                Debug.Log("You have crossed the finish line!");
            }
            
        }
}
