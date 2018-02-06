namespace VRTK
{
    using System.Collections;
    using UnityEngine;
    using UnityStandardAssets.CrossPlatformInput;

    public class RightControllerHandler : MonoBehaviour
    {

        [SerializeField]
        private Player player;
        [SerializeField]
        private float walkSoundDistance = 300;
        [SerializeField]
        private float footstepSoundDistance = 30;

        private VRTK_ControllerEvents controllerEvents;
        private VRTK_InteractGrab grabber;
        private VRTK_TouchpadControl touchpadControl;
        private GameObject menu;

        private GvrAudioSource audioSource;

        private float distanceWalked = 0;
        private float distanceFootstep = 0;

        


        // Use this for initialization
        void Start()
        {
            controllerEvents = GetComponent<VRTK_ControllerEvents>();
            if (GetComponent<VRTK_ControllerEvents>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "Player", "VRTK_ControllerEvents", "the same"));
                return;
            }

            grabber = GetComponent<VRTK_InteractGrab>();
            if (grabber == null) {
                print("Grabber null");
                return;
            }

            touchpadControl = GetComponent<VRTK_TouchpadControl>();
            if (touchpadControl == null) {
                print("Touchpad control null");
                return;
            }

            controllerEvents.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            controllerEvents.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            controllerEvents.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
            controllerEvents.StartMenuPressed += new ControllerInteractionEventHandler(DoStartMenuPressed);
            controllerEvents.ButtonOnePressed += new ControllerInteractionEventHandler(DoButtonOnePressed);
            controllerEvents.ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTwoPressed);
            controllerEvents.TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);

            grabber.ControllerGrabInteractableObject += new ObjectInteractEventHandler(ObjectGrabbed);
            grabber.ControllerUngrabInteractableObject += new ObjectInteractEventHandler(ObjectUngrabbed);

            audioSource = GetComponent<GvrAudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (distanceWalked > walkSoundDistance) {
                player.playWalkSound();
                distanceWalked = 0;
            }

            if (distanceFootstep > footstepSoundDistance) {
                player.playFootstepSound();
                player.changeWaterSoundSource();
                distanceFootstep = 0;
            }

            Vector2 axis = controllerEvents.GetTouchpadAxis();
            float distance = Vector2.Distance(axis, new Vector2(0,0));
            if (distance > 0) {
                distanceWalked += distance;
                distanceFootstep += distance;
            }

            if (grabber.GetGrabbedObject() != null) {
                if (grabber.GetGrabbedObject().tag == "Torch") {
                    if (player.TorchFireCounter > player.TorchFireRate && GameManager.gameManager.Spirits > 0) {
                        player.TorchFireCounter = 0;
                        player.useSpirit();
                    }
                    if (GameManager.gameManager.Spirits <= 0) {
                        grabber.GetGrabbedObject().transform.Find("Torchfire").gameObject.SetActive(false);
                    }
                }
            }
            
            
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            if (!player.TalkingInteractible) {
                if (player.CanTalk)
                    player.CanTalk = false;
                else
                    audioSource.PlayOneShot(player.castSpell(transform));
            } else {
                player.CanTalk = true;
            }
                
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e) {
           player.CanTalk = false;
        }

        private void DoGripPressed(object sender, ControllerInteractionEventArgs e) {
            print("carreguei grip");
            if (grabber.GetGrabbedObject() != null) {
                print(grabber.GetGrabbedObject().tag);
                //if (grabber.gameObject.ta)
            }
        }

        private void DoStartMenuPressed(object sender, ControllerInteractionEventArgs e) {
            print("Carreguei start direito");
        }

        private void DoButtonOnePressed(object sender, ControllerInteractionEventArgs e) {
            print("Carreguei 1 direito");
        }

        private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e) {
            print("Carreguei 2 direito");
        }

        private void ObjectGrabbed(object sender, ObjectInteractEventArgs e) {
            print("Apanhei ");
            if (grabber.GetGrabbedObject().tag == "Mushroom") {
                if (grabber.GetGrabbedObject().transform.Find("mushrooms/PComponent Air Explosion") != null) {
                    Destroy(grabber.GetGrabbedObject().transform.Find("mushrooms/PComponent Air Explosion").gameObject);
                }
                    
            }

            if (grabber.GetGrabbedObject().tag == "RockClimb") {
                audioSource.PlayOneShot(player.playClimbSound());
            }

            if (grabber.GetGrabbedObject().tag == "Chest") {
                audioSource.PlayOneShot(player.playGrabChestSound());
                StartCoroutine(playSoundWithDelay(player.playOpenChestSound(), 1.5f));
            }

            if (grabber.GetGrabbedObject().tag == "Scroll") {
                audioSource.PlayOneShot(player.playGrabScrollSound());
            }

            if (grabber.GetGrabbedObject().tag == "Torch") {
                player.HoldingTorch = true;
                grabber.GetGrabbedObject().transform.Find("Torchfire").gameObject.SetActive(true);
            }

            if (grabber.GetGrabbedObject().tag == "SkuldRune") {
                player.grabSkuldRune();
            }
        }

        private void ObjectUngrabbed(object sender, ObjectInteractEventArgs e) {
            if (grabber.GetGrabbedObject().tag == "Mushroom") {
                Destroy(grabber.GetGrabbedObject().GetComponent<Rigidbody>());
                Destroy(grabber.GetGrabbedObject().GetComponent<VRTK_InteractableObject>());
                StartCoroutine(DisappearObject(grabber.GetGrabbedObject()));
                player.caughtMushroom();
            }

            if (grabber.GetGrabbedObject().tag == "Scroll") {
                Destroy(grabber.GetGrabbedObject().GetComponent<Rigidbody>());
                Destroy(grabber.GetGrabbedObject().GetComponent<VRTK_InteractableObject>());
                StartCoroutine(DisappearObject(grabber.GetGrabbedObject()));
                player.caughtScroll();
            }

            if (grabber.GetGrabbedObject().tag == "Torch") {
                grabber.GetGrabbedObject().transform.Find("Torchfire").gameObject.SetActive(false);
                player.HoldingTorch = false;
                StartCoroutine(playSoundWithDelay(player.playTorchDropSound(), 0.5f));
            }

            if (grabber.GetGrabbedObject().tag == "SkuldRune") {
                Destroy(grabber.GetGrabbedObject().GetComponent<Rigidbody>());
                Destroy(grabber.GetGrabbedObject().GetComponent<VRTK_InteractableObject>());
                StartCoroutine(DisappearObject(grabber.GetGrabbedObject()));
            }
        }

        private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e) {
            distanceFootstep += 5;
        }

        IEnumerator DisappearObject(GameObject obj) {
            //Color color = obj.GetComponentInChildren<MeshRenderer>().material.color;
            MeshRenderer color = obj.GetComponentInChildren<MeshRenderer>();
            print("Starting to fade");
            while (color.material.color.a > 0) {
                Color newAlpha = color.material.color;
                newAlpha.a -= 0.04f;
                color.material.color = newAlpha;
                print("Fading " + color.material.color.a);
                yield return new WaitForSeconds(0.2f);
            }

            Destroy(obj);
        }

        IEnumerator playSoundWithDelay(AudioClip clip, float delay) {
            yield return new WaitForSeconds(delay);
            audioSource.PlayOneShot(clip);
        }

    }
}