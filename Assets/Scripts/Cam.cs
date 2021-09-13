using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] CubeCreator cubeCreator;
    void Update(){
       if (Input.GetMouseButtonDown(0)) { // Если кликнули, проверяем существование CubeManager, после чего, создаем
           if (cubeCreator) {
                cubeCreator.CreateCube();
           }
       }
    }
}
