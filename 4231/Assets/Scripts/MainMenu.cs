using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int characterIndex = 0;

    // public Transform playerPosition;

    #region Changing Material/Texture of Chef Variables
    // Texture Changing
    public Material[] materials;

    // Access Body
    private GameObject chefBody;
    private MeshRenderer chefBodyRenderer;

    // Access Right Hand
    private GameObject chefRight;
    private MeshRenderer chefRightRenderer;

    // Access Left Hand
    private GameObject chefLeft;
    private MeshRenderer chefLeftRenderer;

    // Access Weapon Handle
    private GameObject chefWeaponHandle;
    private MeshRenderer chefWeaponHandleRenderer;

    // Access Head
    private GameObject chefHead;
    private MeshRenderer chefHeadRenderer;

    // Access Weapon Roller
    private GameObject chefWeaponRoller;
    private MeshRenderer chefWeaponRollerRenderer;

    // Access Hat
    private GameObject chefHat;
    private MeshRenderer chefHatRenderer;
    #endregion

    void Start()
    {

        #region Access Meshes of Chef
        // Access Body
        chefBody = transform.Find("body/cuboid").gameObject;
        chefBodyRenderer = chefBody.GetComponent<MeshRenderer>();

        // Access Right Hand
        chefRight = transform.Find("hands/RHand/sphere").gameObject;
        chefRightRenderer = chefRight.GetComponent<MeshRenderer>();

        // Access Left Hand
        chefLeft = transform.Find("hands/weapon/LHand/sphere_1").gameObject;
        chefLeftRenderer = chefLeft.GetComponent<MeshRenderer>();

        // Access Weapon Handle
        chefWeaponHandle = transform.Find("hands/weapon/cuboid_4").gameObject;
        chefWeaponHandleRenderer = chefWeaponHandle.GetComponent<MeshRenderer>();

        // Access Head
        chefHead = transform.Find("head/cuboid_1").gameObject;
        chefHeadRenderer = chefHead.GetComponent<MeshRenderer>();
        #endregion

        #region Access Parts for Damage
        // Access Weapon Roller
        chefWeaponRoller = transform.Find("hands/weapon/cylinder_1").gameObject;
        chefWeaponRollerRenderer = chefWeaponRoller.GetComponent<MeshRenderer>();

        // Access Hat
        chefHat = transform.Find("head/hat/cylinder").gameObject;
        chefHatRenderer = chefHat.GetComponent<MeshRenderer>();
        #endregion

        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
        PlayerPrefs.Save();

    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        // transform.position = playerPosition.position;
    }


    public void leftButton()
    {
        characterIndex--;
        if (characterIndex < 0)
        {
            characterIndex = 3;
        }
        changeChef(characterIndex);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
        PlayerPrefs.Save();
    }

    public void RightButton()
    {
        characterIndex++;
        if (characterIndex > 3)
        {
            characterIndex = 0;
        }
        changeChef(characterIndex);
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
        PlayerPrefs.Save();
    }

    private void changeChef(int index)
    {
        chefBodyRenderer.material = materials[index]; // Change Body
        chefRightRenderer.material = materials[index]; // Change Right Hand
        chefLeftRenderer.material = materials[index]; // Change Left Hand
        chefWeaponHandleRenderer.material = materials[index]; // Change Weapon Handle
        chefHeadRenderer.material = materials[index]; // Change Head
        chefWeaponRollerRenderer.material = materials[index]; // Change Roller
        chefHatRenderer.material = materials[index]; // Change Hat
        // Debug.Log("Material changed.");
    }

}
