using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ServerParse : MonoBehaviour
{
    private string url = "https://www.banki.ru/products/currencyNodejsApi/getTrackingUrlList/"; // Замените на ваш URL

    public class products
    {
        public int productId { get; set; }
        public string category { get; set; }
    }


    public void Action()
    {
        // Запускаем корутин, который будет делать запрос
        StartCoroutine(GetJsonData());
    }

    IEnumerator GetJsonData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Отправляем запрос
            yield return webRequest.SendWebRequest();

            // Проверяем наличие ошибок
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Ошибка: " + webRequest.error);
            }
            else
            {
                // Получаем данные
                string jsonResult = webRequest.downloadHandler.text;
                Debug.Log("Полученные данные: " + jsonResult);

                // Здесь вы можете обработать JSON данные
                ProcessJsonData(jsonResult);
            }
        }
    }

    void ProcessJsonData(string json)
    {
        var a = 0;  
        Root cur = JsonConvert.DeserializeObject<Root>(json);
        int j = cur.products.Count;
        while (a < j-1)
        {
            a++;
            Debug.Log(cur.products[a].category + " Category " + a );
            Debug.Log(cur.products[a].productId + "prodId " + a);
            cur.products[a].productId = 1312;
            cur.products[a].category = "da";
            Debug.Log(cur.products[a].category + " Category " + a + " после изм");
            Debug.Log(cur.products[a].productId + "prodId " + a + " после изм");

        }
        
        json = JsonConvert.SerializeObject(cur);

    }

        // Здесь добавьте код для обработки первых полученных данных
        // Например, десериализация JSON в объект
}
