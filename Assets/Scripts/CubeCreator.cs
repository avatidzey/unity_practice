using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public bool cubeExists = false;
    private Vector2 minCamBound, maxCamBound;
    [SerializeField] Vector2 startingPosition;
    [SerializeField] Material cubeMaterial;
    [SerializeField] string cubeTextureName = "cubeTexture_2.jpg";
    private TextureCreator texCreator = new TextureCreator();
    [SerializeField] private Cube cube;
    public void CreateCube() {
        if (!cubeExists) { // Если кубика нет, то создаем его, устанавливаем материал и определяем его положение
            cubeExists = true;
            Instantiate(cube);
            cube = FindObjectOfType<Cube>(); 
            SetCubePosition();
            SetCubeMaterial();
        }
        else {
            Debug.Log("Cube already exists!");
        }
    }

    public void SetCubeMaterial(){
        texCreator.InitPath();
        if (cubeMaterial) {
            cubeMaterial.mainTexture = texCreator.GetTexture(cubeTextureName); // Определение главной текстуры для подставляемого материала
        }
        cube.AddTexture(cubeMaterial); // Вызов метода кубика для инициализации параметра материала его Mesh Renderer
        texCreator = null;
    }

    public void SetCubePosition() {
        minCamBound = Camera.main.ViewportToScreenPoint (new Vector2 (0, 0)); // Инициализация векторов границ камеры в экранной величине
        maxCamBound = Camera.main.ViewportToScreenPoint (new Vector2 (1, 1));

        startingPosition.x = Mathf.Clamp(startingPosition.x, minCamBound.x, maxCamBound.x); // Инициализация координат положения объекта относительно величин камеры
        startingPosition.y = Mathf.Clamp(startingPosition.y, minCamBound.y, maxCamBound.y);

        cube.FixCubePosition(startingPosition);
    }

    public void StartCubeRotation() { // Руководство вращением камеры
        if (cube.imRotating) {
            cube.imRotating = false;
        }
            else { 
                cube.imRotating = true; 
            }
    }
}

