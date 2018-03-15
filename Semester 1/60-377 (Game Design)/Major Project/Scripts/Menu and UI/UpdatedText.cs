using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuUI
{
    [RequireComponent(typeof(TextMesh))]
    public class TimedText : MonoBehaviour
    {
        List<System.Action> updateActions;

        public void AddAction(System.Action action)
        {
            this.updateActions.Add(action);
        }

        void Update()
        {
            foreach (System.Action action in this.updateActions)
                action();
        }
    }
}