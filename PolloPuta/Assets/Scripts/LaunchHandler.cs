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
    [SerializeField] private Transform polloStartPosition;
    [SerializeField] public Transform chargePosition;
    [SerializeField] private Transform leftLineStartPosition;
    [SerializeField] private Transform rightLineStartPosition;
    [SerializeField] private Transform centerPosition;

    [Header("Line Renderers")]
    [SerializeField] private LineRenderer rightLineRenderer;
    [SerializeField] private LineRenderer leftLineRenderer;

    [Header("Scripts")]
    [SerializeField] private LaunchArea launchArea;
    private PolloHandler polloHandler;

    [Header("Puta")]
    [SerializeField] private GameObject putaPollo;

    private bool clickedInArea = false;

    private GameObject spawnedPollo;

    private Vector3 worldPosition;
    private Vector2 heading;

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

            chargePosition = polloHandler.transformPollo(Vector2.ClampMagnitude(heading, maxMagnitude), centerPosition);

            SetLines(chargePosition.position);

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
        spawnedPollo = Instantiate(putaPollo, polloStartPosition.position, Quaternion.identity);

        SetLines(polloStartPosition.position);

        polloHandler = spawnedPollo.GetComponent<PolloHandler>();
    }

    #region Slingshot Methods

    private void SetLines(Vector2 position)
    {
        leftLineRenderer.SetPosition(0, position);
        leftLineRenderer.SetPosition(1, leftLineStartPosition.position);

        rightLineRenderer.SetPosition(0, position);
        rightLineRenderer.SetPosition(1, rightLineStartPosition.position);
    }

    #endregion
}
