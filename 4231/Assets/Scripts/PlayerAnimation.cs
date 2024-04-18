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

        originalColor = chefHatRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

        #region Change Material of Chef (See Chef Variants) Press 1 to see Chef 1 ... Press 4 to see Chef 4
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chefBodyRenderer.material = materials[0]; // Change Body
            chefRightRenderer.material = materials[0]; // Change Right Hand
            chefLeftRenderer.material = materials[0]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[0]; // Change Weapon Handle
            chefHeadRenderer.material = materials[0]; // Change Head
            chefWeaponRollerRenderer.material = materials[0]; // Change Roller
            chefHatRenderer.material = materials[0]; // Change Hat
            // Debug.Log("Material changed to Material 1.");
            playerIconSlot.texture = playerIcons[0];
            weaponIconSlot.texture = weaponIcons[0];
            healthIconSlot.texture = healthIcons[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            chefBodyRenderer.material = materials[1]; // Change Body
            chefRightRenderer.material = materials[1]; // Change Right Hand
            chefLeftRenderer.material = materials[1]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[1]; // Change Weapon Handle
            chefHeadRenderer.material = materials[1]; // Change Head
            chefWeaponRollerRenderer.material = materials[1]; // Change Roller
            chefHatRenderer.material = materials[1]; // Change Hat
            // Debug.Log("Material changed to Material 2.");
            playerIconSlot.texture = playerIcons[1];
            weaponIconSlot.texture = weaponIcons[1];
            healthIconSlot.texture = healthIcons[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            chefBodyRenderer.material = materials[2]; // Change Body
            chefRightRenderer.material = materials[2]; // Change Right Hand
            chefLeftRenderer.material = materials[2]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[2]; // Change Weapon Handle
            chefHeadRenderer.material = materials[2]; // Change Head
            chefWeaponRollerRenderer.material = materials[2]; // Change Roller
            chefHatRenderer.material = materials[2]; // Change Hat
            // Debug.Log("Material changed to Material 3.");
            playerIconSlot.texture = playerIcons[2];
            weaponIconSlot.texture = weaponIcons[2];
            healthIconSlot.texture = healthIcons[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            chefBodyRenderer.material = materials[3]; // Change Body
            chefRightRenderer.material = materials[3]; // Change Right Hand
            chefLeftRenderer.material = materials[3]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[3]; // Change Weapon Handle
            chefHeadRenderer.material = materials[3]; // Change Head
            chefWeaponRollerRenderer.material = materials[3]; // Change Roller
            chefHatRenderer.material = materials[3]; // Change Hat
            // Debug.Log("Material changed to Material 4.");
            playerIconSlot.texture = playerIcons[3];
            weaponIconSlot.texture = weaponIcons[3];
            healthIconSlot.texture = healthIcons[3];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || playerController.playerState == 4)
        {
            chefBodyRenderer.material.color = Color.red; // Change Body
            chefRightRenderer.material.color = Color.red; // Change Right Hand
            chefLeftRenderer.material.color = Color.red; // Change Left Hand
            chefWeaponHandleRenderer.material.color = Color.red; // Change Weapon Handle
            chefHeadRenderer.material.color = Color.red; // Change Head
            chefWeaponRollerRenderer.material.color = Color.red; // Change Roller
            chefHatRenderer.material.color = Color.red; // Change Hat
            // Debug.Log("Material changed to Material 5.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || playerController.playerState == 5)
        {
            chefBodyRenderer.material.color = originalColor; // Change Body
            chefRightRenderer.material.color = originalColor; // Change Right Hand
            chefLeftRenderer.material.color = originalColor; // Change Left Hand
            chefWeaponHandleRenderer.material.color = originalColor; // Change Weapon Handle
            chefHeadRenderer.material.color = originalColor; // Change Head
            chefWeaponRollerRenderer.material.color = originalColor; // Change Roller
            chefHatRenderer.material.color = originalColor; // Change Hat
            // Debug.Log("Material changed to Material 5.");
        }
        #endregion
    }

    public void ResetAttack()
    {
        animator.SetInteger("Attack", 0); // Get Chef to return to Idle
    }

}
