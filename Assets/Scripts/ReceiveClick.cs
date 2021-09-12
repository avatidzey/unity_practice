using UnityEngine;
using UnityEngine.EventSystems;

public class ReceiveClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) { 
        if (eventData.pointerCurrentRaycast.gameObject.name == "Cube(Clone)") { // Если мы кликнули на объект с именем кубика, то ..
            ClickedOnCube(eventData);
        }
    }

    public void ClickedOnCube(PointerEventData clickedCube) { // Находим объект, ответственный за управление кубом и просим его покрутить кубик
        CubeCreator cubeCreator = FindObjectOfType<CubeCreator>();
        cubeCreator.StartCubeRotation();
    }
}
