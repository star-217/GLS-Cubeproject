using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BuySkin1 : MonoBehaviour
{
    Button testButton;
    float shop_money;
    [SerializeField] float skin_price = 2000;
    bool use_flag = false;
    int texture_number;
    public int max_texture;
    Image image;
    bool[] buy_flag;
    int buyCount;
    
    [SerializeField]private TextMeshProUGUI textMeshPro;
    int start = 1;
    int end = 9;
    int ransu;
    [SerializeField]ParticleSystem particle;
    [SerializeField] int randomCount = 15;
    [SerializeField] float attenuation = 0.8f;


    // Start is called before the first frame update


    void Start()
    {
        
        if (!PlayerPrefs.HasKey("Use"))
            PlayerPrefs.SetInt("Use", 0);
 
            PlayerPrefs.SetInt("Random", 1000);
        if (!PlayerPrefs.HasKey("score_save"))
            PlayerPrefs.SetInt("score_save", 0);


        texture_number = PlayerPrefs.GetInt("ColorNumber"); 
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(Buy);
        image = GetComponent<Image>();
        shop_money = PlayerPrefs.GetFloat("score_save");


        buy_flag = new bool[6];
        for(int i = 0; i < buy_flag.Length; ++i)
        {
            var number = i + 9;
            if (PlayerPrefs.GetInt("BuyFlag" + number) != 1)
                buy_flag[i] = false;
            else
                buy_flag[i] = true;
        }

        //buy_flag[0] = true;
    }

    // Update is called once per frame
    private void Update()
    {
        shop_money = PlayerPrefs.GetFloat("score_save");

    }

    void Buy()
    {
        if (skin_price <= shop_money)
        {
            testButton.enabled = false;

            int notbuyCount = 0;
            for (int i = 0; i < buy_flag.Length; ++i)
            {
                if (!buy_flag[i])
                    ++notbuyCount;
            }

            if (notbuyCount == 0)
                return;

            int[] notBuy = new int[notbuyCount];
            notbuyCount = 0;
            for (int i = 0; i < buy_flag.Length; ++i)
            {
                if (!buy_flag[i])
                {
                    notBuy[notbuyCount] = i;
                    ++notbuyCount;
                }
            }
            StartCoroutine(RandomSelect(notBuy));

        }  
    }



    private IEnumerator RandomSelect(int[] notBuy)
    {
        int index = 0;
        var time = 0.7f;
        for (int i = 0; i < randomCount; i++)
        {
            index = Random.Range(0, notBuy.Length);
            PlayerPrefs.SetInt("Random" , notBuy[index] + 9);
            time *= attenuation;
            yield return new WaitForSeconds(time);
        }

        var number = notBuy[index] + 9;
        shop_money -= skin_price;
        PlayerPrefs.SetFloat("score_save", shop_money);
        PlayerPrefs.SetInt("BuyFlag" + number, 1);
        PlayerPrefs.SetInt("Use", notBuy[index] + 9);
        buy_flag[notBuy[index]] = true;
        buyCount++;
        PlayerPrefs.SetInt("BuyCount", buyCount);

        

        testButton.enabled = true;
        particle.Play();

        for (int i = 0; i < 3; i++)
        {
           
            PlayerPrefs.SetInt("Random", notBuy[index] + 9);
            yield return new WaitForSeconds(0.3f);
            PlayerPrefs.SetInt("Random", 1000);
            yield return new WaitForSeconds(0.3f);
        }
       
    }
}
