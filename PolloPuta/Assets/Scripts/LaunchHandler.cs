using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchHandler : MonoBehaviour
{
    [Header("Launch settings")]
    [SerializeField] private float launchForce;
    [SerializeField] private float maxMagnitude;

    [Header("Transform references")]
    [SerializeField] private Transform startPosition;
    [SerializeField] public Transform chargePosition;

    [Header("Scripts")]
    [SerializeField] private LaunchArea launchArea;
    private PolloHandler polloHandler;

    [Header("Puta")]
    [SerializeField] private GameObject putaPollo;

    private bool clickedInArea = false;

    private GameObject spawnedPollo;

    Vector3 worldPosition;
    Vector2 heading;

    public void Awake()
    {
        SpawnPollo();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && launchArea.IsWithinArea())
        {
            clickedInArea = true;
        }

        if (Mouse.current.leftButton.isPressed && clickedInArea)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            chargePosition = polloHandler.transformPollo(Vector2.ClampMagnitude(heading, maxMagnitude));

            heading = polloHandler.updatePosition(worldPosition);

            //Debug.Log(heading);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && clickedInArea)
        {
            polloHandler.polloReleased();

            polloHandler.Launch(Vector2.ClampMagnitude(heading, maxMagnitude), launchForce);

            clickedInArea = false;

            //Debug.Log(Vector2.ClampMagnitude(heading, maxMagnitude).magnitude);
        }
    }

    private void SpawnPollo()
    {
        spawnedPollo = Instantiate(putaPollo, startPosition.position, Quaternion.identity);

        polloHandler = spawnedPollo.GetComponent<PolloHandler>();
    }

}
