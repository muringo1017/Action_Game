using System;
using UnityEngine;

public class DeactiveGameObject : MonoBehaviour
{
   public float timer = 2f;

   private void Start()
   {
      Invoke("DeactivateAfterTime", timer);
   }

   void DeactivateAfterTime()
   {
      gameObject.SetActive(false);   
   }
}
