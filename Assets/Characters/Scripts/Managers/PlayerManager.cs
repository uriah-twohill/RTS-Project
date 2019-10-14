using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    RaycastHit hit;
    List<UnitController> selectedUnits = new List<UnitController>();
    int heroRespawns = 7, enemyRespawns = 7;
    bool isDragging = false;
    Vector3 mousePosition;
    //public Transform idleTrigger;
    GameObject selected;
    public GameObject ComebackTo;

    private void OnGUI()
    {
        if (isDragging)
        {
            var rect = ScreenHelper.GetScreenRect(mousePosition, Input.mousePosition);
            ScreenHelper.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect, 1, Color.black);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        selected = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(heroRespawns <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if(enemyRespawns <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(camRay, out hit))
            {
                Debug.Log(hit.transform);
                if (hit.transform.CompareTag("playerUnit"))
                {
                    SelectUnit(hit.transform.gameObject.GetComponent<UnitController>(), Input.GetKey(KeyCode.LeftShift));
                }
                else
                {
                    isDragging = true;
                }
                   
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                DeselectUnits();

                foreach (var selectableObject in FindObjectsOfType<PlayerUnitController>())
                {
                    if (IsWithinSelectionBounds(selectableObject.transform))
                    {
                        SelectUnit(selectableObject.gameObject.GetComponent<UnitController>(), true);
                    }
                }

                isDragging = false;
            }
        }

        if (Input.GetMouseButtonDown(1) && selectedUnits.Count > 0)
        {
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out hit))
            {
                Debug.Log(hit.transform);
                if (hit.transform.CompareTag("Ground"))
                {
                    //idleTrigger.transform.position = hit.point;
                    foreach(var selectableObj in selectedUnits)
                    {
                        selectableObj.MoveUnit(hit.point);
                    }
                }
                else if (hit.transform.CompareTag("EnemyUnit"))
                {
                    selected = hit.collider.gameObject;
                    foreach (var selectableObj in selectedUnits)
                    {
                        selectableObj.SetNewTarget(hit.transform);
                    }
                }

            }
        }
        
    }


    private void SelectUnit(UnitController unit, bool isMultiSelect = false)
    {
        if (!isMultiSelect)
        {
            DeselectUnits();
        }
        selectedUnits.Add(unit);
        unit.SetSelected(true);
    }

    private void DeselectUnits()
    {
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            //  selectedUnits[i].Find("Highlight").gameObject.SetActive(false);
            selectedUnits[i].SetSelected(false);

        }
        selectedUnits.Clear();
    }

    private bool IsWithinSelectionBounds(Transform transform)
    {
        if (!isDragging)
        {
            return false;
        }
        var camera = Camera.main;
        var viewportBounds = ScreenHelper.GetViewportBounds(camera, mousePosition, Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(transform.position));
    }

    public GameObject position()
    {
        return ComebackTo;
    }

    public void decreaseHeroRespawns() 
    {
        heroRespawns = heroRespawns - 1; 
    }

    public void decreaseEnemyRespawns()
    {
        enemyRespawns = enemyRespawns - 1;
    }
}