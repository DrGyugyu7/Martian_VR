using Unity.Cinemachine;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;
    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");
    [SerializeField] private float moveSpeed;
    private readonly int hashMovement = Animator.StringToHash("AnimationPar");
    public Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;
    private void Start()
    {
        inventory = new Inventory();
        inventoryUI.SetInventory(inventory);
    }

    // Update is called once per frame
    private void Update()
    {
        Locomotion();
    }
    private void Locomotion()
    {
        Vector3 forward = cinemachineCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();
        characterController.Move(forward * v * Time.deltaTime * moveSpeed);
        transform.rotation = Quaternion.LookRotation(forward);
        if (Input.GetKey("W")) animator.SetInteger(hashMovement, 1);
        else animator.SetInteger(hashMovement, 0);
    }
}
