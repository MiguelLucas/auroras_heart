using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolleQuestDialogue
{
    /*
      * Start Dialogue for Quest Temple
      */
    public string[] StartDialogue()
    {

        string[] dialogue = new string[4];
        dialogue[0] = "I'm Holle and I'm the guardian of this sacred place.";
        dialogue[1] = "To continue your quest, and revive Yggdrasil you must find four scrolls and place them on the altar.";
        dialogue[2] = "This scrolls, where are they?";
        dialogue[3] = "In that I cannot help you. You must prove yourself. When you place them on the altar, come back to talk to me.";

        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersStart()
    {

        string[] characters = new string[4];
        characters[0] = "Holle";
        characters[1] = "Holle";
        characters[2] = "Freya";
        characters[3] = "Holle";

        return characters;
    }

    /*
	 * Dialogue for unfinished Quest Temple
	 */
    public string[] UnfinishedDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "You still haven't collect all scrolls.";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersUnfinished()
    {

        string[] characters = new string[1];
        characters[0] = "Holle";

        return characters;
    }

    /*
	 * 	Dialogue for when the quest is complete
	 */
    public string[] EndDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "Very well. Let's go to the altar, and I help you with the spell";

        return dialogue;
    }

    /*
	 * Order of characters talking
	 */
    public string[] CharactersEnd()
    {

        string[] characters = new string[1];
        characters[0] = "Holle";

        return characters;
    }

    /*
    * Dialogue for after finished Quest Temple
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
        characters[0] = "Holle";

        return characters;
    }


    // ***************
    // Altar Dialogue

    /*
     * Dialogue for dialogue in altar before talking to Holle
     */
    public string[] AltarBeforeTalkingToHolle()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "What is this for, I wonder....";


        return dialogue;
    }

    /*
	 * Order of characters talking
	 */
    public string[] CharactersAltarBeforeTalkingToHolle()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

    /*
     * Dialogue for dialogue in altar before talking to Holle
     */
    public string[] AltarAllScrolls()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "I finished collecting all the scrolls. Maybe I should talk to Holle.";


        return dialogue;
    }

    /*
	 * Order of characters talking
	 */
    public string[] CharactersAltarAllScrolls()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

  /*
  * Dialogue for place rune
  */
    public string[] PlaceScrollDialogue(string name)
    {

        string[] dialogue = new string[1];
        dialogue[0] = "The scroll " + name + " is now in place.";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersPlaceScroll()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

    /*
    * Dialogue for place rune
    */
    public string[] NoScrollsToPlaceDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "I don't seem to have a scroll to place.";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersNoScrollToPlace()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

    /*
   * Dialogue for place rune
   */
    public string[] StartAltarSpell()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "Enchanting spell.....";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersAltarSpell()
    {

        string[] characters = new string[1];
        characters[0] = "Holle";

        return characters;
    }

}