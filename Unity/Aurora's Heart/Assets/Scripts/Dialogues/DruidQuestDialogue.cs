using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidQuestDialogue {

    /*
	 * Start Dialogue for Quest Druid
	 */
    public string[] StartDialogue()
    {

        string[] dialogue = new string[4];
        dialogue[0] = "Who are you, who dares enter my domains?";
        dialogue[1] = "I'm Freya and I'm looking for my parents. The Great Leviathan told that I can find a Rune here.";
        dialogue[2] = "I will allow your entrance, but only if you bring me 3 mushrooms.";
        dialogue[3] = "I will look for them and bring them to you.";

        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersStart()
    {

        string[] characters = new string[4];
        characters[0] = "Druid";
        characters[1] = "Freya";
        characters[2] = "Druid";
        characters[3] = "Freya";

        return characters;
    }

    public int[] TalkStart() {

        int[] talks = new int[4];
        talks[0] = 1;
        talks[1] = 3;
        talks[2] = 4;
        talks[3] = 6;

        return talks;
    }

    /*
	 * Dialogue for unfinished Quest Druid
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
        characters[0] = "Druid";

        return characters;
    }

    /*
	 * 	Dialogue for when the quest is complete
	 */
    public string[] EndDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "Very well.";

        return dialogue;
    }

    /*
	 * Order of characters talking
	 */
    public string[] CharactersEnd()
    {

        string[] characters = new string[1];
        characters[0] = "Druid";

        return characters;
    }

    /*
    * Dialogue for after finished Quest Druid
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
        characters[0] = "Druid";

        return characters;
    }
}
