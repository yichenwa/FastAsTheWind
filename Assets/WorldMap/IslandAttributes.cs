using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IslandAttributes : MonoBehaviour
{

    public string islandName;
    public int islandID;
    public bool hasBlacksmith;
    public bool hasGunsmith;
    public bool hasTavern;
    public bool hasWardsmith;
    public bool hasArchetier;

    public bool hasSpecial;
    public IslandSpecialAttributes specialAttributes; //If no special attributes, give the island the base class

    private GameObject activePanel;

    private bool isDiscovered;

    public void SetAttributes(string name, bool blackS, bool gunS, bool tav, bool wardS, bool arch, bool special)
    {
        islandName = name; hasBlacksmith = blackS; hasGunsmith = gunS; hasTavern = tav;
        hasWardsmith = wardS; hasArchetier = arch; hasSpecial = special;
    }

    public void SetDiscovered()
    {
        isDiscovered = true;
    }

    public bool GetDiscovered()
    {
        return isDiscovered;
    }

    public string GetName()
    {
        return islandName;
    }

    public void SetActivePanel(GameObject panel)
    {
        activePanel = panel;
    }

    public GameObject GetActivePanel()
    {
        return activePanel;
    }

    // Use this for initialization
    void Start ()
    {
        isDiscovered = false;
        transform.position = IslandStats.IslandLocations[islandID];
    }

    public virtual void MarketOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        caller.goldCountText.text = "Gold: " + PlayerStatus.GoldCount;
        caller.relevantStatText.text = "Resources: " + PlayerStatus.ResourcesCount.ToString();
        caller.interactionsText.text = "Whatcha buyin', stranger?";

        activePanel = caller.linkedPanel;
    }

    public virtual void BlacksmithOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        caller.goldCountText.text = "Gold: " + PlayerStatus.GoldCount;
        caller.interactionsText.text = "Need yourself some steel? You've come to the right place.";

        activePanel = caller.linkedPanel;
    }

    public virtual void GunsmithOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        caller.goldCountText.text = "Gold: " + PlayerStatus.GoldCount;
        caller.relevantStatText.text = "Cannonballs: " + PlayerStatus.AmmoCount.ToString();
        caller.interactionsText.text = "Looking to defend yourself, huh? I got just the thing.";

        activePanel = caller.linkedPanel;
    }

    public virtual void WardsmithOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        caller.goldCountText.text = "Gold: " + PlayerStatus.GoldCount;
        caller.interactionsText.text = "Ahhhh. Welcome, good sir. You've come to the right store; the other wardsmiths on this island " +
            "are contemptible amateurs.";

        activePanel = caller.linkedPanel;
    }

    public virtual void ArchetierOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        caller.goldCountText.text = "Gold: " + PlayerStatus.GoldCount;
        caller.interactionsText.text = "It may not be as flashy, but a bow in the right hands is worth a dozen muskets. " +
            "Anything I can get for you?";

        activePanel = caller.linkedPanel;
    }

    public virtual void TavernOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        caller.interactionsText.text = "*The tavern is filled with rowdy drunks, singing along with a bard who looks like he'd" +
            "rather be elsewhere. The bartender greets you warmly, offering food and drinks (for an outrageous price, of course).*";

        activePanel = caller.linkedPanel;
    }

    public virtual void ShipswrightOnClick(MainPanelButton caller)
    {
        caller.mainPanel.SetActive(false);
        caller.linkedPanel.SetActive(true);

        if (PlayerStatus.ShipHealthCurrent == PlayerStatus.ShipHealthMax)
            caller.interactionsText.text = "Looking to upgrade your ship, eh?";
        else caller.interactionsText.text = "Yer ship's lookin' a little rough there. " +
                "Want me to patch 'er up fer ya?";

        caller.goldCountText.text = "Gold: " + PlayerStatus.GoldCount;
        caller.relevantStatText.text = "Ship Health: " + PlayerStatus.ShipHealthCurrent + "/" + PlayerStatus.ShipHealthMax;

        activePanel = caller.linkedPanel;
    }

    public virtual void SpecialOnClick(MainPanelButton caller) //Generic islands have no special button
    {
        return;
    }

    public virtual void SetSailOnClick(MainPanelButton caller)
    {
        SceneManager.LoadScene(SceneIndexes.WorldMap());
    }

}

