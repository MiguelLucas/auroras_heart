using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YggdrasilQuestDialogue {

    /*
	 * Start Dialogue for Quest Yggdrasil
	 */
    public string[] StartDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "It's seems something is missing.";

        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersStart()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

    /*
	 * Dialogue for unfinished Quest Yggdrasil
	 */
    public string[] UnfinishedDialogue()
    {

        string[] dialogue = new string[1];
        dialogue[0] = "I don't seem to have runes to place.";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersUnfinished()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

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
        characters[0] = "Leviathan";

        return characters;
    }

    /*
    * Dialogue for after finished Quest Yggdrasil
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

    /*
   * Dialogue for place rune
   */
    public string[] PlaceRuneDialogue(string name)
    {

        string[] dialogue = new string[1];
        dialogue[0] = "The rune " + name + " is now in place.";


        return dialogue;
    }
    /*
	 * Order of characters talking
	 */
    public string[] CharactersPlaceRune()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

    /*
     * Dialogue for when all runes placed, but needs moonlight
     */
    public string[] SpellNeedsMoonlightDialogue()
    {
        string[] dialogue = new string[1];
        dialogue[0] = "I must come back later. The spell needs moonlight to work.";


        return dialogue;
    }

    /*
   * Order of characters talking
   */
    public string[] CharactersSpellNeedsMoolight()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }

    /*
    * Dialogue for when all runes placed, but needs moonlight
    */
    public string[] SpellChantingDialogue()
    {
        string[] dialogue = new string[1];
        dialogue[0] = "I'm singing the spell.";


        return dialogue;
    }

    /*
   * Order of characters talking
   */
    public string[] CharactersSpellChanting()
    {

        string[] characters = new string[1];
        characters[0] = "Freya";

        return characters;
    }
}
