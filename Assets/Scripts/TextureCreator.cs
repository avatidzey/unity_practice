using UnityEngine;
using System.IO;

public class TextureCreator
{
    string dir;

    public void InitPath() {
        dir = Path.Combine(Application.streamingAssetsPath, "CubeTextures"); // Инициализируем строку, содержащую путь к папке в StreamingAssets
    }

    public Texture2D GetTexture(string neededResource) { // Функция, генерирующая текстуру на основе работы с ресурсом в StreamingAsset
        var filePath = Path.Combine(dir, neededResource); // Определяем путь к ресурсу
        byte[] bytes = null; 
        Texture2D texture = null;

        var file = new FileInfo(filePath);
        if (file.Exists) {
            bytes = File.ReadAllBytes(filePath); // Выгружаем в переменную байты ресурса
            texture = new Texture2D(512,512, TextureFormat.RGB24, false, true); // Формируем пустую текстуру
            texture.LoadImage(bytes); // Инициализируем текстуру с помощью выгруженных байтов
        }
        return texture;
    }
}
     