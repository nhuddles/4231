using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

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
            // Debug.Log("Material changed to Material 1.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            chefBodyRenderer.material = materials[1]; // Change Body
            chefRightRenderer.material = materials[1]; // Change Right Hand
            chefLeftRenderer.material = materials[1]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[1]; // Change Weapon Handle
            chefHeadRenderer.material = materials[1]; // Change Head
            // Debug.Log("Material changed to Material 2.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            chefBodyRenderer.material = materials[2]; // Change Body
            chefRightRenderer.material = materials[2]; // Change Right Hand
            chefLeftRenderer.material = materials[2]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[2]; // Change Weapon Handle
            chefHeadRenderer.material = materials[2]; // Change Head
            // Debug.Log("Material changed to Material 3.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            chefBodyRenderer.material = materials[3]; // Change Body
            chefRightRenderer.material = materials[3]; // Change Right Hand
            chefLeftRenderer.material = materials[3]; // Change Left Hand
            chefWeaponHandleRenderer.material = materials[3]; // Change Weapon Handle
            chefHeadRenderer.material = materials[3]; // Change Head
            // Debug.Log("Material changed to Material 4.");
        }
        #endregion
    }

    public void ResetAttack()
    {
        animator.SetInteger("Attack", 0); // Get Chef to return to Idle
    }

}
