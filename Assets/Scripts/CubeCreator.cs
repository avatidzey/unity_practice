using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public bool cubeExists = false;
    [SerializeField] Vector3 startingPosition;
    [SerializeField] Material boxMaterial;
    [SerializeField] string boxTextureName = "boxTexture_2.jpg";
    private TextureCreator texCreator = new TextureCreator();
    [SerializeField] private Cube cube;
    public void CreateCube() {
        if (!cubeExists) { // Если кубика нет, то создаем его, устанавливаем маериал и определяем его положение
            cubeExists = true;
            Instantiate(cube);
            SetBoxMaterial();
            cube.FixCubeRotation();
            cube.FixCubePosition(startingPosition);
        }
        else {
            Debug.Log("Cube already exists!");
        }
    }

    public void SetBoxMaterial(){
        texCreator.InitPath();
        if (boxMaterial) {
            boxMaterial.mainTexture = texCreator.GetTexture(boxTextureName); // Определение главной текстуры для подставляемого материала
        }
        cube.AddTexture(boxMaterial); // Вызов метода кубика для инициализации параметра материала его Mesh Renderer
        texCreator = null;
    }
}

