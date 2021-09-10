using UnityEngine;
using UnityEngine.EventSystems;

public class ReceiveClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) { 
        if (eventData.pointerCurrentRaycast.gameObject.name == "Cube(Clone)") { // Если мы кликнули на объект с именем кубика, то ..
            ClickedOnCube(eventData);
        }
    }

    public void ClickedOnCube(PointerEventData clickedCube) { // Находим куб и крутим его, если он уже крутится, то останавливаем
        Cube cube = FindObjectOfType<Cube>();
        if (cube.rotating) {
            cube.rotating = false;
            cube.FixCubeRotation();
            
        }
        else { //  В случае если кубик не крутится, то крутим
            cube.rotating = true;
            cube.RotateCube();
        }
    }
}
