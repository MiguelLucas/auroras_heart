using System.Collections;
using System.Collections.Generic;

public class LeviathanQuestDialogue {

	/*
	 * Start Dialogue for Quest Leviathan
	 */
	public string[] StartDialogue(){

		string[] dialogue = new string[4];
		dialogue [0] = "Hello child. I see you found Hugrel.";
		dialogue [1] = "I need 20 spirits to lift the barriers.";
		dialogue [2] = "Where I can find these spirits?";
		dialogue [3] = "In the forest behind us. Good luck.";

		return dialogue;
	}
	/*
	 * Order of characters talking
	 */
	public string[] CharactersStart(){

		string[] characters = new string[4];
		characters [0] = "Leviathan";
		characters [1] = "Leviathan";
		characters [2] = "Freya";
		characters [3] = "Leviathan";

		return characters;
	}

    /*
	 * Dialogue for unfinished Quest Leviathan
	 */
    public string[] UnfinishedDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "You haven't catch everything.";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersUnfinished()
    {

        string[] characters = new string[1];
        characters[0] = "Leviathan";
        
        return characters;
    }

    /*
	 * 	Dialogue for when the quest is complete
	 */
    public string[] EndDialogue(){

		string[] dialogue = new string[4];
        dialogue[0] = "Very well. Now I have the power to lift the barriers.";
        dialogue[1] = ".....";
        dialogue[2] = "Now you can continue your journey. Here, take the Rune of Verthandi, you're going to need it later in your journey.";
        dialogue[3] = "Thank you.";

        return dialogue;
	}

	/*
	 * Order of characters talking
	 */
	public string[] CharactersEnd(){

        string[] characters = new string[4];
        characters[0] = "Leviathan";
        characters[0] = "Leviathan";
        characters[0] = "Leviathan";
        characters[0] = "Freya";

        return characters;
	}

    /*
    * Dialogue for after finished Quest Leviathan
    */
    public string[] AfterDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "How is your journey?";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersAfter()
    {

        string[] characters = new string[1];
        characters[0] = "Leviathan";

        return characters;
    }

}
