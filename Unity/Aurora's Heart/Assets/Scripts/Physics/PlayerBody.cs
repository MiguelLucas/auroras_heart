namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerBody : MonoBehaviour {

        [SerializeField]
        private VRTK_BodyPhysics bodyPhysics;

	    // Use this for initialization
	    void Start () {
            bodyPhysics.StartColliding += BodyPhysics_StartColliding;
            bodyPhysics.tag = "Player";
        }

        private void BodyPhysics_StartColliding(object sender, BodyPhysicsEventArgs e) {
            print("BodyPhysics colliding with " + bodyPhysics.GetCurrentCollidingObject().tag + " " + bodyPhysics.GetCurrentCollidingObject().name);
        }

        // Update is called once per frame
        void Update () {
		
	    }
    }
}