namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LeftControllerHandler : MonoBehaviour
    {

        [SerializeField]
        private Player player;
        [SerializeField]
        private float leftLimit;
        [SerializeField]
        private float rightLimit;

        private bool talkingInteractible = false;

        private GameObject menu;
        private CanvasGroup canvas;

        private GvrAudioSource audioSource;
        

        private VRTK_InteractGrab grabber;

        public bool TalkingInteractible {
            get {
                return talkingInteractible;
            }

            set {
                talkingInteractible = value;
            }
        }

        // Use this for initialization
        void Start()
        {
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

            GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            GetComponent<VRTK_ControllerEvents>().ButtonOnePressed += new ControllerInteractionEventHandler(DoButtonOnePressed);
            GetComponent<VRTK_ControllerEvents>().ButtonOneReleased += new ControllerInteractionEventHandler(DoButtonOneReleased);

            GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTwoPressed);
            GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTwoReleased);

            grabber.ControllerGrabInteractableObject += new ObjectInteractEventHandler(ObjectGrabbed);
            grabber.ControllerUngrabInteractableObject += new ObjectInteractEventHandler(ObjectUngrabbed);

            menu = transform.Find("Menu").gameObject;
            if (menu == null) {
                print("Wrist Menu null");
                return;
            }
            menu.SetActive(true);

            audioSource = GetComponent<GvrAudioSource>();
            canvas = menu.GetComponent<CanvasGroup>();
        }

        // Update is called once per frame
        void Update()
        {
            float headingAngle = Mathf.Atan2(transform.right.z, transform.right.x) * Mathf.Rad2Deg;
            Transform cameraTransform = player.transform.parent.Find("Camera (eye)");
            float playerHeadingAngle = Mathf.Atan2(cameraTransform.right.z, cameraTransform.right.x) * Mathf.Rad2Deg;

            float newOffset = headingAngle - playerHeadingAngle;
            if (newOffset > 180)
                newOffset -= 360;
            if (newOffset < -180)
                newOffset += 360;

            if (newOffset > rightLimit || newOffset < leftLimit) {

                menu.SetActive(true);
                fadeMenu(true);
                player.WristMenuActivated = true;
            } else {
                fadeMenu(false);
                player.WristMenuActivated = false;
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
            if (!talkingInteractible)
                player.createSpiritLight(transform);
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            //print("TRIGGER ESQUERDO LARGADO");
        }

        private void DoButtonOnePressed(object sender, ControllerInteractionEventArgs e)
        {
           // print("TRIGGER ESQUERDO ");
        }
        private void DoButtonOneReleased(object sender, ControllerInteractionEventArgs e)
        {
           // print("TRIGGER ESQUERDO ");
        }
        private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
        {
            //print("TRIGGER ESQUERDO ");
        }
        private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
        {
           // print("TRIGGER ESQUERDO ");
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

        private void fadeMenu(bool fade) {

            if (!fade) {
                if (canvas.alpha > 0) {
                    canvas.alpha -= 0.07f;
                }
            } else {
                if (canvas.alpha < 1) {
                    canvas.alpha += 0.07f;
                }
            }
        }

        IEnumerator DisappearObject(GameObject obj) {
            //Color color = obj.GetComponentInChildren<MeshRenderer>().material.color;
            MeshRenderer renderer = obj.GetComponentInChildren<MeshRenderer>();
            print("Starting to fade");
            while (renderer.material.color.a > 0) {
                Color newAlpha = renderer.material.color;
                newAlpha.a -= 0.05f;
                renderer.material.color = newAlpha;
                print("Fading " + renderer.material.color.a);
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