using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugrelDialogue
{
    public string[] StartGame()
    {

        string[] dialogue = new string[2];
        dialogue[0] = "Where am I? What stange place is this?";
        dialogue[1] = "Mum? Dad? ";

        return dialogue;
    }

    public string[] CharactersStart()
    {
        string[] characters = new string[2];
        characters[0] = "Freya";
        characters[1] = "Freya";

        return characters;
    }

    public string[] DetectHugrel()
    {
        string[] dialogue = new string[3];
        dialogue[0] = "A wolf? Where did he come from?";
        dialogue[1] = "I have a feeling I know him... But I can't remember from where.";
        dialogue[2] = "It seems he wants me to follow him.";

        return dialogue;
    }

    public string[] CharactersDetectHugrel()
    {
        string[] characters = new string[3];
        characters[0] = "Freya";
        characters[1] = "Freya";
        characters[2] = "Freya";

        return characters;
    }

}
