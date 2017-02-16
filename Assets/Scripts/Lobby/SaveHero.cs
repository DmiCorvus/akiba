using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//ОПИСАНИЕ - СОХРАНЯЕТ СОЗДАННОГО ПЕРСОНАЖА
//ПРИКРЕПЛЕНО к стартовому экрану

public class SaveHero : MonoBehaviour {

    //СЛОТ 0-3
    public bool[] saveHeroSlot = new bool[4]; //слоты сохранения - FALSE
    public static string[] saveNameHero = new string[4];//имя
    public static string[] saveGenderHero = new string[4];//пол
    public static string[] saveHairColHero = new string[4];//цвет
    public static int[] saveAVIpicHero = new int[4];//картинка
    //семья
    public static bool[] saveSister = new bool[4]; //у вас есть сестра
    public static int[] savesisPersona = new int[4]; //характер сестры
    public static bool[] saveBrother = new bool[4]; //у вас есть брат
    public static int[] savebroPersona = new int[4]; //характер брата

    private static  Save sav = new Save();

    public GameObject startingScreen;//СТАРТОВЫЙ ЭКРАН

    //Данные для рисования  
    public GameObject[] saveHeroPIC = new GameObject[4];//слот картинки
    public GameObject[] saveHeroPICframe = new GameObject[4]; //рамка
    public GameObject[] saveHeroNAMEtxt = new GameObject[4]; //имя

    static int saveNUM;
    static int drawSlotNUM;

    public static  int selectedSlot; //выбранный вами слот
    int loading = 0;

    //при включении игры
    void OnEnable()
    {
        // PlayerPrefs.DeleteKey("SAVEHERO0");
        //   PlayerPrefs.DeleteKey("SAVEHERO1");
        //  PlayerPrefs.DeleteKey("SAVEHERO2");
        //     PlayerPrefs.DeleteKey("SAVEHERO3");
        loading = 0;
        frame();


    }

    void OnGUI()
    {
        for (int i = 0; i <= 3; i++)
        {
            if (PlayerPrefs.HasKey("SAVEHERO" + i))
            {
                startingScreen.SetActive(true);
                sav = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SAVEHERO" + i));

                saveHeroSlot[i] = true;
                saveNameHero[i] = sav.mmoName;
                saveGenderHero[i] = sav.mmoGender;
                saveHairColHero[i] = sav.mmoHairColor;
                saveAVIpicHero[i] = sav.mmoHeroPICnum;

                saveSister[i] = sav.sister;
                savesisPersona[i] = sav.sisPersonality;
                saveBrother[i] = sav.brother;
                savebroPersona[i] = sav.broPersonality;

                drawSlotNUM = i;
                DrowLoadSlots();                
                loading++;
            }
        }

        if (loading == 0)
        {
            //выключить меню
            startingScreen.SetActive(false);
        }
    }
    //frame
    void frame()
    {
        //рамка при вкл
        for (int i = 0; i <= 3; i++)
        {saveHeroPICframe[i].SetActive(false);}
        for (int i = 0; i <= 3; i++)
        {
            if (PlayerPrefs.HasKey("SAVEHERO" + i))
            {
                saveHeroPICframe[i].SetActive(true);
                selectedSlot = i;
                i = 4;
            }
        }

    }


    //рисуем слоты
    void DrowLoadSlots()
    {
        //1
        if (saveHeroSlot[drawSlotNUM] == true)
        {
            saveHeroPIC[drawSlotNUM].SetActive(true);
            //имя
            saveHeroNAMEtxt[drawSlotNUM].GetComponent<Text>().text = saveNameHero[drawSlotNUM];
            //рисунок
            Image tstIMG = saveHeroPIC[drawSlotNUM].GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + saveGenderHero[drawSlotNUM] + "/" + saveHairColHero[drawSlotNUM] + "/" + saveAVIpicHero[drawSlotNUM]);
        }
    }


    //данные сохранения
    [Serializable]
    public class Save
    {
        public string mmoName; //имя
        public string mmoGender; //пол
        public string mmoHairColor; //цвет
        public int mmoHeroPICnum; //ава
        //семья
        public bool sister;
        public int sisPersonality;
        public bool brother;
        public int broPersonality;
    }




    //кнопка сохранения
    public static void SaveHeroes()
    {
        //номер слота
        for (int i = 0; i <= 3; i++)  { if (!PlayerPrefs.HasKey("SAVEHERO" + i)) { saveNUM = i; i = 4; } }

        //данные
        sav.mmoName = MMOsettings.mmoName;
        sav.mmoGender = MMOsettings.mmoGender;
        sav.mmoHairColor = MMOsettings.mmoHairColor;
        sav.mmoHeroPICnum = MMOsettings.mmoHeroPICnum;

        sav.sister = Family.sister;
        sav.sisPersonality = Family.sisPersonality;
        sav.brother = Family.brother;
        sav.broPersonality = Family.broPersonality;

        PlayerPrefs.SetString("SAVEHERO"+ saveNUM, JsonUtility.ToJson(sav));
        
        print("save complete");
    }





    //кнопка удаления0
    public void Delete0save()
    {
        PlayerPrefs.DeleteKey("SAVEHERO0");
        saveHeroSlot[0] = false;
        saveHeroPIC[0].SetActive(false);
        CHKsaveNotEmpty();
        frame();
    }
    //кнопка удаления1
    public void Delete1save()
    {
        PlayerPrefs.DeleteKey("SAVEHERO1");
        saveHeroSlot[1] = false;
        saveHeroPIC[1].SetActive(false);
        CHKsaveNotEmpty();
        frame();
    }
    //кнопка удаления2
    public void Delete2save()
    {
        PlayerPrefs.DeleteKey("SAVEHERO2");
        saveHeroSlot[2] = false;
        saveHeroPIC[2].SetActive(false);
        CHKsaveNotEmpty();
        frame();
    }
    //кнопка удаления3
    public void Delete3save()
    {
        PlayerPrefs.DeleteKey("SAVEHERO3");
        saveHeroSlot[3] = false;
        saveHeroPIC[3].SetActive(false);
        CHKsaveNotEmpty();
        frame();
    }

    //остались ли сейвы?
    void CHKsaveNotEmpty()
    {
       if ((saveHeroSlot[0] == false)&&(saveHeroSlot[1] == false) &&(saveHeroSlot[2] == false) &&(saveHeroSlot[3] == false))
        {
            //выключить меню
            startingScreen.SetActive(false);
        }
    }

    //кнопка выбора0
    public void select0save()
    {
        saveHeroPICframe[0].SetActive(true);
        saveHeroPICframe[1].SetActive(false);
        saveHeroPICframe[2].SetActive(false);
        saveHeroPICframe[3].SetActive(false);

        selectedSlot = 0;
    }

    //кнопка выбора1
    public void select1save()
    {
        saveHeroPICframe[0].SetActive(false);
        saveHeroPICframe[1].SetActive(true);
        saveHeroPICframe[2].SetActive(false);
        saveHeroPICframe[3].SetActive(false);

        selectedSlot = 1;
    }

    //кнопка выбора2
    public void select2save()
    {
        saveHeroPICframe[0].SetActive(false);
        saveHeroPICframe[1].SetActive(false);
        saveHeroPICframe[2].SetActive(true);
        saveHeroPICframe[3].SetActive(false);

        selectedSlot = 2;
    }

    //кнопка выбора3
    public void select3save()
    {
        saveHeroPICframe[0].SetActive(false);
        saveHeroPICframe[1].SetActive(false);
        saveHeroPICframe[2].SetActive(false);
        saveHeroPICframe[3].SetActive(true);

        selectedSlot = 3;
    }


}
