using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Finish object of level.
    /// </summary>
    class FinishScript : MonoBehaviour
    {
        /// <summary>
        /// Start method of unity script.
        /// </summary>
        public void Start()
        {
            this.gameObject.name = "Finish";
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().isTrigger = true;
        }

        /// <summary>
        /// Creates finish unity object at specific position with specific local scale.
        /// </summary>
        /// <param name="position">Position where to create finish</param>
        /// <param name="scale">Local scale of finish</param>
        /// <returns>Instance of finish unity object</returns>
        public static GameObject CreateFinishObject(Vector3 position, Vector3 scale)
        {
            GameObject finish = GameObject.CreatePrimitive(PrimitiveType.Cube);
            finish.transform.position = position;
            finish.transform.localScale = scale;
            finish.AddComponent<FinishScript>();
            return finish;
        }
    }
}
