using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CameraResizer : MonoBehaviour
{
    InputAction CameraToggle;
    InputAction CameraMove;
    InputAction CameraZoom;

    InputSystem_Actions.CameraActions CameraAct;

    Camera camera;

    bool Enabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();
        CameraAct = Manager.instance.action.Camera;
        CameraToggle = CameraAct.ToggleCameraTransform;
        CameraZoom = CameraAct.Zoom;
        CameraMove = CameraAct.Move;

        CameraToggle.performed += ToggleCameraTransf;
        CameraMove.performed += MoveCamera;
        CameraZoom.performed += ZoomCamera;
        CameraToggle.Enable();
        CameraMove.Enable();
        CameraZoom.Enable();

    }


    void ToggleCameraTransf(InputAction.CallbackContext context)
    {
        Enabled = !Enabled;
        print("Enabled : " + Enabled);
    }

    void MoveCamera(InputAction.CallbackContext context)
    {
        if(Enabled == true)
        {
            transform.DOMove(transform.position + new Vector3(context.ReadValue<Vector2>().x,context.ReadValue<Vector2>().y,0), .5f);
        }
    }

    void ZoomCamera(InputAction.CallbackContext context)
    {
        if(Enabled == true)
        {
            DOVirtual.Float(camera.orthographicSize, camera.orthographicSize + context.ReadValue<float>(), .5f, v =>
            {
                camera.orthographicSize = v;
            });
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
