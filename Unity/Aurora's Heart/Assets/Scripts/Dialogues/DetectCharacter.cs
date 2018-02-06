namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DetectCharacter : MonoBehaviour {

	    [SerializeField]
	    private InteractUI interactUI = null;
        [SerializeField]
        Player player;


        private int layerMask = 1 << 16;
	    private Interactable target = null;

	    void Awake(){
		
		    Physics.IgnoreLayerCollision (0, 15, true);

	    }

	    void FixedUpdate(){

            if (target == null || (target != null && !target.IsInteracting()))
            {
                HitTarget();
            }


            if ((Input.GetKeyDown(KeyCode.Return) || player.CanTalk) && target != null && target.isSeen && !target.IsInteracting()) //TODO: Change to VR
            {
                interactUI.gameObject.SetActive(false);
                target.interaction.Interact();
            }
        }

	    void HitTarget(){
		
		    Ray ray = GetComponent<Camera> ().ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		    RaycastHit hit;  

		    if (Physics.Raycast(ray, out hit, 20, layerMask)){
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                if (interactable != null){ // If hit object has needed script Interactable

                   

                    if (target != interactable || target == interactable && !target.IsInteracting())
                    { // if I`m not already looking at it

                        target = interactable;

                        if (target.nameID == "Hugrel")
                        {
                            target.interaction.Interact();
                        }
                        else
                        {
                            //DisplayInteractUI();
                            interactable.isSeen = true;
                        }

                    }
			    }
			    else if (target != null) {
				    target = null;
				    interactUI.gameObject.SetActive (false);
                    player.TalkingInteractible = false;
                    interactable.isSeen = false;
                }
		    }
		    else if (target != null) {
			    target = null;
                interactUI.gameObject.SetActive (false);
                player.TalkingInteractible = false;
            }
	    }

   
        public void DisplayInteractUI()
        {
            Interactable.TypeInteractable type = target.type;
            string text = "Error";
            switch (type)
            {
                case Interactable.TypeInteractable.Character:
                    text = "Talk to " + target.nameID + ".";
                    break;

                case Interactable.TypeInteractable.Pickup:
                    text = "Pickup " + target.nameID + ".";
                    break;
                case Interactable.TypeInteractable.ObjPlacer:
                    text = "Inspect " + target.nameID + ".";
                    break;
                default:
                    Debug.Log("Unknown interactable type");
                    break;

            }
            interactUI.gameObject.SetActive(true);
            interactUI.SetText(text);
            player.TalkingInteractible = true;
        }
	
    }
}