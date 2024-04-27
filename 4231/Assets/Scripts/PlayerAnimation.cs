using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public PlayerControllerTest playerController;
    public Color originalColor;

    public RawImage playerIconSlot;
    public Texture[] playerIcons;

    public RawImage weaponIconSlot;
    public Texture[] weaponIcons;

    public RawImage healthIconSlot;
    public Texture[] healthIcons;

    int characterIndex;

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

    // Start is called before the first frame update
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

        characterIndex = PlayerPrefs.GetInt("CharacterIndex");

        originalColor = chefHatRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        characterIndex = characterIndex;

        #region Change Material of Chef
        changeChef(characterIndex);

        if (playerController.playerState == 4)
        {
            changeColor(Color.red);
        }
        else if (playerController.playerState == 5)
        {
            changeColor(originalColor);
        }
        #endregion

        #region Character Switch Cheat Code
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                characterIndex++;
                if (characterIndex > 3)
                {
                    characterIndex = 0;
                }
            }
        }
        #endregion
    }

    public void ResetAttack()
    {
        animator.SetInteger("Attack", 0); // Get Chef to return to Idle
    }

    public void changeChef(int index)
    {
        chefBodyRenderer.material = materials[index]; // Change Body
        chefRightRenderer.material = materials[index]; // Change Right Hand
        chefLeftRenderer.material = materials[index]; // Change Left Hand
        chefWeaponHandleRenderer.material = materials[index]; // Change Weapon Handle
        chefHeadRenderer.material = materials[index]; // Change Head
        chefWeaponRollerRenderer.material = materials[index]; // Change Roller
        chefHatRenderer.material = materials[index]; // Change Hat
        // Debug.Log("Material changed.");
        playerIconSlot.texture = playerIcons[index];
        weaponIconSlot.texture = weaponIcons[index];
        healthIconSlot.texture = healthIcons[index];
    }

    public void changeColor(Color col)
    {
        chefBodyRenderer.material.color = col; // Change Body
        chefRightRenderer.material.color = col; // Change Right Hand
        chefLeftRenderer.material.color = col; // Change Left Hand
        chefWeaponHandleRenderer.material.color = col; // Change Weapon Handle
        chefHeadRenderer.material.color = col; // Change Head
        chefWeaponRollerRenderer.material.color = col; // Change Roller
        chefHatRenderer.material.color = col; // Change Hat
        // Debug.Log("Material changed to Material 5.");
    }

}