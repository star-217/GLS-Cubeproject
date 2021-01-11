using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BuySkin : MonoBehaviour
{
    private Button testButton;
    private float shop_money;
    [SerializeField] float skin_price = 1000;
    private bool use_flag = false;
    private int texture_number;
    private bool[] buy_flag;
    private int buyCount;
    public int max_texture;
    private Image image;

    [SerializeField]private TextMeshProUGUI textMeshPro;
    private int start = 1;
    private int end = 9;
    private int ransu;
    [SerializeField]ParticleSystem particle;
    [SerializeField] int randomCount = 20;
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


        buy_flag = new bool[9];
        for(int i = 0; i < buy_flag.Length; ++i)
        {
            if(PlayerPrefs.GetInt("BuyFlag" + i) != 1)
                buy_flag[i] = false;
            else
                buy_flag[i] = true;
        }

        buy_flag[0] = true;
        
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
        var time = 0.5f;
        for (int i = 0; i < randomCount; i++)
        {
            index = Random.Range(0, notBuy.Length);
            PlayerPrefs.SetInt("Random" , notBuy[index]);
            time *= attenuation;
            yield return new WaitForSeconds(time);
        }

        shop_money -= skin_price;
        PlayerPrefs.SetFloat("score_save", shop_money);
        PlayerPrefs.SetInt("BuyFlag" + notBuy[index], 1);
        PlayerPrefs.SetInt("Use", notBuy[index]);
        buy_flag[notBuy[index]] = true;
        buyCount++;
        PlayerPrefs.SetInt("BuyCount", buyCount);
        
        testButton.enabled = true;
        particle.Play();

        for (int i = 0; i < 3; i++)
        {
           
            PlayerPrefs.SetInt("Random", notBuy[index]);
            yield return new WaitForSeconds(0.3f);
            PlayerPrefs.SetInt("Random", 1000);
            yield return new WaitForSeconds(0.3f);
        }
       
    }
}
