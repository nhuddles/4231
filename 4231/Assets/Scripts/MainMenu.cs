using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int characterIndex = 0;

    public Animator animator;
    public PlayerControllerTest playerController;
    public Color originalColor;

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

        originalColor = chefHatRenderer.material.color;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Update()
    {
        #region Change Material of Chef (See Chef Variants) Press 1 to see Chef 1 ... Press 4 to see Chef 4
        if (characterIndex == 0)
        {
            chefBodyRenderer.material = materials[0]; // Change Body
            chefRightRenderer.material = materials[0]; // Change Right Hand
            chefLeftRenderer.material = materials[0]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[0]; // Change Weapon Handle
            chefHeadRenderer.material = materials[0]; // Change Head
            chefWeaponRollerRenderer.material = materials[0]; // Change Roller
            chefHatRenderer.material = materials[0]; // Change Hat
            // Debug.Log("Material changed to Material 1.");
        }
        else if (characterIndex == 1)
        {
            chefBodyRenderer.material = materials[1]; // Change Body
            chefRightRenderer.material = materials[1]; // Change Right Hand
            chefLeftRenderer.material = materials[1]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[1]; // Change Weapon Handle
            chefHeadRenderer.material = materials[1]; // Change Head
            chefWeaponRollerRenderer.material = materials[1]; // Change Roller
            chefHatRenderer.material = materials[1]; // Change Hat
            // Debug.Log("Material changed to Material 2.");
            
        }
        else if (characterIndex == 2)
        {
            chefBodyRenderer.material = materials[2]; // Change Body
            chefRightRenderer.material = materials[2]; // Change Right Hand
            chefLeftRenderer.material = materials[2]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[2]; // Change Weapon Handle
            chefHeadRenderer.material = materials[2]; // Change Head
            chefWeaponRollerRenderer.material = materials[2]; // Change Roller
            chefHatRenderer.material = materials[2]; // Change Hat
            // Debug.Log("Material changed to Material 3.");
        }
        else if (characterIndex == 3)
        {
            chefBodyRenderer.material = materials[3]; // Change Body
            chefRightRenderer.material = materials[3]; // Change Right Hand
            chefLeftRenderer.material = materials[3]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[3]; // Change Weapon Handle
            chefHeadRenderer.material = materials[3]; // Change Head
            chefWeaponRollerRenderer.material = materials[3]; // Change Roller
            chefHatRenderer.material = materials[3]; // Change Hat
            // Debug.Log("Material changed to Material 4.");
        }
        #endregion
    }
    /*public void leftButton()
    {
        if (characterIndex <= 0)
        {
            characterIndex = 3;
        }
        else
        {
            characterIndex -= 1;
        }
    }
    public void RightButton()
    {
        if (characterIndex >= 3)
        {
            characterIndex = 0;
        }
        else
        {
            characterIndex += 1;
        }
    }*/
    public void leftButton()
    {
        if (materials.Length > 0)
        {
            characterIndex = (characterIndex - 1 + materials.Length) % materials.Length;
        }
    }

    public void RightButton()
    {
        if (materials.Length > 0)
        {
            characterIndex = (characterIndex + 1) % materials.Length;
        }
    }
}
