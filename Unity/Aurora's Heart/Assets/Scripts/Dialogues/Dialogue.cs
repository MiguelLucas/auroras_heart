    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;

    public class Dialogue : MonoBehaviour {

        [SerializeField]
        private string[] dialogueStrings;
        [SerializeField]
        private string[] characterStrings;
        [SerializeField]
        private int[] talkIndexes;
        [SerializeField]
        private float secondsBetweenCharacters = 0.15f;
        [SerializeField]
        private float characterRateMultiplier = 0.5f;
        [SerializeField]
        private Text _dialogueText;
        [SerializeField]
        private Text _characterText;
        [SerializeField]
        private Player player;

        private bool _isStringBeingRevealed = false;
        private bool _isDialoguePlaying = false;
        private bool _isEndOfDialogue = false;
        private bool _playDialogue = false;
        private bool _finished = false;

        [SerializeField]
        private GameObject ContinueIcon;
        [SerializeField]
        private GameObject StopIcon;

        public string[] DialogueStrings {
            get {
                return dialogueStrings;
            }

            set {
                dialogueStrings = value;
            }
        }

        public string[] CharacterStrings {
            get {
                return characterStrings;
            }

            set {
                characterStrings = value;
            }
        }

        public bool PlayDialogue {
            get {
                return _playDialogue;
            }

            set {
                _playDialogue = value;
            }
        }

        public bool IsDialoguePlaying {
            get {
                return _isDialoguePlaying;
            }

            set {
                _isDialoguePlaying = value;
            }
        }

        public bool Finished {
            get {
                return _finished;
            }

            set {
                _finished = value;
            }
        }

    public int[] TalkIndexes {
        get {
            return talkIndexes;
        }

        set {
            talkIndexes = value;
        }
    }

    // Use this for initialization
    void Start() {
            //_textComponent = GetComponent<Text>();
            _dialogueText.text = "";
            _characterText.text = "";

            HideIcons();
        }

        // Update is called once per frame
        void Update() {
            if (_playDialogue) {
                if (!IsDialoguePlaying) {
                    IsDialoguePlaying = true;
                    StartCoroutine(StartDialogue());
                }

            }
        }

        public void Activate() {
            this.gameObject.SetActive(true);
        }

        private IEnumerator StartDialogue() {
            int dialogueLength = dialogueStrings.Length;
            int currentDialogueIndex = 0;
            int index = 0;

            while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed) {
                if (!_isStringBeingRevealed) {
                    index = currentDialogueIndex++;

                    //Character talking
                    _characterText.text = characterStrings[index];
                    //player.playTalk(characterStrings[index], talkIndexes[index]);

                    _isStringBeingRevealed = true;

                    StartCoroutine(DisplayString(dialogueStrings[index]));

                    if (currentDialogueIndex >= dialogueLength) {
                        _isEndOfDialogue = true;

                    }
                }

                yield return 0;
            }

            while (true) {
                if (Input.GetKeyDown(KeyCode.Return) || player.CanTalk) //TODO: Change VR
                {
                    break;

                }

                yield return 0;
            }

            //End of dialogue
            HideIcons();
            _dialogueText.text = "";
            _characterText.text = "";
            IsDialoguePlaying = false;
            _isEndOfDialogue = false;
            _playDialogue = false;

        }

        private IEnumerator DisplayString(string stringToDisplay) {
            int stringLength = stringToDisplay.Length;
            int currentCharacterIndex = 0;

            HideIcons();

            _dialogueText.text = "";

            while (currentCharacterIndex < stringLength) {
                _dialogueText.text += stringToDisplay[currentCharacterIndex];
                currentCharacterIndex++;

                if (currentCharacterIndex < stringLength) {
                    if (Input.GetKey(KeyCode.Return) || player.CanTalk) //TODO: Change VR
                    {
                        yield return new WaitForSeconds(secondsBetweenCharacters * characterRateMultiplier);
                    } else {
                        yield return new WaitForSeconds(secondsBetweenCharacters);
                    }
                } else {
                    break;
                }
            }

            ShowIcon();

            while (true) {
                if (Input.GetKeyDown(KeyCode.Return) || player.CanTalk) //TODO: Change VR
                {
                    break;
                }

                yield return 0;
            }

            HideIcons();

            _isStringBeingRevealed = false;
            _dialogueText.text = "";
            if (!IsDialoguePlaying) {
                this.gameObject.SetActive(false);
                _finished = true;
            }


        }

        private void HideIcons() {
            ContinueIcon.SetActive(false);
            StopIcon.SetActive(false);
        }

        private void ShowIcon() {
            if (_isEndOfDialogue) {
                StopIcon.SetActive(true);
            } else {
                ContinueIcon.SetActive(true);
            }

        }
    }