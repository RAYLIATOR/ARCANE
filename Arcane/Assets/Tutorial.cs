using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour 
{
	public GameObject tutorialPanel;
	public Text tutorialText;
	int tutorialLevel;
	int levels;
	void Start () 
	{
		Time.timeScale = 0f;
		tutorialLevel = 0;	
		levels = 8;
	}
	void Update () 
	{
		TutorialText ();
	}
	void TutorialText()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			tutorialLevel += 1;
		}
		switch(tutorialLevel)
		{
		case 0:tutorialText.text = "You are Noah, a wizard and apprentice of Maximus, the greatest wizard of all time. For years he had trained you in the art of magic, hoping that one day you will be powerful enough to visit the frost land, fight your way through vicious enemies, and capture the Arcane staff.";
			break;
		case 1:tutorialText.text = "The staff is incredibly powerful and grants its holder control over the very essence of magic. Maximus says he cannot capture it himself as he is now old, and may not have the strength to fight and survive.";
			break;
		case 2:tutorialText.text = "Maximus expects you to give him the staff and he has promised to use it wisely, to maintain order and bring peace to the realm. Your training is complete, and you are now ready to face the frost land and the dangers it holds.";
			break;
		case 3:tutorialText.text = "As you prepare to embark on this epic quest, you have a vision. You see flames everywhere, and hear cries of pain and suffering. You look around and see a realm burning with chaos, corrupted beyond restoration.";
			break;
		case 4:tutorialText.text = "You see a mighty fortress, towering over the ruins, and it its centre, you see Maximus. A dark, corrupted, and evil Maximus. In his quest for order, he began a reign of terror, and instead of peace he brought death upon the realm.";
			break;
		case 5:tutorialText.text = "Such power, Unstoppable, Terrifying. Maximus, overwhelmed by the power of the staff, uses magic to control the minds of men, causing them to slay each other, until there is nothing left. No, This isn't right. This is not how it is supposed to end.";
			break;
		case 6:tutorialText.text = "An object so powerful, does not belong in the hands of one man. This cannot be allowed to happen. The staff... its stronger than the mind of one man. There is no other choice. The Arcane..staff...must....be.....destroyed.";
			break;
		case 7:tutorialText.text = "Use W, A, S and D to move. Use the left mouse button to shoot. Use the left shift key to sprint. Find the Arcane staff and destroy it.";
			break;
		}
		if (tutorialLevel == levels) 
		{
			tutorialPanel.SetActive (false);
			Time.timeScale = 1f;
		}
	}
}
