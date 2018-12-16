using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lis2_save_editor
{

    public class FactAsset
    {
        public Dictionary<Guid, string> BoolFacts { get; set; }
        public Dictionary<Guid, string> IntFacts { get; set; }
        public Dictionary<Guid, string> FloatFacts { get; set; }
        public Dictionary<Guid, string> EnumFacts { get; set; }

        public static FactAsset Empty
        {
            get
            {
                return new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>(),
                    IntFacts = new Dictionary<Guid, string>(),
                    FloatFacts = new Dictionary<Guid, string>(),
                    EnumFacts = new Dictionary<Guid, string>()
                };
            }
        }
    }

    public class OutfitObject
    {
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public string Slot { get; set; }
        public string Owner { get; set; }
        
    }

    public class LevelObject
    {
        public string Name { get; set; }
        public List<InteractionActor> Interactions { get; set; } 
        public string[] PointsOfInterest { get; set; }
        public string[] WuiVolumes { get; set; }

        public static LevelObject Empty
        {
            get
            {
                return new LevelObject
                {
                    Name = "None",
                    Interactions = new List<InteractionActor>(),
                    PointsOfInterest = new string[0],
                    WuiVolumes = new string[0]
                };
            }
        }
    }

    public class InteractionActor
    {
        public string Name { get; set; }
        public Dictionary<Guid, string> ClassicInteractions { get; set; }
        public Dictionary<Guid, string> DanielInteractions { get; set; }
    }

    public static class GameInfo
    {
        public static string[] LIS2_CheckpointNames = new string[]
        {
            "None",
            "StartSubContext_SIH",
            "StartSubContext_EndOfEpisode",
            //Episode 1
            "E1_1A_CP01_Insertion",
            "E1_1A_CP02_HouseEnter",
            "E1_1A_CP03_AfterChocobar",
            "E1_1A_CP04_FoodDone",
            "E1_1A_CP05_DrinkDone",
            "E1_1A_CP06_BlanketDone",
            "E1_1A_CP07_DadDialDone",
            "E1_1A_CP08_BagPacked",
            "E1_1A_CP09_CallLyla",
            "E1_1A_CP10_StartBrettFight",
            "E1_2A_CP00_PreInsertion",
            "E1_2A_CP01_Insertion",
            "E1_2A_CP02_ClearingArea",
            "E1_2A_CP03_SecondaryPath",
            "E1_2A_CP04_DiscoverShelter",
            "E1_2A_CP05_Ignite",
            "E1_2A_CP06_GoToSleep",
            "E1_5A_CP01a_Insertion",
            "E1_5A_CP01b_ReachGS",
            "E1_5A_CP02_LeaveWithMap",
            "E1_5A_CP03_PicNicHankChoice",
            "E1_5A_CP04_NightWakeUp",
            "E1_5A_CP05_NightHankChoice1",
            "E1_5A_CP06_NightHankChoice2",
            "E1_5A_CP07_EnterShop",
            "E1_5A_CP08_ExitShop",
            "E1_6A_CP01_Insertion",
            "E1_6B_CP01_Insertion",
            "E1_7A_CP01_Insertion",
            "E1_7A_CP02_MotelCorridor",
            "E1_7A_CP03_InsideRoom",
            "E1_7A_CP04_DanielWashing",
            "E1_7A_CP05_StaggingChoice",
            "E1_7A_CP06_TakeSoda",
            "E1_7A_CP07_SeanHallway",
            "E1_7A_CP08_PersonalizeBag",
            "E1_9A_CP01_Insertion",
        };

        public static string[] CS_CheckpointNames = new string[]
        {
            "None",
            "PT_CP00_TestSave",
            "PT_CP01_Insertion",
            "PT_CP02_DrawingFinished",
            "PT_CP03_BreakfastFinished",
            "PT_CP04_LeaveHouse",
            "PT_CP05_EnterHouse",
            "PT_CP06_DadWakeUp",
            "PT_CP10_HelmetEquiped",
            "PT_CP11_MaskEquiped",
            "PT_CP12_LightArmorEquiped",
            "PT_CP13_HeavyArmorEquiped",
            "PT_CP14_WaterEaterDefeated",
            "PT_CP15_GolemCemeteryComplete",
            "PT_CP16_CostumePainted",
            "PT_CP17_MantroidPlanetVisited",
            "PT_CP18_SnowmanBlownUp",
            "PT_CP19_PlayedSnowball",
            "PT_CP20_CaptainSpiritQuestComplete",
            "PT_CP21_PlayedHotDogManGame",
            "PT_CP22_CloakEquiped",
            "PT_CP23_TrexChecked",
            "PT_CP24_VikingChecked",
            "PT_CP25_ActionFigureChecked",
            "PT_CP26_SharkChecked",
            "PT_CP27_SkyPirateChecked",
            "PT_CP28_SnowmancerChecked",
            "PT_CP29_FirecrackerCollected",
            "PT_CP30_GarageKeyCollected",
            "PT_CP31_MapCollected",
            "PT_CP32_CarkeyFloorCollected",
            "PT_CP33_CarkeyBowlCollected",
            "PT_CP34_CarkeyBowlDeposited",
            "PT_CP35_TrousersCollected",
            "PT_CP36_CigaretteCollected",
            "PT_CP37_MapDeposited",
            "PT_CP38_CigaretteConsumed",
            "PT_CP39_TrousersDeposited",
            "PT_CP40_EnterGarage1stTime",
            "PT_CP41_EnterGarage",
            "PT_CP42_ExitGarage",
            "PT_CP43_EnterTreeHouse",
            "PT_CP44_ExitTreeHouse",
            "PT_CP45_EnteringGolemCemetery",
            "PT_CP46_EnteringWaterEater",
            "PT_CP47_BeforeMantroidPlanet",
            "PT_CP48_WardrobeKeyCollected",
            "PT_CP49_WardrobeKeyUsed",
        };

        public static string[] LIS2_EpisodeNames = new string[]
        {
            "Roads",
            "Episode 02",
            "Episode 03",
            "Episode 04",
            "Episode 05",
        };

        public static string[] CS_InventoryItems = new string[]
        {
            "PT_CharlesRoom_Cigarette",
            "PT_CharlesRoom_Trousers",
            "PT_CharlesRoom_WardrobeKey",
            "PT_Garage_Firecrackers",
            "PT_InventoryData",
            "PT_Kitchen_GarageKey",
            "PT_LivingRoom_CarKeys",
            "PT_LivingRoom_Crumbs",
            "PT_TransparentMap"
        };

        public static string[] LIS2_InventoryItems = new string[]
        {
            //Epsiode 1
            "E1_1A_Beers",
            "E1_1A_Blanket",
            "E1_1A_BullyFlyer",
            "E1_1A_Chips",
            "E1_1A_condoms",
            "E1_1A_Cookies",
            "E1_1A_DadPicture",
            "E1_1A_FantasyBook02",
            "E1_1A_Headphones",
            "E1_1A_HomeKeys",
            "E1_1A_Idcard",
            "E1_1A_JennNote",
            "E1_1A_Lighter",
            "E1_1A_MCQTest",
            "E1_1A_PencilCase",
            "E1_1A_PhoneCharger",
            "E1_1A_RightTool",
            "E1_1A_SkateTool",
            "E1_1A_Soda",
            "E1_1A_Textbook",
            "E1_1A_USBkey",
            "E1_1A_Wallet",
            "E1_1A_WaterBottle",
            "E1_1A_WeedPipe",
            "E1_1A_WrongTool_01",
            "E1_1A_WrongTool_02",
            "E1_1A_WrongTool_03",
            "E1_1A_WrongTool_04",
            "E1_1A_WrongTool_05",
            "E1_2A_ChocolateBar",
            "E1_2A_Log01",
            "E1_2A_Log02",
            "E1_2A_Log03",
            "E1_2A_NewspaperArticle",
            "E1_2A_PhoneCharger",
            "E1_2A_Receipt",
            "E1_5A_Cans",
            "E1_5A_Chips",
            "E1_5A_ChocoCrisp",
            "E1_5A_EmptyBottle",
            "E1_5A_FilledWaterBottle",
            "E1_5A_HalfEatenApple",
            "E1_5A_Leaves",
            "E1_5A_Map",
            "E1_5A_Pebble",
            "E1_5A_PineCones",
            "E1_5A_PowerBear",
            "E1_5A_Sandwich",
            "E1_5A_SleepingBag",
            "E1_5A_SlicedBread",
            "E1_5A_Soda",
            "E1_5A_Sweat",
            "E1_5A_Tent",
            "E1_5A_Tool1",
            "E1_5A_Tool2",
            "E1_5A_TShirt",
            "E1_5A_WaterBottle",
            "E1_7A_BrodyLetter",
            "E1_7A_BrodySouvenir",
            "E1_7A_MotelKey",
            "E1_7A_StolenToy",
            "E1_7A_Towels",
            "E1_8A_BusTickets",
            "E1_8A_Toiletries",
        };

        public static string[] LIS2_SeenNotifsNames = new string[]
        {
            "PROM_MetaInventoryNotification_Collectible",
            "PROM_MetaInventoryNotification_Inventory",
            "PROM_MetaInventoryNotification_Journal",
            "PROM_MetaInventoryNotification_Map",
            "PROM_MetaInventoryNotification_Phone",
            "PROM_MetaInventoryNotification_PhoneNotif",
            "PROM_MetaInventoryNotification_PhoneWithInfo",
            "PROM_MetaInventoryNotification_NewItemAddedTo",
            "PROM_MetaInventoryNotification_NewEntryInJournal",
            "PROM_MetaInventoryNotification_MailNewMessageReceived",
            "PROM_MetaInventoryNotification_MailNewMessageReceived_2",
            "PROM_MetaInventoryNotification_NewSouvenirCollected",
            "PROM_MetaInventoryNotification_NewEntryInMap",
            "PROM_MetaInventoryNotification_NewObjectiveAddedTo",
        };

        public static string[] CS_SeenTutosNames = new string[]
        {
            "PT_GameTutorial_CaptainSpiritLogoTutorial",
            "PT_GameTutorial_ClickOnRecentercameraTo",
            "PT_GameTutorial_ExitSystemTutorial",
            "PT_GameTutorial_HoldJogToRun",
            "PT_GameTutorial_HoldPoweractivationToSee",
            "PT_GameTutorial_HoldTuto",
            "PT_GameTutorial_InteractionTutorial",
            "PT_GameTutorial_InteractionTutorialPS4",
            "PT_GameTutorial_InventoyTutorial",
            "PT_GameTutorial_LabyrinthTuto",
            "PT_GameTutorial_MashTuto",
            "PT_GameTutorial_MoveCameraTutorial",
            "PT_GameTutorial_MoveCharacterTutorial",
            "PT_GameTutorial_MoveChrisWithMovecharacter",
            "PT_GameTutorial_MoveForwardWithMoveforward",
            "PT_GameTutorial_MoveTheCameraWith",
            "PT_GameTutorial_NewChoiceTuto",
            "PT_GameTutorial_ObjectInteractionTuto",
            "PT_GameTutorial_ObjectInteractionTutoPS4",
            "PT_GameTutorial_ObservationTuto",
            "PT_GameTutorial_OpenAndCloseYour",
            "PT_GameTutorial_PhHoldWithMashbutton",
            "PT_GameTutorial_PhMashWithMashbutton",
            "PT_GameTutorial_PhPressExitsystembuttonTo",
            "PT_GameTutorial_PhSwitchWithPoweractivation",
            "PT_GameTutorial_PhToInteractWith",
            "PT_GameTutorial_PhToInteractWith_2",
            "PT_GameTutorial_PhToSpeakWhile_2",
            "PT_GameTutorial_PhUseSelectionlistmoveyTo",
            "PT_GameTutorial_PhUseSelectionlistmoveyTo_2",
            "PT_GameTutorial_PhUseTheButtons_2",
            "PT_GameTutorial_PhWhileInA",
            "PT_GameTutorial_PhWhileInA_2",
            "PT_GameTutorial_PowerTutorial",
            "PT_GameTutorial_PressExitbuttonToExit",
            "PT_GameTutorial_PressOpendiaryMyAwesome",
            "PT_GameTutorial_PressSwitchcontrolbuttonToToggle",
            "PT_GameTutorial_RecenterCamTutorial",
            "PT_GameTutorial_RunTutorial",
            "PT_GameTutorial_ShowPictureTuto",
            "PT_GameTutorial_SkipTuto",
            "PT_GameTutorial_SnowBallTutorial",
            "PT_GameTutorial_SnowballUseLookupTo",
            "PT_GameTutorial_StagingChoiceSelection",
            "PT_GameTutorial_StagingChoiceSelectionPS4",
            "PT_GameTutorial_StagingChoiceTuto",
            "PT_GameTutorial_StagingChoiceValidation",
            "PT_GameTutorial_StagingChoiceValidationPS4",
            "PT_GameTutorial_StaticDialogTuto",
            "PT_GameTutorial_StaticDialogTutoPS4",
            "PT_GameTutorial_SwitchCamShoulderTutorial",
            "PT_GameTutorial_SwitchViewTuto",
            "PT_GameTutorial_ThisLogoCaptainspiritlogoAppears",
            "PT_GameTutorial_ToggleDialTuto",
            "PT_GameTutorial_ToggleDynamicDialTutorial",
            "PT_GameTutorial_ToggleInventoryTuto",
            "PT_GameTutorial_UseChangecamerashoulderToSwitch",
            "PT_GameTutorial_UseLookupToAim",
        };

        public static string[] LIS2_SeenTutosNames = new string[]
        {
            "PROM_GameTutorial_CallDanielTuto",
            "PROM_GameTutorial_ClassicDanielInteractionTuto",
            "PROM_GameTutorial_Daniel",
            "PROM_GameTutorial_DanielInteractionTutorial",
            "PROM_GameTutorial_DrawSequence",
            "PROM_GameTutorial_DrawTuto",
            "PROM_GameTutorial_DrawTuto_Hold",
            "PROM_GameTutorial_DynDialogTuto",
            "PROM_GameTutorial_DynDialogTutoPS4",
            "PROM_GameTutorial_ExitSystemTutorial",
            "PROM_GameTutorial_GrabMachineTuto",
            "PROM_GameTutorial_HideAndSeekCall",
            "PROM_GameTutorial_HoldTuto",
            "PROM_GameTutorial_InteractionTutorial",
            "PROM_GameTutorial_InteractionTutorialPS4",
            "PROM_GameTutorial_InventoryTutorial",
            "PROM_GameTutorial_JournalTutorial",
            "PROM_GameTutorial_LabyrinthTuto",
            "PROM_GameTutorial_LittleWolfTutorial",
            "PROM_GameTutorial_LookAtDanielTuto",
            "PROM_GameTutorial_MoneyVerifTuto",
            "PROM_GameTutorial_MoveCameraTutorial",
            "PROM_GameTutorial_MoveCharacterTutorial",
            "PROM_GameTutorial_NewChoiceTuto",
            "PROM_GameTutorial_ObjectInteractionTuto",
            "PROM_GameTutorial_ObjectInteractionTutoPS4",
            "PROM_GameTutorial_ObservationTuto",
            "PROM_GameTutorial_PhPressExitbuttonTo",
            "PROM_GameTutorial_PowerTutorial",
            "PROM_GameTutorial_RecenterCamTutorial",
            "PROM_GameTutorial_RegionMapTuto",
            "PROM_GameTutorial_RunTutorial",
            "PROM_GameTutorial_ShowPictureTuto",
            "PROM_GameTutorial_SkipTuto",
            "PROM_GameTutorial_StagingChoiceSelection",
            "PROM_GameTutorial_StagingChoiceSelectionPS4",
            "PROM_GameTutorial_StagingChoiceTuto",
            "PROM_GameTutorial_StagingChoiceValidation",
            "PROM_GameTutorial_StagingChoiceValidationPS4",
            "PROM_GameTutorial_StaticDialogTuto",
            "PROM_GameTutorial_StaticDialogTutoPS4",
            "PROM_GameTutorial_SwitchCamShoulderTutorial",
            "PROM_GameTutorial_SwitchViewTuto",
            "PROM_GameTutorial_ToggleDialTuto",
            "PROM_GameTutorial_ToggleDynamicDialTutorial",
            "PROM_GameTutorial_ToggleInventoryTuto",
            "PROM_GameTutorial_WoodenStickTutorial",
        };

        public static Dictionary<string, string> LIS2_SubContextNames = new Dictionary<string, string>
        {
            {"NONE", "(none)" }, //special case for empty value
            {"E1_Menu_Subcontext_E1_1A", "1452 Lame Avenue, Seattle"},
            {"E1_Menu_Subcontext_E1_2A", "Into The Woods"},
            {"E1_Menu_Subcontext_E1_5A", "Bear Station"},
            {"E1_Menu_Subcontext_E1_6A", "US-101"},
            {"E1_Menu_Subcontext_E1_6B", "Jewel of the Pacific Coast [Sacrifice Chloe]"},
            {"E1_Menu_Subcontext_E1_6C", "Jewel of the Pacific Coast [Sacrifice AB]"},
            {"E1_Menu_Subcontext_E1_7A", "Sand Castle"},
            {"E1_Menu_Subcontext_E1_8A", "#Roomwithaview"},
            {"E1_Menu_Subcontext_E1_9A", "Long Road Ahead"},
        };

        public static Dictionary<Guid, string> CS_SeenPicturesNames = new Dictionary<Guid, string>()
        {
            {new Guid("12d8fbba-3ad4-4859-8212-f0123fff2ee5"), "SP_PT_CharlesRoom_AlcoholPamphlet"},
            {new Guid("73D42BA9-1BD8-46C9-824B-2D66635DB556"), "SP_PT_CharlesRoom_BoobMag_01"},
            {new Guid("d6252ef7-9dc1-417f-9b46-9e3fe5f32663"), "SP_PT_CharlesRoom_ChrisDrawing"},
            {new Guid("19b5b278-23b1-4e93-b29c-f7c8dc713e5e"), "SP_PT_CharlesRoom_FanLetter"},
            {new Guid("c9206ae1-59c4-4888-8e37-07a245511d58"), "SP_PT_CharlesRoom_FiredLetter"},
            {new Guid("8eae1348-fcd0-40bb-90ec-c27322c96801"), "SP_PT_CharlesRoom_InvestigatorLetter"},
            {new Guid("ed754073-6563-48a1-93b4-2e22960afc93"), "SP_PT_CharlesRoom_LoveLetter"},
            {new Guid("15ad9af1-4133-4f87-910e-3fa18bab6126"), "SP_PT_CharlesRoom_Mortgage"},
            {new Guid("5ed13bcd-c9fe-4ed7-8b07-26418db77a8b"), "SP_PT_CharlesRoom_PoliceLetter"},
            {new Guid("afdcf192-99e6-487a-bcf4-17d56143db99"), "SP_PT_CharlesRoom_SurveillanceFootage"},
            {new Guid("91366e15-358d-4131-8f08-cebfa10d9473"), "SP_PT_ChrisRoom_BirthdaySouvenir_01"},
            {new Guid("5c7e3615-cdf6-4da2-bde0-cac8e28d8eb6"), "SP_PT_ChrisRoom_ComicBooks_01"},
            {new Guid("ccc20e7a-37d0-49ab-94e3-1323e4802f61"), "SP_PT_ChrisRoom_ComicBooks_02"},
            {new Guid("7e072617-f8a7-4ecc-bcc7-d8930a59be78"), "SP_PT_ChrisRoom_ComicBooks_03"},
            {new Guid("0FD46EB1-19F6-4ECB-BCE0-4D929E9F096C"), "SP_PT_ChrisRoom_ComicFlyer_01"},
            {new Guid("fafe0b36-5111-4347-8455-f63cf9ec9cc1"), "SP_PT_ChrisRoom_DrawingManual01"},
            {new Guid("b97292e9-be08-4a10-84f8-0bd8c9d79032"), "SP_PT_ChrisRoom_DrawingManual02"},
            {new Guid("4B73B8EA-788E-4A67-8C8F-40A76303CE59"), "SP_PT_ChrisRoom_Drawing_01"},
            {new Guid("713A0072-D9B7-4251-97EA-13FE1B8E46DB"), "SP_PT_ChrisRoom_Drawing_02"},
            {new Guid("1568279A-428F-4D5E-A2D5-863BB6807F9B"), "SP_PT_ChrisRoom_Drawing_03"},
            {new Guid("60AC506E-6CAB-4322-8DB9-5411DAAA9722"), "SP_PT_ChrisRoom_Drawing_04"},
            {new Guid("28faed29-6293-40f0-bd08-96f3dc5efcac"), "SP_PT_ChrisRoom_Drawing_05"},
            {new Guid("952F36F4-1479-4372-B8D3-C383C788A015"), "SP_PT_ChrisRoom_Drawing_06"},
            {new Guid("29F0E1BB-E46F-4CBA-A261-C42305837C39"), "SP_PT_ChrisRoom_Drawing_07"},
            {new Guid("50884358-D17F-47E7-B124-E3A7C785F446"), "SP_PT_ChrisRoom_Drawing_08"},
            {new Guid("535bef3f-bedd-43f9-a16c-e1b915c0b3b4"), "SP_PT_ChrisRoom_FamilyPicture_01"}, //incorrect
            {new Guid("50791936-c3d4-4917-8dd4-871b591890fc"), "SP_PT_ChrisRoom_FantasyMap_01"},
            {new Guid("0DA85602-3267-44B6-A06A-13DBE5EE5249"), "SP_PT_ChrisRoom_FantasyMap_02"},
            {new Guid("4c67b404-7e9a-4b9d-bca5-b658299aceba"), "SP_PT_ChrisRoom_FriendBook_01"},
            {new Guid("6bdd1501-5ac0-4fd8-b01f-c2d0cedb072c"), "SP_PT_ChrisRoom_FriendBook_02"},
            {new Guid("f35613b3-9cd0-4111-ac06-e6e3bb186db8"), "SP_PT_ChrisRoom_GiftList_01"},
            {new Guid("00a368c7-b042-472c-9ef0-4c87aedbd2fd"), "SP_PT_ChrisRoom_MantroidTeam_01"},
            {new Guid("ca3443d2-d2f5-4bd0-81a5-a3fec5de5d62"), "SP_PT_ChrisRoom_VikingBook_01"},
            {new Guid("21d77c16-c2cb-48d3-a54d-3513ebda6197"), "SP_PT_EHOutside_Garage_AcceptationLetter"},
            {new Guid("c7af758d-ad77-49ad-bd3e-d319fba29671"), "SP_PT_EHOutside_Garage_BlackwellLetter"},
            {new Guid("f7c343cf-7c82-4580-996c-a932ce807ffc"), "SP_PT_EHOutside_Garage_ComicStrip01"},
            {new Guid("4753d8d0-3d6d-4795-9b71-95f34819472d"), "SP_PT_EHOutside_Garage_ComicStrip02"},
            {new Guid("a882e394-1409-43d6-bea6-d343670b18f3"), "SP_PT_EHOutside_Garage_Echography"},
            {new Guid("0d2b6650-082e-4b39-b6f7-2b068785ba5a"), "SP_PT_EHOutside_Garage_GazetteArticle"},
            {new Guid("f477da6e-25cc-4740-b887-36e4c571d783"), "SP_PT_EHOutside_Garage_GrandParentsLetter"},
            {new Guid("808990c4-3f7f-461a-a838-dcf7fc44406b"), "SP_PT_EHOutside_Garage_Kindergarten"},
            {new Guid("79b9b2fe-80e0-4518-870e-95e083506c2e"), "SP_PT_EHOutside_Garage_NewspaperStory"},
            {new Guid("76a332c9-3efa-460a-9e98-29f929e9783d"), "SP_PT_EHOutside_Garage_Obituary"},
            {new Guid("38f9edc0-398c-4a0e-99f3-997c44a82bb1"), "SP_PT_EHOutside_Garage_SocialServiceLetter"},
            {new Guid("a8eb77a8-c066-4ece-8b61-e733d92fec97"), "SP_PT_EHOutside_Garden_MailBox"},
            {new Guid("4205aaf4-cd3b-427d-aa3a-d843833d400a"), "SP_PT_EHOutside_GolemCemetery_ChrisEmilyCostume"},
            {new Guid("af4a6bb6-b2c7-42de-ba3e-d39025251b85"), "SP_PT_EHOutside_GolemCemetery_ComicStripChristmasTree"},
            {new Guid("72acc1c1-3df6-41df-b9cb-b9c8abea7aee"), "SP_PT_EHOutside_GolemCemetery_ComicStripConsole"},
            {new Guid("c0de3b1e-8762-479a-b25e-dbb6526fc647"), "SP_PT_EHOutside_GolemCemetery_Emily"},
            {new Guid("03a03427-31a1-4c54-b8fa-9f5d3e4c1d6c"), "SP_PT_EHOutside_TreeHouse_BadGradesReport"},
            {new Guid("c35b904e-c9ef-4fc6-b385-db3458d1fab9"), "SP_PT_EHOutside_TreeHouse_BaseballCards"},
            {new Guid("5b13e5e1-e221-4d6d-94b6-0dc94992b6dc"), "SP_PT_EHOutside_TreeHouse_ComicStrip01"},
            {new Guid("a1add5ee-6131-485f-9d31-c10c255fd2b6"), "SP_PT_EHOutside_TreeHouse_FightLetter"},
            {new Guid("4aded20e-0510-4533-94af-bbd3d8261b7e"), "SP_PT_EHOutside_TreeHouse_TransparentMap"},
            {new Guid("57c627e8-9c14-4f6f-9404-3d24b0f4c911"), "SP_PT_Kitchen_FridgeList_01"},
            {new Guid("90EF41B8-2DA2-44D6-9B3A-1237A5F208F6"), "SP_PT_Kitchen_FridgeList_02"},
            {new Guid("84abe5eb-95c1-4fa9-ac0f-18e957d30f1f"), "SP_PT_Kitchen_GrandparentsLetter_1"},
            {new Guid("15778919-bb5a-4604-b181-8b6d88c1d6ba"), "SP_PT_Kitchen_GrandparentsLetter_2"},
            {new Guid("855d6d6f-ef39-4b84-81c8-ec5530f81473"), "SP_PT_Kitchen_LaptopDadSport"},
            {new Guid("12270de9-963e-405e-8865-aa5dcc1f5221"), "SP_PT_Kitchen_LaptopHawtDawgMan"},
            {new Guid("17e1a21f-9b6c-4a95-965b-ff42eacb2113"), "SP_PT_Kitchen_LaptopHeroConTickets"},
            {new Guid("933f5448-13f6-4403-be70-bd70e9d22f61"), "SP_PT_Kitchen_LaptopRealEstate"},
            {new Guid("5fcecb36-b650-41a0-932b-7df7be134099"), "SP_PT_Kitchen_LaptopTrainHoppers"},
            {new Guid("89a71783-10de-4f5b-86d5-966dd5792a05"), "SP_PT_Kitchen_Newspaper_01"},
            {new Guid("46f2880a-bbf1-4848-98a3-675d5d9e5074"), "SP_PT_Kitchen_PostItPhone"},
            {new Guid("c5067514-8c29-41f4-9577-c22d8329182c"), "SP_PT_Kitchen_Postcard_01"},
            {new Guid("0E6C89F9-BCE8-4654-907F-10986F889D10"), "SP_PT_LaundryRoom_Note_04"},
            {new Guid("07433675-407f-469b-bf46-62550a1f7aa7"), "SP_PT_LivingRoom_ArtBooks"},
            {new Guid("26c4bf0b-1c78-4ff0-b5a8-b1f0232e84b0"), "SP_PT_LivingRoom_CharlesPics_01"},
            {new Guid("77ddff09-d350-4a18-922d-909c6940d360"), "SP_PT_LivingRoom_CharlesPics_02"},
            {new Guid("828e32db-afd8-47eb-80d7-4e376302016e"), "SP_PT_LivingRoom_CharlesPics_03"},
            {new Guid("f5cf1f61-5cf9-4169-b5ab-6ad277236d9f"), "SP_PT_LivingRoom_DadMagazine"},
            {new Guid("56a599c2-71fa-4769-ad6c-659a342c7630"), "SP_PT_LivingRoom_DriftersBook"},
            {new Guid("adccf323-32fe-4912-b94a-b2f6efc9a6e8"), "SP_PT_LivingRoom_FriendPhoto_01"},
            {new Guid("2b55d409-27fe-4a81-8050-7b336954f987"), "SP_PT_LivingRoom_GothBooks"},
            {new Guid("cd2608db-59b8-4c20-9030-f8453c2bed87"), "SP_PT_LivingRoom_WesternBooks"},
        };

        public static Dictionary<Guid, string> LIS2_SeenPicturesNames = new Dictionary<Guid, string>()
        {
            {new Guid("f05d08f8-2c17-4db6-a967-c11fb1c89dc1"), "SP_RetroCars"},
            {new Guid("07f47bec-0c12-4c23-878a-fe28a8069ccf"), "SP_NeighborNote"},
            {new Guid("922a5fcf-3d2d-4707-a409-fff56aeb2773"), "SP_MoviePoster"},
            {new Guid("5a1b167f-4c02-45b1-9997-133306703a70"), "SP_MusicFlyer"},
            {new Guid("9d427a17-6880-4167-9eb7-f40cc9a45988"), "SP_GarageBook"},
            {new Guid("88be6e7f-3194-4d55-be11-3d609bedcbce"), "SP_GaragePicture"},
            {new Guid("22220609-5b72-49e8-91ec-9875c3db720e"), "SP_Slate"},
            {new Guid("fb35ed02-b3fd-47b6-9831-f7498accc1ad"), "SP_SecretRecipe"},
            {new Guid("f5806815-2283-4e6a-84f7-16ad580f018a"), "SP_SkiPicture"},
            {new Guid("ce378ab3-366d-4417-8a88-29d4d35725c9"), "SP_DanielHomework"},
            {new Guid("d54d5538-e993-4f8c-ba8a-107b1576295c"), "SP_DadWorkPaper"},
            {new Guid("807899f3-8721-4205-98d0-1c7f9329f9cc"), "SP_PuertoLobosPostcard"},
            {new Guid("f86f4698-53a1-4602-8964-46ee69f67ab4"), "SP_ASALicence"},
            {new Guid("38381a10-3f81-4866-a397-4a4c12a3c7bb"), "SP_ArtBook02"},
            {new Guid("684bbbf2-e486-4801-a22f-995b5cbbe4ec"), "SP_ArtBook03"},
            {new Guid("9ddfbcde-1dff-428d-88c1-b90444350fa0"), "SP_SeanDrawing"},
            {new Guid("bd84de41-9cb4-4f2e-8690-fdd7eb2a1ef5"), "SP_RunningPicture"},
            {new Guid("758d2693-4230-49b2-9a1a-c3ece8ccdfcc"), "SP_SwimPicture"},
            {new Guid("79b460dc-b9ec-46c1-a9b7-3edf68cddb1f"), "SP_SkateParkPicture"},
            {new Guid("e4530262-7784-4b42-8d22-ae0ee759fde0"), "SP_GamingMagazine"},
            {new Guid("19414893-00ea-4317-a3f6-998145b03cd6"), "SP_FantasyBook"},
            {new Guid("8bd2d057-8f0b-48e8-9678-17deaa6156c1"), "SP_Laptop01"},
            {new Guid("5b55bdc9-eb90-4730-b60f-46ea771fc5ed"), "SP_Laptop02"},
            {new Guid("f3b22cc3-5c24-4f4d-ac79-7a381770ecf3"), "SP_Laptop03"},
            {new Guid("40f55eff-8645-4a29-b957-c7fa1a8b03c6"), "SP_Laptop04"},
            {new Guid("48044b29-3389-4154-b178-8ed1dc026b3d"), "SP_WorkTag"},
            {new Guid("35b6e41f-3e52-4259-ace8-85eb81835840"), "SP_GigFlyer"},
            {new Guid("85124923-234d-49a5-95a8-f48a054cfe2b"), "SP_E1_2A_ParkingArea_InformationSign_Map"},
            {new Guid("083e2715-74b6-4883-8e22-7f2da4ec4a62"), "SP_E1_2A_ParkingArea_InformationSign_DamagedTrail"},
            {new Guid("68f665c8-bff4-4b5f-9cb9-76aba1221684"), "SP_E1_2A_ParkingArea_InformationSign_BearWarning"},
            {new Guid("6ebde5dd-0467-464b-8aaa-3a0ed13b7e25"), "SP_E1_2A_ParkingArea_EmergencySign_01"},
            {new Guid("8c09efb4-b34a-4239-9f69-165f30f5dadd"), "SP_E1_2A_ParkingArea_PayStationSign_01"},
            {new Guid("2c66f049-469b-4c88-b898-4178f8e32abe"), "SP_E1_2A_ParkingArea_HygieneSign"},
            {new Guid("249fff85-5329-4454-bea3-e75dece1e474"), "SP_E1_2A_ParkingArea_InformationSign_Rules"},
            {new Guid("75d12001-d27a-4fe8-80f9-5ca34ee0bf5a"), "SP_E1_2A_ShelterArea_PolaroidCouple_01"},
            {new Guid("9282f37b-bdb0-453e-8e2d-234953c03fec"), "SP_E1_5A_Outside_NewsPaper"},
            {new Guid("2da3c542-d4fa-4799-ab32-87f400c1e8e9"), "SP_E1_5A_Outside_WildAnimalPoster"},
            {new Guid("5f12c67f-4e1f-4a0f-b8d9-972e5c5c1a2e"), "SP_E1_5A_Outside_ReligiousPoster"},
            {new Guid("3b39cdb9-ef73-4d61-8608-96d25a14e740"), "SP_E1_5A_Outside_ChainsawAdd"},
            {new Guid("a73c5600-a5dd-4919-aec9-eb18507eff97"), "SP_E1_5A_Outside_HikingTour"},
            {new Guid("5e9249e5-cca8-48e5-9bf7-5a7fa9ccbd74"), "SP_E1_5A_Outside_SpanishLessons"},
            {new Guid("e1f9efff-bcaf-47b8-b74e-ad86effe2386"), "SP_E1_5A_Outside_PuppyPoster"},
            {new Guid("3b24478f-9b36-4a3f-99de-1b4b3e467356"), "SP_E1_5A_Inside_Brochure_01"},
            {new Guid("7e77aabf-39c5-43d9-9921-00cbf3e96592"), "SP_E1_5A_Inside_Brochure_02"},
            {new Guid("c3ba2f77-48bd-44e8-ac17-6ae514810def"), "SP_E1_5A_Outside_HalloweenPoster"},
            {new Guid("D7A39B87-E749-45BB-9305-40A413B0EEEA"), "SP_E1_5A_Outside_ToiletInstruction.png"},
            {new Guid("C0DC53EF-46F9-4C38-9B14-83C96511F46B"), "SP_E1_5A_Inside_Celebrity.png"},
            {new Guid("69B42753-97B8-46E8-BB34-DE10082DB675"), "SP_E1_5A_Office_Letter.png"},
            {new Guid("9A0EBAA0-A967-422A-9982-9D29BA606016"), "SP_E1_5A_Office_Magasine.png"},
            {new Guid("c1eb856e-15cb-4f83-85a6-e8d33c1de11a"), "SP_E1_7A_Inside_NewMotelCard"},
            {new Guid("4baf6ee0-71c2-4ca8-b295-31971836c5d8"), "SP_E1_7A_Inside_JRNLNote"},
            {new Guid("2ed93a89-887d-46ef-854d-eeb9292b066d"), "SP_E1_7A_Inside_OldMotelCard"},
            {new Guid("bbf28999-8204-408c-9866-60ac55c318c8"), "SP_E1_7A_Inside_Verybus"},
            {new Guid("dc4ab4b0-5404-4691-8cad-78f08deee447"), "SP_E1_7A_Inside_NaturalPark"},
            {new Guid("6a469260-5d76-4162-a0f9-e0a2e384ec0b"), "SP_E1_7A_Inside_HalloweenParty"},
            {new Guid("05a27c44-b48b-4545-b646-a29dee881815"), "SP_E1_7A_Inside_AmusementPark"},
            {new Guid("f3284cdd-c92e-4c1c-aa2c-a0fcc9e6ab58"), "SP_E1_7A_Inside_BeachView"},
            {new Guid("24d5fb97-5133-45ff-8210-dbeeeea0f775"), "SP_E1_7A_Balcony_Cannabis"},
            {new Guid("ef057bd6-9dbf-46ad-8dce-e090a93b8584"), "SP_E1_7A_Inside_Neighborhood"},
            {new Guid("04f5ae47-444d-4af2-8bd8-9c899b26e941"), "SP_E1_7A_Inside_SecurityInstructions"},
        };

        public static Dictionary<Guid, string> LIS2_CollectibleNames = new Dictionary<Guid, string>()
        {
            {new Guid("{6F9636A7-A081-4B06-B48F-F1E30D40DA55}"), "DLC_ArcadiaBay_Tornado.png"},
            {new Guid("{64FC7B16-6678-4F9B-94D8-9F3501C97938}"), "DLC_ArcadiaBay_Anarchy.png"},
            {new Guid("{33A1ED27-CA00-41E5-B5DE-461C7463D1E7}"), "DLC_ArcadiaBay_Butterfly.png"},
            {new Guid("{AB6671C1-418F-412E-A7FD-BD0CFB27C3B5}"), "DLC_ArcadiaBay_Hole.png"},
            {new Guid("{D4CBBC18-575E-4388-80BB-C6D2F308673B}"), "DLC_ArcadiaBay_Sleep.png"},
            {new Guid("{C9375FB7-5451-45A7-B0B7-50803D121303}"), "DLC_CS_Thunder.png"},
            {new Guid("{167BF5DA-5092-4343-9C2B-8CA824ADD402}"), "DLC_CS_HDMKeychain.png"},
            {new Guid("{B228BAF5-07ED-4778-AA12-0826A9835411}"), "DLC_CS_HDMPatch.png"},
            {new Guid("{D96F0C47-8E65-4434-B4BF-50FD2328498D}"), "DLC_CS_PowerBear.png"},
            {new Guid("{71ABE91C-84D4-4639-B9D8-4E8E695B6DA8}"), "BearKeyring.png"},
            {new Guid("{F49914C0-B9BE-473E-A1D1-4B88D557A7DA}"), "Feather.png"},
            {new Guid("{665B92B2-6AFF-495A-944F-AFC29D163A6E}"), "FishingBait.png"},
            {new Guid("{F36D74F5-52FD-4D18-B8D2-DC308F1163F0}"), "MotelCard.png"},
            {new Guid("{0021BE0D-733C-48D9-9858-7979D284BFCB}"), "Necklace.png"},
            {new Guid("{D9F85836-5020-4AE7-AF10-C3C9D59B7FA5}"), "Trucker.png"},
        };

        public static Dictionary<Guid, string> LIS2_ObjectiveNames = new Dictionary<Guid, string>()
        {
            {new Guid("{2B8C63B7-39DA-499C-84A6-BD067A8FC78E}"), "Find some food for the party"},
            {new Guid("{ADADD142-727A-4C96-85A5-F8E855096D24}"), "Find some drinks for the party"},
            {new Guid("{AF664ABE-F80D-47F8-AFA3-D16CE3F80672}"), "Go ask dad some money"},
            {new Guid("{24AF69DE-32A8-4254-AC51-9124A02A6AB0}"), "Find a blanket for Jenn"},
            {new Guid("{8C5771A3-90E3-44FB-96FC-E094887856E1}"), "Pack my Bag"},
            {new Guid("{4A3023E6-491A-4423-A5A1-A23F2D182761}"), "Call Lyla on my laptop"},
            {new Guid("{EC4AA6DB-33C3-4AF3-B2A0-1386C00F423D}"), "Find dad's tool"},
            {new Guid("{017264E4-8882-49C8-B974-02E56E0D7D11}"), "Find a shelter to spend the night"},
            {new Guid("{A8D8BB62-233D-49CA-B3C2-CCDE131BDF98}"), "Gather some wood to build a fire"},
            {new Guid("{88041D93-AAF7-49B5-8754-E00CDD5974E6}"), "Lit the fire"},
            {new Guid("{17812887-197E-4777-B741-8C6804326F1D}"), "Go to sleep"},
            {new Guid("{4E42B513-B95F-4F58-B797-731B4E92DE1C}"), "Find Food"},
            {new Guid("{91133983-6258-4340-88BF-2EC8EE856F5C}"), "Find Drinks"},
            {new Guid("{7DA848B6-C36A-4C0B-9855-1771BF937E77}"), "Find a map of the region"},
            {new Guid("{03D31CB9-CBFF-46D7-BE50-ACC8B7DBB8C4}"), "Sit to study the map"},
            {new Guid("{7E1009CF-62A9-47BA-A583-A720B67AF9AF}"), "Help Daniel to get into the room"},
            {new Guid("{D6054C25-FF98-4CD7-BA31-7218BF370436}"), "Escape the Gas Station"},
            {new Guid("{A7E6FB89-4802-47CE-BFDA-4B6EE58B99A3}"), "Find your Room to unpack"},
            {new Guid("{B3D67376-4570-4CFF-913D-9AA992E69837}"), "Get a bath ready for Daniel"},
            {new Guid("{1ADDE824-6A13-49BB-A596-23AAE0684851}"), "Check your phone"},
            {new Guid("{8FD88BC2-73B3-4B34-8E57-9872FE80C826}"), "Get a drink for Daniel"},
        };

        public static Dictionary<Guid, string> LIS2_DrawingNames = new Dictionary<Guid, string>()
        {
            {new Guid("{C062F28C-5F88-4420-926B-D56C2FEE7133}"), "E1_1A_DrawSequence" },
            {new Guid("{7F3A11E5-F9C0-48A4-9AAD-A8D65FD437EB}"), "E1_2A_DrawSequence" },
            {new Guid("{27E8A427-3B76-4DC7-9606-A962D3CCA084}"), "E1_7A_DrawSequence" },
        };

        public static Dictionary<Guid, string> LIS2_SMSNames = new Dictionary<Guid, string>()
        {
            {new Guid("{1E42F53E-A518-4FEC-BFB5-6D6DA777E15B}"), "E1_Menu_SMS_PC_Boss_01"},
            {new Guid("{BAF222A5-4EF8-4704-ABD1-89120E93088C}"), "E1_Menu_SMS_PC_Boss_02"},
            {new Guid("{9E453420-6136-47AA-8942-6F6C69F80885}"), "E1_Menu_SMS_PC_Boss_03"},
            {new Guid("{24439DCC-C632-4C9C-A8E1-ADEC451340EB}"), "E1_Menu_SMS_PC_Boss_04"},
            {new Guid("{5E130CA5-D650-4B49-96B6-D599164299E4}"), "E1_Menu_SMS_PC_Boss_05"},
            {new Guid("{D57F0177-D7D4-46A2-8F3E-0BB7456E1137}"), "E1_Menu_SMS_PC_Boss_06"},
            {new Guid("{C275F9EA-06A7-4B66-BFD0-141DC179197A}"), "E1_Menu_SMS_PC_Boss_07"},
            {new Guid("{D709C58C-63C9-4622-83BB-E2916A5BD8B6}"), "E1_Menu_SMS_PC_Boss_08"},
            {new Guid("{DFF24BAB-BA6B-4940-B8EB-1C47B6867D67}"), "E1_Menu_SMS_PC_Boss_09"},
            {new Guid("{45EA0834-39AF-4649-B762-04DC0A6FCAA8}"), "E1_Menu_SMS_PC_Boss_10"},
            {new Guid("{7D8F2776-62F0-47B1-A69C-620F6EAE5F62}"), "E1_Menu_SMS_PC_Boss_11"},
            {new Guid("{434F2D78-9E1B-42A7-A9FB-D61DC4DD22CA}"), "E1_Menu_SMS_PC_Boss_12"},
            {new Guid("{26895CB0-B9BC-44F5-8B2E-3EBC1766A346}"), "E1_Menu_SMS_PC_Boss_13"},
            {new Guid("{1FD09779-A240-49CB-BBD8-E323C5FB7AB1}"), "E1_Menu_SMS_Boss_Oct_01"},
            {new Guid("{96E17ED1-6B64-4DC4-8C97-28149B45E2B8}"), "E1_Menu_SMS_Boss_Oct_02"},
            {new Guid("{1A7EC610-49B4-44C8-979D-93B5294FE4B9}"), "E1_Menu_SMS_Boss_Oct_03"},
            {new Guid("{67C3A438-5549-43A6-98F5-8DA1FC72E099}"), "E1_Menu_SMS_Boss_Oct_04"},
            {new Guid("{CD4A8FA0-3748-4A6D-A843-E62A797C343B}"), "E1_Menu_SMS_Boss_Oct_05"},
            {new Guid("{1D7F2F28-1D53-4F37-B081-B12393AFB84E}"), "E1_Menu_SMS_Boss_Oct_06"},
            {new Guid("{31A627CD-14D7-431A-83DD-DC8BD4556ECE}"), "E1_Menu_SMS_Boss_Oct_07"},
            {new Guid("{E32E0548-898F-4E06-B7B1-D2AC816381D8}"), "E1_Menu_SMS_Boss_Oct_08"},
            {new Guid("{0FA63522-86F4-4B44-A03B-1C65F6B4209E}"), "E1_Menu_SMS_Boss_Oct_09"},
            {new Guid("{A33D7E24-0362-43BA-8A9A-8E9FA885A63E}"), "E1_Menu_SMS_Boss_Oct_10"},
            {new Guid("{518847CB-0CA5-4D9C-905B-56BAA8A2323E}"), "E1_Menu_SMS_Boss_Oct_11"},
            {new Guid("{DCBE6409-DFC5-4A64-884C-55BDE1668E7D}"), "E1_Menu_SMS_PC_Coach_01"},
            {new Guid("{30DA3E0D-C751-47E5-AF60-021CFE10D90A}"), "E1_Menu_SMS_PC_Coach_02"},
            {new Guid("{E5E9BD05-8AEE-4544-A463-5000BB915E4D}"), "E1_Menu_SMS_PC_Coach_03"},
            {new Guid("{BB3BF4CF-668B-44F1-97E6-8D1A503DC8BF}"), "E1_Menu_SMS_PC_Coach_04"},
            {new Guid("{97EF8A3E-DA44-447B-8A06-C137633CC633}"), "E1_Menu_SMS_PC_Coach_05"},
            {new Guid("{C145DFF3-5B0B-4AD3-A096-B02643CDF985}"), "E1_Menu_SMS_PC_Coach_06"},
            {new Guid("{E4F174E0-B90E-4717-96C4-7D6231C53A45}"), "E1_Menu_SMS_PC_Coach_07"},
            {new Guid("{B57B9A07-4140-4773-9739-BD2D5A477FFA}"), "E1_Menu_SMS_PC_Coach_08"},
            {new Guid("{E0D2185A-4B39-40E5-9B95-F00363F0DC67}"), "E1_Menu_SMS_PC_Coach_09"},
            {new Guid("{769CB09F-9481-44BC-B31F-9C420A433312}"), "E1_Menu_SMS_PC_Coach_10"},
            {new Guid("{CDACC1BC-5BE1-445C-A3CE-771E23EC1275}"), "E1_Menu_SMS_PC_Coach_11"},
            {new Guid("{ED6FC7FD-7D0B-4FF8-A68D-1D206A4D559B}"), "E1_Menu_SMS_PC_Coach_12"},
            {new Guid("{AB78423D-649C-4DE0-9233-249BFB4AA115}"), "E1_Menu_SMS_PC_Coach_13"},
            {new Guid("{5E1D0816-855A-442C-9DF0-5CF71557D474}"), "E1_Menu_SMS_PC_Coach_14"},
            {new Guid("{8FC927B9-47B2-4533-93F7-1264B62FF12B}"), "E1_Menu_SMS_PC_Coach_15"},
            {new Guid("{4FF36C61-D81A-47AB-B350-00827CD6FBE8}"), "E1_Menu_SMS_PC_Coach_16"},
            {new Guid("{A37CA637-5B6B-4895-9988-98F4B8808DCA}"), "E1_Menu_SMS_PC_Coach_17"},
            {new Guid("{F08C8D60-9AF0-42B6-A261-F8A59880C1B0}"), "E1_Menu_SMS_PC_Esteban_01"},
            {new Guid("{FED7F0B4-F3DC-4DB9-85DC-521505AE4D4C}"), "E1_Menu_SMS_PC_Esteban_02"},
            {new Guid("{E6524FCA-6646-4495-A24A-CA5F88C6C55B}"), "E1_Menu_SMS_PC_Esteban_03"},
            {new Guid("{91552B7F-2BA3-48CE-B059-ED63AC2D4D97}"), "E1_Menu_SMS_PC_Esteban_04"},
            {new Guid("{04F55C00-21E6-4829-468A-62C866E0D883}"), "E1_Menu_SMS_PC_Esteban_05"},
            {new Guid("{6A3FFCA5-07F8-41BD-A12F-8C08D25C06C1}"), "E1_Menu_SMS_PC_Esteban_06"},
            {new Guid("{94EF9ACC-5BB0-431F-8067-0FBF36960215}"), "E1_Menu_SMS_PC_Esteban_07"},
            {new Guid("{41E56F78-773D-40CC-B579-A7A1172F71D5}"), "E1_Menu_SMS_PC_Esteban_08"},
            {new Guid("{92B38CFE-33FC-41A8-B0B8-A6CC0630487D}"), "E1_Menu_SMS_PC_Esteban_09"},
            {new Guid("{4ACA1A8D-7503-4526-90EC-BCFF52231C5F}"), "E1_Menu_SMS_PC_Esteban_10"},
            {new Guid("{D20299C4-51EB-4049-ACFD-8A7EB12A43FF}"), "E1_Menu_SMS_PC_Esteban_11"},
            {new Guid("{F5E70F46-C49D-4FC1-9C8D-9450A7FE26CA}"), "E1_Menu_SMS_PC_Esteban_12"},
            {new Guid("{4BDFA6DE-CAF3-40A6-AB73-B58E2C29ED7C}"), "E1_Menu_SMS_PC_Esteban_13"},
            {new Guid("{647E8857-A3EB-447A-89D0-CA647CC90E42}"), "E1_Menu_SMS_PC_Esteban_14"},
            {new Guid("{7F9AEB85-AB54-4552-AEAB-C10EE2E433A3}"), "E1_Menu_SMS_PC_Esteban_15"},
            {new Guid("{DDDABD54-25C2-42C8-8E5B-EC271B8497E3}"), "E1_Menu_SMS_PC_Esteban_16"},
            {new Guid("{C9F61DFA-2BD1-4DBC-84D1-E4D181ECF3E0}"), "E1_Menu_SMS_PC_Esteban_17"},
            {new Guid("{CD63B3D6-A2B8-4188-B9C7-A45EC815E5BF}"), "E1_Menu_SMS_PC_Esteban_18"},
            {new Guid("{7F642CAF-6CBF-496F-9BB3-27036694346D}"), "E1_Menu_SMS_PC_Esteban_19"},
            {new Guid("{F7F06A27-0962-43D8-A856-3EC98B9337BB}"), "E1_Menu_SMS_PC_Esteban_20"},
            {new Guid("{22EEB22C-26BD-43C8-BEAE-61631183DFED}"), "E1_Menu_SMS_PC_Esteban_21"},
            {new Guid("{59B71123-A9CA-4118-8F3C-D467F40F89E0}"), "E1_Menu_SMS_PC_Esteban_22"},
            {new Guid("{F211A9A4-D280-47A6-87BC-40FEBC2B4ED8}"), "E1_Menu_SMS_Esteban_Oct_01"},
            {new Guid("{A1379C0A-C789-4E21-87A9-85B0E62760B3}"), "E1_Menu_SMS_Esteban_Oct_02"},
            {new Guid("{62889A27-6C75-427B-87CB-3051AAF23E47}"), "E1_Menu_SMS_Esteban_Oct_03"},
            {new Guid("{58145B00-0623-42C6-B507-11D2913028DA}"), "E1_Menu_SMS_Esteban_Oct_04"},
            {new Guid("{DA8EEB2B-A45E-4389-B1AF-755F353371DE}"), "E1_Menu_SMS_Esteban_Oct_05"},
            {new Guid("{09D4606D-5510-4463-A981-4E328ACE5F8F}"), "E1_Menu_SMS_Esteban_Oct_06"},
            {new Guid("{630C2DCC-8368-4714-8E6B-BE28C00091D3}"), "E1_Menu_SMS_Esteban_Oct_07"},
            {new Guid("{2A50C0DA-D4C5-4AA0-9EE2-C0342626E6DD}"), "E1_Menu_SMS_Esteban_Oct_08"},
            {new Guid("{0D8E19F5-C5CB-49B1-845E-1CAE6B3FF318}"), "E1_Menu_SMS_Esteban_Oct_09"},
            {new Guid("{528EB26F-73F9-4D8F-BC6B-07C86E223AE8}"), "E1_Menu_SMS_Esteban_Oct_10"},
            {new Guid("{D19CA74C-3DF4-4C72-9378-9D3DA23B2167}"), "E1_Menu_SMS_Esteban_Oct_11"},
            {new Guid("{F55EE1AC-0799-48E8-97D8-089F15B4B66F}"), "E1_Menu_SMS_Esteban_Oct_12"},
            {new Guid("{AEBA9EA8-0D59-4B8E-9BA8-7783A946FA2A}"), "E1_Menu_SMS_Esteban_Oct_13"},
            {new Guid("{A95AE7A3-51FA-443A-B2DD-352477C488D8}"), "E1_Menu_SMS_Esteban_Oct_14"},
            {new Guid("{5FBD591E-B284-4FA9-83B4-2C103D7D8119}"), "E1_Menu_SMS_Esteban_Oct_15"},
            {new Guid("{F458F4FC-3918-4DEF-B1FC-A2B5FE0AB93E}"), "E1_Menu_SMS_Esteban_Oct_16"},
            {new Guid("{34BCE44F-9EA2-424C-AF88-221B716F8255}"), "E1_Menu_SMS_Esteban_Oct_17"},
            {new Guid("{5CBBC3A9-A76E-462F-81FB-F3F2DC29EE94}"), "E1_Menu_SMS_Esteban_Oct_18"},
            {new Guid("{03902D19-6480-4421-B162-7BD56252DBB9}"), "E1_Menu_SMS_Esteban_Oct_19"},
            {new Guid("{C0563740-EFDB-443C-ABE5-42AF5903F005}"), "E1_Menu_SMS_Esteban_Oct_20"},
            {new Guid("{A0324BBC-9CB7-45F2-9E01-CE5C5D9435EC}"), "E1_Menu_SMS_Esteban_Oct_21"},
            {new Guid("{2CB10EDE-3997-42C7-ADA9-2AAF5942259E}"), "E1_Menu_SMS_Esteban_Oct_22"},
            {new Guid("{77AFA91C-06EC-405C-BE97-607A2150AF6F}"), "E1_Menu_SMS_Esteban_Oct_23"},
            {new Guid("{B8B69CD3-71A7-4718-A3CC-E6ADB7F6DC1A}"), "E1_Menu_SMS_Esteban_Oct_24"},
            {new Guid("{F1497275-05D8-463E-BB05-EE61BA641B6B}"), "E1_Menu_SMS_Esteban_Oct_25"},
            {new Guid("{770D0E35-54AD-492F-94F2-F8443A2E1F03}"), "E1_Menu_SMS_Esteban_Oct_26"},
            {new Guid("{379BBF2E-CFCE-4730-9EA4-E5B2494C5364}"), "E1_Menu_SMS_Esteban_Oct_27"},
            {new Guid("{85602AA1-D749-40C7-8BE4-E3D96D2D8FF3}"), "E1_Menu_SMS_Esteban_Oct_28"},
            {new Guid("{C1196081-4280-47F6-B5A4-8CB6255DBCB3}"), "E1_Menu_SMS_Esteban_Oct_29"},
            {new Guid("{29B21929-7C4E-4730-896E-FC882F3FF361}"), "E1_Menu_SMS_Esteban_Oct_30"},
            {new Guid("{4A7F3B81-D853-4D9D-B9EC-C5F7AF0E2BDF}"), "E1_Menu_SMS_Esteban_Oct_31"},
            {new Guid("{0E7ACD21-DC93-432C-8EE2-0E02FFE1598B}"), "E1_Menu_SMS_Esteban_Oct_32"},
            {new Guid("{E2B1CFE7-537D-4EFC-9143-F45C2286A58F}"), "E1_Menu_SMS_Esteban_Oct_33"},
            {new Guid("{2962357E-30BC-4395-B279-E6124BB12953}"), "E1_Menu_SMS_Esteban_E1-1A_01"},
            {new Guid("{7D91B646-5B6A-47D7-846E-FACE9B021449}"), "E1_Menu_SMS_Esteban_E1-1A_02"},
            {new Guid("{B7825F64-AFD8-4627-81DE-8A97288D8627}"), "E1_Menu_SMS_Esteban_E1-1A_03"},
            {new Guid("{A4C9D410-634A-4995-9C49-185CA2B32801}"), "E1_Menu_SMS_Esteban_E1-1A_04"},
            {new Guid("{14F5A8B3-42DF-49B5-B170-322A740B6C7C}"), "E1_Menu_SMS_Esteban_E1-1A_05"},
            {new Guid("{FABA45EB-76EC-41A0-9E77-3FB16B953847}"), "E1_Menu_SMS_Esteban_E1-1A_06"},
            {new Guid("{AE208241-C469-41F3-85A9-357695656691}"), "E1_Menu_SMS_PC_Lyla_01"},
            {new Guid("{1E0C1924-AFB8-48A9-88D9-656E80653C54}"), "E1_Menu_SMS_PC_Lyla_02"},
            {new Guid("{BC334B0E-D883-42E7-AFFD-4B0E9FCBECDD}"), "E1_Menu_SMS_PC_Lyla_03"},
            {new Guid("{7CD2EBB8-224D-4C30-97F6-804A23D26C06}"), "E1_Menu_SMS_PC_Lyla_04"},
            {new Guid("{CA04C417-F817-4DBD-8148-E662345040DA}"), "E1_Menu_SMS_PC_Lyla_05"},
            {new Guid("{422C7155-1A54-43EE-8451-39014CC0D277}"), "E1_Menu_SMS_PC_Lyla_06"},
            {new Guid("{EBEA6465-54B2-4898-BC19-58D681D76051}"), "E1_Menu_SMS_PC_Lyla_07"},
            {new Guid("{7E188B0B-785B-4505-B579-8E1C7F59A079}"), "E1_Menu_SMS_PC_Lyla_08"},
            {new Guid("{59B5E4D0-EEB5-4602-9C58-C512C7291FF9}"), "E1_Menu_SMS_PC_Lyla_09"},
            {new Guid("{26A57E32-EBF9-4218-B3BB-8A89A703D45D}"), "E1_Menu_SMS_PC_Lyla_10"},
            {new Guid("{AC669F26-720B-42E7-9F1C-8BF515BE4A39}"), "E1_Menu_SMS_PC_Lyla_11"},
            {new Guid("{8B80CBA9-BC96-4036-A42B-BB79DD3106F2}"), "E1_Menu_SMS_PC_Lyla_12"},
            {new Guid("{569A0EA3-E328-453D-A27F-BF31160911A6}"), "E1_Menu_SMS_PC_Lyla_13"},
            {new Guid("{87CE7D27-41F6-4212-A076-2DC0B5E40394}"), "E1_Menu_SMS_PC_Lyla_14"},
            {new Guid("{083A3569-ADA3-4DC3-B9F4-FB6AD905A425}"), "E1_Menu_SMS_PC_Lyla_15"},
            {new Guid("{0DCEDCD0-74BD-4D30-B02B-41AFB79DE8D1}"), "E1_Menu_SMS_PC_Lyla_16"},
            {new Guid("{BA2C0C7E-ACBC-4F4E-B2B7-72BF6D64CA73}"), "E1_Menu_SMS_PC_Lyla_17"},
            {new Guid("{9E73C174-4ADE-4255-A7F9-9EA02096212A}"), "E1_Menu_SMS_PC_Lyla_18"},
            {new Guid("{3BF6E3A2-A567-4BF2-A5C2-946987C797AB}"), "E1_Menu_SMS_PC_Lyla_19"},
            {new Guid("{586832B5-3D23-4C5C-8D05-86588509577F}"), "E1_Menu_SMS_PC_Lyla_20"},
            {new Guid("{D83D2FD9-5928-4B2A-8935-60063ED49742}"), "E1_Menu_SMS_PC_Lyla_21"},
            {new Guid("{7CB1F23C-9722-4467-948B-741AB5FD318B}"), "E1_Menu_SMS_PC_Lyla_22"},
            {new Guid("{90E80241-99B5-4A16-A3F9-B34C8D0E1BBB}"), "E1_Menu_SMS_PC_Lyla_23"},
            {new Guid("{05A23F42-6D5A-46E6-A6DD-CB586E9AC714}"), "E1_Menu_SMS_PC_Lyla_24"},
            {new Guid("{9A1A87A2-8BA1-4BFC-8F15-620DDADF9F9C}"), "E1_Menu_SMS_PC_Lyla_25"},
            {new Guid("{361BF759-8DDE-4123-8C76-DB3B468C7306}"), "E1_Menu_SMS_PC_Lyla_26"},
            {new Guid("{C875BEC5-AB2C-4A31-9AFC-8D4B27E000EC}"), "E1_Menu_SMS_PC_Lyla_27"},
            {new Guid("{0B338A85-78AF-4EAD-A035-BD35C10AF519}"), "E1_Menu_SMS_PC_Lyla_28"},
            {new Guid("{045D3203-C87C-45DE-81D1-5FB5E73AFC61}"), "E1_Menu_SMS_PC_Lyla_29"},
            {new Guid("{286E23CA-E93D-4476-B556-13E442CB5872}"), "E1_Menu_SMS_PC_Lyla_30"},
            {new Guid("{E4ACCF47-20F0-4C8C-B4BE-BC784CFD30D3}"), "E1_Menu_SMS_PC_Lyla_31"},
            {new Guid("{0E0A9C2B-E6A7-4E73-9C94-3D66123BC00E}"), "E1_Menu_SMS_PC_Lyla_32"},
            {new Guid("{986462CA-037B-4FFA-BF31-2817122122D8}"), "E1_Menu_SMS_PC_Lyla_33"},
            {new Guid("{7A4C5E4A-80FD-43B5-857B-7DB32A5DE78D}"), "E1_Menu_SMS_PC_Lyla_34"},
            {new Guid("{9AC3211F-78AA-419C-9B45-5626815352B5}"), "E1_Menu_SMS_PC_Lyla_35"},
            {new Guid("{275F17E1-B6EF-4524-A0BD-FF402215B5E2}"), "E1_Menu_SMS_PC_Lyla_36"},
            {new Guid("{9F12021D-910B-4490-BCAA-FB8F2148C9C5}"), "E1_Menu_SMS_PC_Lyla_37"},
            {new Guid("{6E03E7D4-3479-4F32-A848-B01825FFD05A}"), "E1_Menu_SMS_PC_Lyla_38"},
            {new Guid("{12B6EC67-374B-475B-A0A5-5604760CD1F9}"), "E1_Menu_SMS_PC_Lyla_39"},
            {new Guid("{49C59FC9-A36E-48C0-B18F-E019EFFD04AC}"), "E1_Menu_SMS_PC_Lyla_40"},
            {new Guid("{8113FBF3-1D9C-4637-8877-AAE25C95DCB3}"), "E1_Menu_SMS_PC_Lyla_41"},
            {new Guid("{FB1BB54D-0E94-4200-A1E6-423B26501BEC}"), "E1_Menu_SMS_PC_Lyla_42"},
            {new Guid("{763347BE-4E4D-4BAD-AA18-51EF8B12516B}"), "E1_Menu_SMS_PC_Lyla_43"},
            {new Guid("{4AF5AC77-DAEB-4916-AE57-54300E7F5CA7}"), "E1_Menu_SMS_PC_Lyla_44"},
            {new Guid("{051530E9-2459-4110-9E53-70577D28797D}"), "E1_Menu_SMS_PC_Lyla_45"},
            {new Guid("{8F868A5D-10AE-4C40-AD40-9423119DBFA4}"), "E1_Menu_SMS_PC_Lyla_46"},
            {new Guid("{AF8D8E2B-5E1F-42CB-BFE7-A058BDF57101}"), "E1_Menu_SMS_PC_Lyla_47"},
            {new Guid("{523D108A-125D-4913-B52B-BB0557458685}"), "E1_Menu_SMS_PC_Lyla_48"},
            {new Guid("{B3CC52CF-D131-4E49-B9BA-0AA17574BF28}"), "E1_Menu_SMS_PC_Lyla_49"},
            {new Guid("{53F41D3A-FB58-4F1A-A785-2BB089BF0780}"), "E1_Menu_SMS_PC_Lyla_50"},
            {new Guid("{0528339B-44E1-4686-BCBC-E284C19E8C46}"), "E1_Menu_SMS_PC_Lyla_51"},
            {new Guid("{2953B7E8-132D-42E7-BC8F-55BC60988D5A}"), "E1_Menu_SMS_PC_Lyla_52"},
            {new Guid("{029BCED2-5095-4884-88AE-60EDA280A4D3}"), "E1_Menu_SMS_PC_Lyla_53"},
            {new Guid("{17DBC520-C5FC-4A06-9DA5-198345F233C9}"), "E1_Menu_SMS_PC_Lyla_54"},
            {new Guid("{1782ED3D-0BD2-43CD-9AAE-4D726DFEF8C6}"), "E1_Menu_SMS_PC_Lyla_55"},
            {new Guid("{29A3DFF2-1162-40EF-B861-7C86A7EBB4DE}"), "E1_Menu_SMS_PC_Lyla_56"},
            {new Guid("{D02DEB93-9475-4CA2-B2D0-E06E5F897F74}"), "E1_Menu_SMS_PC_Lyla_57"},
            {new Guid("{3E471AF4-6339-48F3-8F54-E361F63A4FCA}"), "E1_Menu_SMS_PC_Lyla_58"},
            {new Guid("{BC9D41C9-460A-4ADE-A318-DAD37997A3C9}"), "E1_Menu_SMS_PC_Lyla_59"},
            {new Guid("{5E25F877-266F-4D2A-BFB1-C3C9F7E438FC}"), "E1_Menu_SMS_PC_Lyla_60"},
            {new Guid("{D7B47834-4FC5-4E68-A201-C943C297DBCD}"), "E1_Menu_SMS_PC_Lyla_61"},
            {new Guid("{51F304F1-BA67-45CD-B9C4-CF0203CEC6D7}"), "E1_Menu_SMS_PC_Lyla_62"},
            {new Guid("{1D31104A-E594-4616-935C-A8E2A8F63008}"), "E1_Menu_SMS_PC_Lyla_63"},
            {new Guid("{3684FD01-FAF1-46E3-9C23-3B333DDCCA42}"), "E1_Menu_SMS_PC_Lyla_64"},
            {new Guid("{C40A277E-17E9-4E8E-82EC-75CB7C360028}"), "E1_Menu_SMS_PC_Lyla_65"},
            {new Guid("{B2483958-9A7C-4DCC-A813-5083BCDCB695}"), "E1_Menu_SMS_PC_Lyla_66"},
            {new Guid("{0EFF995E-990F-46B0-A7A4-FFDFC722C8FC}"), "E1_Menu_SMS_PC_Lyla_67"},
            {new Guid("{CBC29B73-F056-4F20-BCD8-B942D2E9C73B}"), "E1_Menu_SMS_PC_Lyla_68"},
            {new Guid("{FCE6C2CE-E1CA-4379-9E94-1B2838A3843B}"), "E1_Menu_SMS_PC_Lyla_69"},
            {new Guid("{BD148405-5F75-42E9-92B4-8D9BC34779F1}"), "E1_Menu_SMS_PC_Lyla_70"},
            {new Guid("{ED3272C8-A0C1-4E0B-8153-D15469A22544}"), "E1_Menu_SMS_PC_Lyla_71"},
            {new Guid("{6BE401F7-3433-4E96-817D-7A0F8E94D1E6}"), "E1_Menu_SMS_PC_Lyla_72"},
            {new Guid("{29911729-84EE-4539-B810-4A5F399DEC07}"), "E1_Menu_SMS_PC_Lyla_73"},
            {new Guid("{739B4C3D-5530-4CCC-B3A0-32E9A6C665D0}"), "E1_Menu_SMS_PC_Lyla_74"},
            {new Guid("{F8D3FF78-A659-4DC9-B948-60482B6AD74D}"), "E1_Menu_SMS_PC_Lyla_75"},
            {new Guid("{D38266B1-B9FA-40B6-A283-F350B878E981}"), "E1_Menu_SMS_PC_Lyla_76"},
            {new Guid("{E9400B4E-5ED1-42EC-A5B3-277A75DF2645}"), "E1_Menu_SMS_PC_Lyla_77"},
            {new Guid("{5A01851F-ECF6-4A06-8272-C2EFB24A0E33}"), "E1_Menu_SMS_PC_Lyla_78"},
            {new Guid("{EC1F8678-9634-4533-96D8-68D4BF7B5AE6}"), "E1_Menu_SMS_PC_Lyla_79"},
            {new Guid("{7FF4AD6F-FDBA-4BCB-BB80-6A947490986D}"), "E1_Menu_SMS_PC_Lyla_80"},
            {new Guid("{38137584-6851-479F-A1AB-BF58182C117A}"), "E1_Menu_SMS_PC_Lyla_81"},
            {new Guid("{C42CE63C-1627-4F47-BE51-CC3DDF5CEDE1}"), "E1_Menu_SMS_PC_Lyla_82"},
            {new Guid("{2B59A3C1-12D7-48AE-B83B-79945ABAA917}"), "E1_Menu_SMS_PC_Lyla_83"},
            {new Guid("{180E6C24-4BFE-43A3-BEE5-7C77F6B8FFA8}"), "E1_Menu_SMS_PC_Lyla_85"},
            {new Guid("{840C7E23-F927-45EF-9A62-CB712FA810FF}"), "E1_Menu_SMS_PC_Lyla_86"},
            {new Guid("{2CCCAB1B-954F-4CFD-B222-7E97F2064190}"), "E1_Menu_SMS_PC_Lyla_87"},
            {new Guid("{44487AA4-BBB8-4C68-8785-E24A467F18CC}"), "E1_Menu_SMS_PC_Lyla_88"},
            {new Guid("{FE097F4F-2C29-47A4-B2BC-C9D8B17DC45E}"), "E1_Menu_SMS_PC_Lyla_89"},
            {new Guid("{901CEC19-11E5-4744-A978-A3C9070892EF}"), "E1_Menu_SMS_Lyla_Oct_01"},
            {new Guid("{749D23CB-66A5-4A4E-8084-673FA444830C}"), "E1_Menu_SMS_Lyla_Oct_02"},
            {new Guid("{3CA57690-4E46-42EC-9EC6-464DFEC5F9FE}"), "E1_Menu_SMS_Lyla_Oct_03"},
            {new Guid("{227135B8-867E-478B-9C59-C7492832334D}"), "E1_Menu_SMS_Lyla_Oct_04"},
            {new Guid("{362EA52D-52A8-4A3F-86AB-924C54DA0114}"), "E1_Menu_SMS_Lyla_Oct_05"},
            {new Guid("{0E4529FF-8C4C-4183-B343-34F1EB882793}"), "E1_Menu_SMS_Lyla_Oct_06"},
            {new Guid("{975432CB-E952-4319-AC04-C4623EE7B565}"), "E1_Menu_SMS_Lyla_Oct_07"},
            {new Guid("{98448DF7-774A-47C0-87DC-1E1F0B5AC2DE}"), "E1_Menu_SMS_Lyla_Oct_08"},
            {new Guid("{CFE493D1-DC66-4AC7-A524-1BBDDEE07553}"), "E1_Menu_SMS_Lyla_Oct_09"},
            {new Guid("{0A93F13D-5940-4D6C-966D-683450DA54E3}"), "E1_Menu_SMS_Lyla_Oct_10"},
            {new Guid("{E455A927-DD9E-4256-ADB6-4270D35C4562}"), "E1_Menu_SMS_Lyla_Oct_11"},
            {new Guid("{A37642F4-06CC-4775-B2A9-BF17D8B4F760}"), "E1_Menu_SMS_Lyla_Oct_12"},
            {new Guid("{CE93DE8F-E23E-46F5-A5DE-D5FE1CDDAD19}"), "E1_Menu_SMS_Lyla_Oct_13"},
            {new Guid("{E4FF1F69-6815-4F24-945E-43BA45E5A4AA}"), "E1_Menu_SMS_Lyla_Oct_14"},
            {new Guid("{2D9DD2E6-A598-429D-9F42-E229B3125CE5}"), "E1_Menu_SMS_Lyla_Oct_15"},
            {new Guid("{577C664E-58CC-4BCC-ADAA-0AFFA37BFC89}"), "E1_Menu_SMS_Lyla_Oct_16"},
            {new Guid("{43B3F3CA-51A9-431A-AA02-D3059C8ABC32}"), "E1_Menu_SMS_Lyla_Oct_17"},
            {new Guid("{56AE2756-E613-4E3F-BCE9-1C54774A721A}"), "E1_Menu_SMS_Lyla_Oct_18"},
            {new Guid("{651780C5-6566-45B1-85A8-C64E79608651}"), "E1_Menu_SMS_Lyla_Oct_19"},
            {new Guid("{E79C8800-02DB-3C7E-4BAA-F12B97526591}"), "E1_Menu_SMS_Lyla_Oct_20"},
            {new Guid("{FA07A068-AD75-4CF6-B586-208DA65ED487}"), "E1_Menu_SMS_Lyla_Oct_21"},
            {new Guid("{D71099EB-6518-4852-9AC9-4B23733010C9}"), "E1_Menu_SMS_Lyla_Oct_22"},
            {new Guid("{AEB1D7F0-40FC-41BF-8EB9-5B00C27F0F9C}"), "E1_Menu_SMS_Lyla_Oct_23"},
            {new Guid("{C26B1CCB-630F-40D3-877C-CFC485BBDE02}"), "E1_Menu_SMS_Lyla_Oct_24"},
            {new Guid("{B4B3E92F-9EF8-4DF5-8FEA-2E10F9F85782}"), "E1_Menu_SMS_Lyla_Oct_25"},
            {new Guid("{2AFFD9DB-CBC3-4481-85AB-F3CDAD34797F}"), "E1_Menu_SMS_Lyla_Oct_26"},
            {new Guid("{D2C46E81-EF60-4724-9A30-9216B84FB279}"), "E1_Menu_SMS_Lyla_Oct_27"},
            {new Guid("{EEF2DB22-3919-41C8-8BCA-8A2488726D08}"), "E1_Menu_SMS_Lyla_Oct_28"},
            {new Guid("{85ACE089-6DB7-4CDB-AF39-E0245C9943A1}"), "E1_Menu_SMS_Lyla_Oct_29"},
            {new Guid("{0F718EB9-5998-4932-BA71-4B6458E5035A}"), "E1_Menu_SMS_Lyla_Oct_30"},
            {new Guid("{00B5E878-4E57-43E6-911F-BF2C8B4273C0}"), "E1_Menu_SMS_Lyla_Oct_31"},
            {new Guid("{A5FF5FE9-A4C1-42F2-A77A-2671BCE80D25}"), "E1_Menu_SMS_Lyla_Oct_32"},
            {new Guid("{9BC69CBE-6AF8-4125-9A15-CD7F10D3865C}"), "E1_Menu_SMS_Lyla_Oct_33"},
            {new Guid("{B983082C-BB69-4668-999C-BBAC7D949405}"), "E1_Menu_SMS_Lyla_Oct_34"},
            {new Guid("{E9243942-8DB1-4F74-9567-D578067B13FE}"), "E1_Menu_SMS_Lyla_Oct_35"},
            {new Guid("{A06C4ABE-1CE1-4318-8AB3-6625CA6BADC4}"), "E1_Menu_SMS_Lyla_Oct_36"},
            {new Guid("{5447FDCF-1129-49E9-B148-1B166D43F969}"), "E1_Menu_SMS_Lyla_Oct_37"},
            {new Guid("{FE988F70-267B-4E95-8CF0-19AB6092ADC3}"), "E1_Menu_SMS_Lyla_Oct_38"},
            {new Guid("{75706FD5-C116-4E64-8355-C184B63D548E}"), "E1_Menu_SMS_Lyla_Oct_39"},
            {new Guid("{408740D6-0260-4F1A-B9A1-AAE55409F3CB}"), "E1_Menu_SMS_Lyla_Oct_40"},
            {new Guid("{3380BF9F-E780-4D20-8647-24DCA9494061}"), "E1_Menu_SMS_Lyla_Oct_41"},
            {new Guid("{8E2C2039-460A-4488-A066-BEEBF42D1C7B}"), "E1_Menu_SMS_Lyla_Oct_42"},
            {new Guid("{BB9D72E9-6FC9-4B3A-9B21-1876A65E8362}"), "E1_Menu_SMS_Lyla_Oct_43"},
            {new Guid("{5111BEA6-BCB6-41ED-B367-AA3D0819184C}"), "E1_Menu_SMS_Lyla_Oct_44"},
            {new Guid("{3BD0DD0B-C787-4CC9-AE35-2E216605539E}"), "E1_Menu_SMS_Lyla_Oct_45"},
            {new Guid("{FCDAFA0C-4DC5-4797-9A8D-E3BE8A8E4D40}"), "E1_Menu_SMS_Lyla_Oct_46"},
            {new Guid("{F15B7E82-6CB2-42C0-97D9-368CA3B8F98F}"), "E1_Menu_SMS_Lyla_Oct_47"},
            {new Guid("{1204E98B-14E8-4509-AC7A-AD00EC4BB5CF}"), "E1_Menu_SMS_Lyla_Oct_48"},
            {new Guid("{F1C09983-5D5D-40E9-B6A1-810D527B0242}"), "E1_Menu_SMS_Lyla_Oct_49"},
            {new Guid("{8039F3B3-E21D-4D96-8C71-526353D34395}"), "E1_Menu_SMS_Lyla_Oct_50"},
            {new Guid("{2CFD2BCB-7C51-495E-A36F-5A935689F8BE}"), "E1_Menu_SMS_Lyla_Oct_51"},
            {new Guid("{C3C76EC7-EBF4-4F85-8A60-075D7B20EF9F}"), "E1_Menu_SMS_Lyla_Oct_52"},
            {new Guid("{4F76F03B-E9FC-46B4-BBD8-2D9151A6BD5D}"), "E1_Menu_SMS_Lyla_Oct_53"},
            {new Guid("{8FD7719F-83F5-473D-B3F2-46C2F0A770DE}"), "E1_Menu_SMS_Lyla_Oct_54"},
            {new Guid("{04A296A7-CD8B-4495-AC04-370CC4E4EC32}"), "E1_Menu_SMS_Lyla_Oct_55"},
            {new Guid("{6BDD82CE-2F3A-4FC5-9360-B0DFD2863EC2}"), "E1_Menu_SMS_Lyla_Oct_56"},
            {new Guid("{C4764E16-79BD-4E87-96CE-3F9E828A039C}"), "E1_Menu_SMS_Lyla_Oct_57"},
            {new Guid("{B72F51F3-DA36-4C36-982F-F8FF79F1D389}"), "E1_Menu_SMS_Lyla_Oct_58"},
            {new Guid("{82511C0B-642A-4618-A8D9-6EA38901C5B8}"), "E1_Menu_SMS_Lyla_Oct_59"},
            {new Guid("{7BFD5117-4E98-4986-9E1F-B17E374EE572}"), "E1_Menu_SMS_Lyla_Oct_60"},
            {new Guid("{FFE0CBAC-F54A-4E9E-A39F-492B6C2C551F}"), "E1_Menu_SMS_Lyla_Oct_61"},
            {new Guid("{B0919B03-AD05-4FCA-9516-90A8F3CF7692}"), "E1_Menu_SMS_Lyla_Oct_62"},
            {new Guid("{174D2BB2-0FA1-423D-A714-798189041ADF}"), "E1_Menu_SMS_Lyla_Oct_63"},
            {new Guid("{7D107C6D-468D-4D5C-9D06-7E40C83F97EC}"), "E1_Menu_SMS_Lyla_Oct_64"},
            {new Guid("{9C141F40-48FE-43B6-85FF-EAD6AC20D0EF}"), "E1_Menu_SMS_Lyla_Oct_65"},
            {new Guid("{304B83A0-BB19-4D3D-8D24-01FF451A3ACB}"), "E1_Menu_SMS_Lyla_Oct_66"},
            {new Guid("{D1225FEE-D7B1-4BC7-9D38-04C748193DB5}"), "E1_Menu_SMS_Lyla_Oct_67"},
            {new Guid("{FEA7B8C9-1005-4D60-9221-44C29E9CDD11}"), "E1_Menu_SMS_Lyla_Oct_68"},
            {new Guid("{582DF9A1-843E-485A-A8B9-C3A993E85335}"), "E1_Menu_SMS_Lyla_Oct_69"},
            {new Guid("{9584BD5F-929A-4AB6-9BD5-655C3159C120}"), "E1_Menu_SMS_Lyla_Oct_70"},
            {new Guid("{EEDBA02B-DD9A-4021-B698-8F134C62A526}"), "E1_Menu_SMS_Lyla_Oct_71"},
            {new Guid("{F015EC62-DD68-4B16-9F64-40215488026E}"), "E1_Menu_SMS_Lyla_Oct_72"},
            {new Guid("{A3AFCB03-A98A-4328-B882-D09CF29639A0}"), "E1_Menu_SMS_Lyla_Oct_73"},
            {new Guid("{9689F04D-3256-4EA6-BBC8-50929413E85E}"), "E1_Menu_SMS_Lyla_Oct_74"},
            {new Guid("{CEA68DE3-2802-47EB-9501-FF85B165F676}"), "E1_Menu_SMS_Lyla_Oct_75"},
            {new Guid("{79D81371-0A26-405E-A255-B15E3A799417}"), "E1_Menu_SMS_Lyla_Oct_76"},
            {new Guid("{4826F371-7370-46FF-A508-EBFA1B568989}"), "E1_Menu_SMS_Lyla_Oct_77"},
            {new Guid("{175C125D-3320-4A2D-B14E-C87FECA08298}"), "E1_Menu_SMS_Lyla_Oct_78"},
            {new Guid("{B58372CC-DF9A-409C-917D-6F2D954D832D}"), "E1_Menu_SMS_Lyla_Oct_79"},
            {new Guid("{68DCF868-C16B-4251-A364-20944A4DFAED}"), "E1_Menu_SMS_Jenn_Oct_01"},
            {new Guid("{9ECB9F6A-1948-4AB2-998B-8722261BD932}"), "E1_Menu_SMS_Jenn_Oct_02"},
            {new Guid("{03B72AB7-5375-4074-B285-AE8050CAD5A4}"), "E1_Menu_SMS_Jenn_Oct_03"},
            {new Guid("{418C9626-EA2C-4FF0-B1A1-C1F920555963}"), "E1_Menu_SMS_Jenn_Oct_04"},
            {new Guid("{7C40B27D-FAD9-4DF4-90A9-A0B0B0EA79E0}"), "E1_Menu_SMS_Jenn_Oct_05"},
            {new Guid("{6DAD53D6-5AB7-4239-9041-ACA2A2DD0DA7}"), "E1_Menu_SMS_Jenn_Oct_06"},
            {new Guid("{9A8D8B02-BF6F-48E0-BA47-4651782992A7}"), "E1_Menu_SMS_Jenn_Oct_07"},
            {new Guid("{682801D1-354F-4453-A4B1-2EC091FC7452}"), "E1_Menu_SMS_Jenn_Oct_08"},
            {new Guid("{5E9AFEEB-BB32-4CAD-9445-96429FB93AEC}"), "E1_Menu_SMS_Jenn_Oct_09"},
            {new Guid("{2EB3B536-66ED-4F66-8D03-3B9B993FF90C}"), "E1_Menu_SMS_Jenn_Oct_10"},
            {new Guid("{45013F50-2555-431D-B94F-C13AE7397F51}"), "E1_Menu_SMS_Jenn_Oct_11"},
            {new Guid("{68E83433-2534-4556-BBB1-E642C157B57E}"), "E1_Menu_SMS_Jenn_Oct_12"},
            {new Guid("{BDF25B77-D578-46EF-8283-01696EAC596E}"), "E1_Menu_SMS_Jenn_Oct_13"},
            {new Guid("{21A430D7-E6C8-4669-B6BD-1F4141319602}"), "E1_Menu_SMS_Jenn_Oct_14"},
            {new Guid("{4A23B035-717E-402A-8EE9-1EEE029376EC}"), "E1_Menu_SMS_Jenn_Oct_15"},
            {new Guid("{4D45B59B-B421-41BD-A8CD-34D47D3C3371}"), "E1_Menu_SMS_Jenn_Oct_16"},
            {new Guid("{91FD1436-662E-4225-8DA7-2254BB55422E}"), "E1_Menu_SMS_Jenn_Oct_17"},
            {new Guid("{6045427B-5CE9-4000-B1A7-EE6D99025704}"), "E1_Menu_SMS_Jenn_Oct_18"},
            {new Guid("{0AA9853F-632D-4535-847E-F7BBE380E670}"), "E1_Menu_SMS_Jenn_Oct_19"},
            {new Guid("{B706D28A-71CF-466F-AD70-F783CA6E165E}"), "E1_Menu_SMS_Jenn_Oct_20"},
            {new Guid("{E9E63560-37A8-4654-A2D3-46938FFE4CE4}"), "E1_Menu_SMS_Jenn_Oct_21"},
            {new Guid("{F3B3009B-6677-4108-8A0E-B31E70388882}"), "E1_Menu_SMS_Jenn_Oct_22"},
            {new Guid("{68E09DBC-CF1A-40A3-BE88-D1DBA2DA003F}"), "E1_Menu_SMS_Jenn_Oct_23"},
            {new Guid("{78C73573-2C50-4724-92AB-361B74D9CB69}"), "E1_Menu_SMS_Jenn_Oct_24"},
            {new Guid("{26D35073-E672-41E3-97D1-A2512F3B11DF}"), "E1_Menu_SMS_Jenn_Oct_25"},
            {new Guid("{E82E5A0D-80A1-4241-9BD2-A1D8F1486532}"), "E1_Menu_SMS_Jenn_Oct_26"},
            {new Guid("{E11C6532-CE93-4AE3-80AA-B648B73124FE}"), "E1_Menu_SMS_Jenn_Oct_27"},
            {new Guid("{70DD9BFA-2014-4024-B5C7-B6B103EFFD8A}"), "E1_Menu_SMS_Jenn_Oct_28"},
            {new Guid("{ADC6EE58-EE43-49BA-A565-62784F408A69}"), "E1_Menu_SMS_Jenn_Oct_29"},
            {new Guid("{FCE144C9-7B70-4CFB-B2E2-3F039424CF48}"), "E1_Menu_SMS_Jenn_Oct_30"},
            {new Guid("{0BA83ED7-03DF-4ABF-B584-DC6DC7530AC0}"), "E1_Menu_SMS_Jenn_Oct_31"},
            {new Guid("{E0C2149D-DBCF-43E3-A4C8-D35E11C43097}"), "E1_Menu_SMS_Jenn_E1-1A_01"},
            {new Guid("{B50F3436-704B-47B7-9C07-143AFF69B4CC}"), "E1_Menu_SMS_PC_Eric_01"},
            {new Guid("{9ADE9D3F-AE2B-430E-9E6E-C466F4DE355E}"), "E1_Menu_SMS_PC_Eric_02"},
            {new Guid("{E6DD03C1-3CD9-46C2-8AEE-5A4F539A7131}"), "E1_Menu_SMS_PC_Eric_03"},
            {new Guid("{14B55051-90E9-4CB7-9909-3B951011AA5B}"), "E1_Menu_SMS_PC_Eric_04"},
            {new Guid("{1D796C3D-3C08-4F48-9F9A-FCC65CA0A882}"), "E1_Menu_SMS_PC_Eric_05"},
            {new Guid("{79871C92-1161-434B-98C1-3C9FB33CDEFD}"), "E1_Menu_SMS_PC_Eric_06"},
            {new Guid("{3111F341-8495-4CA8-9217-0595C34E8734}"), "E1_Menu_SMS_Friends_Oct_01"},
            {new Guid("{7947205C-B759-48AA-AECD-3E947AF9382F}"), "E1_Menu_SMS_Friends_Oct_04"},
            {new Guid("{B0BA9F6C-0242-4B4A-BA42-BA017420F128}"), "E1_Menu_SMS_Friends_Oct_05"},
            {new Guid("{3EA83DD9-2885-44F4-994A-2C068E498A36}"), "E1_Menu_SMS_Friends_Oct_06"},
            {new Guid("{2FEF3568-65B6-AF4D-DC5C-4B70F7A4D12E}"), "E1_Menu_SMS_Friends_Oct_08"},
            {new Guid("{D390387A-D37B-4744-89BF-9D4D50BB7724}"), "E1_Menu_SMS_Friends_Oct_09"},
            {new Guid("{50DA77A1-7FF3-4F53-9C5B-C9FFC0E46F10}"), "E1_Menu_SMS_Friends_Oct_12"},
            {new Guid("{1BBE0371-048F-43F0-8B7E-894D6A43F3BB}"), "E1_Menu_SMS_Friends_Oct_13"},
            {new Guid("{99C10414-AF50-4606-8052-B7AA07CBBFCA}"), "E1_Menu_SMS_Friends_Oct_15"},
            {new Guid("{5CC5C56C-2143-4228-9604-3300891193D8}"), "E1_Menu_SMS_Friends_Oct_16"},
            {new Guid("{C81E0EB2-B355-47E9-932C-852D14CBE787}"), "E1_Menu_SMS_Friends_Oct_31"},
            {new Guid("{2DAEF0FA-F7B3-4EB6-B332-D3D78355909D}"), "E1_Menu_SMS_Friends_Oct_32"},
            {new Guid("{F494B44A-DA17-4F85-AE10-EFE2F368EED0}"), "E1_Menu_SMS_Friends_Oct_33"},
            {new Guid("{F1135BB5-5C79-4ECE-B9A6-5493D08279CF}"), "E1_Menu_SMS_Friends_Oct_34"},
            {new Guid("{9322E86C-0AA8-44D5-9AE5-4A930E9F1ABA}"), "E1_Menu_SMS_Friends_Oct_35"},
            {new Guid("{B598C88A-BE2C-489B-A90E-61B0C863C51A}"), "E1_Menu_SMS_Friends_Oct_36"},
            {new Guid("{F8BE54DE-BA36-42E5-A277-CEBD305AEDEE}"), "E1_Menu_SMS_Friends_Oct_37"},
            {new Guid("{BA9E050B-98E6-4764-B43B-4A748505626C}"), "E1_Menu_SMS_Friends_Oct_38"},
            {new Guid("{29AE6734-0A31-4A36-894E-36072E0EE0DB}"), "E1_Menu_SMS_PC_Adam_01"},
            {new Guid("{4346F734-CF06-459D-A1F3-E368C442CB98}"), "E1_Menu_SMS_PC_Adam_02"},
            {new Guid("{26E27265-6967-449B-9AF9-16D97069B6C1}"), "E1_Menu_SMS_PC_Adam_03"},
            {new Guid("{15E6E729-E9F1-4E33-A191-C668642DB963}"), "E1_Menu_SMS_PC_Adam_04"},
            {new Guid("{53227854-F0F1-4226-8F73-C461EF738E2E}"), "E1_Menu_SMS_PC_Adam_05"},
            {new Guid("{1A1B59D7-28F4-4BC3-A3C7-D3DB8E253425}"), "E1_Menu_SMS_PC_Adam_06"},
            {new Guid("{120809C8-E080-4CC7-930F-DEA58FD6D9E4}"), "E1_Menu_SMS_PC_Adam_07"},
            {new Guid("{190AC210-756F-46A9-8D24-3C8D63ED2E2F}"), "E1_Menu_SMS_PC_Adam_08"},
            {new Guid("{8BB7C5DE-37D1-4DD4-8850-5764E5FA86D3}"), "E1_Menu_SMS_PC_Adam_09"},
            {new Guid("{33206674-DBFE-44D4-A33C-D8F8D4EFBFE6}"), "E1_Menu_SMS_PC_Adam_10"},
            {new Guid("{A5E4D9A0-E2C0-4629-9F99-D54F5F18FE9C}"), "E1_Menu_SMS_PC_Adam_11"},
            {new Guid("{AA6B0EEA-61F8-4E73-A96A-5A3C895B0DE2}"), "E1_Menu_SMS_PC_Adam_12"},
            {new Guid("{2E790B43-44B6-44BD-AD76-882DD18FD1BB}"), "E1_Menu_SMS_Friends_Oct_18"},
            {new Guid("{E57AEA8F-6C79-4DE4-A039-2EE47EBFE7AC}"), "E1_Menu_SMS_Friends_Oct_19"},
            {new Guid("{2F17B0A1-6399-49F8-A7D9-F10AC3719014}"), "E1_Menu_SMS_Friends_Oct_20"},
            {new Guid("{16B9C212-B4A6-4AC6-8152-9012EC2B6A31}"), "E1_Menu_SMS_Friends_Oct_21"},
            {new Guid("{01FF565B-DD5C-4902-ACBA-594039C3FE02}"), "E1_Menu_SMS_Friends_Oct_22"},
            {new Guid("{84E7174F-B689-4691-8CE1-4E96FF09E60B}"), "E1_Menu_SMS_Friends_Oct_23"},
            {new Guid("{CBD86ABB-CB47-4C6D-AC6E-5F1BFD25C182}"), "E1_Menu_SMS_Friends_Oct_24"},
            {new Guid("{AB3B032D-C25E-4EFD-A459-BD8E269D7735}"), "E1_Menu_SMS_Friends_Oct_25"},
            {new Guid("{4AAB8F4F-9559-439F-8558-5ECA7B1414EA}"), "E1_Menu_SMS_Friends_Oct_26"},
            {new Guid("{1CE820E7-3F4F-436F-B790-7DD5ECD5B4DF}"), "E1_Menu_SMS_Friends_Oct_27"},
            {new Guid("{14F4B221-7124-49B5-9281-69EB35D269D9}"), "E1_Menu_SMS_Friends_Oct_28"},
            {new Guid("{8E1E2301-8B27-498C-9668-703F7D592575}"), "E1_Menu_SMS_Friends_Oct_29"},
            {new Guid("{2ECD1061-E57E-4EE4-A675-13678BF6F343}"), "E1_Menu_SMS_Friends_Oct_30"},
            {new Guid("{0CEFFFE6-E02D-4B14-A521-6B5533FE8026}"), "E1_Menu_SMS_Esteban_E1-1A_07"},
            {new Guid("{B4A56F34-6DCF-43EF-AADA-148CC83C5EEA}"), "E1_Menu_SMS_Lyla_E1-1A_01"},
            {new Guid("{62E0ABAD-7F81-41D3-8521-58AB2D52E0EC}"), "E1_Menu_SMS_Lyla_E1-1A_02"},
            {new Guid("{64CCA509-B284-49D9-A41B-3C29996A92B2}"), "E1_Menu_SMS_Jenn_E1-1A_02"},
            {new Guid("{9DE4AE45-7445-4171-A96F-18AB055A1D69}"), "E1_Menu_SMS_Derek_E1-1A_01"},
            {new Guid("{EBC362AC-671C-45E0-9548-B0CF34BF6D75}"), "E1_Menu_SMS_Derek_E1-1A_03"},
            {new Guid("{0372DFFF-16C0-47BC-86D5-E78B49311078}"), "E1_Menu_SMS_Boss_E1-2A_01"},
            {new Guid("{AB37FB91-8CCD-49DF-9F3C-FB77D6B1F881}"), "E1_Menu_SMS_Boss_E1-2A_02"},
            {new Guid("{CF222AA5-B87C-4EAD-9C72-FD0329EED479}"), "E1_Menu_SMS_Boss_E1-2A_03"},
            {new Guid("{94ADB495-4502-4EA0-96D4-582739D97458}"), "E1_Menu_SMS_Boss_E1-2A_04"},
            {new Guid("{EBD445D2-0C58-4EF2-A92D-A7B4F7F7628D}"), "E1_Menu_SMS_Boss_E1-2A_05"},
            {new Guid("{5E5C4965-4DD4-4100-B600-9532FBE1081C}"), "E1_Menu_SMS_Lyla_E1-2A_01"},
            {new Guid("{5E270D8A-0812-4AF5-8458-0CE2975B18B9}"), "E1_Menu_SMS_Lyla_E1-2A_02"},
            {new Guid("{3B4B22DA-0365-4B9D-B58B-DCCC6E380F3E}"), "E1_Menu_SMS_Lyla_E1-2A_03"},
            {new Guid("{BD474B60-FB26-4149-A2EB-A0CB377D3551}"), "E1_Menu_SMS_Lyla_E1-2A_04"},
            {new Guid("{4ABBB57C-0CDB-4506-8C24-A6CABD732455}"), "E1_Menu_SMS_Lyla_E1-2A_05"},
            {new Guid("{3D5AD849-EB1D-4A98-8495-4E4E94DA9FBB}"), "E1_Menu_SMS_Lyla_E1-2A_06"},
            {new Guid("{3BEF4BC3-4B36-414B-92C8-3E30A50DE823}"), "E1_Menu_SMS_Lyla_E1-2A_07"},
            {new Guid("{D73A592D-432C-45A5-A592-81F8EE8D7ECF}"), "E1_Menu_SMS_Lyla_E1-2A_08"},
            {new Guid("{A2A0FD47-EA4B-450F-AFA9-B5162E000A90}"), "E1_Menu_SMS_Lyla_E1-2A_09"},
            {new Guid("{18F3FD93-CC33-4E97-BF54-659254D922DA}"), "E1_Menu_SMS_Lyla_E1-2A_10"},
            {new Guid("{72536341-F150-4283-8FBD-B97F23DBAF1D}"), "E1_Menu_SMS_Lyla_E1-2A_11"},
            {new Guid("{7A2E3A5F-73C3-40CC-8821-70D94ABEDE60}"), "E1_Menu_SMS_Lyla_E1-2A_12"},
            {new Guid("{C69FF586-C872-4C6E-B563-A036C08E4FBB}"), "E1_Menu_SMS_Lyla_E1-2A_13"},
            {new Guid("{45F15894-1B95-4AB1-B3B7-1170E79E586A}"), "E1_Menu_SMS_Lyla_E1-2A_14"},
            {new Guid("{ED73C077-9DFF-42B1-AA9F-02F6D9D67B2D}"), "E1_Menu_SMS_Lyla_E1-2A_15"},
            {new Guid("{5DB2E821-B3E5-4A6D-AA6F-EE694E939109}"), "E1_Menu_SMS_Lyla_E1-2A_16"},
            {new Guid("{71B3F518-CD04-4AA1-ADD5-93B8CB9DCF16}"), "E1_Menu_SMS_Lyla_E1-2A_17"},
            {new Guid("{D7ADB3D5-9649-4F50-B173-92789B2FB8DC}"), "E1_Menu_SMS_Lyla_E1-2A_18"},
            {new Guid("{C6C4B9E6-D100-4CAF-BB06-08DBBA806007}"), "E1_Menu_SMS_Lyla_E1-2A_19"},
            {new Guid("{1856AA16-AFC4-4A2C-B6C5-A64CF2F91C2A}"), "E1_Menu_SMS_Lyla_E1-2A_20"},
            {new Guid("{963611D1-6003-46C2-A805-6352F8D7B803}"), "E1_Menu_SMS_Lyla_E1-2A_21"},
            {new Guid("{FC0F6389-49AC-48F0-A2E6-A0DE0ACAE042}"), "E1_Menu_SMS_Lyla_E1-2A_22"},
            {new Guid("{F5B55A04-9BCD-BA4B-2EFA-2C44D2298D2D}"), "E1_Menu_SMS_Lyla_E1-2A_23"},
            {new Guid("{10BF8351-19D9-4C4F-BEFD-CF1170D1C9F3}"), "E1_Menu_SMS_Lyla_E1-2A_24"},
            {new Guid("{10196578-4D95-401A-86D8-9A6B0528E57C}"), "E1_Menu_SMS_Lyla_E1-2A_25"},
            {new Guid("{BB6EE652-231C-48D3-86A5-9E87FED02834}"), "E1_Menu_SMS_Lyla_E1-2A_26"},
            {new Guid("{C3D15B48-0EC3-42D2-98BA-BDD71FDB5D9B}"), "E1_Menu_SMS_Lyla_E1-2A_27"},
            {new Guid("{C29BEB3C-1BC2-4DB4-A0DA-DA3160993B6A}"), "E1_Menu_SMS_Lyla_E1-2A_28"},
            {new Guid("{FD601DAF-DB3A-4CBF-AAEA-BA1C4199A87D}"), "E1_Menu_SMS_Lyla_E1-2A_29"},
            {new Guid("{895A7999-6F8C-4E0F-8124-DF3F5ECBE571}"), "E1_Menu_SMS_Lyla_E1-2A_30"},
            {new Guid("{E74FBDCC-0A88-4510-A67C-5B2491264440}"), "E1_Menu_SMS_Lyla_E1-2A_31"},
            {new Guid("{7A49B661-DF2B-478A-94DF-E722C9205C24}"), "E1_Menu_SMS_Lyla_E1-2A_32"},
            {new Guid("{D9289B96-A0F4-455F-8ABA-5D4667AB4E7F}"), "E1_Menu_SMS_Lyla_E1-2A_33"},
            {new Guid("{69573C05-FDDB-4479-A2D1-3502A701C028}"), "E1_Menu_SMS_Lyla_E1-2A_34"},
            {new Guid("{000C96AC-2EE1-4F2C-83E7-3671FC18DED6}"), "E1_Menu_SMS_Lyla_E1-2A_35"},
            {new Guid("{6948A902-EA18-489C-9425-F23774A8478F}"), "E1_Menu_SMS_Lyla_E1-2A_36"},
            {new Guid("{AC2F20A1-A84B-4392-AA19-CB71ED28CCF8}"), "E1_Menu_SMS_Lyla_E1-2A_37"},
            {new Guid("{803008F0-F629-4CA5-AF51-ACC0BB3613C0}"), "E1_Menu_SMS_Lyla_E1-2A_38"},
            {new Guid("{C6A74AC8-6866-4C65-85C2-0A412D8D3E0F}"), "E1_Menu_SMS_Lyla_E1-2A_39"},
            {new Guid("{3529B16A-484C-488B-8907-0AEA29B67D65}"), "E1_Menu_SMS_Lyla_E1-2A_40"},
            {new Guid("{BB70E090-B743-4D50-86D9-936FD77A9852}"), "E1_Menu_SMS_Lyla_E1-2A_41"},
            {new Guid("{867E45EC-E020-41E0-9737-949120AF9A96}"), "E1_Menu_SMS_Lyla_E1-2A_42"},
            {new Guid("{5ADC6802-05C4-4A12-8B5D-3DE3CA346B7A}"), "E1_Menu_SMS_Lyla_E1-2A_43"},
            {new Guid("{3C4AC3F6-B341-4C6E-82AF-3205C217547E}"), "E1_Menu_SMS_Lyla_E1-2A_44"},
            {new Guid("{A494E3C2-9890-4238-8389-5AD4B6850D46}"), "E1_Menu_SMS_Lyla_E1-2A_45"},
            {new Guid("{62362C14-D693-4399-AE8E-AACAC2977957}"), "E1_Menu_SMS_Lyla_E1-2A_46"},
            {new Guid("{2039ABF3-4783-4368-9834-4CAA8ADE654A}"), "E1_Menu_SMS_Lyla_E1-2A_47"},
            {new Guid("{7605BB81-99AE-4ED5-9C85-BEB749906236}"), "E1_Menu_SMS_Lyla_E1-2A_48"},
            {new Guid("{DCF0E3AD-5E5D-4FF5-8514-57B750FA53DE}"), "E1_Menu_SMS_Lyla_E1-2A_49"},
            {new Guid("{B0C0E2D3-B9F7-4BA2-8510-0FC161207B1B}"), "E1_Menu_SMS_Lyla_E1-2A_50"},
            {new Guid("{A94225C8-2FC9-41CE-A207-C48006E9205E}"), "E1_Menu_SMS_Lyla_E1-2A_51"},
            {new Guid("{65AFC168-8DBB-4C5C-942E-A3C58AAEF95D}"), "E1_Menu_SMS_Lyla_E1-2A_52"},
            {new Guid("{85C4BF6E-BDE0-4EE0-ABE8-05F49D4CC569}"), "E1_Menu_SMS_Lyla_E1-2A_53"},
            {new Guid("{6B39EF89-F9B7-4B4A-AEFF-00E4CB3E7CB4}"), "E1_Menu_SMS_Lyla_E1-2A_54"},
            {new Guid("{9E661E68-7C6E-47B7-93A7-8FE31109D2CD}"), "E1_Menu_SMS_Lyla_E1-2A_55"},
            {new Guid("{586216CD-7C94-4155-B42D-B0865F7C9642}"), "E1_Menu_SMS_Lyla_E1-2A_56"},
            {new Guid("{43BA800D-D105-4D14-B564-52FC17CA468A}"), "E1_Menu_SMS_Lyla_E1-2A_57"},
            {new Guid("{0CECB79B-2FF6-4DC3-A951-C7094B99A6F9}"), "E1_Menu_SMS_Lyla_E1-2A_58"},
            {new Guid("{0A365157-42C4-43D1-9E13-0A329AAA5633}"), "E1_Menu_SMS_Lyla_E1-2A_59"},
            {new Guid("{502823B1-4881-460E-B2F3-30F438213B45}"), "E1_Menu_SMS_Lyla_E1-2A_60"},
            {new Guid("{E833F6A4-5575-447F-8956-6AA7CC3DAB9E}"), "E1_Menu_SMS_Lyla_E1-2A_61"},
            {new Guid("{418331B1-2DAA-4F5B-ADB7-64E2CC123DD0}"), "E1_Menu_SMS_Lyla_E1-2A_62"},
            {new Guid("{4FF16450-D4FB-44DB-99D3-80869115AB94}"), "E1_Menu_SMS_Lyla_E1-1A_07"},
            {new Guid("{4F9FE35E-C2C5-4B93-B6A7-60571A52BC17}"), "E1_Menu_SMS_Lyla_E1-1A_08"},
            {new Guid("{3458A26E-C7F1-4992-AC10-E5638645C154}"), "E1_Menu_SMS_Lyla_E1-1A_09"},
            {new Guid("{4D2CA04C-8DD5-4A3A-AB93-5FD26BB97F68}"), "E1_Menu_SMS_Lyla_E1-1A_10"},
            {new Guid("{08735E54-4265-4575-B59E-7C21750C2C5D}"), "E1_Menu_SMS_Jenn_E1-2A_01"},
            {new Guid("{DA1BE871-D5C9-4D17-AA82-41CC33331925}"), "E1_Menu_SMS_Jenn_E1-2A_02"},
            {new Guid("{0B9DC644-C8C1-4F17-8C3C-0FD185E2801B}"), "E1_Menu_SMS_Jenn_E1-2A_03"},
            {new Guid("{F8A3D69E-E477-407C-BB18-97D3FECD041D}"), "E1_Menu_SMS_Jenn_E1-2A_04"},
            {new Guid("{8E13B0F1-2C64-4EF2-8B27-15059DADE067}"), "E1_Menu_SMS_Jenn_E1-2A_05"},
            {new Guid("{1C693FB9-ACAA-4349-990E-E4EDD777480C}"), "E1_Menu_SMS_Jenn_E1-2A_06"},
            {new Guid("{6615413B-BBFD-432E-A8D6-4FD4090EF207}"), "E1_Menu_SMS_Jenn_E1-2A_07"},
            {new Guid("{3AF79726-4995-48A3-AB79-9289F494B362}"), "E1_Menu_SMS_Eric_E1-2A_01"},
            {new Guid("{422E121C-2170-4829-848D-840167F57893}"), "E1_Menu_SMS_Eric_E1-2A_02"},
            {new Guid("{D415708B-FAF0-4E11-95B8-C694F337132C}"), "E1_Menu_SMS_Eric_E1-2A_03"},
            {new Guid("{09CE35E5-8D89-4C67-B6C3-E31D03144FC0}"), "E1_Menu_SMS_Eric_E1-2A_04"},
            {new Guid("{D751B1F9-603B-4351-8559-1AFFA5407DD0}"), "E1_Menu_SMS_Officer_E1-2A_01"},
            {new Guid("{588DA3DF-36AB-4A80-9743-359DBC322684}"), "E1_Menu_SMS_UnknownFriend_E1-2A_02"},
            {new Guid("{AF9FFDA2-1E04-4D8D-9322-3DE5918AD602}"), "E1_Menu_SMS_Coach_E1-3A_01"},
            {new Guid("{99A5A11D-9882-41D5-B57F-C0D93C69EE92}"), "E1_Menu_SMS_Coach_E1-3A_02"},
            {new Guid("{4E920045-B9B5-4D1F-8B43-14523F1B5D32}"), "E1_Menu_SMS_Coach_E1-3A_03"},
            {new Guid("{120F0D51-52D6-4C7E-898A-14C53420B951}"), "E1_Menu_SMS_Lyla_E1-3A_01"},
            {new Guid("{5B01D64D-1F97-463A-9343-C0B67CE43430}"), "E1_Menu_SMS_Lyla_E1-3A_02"},
            {new Guid("{D49A42B1-F4AE-417D-B632-35303B7DF593}"), "E1_Menu_SMS_Lyla_E1-3A_03"},
            {new Guid("{DE573B49-DD17-4321-AFED-0FE53C66201C}"), "E1_Menu_SMS_Lyla_E1-3A_04"},
            {new Guid("{A04EF6C0-DF68-4705-842E-D25173649496}"), "E1_Menu_SMS_Lyla_E1-3A_05"},
            {new Guid("{C85E5D2B-90AB-460E-A78D-1FE91B3B9648}"), "E1_Menu_SMS_Lyla_E1-3A_06"},
            {new Guid("{40F2536C-4113-42A8-B68D-A105BC426A93}"), "E1_Menu_SMS_Lyla_E1-3A_07"},
            {new Guid("{4001BE4A-9942-4576-B619-8B0A2AB8170A}"), "E1_Menu_SMS_Eric_E1-3A_01"},
            {new Guid("{E10EAE9E-2BAC-414D-B0CA-A8A0DA01E94F}"), "E1_Menu_SMS_Eric_E1-3A_02"},
            {new Guid("{5C2F7329-8DA5-4614-BEEB-D15684551CCE}"), "E1_Menu_SMS_Ellery_E1-3A_01"},
            {new Guid("{4D5F4316-385D-4207-9A96-03853033C802}"), "E1_Menu_SMS_Lyla_E1-7A_05"},
        };

        public static List<LevelObject> CS_Levels = new List<LevelObject>()
        {
            {
                new LevelObject()
                {
                    Name = "PROM_P",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_AMB",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_Background_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHDreams_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_EHDreams_ToGolemCem",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHInside_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHInside_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHOutside_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHInside_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_EHInside_HouseDoor",
                        "GAT_EHInside_Bathroom",
                        "GAT_EHInside_ChrisRoom",
                        "GAT_EHInside_CharlesRoom",
                        "GAT_EHWindow_01",
                        "GAT_EHWindow_02",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHOutside_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHOutside_LD",
                    Interactions = new List<InteractionActor>()
                    {
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Padlock",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8d786eb3-f446-49aa-aaf8-1de8d31c1b36"), "PROM_P_IntActor_Padlock_C1_Look" },
                                    { new Guid("f9590e00-f543-4c3b-a4e5-c9faf1e15ab0"), "PROM_P_IntActor_Padlock_C2_Unlock" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Lookout",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ea61c0e4-7210-4fc1-90c8-b4ac3a375d92"), "PROM_P_IntActor_Lookout_C1_Sit" },
                                    { new Guid("7d54742c-bf56-4ff1-9e15-84a2065449f6"), "PROM_P_IntActor_Lookout_C2_Sit" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Spiritmobile",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ba214193-e732-4d57-91cb-be08a074525a"), "PROM_P_IntActor_Spiritmobile_C1_Look" },
                                    { new Guid("82c430bb-8895-44db-8356-064a1325884a"), "PROM_P_IntActor_Spiritmobile_C2_Look" },
                                    { new Guid("154f15ec-0775-43c3-8f98-43d4fd34afe4"), "PROM_P_IntActor_Spiritmobile_C3_Inspect" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("48e48fd3-7df7-4ecb-9ea6-f4d03e0e7765"), "PROM_P_IntActor_Spiritmobile_C0_PowerDrive" },
                                    { new Guid("44b4bae6-c363-4dde-8b4d-d31127581d40"), "PROM_P_IntActor_Spiritmobile_C0_PowerDrive" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Firecracker",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fa2b8065-fe6b-4266-b4de-31d847fbde27"), "PROM_P_IntActor_Firecracker_C1_Look" },
                                    { new Guid("883a3c99-c8ff-4277-af40-eb8f1b389ebc"), "PROM_P_IntActor_Firecracker_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_LadderGoDown",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cb96c404-9442-40d7-8d11-f76dd449ad8e"), "PROM_P_IntActor_LadderGoDown_C1_Godown" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SideDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("eeb28afc-8349-44e6-8f1e-fbebaadb437f"), "PROM_P_IntActor_SideDoor_C1_Open" },
                                    { new Guid("cd75c8ca-91a6-40a0-8e26-f901985b28a6"), "PROM_P_IntActor_SideDoor_C2_Open" },
                                    { new Guid("9f0ccd62-4719-468d-ab42-50a1bee08088"), "PROM_P_IntActor_SideDoor_C3_Open" },
                                    { new Guid("83f7f143-2e3c-41ea-80a6-396187c7b524"), "PROM_P_IntActor_SideDoor_C4_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_TransparentMap",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e4303c35-b4d4-4192-983a-4346b9443010"), "PROM_P_IntActor_TransparentMap_C1_Look" },
                                    { new Guid("707c0292-3d7f-43f8-bcd1-ab5198da05da"), "PROM_P_IntActor_TransparentMap_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GolemCemetary",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2fe86bf6-6940-4250-bfbd-9c50e8a1b20e"), "PROM_P_IntActor_GolemCemetary_C1_Look" },
                                    { new Guid("85639c10-a766-4e4b-a5de-28c0aefc6df8"), "PROM_P_IntActor_GolemCemetary_C2_Look" },
                                    { new Guid("efbb1503-2bfd-4e9c-b06e-b45fa06554bd"), "PROM_P_IntActor_GolemCemetary_C3_Enter" },
                                    { new Guid("1fb1e2bf-2830-4451-8a61-ebc5e646e493"), "PROM_P_IntActor_GolemCemetary_C4_Enter" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SnowMan",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4bacb280-9bfc-4bde-ae29-721f68d36569"), "PROM_P_IntActor_SnowMan_C1_Look" },
                                    { new Guid("8dd9acd0-4fa4-4ae8-9ed6-5845d61a3897"), "PROM_P_IntActor_SnowMan_C2_Tune" },
                                    { new Guid("850e1b12-70f5-40a0-8b89-ef824e4d798e"), "PROM_P_IntActor_SnowMan_C3_Look" },
                                    { new Guid("e6e12e2c-c46b-4090-9c0f-2fa158e5be6d"), "PROM_P_IntActor_SnowMan_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("50c6c988-1a9c-466b-b6e1-e1c00b312ecb"), "PROM_P_IntActor_SnowMan_C0_BlowUp" },
                                    { new Guid("8a684962-4063-4875-8e58-8271ec0ccc98"), "PROM_P_IntActor_SnowMan_C0_BlowUp" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CreepyTree",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f73e181b-84fb-4a36-ab92-410b80e39008"), "PROM_P_IntActor_CreepyTree_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Range",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("207991fd-2155-4942-9225-2d00a00dad89"), "PROM_P_IntActor_Range_C1_Look" },
                                    { new Guid("3ffd0977-198c-4129-a080-529dbfd1a3bf"), "PROM_P_IntActor_Range_C2_SetupRange" },
                                    { new Guid("955a6ab6-f5c9-427b-8dae-de7b8752f3e9"), "PROM_P_IntActor_Range_C3_SetupRange" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_LadderGoUp",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("eda6cb4d-5b28-41dd-bf19-89402ba6b5fc"), "PROM_P_IntActor_LadderGoUp_C1_Look" },
                                    { new Guid("a200dc1a-8c16-43a7-b3b0-4e75a341a20f"), "PROM_P_IntActor_LadderGoUp_C2_Goup" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_TreeCarving",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cb82ed56-ed96-42c4-883e-3d1ec7025cbc"), "PROM_P_IntActor_TreeCarving_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SkyPirate",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d61dd8cc-acf2-44a7-ad53-ceaecdccf7cc"), "PROM_P_IntActor_SkyPirate_C1_Look" },
                                    { new Guid("a786132e-0a68-4e75-b44c-2a984550132b"), "PROM_P_IntActor_SkyPirate_C2_Look" },
                                    { new Guid("916c4102-311d-411a-8ca3-eb4c4f37852d"), "PROM_P_IntActor_SkyPirate_C3_Check" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SecretStash",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("66a70b0a-903a-41e5-abee-cb1591e653d8"), "PROM_P_IntActor_SecretStash_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("183adefe-08b5-417e-b23f-bd5ee84eddd1"), "PROM_P_IntActor_SecretStash_C0_Open" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SchoolLetters",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("df4f1f5d-83c9-48b7-95e0-d4bd9dbef257"), "PROM_P_IntActor_SchoolLetters_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Ashtray",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b7b622e9-5ac2-4c7e-a3b3-13e540e0d14d"), "PROM_P_IntActor_Ashtray_C1_Look" },
                                    { new Guid("a8f9e40e-c095-42f4-a05d-74919de5bdf4"), "PROM_P_IntActor_Ashtray_C2_LightCigarette" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Shovel",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ed2ed7a2-eda2-45d1-a246-f25a9635c26d"), "PROM_P_IntActor_Shovel_C1_ClearSnow" },
                                    { new Guid("f60bd83f-6f93-471a-913b-3cfae1f1b1bc"), "PROM_P_IntActor_Shovel_C2_Look" },
                                    { new Guid("785933ca-a0b8-4c6a-8085-81412ac39996"), "PROM_P_IntActor_Shovel_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GarageMainDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a20d6a4e-ac59-4391-920d-70c511fc6987"), "PROM_P_IntActor_GarageMainDoor_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("40c28473-ee97-480a-9209-4d251e533972"), "PROM_P_IntActor_GarageMainDoor_C0_Open" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Mailbox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6d4939c1-777e-440f-ae1d-a8c95034c542"), "PROM_P_IntActor_Mailbox_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BaseBallCard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("44a0dfa6-4649-4eea-a853-d023a4df024d"), "PROM_P_IntActor_BaseBallCard_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WallHole",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("09639b74-ae1c-44cd-8fd6-9155fe3dc945"), "PROM_P_IntActor_WallHole_C1_Look" },
                                    { new Guid("181d9051-715b-4992-8dfb-0d664498bc1b"), "PROM_P_IntActor_WallHole_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Range2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8d5c98ab-2c25-4d79-84a3-fa9ec84b57d7"), "PROM_P_IntActor_Range2_C1_Look" },
                                    { new Guid("6c3abd58-d7ae-4889-a4a6-3325e308aea8"), "PROM_P_IntActor_Range2_C2_Pulverize" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GrandParentsLetterGarage",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6248b9c0-3daa-4239-99b8-c55866917707"), "PROM_P_IntActor_GrandParentsLetterGarage_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SprayPaint",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e06ccc70-aa0b-4245-a552-462be08384fe"), "PROM_P_IntActor_SprayPaint_C1_Look" },
                                    { new Guid("2ddf6d4c-7bed-42a5-916f-cdf2d6bbf12a"), "PROM_P_IntActor_SprayPaint_C2_Look" },
                                    { new Guid("d088a846-a0f7-46e3-8c5b-28f73eb1c773"), "PROM_P_IntActor_SprayPaint_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b78d05a9-3335-481a-8956-e210469b20cc"), "PROM_P_IntActor_SprayPaint_C0_Use" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_HikingBoots",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("90dab23d-ffb9-4421-8261-4c7d07b221d6"), "PROM_P_IntActor_HikingBoots_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BrokenSwing",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ff16c846-ff99-4aea-9d1c-e3a430eac1ce"), "PROM_P_IntActor_BrokenSwing_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GraffitiHouse",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ed6722a6-b472-43e9-b702-a5677238051e"), "PROM_P_IntActor_GraffitiHouse_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Locker",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a98a6526-ea20-4313-94ab-5ccccdd524b6"), "PROM_P_IntActor_Locker_C1_Open" },
                                    { new Guid("4673cb7f-002d-4dfe-ac01-b41158bd335e"), "PROM_P_IntActor_Locker_C2_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GarageLightSwitch",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c281c239-f77a-4d79-bbf6-407717352256"), "PROM_P_IntActor_GarageLightSwitch_C1_TurnOn" },
                                    { new Guid("23648ecd-de36-4f91-a35e-340ae2878288"), "PROM_P_IntActor_GarageLightSwitch_C2_TurnOff" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BinderGarage",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0c923b29-61ff-4984-a871-c2f9cdd40ce4"), "PROM_P_IntActor_BinderGarage_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Binder",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("24a729e4-8948-49d6-b4c8-9ed10754a0f6"), "PROM_P_IntActor_Binder_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BoxGarage",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a8cae138-f5ec-4d46-bd4d-7a85cf43aac2"), "PROM_P_IntActor_BoxGarage_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Doll",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("94a53cad-fc5f-46a8-85e5-722f5a7bea4d"), "PROM_P_IntActor_Doll_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Noctared",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("86131627-6098-40c6-8a89-f261ea36ab56"), "PROM_P_IntActor_Noctared_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ComicStripTreeHouse",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6a78c863-56ec-4e16-98ac-e4b7bcc0f978"), "PROM_P_IntActor_ComicStripTreeHouse_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BeerCardboard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("254f05bc-7313-44e5-a3ce-1d276a499514"), "PROM_P_IntActor_BeerCardboard_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e0bf9028-af7c-403d-88c8-cf81b611c689"), "PROM_P_IntActor_BeerCardboard_C0_Wear" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Lookout2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("85936598-aee3-4671-9c9b-e9229cffe59d"), "PROM_P_IntActor_Lookout2_C1_SitALT" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ReynoldsHouse",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cde0caa0-19a8-424c-b60a-78f199bee345"), "PROM_P_IntActor_ReynoldsHouse_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Raccoon",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "PROM_P_IntActor_Raccoon_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHOutside_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_EHOutside_GarageDoor",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_Global_MusicMix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_Global_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_Ground_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_PlanetGround_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_GarageInside_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_EHInside_LD",
                    Interactions = new List<InteractionActor>()
                    {
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_DirtyClothes",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c671b3e4-3910-46e5-af91-583a0456bac1"), "PROM_P_IntActor_DirtyClothes_C1_Look" },
                                    { new Guid("587a0d90-a921-4ab1-aa49-8055be464699"), "PROM_P_IntActor_DirtyClothes_C2_Addtotub" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesBed",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fd0f930d-0949-40cb-a51c-962c62052cbc"), "PROM_P_IntActor_CharlesBed_C1_Look" },
                                    { new Guid("086cc518-7f63-46aa-a52c-d1516a9d8fa5"), "PROM_P_IntActor_CharlesBed_C2_Liedown" },
                                    { new Guid("c76e71a5-d988-4f0b-9df1-5a22494f00bb"), "PROM_P_IntActor_CharlesBed_C3_Liedown" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Dishes",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f768dd22-c977-4c6b-8f52-82d4c5fdbdd7"), "PROM_P_IntActor_Dishes_C1_Look" },
                                    { new Guid("5ce51f66-92c2-402d-9409-ef52ee9493a9"), "PROM_P_IntActor_Dishes_C2_Wash" },
                                    { new Guid("69a5f45d-52ec-4a82-a8ef-56cdd0945b74"), "PROM_P_IntActor_Dishes_C3_Look" },
                                    { new Guid("bacefc8c-2613-4219-afb7-84c22181f169"), "PROM_P_IntActor_Dishes_C4_Wash" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1c63323b-dab6-4fd6-840b-6db90202917c"), "PROM_P_IntActor_Dishes_C0_MegaWash" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_MicroWave",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e1911246-461b-4f80-82ac-d6525a138ec1"), "PROM_P_IntActor_MicroWave_C1_Look" },
                                    { new Guid("b47cacfb-bd63-4b1a-a00c-607b5301fdf4"), "PROM_P_IntActor_MicroWave_C2_Givetodad" },
                                    { new Guid("c584dcab-df67-4344-896b-5253ae5ce8ec"), "PROM_P_IntActor_MicroWave_C3_Look" },
                                    { new Guid("d3fa8ca0-0b55-42ce-9686-f8a16e01f6a7"), "PROM_P_IntActor_MicroWave_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e9fb7292-3c9a-4efb-bd28-8d3abc29e772"), "PROM_P_IntActor_MicroWave_C0_Irradiate" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_MacCheese",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cc4db36a-036b-408b-9102-9922e040ef90"), "PROM_P_IntActor_MacCheese_C1_Cook" },
                                    { new Guid("280820ca-c9e8-483b-b704-930c27891bb3"), "PROM_P_IntActor_MacCheese_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_RecycleBin",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e8c80d03-cf17-422e-84fd-bba5386464d8"), "PROM_P_IntActor_RecycleBin_C1_Look" },
                                    { new Guid("ac8b2982-89d6-4fb1-bf75-0821624eb2bf"), "PROM_P_IntActor_RecycleBin_C2_Look" },
                                    { new Guid("4a854b9f-1cc7-45dc-9612-debcc473e1ca"), "PROM_P_IntActor_RecycleBin_C3_TakeOut" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_MainDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b92544b9-1cff-4a25-af96-67590fb8afe0"), "PROM_P_IntActor_MainDoor_C1_GetOut" },
                                    { new Guid("524a6abb-dafa-45b6-b281-291a2313c4ae"), "PROM_P_IntActor_MainDoor_C2_GetOut" },
                                    { new Guid("a52e1ab7-746d-4f43-b892-e317bafb40f5"), "PROM_P_IntActor_MainDoor_C3_Getin" },
                                    { new Guid("db5751fd-99f4-43ac-ab0d-195f03f08a39"), "PROM_P_IntActor_MainDoor_C4_Getin" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesRoomDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1ab13313-f448-4650-96d7-6f47e65dced2"), "PROM_P_IntActor_CharlesRoomDoor_C1_Enter" },
                                    { new Guid("6e6bf78c-a5e0-49bb-98ed-78127b2f6ec2"), "PROM_P_IntActor_CharlesRoomDoor_C2_Leave" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Cloak",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("dde953ae-d755-460c-a43f-0fee465249ca"), "PROM_P_IntActor_Cloak_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c6e50757-c873-436b-b7f2-464c99915818"), "PROM_P_IntActor_Cloak_C0_Wear" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ChrisRoomDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4ff90ab4-866c-48f9-9a17-cbfa32c68748"), "PROM_P_IntActor_ChrisRoomDoor_C1_Open" },
                                    { new Guid("943af934-157b-43d5-99ff-db79dd247079"), "PROM_P_IntActor_ChrisRoomDoor_C2_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SecretMap_2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("11850bc4-8c95-4776-ad16-af479b4d7e9f"), "PROM_P_IntActor_2_C1_Look" },
                                    { new Guid("d547857f-a7ac-4dd1-855e-942f127a585a"), "PROM_P_IntActor_2_C2_Look" },
                                    { new Guid("02a8a80f-d3fe-491a-b179-9c1c335e3098"), "PROM_P_IntActor_2_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("be4fd82a-687d-42ac-a451-506521be7bcf"), "PROM_P_IntActor_2_C0_Decypher" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Drawing_1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f59920dc-8c8c-4b4d-8db8-ca33fe20aa61"), "PROM_P_IntActor_1_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_KeyBowl",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("dd8a6b11-980c-423f-a243-0f309155a54c"), "PROM_P_IntActor_KeyBowl_C1_Put" },
                                    { new Guid("e16de051-4d99-4f25-bb62-ce213baeead0"), "PROM_P_IntActor_KeyBowl_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_LandlinePhone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("17f08a92-271f-4714-b7ab-d5a4892f37b7"), "PROM_P_IntActor_LandlinePhone_C1_Answer" },
                                    { new Guid("fcb4150a-6ab5-4cea-82fc-727c400de7b1"), "PROM_P_IntActor_LandlinePhone_C2_Use" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Turntable",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("61211273-e01f-4bd0-b158-0b506547f39f"), "PROM_P_IntActor_Turntable_C1_Look" },
                                    { new Guid("4abb4250-9f60-412a-91e1-d443646ddf14"), "PROM_P_IntActor_Turntable_C2_Play" },
                                    { new Guid("f73428e9-8edc-436a-9b60-f06e2bb42779"), "PROM_P_IntActor_Turntable_C3_Stop" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Pants",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0cca7b2b-db72-4623-83de-d0b0239d7480"), "PROM_P_IntActor_Pants_C1_Look" },
                                    { new Guid("a7c9b20d-7af5-463d-9466-2ffefbc7a78b"), "PROM_P_IntActor_Pants_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_LightSwitch",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ffd0f70a-46cf-4361-9811-f7d2627fc530"), "PROM_P_IntActor_LightSwitch_C1_TurnOn" },
                                    { new Guid("416ef4f5-1876-460b-8cc6-9a1e39eb7188"), "PROM_P_IntActor_LightSwitch_C2_TurnOff" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_FamilyPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9000f2fe-a597-48fa-983f-fe9d8db57cdd"), "PROM_P_IntActor_FamilyPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BugsMotel",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5c44cd0b-f751-4017-bac9-6924bf93fdea"), "PROM_P_IntActor_BugsMotel_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Bag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f42d1cd4-1948-4151-8be2-c2d18d392088"), "PROM_P_IntActor_Bag_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_AdventCalendar",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ce4564f0-df69-49a0-8901-c55c71a3e0c9"), "PROM_P_IntActor_AdventCalendar_C1_Look" },
                                    { new Guid("40fdd3a5-5eb7-4cd6-a3e7-a89f5989c719"), "PROM_P_IntActor_AdventCalendar_C2_Eat" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SecretMapFPP",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d1c2183b-33b9-48c0-85c5-f49654d72381"), "PROM_P_IntActor_SecretMapFPP_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9603a747-1818-4765-9e6d-8fa4eb39fc33"), "PROM_P_IntActor_SecretMapFPP_C0_Take" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_FavoriteBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3ce33007-c19a-4c67-9883-40a3f87d6d88"), "PROM_P_IntActor_FavoriteBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WalkieTalkie",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4356a497-343a-487a-a19d-9614ba186d36"), "PROM_P_IntActor_WalkieTalkie_C1_Look" },
                                    { new Guid("ff33514b-d3b4-4d8a-b4a9-3b0e3f9d3c79"), "PROM_P_IntActor_WalkieTalkie_C2_Call" },
                                    { new Guid("6244aca2-cbca-474c-b0d7-2696c9326dc5"), "PROM_P_IntActor_WalkieTalkie_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Slippers",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9e3d698f-0522-483c-8e50-c8bd0f3e50c1"), "PROM_P_IntActor_Slippers_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ForestWarrior",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("995e5c3d-851a-49cb-9612-af92dbf13da9"), "PROM_P_IntActor_ForestWarrior_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WishList",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cedd8d58-e78e-4684-a7d0-f5f2efbe4a06"), "PROM_P_IntActor_WishList_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Trophy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ccc05d0f-e8fa-46e2-8a98-bd8c4694f87a"), "PROM_P_IntActor_Trophy_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ComicBookBathroom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1682b309-7917-4c51-95bd-abda6eae39bd"), "PROM_P_IntActor_ComicBookBathroom_C1_Look" },
                                    { new Guid("a31285f1-4b18-4939-8a68-a1eadccfdf4a"), "PROM_P_IntActor_ComicBookBathroom_C2_Read" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GarageKey",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a518f36c-33d5-47d3-99ea-64d91e48dca9"), "PROM_P_IntActor_GarageKey_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Mirror",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1e76b246-8b9c-4f4b-a01f-f8a7dd354076"), "PROM_P_IntActor_Mirror_C1_Interview" },
                                    { new Guid("4afaaaae-fada-43c1-b460-35ad919a6c1d"), "PROM_P_IntActor_Mirror_C2_Use" },
                                    { new Guid("2bdb56b2-be8e-457f-8859-11a844c3d5fc"), "PROM_P_IntActor_Mirror_C3_Use" },
                                    { new Guid("5b3e52c9-e64e-4ba7-a6a5-291e2ff66b24"), "PROM_P_IntActor_Mirror_C4_Use" },
                                    { new Guid("ec22e7d0-6982-4216-ba36-964ce34380c4"), "PROM_P_IntActor_Mirror_C5_Use" },
                                    { new Guid("317af5c9-7319-46b5-89df-70a4b291c4f4"), "PROM_P_IntActor_Mirror_C6_Use" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Faucet",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("55c6b3b2-7ac2-4571-ac56-c4244c59de8a"), "PROM_P_IntActor_Faucet_C1_Use" },
                                    { new Guid("66b3e217-391f-45c2-9e07-02326a708fc0"), "PROM_P_IntActor_Faucet_C2_Look" },
                                    { new Guid("727eb070-1b01-46e6-b825-cdc05decb5d4"), "PROM_P_IntActor_Faucet_C3_Use" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Submarine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9a5a5454-4c54-4d51-8de1-90aafa26253c"), "PROM_P_IntActor_Submarine_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Console",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("aeda0d36-1335-448f-9321-4a5ac8a693f5"), "PROM_P_IntActor_Console_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_HeightGauge",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("20945b00-8377-4a2a-b98c-326e938d11eb"), "PROM_P_IntActor_HeightGauge_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesRoomTopBox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("bf29def7-82fa-480e-8175-db385458f8ce"), "PROM_P_IntActor_CharlesRoomTopBox_C1_Look" },
                                    { new Guid("91b6917a-98f0-4c26-a791-11e6de185c36"), "PROM_P_IntActor_CharlesRoomTopBox_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Newspaper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("277d981b-7592-4e34-a922-6e21ba256353"), "PROM_P_IntActor_Newspaper_C1_Read" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BaseballBat",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6a183b6a-5186-4fb0-9b85-44dc3adf6376"), "PROM_P_IntActor_BaseballBat_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Lamp",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("03b67c76-c205-4d3f-b739-20910ee0a64e"), "PROM_P_IntActor_Lamp_C1_Look" },
                                    { new Guid("6e5f31c1-4905-48ea-ad6a-c7d86d9d895f"), "PROM_P_IntActor_Lamp_C2_Fix" },
                                    { new Guid("5c61c950-df1b-4b12-9c36-02522ab9a73b"), "PROM_P_IntActor_Lamp_C3_Turnon" },
                                    { new Guid("2886a3ee-e824-455c-968f-867b1802f0f1"), "PROM_P_IntActor_Lamp_C4_Turnoff" },
                                    { new Guid("5690047c-f94f-40c2-af53-4e3fbf8018db"), "PROM_P_IntActor_Lamp_C5_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_FistMark",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fdf2b60d-d3fd-4c64-a2b8-0cec6f124da5"), "PROM_P_IntActor_FistMark_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Tattoo",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("dbf2c463-90f6-462c-8800-55cb499a078a"), "PROM_P_IntActor_Tattoo_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c091ce9e-f497-47b4-ae68-4fbdbdc60420"), "PROM_P_IntActor_Tattoo_C0_Apply" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Fridge",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7a5f4d80-2bfa-4d77-bb57-641e7f6f9826"), "PROM_P_IntActor_Fridge_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_NerfGun",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1cd075f9-ff69-4ec1-8c6f-fadeefc09837"), "PROM_P_IntActor_NerfGun_C1_Look" },
                                    { new Guid("190ade1c-e8e7-4278-9d36-2da8919cf54c"), "PROM_P_IntActor_NerfGun_C2_ShootDad" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WhiskyBottle",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c4701167-5c88-4d0f-a092-3f6b6347fcb7"), "PROM_P_IntActor_WhiskyBottle_C1_Look" },
                                    { new Guid("dfc2e4a1-7101-42fd-9ed6-43654254ee92"), "PROM_P_IntActor_WhiskyBottle_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("256c68d7-1fd6-4987-952b-9312bba58869"), "PROM_P_IntActor_WhiskyBottle_C0_Evaporate" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Sofa",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6037bad4-8412-4768-a837-68e5a16027a8"), "PROM_P_IntActor_Sofa_C1_Look" },
                                    { new Guid("2194d490-bf07-41af-bcb9-f80a86ca0850"), "PROM_P_IntActor_Sofa_C2_Sit" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesTrophies",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fb957a1c-ce98-42f5-a044-5c41faba80d3"), "PROM_P_IntActor_CharlesTrophies_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_FireStove",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2b022c12-824c-48d8-8323-e0a9fe42fee1"), "PROM_P_IntActor_FireStove_C1_Look" },
                                    { new Guid("f1105087-7710-437d-b12c-3fe0c667661b"), "PROM_P_IntActor_FireStove_C2_AddLog" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("72da7c86-696d-4974-94cd-7398a8f1801f"), "PROM_P_IntActor_FireStove_C0_Burn" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BookShelfTop",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("97fcf444-21d7-48ad-97eb-7fbe32cf6468"), "PROM_P_IntActor_BookShelfTop_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_DoorDarkZone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b18f8034-3845-432b-a35c-716ed8dea046"), "PROM_P_IntActor_DoorDarkZone_C1_Look" },
                                    { new Guid("4f3e9b8d-2190-46ad-bb2c-94023589388e"), "PROM_P_IntActor_DoorDarkZone_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c7972c2f-67a4-42dc-8659-97cf49e62f8f"), "PROM_P_IntActor_DoorDarkZone_C0_Open" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WaterHeater",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f894bea4-7a2e-4995-aca9-9f9cd325f1ae"), "PROM_P_IntActor_WaterHeater_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("eea60eb3-44d4-468e-ad8e-efd4b79c82b4"), "PROM_P_IntActor_WaterHeater_C0_Tame" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ChristmasDecorations",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fd7f4f16-7059-48af-a398-4b119cdf32d2"), "PROM_P_IntActor_ChristmasDecorations_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Memo",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a93a0872-cfef-4f66-a809-a900fcdfa1c0"), "PROM_P_IntActor_Memo_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Window",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("14e034d1-6b7e-4f17-80cb-797708aa8751"), "PROM_P_IntActor_Window_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Closet",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("155e3362-c7a2-4bf4-971c-66dfc9ef45a3"), "PROM_P_IntActor_Closet_C1_Open" },
                                    { new Guid("68f3c194-8076-428f-97c0-fb95dddb7bc1"), "PROM_P_IntActor_Closet_C2_Open" },
                                    { new Guid("21666f3f-e1c1-4ac8-8b0f-f91cbedaa10b"), "PROM_P_IntActor_Closet_C3_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Weapons",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4eb04890-6efb-42e4-99ef-d63e2e6dc675"), "PROM_P_IntActor_Weapons_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesRoomDrawing",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1a008d71-efb6-4321-9f98-600a52f44182"), "PROM_P_IntActor_CharlesRoomDrawing_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Playbox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a573587b-abef-418f-a08c-0e59a8e7c027"), "PROM_P_IntActor_Playbox_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Tv",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("322b978b-1666-4485-a04d-3913fe8107e5"), "PROM_P_IntActor_Tv_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2275130c-ccca-4c5a-9234-bd87fad6fca6"), "PROM_P_IntActor_Tv_C0_SwitchOn" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_TeddyBear",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("93f5c9c9-5837-4ab0-a6a7-f24b76251c3d"), "PROM_P_IntActor_TeddyBear_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_PizzaArcadeRankings",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9a770fa1-cb97-4dd3-991b-2e57e81af739"), "PROM_P_IntActor_PizzaArcadeRankings_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WashingMachine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d536aadb-09cf-4f5d-b89f-e2beef0f6bfe"), "PROM_P_IntActor_WashingMachine_C1_Wash" },
                                    { new Guid("5999c182-dcf0-4494-afd0-36a403008656"), "PROM_P_IntActor_WashingMachine_C2_Look" },
                                    { new Guid("df14bf69-ac85-44ae-bd36-3416a027dc27"), "PROM_P_IntActor_WashingMachine_C3_AddDad'sPants" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_LoveLetter",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("63227777-054e-4308-823d-eef7be62eee0"), "PROM_P_IntActor_LoveLetter_C1_Read" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BasketBallCloset",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("317b99b5-7fcf-49ea-959e-2c41ae92c136"), "PROM_P_IntActor_BasketBallCloset_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ClosetCase",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a652e91e-3be2-4384-9482-e286ddd71744"), "PROM_P_IntActor_ClosetCase_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GlowingSticker",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a464c236-b4ef-4f1f-bfbf-6d81b0ef3456"), "PROM_P_IntActor_GlowingSticker_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ToiletSticker",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("05fee10b-5772-463d-8300-9dc4d068f64f"), "PROM_P_IntActor_ToiletSticker_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_TrainMagazine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a190a3eb-dc26-4659-aa41-e52f39fd83d1"), "PROM_P_IntActor_TrainMagazine_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Razor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9e621ebb-b5b1-4cfc-8ba2-0d1e014df4d4"), "PROM_P_IntActor_Razor_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_StatBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ac8a219e-a381-4975-b41e-4999cdc17b72"), "PROM_P_IntActor_StatBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_FriendPhoto",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("93110d37-33e3-4f62-be5e-0a4bc1996468"), "PROM_P_IntActor_FriendPhoto_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_MilkBottle",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("53d61843-ef44-44a6-a35b-118cae8c5c06"), "PROM_P_IntActor_MilkBottle_C1_Drink" },
                                    { new Guid("8ecc673b-dbdb-4900-9e88-6725e5ed9402"), "PROM_P_IntActor_MilkBottle_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GrandParentsLetter",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f4f4cc2e-6ead-4075-9ea8-84f406e0c111"), "PROM_P_IntActor_GrandParentsLetter_C1_Read" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesTeamPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3c843215-4fa9-4767-ac88-cff4aaadd799"), "PROM_P_IntActor_CharlesTeamPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Tupperware",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c0c54a1a-c47e-4057-b448-38dd9384b80c"), "PROM_P_IntActor_Tupperware_C1_Trash" },
                                    { new Guid("0fe8d09e-2a45-4b55-8293-7e373d078dfb"), "PROM_P_IntActor_Tupperware_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BoxArmyToy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("38b3bd70-860e-492c-9f05-b0067686fca6"), "PROM_P_IntActor_BoxArmyToy_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_DvdPile",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1a2edac8-b695-4d12-ab84-8db8f76e945f"), "PROM_P_IntActor_DvdPile_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ComicBooksShelf",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0607a497-22d4-4f36-ad05-87aa7ada03d0"), "PROM_P_IntActor_ComicBooksShelf_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ComicFlyer",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ef6d0205-6d42-4405-8bc8-f708e43217cb"), "PROM_P_IntActor_ComicFlyer_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_VikingBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1c2b8a6c-5d9f-4c57-8820-d429c3eaf606"), "PROM_P_IntActor_VikingBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Laptop",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ef2bd89d-f3e0-4e5d-bdcf-018f22ba103f"), "PROM_P_IntActor_Laptop_C1_Use" },
                                    { new Guid("ed0fb465-d0a0-48d9-b1c4-7a0e7f2f1f0b"), "PROM_P_IntActor_Laptop_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_PhoneCall",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ff305465-d1a8-4242-9e7c-05cbeedf5f3a"), "PROM_P_IntActor_PhoneCall_C1_CallDad" },
                                    { new Guid("f3e32c30-a4b5-4ae8-a1e5-8cfdf549f2ca"), "PROM_P_IntActor_PhoneCall_C2_CallPizzaDelivery" },
                                    { new Guid("5c0600a2-c480-43a7-8da0-4978b1feb108"), "PROM_P_IntActor_PhoneCall_C3_CallReynolds" },
                                    { new Guid("11aeefbd-4b74-4200-b42d-8b5783ef899b"), "PROM_P_IntActor_PhoneCall_C4_CallAudra" },
                                    { new Guid("841da8a1-bc82-4463-99b0-dccc8f50d897"), "PROM_P_IntActor_PhoneCall_C5_CallReynolds" },
                                    { new Guid("9d0b0200-85ca-48f9-9953-4f37da4c8e68"), "PROM_P_IntActor_PhoneCall_C6_CallAudra" },
                                    { new Guid("4ce84b8a-0a40-4792-9061-e6d8e3b0f032"), "PROM_P_IntActor_PhoneCall_C7_CallAudra" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Sofa2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("29f54cf6-c6c2-401d-8e5b-0d6cc7df7431"), "PROM_P_IntActor_Sofa2_C1_ZenSeqDad" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_MantroidTeam",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("eb88f1dc-475c-4c10-aaf8-0bbde320c686"), "PROM_P_IntActor_MantroidTeam_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_AluminiumFoil",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e1b46a53-0eb2-4de2-8fd2-974f1c7c7a63"), "PROM_P_IntActor_AluminiumFoil_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2ddd4244-1fbe-4d8a-b23c-0a33a1e7626f"), "PROM_P_IntActor_AluminiumFoil_C0_Wear" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_MakeUp",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ced5f017-af05-40cf-bb97-7ec34f60d9ae"), "PROM_P_IntActor_MakeUp_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e4c37e26-0521-440d-9ca7-1b1ac463c987"), "PROM_P_IntActor_MakeUp_C0_Apply" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SportBag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("98be4d43-11c8-4777-b477-0ffd2f17b04e"), "PROM_P_IntActor_SportBag_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("74a8920d-cca8-4230-b112-d975542405ed"), "PROM_P_IntActor_SportBag_C0_Wear" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BeaverCreekPostCard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("12e408b8-4427-4cf7-b07d-6928e8523511"), "PROM_P_IntActor_BeaverCreekPostCard_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_FirecrackerBox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c371b165-10ef-451a-92fa-97e6815ed00f"), "PROM_P_IntActor_FirecrackerBox_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_DrawingManual",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3d6f07c1-3515-4ac5-858b-c76a98d79e8a"), "PROM_P_IntActor_DrawingManual_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Perfume",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f37b0cc0-504a-40b6-b291-a7fe59d7cdd0"), "PROM_P_IntActor_Perfume_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_KitchenLockedDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fdb4b274-5081-48e8-9f94-cd16d984eaa6"), "PROM_P_IntActor_KitchenLockedDoor_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BoobMag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e74c6a3a-7f77-45c7-af39-f065e2ae9942"), "PROM_P_IntActor_BoobMag_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_GroceryList",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c45c81c2-7c7b-4b94-a058-cf9012c06174"), "PROM_P_IntActor_GroceryList_C1_Look" },
                                    { new Guid("f9378d18-a0e8-45f0-9f30-5436ff96939f"), "PROM_P_IntActor_GroceryList_C2_Addicecream" },
                                    { new Guid("6268d2b1-d0b6-463a-950e-e89435fbc4f8"), "PROM_P_IntActor_GroceryList_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WashedDishes",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2c42afee-d9de-44a8-98b7-d5bdac7308b9"), "PROM_P_IntActor_WashedDishes_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesBasketPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6ca0c81e-4511-4d14-aff4-88575f3cc288"), "PROM_P_IntActor_CharlesBasketPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BeerFridge",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("baa3b1b6-b264-488e-a0f3-b7dcdb2a3065"), "PROM_P_IntActor_BeerFridge_C1_Give" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Record",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("32c57c3e-9817-40ee-b3df-4a74c32f2033"), "PROM_P_IntActor_Record_C1_Play" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BooksLivingRoom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d4a6f0f2-9096-491b-82b7-26020eb8c5c0"), "PROM_P_IntActor_BooksLivingRoom_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_WardrobeKey",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("160b58e1-e9ac-4524-87f9-48564b8ed5c9"), "PROM_P_IntActor_WardrobeKey_C1_Look" },
                                    { new Guid("63504363-4542-4e07-94ae-b291f744a080"), "PROM_P_IntActor_WardrobeKey_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ActionFigures",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8593bd7a-2aaf-4f51-9e04-77d07770818f"), "PROM_P_IntActor_ActionFigures_C1_Look" },
                                    { new Guid("5f9716b4-663a-42bd-8083-3691e0335e3f"), "PROM_P_IntActor_ActionFigures_C2_Play" },
                                    { new Guid("c8dd3bcd-2a75-40fa-82c6-09a76f96a2bd"), "PROM_P_IntActor_ActionFigures_C3_Look" },
                                    { new Guid("b18dc26f-31c9-4a97-b081-2e0d5e707cb1"), "PROM_P_IntActor_ActionFigures_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesBed2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fe18694d-ef69-4202-aea1-5410269c9c0f"), "PROM_P_IntActor_CharlesBed2_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Carkeys",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7ec8cd95-bd1a-4b8c-b544-5d0bfb2ecf7b"), "PROM_P_IntActor_Carkeys_C1_Look" },
                                    { new Guid("bac984c4-6281-4fb1-aa54-818f06de2b04"), "PROM_P_IntActor_Carkeys_C2_Take" },
                                    { new Guid("1a7c3899-b8c5-4188-b8f3-43a2b74d254c"), "PROM_P_IntActor_Carkeys_C3_Take" },
                                    { new Guid("95bd0caf-dc2d-45c8-8f5d-2d6f72423a28"), "PROM_P_IntActor_Carkeys_C4_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Cellphone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6d27fb56-ad68-4149-b160-4a222594dbf7"), "PROM_P_IntActor_Cellphone_C1_Look" },
                                    { new Guid("a27215a3-ecd4-4553-b82b-e4b32ca65601"), "PROM_P_IntActor_Cellphone_C2_Unlock" },
                                    { new Guid("44d707d0-4319-4efb-92cc-3cb01a6c4aac"), "PROM_P_IntActor_Cellphone_C3_Play" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Cigarette",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("86ebeba9-817d-4aa1-8f11-bfa081e902be"), "PROM_P_IntActor_Cigarette_C1_Look" },
                                    { new Guid("d7656f33-b102-4a16-874d-e02638c29286"), "PROM_P_IntActor_Cigarette_C2_Look" },
                                    { new Guid("d99cbd77-33e6-4892-8341-72c3022240b9"), "PROM_P_IntActor_Cigarette_C3_Stealone" },
                                    { new Guid("072f088e-1d86-4d9a-997f-b49c8191e15b"), "PROM_P_IntActor_Cigarette_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Dinosaur",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9be11e09-8911-4888-afb9-ae6fb78da47a"), "PROM_P_IntActor_Dinosaur_C1_Look" },
                                    { new Guid("ce15ec78-4a6e-4d79-98c0-0236972267ed"), "PROM_P_IntActor_Dinosaur_C2_Play" },
                                    { new Guid("42be10cf-9317-466c-800d-3723612b0dfd"), "PROM_P_IntActor_Dinosaur_C3_Play" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_CharlesRoomChair",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c56a5213-86a6-4def-96f7-c1a856134da5"), "PROM_P_IntActor_CharlesRoomChair_C1_Move" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Charles",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7721c421-3282-4f87-8b76-f497021012a7"), "PROM_P_IntActor_Charles_C1_Wakeup" },
                                    { new Guid("6e3bf673-33e6-4deb-8804-873ab164b3a2"), "PROM_P_IntActor_Charles_C2_Speak" },
                                    { new Guid("157e656d-9e5e-4f81-9069-33778161dc64"), "PROM_P_IntActor_Charles_C3_Speak" },
                                    { new Guid("8dcc2c66-5dd4-475e-82d7-58d87deb2a5e"), "PROM_P_IntActor_Charles_C4_Look" },
                                    { new Guid("9b85e1fb-2972-4e81-be8e-c8b0daa11203"), "PROM_P_IntActor_Charles_C5_Look" },
                                    { new Guid("d4fe1f50-9d2f-468c-a5ce-4247fa35bcae"), "PROM_P_IntActor_Charles_C6_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ChrisBasketBall",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c84658a5-2fc4-4234-ac71-5af3e96d3dcd"), "PROM_P_IntActor_ChrisBasketBall_C1_Look" },
                                    { new Guid("ce40d117-04f5-4e0b-b7b5-5cb78a392fde"), "PROM_P_IntActor_ChrisBasketBall_C2_Throw" },
                                    { new Guid("657604ac-e587-4fc9-9aa0-c07b31fcd209"), "PROM_P_IntActor_ChrisBasketBall_C3_Throw" },
                                    { new Guid("ca519fe2-9230-4f14-bb94-2341543b5b9d"), "PROM_P_IntActor_ChrisBasketBall_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_SharkStinger",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("da7535b9-a34b-4ebc-971f-dc56c09398f5"), "PROM_P_IntActor_SharkStinger_C1_Look" },
                                    { new Guid("8c80772a-7179-40a0-aa32-86730d543861"), "PROM_P_IntActor_SharkStinger_C2_Play" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b48dc8e8-b28c-4196-bd75-930c7e1c6315"), "PROM_P_IntActor_SharkStinger_C0_Power" },
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_ChrisWardrobeDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0b0d6f57-abf5-4d3c-9a42-0610313bcd7d"), "PROM_P_IntActor_ChrisWardrobeDoor_C1_Open" },
                                    { new Guid("31e95f00-3b6b-42cd-bbc3-6c60d2039515"), "PROM_P_IntActor_ChrisWardrobeDoor_C2_Close" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_BeerCans",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("356b46ee-0c4d-4f0f-ab65-1c68b92cb4f5"), "PROM_P_IntActor_BeerCans_C1_Look" },
                                    { new Guid("d954edde-bffe-461c-a1cb-458907f2b87a"), "PROM_P_IntActor_BeerCans_C2_Trash" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PT_BP_LIS2InteractionActor_Note",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0abe9558-36eb-4649-b955-c1693e58003e"), "PROM_P_IntActor_Note_C1_Inspect" },
                                    { new Guid("aa4127a3-cde1-4761-8ab3-421c063c6697"), "PROM_P_IntActor_Note_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "PT_HawtDawgMan",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
        };

        public static List<LevelObject> LIS2_Levels = new List<LevelObject>()
        {
            {
                new LevelObject()
                {
                    Name = "E1_9A",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_9A_AMB",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_9A_BackgroundGR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_9A_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_9A_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_9A_LD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_9A_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "CoastCurve_T01_Fix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "CoastCurve_T02_Fix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "CoastInter_T03_Fix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "CoastStrai_T04_Fix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_LD",
                    Interactions = new List<InteractionActor>()
                    {
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Laptop",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("909a8ef3-c828-44b5-8e46-beafc101042b"), "E1_1A_LD_IntActor_Laptop_C1_CallLyla" },
                                    { new Guid("8ddbc104-a07a-4c4f-9c71-c08fa7d39bb6"), "E1_1A_LD_IntActor_Laptop_C2_Use" },
                                    { new Guid("60fd3c0a-9dac-4fb7-9dcf-6f48a213f7a4"), "E1_1A_LD_IntActor_Laptop_C3_Facebook" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanBackpack",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("47f19374-22e7-4d52-a461-c93daed5f96c"), "E1_1A_LD_IntActor_SeanBackpack_C1_Pack" },
                                    { new Guid("924a8a05-aef1-4ebb-83ae-77e8837aa7fc"), "E1_1A_LD_IntActor_SeanBackpack_C2_Look" },
                                    { new Guid("789c8c48-aa69-4fa6-80de-f444e24b1f59"), "E1_1A_LD_IntActor_SeanBackpack_C3_Look" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_SeanBackpack_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DadPaper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_DadPaper_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanBike",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7f67d3a3-d9ed-4a22-864e-dfb4b2a58678"), "E1_1A_LD_IntActor_SeanBike_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Blanket",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("871a11cc-3cb8-4c47-981b-dffbb74c859a"), "E1_1A_LD_IntActor_Blanket_C1_Look" },
                                    { new Guid("444e6f72-33fc-4322-bb5a-abe51153147c"), "E1_1A_LD_IntActor_Blanket_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Fridge",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("565ec9ee-6512-4d56-aeea-97b30e9f77cb"), "E1_1A_LD_IntActor_Fridge_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Cupboard01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7f670ea3-4011-44a7-80c5-6f28129dde00"), "E1_1A_LD_IntActor_Cupboard01_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Picture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("12b1cbfe-6f7d-4ef6-acdf-548b2f3db5a5"), "E1_1A_LD_IntActor_Picture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Skateboard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0d687e36-6538-416d-9876-51552ce6478e"), "E1_1A_LD_IntActor_Skateboard_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Trophies",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0846f853-6977-4b4d-a3cd-0ee4ced7d278"), "E1_1A_LD_IntActor_Trophies_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Dad",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1f6f9561-041f-42e5-a9b1-30c0362c3012"), "E1_1A_LD_IntActor_Dad_C1_GiveTool" },
                                    { new Guid("e7228f83-c5b8-4de0-8420-c7da4b4fdaf8"), "E1_1A_LD_IntActor_Dad_C2_GiveTool" },
                                    { new Guid("7e8958cd-c874-4a85-9346-194bc1dbf8dd"), "E1_1A_LD_IntActor_Dad_C3_GiveTool" },
                                    { new Guid("9d854e84-d8d2-48a1-b7d5-0993270ac791"), "E1_1A_LD_IntActor_Dad_C4_GiveTool" },
                                    { new Guid("06613a7a-9da8-4c13-a53b-9adc9f5579c3"), "E1_1A_LD_IntActor_Dad_C5_GiveTool" },
                                    { new Guid("9be61936-11d9-43ba-92e8-4a99f9b384c8"), "E1_1A_LD_IntActor_Dad_C6_GiveTool" },
                                    { new Guid("2ea9fe64-79c3-4b97-9db9-cadf043b4b68"), "E1_1A_LD_IntActor_Dad_C7_GiveTool" },
                                    { new Guid("77ed4531-1d14-4711-8f3a-101c1ab5185c"), "E1_1A_LD_IntActor_Dad_C8_GiveTool" },
                                    { new Guid("3b30963c-06a0-4c9a-a9be-2e270d336587"), "E1_1A_LD_IntActor_Dad_C9_GiveTool" },
                                    { new Guid("e51e4547-0b12-4f82-975b-043f713a53af"), "E1_1A_LD_IntActor_Dad_C10_GiveTool" },
                                    { new Guid("cd0352eb-3faf-44e0-8606-257a1186a4d4"), "E1_1A_LD_IntActor_Dad_C11_GiveTool" },
                                    { new Guid("67184a88-78ff-4841-933c-b908be20fede"), "E1_1A_LD_IntActor_Dad_C12_GiveTool" },
                                    { new Guid("54535686-bd7e-4208-a854-10ab72c7f0bb"), "E1_1A_LD_IntActor_Dad_C13_GiveTool" },
                                    { new Guid("83208e62-df73-4fc0-b2b9-fe805d458feb"), "E1_1A_LD_IntActor_Dad_C14_GiveTool" },
                                    { new Guid("3ad05d66-fb47-4f95-980c-e96f796517a5"), "E1_1A_LD_IntActor_Dad_C15_GiveTool" },
                                    { new Guid("a5f85c49-626e-42b6-8c0f-2a2d3df37381"), "E1_1A_LD_IntActor_Dad_C16_GiveTool" },
                                    { new Guid("d949e026-6f8e-4f7c-a9c4-69b60d1d394a"), "E1_1A_LD_IntActor_Dad_C17_GiveTool" },
                                    { new Guid("594059f9-1178-486f-90d6-4ff94ec3f0fa"), "E1_1A_LD_IntActor_Dad_C18_GiveTool" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_RightTool01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("35eb9830-8993-4b69-a658-b61a8c9a6b42"), "E1_1A_LD_IntActor_RightTool01_C1_Take" },
                                    { new Guid("5ecd3f0d-a2ea-42b1-b4cf-7acb1aca0039"), "E1_1A_LD_IntActor_RightTool01_C2_Look" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_RightTool01_C3_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WrongTool01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7fcedc2c-8770-4cad-93a8-e36883380e6b"), "E1_1A_LD_IntActor_WrongTool01_C1_Take" },
                                    { new Guid("7164e99b-8f53-41ce-8f14-3db14a6bfe2c"), "E1_1A_LD_IntActor_WrongTool01_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_GarageDrawer",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("117f6741-8cc9-47ae-be8f-7d0d9b87c15b"), "E1_1A_LD_IntActor_GarageDrawer_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Cabinet",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1d40b25f-af67-48ff-85cc-bd5775cdde37"), "E1_1A_LD_IntActor_Cabinet_C1_Practice" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Cabinet_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Ipod",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("90753ede-3f70-4a93-a1bf-9e3938e1df52"), "E1_1A_LD_IntActor_Ipod_C1_Play" },
                                    { new Guid("df386beb-4de2-4d21-aa0e-edbbc399365a"), "E1_1A_LD_IntActor_Ipod_C2_Stop" },
                                    { new Guid("019efe78-ddd3-4680-b908-38e57f8985da"), "E1_1A_LD_IntActor_Ipod_C4_Play" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Ipod_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Nightstand",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6e681db2-7259-4521-b61e-554a62413faa"), "E1_1A_LD_IntActor_Nightstand_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Lamp",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a54052e4-9f04-499c-915d-8ad882ae1ca5"), "E1_1A_LD_IntActor_Lamp_C1_SwitchOn" },
                                    { new Guid("9da4612d-b5c9-4455-90b4-bea33d7aee14"), "E1_1A_LD_IntActor_Lamp_C2_SwitchOff" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Sodas",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d3cc3989-621d-432c-9f21-325c490ddd5a"), "E1_1A_LD_IntActor_Sodas_C1_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Sodas_C2_Look" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_Sodas_C3_Switch" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Beers",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("808eaf9d-ad57-42c6-97e4-135ee6e6aa06"), "E1_1A_LD_IntActor_Beers_C1_Take" },
                                    { new Guid("4ba550e4-a60a-4d2e-a4db-1345f013e143"), "E1_1A_LD_IntActor_Beers_C3_Switch" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Beers_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Cookies",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ab089a87-27e0-46cd-bb7f-d553170d64f9"), "E1_1A_LD_IntActor_Cookies_C3_Switch" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_Cookies_C1_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Cookies_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Chips",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("777e4f5d-6692-475e-be99-07da5f13b79b"), "E1_1A_LD_IntActor_Chips_C3_Switch" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_Chips_C1_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Chips_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Couch",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("bed01253-d33c-40f6-bb43-614365e67ada"), "E1_1A_LD_IntActor_Couch_C1_Sit" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_letters",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("385fc24b-408d-4d1f-848d-a4b5b0dbe4b6"), "E1_1A_LD_IntActor_letters_C1_Reorganize" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Jar",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c644c610-df53-4cff-8058-793f87eecb5e"), "E1_1A_LD_IntActor_Jar_C2_Look" },
                                    { new Guid("8eec7b4f-4582-414d-9e0d-47800e92111c"), "E1_1A_LD_IntActor_Jar_C3_Putback($10)" },
                                    { new Guid("7aeacc66-8ccc-4cc3-804f-b03b270ec902"), "E1_1A_LD_IntActor_Jar_C4_Addmoney($10)" },
                                    { new Guid("6d6a64df-7574-473a-ad03-d75a62168fdf"), "E1_1A_LD_IntActor_Jar_C5_Takeback($10)" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_Jar_C1_Stealcoins($10)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanWindow",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("518ed164-b8ec-4b4a-b3d8-b0fa65e01f67"), "E1_1A_LD_IntActor_SeanWindow_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Playbox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Playbox_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LeftOverFood",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_LeftOverFood_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_SeanBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WrongTool07",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b325ad8d-dcb6-4998-91ad-93cdb4907edf"), "E1_1A_LD_IntActor_WrongTool07_C1_Take" },
                                    { new Guid("083272a8-eaab-403b-b97b-f742481a5ce5"), "E1_1A_LD_IntActor_WrongTool07_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WrongTool06",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cf078aac-65c7-406e-8003-9b327949035b"), "E1_1A_LD_IntActor_WrongTool06_C1_Take" },
                                    { new Guid("e9f3a6a7-6ba1-4906-a99b-9ad4661e8b7a"), "E1_1A_LD_IntActor_WrongTool06_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WrongTool05",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6497f836-a98f-4d8e-917f-791ba8bd175a"), "E1_1A_LD_IntActor_WrongTool05_C1_Take" },
                                    { new Guid("f5a11751-fdfe-4ce8-9969-fa6142ebfb4f"), "E1_1A_LD_IntActor_WrongTool05_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WrongTool03",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("be1370b2-3f2d-4e54-bc41-1e2422b8804c"), "E1_1A_LD_IntActor_WrongTool03_C1_Take" },
                                    { new Guid("158243d1-69a0-4f9e-9763-1bfa424672b9"), "E1_1A_LD_IntActor_WrongTool03_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DeskCupboard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("db862a06-f13d-47b6-98bb-b8c83f7f2d10"), "E1_1A_LD_IntActor_DeskCupboard_C1_open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Leftover",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Leftover_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Candy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("59ef075d-6a75-42d2-8468-9ac19ac5c8db"), "E1_1A_LD_IntActor_Candy_C2_Take" },
                                    { new Guid("b59d3db1-04d9-4bc4-97fa-63cc3b917618"), "E1_1A_LD_IntActor_Candy_C3_Switch" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Candy_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanCar",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_SeanCar_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ChairBean",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("47230a84-75fd-4c2b-b189-60dfcc654a25"), "E1_1A_LD_IntActor_ChairBean_C1_SitandDraw" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_MoviePoster",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2671d1fa-238b-4007-946b-f86765095e25"), "E1_1A_LD_IntActor_MoviePoster_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Saw",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Saw_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Engine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Engine_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_MusicPoster",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_MusicPoster_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ReligiousPortrait",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_ReligiousPortrait_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DadBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_DadBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_KarenBox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_KarenBox_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_XmasDecorations",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_XmasDecorations_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LaundryBasket",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_LaundryBasket_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ToothBrush",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_ToothBrush_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FramedLicence",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_FramedLicence_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_NeighborNote",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_NeighborNote_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FakePumpkin",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_FakePumpkin_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TV",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_TV_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DaanielHomework",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_DaanielHomework_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LOTRCollection",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_LOTRCollection_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DadShoes",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_DadShoes_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BaseballCap",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_BaseballCap_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DanielToy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_DanielToy_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_RetrocarsBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_RetrocarsBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Slate",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_Slate_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_EmptyChoco",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_EmptyChoco_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SecretRecipe",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_SecretRecipe_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WorkUniform",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_WorkUniform_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ArtBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_ArtBook_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_GigFlyer",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_GigFlyer_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanDrawing",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_SeanDrawing_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FriendPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_FriendPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_GaragePicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_GaragePicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LivingRoomWindow",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_LivingRoomWindow_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Fireplace",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Fireplace_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SkiEquipment",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_SkiEquipment_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FireExtiguinsher",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_FireExtiguinsher_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WallTag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_WallTag_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DadRoom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a1162a69-7865-48f8-b8c7-5370504893ae"), "E1_1A_LD_IntActor_DadRoom_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanRoom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6f6a2df5-cfcc-43af-954b-3dd27d035646"), "E1_1A_LD_IntActor_SeanRoom_C1_Enter" },
                                    { new Guid("66d4cacd-7052-4d05-ab88-75a013ac157e"), "E1_1A_LD_IntActor_SeanRoom_C2_Leave" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DanielRoom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b907e417-f3c4-4d45-b314-68586fe0af07"), "E1_1A_LD_IntActor_DanielRoom_C1_Knock" },
                                    { new Guid("7aa6a7c4-80a6-424f-92e7-1a2867bce922"), "E1_1A_LD_IntActor_DanielRoom_C2_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WeedPipe",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_WeedPipe_C1_Look" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_WeedPipe_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BirthdayGift",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_BirthdayGift_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BandPoster",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_BandPoster_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_MoviePoster_462",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_462_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Smoothie",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Smoothie_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_HeadSet",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_HeadSet_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_CornSyrup",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_CornSyrup_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FidgetSpinner",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a5becc0c-55a6-4c55-9596-c47b0a01fdb6"), "E1_1A_LD_IntActor_FidgetSpinner_C1_Play" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_GamingMagazine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_GamingMagazine_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SkateParkPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_SkateParkPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Tools",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Tools_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Postcard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_Postcard_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Receipt",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_Receipt_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LightSwitch",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d33d8477-1bd3-40c7-82c9-3c26f89fcadf"), "E1_1A_LD_IntActor_LightSwitch_C1_Turnon" },
                                    { new Guid("2d318c30-80bb-436b-9f3b-be023a9f3425"), "E1_1A_LD_IntActor_LightSwitch_C2_Turnoff" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SketchDesk",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a9978cef-b345-44d9-8d38-2f897be3f616"), "E1_1A_LD_IntActor_SketchDesk_C1_SketchLyla" },
                                    { new Guid("fda6e287-88c8-4f99-a041-6f1995b06746"), "E1_1A_LD_IntActor_SketchDesk_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Ball",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("550cb559-1a9f-4ce0-ae47-f10c8ae523f2"), "E1_1A_LD_IntActor_Ball_C1_Play" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_NightstandBook",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("bc47e9c2-f8dc-43c5-9a81-f4b343fda004"), "E1_1A_LD_IntActor_NightstandBook_C1_Move" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Condoms",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_1A_LD_IntActor_Condoms_C1_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_Condoms_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanDrawer",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3740826c-60b2-455e-967b-3cce2f106b1f"), "E1_1A_LD_IntActor_SeanDrawer_C1_Open" },
                                    { new Guid("ec399134-eff0-4442-965e-16ef53142523"), "E1_1A_LD_IntActor_SeanDrawer_C2_Close" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_OldPhone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_OldPhone_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_OldToy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_1A_LD_IntActor_OldToy_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SkiPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_1A_LD_IntActor_SkiPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LightSwitch2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d33d8477-1bd3-40c7-82c9-3c26f89fcadf"), "E1_1A_LD_IntActor_LightSwitch2_C1_Turnon" },
                                    { new Guid("2d318c30-80bb-436b-9f3b-be023a9f3425"), "E1_1A_LD_IntActor_LightSwitch2_C2_Turnoff" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_HouseDoor",
                        "GAT_BathroomDoor",
                        "GAT_SeanDoor",
                        "GAT_GarageInside",
                        "GAT_Laundry",
                        "GAT_DanielDoor",
                        "GAT_Stairs",
                        "WuiVolumeGate_1",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_Ground_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_AMB",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HExterior_Before_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HSeanRoom_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HExterior_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HKitchenLiving_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_Background_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_LD",
                    Interactions = new List<InteractionActor>()
                    {
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanBag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("adfea919-64ff-4df0-a917-8fc4fd7989cd"), "E1_2A_LD_IntActor_SeanBag_C1_Look" },
                                    { new Guid("b71b032c-948b-462e-a07c-ea8a11ce92dd"), "E1_2A_LD_IntActor_SeanBag_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Bench",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5a2971d2-783c-487e-aac6-aa4ab56aa3a4"), "E1_2A_LD_IntActor_Bench_C1_Sit" },
                                    { new Guid("2a6c0e63-1fe1-411a-a048-c5470f891388"), "E1_2A_LD_IntActor_Bench_C2_DanielHere" },
                                    { new Guid("bed01253-d33c-40f6-bb43-614365e67ada"), "E1_2A_LD_IntActor_Bench_C3_Sit" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Car",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("beb4b192-ce9f-46bc-8800-89d65fdd08dd"), "E1_2A_LD_IntActor_Car_C1_Look" },
                                    { new Guid("f56ee6a4-e87d-44d5-8650-78e6f9337460"), "E1_2A_LD_IntActor_Car_C2_Look" },
                                    { new Guid("70aaf450-9f7d-42d3-b9c6-fdac2456b726"), "E1_2A_LD_IntActor_Car_C3_Look" },
                                    { new Guid("04aa54cb-57bc-4629-9989-89d64cc478a9"), "E1_2A_LD_IntActor_Car_C4_Examine" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Firepit",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f5b50738-6676-4d9b-a220-6eb7f3d69bae"), "E1_2A_LD_IntActor_Firepit_C1_AddLogs" },
                                    { new Guid("7cf9d70d-bb2f-4f01-ae9b-afc9973872f5"), "E1_2A_LD_IntActor_Firepit_C2_Ignite" },
                                    { new Guid("62ed9b77-9bc0-405d-b941-98139f168097"), "E1_2A_LD_IntActor_Firepit_C4_BuildFire" },
                                    { new Guid("a07849f0-4d12-450c-846e-33436bb64b5a"), "E1_2A_LD_IntActor_Firepit_C5_Ignite" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Firepit_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Sign2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c9324c57-958b-4213-9e7f-75a8bb7fa29c"), "E1_2A_LD_IntActor_Sign2_C1_Look" },
                                    { new Guid("a3d47674-196c-4de0-aa98-23de86bcd81f"), "E1_2A_LD_IntActor_Sign2_C2_Discuss" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BirdNest",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ade5c9b3-7e39-4bb3-9f26-da4b6b868adc"), "E1_2A_LD_IntActor_BirdNest_C1_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Berries03",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("91a3a0db-5dc1-441d-a8d1-fb74e092a181"), "E1_2A_LD_IntActor_Berries03_C1_Eat" },
                                    { new Guid("ea8046ea-2e82-4843-a8db-3bf49d8fba92"), "E1_2A_LD_IntActor_Berries03_C3_Look" },
                                    { new Guid("4cf94889-80c6-413c-9082-0cea6d9ce28e"), "E1_2A_LD_IntActor_Berries03_C4_Look" },
                                    { new Guid("799269c4-5f31-4a42-8bed-ac882f983df4"), "E1_2A_LD_IntActor_Berries03_C2_Check" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log17",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log17_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log01_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log04",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log04_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log07",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log07_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log11",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log11_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log12",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log12_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log13",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log13_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log14",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log14_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log15",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log15_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Log16",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5ea45aa1-eb78-49f0-b7a8-0cab0ae4c40a"), "E1_2A_LD_IntActor_Log16_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Carving1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a9b61e73-b22b-4731-968a-8efbbcc6d3fd"), "E1_2A_LD_IntActor_Carving1_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Carving2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6f12fcec-7997-4e10-a825-223ef0a82d91"), "E1_2A_LD_IntActor_Carving2_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DeadAnimal",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("047989d4-f751-41ee-9cb9-baea00f12395"), "E1_2A_LD_IntActor_DeadAnimal_C1_Look" },
                                    { new Guid("164e453a-7a5a-4574-9187-8bbd387c252a"), "E1_2A_LD_IntActor_DeadAnimal_C2_Discuss" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FallenTree",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f0816680-91a5-4897-8c9b-49f7e18a209d"), "E1_2A_LD_IntActor_FallenTree_C1_Climbover" },
                                    { new Guid("b8e622ce-935c-4588-9fef-83aa91607fbf"), "E1_2A_LD_IntActor_FallenTree_C2_Climbover" },
                                    { new Guid("ee245f34-5087-46f4-9bac-1abb3e4f48d2"), "E1_2A_LD_IntActor_FallenTree_C3_Climbover" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_HygieneSign",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e331d457-1163-42c2-81e1-c838aff42dd6"), "E1_2A_LD_IntActor_HygieneSign_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Landslide",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("94e55689-c889-49c2-9b6e-77e5d99f909e"), "E1_2A_LD_IntActor_Landslide_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Ledge",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2365800d-ced1-47bf-bb36-5397834e29c9"), "E1_2A_LD_IntActor_Ledge_C1_ClimbDown" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Ledge2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("84b915a2-ad17-4db3-b8a5-bf699c1adb91"), "E1_2A_LD_IntActor_Ledge2_C1_Getup" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ZenRock",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("86e42b6b-eeee-4ca3-bf20-f2f6fe0b5044"), "E1_2A_LD_IntActor_ZenRock_C1_Sit" },
                                    { new Guid("234ffdf4-0fc4-490e-9b97-551bdbf499c9"), "E1_2A_LD_IntActor_ZenRock_C2_Sit" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailBlaze01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e1e002ff-c3a5-4d0b-aaf9-9e523eed4788"), "E1_2A_LD_IntActor_TrailBlaze01_C1_Look" },
                                    { new Guid("36cd8c22-cd4e-4c6c-a811-6af7fdea1124"), "E1_2A_LD_IntActor_TrailBlaze01_C2_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Map",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("650c219c-b59f-4128-90e6-91f2d32fae11"), "E1_2A_LD_IntActor_Map_C2_Discuss" },
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_2A_LD_IntActor_Map_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_PoI_PushTrunk",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("deb9032a-1ee7-4b39-bc3b-086503756178"), "E1_2A_LD_IntActor_PushTrunk_C1_Push" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_PushTrunk_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailDamage01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("36ae9040-6549-4e07-adce-4d603ecfb960"), "E1_2A_LD_IntActor_TrailDamage01_C2_Discuss" },
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_2A_LD_IntActor_TrailDamage01_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WelcomePaper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5255fb45-3ecc-4b3e-a9f5-51046772eb85"), "E1_2A_LD_IntActor_WelcomePaper_C2_Discuss" },
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_2A_LD_IntActor_WelcomePaper_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailDamage02",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ad49d412-9e0c-41e3-ae4c-ba6b400362c7"), "E1_2A_LD_IntActor_TrailDamage02_C2_Discuss" },
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_2A_LD_IntActor_TrailDamage02_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Mailbox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4adaba1f-3c19-4e8c-8027-f1c90e323104"), "E1_2A_LD_IntActor_Mailbox_C1_Open" },
                                    { new Guid("0f58978e-9fec-4581-bd5e-d9cd34b0d46b"), "E1_2A_LD_IntActor_Mailbox_C2_Look" },
                                    { new Guid("eebe330b-4253-406f-b18d-be40c6281c66"), "E1_2A_LD_IntActor_Mailbox_C3_Look" },
                                    { new Guid("82f9fac5-ebf1-47e1-a47e-8328f9e822ba"), "E1_2A_LD_IntActor_Mailbox_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Marks",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("654adc12-020a-4a69-93f2-b18b9b065574"), "E1_2A_LD_IntActor_Marks_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Paper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b740b5ab-8408-47b4-bca0-61d4379e6ca1"), "E1_2A_LD_IntActor_Paper_C2_Discuss" },
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_2A_LD_IntActor_Paper_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_PicNicSign",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("973c06ef-9d23-4b09-b552-f69a0e8eb251"), "E1_2A_LD_IntActor_PicNicSign_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ShelfFungusTree",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("54cb54fb-54a9-4084-bda3-ac9ccc814076"), "E1_2A_LD_IntActor_ShelfFungusTree_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Sign3",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8a9d8ba4-276e-441f-afb8-a1c4a6964ed6"), "E1_2A_LD_IntActor_Sign3_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Sign4",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c903a96f-4fcb-4bcf-9570-b71557a6f17c"), "E1_2A_LD_IntActor_Sign4_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailBlaze",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2d61314e-fc13-4386-bedb-b491e5534dd0"), "E1_2A_LD_IntActor_TrailBlaze_C1_Look" },
                                    { new Guid("efb13ed7-35cb-4f44-ace9-e0475c9586a9"), "E1_2A_LD_IntActor_TrailBlaze_C2_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailBlaze1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1c6e0fb4-5afb-4615-8df3-343dbd01cab4"), "E1_2A_LD_IntActor_TrailBlaze1_C1_Look" },
                                    { new Guid("4f6c9616-69ef-44fa-8248-8e736e253837"), "E1_2A_LD_IntActor_TrailBlaze1_C2_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailBlaze2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8b078e65-8cc7-4c36-a860-23e79544dd0d"), "E1_2A_LD_IntActor_TrailBlaze2_C1_Look" },
                                    { new Guid("6dc09f2c-45d4-43e0-85fa-44210751ab7f"), "E1_2A_LD_IntActor_TrailBlaze2_C2_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TrailBlaze3",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1c6e0fb4-5afb-4615-8df3-343dbd01cab4"), "E1_2A_LD_IntActor_TrailBlaze3_C1_Look" },
                                    { new Guid("4f6c9616-69ef-44fa-8248-8e736e253837"), "E1_2A_LD_IntActor_TrailBlaze3_C2_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WaspNest",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("75268afc-cdf8-411d-b960-59dc35f1cd2d"), "E1_2A_LD_IntActor_WaspNest_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Tag01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Tag01_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Polaroid",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Polaroid_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TagRock01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("799269c4-5f31-4a42-8bed-ac882f983df4"), "E1_2A_LD_IntActor_TagRock01_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Berries01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6ce8f73f-f873-49e6-a1c8-ed9746020380"), "E1_2A_LD_IntActor_Berries01_C1_Eat" },
                                    { new Guid("3a64b4d8-b9b4-4653-9e54-1f4a62523bff"), "E1_2A_LD_IntActor_Berries01_C2_Look" },
                                    { new Guid("5cd83ef0-c1b5-4769-ba20-373d8b933ef4"), "E1_2A_LD_IntActor_Berries01_C3_Look" },
                                    { new Guid("8dd85bdb-67ec-4960-a202-96c535a7c944"), "E1_2A_LD_IntActor_Berries01_C4_Check" },
                                    { new Guid("09beaf7d-ccb9-4be3-a8f9-9fafb1536686"), "E1_2A_LD_IntActor_Berries01_C5_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Berries02",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("08ec5eb5-776d-41a5-ac05-876753b3b380"), "E1_2A_LD_IntActor_Berries02_C1_Eat" },
                                    { new Guid("8a449f55-284c-4178-9e2d-ffcb0abdbcc5"), "E1_2A_LD_IntActor_Berries02_C2_Look" },
                                    { new Guid("d963cb80-4609-45d2-afae-67ac904ea84f"), "E1_2A_LD_IntActor_Berries02_C3_Look" },
                                    { new Guid("01be33c2-9a15-46c9-9ce7-2f6a46e52e2d"), "E1_2A_LD_IntActor_Berries02_C5_Show" },
                                    { new Guid("8dd85bdb-67ec-4960-a202-96c535a7c944"), "E1_2A_LD_IntActor_Berries02_C4_Check" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Spikes01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Spikes01_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LogStack01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8cbf9f66-58a3-4f24-ab0c-fa044fc457dc"), "E1_2A_LD_IntActor_LogStack01_C1_Check" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Ants",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Ants_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Spikes02",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Spikes02_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WeaponRacks",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_WeaponRacks_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_CatFood",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_CatFood_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BearMarks02",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("daa1459e-2eb1-4249-9b81-fbfed80847fc"), "E1_2A_LD_IntActor_BearMarks02_C1_Look" },
                                    { new Guid("e90fe598-2f5b-4fa4-9a7f-07b2b0b3d32d"), "E1_2A_LD_IntActor_BearMarks02_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TagRocks02",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_TagRocks02_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Berries04",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b5c103da-fef0-42bb-9853-54191194f090"), "E1_2A_LD_IntActor_Berries04_C5_Show" },
                                    { new Guid("6ce8f73f-f873-49e6-a1c8-ed9746020380"), "E1_2A_LD_IntActor_Berries04_C1_Eat" },
                                    { new Guid("3a64b4d8-b9b4-4653-9e54-1f4a62523bff"), "E1_2A_LD_IntActor_Berries04_C2_Look" },
                                    { new Guid("5cd83ef0-c1b5-4769-ba20-373d8b933ef4"), "E1_2A_LD_IntActor_Berries04_C3_Look" },
                                    { new Guid("8dd85bdb-67ec-4960-a202-96c535a7c944"), "E1_2A_LD_IntActor_Berries04_C4_Check" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FishingBait",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e40cf3ad-c8ee-4d0c-a77e-71d1e7914320"), "E1_2A_LD_IntActor_FishingBait_C2_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_FishingBait_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Drawing",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("efc951c1-0af0-49b3-ae83-5dcfaa953e27"), "E1_2A_LD_IntActor_Drawing_C1_SitandDraw" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SkimStone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a2ac05f9-027c-438a-a87a-c04cb386dbb1"), "E1_2A_LD_IntActor_SkimStone_C1_Skim" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_SkimStone_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Berries05",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fba227c7-aea2-4e42-b637-c3d653132bfd"), "E1_2A_LD_IntActor_Berries05_C5_Show" },
                                    { new Guid("6ce8f73f-f873-49e6-a1c8-ed9746020380"), "E1_2A_LD_IntActor_Berries05_C1_Eat" },
                                    { new Guid("3a64b4d8-b9b4-4653-9e54-1f4a62523bff"), "E1_2A_LD_IntActor_Berries05_C2_Look" },
                                    { new Guid("5cd83ef0-c1b5-4769-ba20-373d8b933ef4"), "E1_2A_LD_IntActor_Berries05_C3_Look" },
                                    { new Guid("8dd85bdb-67ec-4960-a202-96c535a7c944"), "E1_2A_LD_IntActor_Berries05_C4_Check" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Berries06",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("91a3a0db-5dc1-441d-a8d1-fb74e092a181"), "E1_2A_LD_IntActor_Berries06_C1_Eat" },
                                    { new Guid("799269c4-5f31-4a42-8bed-ac882f983df4"), "E1_2A_LD_IntActor_Berries06_C2_Check" },
                                    { new Guid("ea8046ea-2e82-4843-a8db-3bf49d8fba92"), "E1_2A_LD_IntActor_Berries06_C3_Look" },
                                    { new Guid("4cf94889-80c6-413c-9082-0cea6d9ce28e"), "E1_2A_LD_IntActor_Berries06_C4_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SpiderWeb",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_SpiderWeb_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Chips",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Chips_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Chocobar",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Chocobar_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Lighter",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Lighter_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Wallet",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Wallet_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Toilet",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("77dc56ae-8ce5-4572-a2d6-1c1e2537ca0a"), "E1_2A_LD_IntActor_Toilet_C1_Look" },
                                    { new Guid("18e12cc6-c753-4231-b457-e9b7b1062447"), "E1_2A_LD_IntActor_Toilet_C2_Ask" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SeanPhone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("9049b809-85b9-41c1-ac05-6fa1eae7ef0b"), "E1_2A_LD_IntActor_SeanPhone_C1_Look" },
                                    { new Guid("9b03d77f-31d3-451a-b686-def8e305a6c0"), "E1_2A_LD_IntActor_SeanPhone_C2_Look" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_SeanPhone_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_FallenTree",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("dda0afce-6ba4-4a25-9964-f133ef9287ce"), "E1_2A_LD_IntActor_FallenTree_C1_Cheerup" },
                                    { new Guid("9cf80cf4-a2cf-4de4-9ec9-ebd9d7f56496"), "E1_2A_LD_IntActor_FallenTree_C2_Help" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_DropDown",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4ea2f1c4-3a4c-4fd6-b5fe-f5bd8c7d8be8"), "E1_2A_LD_IntActor_DropDown_C1_Help" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_HideAndSeek",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("adb85009-af7e-41f5-8248-f6939cd56f2c"), "E1_2A_LD_IntActor_HideAndSeek_C1_Scare" },
                                    { new Guid("3acfa58f-fa70-4ccc-a17e-06db24f6526c"), "E1_2A_LD_IntActor_HideAndSeek_C2_Scare" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_SpiderWeb",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("73b60aae-9dc9-4bbb-a3db-b573b55eb101"), "E1_2A_LD_IntActor_SpiderWeb_C2_Scare" },
                                    { new Guid("8dd85bdb-67ec-4960-a202-96c535a7c944"), "E1_2A_LD_IntActor_SpiderWeb_C1_Explain" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Raccoon",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f5d4cdba-eb55-4177-8125-ed7bb409e318"), "E1_2A_LD_IntActor_Raccoon_C1_Look" },
                                    { new Guid("ddd689dc-7058-41bc-a8d2-a3c60a7d87a0"), "E1_2A_LD_IntActor_Raccoon_C2_Show" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_DanielSkimStone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("46c1d7b1-7941-4ea3-b4b9-06eb1a143c12"), "E1_2A_LD_IntActor_DanielSkimStone_C1_Teach" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_MailboxRock",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3bd16889-f19a-4aa8-8dfe-dd14f0b01e1d"), "E1_2A_LD_IntActor_MailboxRock_C2_Look" },
                                    { new Guid("82f9fac5-ebf1-47e1-a47e-8328f9e822ba"), "E1_2A_LD_IntActor_MailboxRock_C1_BreakBox" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_SpeakGPSit",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1fc65752-35cb-4663-9e4f-3bf9ab6a396a"), "E1_2A_LD_IntActor_SpeakGPSit_C2_Gotosleep" },
                                    { new Guid("6bc5f6d2-cb1c-42a4-9b90-e758293c0646"), "E1_2A_LD_IntActor_SpeakGPSit_C3_Checkon" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_SpeakGPSit_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_Fishing",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3418edd5-ffc6-4532-aff7-bed629ef2b10"), "E1_2A_LD_IntActor_Fishing_C1_Splash" },
                                    { new Guid("f4966ac7-7ff3-4ddc-9bd7-fbb041adae97"), "E1_2A_LD_IntActor_Fishing_C2_Cheerup" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_PoutingShelter",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_PoutingShelter_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel_SwordFight",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("324d342c-902a-4dc9-94dc-0d8f0e387a3b"), "E1_2A_LD_IntActor_SwordFight_C2_Duel" },
                                    { new Guid("66a578c3-d669-4d5f-91ac-c6b09bb435e3"), "E1_2A_LD_IntActor_SwordFight_C3_Play" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_SwordFight_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BeerCan",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_BeerCan_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SodaCan",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_SodaCan_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Cookies",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_2A_LD_IntActor_Cookies_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                    },
                    PointsOfInterest = new string[]
                    {
                        "BP_PointOfInterest_SecondaryPathDiscovered",
                        "BP_PointOfInterest_DiscoverShelter",
                        "BP_PointOfInterest_HideAndSeek",
                        "BP_PointOfInterest_Raccoon",
                        "BP_PointOfInterest_TrailEntrance",
                        "BP_PointOfInterest_BirdNest",
                        "BP_PointOfInterest_Car",
                        "BP_PointOfInterest_WildLifeSign",
                        "BP_PointOfInterest_Cliff",
                        "BP_PointOfInterest_NoCampingSign",
                        "BP_PointOfInterest_BuildFort_WeaponRacks",
                        "BP_PointOfInterest_TrailBlaze03",
                        "BP_PointOfInterest_TrailBlaze04",
                        "BP_PointOfInterest_TrailBlaze01",
                        "BP_PointOfInterest_Berries02_ShowDaniel",
                        "BP_PointOfInterest_Berries01_ShowDaniel",
                        "BP_PointOfInterest_DanielPouting",
                        "BP_PointOfInterest_BuildFort_PushTrunk",
                        "BP_PointOfInterest_BuildFort_LookAround5",
                        "BP_PointOfInterest_HelpFire_DumpWood",
                        "BP_PointOfInterest_Picnic_Vault07",
                        "BP_PointOfInterest_Picnic_Vault11",
                        "BP_PointOfInterest_FallenTree",
                        "BP_PointOfInterest_Berries02_Tasted",
                        "BP_PointOfInterest_Berries02_DanielFound",
                        "BP_PointOfInterest_Berries01_Tasted",
                        "BP_PointOfInterest_Berries01_DanielFound",
                        "BP_PointOfInterest_Berries03_DanielFound",
                        "BP_PointOfInterest_Berries04_ShowDaniel",
                        "BP_PointOfInterest_Berries04_DanielFound",
                        "BP_PointOfInterest_Berries04_Tasted",
                        "BP_PointOfInterest_BreakWoodenStick01",
                        "BP_PointOfInterest_BreakWoodenStick03",
                        "BP_PointOfInterest_BreakWoodenStick04",
                        "BP_PointOfInterest_BreakWoodenStick05",
                        "BP_PointOfInterest_WoodenStick",
                        "BP_PointOfInterest_WoodenStick2",
                        "BP_PointOfInterest_WoodenStick3",
                        "BP_PointOfInterest_WoodenStick4",
                        "BP_PointOfInterest_BuildFort_TakeWood01",
                        "BP_PointOfInterest_BuildFort_TakeWood02",
                        "BP_PointOfInterest_BuildFort_LookAround3",
                        "BP_PointOfInterest_BuildFort_TakeWood03",
                        "BP_PointOfInterest_BuildFort_Pikes",
                        "BP_PointOfInterest_HelpFire_TakeWood02_01",
                        "BP_PointOfInterest_HelpFire_TakeWood02_02",
                        "BP_PointOfInterest_HelpFire_TakeWood02_03",
                        "BP_PointOfInterest_SmallDropDown02",
                        "BP_PointOfInterest_HelpFire_TakeWood03_01",
                        "BP_PointOfInterest_HelpFire_TakeWood03_02",
                        "BP_PointOfInterest_HelpFire_TakeWood03_04",
                        "BP_PointOfInterest_SpiderWeb",
                        "BP_PointOfInterest_HelpFire_TakeWood03_03",
                        "BP_PointOfInterest_Landslide",
                        "BP_PointOfInterest_SkimStone",
                        "BP_PointOfInterest_Fishing",
                        "BP_PointOfInterest_ClimbDown",
                        "BP_PointOfInterest_Ants",
                        "BP_PointOfInterest_BearMarkings",
                        "BP_PointOfInterest_DeadAnimal",
                        "BP_PointOfInterest_FeeTube",
                        "BP_PointOfInterest_HiddenVista",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot01_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot03_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot04_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot05_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot06_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot06_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot06_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot06_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot06_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot06_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot07_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot08_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI01",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI02",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI03",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI04",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI05",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI06",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI07",
                        "BP_PointOfInterest_HideAndSeek_Spot09_PoI08",
                        "BP_PointOfInterest_HideAndSeek_Spot10_PoI07",
                        "BP_PointOfInterest_Lean01",
                        "BP_PointOfInterest_Lean02",
                        "BP_PointOfInterest_Lean04",
                        "BP_PointOfInterest_Lean05",
                        "BP_PointOfInterest_LookAround01",
                        "BP_PointOfInterest_LookFungus",
                        "BP_PointOfInterest_LookingForCar",
                        "BP_PointOfInterest_LookOver01",
                        "BP_PointOfInterest_LookOver02",
                        "BP_PointOfInterest_LookOver03",
                        "BP_PointOfInterest_LookOver05",
                        "BP_PointOfInterest_LookOver06",
                        "BP_PointOfInterest_MainTrail_Vault01",
                        "BP_PointOfInterest_MainTrail_Vault02",
                        "BP_PointOfInterest_Parking_Vault01",
                        "BP_PointOfInterest_Parking_Vault02",
                        "BP_PointOfInterest_Parking_Vault03",
                        "BP_PointOfInterest_Parking_Vault04",
                        "BP_PointOfInterest_Picnic_Vault01",
                        "BP_PointOfInterest_Picnic_Vault02",
                        "BP_PointOfInterest_Picnic_Vault03",
                        "BP_PointOfInterest_Picnic_Vault05",
                        "BP_PointOfInterest_Picnic_Vault06",
                        "BP_PointOfInterest_Picnic_Vault08",
                        "BP_PointOfInterest_Picnic_Vault09",
                        "BP_PointOfInterest_Picnic_Vault10",
                        "BP_PointOfInterest_PicnicSign",
                        "BP_PointOfInterest_ReadTableCarving01",
                        "BP_PointOfInterest_ReadTableCarving02",
                        "BP_PointOfInterest_SecPath_Vault01",
                        "BP_PointOfInterest_SecPath_Vault02",
                        "BP_PointOfInterest_Shelter_Vault01",
                        "BP_PointOfInterest_Shelter_Vault02",
                        "BP_PointOfInterest_Shelter_Vault03",
                        "BP_PointOfInterest_Shelter_Vault04",
                        "BP_PointOfInterest_Shelter_Vault05",
                        "BP_PointOfInterest_Shelter_Vault06",
                        "BP_PointOfInterest_Shelter_Vault07",
                        "BP_PointOfInterest_Shelter_Vault08",
                        "BP_PointOfInterest_Shelter_Vault09",
                        "BP_PointOfInterest_Shelter_Vault10",
                        "BP_PointOfInterest_Shelter_Vault13",
                        "BP_PointOfInterest_Shelter_Vault14",
                        "BP_PointOfInterest_SitStump01",
                        "BP_PointOfInterest_SitStump02",
                        "BP_PointOfInterest_SitTable",
                        "BP_PointOfInterest_SmallDropDown01",
                        "BP_PointOfInterest_TrailBlaze02",
                        "BP_PointOfInterest_TreeCarving",
                        "BP_PointOfInterest_TreeFungus",
                        "BP_PointOfInterest_WaterStream",
                        "BP_PointOfInterest_SwordFight",
                        "BP_PointOfInterest_Berries01_FoundKnownSpot",
                        "BP_PointOfInterest_Berries02_FoundKnownSpot",
                        "BP_PointOfInterest_Berries04_FoundKnownSpot",
                        "BP_PointOfInterest_Berries05_ShowDaniel",
                        "BP_PointOfInterest_Berries05_Tasted",
                        "BP_PointOfInterest_Berries05_DanielFound",
                        "BP_PointOfInterest_Berries05_FoundKnownSpot",
                        "BP_PointOfInterest_Berries06_DanielFound",
                        "BP_PointOfInterest_Berries06_FoundKnownSpot",
                        "BP_PointOfInterest_Berries03_FoundKnownSpot",
                        "BP_PointOfInterest_Picnic_Vault12",
                        "BP_PointOfInterest_Fishing_Forti",
                        "BP_PointOfInterest_Lean5",
                        "BP_PointOfInterest_SitDown01",
                        "BP_PointOfInterest_leanCar01",
                        "BP_PointOfInterest_SitTrunk_16",
                        "BP_PointOfInterest_LeanTree01",
                        "BP_PointOfInterest_LookAtSignRoad",
                        "BP_PointOfInterest_Creepy01",
                        "BP_PointOfInterest_SitRock01",
                        "BP_PointOfInterest_Shelter_Sit01",
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_RoadToPicnic",
                        "GAT_DeepToShelter",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_NAV",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Insertion_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Insertion_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_AMB_NOON",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_BackgroundGR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_GS_ToiletDoor",
                        "GAT_GS_ShopDoor",
                        "GAT_GS_DeskDoor",
                        "GAT_GS_AirVent",
                        "GAT_GS_OfficeDoor",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_LD",
                    Interactions = new List<InteractionActor>()
                    {
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_GrabMachine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_GrabMachine_C1_Look" },
                                    { new Guid("a3aea13e-80c4-4930-b513-ec2b2c7f257f"), "E1_5A_LD_IntActor_GrabMachine_C2_Play($1)" },
                                    { new Guid("fd87a1c5-e1bc-44a5-9dae-1ac796d5079f"), "E1_5A_LD_IntActor_GrabMachine_C3_Play($1)" },
                                    { new Guid("94c3c83d-406f-45ad-89e8-07a6c3f9deaa"), "E1_5A_LD_IntActor_GrabMachine_C4_LetDanielplay($1)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_TShirt",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6d27312d-4113-4d26-8b7c-6e8db0f66b7a"), "E1_5A_LD_IntActor_TShirt_C1_Addtobasket($11.90)" },
                                    { new Guid("a5233cf0-577a-4c5f-b280-96870e216aec"), "E1_5A_LD_IntActor_TShirt_C2_Steal" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_TShirt_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_RegionMap",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a948de41-03ac-4703-ad3e-ce46a0970830"), "E1_5A_LD_IntActor_RegionMap_C1_Take" },
                                    { new Guid("59dbb4eb-ddc4-4ce3-83f2-4cfe15eb4baa"), "E1_5A_LD_IntActor_RegionMap_C3_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_RegionMap_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_PicnicTable",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("70b47b90-7cbc-4daa-9e9b-83f045788e0d"), "E1_5A_LD_IntActor_PicnicTable_C1_Look" },
                                    { new Guid("f5b83bf3-c169-409e-86bc-f62ea32e6c83"), "E1_5A_LD_IntActor_PicnicTable_C2_Eat" },
                                    { new Guid("4d2f9932-f2a2-4c09-a1e6-fbb84ad0a073"), "E1_5A_LD_IntActor_PicnicTable_C3_LocalMap" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_PipeAnchor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f6340ccd-cf26-4a93-b7e3-638a23e1e81b"), "E1_5A_LD_IntActor_PipeAnchor_C1_Tear" },
                                    { new Guid("622abb23-7aec-4e74-b965-f07acb1e44db"), "E1_5A_LD_IntActor_PipeAnchor_C2_Look" },
                                    { new Guid("ead22eaa-e6b0-4495-a887-08e2494acda8"), "E1_5A_LD_IntActor_PipeAnchor_C3_Tear" },
                                    { new Guid("dfbc0745-5454-47ec-92f4-7a78357b289c"), "E1_5A_LD_IntActor_PipeAnchor_C4_Tear" },
                                    { new Guid("5cd06799-8aae-40bd-b5ac-37003363e69d"), "E1_5A_LD_IntActor_PipeAnchor_C5_Askfortool" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_FrontDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cdac0fc4-8df8-4ed6-84b4-9457fb3483c1"), "E1_5A_LD_IntActor_FrontDoor_C1_Goin" },
                                    { new Guid("e7e9630f-560a-4b6d-bddb-3b4f20e9c1ca"), "E1_5A_LD_IntActor_FrontDoor_C2_Goin" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_FrontDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f86767e6-ad9e-4ba8-9774-f9d79cff4e60"), "E1_5A_LD_IntActor_FrontDoor_C1_Getout" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_Chair",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("799269c4-5f31-4a42-8bed-ac882f983df4"), "E1_5A_LD_IntActor_Chair_C1_Reach" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_GivePuppyPoster",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f81442f0-5a3e-4616-81dd-90788aaeb33d"), "E1_5A_LD_IntActor_GivePuppyPoster_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_IceContainer",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("eacdb5f0-09d6-4a8b-a8d9-cc288e5daaa1"), "E1_5A_LD_IntActor_IceContainer_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_WaterBottle",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cc76de69-e649-40ee-bd35-30b2f73c316e"), "E1_5A_LD_IntActor_WaterBottle_C1_Look" },
                                    { new Guid("1ead3cbd-e19b-4f8d-a01f-2ff889d390b6"), "E1_5A_LD_IntActor_WaterBottle_C2_Addtobasket($4.50)" },
                                    { new Guid("390e7389-b6d8-44c5-8ca1-10115ae9e137"), "E1_5A_LD_IntActor_WaterBottle_C3_Steal" },
                                    { new Guid("714142bd-bf82-4a3d-8098-c924a67b586b"), "E1_5A_LD_IntActor_WaterBottle_C4_Asktodistractshopkeeper" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_HotDogMachine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b833c6c3-c27b-446f-997c-7de79872b238"), "E1_5A_LD_IntActor_HotDogMachine_C1_Look" },
                                    { new Guid("2d406e16-7480-4932-a551-435544b4df40"), "E1_5A_LD_IntActor_HotDogMachine_C2_Make2hotdogs($6)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_SleepingBag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("736eb62e-7f23-4575-b142-c946fb99b76f"), "E1_5A_LD_IntActor_SleepingBag_C1_Addtobasket($16)" },
                                    { new Guid("343f9622-c28a-4bc7-9c4f-113e3ccf8986"), "E1_5A_LD_IntActor_SleepingBag_C2_Steal" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_SleepingBag_C3_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_ToiletDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("099be3e5-2cbc-43d5-b051-3d3bc651c647"), "E1_5A_LD_IntActor_ToiletDoor_C1_Look" },
                                    { new Guid("acdd70ee-8803-49ce-b937-141f851d8458"), "E1_5A_LD_IntActor_ToiletDoor_C2_Open" },
                                    { new Guid("fcbb86a5-7cb1-43bb-8ba3-36714f183edd"), "E1_5A_LD_IntActor_ToiletDoor_C3_Entertogether" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_ToiletSink",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("16931b60-903c-420d-983b-312d5dd08eb1"), "E1_5A_LD_IntActor_ToiletSink_C1_Fillbottle" },
                                    { new Guid("799269c4-5f31-4a42-8bed-ac882f983df4"), "E1_5A_LD_IntActor_ToiletSink_C2_Cleanup" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_GSTL01_InspectorPay",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("32f2565b-77ac-4881-a59d-b70d36106238"), "E1_5A_LD_IntActor_InspectorPay_C1_Pay" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_ToiletDoorGetout",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("ad4c4e7a-c012-4eb3-b14c-d3798353af77"), "E1_5A_LD_IntActor_ToiletDoorGetout_C1_Leave" },
                                    { new Guid("d09a038b-29d7-4424-8ebd-ea741fa653c5"), "E1_5A_LD_IntActor_ToiletDoorGetout_C2_Leave" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_InspectorToolDesk",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6813d359-d5a5-4e24-93e9-f38912e237a8"), "E1_5A_LD_IntActor_InspectorToolDesk_C1_Inspect" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_SlicedBread",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("68b20af3-afd6-4072-b54c-0dc2450ec362"), "E1_5A_LD_IntActor_SlicedBread_C1_Look" },
                                    { new Guid("dd17c6d3-5a6c-4f4a-943d-6d5df4618235"), "E1_5A_LD_IntActor_SlicedBread_C2_Addtobasket($5.90)" },
                                    { new Guid("0e69e7ba-293e-4a7a-9234-f727120f8d56"), "E1_5A_LD_IntActor_SlicedBread_C3_Steal" },
                                    { new Guid("2383c4af-e36e-45fb-8b66-1d1e7bfd6f38"), "E1_5A_LD_IntActor_SlicedBread_C4_Asktodistractshopkeeper" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_Can",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("910774ec-fda4-4704-b5be-1e6dacd1d254"), "E1_5A_LD_IntActor_Can_C1_Look" },
                                    { new Guid("32175e1b-d33e-4c8a-9601-1528c9ae860c"), "E1_5A_LD_IntActor_Can_C2_Addtobasket($4.50)" },
                                    { new Guid("945de9f5-cb3e-4495-b4c2-38bb77622520"), "E1_5A_LD_IntActor_Can_C3_Steal" },
                                    { new Guid("221fff81-6329-4858-80d2-39f917e2a165"), "E1_5A_LD_IntActor_Can_C4_Asktodistractshopkeeper" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_CelebrityPhoto",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("69d46663-6148-477b-8d03-3c140b93d3b1"), "E1_5A_LD_IntActor_CelebrityPhoto_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_CampingSign",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f29ae678-c332-4e48-af8d-4268427a6f55"), "E1_5A_LD_IntActor_CampingSign_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_BackDoorKeys",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("95bb43a1-fc3f-495c-aba7-81b649eb196c"), "E1_5A_LD_IntActor_BackDoorKeys_C1_Look" },
                                    { new Guid("0b5004e3-2aa9-4219-ba23-ae3b97fd4ace"), "E1_5A_LD_IntActor_BackDoorKeys_C2_Reach" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_PosterToMove",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("851d78bb-697c-4d14-b602-4b2c2bead937"), "E1_5A_LD_IntActor_PosterToMove_C1_Look" },
                                    { new Guid("53ad480c-ed02-42c0-950d-5437e7f68a67"), "E1_5A_LD_IntActor_PosterToMove_C2_Push" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Family",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e79db5fd-2645-4a8a-8fb5-a17b8616782f"), "E1_5A_LD_IntActor_Family_C2_Speak" },
                                    { new Guid("6c1a05f2-0876-4e97-9f1b-65709899c5bb"), "E1_5A_LD_IntActor_Family_C3_SendDanieltobeg" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Family_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_HalfCarvedBear",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3ea36fb4-882a-4026-99bc-67ab633a7819"), "E1_5A_LD_IntActor_HalfCarvedBear_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Trash",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("438e2aa3-2d23-436e-bb77-5bbe02635042"), "E1_5A_LD_IntActor_Trash_C1_Look" },
                                    { new Guid("1a6bcf82-ee5d-44fc-ae21-b08cdd031b51"), "E1_5A_LD_IntActor_Trash_C2_Lookforfood" },
                                    { new Guid("f7b0018d-11dc-4c1e-b48d-5b299d4762ef"), "E1_5A_LD_IntActor_Trash_C3_Lookforfood" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_Ties",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("219d6d33-7055-4605-8c53-9cd65246eef5"), "E1_5A_LD_IntActor_Ties_C1_Break" },
                                    { new Guid("73565b54-7a95-4679-9fd8-f148fe23846b"), "E1_5A_LD_IntActor_Ties_C2_Break" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_Computer",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("39e13d52-6868-4ae0-955b-000233fd59e0"), "E1_5A_LD_IntActor_Computer_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_ExitDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8b006e7c-a44c-4de3-b5ae-39eb213e830a"), "E1_5A_LD_IntActor_ExitDoor_C2_Asktoopen" },
                                    { new Guid("39e13d52-6868-4ae0-955b-000233fd59e0"), "E1_5A_LD_IntActor_ExitDoor_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_FamilyPicture",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("39e13d52-6868-4ae0-955b-000233fd59e0"), "E1_5A_LD_IntActor_FamilyPicture_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_window",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3f6fb52a-759f-4dcf-9c7d-1d99ecf21c70"), "E1_5A_LD_IntActor_window_C2_Asktoopen" },
                                    { new Guid("39e13d52-6868-4ae0-955b-000233fd59e0"), "E1_5A_LD_IntActor_window_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_ChocoCrisp",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("89f36eec-bd53-46b8-9fe4-c1e369a53f7b"), "E1_5A_LD_IntActor_ChocoCrisp_C4_Asktodistractshopkeeper" },
                                    { new Guid("68b20af3-afd6-4072-b54c-0dc2450ec362"), "E1_5A_LD_IntActor_ChocoCrisp_C1_Look" },
                                    { new Guid("dd17c6d3-5a6c-4f4a-943d-6d5df4618235"), "E1_5A_LD_IntActor_ChocoCrisp_C2_Addtobasket($1.99)" },
                                    { new Guid("0e69e7ba-293e-4a7a-9234-f727120f8d56"), "E1_5A_LD_IntActor_ChocoCrisp_C3_Steal" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_ToiletPaperDispenser",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d4cf81d9-835b-43e6-9fdc-a1adea81fa8d"), "E1_5A_LD_IntActor_ToiletPaperDispenser_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Mirror",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d4cf81d9-835b-43e6-9fdc-a1adea81fa8d"), "E1_5A_LD_IntActor_Mirror_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_ToiletInstruction1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d4cf81d9-835b-43e6-9fdc-a1adea81fa8d"), "E1_5A_LD_IntActor_ToiletInstruction1_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_SportTeam",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0c28f7cb-df82-4148-a26f-e39ee9e71103"), "E1_5A_LD_IntActor_SportTeam_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_AirVent",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("bdc1454e-a954-413f-8470-1e3d47e6b8c0"), "E1_5A_LD_IntActor_AirVent_C1_Asktotearoff" },
                                    { new Guid("6df26c01-11ad-4e88-8e79-bc565eec53e7"), "E1_5A_LD_IntActor_AirVent_C2_AnswerDaniel" },
                                    { new Guid("633a1982-703b-4dd0-8cef-1e44316cff13"), "E1_5A_LD_IntActor_AirVent_C3_Takethetool" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_PilePaper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("15a33b08-c794-4a2e-abf5-4ea2a823c875"), "E1_5A_LD_IntActor_PilePaper_C1_Read" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_StorageDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("799269c4-5f31-4a42-8bed-ac882f983df4"), "E1_5A_LD_IntActor_StorageDoor_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_Souvenir",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8b48d214-8780-4f32-88cc-4f0cc2e55ba2"), "E1_5A_LD_IntActor_Souvenir_C1_Kick" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_HalloweenDeco1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_HalloweenDeco1_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_BigBear",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_BigBear_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_InflatablePumpkin",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_InflatablePumpkin_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Newspaper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Newspaper_C1_Read" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_PowerBear",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_PowerBear_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_KnifeDisplay",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_KnifeDisplay_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_SodaBottle",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7a15cdf1-834b-4259-80e2-185949e4fefa"), "E1_5A_LD_IntActor_SodaBottle_C2_Addtobasket($3.50)" },
                                    { new Guid("3dc6b02b-e1a6-437f-bc3b-46986622f57a"), "E1_5A_LD_IntActor_SodaBottle_C3_Steal" },
                                    { new Guid("b8f04a4e-7af1-419f-ad18-37ebf491133b"), "E1_5A_LD_IntActor_SodaBottle_C4_Asktodistractshopkeeper" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_SodaBottle_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_JunkPile",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("243f98d2-ae3a-487f-9b81-6ffb6c2a6e60"), "E1_5A_LD_IntActor_JunkPile_C1_Discuss" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Shelve",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6b3413cc-d113-421d-8b04-8fbada6ec5ee"), "E1_5A_LD_IntActor_Shelve_C2_Discuss" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Shelve_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Posters",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1f54ced6-9c63-4de7-8585-49849c39f1dc"), "E1_5A_LD_IntActor_Posters_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_SpanishLessons",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1f54ced6-9c63-4de7-8585-49849c39f1dc"), "E1_5A_LD_IntActor_SpanishLessons_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_WildAnimalsPoster",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1f54ced6-9c63-4de7-8585-49849c39f1dc"), "E1_5A_LD_IntActor_WildAnimalsPoster_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_Poster1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Poster1_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_ATM",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_ATM_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_inside_Postcard",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Postcard_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_Sweat",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1a0d668f-cd17-4eb9-bf71-3a71acb768eb"), "E1_5A_LD_IntActor_Sweat_C2_Steal" },
                                    { new Guid("a7f10ef2-7a43-4ddf-82cd-58f134d1dd3a"), "E1_5A_LD_IntActor_Sweat_C3_Addtobasket($59.99)" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Sweat_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_Tent",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d5f562df-a36c-4f47-86bc-437fbcd83080"), "E1_5A_LD_IntActor_Tent_C2_Steal" },
                                    { new Guid("c240aaf6-c035-457c-befb-96c11826908a"), "E1_5A_LD_IntActor_Tent_C3_Addtobasket($69.99)" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Tent_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_Coffee",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Coffee_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_LetterBox",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_LetterBox_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Sign",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Sign_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_KeyChain",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("51f93625-c182-45e9-8505-8255d7153936"), "E1_5A_LD_IntActor_KeyChain_C2_Show" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_KeyChain_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_TrappedBird",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("b0f4531e-5091-49aa-972c-6c7ddf30229f"), "E1_5A_LD_IntActor_TrappedBird_C2_Move" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_TrappedBird_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Bench",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fa42c6da-272b-4bea-9b91-77fe7f9ae4fc"), "E1_5A_LD_IntActor_Bench_C1_Sit" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Tube",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("35e042a1-a8f7-413c-9ef8-20ebb666a39f"), "E1_5A_LD_IntActor_Tube_C1_Push" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_inside_Witch",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Witch_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_Laptop",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Laptop_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_Door",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fbe46114-4f53-4680-a2d1-a0c65798f455"), "E1_5A_LD_IntActor_Door_C2_Asktoopen" },
                                    { new Guid("39e13d52-6868-4ae0-955b-000233fd59e0"), "E1_5A_LD_IntActor_Door_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_CampingGear",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_CampingGear_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_House",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_House_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_Bears",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Bears_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_outside_LicensePlate_314",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_314_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Birds",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Birds_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Feather",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("15fbc5db-b605-4678-b35d-c0c1a3ae8b35"), "E1_5A_LD_IntActor_Feather_C1_Pickup" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Feather_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Inside_TruckSticker",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("38c3d8a9-de71-47f2-87fe-f0c0fadb3d39"), "E1_5A_LD_IntActor_TruckSticker_C1_Take" },
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_TruckSticker_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_HotDog",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f1a6b9e2-79ef-416f-9031-ed2f648dc556"), "E1_5A_LD_IntActor_HotDog_C1_Remove($6)" },
                                    { new Guid("2817ca77-b9d9-4ec1-9781-88697e20ff21"), "E1_5A_LD_IntActor_HotDog_C2_Take($6)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_Brochures",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_Brochures_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_HalloweenPoster2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1f54ced6-9c63-4de7-8585-49849c39f1dc"), "E1_5A_LD_IntActor_HalloweenPoster2_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_BackDoorKeys_Fallen",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0b5004e3-2aa9-4219-ba23-ae3b97fd4ace"), "E1_5A_LD_IntActor_Fallen_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Office_Souvenir2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8b48d214-8780-4f32-88cc-4f0cc2e55ba2"), "E1_5A_LD_IntActor_Souvenir2_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Outside_Car_296",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c55b5b3d-1f8a-4269-bb38-9ff06568ebb4"), "E1_5A_LD_IntActor_296_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_Water",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4055cacb-a32d-441c-88d5-ccbfa54b20d4"), "E1_5A_LD_IntActor_Water_C1_Remove($4.50)" },
                                    { new Guid("a659be60-70b4-42fd-8756-405fddd16f78"), "E1_5A_LD_IntActor_Water_C2_Take($4.50)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_outside_LicensePlate",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cb060010-270a-4ed1-b743-047ba0f55d52"), "E1_5A_LD_IntActor_LicensePlate_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Toilets",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("2190f604-b08e-4a8d-83bd-67d15ca0c17c"), "E1_5A_LD_IntActor_Toilets_C1_Ask" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_Brody",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8f916856-6569-4ad8-9d90-7045bcbf5b19"), "E1_5A_LD_IntActor_Brody_C1_Look" },
                                    { new Guid("1e940a08-5a50-436f-90c9-aa23f7463048"), "E1_5A_LD_IntActor_Brody_C2_Speak" },
                                    { new Guid("7d5bdfb2-0a68-488c-9414-874182028e9a"), "E1_5A_LD_IntActor_Brody_C3_Interrupt" },
                                    { new Guid("1f21cf68-174f-4ba1-886a-9029aec085e1"), "E1_5A_LD_IntActor_Brody_C4_Speak" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_Puppy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6e2747a6-4f1d-49cd-b094-c6583a88da16"), "E1_5A_LD_IntActor_Puppy_C1_Look" },
                                    { new Guid("c6c272d5-448d-45af-98cd-3131f004e8a2"), "E1_5A_LD_IntActor_Puppy_C2_Pet" },
                                    { new Guid("a955c76b-8ee8-43c2-8363-86433a0bc201"), "E1_5A_LD_IntActor_Puppy_C3_Show" },
                                    { new Guid("79a81290-7c19-4bfe-80d2-3f3b9f3f4b3c"), "E1_5A_LD_IntActor_Puppy_C4_Discuss" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_Sweat",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0c7a1bde-5f6d-47ee-95fd-5a460db8262b"), "E1_5A_LD_IntActor_Sweat_C1_Remove($11.90)" },
                                    { new Guid("cff533d2-9d8f-449b-98e9-3b8fe1deb073"), "E1_5A_LD_IntActor_Sweat_C2_Take($11.90)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_Shop_GSTL01",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e128b7b6-218e-46a1-9ef1-17bc726994b1"), "E1_5A_LD_IntActor_GSTL01_C1_Pay" },
                                    { new Guid("62794a86-5648-4fbb-ae0f-afea10353e0a"), "E1_5A_LD_IntActor_GSTL01_C2_Look" },
                                    { new Guid("95e5d0d6-3506-479e-b2f9-49b85d5d9bf5"), "E1_5A_LD_IntActor_GSTL01_C3_Leavearticles" },
                                    { new Guid("52b10df5-dea2-4593-afd9-b5ac37c20799"), "E1_5A_LD_IntActor_GSTL01_C4_Interrupt" },
                                    { new Guid("aedd60df-2ab8-4112-8b3a-a23f32a91f0b"), "E1_5A_LD_IntActor_GSTL01_C5_Speak" },
                                    { new Guid("7ab89f29-4044-431b-9756-16fefd1f338a"), "E1_5A_LD_IntActor_GSTL01_C6_Pay" },
                                    { new Guid("3334fde0-ea50-40db-a759-dd404d4d29bb"), "E1_5A_LD_IntActor_GSTL01_C7_Asktodistract" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_Bread",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c35b4cdb-5dac-4b9b-9807-79829848365b"), "E1_5A_LD_IntActor_Bread_C1_Remove($5.90)" },
                                    { new Guid("687f2498-74cf-4954-97ad-d70cf4c2fd60"), "E1_5A_LD_IntActor_Bread_C2_Take($5.90)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_Can",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0c7a1bde-5f6d-47ee-95fd-5a460db8262b"), "E1_5A_LD_IntActor_Can_C1_Remove($4.50)" },
                                    { new Guid("cff533d2-9d8f-449b-98e9-3b8fe1deb073"), "E1_5A_LD_IntActor_Can_C2_Take($4.50)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_SleepingBag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("57475bd8-a31d-465c-81ab-199b00dbdfcc"), "E1_5A_LD_IntActor_SleepingBag_C1_Remove($16)" },
                                    { new Guid("66335cdb-8fb8-47e0-92e4-b69f716ad2aa"), "E1_5A_LD_IntActor_SleepingBag_C2_Take($16)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_Soda",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c35b4cdb-5dac-4b9b-9807-79829848365b"), "E1_5A_LD_IntActor_Soda_C1_Remove($3.50)" },
                                    { new Guid("687f2498-74cf-4954-97ad-d70cf4c2fd60"), "E1_5A_LD_IntActor_Soda_C2_Take($3.50)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_ShopPay_ChocoCrisp",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0c7a1bde-5f6d-47ee-95fd-5a460db8262b"), "E1_5A_LD_IntActor_ChocoCrisp_C1_Remove($1.99)" },
                                    { new Guid("cff533d2-9d8f-449b-98e9-3b8fe1deb073"), "E1_5A_LD_IntActor_ChocoCrisp_C2_Take($1.99)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                    },
                    PointsOfInterest = new string[]
                    {
                        "BP_PoI_Int_Kitchen",
                        "BP_PoI_Int_BababarsPoster",
                        "BP_PoI_Int_Juice",
                        "BP_PoI_Int_GrabMachine",
                        "BP_PoI_Int_CandyMachine",
                        "BP_PoI_Int_Tents",
                        "BP_PoI_out_HalloweenDeco",
                        "BP_PoI_Int_Chocobar",
                        "BP_PoI_Int_Puppy",
                        "BP_PoI_int_Brody",
                        "BP_PoI_Int_Bear",
                        "BP_PoI_Out_BigBear",
                        "BP_PoI_Out_Shelve",
                        "BP_PoI_Int_SouvenirRack",
                        "BP_PoI_Int_Tea",
                        "BP_PoI_Int_Sweater",
                        "BP_PoI_Out_Curb",
                        "BP_PoI_Out_Curb2",
                        "BP_PoI_Out_HalloweenDeco2",
                        "BP_PoI_Out_BenchFront",
                        "BP_PoI_Out_Pump1",
                        "BP_PoI_Out_Pump2",
                        "BP_PoI_Out_Pump3",
                        "BP_PoI_Out_Pump4",
                        "BP_PoI_Out_Table",
                        "BP_PoI_Out_Workbench",
                        "BP_PoI_Out_Curb3",
                        "BP_PoI_Out_BirdGroup1",
                        "BP_PoI_Int_Doris",
                        "BP_PoI_Out_BirdGroup2",
                        "BP_PoI_Out_BenchPhone",
                        "BP_PoI_Int_Witch",
                        "BP_PoI_Int_PowerBear",
                        "BP_PoI_Int_Ketchup",
                        "BP_PoI_Int_Window",
                        "BP_PoI_Int_Biscuit",
                        "BP_PoI_Out_Animals",
                        "BP_PoI_Int_PeanutButter",
                        "BP_PoI_Int_Drinks",
                        "BP_PoI_Int_Beer",
                        "BP_PoI_Int_Knifes",
                        "BP_PoI_Out_Pumpkin",
                        "BP_PoI_Out_CampingSign",
                        "BP_PoI_Out_Junkpile",
                        "BP_PoI_Out_SquirrelNut",
                        "BP_PoI_Out_LeanBarrier",
                        "BP_PoI_Out_LeanBarrier2",
                        "BP_PoI_Out_LeanWallBack",
                        "BP_PoI_Out_TouchNeck",
                        "BP_PoI_Out_TouchNose",
                        "BP_PoI_Out_SEarch",
                        "BP_PoI_Out_DragFeet",
                        "BP_PoI_Out_DragFeet2",
                        "BP_PoI_Out_TouchNeck2",
                        "BP_PoI_Out_LeanBarrier3",
                        "BP_PoI_Out_Search2",
                        "BP_PoI_Out_SitJunk",
                        "BP_PoI_Out_BearPoster",
                        "BP_PoI_Out_ToiletPoster",
                        "BP_PoI_Out_Toilet_Sitting",
                        "BP_PoI_Int_Ketchup_PoI_Infini",
                        "BP_PoI_Int_Cream_PoI_Infini",
                        "BP_PoI_Int_Drink_Infini",
                        "BP_PoI_Out_InfiniZenSqc",
                        "BP_PoI_Out_PrivateProperty",
                        "BP_PoI_Out_Jump",
                        "BP_PoI_Out_DragFeet3",
                        "BP_PoI_Out_SitTree",
                        "BP_PoI_Out_BirdElectricPole",
                        "BP_PoI_Int_Airvent_PoI_Infini",
                        "BP_PoI_Out_LookWoods",
                        "BP_PoI_Out_SitTree2",
                        "BP_PoI_Out_LeanWoodPile",
                        "BP_PoI_Out_LookBlackCar",
                        "BP_PoI_Out_DragFeet4",
                        "BP_PoI_Out_LeanBarrier4_336",
                        "BP_PoI_Out_LookGround",
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_Nav",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_AMB_Evening",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_Insertion_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_Insertion_LD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                        "BP_PoI_Out_Ins_GSDiscovery",
                        "BP_PoI_Out_Ins_Stump",
                        "BP_PoI_Out_Ins_OldWheel",
                        "BP_PoI_OutOfbreathe",
                        "BP_PoI_Out_Ins_LeanElectricPole",
                        "BP_PoI_Out_Inst_OldPath",
                        "BP_PoI_Out_Ins_CountingTrees",
                        "BP_PoI_Out_Ins_SitTree",
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A_AMB",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A_BackgroundGR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A_LD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6A_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "ForestStrai_T01_Fix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "ForestCurv_T02_Fix",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6B",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6B_AMB",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6BC_LD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6B_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6B_BackgroundGR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6B_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_6B_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_AMB",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_BackgroundGR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_LD",
                    Interactions = new List<InteractionActor>()
                    {
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_MotelCardCollectible",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("99ac61bc-0b81-4c6c-b0f8-1afc5de01718"), "E1_7A_LD_IntActor_MotelCardCollectible_C1_Look" },
                                    { new Guid("f496979c-fcb8-4663-8695-d7bd64868697"), "E1_7A_LD_IntActor_MotelCardCollectible_C2_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Phone",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("74b0c67e-2b27-44b2-ac38-ebbe3e058f7e"), "E1_7A_LD_IntActor_Phone_C1_Take" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2Interaction_MainDoor",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f9e2e2b7-bc1b-4b07-990a-3df4d2c928b9"), "E1_7A_LD_IntActor_MainDoor_C1_Goinside" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BathTap",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6b61790f-2dc7-4ce7-8c38-65a784cb2f67"), "E1_7A_LD_IntActor_BathTap_C1_Look" },
                                    { new Guid("7231f2fe-6e8f-4845-b772-fc8d7cdd9290"), "E1_7A_LD_IntActor_BathTap_C2_Open" },
                                    { new Guid("4e8ba81b-fe87-4773-a14e-b2886b732074"), "E1_7A_LD_IntActor_BathTap_C3_Close" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Bathtub",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("20a0ac91-3707-4b6a-a166-ece3b1e04977"), "E1_7A_LD_IntActor_Bathtub_C1_Look" },
                                    { new Guid("f729fece-8f71-4950-92e8-9a6f3adea90e"), "E1_7A_LD_IntActor_Bathtub_C2_Look" },
                                    { new Guid("7725243c-edb1-4230-b3fe-22d27e6b25f9"), "E1_7A_LD_IntActor_Bathtub_C3_Calltobath" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BagDaniel",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("3e9cb521-44be-4af4-9302-c28c4658cc9d"), "E1_7A_LD_IntActor_BagDaniel_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SinkTap",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c7aac78e-47ad-482a-8aaa-edeb587775d5"), "E1_7A_LD_IntActor_SinkTap_C1_Wash" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TowelHolder",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("470760d4-0d12-4bdc-9686-c1af16118b08"), "E1_7A_LD_IntActor_TowelHolder_C1_Puttowel" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_VendingMachine",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8114f43d-c58d-4d26-84dd-8e6001773a0f"), "E1_7A_LD_IntActor_VendingMachine_C1_Buyasoda($1)" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Balcony",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d432ec9e-7b65-42ce-9ee8-165771d4f052"), "E1_7A_LD_IntActor_Balcony_C1_Lean" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_AshTray",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("cd2e14b4-731e-45f7-b26b-f3534ec1f09b"), "E1_7A_LD_IntActor_AshTray_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Painting",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fc56ca1a-4d71-4848-8a5c-a691f90097fa"), "E1_7A_LD_IntActor_Painting_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Instructions",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c8a5ac0d-c946-4b43-8ae9-f6ad459a9d68"), "E1_7A_LD_IntActor_Instructions_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Map",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("697ab710-3d40-4e12-a2ab-2f1febe43638"), "E1_7A_LD_IntActor_Map_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LiquidSoap",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("6e49d16e-bf8e-4a3e-b3f0-63ef4c568ae6"), "E1_7A_LD_IntActor_LiquidSoap_C1_Look" },
                                    { new Guid("0a07941b-787b-4087-ae27-9504b62a9b81"), "E1_7A_LD_IntActor_LiquidSoap_C2_Add" },
                                    { new Guid("b36f836f-7607-444a-995d-1bda165289b0"), "E1_7A_LD_IntActor_LiquidSoap_C3_Add" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Wardrobe",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f1f365eb-de7b-495c-b6bd-dd7ead3b1ad9"), "E1_7A_LD_IntActor_Wardrobe_C1_Open" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BrodyCarBeach",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("69bc1b13-6e02-46b5-9bb6-14fb5539961c"), "E1_7A_LD_IntActor_BrodyCarBeach_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FreshTowels",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5d948ec2-c187-4f3d-8ddd-6e4939092f34"), "E1_7A_LD_IntActor_FreshTowels_C1_Take" },
                                    { new Guid("88b3966f-9a3b-4e38-abf2-3cfc2046ef64"), "E1_7A_LD_IntActor_FreshTowels_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BagBeach",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("45541745-909f-4ab3-920f-2415292c12ee"), "E1_7A_LD_IntActor_BagBeach_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BrodyBag",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e8bc1ef7-1616-4c68-a940-c660fbccac55"), "E1_7A_LD_IntActor_BrodyBag_C1_Look" },
                                    { new Guid("af2e222c-a63d-48ef-9c90-616cfa5749ec"), "E1_7A_LD_IntActor_BrodyBag_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_SandCastle",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("f7b01fdf-ad7c-4b96-b39a-fd1a246957be"), "E1_7A_LD_IntActor_SandCastle_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_FrenchWindowInside",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e2092fc3-7bf5-4a5a-88c1-9901a1fd55d5"), "E1_7A_LD_IntActor_FrenchWindowInside_C1_Gooutside" },
                                    { new Guid("cb59d810-def7-4bde-a7b7-d030462be62f"), "E1_7A_LD_IntActor_FrenchWindowInside_C2_Goinside" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TV",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("df521953-1c87-49af-a1d7-7b7b150d7fc8"), "E1_7A_LD_IntActor_TV_C1_Look" },
                                    { new Guid("bd4fc135-362a-4d76-89a3-5112b816404f"), "E1_7A_LD_IntActor_TV_C2_Asktolowervolume" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Tie",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("828b6c79-4dd2-47e2-be2d-a8d2af047187"), "E1_7A_LD_IntActor_Tie_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DustPan_246",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("303c5667-7aa4-4264-b453-160cbeea8526"), "E1_7A_LD_IntActor_246_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Iron_338",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7488d4d8-d54e-4af0-9237-1cb4b53d9493"), "E1_7A_LD_IntActor_338_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_MotelDrawing",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("710b9ba3-b2ca-4025-972b-59db8330dfe7"), "E1_7A_LD_IntActor_MotelDrawing_C1_Sitanddraw" },
                                    { new Guid("5825ada7-2791-4c87-99ff-8239ec71aedb"), "E1_7A_LD_IntActor_MotelDrawing_C2_Sitanddraw" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_NoisyRoom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("918ffabf-478b-45a3-9280-3b74637c3cf4"), "E1_7A_LD_IntActor_NoisyRoom_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Bed1",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("5f036e40-265b-48ca-ab3a-28f7c624ec12"), "E1_7A_LD_IntActor_Bed1_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Bed2",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("54db4a48-18b9-455c-a255-55afcabe689d"), "E1_7A_LD_IntActor_Bed2_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Card",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("864321f3-6496-4ee4-8807-b2d66cb71276"), "E1_7A_LD_IntActor_Card_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_DanielShoes",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("0622f366-152f-4282-9e3a-d3001cad7c9a"), "E1_7A_LD_IntActor_DanielShoes_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Flyers",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("4c29162b-08c3-40e6-8291-9165bd75a82f"), "E1_7A_LD_IntActor_Flyers_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_ForgottenPaper",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7654738b-7026-4760-aa0f-312961112815"), "E1_7A_LD_IntActor_ForgottenPaper_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_JRNLNote",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("fc2e3329-5f7f-48c8-b8d8-d7f085712647"), "E1_7A_LD_IntActor_JRNLNote_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_KnockDoorDaniel",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a2b38abf-f662-4337-9e5c-9bd7f9fcad24"), "E1_7A_LD_IntActor_KnockDoorDaniel_C1_Knock" },
                                    { new Guid("d17167cd-b271-4363-91fe-82946aaf969c"), "E1_7A_LD_IntActor_KnockDoorDaniel_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_LightSwitch",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("448228ca-3ed0-4f56-a6a2-12bbcb0c0005"), "E1_7A_LD_IntActor_LightSwitch_C1_TurnOn" },
                                    { new Guid("143379fe-4cc6-4cea-b595-fa24198c755b"), "E1_7A_LD_IntActor_LightSwitch_C2_TurnOff" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_RacoonSweatShirt",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("eec4a882-2d29-4fd2-b401-d5402889a547"), "E1_7A_LD_IntActor_RacoonSweatShirt_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Shampoo",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("e18e8c78-17bb-4841-8de7-3fa0fb2b44c1"), "E1_7A_LD_IntActor_Shampoo_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_TowelBathroom",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("a8d63ffa-ed22-4f8a-b7b2-02712a897c17"), "E1_7A_LD_IntActor_TowelBathroom_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Tent",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("8dad1f2e-e261-4602-aa60-2385b320b604"), "E1_7A_LD_IntActor_Tent_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_PowerBear_Right",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("1634246d-bb4a-4823-983f-e61cabfecb5d"), "E1_7A_LD_IntActor_Right_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_PowerBear_Left",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("31627f67-0465-4308-8890-c6c719cffaf7"), "E1_7A_LD_IntActor_Left_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Toy",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("38fc1754-4893-48f0-8b29-a92a48c655ea"), "E1_7A_LD_IntActor_Toy_C1_Look" },
                                    { new Guid("87d5b224-002e-40ed-a7d5-7046e2507de6"), "E1_7A_LD_IntActor_Toy_C2_Question" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_BeachDaniel",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("7218a677-82df-45a6-b411-7a172cdda405"), "E1_7A_LD_IntActor_BeachDaniel_C1_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Daniel",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("44ef820f-30d9-4e31-8494-d8d26ae3dffc"), "E1_7A_LD_IntActor_Daniel_C1_Sendtobath" },
                                    { new Guid("e7cdb388-9e58-47e4-a7e5-c8fc4000fd9a"), "E1_7A_LD_IntActor_Daniel_C2_WatchTVtogether" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_WoodStick",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("d0e4ce60-44f8-4774-b273-a9be702c3864"), "E1_7A_LD_IntActor_WoodStick_C1_Playfetch" },
                                    { new Guid("ab667f97-b980-4c12-991b-8de6e4bb0222"), "E1_7A_LD_IntActor_WoodStick_C2_Look" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                        {
                            new InteractionActor()
                            {
                                Name = "PROM_BP_LIS2InteractionActor_Tickle",
                                ClassicInteractions = new Dictionary<Guid, string>()
                                {
                                    { new Guid("c04f807d-7c93-40cd-8341-480cdde355b5"), "E1_7A_LD_IntActor_Tickle_C1_Tickle" },
                                },
                                DanielInteractions = new Dictionary<Guid, string>()
                                {
                                },
                            }
                        },
                    },
                    PointsOfInterest = new string[]
                    {
                        "BP_PointOfInterest_Room8",
                        "BP_PointOfInterest_Room10",
                        "BP_PointOfInterest_AdultTalk",
                        "BP_PointOfInterest_Chair2",
                        "BP_PointOfInterest_Chair3",
                        "BP_PointOfInterest_Lean1",
                        "BP_PointOfInterest5",
                        "BP_PointOfInterest_Chair1",
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_SD",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                        "GAT_MotelDoor",
                        "Gat_MotelWindow",
                        "GAT_BathroomDoor",
                        "GAT_ToMotelPark",
                        "GAT_MotelStairs01",
                        "GAT_MotelStairs02",
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_Motel_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_NAV",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_Outside_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_7A_Room_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_5A_AMB_Night",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "ForestStrai_T01_Scr",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "ForestCurv_T02_Scr",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HGarage_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HExterior_After_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HDanRoom_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_HBathroom_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_1A_FRNDRoom_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Background_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Forest_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Forest_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Road_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_Road_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_ParkingArea_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_PicnicArea_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_AMB_SUNSET",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_HikingTrail_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_SecondaryPath_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_River_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_River_FX",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_ShelterArea_GR",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_AMB_DUSK",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
            {
                new LevelObject()
                {
                    Name = "E1_2A_AMB_NIGHT",
                    Interactions = new List<InteractionActor>()
                    {
                    },
                    PointsOfInterest = new string[]
                    {
                    },
                    WuiVolumes = new string[]
                    {
                    },
                }
            },
        };

        public static List<OutfitObject> LIS2_Outfits = new List<OutfitObject>()
        {
            new OutfitObject { GUID = new Guid("00000000-0000-0000-0000-000000000000"), Name = "(none)", Slot = "None", Owner = "None" }, //special case for empty value
            new OutfitObject { GUID = new Guid("258501f2-2b99-44a3-b1e6-0f83b6215716"), Name = "E1_Sean_Basic", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("31083e38-41ce-4905-be44-7b31520e73ed"), Name = "E1_Sean_Bag", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("84f1b323-03ac-44be-a4e4-036d32014ef5"), Name = "E1_Sean_CapBag", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("5d26d057-311b-4057-b598-3233bffe33e9"), Name = "E1_Sean_Cap", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("cd3ec5e7-e476-4b97-ba5b-5b4d8ba0b606"), Name = "E1_Sean_Hoodie", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("b8ed07f4-951a-4d1d-8212-7470b0f1be14"), Name = "E1_Sean_HoodieNoBag", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("fa32cddd-1ec0-4c45-ab5a-47508a762ec1"), Name = "E1_Sean_BigBag", Slot = "Main", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("d4346ee6-f36e-4567-abfe-2393c3eccad4"), Name = "E1_Sean_Basic_Arm", Slot = "Arms", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("717b7dd4-d676-4a51-8ad8-7d66a7ba4726"), Name = "E1_Daniel_Chemise", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("ed4d7fe5-dace-4885-bc2d-194fadf6ce89"), Name = "E1_Daniel_Tshirt", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("554bf18d-7fc7-4576-9007-7424411c8e78"), Name = "E1_Daniel_TshirtSocks", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("ac9ce54f-ad9c-4490-b932-223560ff0a62"), Name = "E1_Daniel_ShirtAndSocks", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("dc7613e2-8a58-42c8-8a20-87cf10e0be6e"), Name = "E1_Daniel_BarefootRegularShirtDryHair", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("15bff69f-790a-47b6-b5c7-8d8f8348466b"), Name = "E1_Daniel_BarefootRegularShirtWetHair", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("814b5063-a9d1-4795-99ea-cc55e3c07723"), Name = "E1_Daniel_RaccoonSweat", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("96a80845-28ba-4b12-818b-db9773d724d7"), Name = "E1_Daniel_Bag", Slot = "Main", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("34804a71-6888-4c5c-92b9-30c9ed41d276"), Name = "E1_Daniel_Basic_FrontMask", Slot = "Mask", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("e228f90d-36b3-4a43-bc45-e7f1d96879f0"), Name = "E1_Daniel_BackMask", Slot = "Mask", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("bf5f70c8-9368-4432-9300-12ceb0680c73"), Name = "E1_Daniel_Basic_NoMask", Slot = "Mask", Owner = "Daniel" },
            new OutfitObject { GUID = new Guid("69d5dfb2-e0e9-4db9-b45d-805a91841c53"), Name = "E1_Sean_Default_Head", Slot = "Head", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("5bda150f-31c4-4f71-a1ac-7899da78dfc4"), Name = "E1_Sean_Hoodie_Head", Slot = "Head", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("51358f03-c176-4b4b-9bb0-8a3f142ed436"), Name = "E1_KeyChain", Slot = "Collectible_Mesh", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("c9c36f89-c56b-4b19-8526-8a5c03eefc55"), Name = "E1_FishBait", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("0b669cfa-db74-439b-80b9-aa6e9d199672"), Name = "E1_LostNecklace", Slot = "Collectible_Mesh", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("c7b71306-96ec-4f1f-a460-22787437d74e"), Name = "E1_Feather", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("09593626-017e-40f4-bcd1-14cc05087da7"), Name = "E1_BadgePowerBear", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("6c631a0a-3bb4-44e9-9b7e-472f3ff5b5e4"), Name = "E1_BadgeAnarchy", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("de89a776-e442-4fc2-9c42-b5957f887675"), Name = "E1_BadgeButterfly", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("2f38aa48-61f5-4df2-b27f-a3777eb015e4"), Name = "E1_BadgeHole", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("bbf2ff81-110f-4ec3-85be-f1d1628f1edb"), Name = "E1_BadgeSleep", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("f63c0a17-79a5-4c32-89a2-8585074899e6"), Name = "E1_BadgeTornado", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("9925f441-bb21-4005-b4d0-def32e69b900"), Name = "E1_HawtDawg", Slot = "Collectible_Mesh", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("bdd1d9a4-90ca-4d15-bfe1-7091eca59e11"), Name = "E1_BadgeHDMPatch", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("cefdbfb6-928e-49fd-9bf3-49576cbba8be"), Name = "E1_BadgePowerBear", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("9e7d3039-38d9-4427-bf83-883ec4604bf1"), Name = "E1_BadgeThunder", Slot = "Collectible_Badge", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("b9874a4e-6342-4a44-914b-ee2828a922d2"), Name = "E1_Sean_Dirt", Slot = "Dirt_General", Owner = "Sean" },
            new OutfitObject { GUID = new Guid("1a0e11ac-34e8-49f6-88e5-7df47292068e"), Name = "E1_Daniel_Dirt", Slot = "Head_Dirt", Owner = "Daniel" },
        };

        public static Dictionary<string, FactAsset> CS_FactAssets = new Dictionary<string, FactAsset>()
        {
            {
                "06a6ac22-bb5b-4a8c-b86a-ee5115371825", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("6fd901c5-5c3a-4701-8af9-d01bd365fe80"), "PT_EHInside_ChrisRoom_DrawMask"},
                        {new Guid("f3709310-7831-49db-9edc-e3141ba6e7fa"), "PT_EHInside_ChrisRoom_DadCall"},
                        {new Guid("bfff4277-a910-4338-96da-7e4d196e6516"), "PT_EHInside_Kitchen_DadAngry"},
                        {new Guid("ed2951f7-b7d8-445a-a883-9d612fe2a410"), "PT_EHInside_ChrisRoom_ChrisExitRoom"},
                        {new Guid("58ca4ac5-bc91-4924-a806-bab3b66ad9f2"), "PT_EHInside_ChrisRoom_CloakCollected"},
                        {new Guid("8dc5f4ed-fa22-4ec5-af48-bc3d24c0cb24"), "PT_EHInside_CharlesRoom_CigaretteCollected"},
                        {new Guid("eeb798a7-6a49-4255-ae10-cf643cee9407"), "PT_EHInside_Kitchen_GarageKeyCollected"},
                        {new Guid("1990dea4-cab6-4fae-89c7-1c8fec1db617"), "PT_EHInside_Kitchen_CarKeyCollected"},
                        {new Guid("da32a84d-dac2-414c-92b8-4c1a48293788"), "PT_EHInside_ChrisRoom_TreasureLocationRevealed"},
                        {new Guid("8d911017-3757-48d6-8b98-41d365aa89af"), "PT_EHInside_LivingRoom_DoorBell"},
                        {new Guid("04ef477b-39d6-4069-8c9e-acf5ee0804d2"), "PT_EHInside_CharlesRoom_LampFixed"},
                        {new Guid("1d328d39-db4f-461f-84a1-076d14ff88ff"), "PT_EHInside_Kitchen_GroceryList_IceCream"},
                        {new Guid("675a9a99-595c-4858-bf45-ced5c0896a05"), "PT_EHInside_LivingRroom_CarKeyPlaced"},
                        {new Guid("57f96aa4-25b2-4827-a917-2a3d9a1772bf"), "PT_EHInside_CharlesRoom_ClosetKeyCollected"},
                        {new Guid("11d98715-8cb8-4bbb-a147-694778f2f03c"), "PT_EHInside_CharlesRoom_ClosetUnlocked"},
                        {new Guid("ad853d67-7b7b-4001-bb2d-b013d8a0211d"), "PT_EHInside_LivingRoom_PostItPhoneNumbersSeen"},
                        {new Guid("a8e2d7c4-2249-4d3d-b776-aeb72fcbef81"), "PT_EHInside_LivingRoom_PhoneRinging"},
                        {new Guid("b1e7f514-802f-47f4-8309-43a5e9859601"), "PT_EHInside_CharlesRoom_ConsoleSpotted"},
                        {new Guid("e8f3c0b5-53ed-42ca-b779-6d9b9a40f3ba"), "PT_EHInside_ChrisRoom_ReportToBaseDone"},
                        {new Guid("8b47bdb8-7626-4469-b7ec-24e767c0c03e"), "PT_EHInside_ChrisRoom_DrawHeavyArmor"},
                        {new Guid("902d911e-0267-421a-8982-dba5e36a6446"), "PT_EHInside_ChrisRoom_DrawHelmet"},
                        {new Guid("4a9d1561-4763-4d7c-ae54-7771462e3da6"), "PT_EHInside_ChrisRoom_DrawLightArmor"},
                        {new Guid("fcac273a-fd2b-4622-9d43-5343cebb778f"), "PT_EHInside_ChrisRoom_DrawBrightColor"},
                        {new Guid("7c13b670-f29f-4e56-a338-f6e9eb00d715"), "PT_EHInside_ChrisRoom_DrawDarkColor"},
                        {new Guid("2b310c90-37d1-4293-834b-64f5da75d5da"), "PT_EHInside_ChrisRoom_GumTattooApplied"},
                        {new Guid("c13a2880-57cd-4c73-9cc0-c2ca0e971dbb"), "PT_EHInside_ChrisRoom_DrawingSeen"},
                        {new Guid("cf537fc3-7aba-4032-8100-c0366da3f52e"), "PT_EHInside_ChrisRoom_MantroidCarDone"},
                        {new Guid("7553b363-c7f3-41a2-aa7f-d7a8a3fdc54f"), "PT_EHInside_CharlesRoom_BoxSeen"},
                        {new Guid("474d6d2c-6d3d-42b8-b815-e891780aa0b3"), "PT_EHInside_CharlesRoom_TurntablePlaying"},
                        {new Guid("58db328d-3aba-44cb-a37b-ad9759f718a1"), "PT_EHInside_CharlesRoom_VinylIn"},
                        {new Guid("2410a75f-3959-46d5-949c-bcdeddd09035"), "PT_IsBusy"},
                        {new Guid("79d25ec9-cb45-472c-8863-b927c7db17ea"), "PT_EHInside_ChrisRoom_ActionFigurine_Done"},
                        {new Guid("0414e924-9e14-456e-8ee1-4439f550282f"), "PT_EHInside_LaundryRoom_DirtyClothesPut"},
                        {new Guid("df342d6d-0bf2-4545-afd9-39434d4580c7"), "PT_EHInside_LaundryRoom_WashingMachineOn"},
                        {new Guid("59d1f069-503c-463f-b171-5cb1645bf669"), "PT_EHInside_CharlesRoom_ChrisOnTheBed"},
                        {new Guid("6f0431f9-4726-4a2b-8804-2d4d6467cb3a"), "PT_EHInside_FrontDoor_FirstExitDone"},
                        {new Guid("f3c689f9-e381-49ef-b085-4b444a6e033f"), "PT_EHInside_FrontDoor_FirstEnterDone"},
                        {new Guid("fe40cd96-28c0-44ce-9fa4-da39ceb5cf7b"), "PT_EHInside_LaundryRoom_PantsInWashingMachine"},
                        {new Guid("369c267f-32eb-41ec-b26c-95faa25a5b08"), "F_PT_EHInside_Kitchen_RecycleBinFull"},
                        {new Guid("4aaf9901-f110-4169-ba4a-0d8fe407fa0f"), "F_PT_EHInside_Kitchen_CalledDadMobile"},
                        {new Guid("d3b7ccdc-9148-4e5d-aeb8-ec2ee21353d5"), "PT_EHInside_LaundryRoom_OdessaNumberCollected"},
                        {new Guid("e82ed1b2-8c70-4183-8854-e173d8ccf139"), "PT_EHInside_Kitchen_RecycleBinOutside"},
                        {new Guid("352a1e38-ae16-43c8-b69b-a168fb3ca43b"), "F_PT_EHInside_NeedHotWater"},
                        {new Guid("bb75b9f0-d463-4025-8484-f51bc9360e93"), "F_PT_EHInside_LivingRoom_CharlesAsleep"},
                        {new Guid("89ba39ca-647c-4522-aaee-46d424b5d5c7"), "F_PT_EHInside_Kitchen_Helmet_Equipped"},
                        {new Guid("c2011494-4f25-4ecf-bb17-427a428ee549"), "F_PT_EHInside_Bathroom_Mask_Equipped"},
                        {new Guid("1e4355e6-6a46-4988-9fb0-f7163d12448c"), "F_PT_EHInside_CharlesRoom_LightArmor_Equipped"},
                        {new Guid("a25ff346-3de5-4dfd-b02b-67c13131e061"), "F_PT_CostumePainted"},
                        {new Guid("1cd8e46d-cce9-4d48-8dd1-36e36d156e26"), "F_PT_EHInside_CharlesRoom_ChairMoved"},
                        {new Guid("6ebadc2e-577a-4d8d-b0ae-c4b4052ca41a"), "F_PT_EHInside_Kitchen_CalledClaireReynolds"},
                        {new Guid("abf600ca-004e-4435-bb07-cbb289a1aad9"), "F_PT_EHInside_Kitchen_DishesWashed"},
                        {new Guid("5e9b52a9-086a-403c-b2af-a0335214ff97"), "F_PT_EHInside_DialClaire_PlayingVideoGame"},
                        {new Guid("598330b5-c930-49cf-beb6-eeac44a4645f"), "F_PT_EHInside_DialClaire_DoingHomework"},
                        {new Guid("22bed979-a773-4a77-8111-5cfeab222106"), "F_PT_EHInside_DialClaire_TreeAccident"},
                        {new Guid("1fc3c29b-dfaa-4fb4-b366-8b6be4658ffe"), "F_PT_EHInside_DialClaire_NoHear"},
                        {new Guid("e9ec8581-8217-45a8-856d-bc3df852ae4f"), "F_PT_EHInside_DialClaire_Believe"},
                        {new Guid("ccdc6eaa-1996-4fa5-abf0-a28d81517bb1"), "F_PT_EHInside_DialClaire_Doubt"},
                        {new Guid("987cefdc-5e5d-4e8f-b640-535e2189bdcc"), "F_PT_EHInside_DialClaire_Distrust"},
                        {new Guid("54a1a7fc-6d25-43bd-912d-5bfdd63b7cc8"), "F_PT_EHInside_DialClaire_HouseCleaning"},
                        {new Guid("237e8486-ec26-4ef2-96c5-03fea0bf7785"), "F_PT_EHInside_DialClaire_DadFell"},
                        {new Guid("4af1de60-21b8-4774-a7a4-2f00e1c005be"), "F_PT_EHInside_ChrisRoom_ActionFigure_Release"},
                        {new Guid("0fe23f34-4788-4594-bcd3-93cfe28768a1"), "F_PT_EHInside_LaundryRoom_WaterHeaterFixed"},
                        {new Guid("f751f7df-f1e2-4605-ba32-e8ef59b9924d"), "F_PT_EHInside_Kitchen_ChrisGrabbedLandline"},
                        {new Guid("01ee94e4-f4a5-4995-b970-1e48a493873d"), "F_PT_EHInside_Kitchen_PhoneUnlocked"},
                        {new Guid("9e944045-83ec-422a-b6a2-3fbe295a4823"), "F_PT_EHInside_AddedLogToFurnace"},
                        {new Guid("49e36c9a-1f40-4651-8b67-56e2eca6d8f2"), "F_PT_PowerTutoDone"},
                        {new Guid("895f5ebc-e3c1-4094-adfd-ca9f95685bb6"), "F_PT_EHInside_Kitchen_HelmetSpotted"},
                        {new Guid("a16b7032-06a1-4063-9e81-679b5bd6a065"), "F_PT_EHInside_CharlesRoom_LightArmorSpotted"},
                        {new Guid("dcd2ab85-df24-4c24-b2fb-b4c94458cb42"), "F_PT_EHInside_Bathroom_MakeUpSpotted"},
                        {new Guid("d25b7710-8257-4e32-8124-4698046f72d3"), "F_PT_EHInside_Kitchen_CalledOdessa"},
                        {new Guid("1cb6c26a-0b7e-471c-bf0d-430c289934e1"), "F_PT_EHInside_Kitchen_MacCheeseCooking"},
                        {new Guid("749890d6-628f-4501-8ad0-b52eae278187"), "F_PT_EHInside_Kitchen_MacCheeseCooked"},
                        {new Guid("c76e96fa-f58e-4b08-91c1-b7bee824bf55"), "F_PT_EHInside_LaundryRoom_LightsOn"},
                        {new Guid("a0ab3395-f5d1-45bd-aa81-6d844ba3d3e7"), "F_PT_EHInside_Kitchen_CalledPizza"},
                        {new Guid("9ee10fe9-24b3-42b1-954c-0024bc0f725a"), "F_PT_EHInside_Kitchen_CanCallClaireReynolds"},
                        {new Guid("29550ad4-310f-4fab-a6a2-fba9968cb7ff"), "F_PT_EHInside_Kitchen_CanCallPizza"},
                        {new Guid("dd105580-0463-40c4-b644-8c8a4683322f"), "F_PT_EHInside_Kitchen_CanCallOdessa"},
                        {new Guid("e02b2e0e-d6bb-4e68-bb90-b09bcbf1b58c"), "F_PT_EHInside_Kitchen_CanCallDadMobile"},
                        {new Guid("740845b2-7a2b-4bec-b060-513c92d50ae0"), "F_PT_EHInside_LivingRoom_ChrisSitSofa"},
                        {new Guid("d837dcfe-a3bb-40ca-93de-4c96a50bd43a"), "F_PT_CharlesRoom_TrousersCollected"},
                        {new Guid("02a2514b-5b61-462f-b3eb-c0531a9b5d8a"), "F_PT_EHInside_DialHalfTime_EnteredOnce"},
                        {new Guid("063ecc9b-6b67-48af-9126-9ee370d2e3fa"), "F_PT_EHInside_LivingRoom_CanSpeakToDad"},
                        {new Guid("7d7077a3-3978-4034-a9cc-0cb9d253d61f"), "F_PT_EHInside_ChrisRoom_MapSeen"},
                        {new Guid("562da249-4a74-438f-83aa-43d8304d2b41"), "F_PT_EHInside_Kitchen_DishesBroken"},
                        {new Guid("6008e7b2-7c15-429b-ac6c-fbc4b8358333"), "F_PT_EHInside_LaundryRoom_StickersIsGlowing"},
                        {new Guid("00e40d79-988b-4792-bbb1-5a3daa6617a0"), "F_PT_EHInside_LivingRoom_DadAskBeer"},
                        {new Guid("2d91b897-a34d-4346-b225-f65e2ad8ae42"), "F_PT_EHInside_ChrisIsNear"},
                        {new Guid("afacc298-ed70-466f-bc76-3a69ce2b0875"), "F_PT_EHInside_ChrisIsOutside"},
                        {new Guid("682e816b-cb49-44a4-bc0e-d9f5cf96dca9"), "F_PT_EHInside_Kitchen_LandlinePhoneCallAnswered"},
                        {new Guid("c579b60d-11b4-40cc-b8e0-542079776e83"), "F_PT_EHInside_Kitchen_CanHintAtLandlinePhoneCallMissed"},
                        {new Guid("80ede424-2a03-4e96-ba6d-324133f8bb94"), "F_PT_EHInside_LivingRoom_CharlesIsAnimated"},
                        {new Guid("076769e7-50dc-4857-99ab-5930adb39717"), "F_PT_EHInside_LivingRoom_CharlesIsDrunk"},
                        {new Guid("50f0879d-eea4-44a3-bc43-c771819f2f09"), "F_PT_EHInside_Kitchen_MacCheeseGivenToDad"},
                        {new Guid("52e6c3bf-669d-40ca-946f-7d736b4b57bd"), "F_PT_EHInside_CharlesRoom_PlayedMomVinyl"},
                        {new Guid("75a7aa64-28f4-4479-8059-4ec070bdc0c9"), "F_PT_EHInside_LivingRoom_ReactedToWashingMachine"},
                        {new Guid("e345b2eb-2849-49a7-9872-56f12dd62737"), "F_PT_EHInside_LivingRoom_ReactedToWaterHeater"},
                        {new Guid("109be961-45be-433b-bbf9-ff1bac9d98db"), "F_PT_EHInside_ChrisRoom_VikingChecked"},
                        {new Guid("1ea30c5a-5907-4b85-8984-e4b53c19e771"), "F_PT_EHInside_LivingRoom_TrexChecked"},
                        {new Guid("52c556a8-f9c1-4966-8afe-48c65ff690e4"), "F_PT_EHInside_LivingRoom_MatchIsOn"},
                        {new Guid("58a2f05c-5b53-424e-b584-e4462c288137"), "F_PT_MoveCharacterTutoDone"},
                        {new Guid("204074e3-b52b-46e1-841b-27bc1c4a7189"), "F_PT_MoveCameraTutoDone"},
                        {new Guid("360ee238-ceb6-4715-95fb-dbf35157daeb"), "F_PT_EHInside_LivingRoom_CharlesReactedToKeyInBowl"},
                        {new Guid("e28b9972-974b-412b-93d4-701e8c041b04"), "F_PT_EHInside_ChrisRoom_ActionFigureChecked"},
                        {new Guid("710497b6-9525-4fc0-99cd-dbd52b108644"), "F_PT_EHInside_ChrisRoom_SharkChecked"},
                        {new Guid("90fe316f-35f8-4d76-a3c2-8fd872b579d5"), "F_PT_EHInside_InterruptingCharles"},
                        {new Guid("97b69e25-650d-4754-b9ca-84582f6f825b"), "F_PT_EHInside_Kitchen_IsInAPhoneCall"},
                        {new Guid("fce1cb1f-59a0-4cfc-90d4-ceeeb9ae717e"), "F_PT_EHInside_LivingRoom_ChrisDidZenSeqPart2"},
                        {new Guid("3235320c-03ee-4edb-907d-e755124d57c5"), "F_PT_EHInside_LivingRoom_StatBookInUse"},
                        {new Guid("97ef07ca-4783-4ec1-93e6-2914eb2ec186"), "F_PT_EHInside_Kitchen_MacCheeseCookedButCold"},
                        {new Guid("b811ff5c-a385-4999-ae9c-cf2c2abd6db8"), "F_PT_EHInside_LivingRoom_ChrisInFrontOfTV"},
                        {new Guid("26715526-4623-4d35-add9-674eb94a7866"), "F_PT_InventoryTutorialDone"},
                        {new Guid("d9ab6c9f-2224-4037-bb1a-3e166606f697"), "F_PT_EHInside_Kitchen_HawdDawgManCaptain SpiritNotifyDone"},
                        {new Guid("ad3a6faf-7fa7-4066-9bdb-a9080350d46b"), "F_PT_EHInside_ChrisIsInTheKitchen"},
                        {new Guid("e39842b8-246c-4b07-9ccd-64707bed94e3"), "F_PT_EHInside_ChrisIsInTheLaundry"},
                        {new Guid("5895d12f-d950-4b7f-86df-1fe9fcfa23ff"), "F_PT_EHInside_ChrisIsInTheLivingRoom"},
                        {new Guid("b6b21ac5-5370-41c5-86dc-d945e33c101f"), "F_PT_EHInside_ChrisIsInChrisRoom"},
                        {new Guid("5a1366b3-cac6-49a6-96f1-30d6d6c8d3b1"), "F_PT_EHInside_ChrisIsInCharlesRoom"},
                        {new Guid("2c5d54cd-670c-4424-a1f1-28d7b4b3bdb8"), "F_PT_EHInside_ChrisIsInTheBathroom"},
                        {new Guid("268397b4-f4e6-4868-bd0b-7bb8a752d5bb"), "F_PT_EHInside_ChrisIsInTheDarkZone"},
                        {new Guid("3fbd19e0-556f-4573-af9b-f7ba4f3baf92"), "F_PT_EHInside_Kitchen_ChrisIsUsingMobilePhone"},
                        {new Guid("1b050fc5-7d25-4166-a7bd-d8c582c9c0d8"), "F_PT_OpenDiaryTutorialDone"},
                        {new Guid("a5b96193-f5d4-459d-ab84-5f94ced88d35"), "F_PT_ShouldOpenDiary"},
                        {new Guid("9e5488d8-80a7-4ee0-8db8-07320f9bd616"), "F_PT_RecenterCamTutoDone"},
                        {new Guid("b0058737-cea2-4c66-8603-0cbb46d0a69c"), "F_PT_SwitchCameraShoulderTutoDone"},
                        {new Guid("ea936a27-16ca-4fdb-abef-00436421b30c"), "F_PT_EHInside_Match_Paused"},
                        {new Guid("7f22840e-172b-4434-977f-d91adca4e581"), "F_PT_EHInside_DialHalfTime_PineTreeChoice"},
                        {new Guid("deb24283-9b2a-4760-9667-bebf51a3a30b"), "F_PT_EHInside_DialHalfTime_MomChoice"},
                        {new Guid("8a7a24b7-2a93-46c4-9fd7-0b35ae25e46a"), "F_PT_EHInside_MatchComplete"},
                        {new Guid("e060b1e1-ac32-401e-9aa4-505064d16754"), "Metrics_DialHalfTimeStartedOnce"},
                        {new Guid("ec0d1bf0-3f6a-464e-8347-02d04886bb75"), "F_PT_EHInside_LaundryRoom_CanReactToWaterEater"},
                        {new Guid("912cb014-202f-450d-aed6-2a5d97812c1d"), "F_PT_EHInside_CharlesSpeaks"},
                        {new Guid("6cb2a0d7-f164-4cb9-bc44-7efa517c96f4"), "F_PT_EHInside_Kitchen_ChrisIsBringingMacCheese"},
                        {new Guid("95d4bef1-9147-41ee-b694-02743dbc6472"), "F_PT_EHInside_Kitchen_CharlesCanReactToMicroWaveBeeps"},
                        {new Guid("1f2e1f68-2d23-4846-b765-9990ab5e4ff1"), "F_PT_EHInside_LivingRoom_ChimneyIsStrong"},
                        {new Guid("6c75f5fe-3df7-4795-a3dd-2a6adb0bd341"), "F_PT_EHInside_CharlesRoom_ChrisLikedMomRecordCue"},
                        {new Guid("2aedb14e-7eb8-4be6-ad12-fd2293d10c71"), "F_PT_EHInside_ChrisRoom_ClosetOpen"},
                        {new Guid("e37328bc-0b89-45dd-a486-3ff8322bed5e"), "F_PT_EHInside_CharlesRoom_LightsOn"},
                        {new Guid("c7079c3f-f479-48da-9abf-77c71c20fc12"), "F_PT_EHInside_Kitchen_ChrisDrankMilk"},
                        {new Guid("15b90ca5-280b-4c8b-9431-361dde3f20d3"), "F_PT_EHInside_LivingRoom_MatchPausedByCharles"},
                        {new Guid("6a654d3b-f5a3-4e19-bbf7-676a758e9d05"), "F_PT_EHInside_Bathroom_InterviewDone"},
                        {new Guid("8042f340-98f1-4202-9145-a0dac02d865b"), "F_PT_EHInside_Kitchen_TupperwareTrashed"},
                        {new Guid("2df5ffdf-5b01-467e-9746-1e9e380ca6a3"), "F_PT_EHInside_CharlesRoom_ZenMusicPlaying"},
                        {new Guid("40c183de-bcba-4c2f-8ec1-a87de32a1a57"), "F_PT_EHInside_ChrisRoom_FailedBasketBallThrow"},
                        {new Guid("d45d480a-2eae-4b46-9ec7-719713d07751"), "F_PT_EHInside_LivingRoom_WhiskyBottleInUse"},
                        {new Guid("d249694e-5b02-4290-ac58-1febafb5d58e"), "F_PT_EHInside_Kitchen_CalledClaireReynoldsLate"},
                        {new Guid("2dae2bcb-711b-4a34-a43b-d275cdd8017e"), "F_PT_DiaryLocked"},
                        {new Guid("10567441-6018-40e5-b49c-e2db26159d54"), "F_PT_EHInside_ChrisRoom_DadCallTimelineActive"},
                        {new Guid("079e942c-3e67-4418-9c1d-7b4d56744d22"), "F_PT_EHInside_ChrisRoom_SkipTitleReveal"},
                        {new Guid("afe884dc-5cac-4426-bddb-a5203340eb7c"), "F_PT_EHInside_LivingRoom_DadAskBeerTimelineActive"},
                        {new Guid("29012452-d27b-42ad-93e9-758d2b7f5bd0"), "F_PT_EHInside_LivingRoom_PlayedWithDinosaur"},
                        {new Guid("0b3208ce-5e93-4e2a-958f-b5c80be53fc9"), "F_PT_EHInside_LivingRoom_DialDrankALotChoiceDone"},
                        {new Guid("609f24dc-e6c9-4804-ae89-0c273d899928"), "F_PT_EHInside_LivingRoom_CarKeysFoundWithCharles"},
                        {new Guid("de5ba019-9399-4281-887d-7b989effcc00"), "F_PT_EHInside_LivingRoom_Drink03PlayedOnce"},
                        {new Guid("f0e3e339-e9a4-4306-9967-f8a31900712a"), "F_PT_EHInside_LateToBreakfastEnabled"},
                        {new Guid("eee8c04f-83ac-4630-955a-95d163d7ee1b"), "F_PT_EHInside_Kitchen_AnswerPhoneNoCut"},
                        {new Guid("aaba4e71-969a-46f0-9e2c-b97e58df9134"), "F_PT_EHInside_LaundryRoom_LightPowered"},
                        {new Guid("9ae0ce3b-db0b-4f36-8e44-506f42a9f81c"), "F_PT_EndReached"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("bfa99920-2923-454d-8789-057de45d52e5"), "F_PT_EHInside_LivingRoom_ChrisTriedToSpeakToDadCounter"},
                        {new Guid("817683e9-6595-456d-aeaa-09052b36e863"), "F_PT_EHInside_LivingRoom_DadAnsweredToChrisCounter"},
                        {new Guid("70a8348f-0acb-4631-b631-0849cb3a1998"), "PT_EHInside_ChrisRoom_DadAskForBreakfast"},
                        {new Guid("0623ae68-e024-48ca-b889-f8dd50a0974b"), "F_PT_EHInside_DialClaireTrustCounter"},
                        {new Guid("1804657a-f40f-4dbc-a7ea-77389bf5db25"), "F_PT_EHInside_LivingRoom_HalfTimeDial_ChoiceCount"},
                        {new Guid("1d04884e-efa0-4b0a-98a8-5b71b4fd77eb"), "F_PT_DynamicDialTutoDoneINT"},
                        {new Guid("4cc7e566-606a-412b-b81a-5d2a2da32bc0"), "F_PT_EHInside_LivingRoom_AskBeerCount"},
                        {new Guid("5d75e1c9-e4f8-4b90-a6e4-5171881938fd"), "F_PT_EHInside_ChrisPhoneCallReactionCueNumber"},
                        {new Guid("a0aa6881-4c6b-4f1e-a1a7-c687278a542d"), "F_PT_EHInside_Kitchen_MicroWaveReactionCueNumber"},
                        {new Guid("012f489e-4fbf-4d8b-b244-77622f27625e"), "F_PT_EHInside_LivingRoom_HidingTVReactionCueNumber"},
                        {new Guid("75f381d7-f5d2-4759-aa7a-0a5a81b80e98"), "F_PT_EHInside_LivingRoom_StatBookState"},
                        {new Guid("f28dc9bc-ee8b-4ab4-b8c9-7a3554c9de06"), "F_PT_EHInside_ChrisPhoneCallReactionCueNumberMax"},
                        {new Guid("9f089f99-fd9d-4806-af00-ae4165e38d3f"), "Metrics_EmilySecretsFound"},
                        {new Guid("56653ac8-f44c-4c5f-8a68-424936d8e077"), "F_PT_EHInside_LivingRoom_StatBookLoopCount"},
                        {new Guid("0be8a2b7-578b-4921-a1e4-2fd6b230e7a7"), "F_PT_EHInside_Kitchen_FreeSlotForAudra"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("b44f209d-812f-426c-bec9-652334ce88bc"), "F_PT_EHInside_Kitchen_MicroWaveHeatingDuration"},
                        {new Guid("687d2170-011b-4053-bb8c-e0d34243b1d9"), "F_PT_EHInside_LivingRoom_CurrentWhiskyGlassLevel"},
                        {new Guid("9e725853-902c-4e6e-bc8d-05d091e8b680"), "F_PT_EHInside_LivingRoom_CurrentWhiskyBottleLevel"},
                        {new Guid("19550609-ef3f-442f-ab47-ad8d142adbe4"), "F_PT_EHInside_CharlesRoom_ZenMusicElapsedTime"},
                        {new Guid("f85779aa-6ed5-460c-bac3-eac05810e0eb"), "F_PT_EHInside_LaundryRoom_GlowTimeline"},
                        {new Guid("1786e881-832b-4b59-b9f8-40974ba2e046"), "F_PT_EHInside_ChrisRoom_DadCallingTimeline"},
                        {new Guid("bba5b425-55db-453a-985f-93a60202591f"), "F_PT_EHInside_DadAskBeerTimeline"},
                        {new Guid("a79d501a-a03e-4db1-8fb2-53fdd20a9264"), "F_PT_EHInside_Match_Time"},
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "7b1cb3ee-7825-4ec9-b424-a7dc143d16f5", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("d07b6639-1db7-425c-9b2a-0af68f904b24"), "F_PROM_P_IntActor_Window_C1_Look"},
                        {new Guid("356f36ee-7a23-4052-bbf0-c3ea89c8242c"), "F_PROM_P_IntActor_ToiletSticker_C1_Look"},
                        {new Guid("627012f4-c660-4505-9e0e-3ebf6a808043"), "F_PROM_P_IntActor_Tattoo_C1_Look"},
                        {new Guid("712e3726-4abe-4533-bdc2-c390fbc29957"), "F_PROM_P_IntActor_Tattoo_D1_Apply"},
                        {new Guid("b4ce0a2c-84c1-4f7e-8f18-3c4dbf7d8adb"), "F_PROM_P_IntActor_Submarine_C1_Look"},
                        {new Guid("3e52787a-4c9c-45ec-aa20-f3a8b17546d6"), "F_PROM_P_IntActor_StatBook_C1_Look"},
                        {new Guid("4efa88fd-b565-4686-964b-8c47b7775d3e"), "F_PROM_P_IntActor_Razor_C1_Look"},
                        {new Guid("76f37932-7bdc-4660-b099-731fa1b1430b"), "F_PROM_P_IntActor_KitchenLockedDoor_C1_Look"},
                        {new Guid("f889cd57-4044-4f39-be09-65df41051ba1"), "F_PROM_P_IntActor_GlowingSticker_C1_Look"},
                        {new Guid("9b502124-c7af-4876-983b-409018cce6f0"), "F_PROM_P_IntActor_Fridge_C1_Open"},
                        {new Guid("f2089840-a43e-4aa7-90e2-e767ca63ec74"), "F_PROM_P_IntActor_Faucet_C3_Use"},
                        {new Guid("c7a99ce8-c778-44a3-ab83-175debaaaa1a"), "F_PROM_P_IntActor_Faucet_C1_Use"},
                        {new Guid("00ef7d28-c06f-49c4-90b5-217161276697"), "F_PROM_P_IntActor_Faucet_C2_Look"},
                        {new Guid("7be7eaaa-96d3-4943-8a80-a928fd2ff009"), "F_PROM_P_IntActor_DirtyClothes_C1_Look"},
                        {new Guid("0c8c3c16-5b6c-46a9-9167-3840b8af5967"), "F_PROM_P_IntActor_DirtyClothes_C2_Addtotub"},
                        {new Guid("5dcf9dab-8fcd-4f0a-b5f8-65252024c851"), "F_PROM_P_IntActor_ComicBookBathroom_C2_Read"},
                        {new Guid("1c70bff0-fdd1-4d84-98fb-697960f23bbd"), "F_PROM_P_IntActor_ChristmasDecorations_C1_Look"},
                        {new Guid("6ebdcc1d-aefc-4cd5-b6ba-e5823d5f96fd"), "F_PROM_P_IntActor_ChrisBasketBall_C1_Look"},
                        {new Guid("ac833091-f3aa-48c5-a79d-ab726caba276"), "F_PROM_P_IntActor_ChrisBasketBall_C3_Throw"},
                        {new Guid("60c981f8-958c-4295-93a7-172546fed846"), "F_PROM_P_IntActor_CharlesTrophies_C1_Look"},
                        {new Guid("2e8d6eb7-96a3-4835-b9be-ec26d4627e51"), "F_PROM_P_IntActor_BoxArmyToy_C1_Look"},
                        {new Guid("fe07cacb-f67c-4e9d-a074-43df4caf4569"), "F_PROM_P_IntActor_BoobMag_C1_Look"},
                        {new Guid("d5ca3d36-eae1-4409-8c0c-950f0b0953c9"), "F_PROM_P_IntActor_BaseballBat_C1_Look"},
                        {new Guid("ac98d8a4-4b29-47e5-b7e7-d85605a8a536"), "F_PROM_P_IntActor_Note_C1_Inspect"},
                        {new Guid("041725b5-f369-47ea-9d20-4c461fd9bcbb"), "F_PROM_P_IntActor_Note_C2_Look"},
                        {new Guid("8525d9a4-e10e-45a6-b297-f11ac43f7fcd"), "F_PROM_P_IntActor_WashingMachine_C1_Wash"},
                        {new Guid("bd14916a-4fbb-4ff2-a9da-d2700d00da2e"), "F_PROM_P_IntActor_WashingMachine_C2_Look"},
                        {new Guid("41d4dfae-cd7b-45fd-8bbe-e627ce3f543e"), "F_PROM_P_IntActor_WashingMachine_C3_AddDad'sPants"},
                        {new Guid("acea9ed9-3cbf-451c-96d2-6dbac0cd3af0"), "F_PROM_P_IntActor_DoorDarkZone_C2_Look"},
                        {new Guid("f6503cf5-b2c7-4b90-8ec2-85eb7421fe05"), "F_PROM_P_IntActor_DoorDarkZone_C1_Look"},
                        {new Guid("fda3827d-1f9e-4ad4-acd5-5cda58fe7ed6"), "F_PROM_P_IntActor_DoorDarkZone_D1_Open"},
                        {new Guid("d6788b80-ce54-42b9-804c-3c243ba1a92d"), "F_PROM_P_IntActor_WaterHeater_C1_Look"},
                        {new Guid("89a7839a-ea3e-420e-8dfc-724ba7fd41a2"), "F_PROM_P_IntActor_WaterHeater_D1_Tame"},
                        {new Guid("479233d5-281d-457f-8e5d-a65df30e8ccf"), "F_PROM_P_IntActor_LightSwitch_C1_TurnOn"},
                        {new Guid("0bbbf152-fc84-4d2f-b757-61e6ed66920b"), "F_PROM_P_IntActor_LightSwitch_C2_TurnOff"},
                        {new Guid("21bd658a-e1c6-43dc-a70c-a81815a3f01f"), "F_PROM_P_IntActor_MakeUp_C1_Look"},
                        {new Guid("cfce76da-1fe2-4f13-909c-5e3cdc442060"), "F_PROM_P_IntActor_MakeUp_D1_Apply"},
                        {new Guid("5a38e6a9-6448-40e1-8b33-7af2c4ea7021"), "F_PROM_P_IntActor_Mirror_C1_Interview"},
                        {new Guid("6691c612-0a36-4a18-8b08-879bda4cc83b"), "F_PROM_P_IntActor_Mirror_C3_Use"},
                        {new Guid("c1cb4973-cdf0-41ef-a846-66085bdf95fb"), "F_PROM_P_IntActor_Mirror_C5_Use"},
                        {new Guid("0658bbd6-be67-4b8c-bd1a-26adf1c36cf4"), "F_PROM_P_IntActor_Mirror_C2_Use"},
                        {new Guid("009af398-10f0-48df-9dcb-3cb9714554a3"), "F_PROM_P_IntActor_Turntable_C1_Look"},
                        {new Guid("947388b7-e922-40a5-be20-b8896bc65d72"), "F_PROM_P_IntActor_Turntable_C3_Stop"},
                        {new Guid("de30f31b-3a1c-4b48-ab4b-f9eddcbed052"), "F_PROM_P_IntActor_CharlesRoomDoor_C1_Enter"},
                        {new Guid("00682494-fc1d-40ce-9946-6203fd23d933"), "F_PROM_P_IntActor_CharlesRoomDoor_C2_Leave"},
                        {new Guid("fa8af3cc-b023-4767-96d4-7487f64841a3"), "F_PROM_P_IntActor_GarageKey_C1_Take"},
                        {new Guid("c7a84d2f-b8c9-4496-8131-5b06361315af"), "F_PROM_P_IntActor_MilkBottle_C1_Drink"},
                        {new Guid("78e52067-a0c4-40cd-84fd-8525ec4e6b3a"), "F_PROM_P_IntActor_MilkBottle_C2_Look"},
                        {new Guid("c65d2a84-5718-457b-97a7-fcf7a2dc8396"), "F_PROM_P_IntActor_Dishes_C1_Look"},
                        {new Guid("82f296fb-6bc6-4f23-baad-a6522925e359"), "F_PROM_P_IntActor_Dishes_D1_MegaWash"},
                        {new Guid("c84a9819-631f-4e8b-a72a-7f0280274bbe"), "F_PROM_P_IntActor_Dishes_C2_Wash"},
                        {new Guid("e087658f-c37c-42ca-b66c-e96e3961d818"), "F_PROM_P_IntActor_Memo_C1_Look"},
                        {new Guid("930aee31-8675-4d85-b50c-0ce5764925da"), "F_PROM_P_IntActor_MacCheese_C1_Cook"},
                        {new Guid("0e0a3770-a322-4e26-b8ee-ab72da387b3d"), "F_PROM_P_IntActor_AluminiumFoil_C1_Look"},
                        {new Guid("01f5a55e-491f-4f00-a3b9-ca5aa02be7bb"), "F_PROM_P_IntActor_AluminiumFoil_D1_Wear"},
                        {new Guid("7b72dfe5-d76f-43e3-8ef7-3deca053e7b3"), "F_PROM_P_IntActor_RecycleBin_C1_Look"},
                        {new Guid("f9213ec4-cb92-4691-855b-7f011e46a71c"), "F_PROM_P_IntActor_RecycleBin_C2_Look"},
                        {new Guid("f117ee32-833e-4576-acc2-d30ec20d5f49"), "F_PROM_P_IntActor_RecycleBin_C3_TakeOut"},
                        {new Guid("0840016c-91a5-4c9b-bf27-a21496e82d24"), "F_PROM_P_IntActor_MicroWave_C1_Look"},
                        {new Guid("1f4a2bfd-a835-45e3-8fa1-674b3b8bfb3b"), "F_PROM_P_IntActor_MicroWave_C2_Givetodad"},
                        {new Guid("dfcb06d3-e897-4755-bb5c-3acb16a69270"), "F_PROM_P_IntActor_MicroWave_C3_Look"},
                        {new Guid("c4f15d39-3abd-427c-a5a6-9182857a9521"), "F_PROM_P_IntActor_Carkeys_C1_Look"},
                        {new Guid("3d1e76bf-2f7c-42a4-af28-5dc7c7cb1e7e"), "F_PROM_P_IntActor_Carkeys_C2_Take"},
                        {new Guid("90ba2a54-525f-433d-83ea-f0591482149e"), "F_PROM_P_IntActor_KeyBowl_C1_Put"},
                        {new Guid("55d99564-e145-4a0e-831d-c44ea28c7b4b"), "F_PROM_P_IntActor_KeyBowl_C2_Take"},
                        {new Guid("9b54b6ea-0b0f-4297-9d84-3ed1a875a851"), "F_PROM_P_IntActor_Carkeys_C3_Take"},
                        {new Guid("8dd4ef1a-cfb2-4937-a574-d0caaa9b5c49"), "F_PROM_P_IntActor_Laptop_C1_Use"},
                        {new Guid("79c43e02-b57f-4941-9efb-3d07bca997b6"), "F_PROM_P_IntActor_Charles_C3_Speak"},
                        {new Guid("362cb015-b308-4112-9373-0c1295bebfe2"), "F_PROM_P_IntActor_Laptop_C2_Look"},
                        {new Guid("2f20e9bc-d4d8-4fe7-9938-11671ec03869"), "F_PROM_P_IntActor_TrainMagazine_C1_Look"},
                        {new Guid("170998ac-9beb-4176-a77b-21f0b37b1ab0"), "F_PROM_P_IntActor_GroceryList_C1_Look"},
                        {new Guid("98a762be-ac93-424e-a118-21e9344a1a16"), "F_PROM_P_IntActor_GroceryList_C2_Addicecream"},
                        {new Guid("2e846d1c-b267-4b15-bc25-790177cd6f7c"), "F_PROM_P_IntActor_GroceryList_C3_Look"},
                        {new Guid("e3b80a80-fc2f-471e-9945-e3f1fe01a952"), "F_PROM_P_IntActor_BeaverCreekPostCard_C1_Look"},
                        {new Guid("bece54af-e8ae-4039-a004-f44d72a4925d"), "F_PROM_P_IntActor_GrandParentsLetter_C1_Read"},
                        {new Guid("e6217493-6541-4773-9e94-91493a62e838"), "F_PROM_P_IntActor_Newspaper_C1_Read"},
                        {new Guid("6c363ed6-171e-46ab-80e0-a76d827f8b5e"), "F_PROM_P_IntActor_BooksLivingRoom_C1_Look"},
                        {new Guid("95722cf3-fc24-4006-b64c-c37c5f9b96d7"), "F_PROM_P_IntActor_FriendPhoto_C1_Look"},
                        {new Guid("4e324bbb-1685-47e9-a357-2ff243ade11e"), "F_PROM_P_IntActor_BookShelfTop_C1_Look"},
                        {new Guid("25a102ad-6bee-4c34-96aa-a60d0fe7437a"), "F_PROM_P_IntActor_CharlesTeamPicture_C1_Look"},
                        {new Guid("47cdd92b-e6d2-4881-a765-b8e463ad3a26"), "F_PROM_P_IntActor_CharlesBasketPicture_C1_Look"},
                        {new Guid("7e6bfff2-497c-409a-a38a-256be3fb4fb9"), "F_PROM_P_IntActor_FireStove_C1_Look"},
                        {new Guid("d446ae46-28a0-410d-bade-4de1007c6f5e"), "F_PROM_P_IntActor_FireStove_C2_AddLog"},
                        {new Guid("d60fb40c-f6e5-42aa-a902-b05aa742cb69"), "F_PROM_P_IntActor_FireStove_D1_Burn"},
                        {new Guid("095b64c4-ff01-4748-982a-54e63d781b1d"), "F_PROM_P_IntActor_Dinosaur_C1_Look"},
                        {new Guid("2fab0f11-66ac-45db-8089-036eae86d11a"), "F_PROM_P_IntActor_Dinosaur_C2_Play"},
                        {new Guid("303ef22e-5784-4073-a5b8-5325ef5e0a12"), "F_PROM_P_IntActor_WhiskyBottle_C1_Look"},
                        {new Guid("04e8c032-2d6c-4cf0-8599-d6544d041db0"), "F_PROM_P_IntActor_WhiskyBottle_C2_Look"},
                        {new Guid("77c6dbb1-5637-428b-b9f0-4d87204a028a"), "F_PROM_P_IntActor_WhiskyBottle_D1_Evaporate"},
                        {new Guid("2a5894d8-b409-4d51-95b2-426ae452d52a"), "F_PROM_P_IntActor_NerfGun_C1_Look"},
                        {new Guid("3119f191-096b-4973-b5e2-51588b4c5839"), "F_PROM_P_IntActor_phoneCall_C1_CallDad"},
                        {new Guid("ba726242-9e5e-486e-b004-bee56b3f083a"), "F_PROM_P_IntActor_phoneCall_C2_CallPizzaDelivery"},
                        {new Guid("ef26bcff-e14f-4bb3-a070-6a5a37bc8114"), "F_PROM_P_IntActor_phoneCall_C5_CallReynolds"},
                        {new Guid("f2ece824-142b-42ef-b48c-cf16908c850d"), "F_PROM_P_IntActor_Charles_C1_Wakeup"},
                        {new Guid("00fcc439-7e2e-4822-b34e-2c6c1afb7a94"), "F_PROM_P_IntActor_Charles_C2_Speak"},
                        {new Guid("ab753297-496d-4782-b7a9-903695abcfed"), "F_PROM_P_IntActor_phoneCall_C3_CallReynolds"},
                        {new Guid("e58a4c21-99c7-421b-be6f-1b2722e398ca"), "F_PROM_P_IntActor_PhoneCall_C7_CallAudra"},
                        {new Guid("10996a91-227a-43e3-bc8f-9f9f693a7ca1"), "F_PROM_P_IntActor_Charles_C4_Look"},
                        {new Guid("a691741d-bd32-471a-81e8-034dfa369b06"), "F_PROM_P_IntActor_Charles_C6_Look"},
                        {new Guid("9068b43e-3a78-4cbd-ae1e-1f7be912b3fc"), "F_PROM_P_IntActor_Sofa_C1_Look"},
                        {new Guid("5345d65c-f812-458a-a449-7d2f56f2487f"), "F_PROM_P_IntActor_Sofa_C2_Sit"},
                        {new Guid("674faac1-4565-4cf7-aad1-e4085d6a33ea"), "F_PROM_P_IntActor_LandlinePhone_C1_Answer"},
                        {new Guid("ee744eab-982a-4278-9b61-3496211dc7e8"), "F_PROM_P_IntActor_LandlinePhone_C2_Use"},
                        {new Guid("e11098d6-0917-4162-bb42-f3f390f7e61c"), "F_PROM_P_IntActor_Slippers_C1_Look"},
                        {new Guid("319073b6-f951-4c75-bcbc-7dbec5d2f226"), "F_PROM_P_IntActor_PizzaArcadeRankings_C1_Look"},
                        {new Guid("70547212-f3a1-4751-b149-f1167b8c11ee"), "F_PROM_P_IntActor_SharkStinger_C1_Look"},
                        {new Guid("142d18c3-fe02-42a8-bf25-82ae58185313"), "F_PROM_P_IntActor_SharkStinger_C2_Play"},
                        {new Guid("e4676ebc-9755-4238-8682-9222326c40f1"), "F_PROM_P_IntActor_Tv_C1_Look"},
                        {new Guid("0c5a1f4d-e585-4cda-9dbb-cb7adceba5a7"), "F_PROM_P_IntActor_Tv_D1_SwitchOn"},
                        {new Guid("de2687fc-9b36-4e98-9af4-c67caf5d6cd8"), "F_PROM_P_IntActor_Console_C1_Look"},
                        {new Guid("cc7464d8-62b9-4bd5-aadb-9886b2e73a34"), "F_PROM_P_IntActor_FirecrackerBox_C1_Look"},
                        {new Guid("0ca24614-ac58-46e8-951c-59def38bdd13"), "F_PROM_P_IntActor_VikingBook_C1_Look"},
                        {new Guid("26b929fa-e802-4652-93ef-03f54e0bd685"), "F_PROM_P_IntActor_ForestWarrior_C1_Look"},
                        {new Guid("f7a51360-db29-41c8-93d2-b07c1e9db136"), "F_PROM_P_IntActor_WishList_C1_Look"},
                        {new Guid("7f672c71-3bfc-4f2a-8ae4-36499b5a5390"), "F_PROM_P_IntActor_TeddyBear_C1_Look"},
                        {new Guid("5a89f47c-e3f5-44d1-ab0e-f4c0838d6b24"), "F_PROM_P_IntActor_DrawingManual_C1_Look"},
                        {new Guid("26cb3d95-b978-4fe7-855e-d3409dbb2872"), "F_PROM_P_IntActor_2_C1_Look"},
                        {new Guid("4083817f-dc79-4e41-b8fb-c8ee748dddab"), "F_PROM_P_IntActor_2_C2_Look"},
                        {new Guid("ccd2843b-36b0-4b6e-ae6d-a665094646e7"), "F_PROM_P_IntActor_2_C3_Look"},
                        {new Guid("17f86143-b7c5-4b3e-8ad3-9087cbd05bb3"), "F_PROM_P_IntActor_2_D1_Decypher"},
                        {new Guid("12ff1d61-2c38-4b79-8f0d-29656437b7ff"), "F_PROM_P_IntActor_Bag_C1_Look"},
                        {new Guid("b6aa4ba3-bb76-43af-8431-e770368e813b"), "F_PROM_P_IntActor_MantroidTeam_C1_Look"},
                        {new Guid("4210ad17-37fb-4564-ad94-ec4092a7fd31"), "F_PROM_P_IntActor_ComicFlyer_C1_Look"},
                        {new Guid("ac2ff522-5dcc-457d-82cf-3c252a51a031"), "F_PROM_P_IntActor_1_C1_Look"},
                        {new Guid("afc869c2-88f0-4f1c-8a80-1d68d8e9b188"), "F_PROM_P_IntActor_ActionFigures_C1_Look"},
                        {new Guid("a1a44c33-3868-4673-8bf6-7d6aee1c95bd"), "F_PROM_P_IntActor_ActionFigures_C2_Play"},
                        {new Guid("6d4311e8-2c51-4b54-912f-0d3aa7c8fe7a"), "F_PROM_P_IntActor_ActionFigures_C4_Look"},
                        {new Guid("0c322e14-6e1b-48df-8cba-4255596d20b3"), "F_PROM_P_IntActor_Weapons_C1_Look"},
                        {new Guid("31c08d0f-e7f2-4044-b298-24519d979b25"), "F_PROM_P_IntActor_FavoriteBook_C1_Look"},
                        {new Guid("8bc92885-9a3a-4a8b-853f-624ae54d670d"), "F_PROM_P_IntActor_WalkieTalkie_C2_Call"},
                        {new Guid("1dcbf52b-ee1c-4cbe-99e1-f26e08e23998"), "F_PROM_P_IntActor_WalkieTalkie_C3_Look"},
                        {new Guid("0fecdb61-f5d3-46cb-b51c-534b1a833def"), "F_PROM_P_IntActor_Trophy_C1_Look"},
                        {new Guid("d8a81c90-4c82-433c-ae04-09d17408194e"), "F_PROM_P_IntActor_ComicBooksShelf_C1_Look"},
                        {new Guid("945bcc8b-35ee-4356-8517-b31182ab9d4d"), "F_PROM_P_IntActor_BugsMotel_C1_Look"},
                        {new Guid("3f52641a-2198-49fc-851e-ce72df20f467"), "F_PROM_P_IntActor_DvdPile_C1_Look"},
                        {new Guid("53c05102-f3b3-4c78-bb3e-1be80095a24b"), "F_PROM_P_IntActor_ChrisWardrobeDoor_C1_Open"},
                        {new Guid("60d3d12d-276d-40ae-9430-a8bb75413e4e"), "F_PROM_P_IntActor_ChrisWardrobeDoor_C2_Close"},
                        {new Guid("b9089352-bf5e-4eb3-a285-e736444303d5"), "F_PROM_P_IntActor_AdventCalendar_C1_Look"},
                        {new Guid("aad3d520-7963-4250-8a6e-3f2bd6545432"), "F_PROM_P_IntActor_AdventCalendar_C2_Eat"},
                        {new Guid("f318ae50-f7d0-41ea-ad50-f0b8b1236888"), "F_PROM_P_IntActor_Cloak_C1_Look"},
                        {new Guid("09ddd962-bfa9-4051-85ad-8c5ae7d98515"), "F_PROM_P_IntActor_Cloak_D1_Wear"},
                        {new Guid("dd0b4a67-5a63-4f82-9687-b7f7dded3c3a"), "F_PROM_P_IntActor_MainDoor_C1_GetOut"},
                        {new Guid("04a33b10-939c-4fc0-bb0f-7c26be9a9008"), "F_PROM_P_IntActor_MainDoor_C2_GetOut"},
                        {new Guid("5e041ace-3d80-4807-892d-db8edd67729f"), "F_PROM_P_IntActor_MainDoor_C3_Getin"},
                        {new Guid("12242acb-26d0-49bf-8c31-c44687fa6574"), "F_PROM_P_IntActor_MainDoor_C4_Getin"},
                        {new Guid("a8d38f61-ecb2-40ae-ba12-a4a1781f6d37"), "F_PROM_P_IntActor_ChrisRoomDoor_C2_Open"},
                        {new Guid("7ca68e87-b508-4c8e-af9e-06d150c4a203"), "F_PROM_P_IntActor_Sofa2_C1_ZenSeqDad"},
                        {new Guid("f0cd7d0b-3217-4a91-b291-6055c2563a02"), "F_PROM_P_IntActor_Cellphone_C1_Look"},
                        {new Guid("92ba0be3-9ab0-4f47-962b-d5fe2c146c4e"), "F_PROM_P_IntActor_Cellphone_C2_Unlock"},
                        {new Guid("dcab3333-8f02-48ad-90f0-20c3cd68c476"), "F_PROM_P_IntActor_Cellphone_C3_Play"},
                        {new Guid("c5fea098-19be-44dd-83fd-1e1b3ddcbb08"), "F_PROM_P_IntActor_Tupperware_C1_Trash"},
                        {new Guid("2d5cf895-d489-4ffa-85ed-40f45fefa631"), "F_PROM_P_IntActor_Tupperware_C2_Look"},
                        {new Guid("a7a6e1cb-0657-4747-9f6b-68154e0f1a0f"), "F_PROM_P_IntActor_BeerCans_C1_Look"},
                        {new Guid("79735771-be4b-40d3-8140-218cdb3d42b0"), "F_PROM_P_IntActor_BeerCans_C2_Trash"},
                        {new Guid("bcbdc74d-70d5-4b81-964d-ec865a16cfd6"), "F_PROM_P_IntActor_ClosetCase_C1_Look"},
                        {new Guid("f9bd385c-bafe-49cc-8a82-1efe1db3aaf1"), "F_PROM_P_IntActor_LoveLetter_C1_Read"},
                        {new Guid("280e5306-5b56-47ed-b6a4-d57f6d2887b4"), "F_PROM_P_IntActor_BasketBallCloset_C1_Look"},
                        {new Guid("d5a03f81-c9f4-4bfa-94b7-7a57976fd844"), "F_PROM_P_IntActor_Pants_C1_Look"},
                        {new Guid("b24e947f-34f0-4847-8c1c-905f2f14c597"), "F_PROM_P_IntActor_Pants_C2_Take"},
                        {new Guid("95bf393f-decd-46d0-9f3f-d652d9253373"), "F_PROM_P_IntActor_Playbox_C1_Look"},
                        {new Guid("299503a1-24dc-4d8f-b912-156590008184"), "F_PROM_P_IntActor_HeightGauge_C1_Look"},
                        {new Guid("2d4e628e-d426-4b29-a137-4fb64a496b2a"), "F_PROM_P_IntActor_Closet_C1_Open"},
                        {new Guid("7018905e-43a0-4bca-871e-23d1c048dd3e"), "F_PROM_P_IntActor_Closet_C2_Open"},
                        {new Guid("228c4ea5-739b-40f9-9891-e041d1781260"), "F_PROM_P_IntActor_Closet_C3_Open"},
                        {new Guid("7d38f42b-42f7-4daf-ae07-433b12174e4e"), "F_PROM_P_IntActor_Cigarette_C1_Look"},
                        {new Guid("c1126c4b-fd90-4d07-8c86-5a77d01f64ea"), "F_PROM_P_IntActor_Cigarette_C2_Look"},
                        {new Guid("a3c6d5f5-d491-418f-a221-892f548513f8"), "F_PROM_P_IntActor_Cigarette_C3_Stealone"},
                        {new Guid("0ad8a68d-2939-4027-9e12-d3791aa66cef"), "F_PROM_P_IntActor_Cigarette_C4_Look"},
                        {new Guid("a58c2590-75c4-42a4-895e-648e39fa9ed7"), "F_PROM_P_IntActor_Record_C1_Play"},
                        {new Guid("055182a7-25d6-46de-9c71-7bc15ee0e7fd"), "F_PROM_P_IntActor_CharlesRoomChair_C1_Move"},
                        {new Guid("c80024f1-f2ce-4697-a3d8-3dedfc7444a4"), "F_PROM_P_IntActor_CharlesRoomTopBox_C1_Look"},
                        {new Guid("8290f18a-d09a-448f-9a18-e8baf4f2963f"), "F_PROM_P_IntActor_CharlesRoomTopBox_C2_Look"},
                        {new Guid("44e81be4-5988-4166-a212-5f0b3a7ffdbf"), "F_PROM_P_IntActor_SportBag_C1_Look"},
                        {new Guid("412ad762-de83-4c02-98e5-c67c0803729e"), "F_PROM_P_IntActor_SportBag_D1_Wear"},
                        {new Guid("28f107bf-7f5e-4103-a030-3253ed7ff285"), "F_PROM_P_IntActor_WardrobeKey_C1_Look"},
                        {new Guid("3a24802d-8261-4cd1-accb-5cffac3e2835"), "F_PROM_P_IntActor_WardrobeKey_C2_Take"},
                        {new Guid("55839482-9fe0-4af8-b0ba-5ad7342ca174"), "F_PROM_P_IntActor_CharlesRoomDrawing_C1_Look"},
                        {new Guid("7f440dbb-a24b-4ed6-a591-5d4dd5d86f5c"), "F_PROM_P_IntActor_Lamp_C1_Look"},
                        {new Guid("5177b891-7803-4bfc-9bd7-2b3e009796ac"), "F_PROM_P_IntActor_Lamp_C2_Fix"},
                        {new Guid("6e3feabf-1f98-4bb6-b446-5a47b8280f9a"), "F_PROM_P_IntActor_Lamp_C3_Turnon"},
                        {new Guid("16a31fa0-26df-4755-9b38-f23510239d03"), "F_PROM_P_IntActor_Lamp_C4_Turnoff"},
                        {new Guid("d823974d-28d7-4166-94b5-d8326e9d11c1"), "F_PROM_P_IntActor_Lamp_C5_Look"},
                        {new Guid("b6bde28c-e9b3-4fa6-a523-b7a76f34dca3"), "F_PROM_P_IntActor_Perfume_C1_Look"},
                        {new Guid("18e6fb1e-c973-4670-a2ae-6b34e1fd0b7c"), "F_PROM_P_IntActor_FistMark_C1_Look"},
                        {new Guid("b9241fb2-21a2-41a4-9c1f-f601ec82bc98"), "F_PROM_P_IntActor_CharlesBed2_C1_Look"},
                        {new Guid("548c2907-aef8-472d-aca1-3a1d3ad9a621"), "F_PROM_P_IntActor_CharlesBed_C1_Look"},
                        {new Guid("28f69a4b-56f8-4824-b5b8-3acbcd7b1bd1"), "F_PROM_P_IntActor_CharlesBed_C2_Liedown"},
                        {new Guid("ffc28a93-9ea5-4545-a2e4-2fdfa653776c"), "F_PROM_P_IntActor_CharlesBed_C3_Liedown"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "281819ef-e16f-42d4-9a59-6ec4a7b2df12", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("a7e8017d-0f47-4941-b63f-1d9275fcc717"), "F_PT_Metrics_ArmorChoice_IsLight"},
                        {new Guid("4b024dd2-15af-459d-b6fb-4ded315ffab1"), "F_PT_Metrics_ArmorChoice_IsHelmet"},
                        {new Guid("459934db-50de-4eb2-abf3-bf943c858529"), "F_PT_Metrics_ArmorChoice_IsColorful"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "ac49fe65-38d5-48c5-8dfd-6a845e0ee5da", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("5e13bfd0-506e-4702-92bd-6acc71c3ce68"), "Metrics_HawtDawgMan_StartedCount"},
                        {new Guid("ac551dee-b5bf-4e9e-9311-4af66be4ad1b"), "Metrics_SnowballThrownCount"},
                        {new Guid("dd56da98-f778-483c-a1c8-c8c3a1a313c3"), "Metrics_SnowballHitCount"},
                        {new Guid("1008b573-8244-44c6-a06d-8ebeda11f2fd"), "Metrics_HawtDawgMan_NewHighScore"},
                        {new Guid("cadc3e5b-a891-4762-92f9-05b1c22721bb"), "Metrics_SnowballMissCount"},
                        {new Guid("fbfd9a12-1845-41c2-bc17-405e7c97e198"), "Metrics_HawtDawgMan_Gameplayed"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("129936e5-922c-4122-97b5-4bed9683bb08"), "Metrics_SnowballAccuracy"},
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "c4363c23-73c5-4232-9978-1bdb00eaca0a", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("4f60b5c3-9083-4db2-a751-35b15397ac16"), "PT_EHOutside_Garage_FirecrackerCollected"},
                        {new Guid("022eb326-92ad-4914-bdc0-869a096f8a76"), "PT_EHOutside_TreeHouse_StashOpen"},
                        {new Guid("436a14e5-5ba1-4280-b43f-56d73c1be1b5"), "PT_EHOutside_TreeHouse_TransparentMapCollected"},
                        {new Guid("d6ff4203-0ec6-4a7c-ad24-cd99aaea0fb5"), "PT_EHOutside_Garage_SideDoorCrossed"},
                        {new Guid("ca43b8ee-2b8d-4680-9c4a-00fe6851d7ab"), "PT_EHOutside_Garage_SideDoorUnlocked"},
                        {new Guid("9b6b948c-9a30-4277-9b5e-f48e4d964214"), "PT_EHOutside_Garden_SnowCleared"},
                        {new Guid("fb184571-c934-4143-b4cc-f9e2a83a4891"), "PT_EHOutside_Garage_RaccoonStartled"},
                        {new Guid("4d0ebe9c-3e43-4607-a46e-ca213044eebd"), "PT_EHOutside_Garden_RangeSetup"},
                        {new Guid("b0349bee-2f04-4239-92fd-bb02b66f7478"), "PT_EHOutside_TreeHouse_Climbed"},
                        {new Guid("48a5ece0-7f71-4255-bcd1-9698e34474e4"), "F_PT_EHOutside_Garage_HeavyArmor_Equipped"},
                        {new Guid("8e592c2c-bf2c-4fa6-b9aa-3b615368292d"), "PT_EHOutside_Garden_GolemCemeteryComplete"},
                        {new Guid("0a41140d-430a-4ed0-9fbc-a7b3ecd0a396"), "PT_EHOutside_TreeHouse_ChrisSmoked"},
                        {new Guid("d64ce65e-1ef8-4fe1-85ce-4306652db1f0"), "F_PT_EHOutside_Garden_SnowmanBlownUp"},
                        {new Guid("3eeba2cc-d9ef-4150-a377-fe9ae3145057"), "F_PT_EHOutisde_Garage_VisitedPlanet"},
                        {new Guid("ee3f4196-abfd-4b27-95b5-c11835c79a36"), "F_PT_EHOutside_Garage_HeavyArmorSpotted"},
                        {new Guid("badc1b3a-2fac-49d1-b3c2-65b4339626de"), "F_PT_EHOutside_Garage_ReachedPlanetCrossroad"},
                        {new Guid("1a3f1bc8-01de-4152-991b-d043914a3cf2"), "PT_EHOutside_Garage_LockerUnlocked"},
                        {new Guid("6a50bf40-382b-4f76-bc92-e90af4fe6c63"), "F_PT_EHOutside_Garden_SnowmanTuned"},
                        {new Guid("2f7990a0-8551-49db-9460-659960659017"), "F_PT_EHInside_Garden_GolemEnteredOnce"},
                        {new Guid("f1822d62-8af6-4399-8fc7-8a677ad7a322"), "F_PT_EHOutside_Garage_LightOn"},
                        {new Guid("8a0c6051-a31b-4062-892c-481f925f6362"), "F_PT_EHOutside_Garden_IsShootingSnowBall"},
                        {new Guid("5ad8498f-955c-4bc0-8ffd-c17518fd034a"), "F_PT_EHOutside_Garden_SnowmanJoke"},
                        {new Guid("7dd636ff-d30a-4daa-aaa1-54876b6aab17"), "PT_EHOutside_Garden_HasShotAllCans"},
                        {new Guid("38f88506-43c7-4b31-8486-de7e226bad32"), "F_PT_EHOutside_TreeHouse_SkyPirateChecked"},
                        {new Guid("d2752c0e-1ec5-48e2-a444-e967fd3708a8"), "F_PT_EHOutside_TreeHouse_TransparentMapSeen"},
                        {new Guid("8c4bafef-bd5f-4703-b795-150514210acd"), "F_PT_EHOutside_TreeHouse_ChrisInZenSeqTree"},
                        {new Guid("7f00fdf0-f73c-4979-ad37-97cbba65f6aa"), "F_PT_EHOutside_TreeHouse_ChrisScreamedInZenSeq"},
                        {new Guid("a74233c3-111d-4b6e-b9cb-f70739eb3813"), "F_PT_EHOutside_Garden_SnowmancerChecked"},
                        {new Guid("595decb2-8cce-423f-8756-09c0c56f8745"), "F_PT_EHOutside_Garden_RangeSetupOnce"},
                        {new Guid("ef52d11f-4e9d-4649-b382-402afbbb5a3e"), "F_PT_EHOutside_Garage_PaintSpotted"},
                        {new Guid("8f5aa6fa-a93d-41d7-877b-27e71ca4481d"), "F_PT_EHOutisde_JogTutorialDone"},
                        {new Guid("655a79b4-af6e-4ddf-ab48-7dd2e5c8a068"), "F_PT_EHOutside_MantroidPlanet_IGEOneComplete"},
                        {new Guid("697ef10e-55a2-4ef5-8056-2077f9c44d39"), "F_PT_EHOutside_MantroidPlanet_IGETwoComplete"},
                        {new Guid("a2c4737a-8824-4eff-850d-faf7149be6b2"), "F_PT_EHOutside_MantroidPlanet_ExtraIGEPlaying"},
                        {new Guid("53260419-ad85-490a-aa0a-9c50d45e3edc"), "F_PT_EHOutside_MantroidPlanet_IGETwoPlaying"},
                        {new Guid("08040b27-93ee-412d-add8-d297f7b374b7"), "F_PT_EHOutside_MantroidPlanet_CanPlayExtraIGE"},
                        {new Guid("1cd2437f-06e4-4e11-9115-02bd94524efe"), "PT_CaptainSpiritQuestDone"},
                        {new Guid("7fce7bd7-acf9-4c88-be17-a1bc513dbce1"), "F_PT_EHOutside_ChrisIsInTheGarage"},
                        {new Guid("435bddb4-0d25-4975-b313-eb4883862902"), "F_PT_EHOutside_ChrisIsInTheTreeHouse"},
                        {new Guid("58484bf9-e89b-4ec6-8adb-aefe34543ddf"), "F_PT_EHOutside_ChrisIsInTheGolemCemetery"},
                        {new Guid("9e51afec-7dcb-43aa-9750-ba50810bd21b"), "F_PT_EHOutside_ChrisIsInMantroidPlanet"},
                        {new Guid("ed08c5fc-9ee6-40f3-a562-5b59dc82dd7a"), "F_PT_EHOutside_ChrisIsThrowingSnowball"},
                        {new Guid("44d69293-8a7d-4b39-97dd-76342c2f4203"), "F_PT_EHOutside_ChrisIsUsingTheLocker"},
                        {new Guid("b4165ee2-0d27-4da8-9bb7-549e669930cc"), "F_PT_EHOutside_TreeHouse_ChrisIsLyingInZenSeqTree"},
                        {new Guid("119fdfcb-4eef-4361-bca4-32618479b50e"), "PT_CaptainSpiritLogoDone"},
                        {new Guid("b4a57e76-5d7f-4b40-9da7-76134ee4fbf7"), "F_PT_EHOutside_TreeHouse_CustomEndingZenSeqTree"},
                        {new Guid("77524f1b-66fc-437e-8807-3ae7a65fe3a5"), "F_PT_EHOutside_Garage_BoxOpenedOnce"},
                        {new Guid("9596ecd3-837e-4012-b781-738a203c411f"), "F_PT_EHOutside_Garage_BinderOpenedOnce"},
                        {new Guid("6e5bfa8d-dd19-45cb-8ce5-db957f481546"), "F_PT_EHOutside_TreeHouse_ComicStripsSeen"},
                        {new Guid("b5c8e52c-4a3f-41bc-89e9-a4ba855bfca4"), "F_PT_EHOutside_MantroidPlanet_ChrisFaintByTimer"},
                        {new Guid("e52944ef-d6af-47f1-b092-471cf513fc5f"), "F_PT_EHOutside_Garage_FirecrackerSaveDoneOnce"},
                        {new Guid("ff52e3c0-8cdc-4eca-b4b4-a625232b04ca"), "F_PT_EHOutside_TreeHouse_TransparentMapSavedOnce"},
                        {new Guid("a68b2300-b2cf-41de-a1c0-d095fcc933ec"), "F_PT_EHOutside_TreeHouse_SequenceZenPlayed"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("927ea3da-c53e-4766-87da-e4bf754a73af"), "PT_EHOutside_Garden_GolemCemeteryProgress"},
                        {new Guid("65e829ae-82ad-46a7-93c3-b369794b4687"), "F_PT_CostumePartsCount"},
                        {new Guid("9ba457cd-d09e-498f-9271-1f0b43d0f4a7"), "F_PT_EHOutside_MantroidPlanet_MantroidCueCounter"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("25c7ddc7-63dd-4e89-97f0-2fc477a7cbd2"), "GolemCemeteryCurrentChoice"},
                    },
                }
            },
            {
                "de38cba6-0d68-40de-838e-30dd807ceba2", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("8277a06d-e5e2-4935-8e65-09e7d468cfe0"), "F_PROM_P_IntActor_WallHole_C2_Look"},
                        {new Guid("c5c26ec0-745c-4894-a184-0ab213003b1a"), "F_PROM_P_IntActor_WallHole_C1_Look"},
                        {new Guid("554e59a1-be23-4dd6-9fcd-50ef5e16db06"), "F_PROM_P_IntActor_TreeCarving_C1_Look"},
                        {new Guid("a656d09b-2ea0-441d-9d5b-1faa49c86623"), "F_PROM_P_IntActor_Shovel_C1_ClearSnow"},
                        {new Guid("8e3e3bf8-ada6-421e-9279-6bd71ed54f59"), "F_PROM_P_IntActor_Shovel_C3_Look"},
                        {new Guid("5fb0ce10-9a58-406a-860f-7dc8d76ebb7c"), "F_PROM_P_IntActor_ReynoldsHouse_C1_Look"},
                        {new Guid("5a073712-a9db-4720-9720-1bfd5fd317ad"), "F_PROM_P_IntActor_Raccoon_C1_Look"},
                        {new Guid("9c89c203-7ba8-4d01-86f2-c522cf896b3a"), "F_PROM_P_IntActor_Mailbox_C1_Open"},
                        {new Guid("6c7bd675-6cd2-4675-846e-88a350bfabb2"), "F_PROM_P_IntActor_HikingBoots_C1_Look"},
                        {new Guid("3c548cac-53eb-4202-b11a-4591221ea73f"), "F_PROM_P_IntActor_GraffitiHouse_C1_Look"},
                        {new Guid("ef64bfa8-4b06-4c57-80a4-93003d9a2791"), "F_PROM_P_IntActor_GarageMainDoor_C1_Look"},
                        {new Guid("94497530-396e-48e5-8a1b-6edf7cad2ddb"), "F_PROM_P_IntActor_GarageMainDoor_D1_Open"},
                        {new Guid("5f003637-7cc2-47c7-aacd-2a1c5466cc83"), "F_PROM_P_IntActor_GarageLightSwitch_C1_TurnOn"},
                        {new Guid("5a0ad5e6-79cb-4357-b354-923420a303a0"), "F_PROM_P_IntActor_GarageLightSwitch_C2_TurnOff"},
                        {new Guid("a910b809-acb1-4955-bde3-410f86262406"), "F_PROM_P_IntActor_CreepyTree_C1_Look"},
                        {new Guid("c9991030-7c7e-4e32-a4cf-b6fb456ffb4d"), "F_PROM_P_IntActor_BrokenSwing_C1_Look"},
                        {new Guid("2a4460b0-5dce-4abc-9670-c4e39fa715e5"), "F_PROM_P_IntActor_SchoolLetters_C1_Look"},
                        {new Guid("83328e56-24f5-435e-9b56-47f451292fbf"), "F_PROM_P_IntActor_BaseBallCard_C1_Look"},
                        {new Guid("3123b26a-29ce-4125-983d-da7356aec4e4"), "F_PROM_P_IntActor_TransparentMap_C1_Look"},
                        {new Guid("7c3a2c65-6fca-4e4b-9991-4051f355c091"), "F_PROM_P_IntActor_TransparentMap_C2_Take"},
                        {new Guid("745f25bc-5992-4b65-b9aa-5a764a1e6fdf"), "F_PROM_P_IntActor_Binder_C1_Look"},
                        {new Guid("900e30c5-4914-4925-ad13-9836cb18cc2d"), "F_PROM_P_IntActor_GrandParentsLetterGarage_C1_Look"},
                        {new Guid("aefb4300-0d6f-41f3-a0bc-7730829c05b0"), "F_PROM_P_IntActor_ComicStripTreeHouse_C1_Look"},
                        {new Guid("68b7cdbc-fddb-4312-9221-3cc919c96c14"), "F_PROM_P_IntActor_BinderGarage_C1_Look"},
                        {new Guid("74e01338-5249-4128-942e-e5bf2e0765a7"), "F_PROM_P_IntActor_BoxGarage_C1_Look"},
                        {new Guid("1c52872d-90df-408f-b7a4-c639df07e320"), "F_PROM_P_IntActor_SnowMan_C1_Look"},
                        {new Guid("e85a04a9-4fff-4533-a31f-5fd3e92b1f0c"), "F_PROM_P_IntActor_SnowMan_C2_Tune"},
                        {new Guid("fb60b121-bcf3-4783-afb9-b36eeb7aef92"), "F_PROM_P_IntActor_SnowMan_C3_Look"},
                        {new Guid("d83aab84-6295-442a-b697-573036ec5edb"), "F_PROM_P_IntActor_SnowMan_D1_BlowUp"},
                        {new Guid("70093e5e-3896-4fa6-bc95-95b2c33adfa6"), "F_PROM_P_IntActor_SnowMan_D2_BlowUp"},
                        {new Guid("6bd05eea-e0c5-49d3-ab86-8dca87d8802e"), "F_PROM_P_IntActor_SideDoor_C1_Open"},
                        {new Guid("5007ceb8-f394-4f8c-9fc7-4315e829280e"), "F_PROM_P_IntActor_SideDoor_C2_Open"},
                        {new Guid("92e1b351-3b79-495b-b42c-ca5a7f09cc1f"), "F_PROM_P_IntActor_SideDoor_C3_Open"},
                        {new Guid("e68ba174-c775-45ef-a667-5ac2a5ef9e62"), "F_PROM_P_IntActor_SideDoor_C4_Open"},
                        {new Guid("a4172f62-52e7-4d64-947b-5959cd296173"), "F_PROM_P_IntActor_SprayPaint_C1_Look"},
                        {new Guid("53436609-1102-4919-8a74-0fe11c58a24b"), "F_PROM_P_IntActor_SprayPaint_C3_Look"},
                        {new Guid("a7c8fd5a-9e13-4be7-a5fa-1c2cee3c8be7"), "F_PROM_P_IntActor_SprayPaint_D1_Use"},
                        {new Guid("dad757d7-94bc-4aae-a138-1e4137105689"), "F_PROM_P_IntActor_BeerCardboard_C1_Look"},
                        {new Guid("dd7fb14a-f3ac-43f9-9c5a-2dbf6e634880"), "F_PROM_P_IntActor_BeerCardboard_D1_Wear"},
                        {new Guid("e5879fea-c704-427e-adee-f809eb756722"), "F_PROM_P_IntActor_Spiritmobile_C1_Look"},
                        {new Guid("ded602b0-00a9-48fc-81b1-feeb6f2dc665"), "F_PROM_P_IntActor_Spiritmobile_C2_Look"},
                        {new Guid("083b5667-deb4-49e8-888a-f0d0326af393"), "F_PROM_P_IntActor_Spiritmobile_C3_Inspect"},
                        {new Guid("851b2c5f-306a-4a59-a478-113e41a96368"), "F_PROM_P_IntActor_Spiritmobile_D1_PowerDrive"},
                        {new Guid("65f74e2c-1f38-40b1-a279-496aae8dad92"), "F_PROM_P_IntActor_Spiritmobile_D2_PowerDrive"},
                        {new Guid("04a17d28-b05d-4c22-99ce-4060156ce604"), "F_PROM_P_IntActor_GolemCemetary_C1_Look"},
                        {new Guid("25437cc1-457f-4204-b38a-658a2d22165a"), "F_PROM_P_IntActor_GolemCemetary_C2_Look"},
                        {new Guid("5c018e5f-7423-469b-bb7b-23750b07c9f2"), "F_PROM_P_IntActor_GolemCemetary_C3_Enter"},
                        {new Guid("55f9a441-acbc-4ce5-bf00-4a5cc94dffc2"), "F_PROM_P_IntActor_GolemCemetary_C4_Enter"},
                        {new Guid("2b779643-6604-4d4f-9888-a649d16761ba"), "F_PROM_P_IntActor_Firecracker_C1_Look"},
                        {new Guid("4b1854d7-cba7-4b0e-8899-a0627c23c966"), "F_PROM_P_IntActor_Firecracker_C2_Take"},
                        {new Guid("d98427e0-1a91-4ecb-b856-fd61e1377064"), "F_PROM_P_IntActor_Doll_C1_Look"},
                        {new Guid("311fc1e4-cd57-45fe-97e1-bec57d8ecdbf"), "F_PROM_P_IntActor_Noctared_C1_Look"},
                        {new Guid("8231f771-c6fc-4561-9ea8-852929d21ecd"), "F_PROM_P_IntActor_Lookout2_C1_SitALT"},
                        {new Guid("67c71436-74c0-44e2-a231-78ab3f57747a"), "F_PROM_P_IntActor_locker_C1_Open"},
                        {new Guid("2d6b8217-95b4-48c5-b228-76e8c0060119"), "F_PROM_P_IntActor_locker_C2_Open"},
                        {new Guid("d04b5029-8ccd-4edd-8fe0-c44c21e0cb58"), "F_PROM_P_IntActor_Range_C2_SetupRange"},
                        {new Guid("2fcd87de-2697-4d93-aace-1b78b43c558c"), "F_PROM_P_IntActor_padlock_C1_Look"},
                        {new Guid("fb31bfb1-14cd-4a69-9a18-4666627c5774"), "F_PROM_P_IntActor_padlock_C2_Unlock"},
                        {new Guid("119074f0-a71b-42ef-b033-40557cdb6ee7"), "F_PROM_P_IntActor_LadderGoUp_C1_Look"},
                        {new Guid("2a9c7874-131c-471d-9fe0-095d36c124ed"), "F_PROM_P_IntActor_LadderGoUp_C2_Goup"},
                        {new Guid("c2a9ab5c-d5c9-4bd3-b34e-5ee74b282b7a"), "F_PROM_P_IntActor_SkyPirate_C1_Look"},
                        {new Guid("b6950e2b-75e6-4f9d-9024-7dc858fffc09"), "F_PROM_P_IntActor_SkyPirate_C2_Look"},
                        {new Guid("274da36e-c72a-49ad-b472-19e461bfe815"), "F_PROM_P_IntActor_SkyPirate_C3_Check"},
                        {new Guid("cb7968a3-6fb3-442c-b48c-30a34c6ed4ae"), "F_PROM_P_IntActor_SecretStash_C1_Look"},
                        {new Guid("b767bbe8-7817-4c61-b0a7-352ebc763882"), "F_PROM_P_IntActor_SecretStash_D1_Open"},
                        {new Guid("cb5f0adb-2f92-4688-b322-97b9217238ab"), "F_PROM_P_IntActor_Lookout_C1_Sit"},
                        {new Guid("a1379e66-0462-44ff-a101-aab8fe186c0b"), "F_PROM_P_IntActor_Lookout_C2_Sit"},
                        {new Guid("d8da7dab-42d9-4876-9422-693b248d8800"), "F_PROM_P_IntActor_Ashtray_C1_Look"},
                        {new Guid("efcc8443-8db1-4a64-93d8-4b2a9042a968"), "F_PROM_P_IntActor_Ashtray_C2_LightCigarette"},
                        {new Guid("041a2294-75cd-4833-8997-68b4f61bec73"), "F_PROM_P_IntActor_LadderGoDown_C1_Godown"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
        };

        public static Dictionary<string, FactAsset> LIS2_FactAssets = new Dictionary<string, FactAsset>()
        {
            {
                "6c55f64d-7841-41b9-8923-2e689cef42bb", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("77da5163-440a-445c-b01c-15dabc149881"), "F_E1_6A_Inside_InsertionFirstTalk_C"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("38b3bc29-7cc7-4e80-b325-18a7a00049d1"), "F_E1_6A_Inside_InsertionFirstTalk_BrodyStatus"},
                        {new Guid("13677780-72c4-41ed-a561-076d56ff5daf"), "F_E1_6A_Inside_InsertionFirstTalk_DogChoice"},
                        {new Guid("96a33ac4-0969-4e43-95de-746af8436091"), "F_E1_6A_Inside_InsertionFirstTalk_DogChoiceName"},
                        {new Guid("d13dfe23-add0-4c4b-9548-c169f3a96d8c"), "F_E1_6A_Inside_InsertionFirstTalk_FirstChoiceChitchat"},
                        {new Guid("f5950514-5578-4119-ba49-1fac5c06bc5e"), "F_E1_6A_Inside_InsertionFirstTalk_LearnBrody"},
                        {new Guid("eeadfb02-97ed-477c-9e1a-5d5503a65c49"), "F_E1_6A_Inside_InsertionFirstTalk_PastLife"},
                        {new Guid("0e7725ca-184f-4655-b853-da49ac4ba710"), "F_E1_6A_Inside_InsertionFirstTalk_SeanChooseDogName"},
                    },
                }
            },
            {
                "bb00a9b7-9de1-46eb-affd-519593939409", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("1a3ad35d-086b-48c9-b2a6-34f2c63a48c2"), "F_PROM_MovePlayerTutoDone"},
                        {new Guid("6efd17f0-1465-4da4-83a3-9fa320e83fff"), "F_PROM_MoveCamTutoDone"},
                        {new Guid("76466cb2-18ad-4d68-b398-3d8deac3e913"), "F_PROM_DrawSeq_SwitchTutoFirstTime"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "28e20483-f626-42d2-9710-4f1b89eb6088", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("5df71635-9b8b-4544-8c89-42a085eac04b"), "F_PROM_DisableCollectiblePage"},
                        {new Guid("c139422e-8329-49cb-8622-d7f8784f4509"), "F_PROM_DisableJournalPage"},
                        {new Guid("e8fb9b80-5aa9-471f-9bc4-b2bc51a7dbb1"), "F_PROM_DisableMapPage"},
                        {new Guid("a8f503e9-eb8f-4091-b155-bd9c91e57d8a"), "F_PROM_DisablePhonePage"},
                        {new Guid("74f295bc-caed-46fa-b6d1-2b3b00b135a5"), "F_PROM_SeanIsInside"},
                        {new Guid("0abc92af-8b9f-4bbe-af57-8f59707496e6"), "F_PROM_DanielIsInside"},
                        {new Guid("f09bbb17-9ffe-4e8c-861e-e4f84e90c25f"), "F_PROM_SeanBag"},
                        {new Guid("1ddcd244-8d09-4b98-b3de-b0c558d2aae3"), "F_PROM_DisplayHiddenHowToPlayPages"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("68dfb6c1-5aea-4362-ad3c-9bfdf52ae4b1"), "F_PROM_E1_StealCount"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("c68a73d0-7181-4924-994a-2833a01adc09"), "F_PROM_CashInInventory"},
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("2fcee5b9-780f-40f8-abef-dee6c03b9fe2"), "F_PROM_SeanIdleBreakMood"},
                        {new Guid("b163b7e1-00c8-4eb0-b743-a2b24489b6ac"), "F_PROM_DanielIdleBreakMood"},
                        {new Guid("af8ead6c-83f7-41bc-86ff-5337c6e45c96"), "F_PROM_Phone_BatteryState"},
                        {new Guid("226d21be-2085-4231-a872-da685fda0a65"), "F_PROM_Phone_NetworkState"},
                        {new Guid("1bb65379-cfac-4547-9b49-ac7f0c62a830"), "F_PROM_Mat_Sean_Head_Dirt"},
                        {new Guid("0656087d-382a-411a-bf1f-6d169a3136dc"), "F_PROM_Mat_Sean_Pants_Dirt"},
                        {new Guid("b749c972-4844-4ae7-a0a6-8013bcae835b"), "F_PROM_Mat_Sean_Shoes_Dirt"},
                        {new Guid("c5081677-4ac0-4b83-bc90-3a96d5d0204e"), "F_PROM_Mat_Sean_Tshirt_Dirt"},
                        {new Guid("fae59b18-6801-4fa6-b306-dcb87cd2d007"), "F_PROM_Mat_Sean_Arms_WrittenList"},
                        {new Guid("b1003009-473c-48fe-adab-53ccb64bf5d1"), "F_PROM_Mat_Daniel_Head_Dirt"},
                        {new Guid("fc423ee2-1051-4662-b7a8-27754541c130"), "F_PROM_Mat_Daniel_Pants_Dirt"},
                        {new Guid("55d1ee63-1030-4599-b62e-870531031fcd"), "F_PROM_Mat_Daniel_Tshirt_Dirt"},
                        {new Guid("3f51a135-9876-42b3-9fb3-b6d6c3dc0b3e"), "F_PROM_Mat_Daniel_Shoes_Dirt"},
                        {new Guid("596ca364-af0b-4ecb-83b3-a144dfe8e0c0"), "F_PROM_Mat_Sean_Head_FX"},
                        {new Guid("b934f063-7151-4adc-8869-0dda94ed78b9"), "F_PROM_Mat_Daniel_Arms_Dirt"},
                        {new Guid("c73fa80f-e764-416b-93d7-2a104d9a55a5"), "F_PROM_Mat_Sean_Arms_Dirt"},
                        {new Guid("309bbda2-e182-45c3-be3b-4b075c17955c"), "F_PROM_Mat_Sean_Arms_Cuts"},
                        {new Guid("c8761ee8-0b1e-4010-8012-64da6857b1dd"), "F_PROM_Mat_Daniel_Arms_Blush"},
                        {new Guid("6c43d539-160f-4ae9-aec7-b7ff165a0f5e"), "F_PROM_Mat_Sean_Arms_Blush"},
                        {new Guid("57150b82-e4c2-43bc-8128-e9ecc0c48ae4"), "F_PROM_Mat_Daniel_Arms_Cuts"},
                    },
                }
            },
            {
                "a1ae06c3-2da3-40b4-b2ec-afa897c3ad59", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("e3ee31b1-cc47-4a15-bfcf-767081dae3a4"), "F_ACH_E1_OnTheRoadAgain"},
                        {new Guid("2e7ee17d-038b-4e47-9422-1251b497f55c"), "F_ACH_E1_Supporter"},
                        {new Guid("ccb0c1d5-8173-4ac3-ae71-f64c432d7f6d"), "F_ACH_E1_WildlifeProtector"},
                        {new Guid("57a61f81-fe7c-41f3-bc9a-684bea9b8656"), "F_ACH_E1_TheSketchyWay"},
                        {new Guid("87f75924-efda-412d-8454-20b8a2d6d0fe"), "F_ACH_E1_BearGang"},
                        {new Guid("58860169-feef-4b12-8009-185cacd2fc8e"), "F_ACH_E1_LuckyCharm"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "8ef75771-96ef-41b1-8e6b-47b31c7835a2", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("5172a55e-e3b7-4982-9a41-0e1842364ec6"), "F_PROM_E1_2A_Journal_DetailsDone"},
                        {new Guid("f5ac5af6-5720-4062-865a-d9faf595b56e"), "F_PROM_E1_2A_Journal_RoughDone"},
                        {new Guid("01eeedf3-8a90-4695-b8f6-6d6e730d354a"), "F_PROM_E1_7A_Journal_RoughDone"},
                        {new Guid("7eeb459b-da01-4534-b105-b37c981823d2"), "F_PROM_E1_7A_Journal_DetailsDone"},
                        {new Guid("d457a4c0-ffc2-4dc0-b435-b9e1a2395ee6"), "F_PROM_E1_2A_DrawSQCFinished"},
                        {new Guid("d8d373af-d234-444c-b4c8-4715c53bff6b"), "F_PROM_E1_7A_DrawSQCFinished"},
                        {new Guid("1b416551-37cc-4033-a91e-cf74a1dabd4a"), "F_PROM_DrawSeq_FirstLaunch"},
                        {new Guid("763108d1-16c4-4f0e-bcb0-0578f2e3b6a7"), "F_PROM_DrawSequenceAborted"},
                        {new Guid("184d70e7-7b85-4e98-8e42-5f052e81e3f3"), "F_PROM_DrawSeqTuto_DrawOnce"},
                        {new Guid("660d6c56-37e7-49b2-a17b-0071666488fc"), "F_PROM_E1_1A_Journal_DetailsDone"},
                        {new Guid("75f3a89b-bccb-4b05-9cee-3fcfcd6067cd"), "F_PROM_E1_1A_Journal_RoughDone"},
                        {new Guid("2bf78da0-9955-41dd-8e38-8a91159d64e8"), "F_PROM_E1_1A_DrawSQCFinished"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("6c2e9d98-842b-4316-9575-1f592972c86e"), "F_PROM_DrawSeqTuto_Steps"},
                    },
                }
            },
            {
                "c4a76bc0-7a1a-426f-aa2c-6241c7019ffb", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("3a07565e-3240-47b7-855b-1251aa172212"), "F_PROM_LIS1_SacrificeArcadiaBay"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "c02d73d9-774a-4ecd-9cd8-20dece6fda46", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("0000d292-673b-4a40-8861-ee4aeb5c1226"), "F_E1_1A_GotSoda"},
                        {new Guid("f7114fe7-119c-4631-b770-b22dcb98e23b"), "F_E1_1A_GotChips"},
                        {new Guid("4010b7e3-d5d2-4ca6-8086-461720baf01b"), "F_E1_1A_GotCookies"},
                        {new Guid("23541e7e-0914-4df7-a954-6e045a894d81"), "F_E1_1A_GotBlanket"},
                        {new Guid("743889e7-93ff-4970-935a-fa1674258285"), "F_E1_1A_SeanRoom_GPSit"},
                        {new Guid("7bcea34c-7a9f-408f-a2e7-939e78ee90b0"), "F_E1_1A_GotMoney"},
                        {new Guid("479e6d3e-9c1e-4041-80ff-f769f8e29e31"), "F_E1_1A_SchoolBagPacked"},
                        {new Guid("d8587c69-15e1-4c67-ac70-c75a1038c482"), "F_E1_1A_JennFacebookUnlock"},
                        {new Guid("6d0ac468-9ba6-4dd4-98dc-1ad1326554db"), "F_E1_1A_DialForbiden"},
                        {new Guid("d7c29ffa-49ca-47b3-99ec-0b305f89282c"), "F_E1_1A_MusicPlaying"},
                        {new Guid("28b746c0-1ba6-4e31-a1ee-f548c6d0741d"), "F_E1_1A_DrawingLyla"},
                        {new Guid("f402986f-9dce-4718-8836-298160dc24bf"), "F_E1_1A_Laptop_InDial"},
                        {new Guid("e90b0625-30c8-446b-a163-ba500b7c7a93"), "F_E1_1A_Laptop_InSequence"},
                        {new Guid("cc9d2d92-1ddb-4d66-ac68-95341881a5e3"), "F_E1_1A_Laptop_ReactWindow"},
                        {new Guid("add88076-0c14-4380-8de2-3eff8e943ef9"), "F_E1_1A_Laptop_AllowShowDrawing"},
                        {new Guid("1b931e04-0a28-4da3-98a0-feeb311f5bf2"), "F_E1_1A_Textmessage_FRNDSkype"},
                        {new Guid("9cf9ed69-5c27-4a6a-b824-415da1b0995c"), "F_E1_1A_Laptop_NoiseOutside"},
                        {new Guid("c0a1c597-af8e-4be6-ad52-0a9e98c3e4e6"), "F_E1_1A_SeanDownstairs"},
                        {new Guid("619d5d3b-f564-4190-88b8-5a0fc3448a9a"), "F_E1_1A_LaundryLightOn"},
                        {new Guid("ed19f6aa-bc3b-41aa-8909-e2eaeaa3d47e"), "F_E1_1A_SeanOutside"},
                        {new Guid("bbedfb2e-5e85-495d-88a7-cb31b70efde0"), "F_E1_1A_SeanInSeanRoom"},
                        {new Guid("e393ddce-e712-4b21-8ee4-559f2aa9eb0f"), "F_E1_1A_Jar_AddMoneyActive"},
                        {new Guid("526b64d8-284f-4f85-86ec-b94b963bbd64"), "F_E1_1A_TextMessage_DadInsertion"},
                        {new Guid("c84429fc-2020-4462-b0fe-98d58c9e54f6"), "F_E1_1A_TextMessage_FRND02Insertion"},
                        {new Guid("2ea0b1c9-a2b9-4253-a70b-304fb62c7ed9"), "F_E1_1A_Textmessage_FRND06_After"},
                        {new Guid("8046a18a-835d-410d-8f5e-50400810a294"), "F_E1_1A_SearchingForTools"},
                        {new Guid("d0c50f3b-e1e7-420e-93bf-77e106247d7d"), "F_E1_1A_InDialWithDad"},
                        {new Guid("8327f84a-d39a-4269-9039-a4b820212dca"), "F_E1_1A_SMS_FRND06_Seen"},
                        {new Guid("89a857d9-66dc-485c-b28e-ff3fe9432371"), "F_E1_1A_SMS_FRND_Seen"},
                        {new Guid("a51fdf50-24d5-48bf-8f9d-6108c48b03e7"), "F_E1_1A_Laptop_LylaReact"},
                        {new Guid("c7f9024b-9afe-4d9f-a9ab-4bdde43a8f13"), "F_E1_1A_GotBeers"},
                        {new Guid("7cc63a4b-47e6-4bd3-8b88-6c9e1f588b99"), "F_E1_1A_ToolPuzzle_HintReversible"},
                        {new Guid("2362749a-e5fa-40db-a9d3-d9c48bdc139b"), "F_E1_1A_jar_StealActive"},
                        {new Guid("d29974b0-1159-4641-97cc-9c3e9ace934b"), "F_E1_1A_ShouldLaunchDrawingChoice"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("f20f1307-be7d-4f21-bdc5-ce6d62e606c7"), "F_E1_1A_ToolGiven"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("05c6ade7-09af-40a0-be9c-20ab498d118a"), "F_E1_1A_RadioSourcePosition"},
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("eec95e99-f8eb-4fee-87da-f033dc4a63c9"), "F_E1_1A_ToolInHand"},
                    },
                }
            },
            {
                "cec79f2a-2731-4b18-8152-56b4c63311c5", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("e32ea805-7be8-44ff-8396-6c4491d550d0"), "F_E1_1A_HouseFront_ChillSteps_C"},
                        {new Guid("01735097-aa30-4604-aa5d-b52e7d478399"), "F_E1_1A_Kitchen_EnterHouse_C"},
                        {new Guid("f9a86b67-0b52-4b7b-9b65-eba4352c2f7d"), "F_E1_1A_Garage_DadDial_C"},
                        {new Guid("8a5a2bde-9f53-4b02-8a33-a7cb9a2faaf4"), "F_E1_1A_SeanRoom_SkypeJennDial_C"},
                        {new Guid("aa7c9537-b18b-49e8-a16b-e501b0f6c4af"), "F_E1_1A_DanielRoom_Knock_C"},
                        {new Guid("60bb476c-cf86-4ae7-a6a0-2e6f82a92faa"), "F_E1_1A_Garage_DadAskForTool_C"},
                        {new Guid("2170ba23-f664-4970-8c27-5d2e554a863b"), "F_E1_1A_SeanRoom_DanielKickOut_C"},
                        {new Guid("60a34089-b770-4571-a33e-1ec1e2910be8"), "F_E1_1A_SeanRoom_JennPost_C"},
                        {new Guid("516620b3-26de-4880-a718-1f7e7deb6d7f"), "F_E1_1A_SeanRoom_AfterJennPost_C"},
                        {new Guid("47c32e56-540d-4c16-b77f-a834f62133ee"), "F_E1_1A_Garage_EmptyDrawer_C"},
                        {new Guid("dae77557-6031-4ae0-a9ac-2d73c30270b3"), "F_E1_1A_Garage_Chitchat01_C"},
                        {new Guid("59df54ad-3480-4e1f-9372-855b38a49ffa"), "F_E1_1A_Garage_ToolHint01_C"},
                        {new Guid("234ee765-94e3-45e1-93f4-e048f4a5f9ea"), "F_E1_1A_SeanRoom_SkypeDrawing_C"},
                        {new Guid("a007d660-3ed7-42dc-8e41-77389740e978"), "F_E1_1A_SeanRoom_LylaReact_C"},
                        {new Guid("374c9a34-9937-4fb8-8c4b-ef521fd85417"), "F_E1_1A_Garage_Chitchat02_C"},
                        {new Guid("c7488cef-a1c7-44c8-bd04-8257115ee27f"), "F_E1_1A_Garage_ToolHint02_C"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("51360b98-821c-4371-9205-30cbf60e39ec"), "F_E1_1A_HouseFront_ChillSteps_Smoke"},
                        {new Guid("a2203b2d-1888-4430-94e1-c8bf1e1afc38"), "F_E1_1A_HouseFront_ChillSteps_Drawing"},
                        {new Guid("a401cff3-50df-49a4-aad1-4f5fe6cec702"), "F_E1_1A_HouseFront_ChillSteps_FriendForever"},
                        {new Guid("077bb93a-5fc1-4647-b1e4-27cb41934498"), "F_E1_1A_Kitchen_EnterHouse_Chocobar"},
                        {new Guid("8aaf2ef7-e301-4e2b-b077-a1672076edfb"), "F_E1_1A_Garage_DadDial_Party"},
                        {new Guid("f835b770-0f80-4514-868a-aeab8fe57ebb"), "F_E1_1A_Garage_DadDial_Future"},
                        {new Guid("a69419cc-7233-433f-ae3c-371ab73c00a8"), "F_E1_1A_Garage_DadDial_SeanCar"},
                        {new Guid("51187f9a-0ba9-4fa1-b3d2-fdc45b9e3b42"), "F_E1_1A_Garage_DadDial_MoreInfo"},
                        {new Guid("4ea2d694-8304-4e9a-80ee-b5f0d8310a23"), "F_E1_1A_Garage_DadDial_HugDad"},
                        {new Guid("007f44e7-f4c8-40d2-a26b-84ca3abb387e"), "F_E1_1A_SeanRoom_SkypeJennDial_JennChoice"},
                        {new Guid("5db981e3-4669-426c-b903-379cca53be86"), "F_E1_1A_DanielRoom_Knock_DanielBusy"},
                        {new Guid("aff06794-d54b-4174-bef3-e0359dab0ab9"), "F_E1_1A_DanielRoom_Knock_DanielAskAboutLyla"},
                        {new Guid("13c269d5-5b17-4888-9051-eb62b728206f"), "F_E1_1A_Garage_DadAskForTool_WhoIsIt"},
                        {new Guid("85ba6a50-6393-4caa-b0ac-ff5919cf7c45"), "F_E1_1A_SeanRoom_DanielKickOut_LylaMad"},
                        {new Guid("bf64fa71-b6d6-4cea-b03f-0a979d2a31a2"), "F_E1_1A_Garage_ToolHint01_DadAsk"},
                        {new Guid("5014fde2-77d8-44d8-bd2f-9434a33ada07"), "F_E1_1A_SeanRoom_SkypeDrawing_DrawingChoice"},
                        {new Guid("a1fd8986-5788-47c3-8b4a-4249e7cb20af"), "F_E1_1A_LevelChoice_Facebook"},
                        {new Guid("856c55f3-5197-49fa-9f41-d1968d500ff7"), "F_E1_1A_LevelChoice_BrettFight"},
                    },
                }
            },
            {
                "96169c2a-2532-4a82-800b-4b18dfacb941", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("07c8fc58-a4d2-44e6-8f54-2625231d5756"), "F_E1_1A_IntActor_GarageDrawer_C1_Open"},
                        {new Guid("83b4b880-8e97-4de1-841e-12bc5ffc80fe"), "F_E1_1A_IntActor_RightTool01_C1_Take"},
                        {new Guid("f6169c03-ed1a-491c-8299-7f84d426210d"), "F_E1_1A_IntActor_RightTool01_C2_Look"},
                        {new Guid("d99b861b-c313-4461-a067-22fed1aafd1c"), "F_E1_1A_IntActor_WrongTool01_C2_Look"},
                        {new Guid("a8d1dd3a-276d-4dee-a31e-12e69da0cc91"), "F_E1_1A_IntActor_WrongTool03_C2_Look"},
                        {new Guid("5fde135c-7997-4f4f-91d6-a5b2e88896be"), "F_E1_1A_IntActor_WrongTool05_C2_Look"},
                        {new Guid("4509a605-4d7d-4e09-a4ec-09e275b1106c"), "F_E1_1A_IntActor_WrongTool06_C2_Look"},
                        {new Guid("b6e0ff7f-23cc-40ec-884f-d6c6323c6393"), "F_E1_1A_IntActor_WrongTool07_C2_Look"},
                        {new Guid("0724b3fc-ad7f-4339-8c46-213ad19cd9be"), "F_E1_1A_IntActor_Laptop_C1_CallLyla"},
                        {new Guid("863c6451-a363-4607-b5f9-19e07f88a0c2"), "F_E1_1A_IntActor_Laptop_C2_Use"},
                        {new Guid("9ef0f46e-43aa-4e1f-927f-c711ad66d0c1"), "F_E1_1A_IntActor_Laptop_C3_Facebook"},
                        {new Guid("435570ea-60ee-4aff-91f5-3646a17b045d"), "F_E1_1A_IntActor_WallTag_C1_Look"},
                        {new Guid("4b158185-06d1-4333-a2cf-0aab173c4202"), "F_E1_1A_IntActor_Fridge_C1_Open"},
                        {new Guid("bc919e50-44a6-46e6-bc22-7d516b4b428c"), "F_E1_1A_IntActor_DanielRoom_C1_Knock"},
                        {new Guid("9b75c206-f7c3-4a74-99db-a06d1118ebf9"), "F_E1_1A_IntActor_DanielRoom_C2_Open"},
                        {new Guid("8b3f7a80-70d0-47c9-96f0-2decf366ba6b"), "F_E1_1A_IntActor_Dad_C1_GiveTool"},
                        {new Guid("46f6157c-082f-4dd0-b5f5-237609230925"), "F_E1_1A_IntActor_Cupboard01_C1_Open"},
                        {new Guid("6c213096-e557-4371-8cb5-66ac201497e4"), "F_E1_1A_IntActor_SeanBackpack_C1_Pack"},
                        {new Guid("4e6ca510-d2e5-4173-abc2-071a3d2f5a48"), "F_E1_1A_IntActor_SeanBackpack_C2_Look"},
                        {new Guid("a03c83e6-2113-47e8-9ff6-aeca41233d31"), "F_E1_1A_IntActor_Sodas_C1_Take"},
                        {new Guid("f5352957-4b4f-47c3-ac50-20fa6e324e2b"), "F_E1_1A_IntActor_Chips_C3_Switch"},
                        {new Guid("bc816a67-81e4-43bf-83ae-9d680122433e"), "F_E1_1A_IntActor_Cookies_C1_Take"},
                        {new Guid("e9cb49b9-f7fc-494f-a7ce-d3ccb43f378e"), "F_E1_1A_IntActor_Cookies_C2_Look"},
                        {new Guid("7dd579c5-53c0-439e-a466-d4a610166d9b"), "F_E1_1A_IntActor_Cookies_C3_Switch"},
                        {new Guid("9526c5a0-0b39-48c3-9755-dbac09ea16dc"), "F_E1_1A_IntActor_letters_C1_Reorganize"},
                        {new Guid("ccad8560-634d-47f0-9d1b-50fb0da18c84"), "F_E1_1A_IntActor_SketchDesk_C1_SketchLyla"},
                        {new Guid("ee6dc2e2-043e-43f6-a0df-f880895fe315"), "F_E1_1A_IntActor_SeanDrawer_C1_Open"},
                        {new Guid("d17795b9-33b8-4c78-a5ab-7be29d928036"), "F_E1_1A_IntActor_SeanDrawer_C2_Close"},
                        {new Guid("5d79b4bd-ee1b-4347-b749-25a52328fdbf"), "F_E1_1A_IntActor_Ipod_C1_Play"},
                        {new Guid("a87e77f4-bea2-44c7-a5d0-d36956338874"), "F_E1_1A_IntActor_Ipod_C2_Stop"},
                        {new Guid("d2d536b4-b3b1-40d2-8574-14f815354db1"), "F_E1_1A_IntActor_Ipod_C3_Look"},
                        {new Guid("cebb19b4-0d26-4331-8fc4-c74197b8c887"), "F_E1_1A_IntActor_Blanket_C1_Look"},
                        {new Guid("188db876-9304-4f51-aad9-2022518debf6"), "F_E1_1A_IntActor_Blanket_C2_Take"},
                        {new Guid("97e27aea-efa8-48bb-8b3d-f6b36e803b81"), "F_E1_1A_IntActor_Jar_C2_Look"},
                        {new Guid("7d5bdfec-3ad6-4b42-a633-f084ab5da744"), "F_E1_1A_IntActor_Jar_C4_Addmoney($10)"},
                        {new Guid("15224a96-9233-4c79-a53e-10967d0a2721"), "F_E1_1A_IntActor_NightstandBook_C1_Move"},
                        {new Guid("2a9510af-25fa-49bf-9a12-a291363afd7a"), "F_E1_1A_IntActor_SeanRoom_C1_Enter"},
                        {new Guid("7f674d35-c66c-4829-88cf-185fc4dae731"), "F_E1_1A_IntActor_DeskCupboard_C1_open"},
                        {new Guid("230b3ef0-6535-4a09-84ca-1f77e3030052"), "F_E1_1A_IntActor_Candy_C1_Look"},
                        {new Guid("19035224-541b-4db1-a76f-ffcc8bf16dbf"), "F_E1_1A_IntActor_Candy_C3_Switch"},
                        {new Guid("b4e70006-3709-4475-9d3b-9116453fcaa5"), "F_E1_1A_IntActor_Leftover_C1_Look"},
                        {new Guid("b2f69b1c-317b-44d8-a0c0-af9f8c77b5f6"), "F_E1_1A_IntActor_ArtBook_C1_Look"},
                        {new Guid("b5752878-6098-4a4d-93c9-5a472fa74d4b"), "F_E1_1A_IntActor_BaseballCap_C1_Look"},
                        {new Guid("2c36e416-dc1a-4e35-930a-ae52de08fdbb"), "F_E1_1A_IntActor_BirthdayGift_C1_Look"},
                        {new Guid("41aeda2e-205d-4b61-b85d-8f7fabfb8e62"), "F_E1_1A_IntActor_Cabinet_C1_Practice"},
                        {new Guid("4267a64b-49ee-4d83-b97b-6317edcfcfef"), "F_E1_1A_IntActor_CornSyrup_C1_Look"},
                        {new Guid("963885f4-1bfe-4c5f-a2e4-1f9d5dc54b45"), "F_E1_1A_IntActor_Couch_C1_Sit"},
                        {new Guid("1dec3ae5-30e0-43cc-a58c-452d775afd85"), "F_E1_1A_IntActor_DaanielHomework_C1_Look"},
                        {new Guid("cf19e0d6-5dfc-4684-ac44-e14d41df2e0b"), "F_E1_1A_IntActor_DadBook_C1_Look"},
                        {new Guid("7321779d-8560-4690-968c-b0cb32a9a1ac"), "F_E1_1A_IntActor_DadPaper_C1_Look"},
                        {new Guid("f420f77a-0d28-46ac-b8cb-bc372fccb883"), "F_E1_1A_IntActor_DadRoom_C1_Look"},
                        {new Guid("a2bb9b8f-4128-4b62-8597-e7f08d476022"), "F_E1_1A_IntActor_DadShoes_C1_Look"},
                        {new Guid("756789ef-4113-428a-a2f6-b6cad5f52f7b"), "F_E1_1A_IntActor_DanielToy_C1_Look"},
                        {new Guid("ab8296a2-1e8d-4b22-bb27-94eb261c42e4"), "F_E1_1A_IntActor_FakePumpkin_C1_Look"},
                        {new Guid("1577c30b-f3e2-4baa-8134-4c4bf71c4a68"), "F_E1_1A_IntActor_FireExtiguinsher_C1_Look"},
                        {new Guid("d638ba0b-cbd1-47f1-b66a-687f5b05c701"), "F_E1_1A_IntActor_Fireplace_C1_Look"},
                        {new Guid("a88b2b68-b745-4948-b2f8-b7cef7fb0541"), "F_E1_1A_IntActor_FramedLicence_C1_Look"},
                        {new Guid("6b0087ba-b4ea-4d48-a741-5293347bd8ce"), "F_E1_1A_IntActor_FriendPicture_C1_Look"},
                        {new Guid("55098aeb-2491-49a4-bb31-34ec2c6fd109"), "F_E1_1A_IntActor_GamingMagazine_C1_Look"},
                        {new Guid("dc115c9d-eb76-43dd-9565-31cd62af6bb6"), "F_E1_1A_IntActor_GaragePicture_C1_Look"},
                        {new Guid("852c12a6-d2d2-4a5e-a831-6d113491f3e7"), "F_E1_1A_IntActor_HeadSet_C1_Look"},
                        {new Guid("999536f8-9f41-4126-8381-b7c061899c5c"), "F_E1_1A_IntActor_KarenBox_C1_Look"},
                        {new Guid("b6c333b1-38fa-4287-8e7b-ec375c4aeb03"), "F_E1_1A_IntActor_LaundryBasket_C1_Look"},
                        {new Guid("e26ca89a-5d28-485d-8e3a-606e6c313d58"), "F_E1_1A_IntActor_LeftOverFood_C1_Look"},
                        {new Guid("87601179-a5c5-4cc0-8618-1134ed2545e8"), "F_E1_1A_IntActor_LightSwitch_C1_Turnon"},
                        {new Guid("e367f94d-c895-4c06-a14a-c2521f23584f"), "F_E1_1A_IntActor_LightSwitch_C2_Turnoff"},
                        {new Guid("d218f122-37d6-4078-9e61-d59cf82e8d49"), "F_E1_1A_IntActor_LivingRoomWindow_C1_Look"},
                        {new Guid("74f905e7-54ab-4a32-a08f-818fb7651705"), "F_E1_1A_IntActor_LOTRCollection_C1_Look"},
                        {new Guid("03257e5c-4f55-4889-8533-d5e6ceab1355"), "F_E1_1A_IntActor_MoviePoster_C1_Look"},
                        {new Guid("99863c4a-f82f-43fd-ac7e-b6549083c357"), "F_E1_1A_IntActor_462_C1_Look"},
                        {new Guid("1c7279ff-51f3-4adb-b8b5-71a6120ceb73"), "F_E1_1A_IntActor_MusicPoster_C1_Look"},
                        {new Guid("6722a9be-8e40-4c79-b652-b6b52b595fe4"), "F_E1_1A_IntActor_NeighborNote_C1_Look"},
                        {new Guid("921169ef-0da4-411a-b2f9-953bcc1df811"), "F_E1_1A_IntActor_Nightstand_C1_Open"},
                        {new Guid("e9d10748-314b-4af4-957d-cb4537ca8db8"), "F_E1_1A_IntActor_Picture_C1_Look"},
                        {new Guid("d0c863bc-869d-4702-a2db-90663b25d063"), "F_E1_1A_IntActor_Playbox_C1_Look"},
                        {new Guid("fc893275-9e86-4c8f-b573-8c3f7900dc4d"), "F_E1_1A_IntActor_Postcard_C1_Look"},
                        {new Guid("a97ecbd2-345d-4568-8046-36125418cb05"), "F_E1_1A_IntActor_ReligiousPortrait_C1_Look"},
                        {new Guid("b809bf2e-5207-44ca-bf6c-607937ffc02a"), "F_E1_1A_IntActor_RetrocarsBook_C1_Look"},
                        {new Guid("edf975bb-8b0a-412c-8ad9-2eeb18b9da90"), "F_E1_1A_IntActor_Saw_C1_Look"},
                        {new Guid("de1c7276-37e8-4985-97eb-80aa5c4ce440"), "F_E1_1A_IntActor_SeanBike_C1_Look"},
                        {new Guid("36f6df7a-47d1-4771-8232-21542964e64a"), "F_E1_1A_IntActor_SeanBook_C1_Look"},
                        {new Guid("1d7bf8a9-87f6-422e-bd76-b91c6a2b1e1a"), "F_E1_1A_IntActor_SeanDrawing_C1_Look"},
                        {new Guid("23418976-98b1-4d5c-ae18-a365c5b02d78"), "F_E1_1A_IntActor_SecretRecipe_C1_Look"},
                        {new Guid("37e3a7ed-7a8f-4025-aeec-eb3daa3d8c63"), "F_E1_1A_IntActor_Skateboard_C1_Look"},
                        {new Guid("a208ba54-2ef2-4293-9f64-cf252696ae90"), "F_E1_1A_IntActor_SkateParkPicture_C1_Look"},
                        {new Guid("b52844f4-a46f-4820-9018-1cfca690895a"), "F_E1_1A_IntActor_SkiEquipment_C1_Look"},
                        {new Guid("106c93d6-f181-4970-9ff7-8f62774e17e9"), "F_E1_1A_IntActor_SkiPicture_C1_Look"},
                        {new Guid("bca24543-c88e-43b0-a153-89c8f74f11ac"), "F_E1_1A_IntActor_Slate_C1_Look"},
                        {new Guid("8c06ce42-ab34-4ee9-9c05-d6d734f3a89f"), "F_E1_1A_IntActor_Smoothie_C1_Look"},
                        {new Guid("8a4e13f2-36a5-48c3-b4ae-2325a1d8abba"), "F_E1_1A_IntActor_Tools_C1_Look"},
                        {new Guid("74fdb572-1f46-4989-a06c-f2153f144831"), "F_E1_1A_IntActor_ToothBrush_C1_Look"},
                        {new Guid("d6eb4e7b-b416-4139-b643-2ae6f16767af"), "F_E1_1A_IntActor_Trophies_C1_Look"},
                        {new Guid("b33bc3ad-df15-43f5-853a-303852368c82"), "F_E1_1A_IntActor_TV_C1_Look"},
                        {new Guid("9956b72d-857c-4a08-9429-e5e3340789ed"), "F_E1_1A_IntActor_WorkUniform_C1_Look"},
                        {new Guid("067616d3-734e-47f9-b3e7-9f90e6b6e656"), "F_E1_1A_IntActor_XmasDecorations_C1_Look"},
                        {new Guid("c36a35e1-8475-4f5a-b9bc-206d52dec6e1"), "F_E1_1A_IntActor_SeanWindow_C1_Look"},
                        {new Guid("bd584cc6-6951-4545-8243-09d4ced9e249"), "F_E1_1A_IntActor_LightSwitch2_C1_Turnon"},
                        {new Guid("353bfde4-9e54-499b-9d09-4b6fc87ff851"), "F_E1_1A_IntActor_LightSwitch2_C2_Turnoff"},
                        {new Guid("d4e42bb0-2123-460c-9759-cad1644c94d2"), "F_E1_1A_IntActor_SeanBackpack_C3_Look"},
                        {new Guid("79ba4d56-a714-4321-a23b-b7db4875e332"), "F_E1_1A_IntActor_Beers_C2_Look"},
                        {new Guid("8097b6b9-94dd-4433-82a1-d728646e373a"), "F_E1_1A_IntActor_Sodas_C2_Look"},
                        {new Guid("0f71ff6d-27b6-4593-b9f5-80438bf2e647"), "F_E1_1A_IntActor_Chips_C2_Look"},
                        {new Guid("7bd1f292-52f6-4ae8-8b66-d9920465aca1"), "F_E1_1A_IntActor_Lamp_C1_SwitchOn"},
                        {new Guid("6d674cc2-f0ce-4515-9ce3-356d2493474f"), "F_E1_1A_IntActor_WeedPipe_C1_Look"},
                        {new Guid("5d1fe151-2c20-4e89-bea8-1e281257d6fb"), "F_E1_1A_IntActor_GigFlyer_C1_Look"},
                        {new Guid("8630379f-41ad-4ef9-b538-3ad95f99c146"), "F_E1_1A_IntActor_BandPoster_C1_Look"},
                        {new Guid("aa8a0ec0-1ac4-4d08-9d4b-ed3bdb9c3b57"), "F_E1_1A_IntActor_Cabinet_C2_Look"},
                        {new Guid("98af4981-af20-4070-a82d-3bc37b59b12f"), "F_E1_1A_IntActor_ChairBean_C1_SitandDraw"},
                        {new Guid("4f8607f1-ef6b-4c86-823f-28e52dc0050e"), "F_E1_1A_IntActor_Condoms_C1_Take"},
                        {new Guid("304b42fb-bcf6-4058-932e-a9235dec433c"), "F_E1_1A_IntActor_Condoms_C2_Look"},
                        {new Guid("1e22c307-cec2-4d2f-b796-7edbb7ec81c4"), "F_E1_1A_IntActor_Engine_C1_Look"},
                        {new Guid("40fb383c-1935-4cd8-9748-5f9a5e5c7c06"), "F_E1_1A_IntActor_OldPhone_C1_Look"},
                        {new Guid("1b41a00b-bd91-4fc4-b251-3927fc9c8681"), "F_E1_1A_IntActor_OldToy_C1_Look"},
                        {new Guid("a70d281d-2b82-4705-898f-3d7c3ad432fc"), "F_E1_1A_IntActor_Receipt_C1_Look"},
                        {new Guid("7b4e3c80-878f-4795-b6c0-8d1a6bd2b665"), "F_E1_1A_IntActor_SeanCar_C1_Look"},
                        {new Guid("996cd574-9412-494e-ba24-a16ec4e7e0fb"), "F_E1_1A_IntActor_WrongTool05_C1_Take"},
                        {new Guid("c5a7915e-760a-47a9-94ed-59268beec216"), "F_E1_1A_IntActor_Ball_C1_Play"},
                        {new Guid("635a2be9-80b9-4659-b022-5bc1480123ec"), "F_E1_1A_IntActor_Dad_C2_GiveTool"},
                        {new Guid("c4c79d19-5e61-4872-98e3-7ad2a9413c99"), "F_E1_1A_IntActor_SeanBackpack_C4_Look"},
                        {new Guid("aba9e660-42fc-4d4b-953d-944d80270bce"), "F_E1_1A_IntActor_Beers_C1_Take"},
                        {new Guid("9907149a-0b88-4a99-8673-55fdd70e215e"), "F_E1_1A_IntActor_Beers_C3_Switch"},
                        {new Guid("2d9cf4e3-bb78-43b5-a755-b22cb88afe78"), "F_E1_1A_IntActor_Sodas_C3_Switch"},
                        {new Guid("1eb398db-7f68-474a-a0b8-17ea0eb4d815"), "F_E1_1A_IntActor_WeedPipe_C2_Take"},
                        {new Guid("2b901154-0ec5-48c5-b541-ffe6c338e7da"), "F_E1_1A_IntActor_Candy_C2_Take"},
                        {new Guid("d2a9325c-be70-4ac9-889b-2482a9779493"), "F_E1_1A_IntActor_RightTool01_C3_Take"},
                        {new Guid("22c31b1a-f921-4419-ab7d-c8f9697348ef"), "F_E1_1A_IntActor_Chips_C1_Take"},
                        {new Guid("817f1ea5-40ad-4bec-b99f-15ae600f3cbe"), "F_E1_1A_IntActor_Jar_C1_Stealcoins($10)"},
                        {new Guid("086ba7a7-0c70-4b9a-a1a4-614ee6cbddb5"), "F_E1_1A_IntActor_EmptyChoco_C1_Look"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "8c794872-5f7d-413f-b975-20a5e3334f92", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("d15f37ed-33bb-4bac-8c9f-49106179ce32"), "F_E1_2A_SecondaryPath_FallenTree_DanielHelped"},
                        {new Guid("dcfbb855-c53f-479c-9952-d77b978fd021"), "F_E1_2A_ParkingArea_Car_Left"},
                        {new Guid("cfb61e85-42d0-402c-a213-bc4f43f7bd11"), "F_E1_2A_PicnicArea_DanielPoISpiderWeb"},
                        {new Guid("dd8d5ba5-deac-4dc2-ad7b-198eb0ae5e50"), "F_E1_2A_SecondaryPath_HideAndSeek_DanielReady"},
                        {new Guid("ce74e429-2a8c-4186-954e-cd25475c35b9"), "F_E1_2A_ShelterArea_CampFire_GatheringMaterials"},
                        {new Guid("5ef102bd-b371-471c-9f4c-bb5b7f2d58a5"), "F_E1_2A_PicnicArea_ZenBench_Available"},
                        {new Guid("c6b5a8dd-b3c0-40ff-94b4-d1cb742f42ed"), "F_E1_2A_ParkingArea_PayStationSign_ShowPictureSeen"},
                        {new Guid("5d13ce02-f454-4bc3-a7f5-dbeb361566e2"), "F_E1_2A_SecondaryPath_FallenTree_SeanCrossed"},
                        {new Guid("ec644d8a-88e7-4f7e-9122-26d38087e1ea"), "F_E1_2A_PicnicArea_HideAndSeek_DanielHidden"},
                        {new Guid("5a6d4445-8a43-4e3c-b653-b37ba8d109e7"), "F_E1_2A_ParkingArea_DialChoice_Minecraft"},
                        {new Guid("995b5ad9-76b6-411a-b25f-ecaaa0d159b8"), "F_E1_2A_SecondaryPath_FallenTree_FirstCross"},
                        {new Guid("3e5429ac-07ff-4d87-9462-0969669a00b1"), "F_E1_2A_SecondaryPath_SeanFoundPath"},
                        {new Guid("bb496683-b13e-4e10-9f08-3dfd4105a06c"), "F_E1_2A_PicnicArea_ZenBench_InterruptedByDaniel"},
                        {new Guid("374b2fe3-9553-43b2-b518-e49681381cda"), "F_E1_2A_HikingTrail_Raccoon_Shown"},
                        {new Guid("12bb6b3e-e1c8-4f96-b394-2605550fda73"), "F_E1_2A_PicnicArea_TrailBlazeShown"},
                        {new Guid("5665548c-285f-4ddc-baba-1e3ac99febf1"), "F_E1_2A_ParkingArea_DeadRaccoonSeen"},
                        {new Guid("312a3033-8492-461d-9ca5-2197f6ceaa6c"), "F_E1_2A_ParkingArea_DanielOnPoICar"},
                        {new Guid("f15bc701-f90b-498a-880b-89ccc319f26f"), "F_E1_2A_ParkingArea_WildlifeSign_Reassure"},
                        {new Guid("3f035ca3-ec9c-4ef9-9d97-a2404b5819e2"), "F_E1_2A_ParkingArea_HasForcedToilets"},
                        {new Guid("6c3a601a-8771-46e3-822d-c55c5854ef16"), "F_E1_2A_PicnicArea_QuicklyFoundDanielSpot"},
                        {new Guid("f4b43ad7-5b1b-476d-a459-80ccc3730234"), "F_E1_2A_ShelterArea_CampFire_Built"},
                        {new Guid("c65ac77d-a8f7-4444-a2b8-0392d80b2ee6"), "F_E1_2A_ShelterArea_FortificationDone"},
                        {new Guid("f008d108-d15b-4bf2-a121-c9886a35f7f1"), "F_E1_2A_ShelterArea_GPSit"},
                        {new Guid("bc9b7fba-6f1f-4b5a-bc4c-3a03ab5a8eac"), "F_E1_2A_PicnicArea_TasteBerries01"},
                        {new Guid("48a82c3c-8085-4d04-9e08-03ddeac9cf8c"), "F_E1_2A_PicnicArea_BerriesFoundByDaniel"},
                        {new Guid("2a7c1131-2600-4f07-be4c-595569730604"), "F_E1_2A_PicnicArea_TasteBerries03"},
                        {new Guid("a1ea66f3-4530-439d-a8a0-3c825cf7b338"), "F_E1_2A_ShelterArea_GPSit_Speaking"},
                        {new Guid("9e510f5b-9f42-443d-b952-3a3000016c53"), "F_E1_2A_ShelterArea_GPSit_DanielYawns"},
                        {new Guid("2c1d2658-f5b8-4fda-8ff2-6c03012e8b7b"), "F_E1_2A_ParkingArea_DeadAnimals_DiscussDone"},
                        {new Guid("704911e3-9f53-42da-aeb6-0fa2835c7770"), "F_E1_2A_SecondaryPath_TreeFungusSeen"},
                        {new Guid("5a87301d-e737-42e6-bf6b-400aef6160ce"), "F_E1_2A_ShelterArea_CampFire_LogPlaced"},
                        {new Guid("768fb3a2-1811-439f-be9f-2b7220a4362b"), "F_E1_2A_ShelterArea_SkimStone_Succeed"},
                        {new Guid("c56b5834-b112-4e17-957d-85fbbd3e2b6c"), "F_E1_2A_ShelterArea_SpikesDone"},
                        {new Guid("997d553d-179c-4542-8885-70a6986c9605"), "F_E1_2A_ShelterArea_LookFortificationsSunset"},
                        {new Guid("97cf1823-98ff-4383-9a75-e75dbfd74350"), "F_E1_2A_SecondaryPath_BigClimb_DanielScared"},
                        {new Guid("e1a0c639-7180-40b2-ac96-4d9020649b32"), "F_E1_2A_PicnicArea_Berries01_Active"},
                        {new Guid("d4f9e636-0683-4b8b-9bc7-b53e90200a77"), "F_E1_2A_TEMP_DanielIshidding"},
                        {new Guid("37b5fa5d-0a84-4217-bf7e-f9016bd9c388"), "F_E1_2A_PicnicArea_Berries01_DanielDone"},
                        {new Guid("6f0c64fa-4f51-4d5b-a622-ab1d23f38bcb"), "F_E1_2A_PicnicArea_Berries03_DanielDone"},
                        {new Guid("48e3a68a-f367-4b3b-85ba-61fb34ee41d3"), "F_E1_2A_PicnicArea_BearMarksLooked"},
                        {new Guid("667b1f5f-22c9-4998-96db-2d7e4e640154"), "F_E1_2A_PicnicArea_Berries03_Active"},
                        {new Guid("148580cf-3548-4791-92a2-d50bae086d49"), "F_E1_2A_PicnicArea_Berries04_Active"},
                        {new Guid("5bf6c770-c673-4b15-a8fb-d3bab3edf3b6"), "F_E1_2A_PicnicArea_Berries04_Checked"},
                        {new Guid("0596868d-a5ef-43b6-bce3-ffd43a88c7f3"), "F_E1_2A_PicnicArea_Berries04_DanielDone"},
                        {new Guid("226d712d-e4cf-4783-80d4-b43575c6a9c9"), "F_E1_2A_PicnicArea_Berries04_NeedTesting"},
                        {new Guid("6c8be0c3-6af1-4306-80c8-91e1c4a3478a"), "F_E1_2A_PicnicArea_TasteBerries04"},
                        {new Guid("4e159d56-2069-4f93-97d7-19273e6ab56d"), "F_E1_2A_PicnicArea_GoodBerriesTastedBySean"},
                        {new Guid("519c40e4-a8ac-49ec-a267-faefa85d9c93"), "F_E1_2A_PicnicArea_GoodBerriesTastedByDaniel"},
                        {new Guid("afc8c9a8-0b93-45d0-975a-1b38a556cd58"), "F_E1_2A_PicnicArea_Berries_SeanBusy"},
                        {new Guid("4dea7224-18cd-42ed-b074-1e5acae98451"), "F_E1_2A_PicnicArea_Berries_DanielSick"},
                        {new Guid("997917fb-fe5a-43a1-8e80-8e57ebd61d1a"), "F_E1_2A_PicnicArea_BadBerriesTastedByDaniel"},
                        {new Guid("8d78a035-6b3c-4604-91fa-a4efeeee7aaf"), "F_E1_2A_PicnicArea_BadBerriesTastedBySean"},
                        {new Guid("9f6b5432-0041-4dc1-ac3f-35ec11e2973f"), "F_E1_2A_PicnicArea_Berries05_Active"},
                        {new Guid("4a907df6-4179-4000-8b8e-7fb260487a4a"), "F_E1_2A_PicnicArea_Berries05_DanielDone"},
                        {new Guid("006ba01a-2d25-4551-a6d3-35205be00885"), "F_E1_2A_PicnicArea_TasteBerries05"},
                        {new Guid("235a15a5-b3a5-4cea-9c9b-5aa50b4474e2"), "F_E1_2A_HiddenVistaEnable"},
                        {new Guid("c95182c8-b214-4bf0-a7a9-ab22ef312dfd"), "F_E1_2A_ShelterArea_GoodNight"},
                        {new Guid("f1e43570-3945-412b-8acf-3617914bbda6"), "F_E1_2A_InDrawSequence"},
                        {new Guid("6315a43b-bcd7-47ef-871f-6ebd53d7418b"), "F_E1_2A_Berries_DanielAsk"},
                        {new Guid("db4b6d87-0397-43ae-bc59-5d04ad7a99db"), "F_E1_2A_PicnicArea_TutoLookCanBeLaunched"},
                        {new Guid("35bb5083-5428-4c79-8868-be25232cd588"), "F_E1_2A_ParkingArea_SeanNearCar"},
                        {new Guid("faa928a4-405c-41b1-a16a-b47f1fda2ffc"), "F_E1_2A_SubcontextStarted"},
                        {new Guid("622f2d1a-6bfe-4816-94e2-7ff1a3aef600"), "F_E1_2A_ShelterArea_DanielFishing"},
                        {new Guid("c8b37ac8-d1cc-413f-b623-62d4e198a042"), "F_E1_2A_SeanNearFireCamp"},
                        {new Guid("5c136ce7-2ac5-4edd-b157-685b2fdc9178"), "F_E1_2A_DarkeningWoodsDone"},
                        {new Guid("a924b1f6-70e3-497a-9722-bdd6a96f6255"), "F_E1_2A_DanielDoingPoIActivities"},
                        {new Guid("a4080432-b236-49c6-b53a-cc4e234f9eae"), "F_E1_2A_PoIFishingStarted"},
                        {new Guid("6c6b3f5b-3077-4d4a-8b8f-e7a47a0b40c6"), "F_E1_2A_ShelterArea_DanielFollow"},
                        {new Guid("5c25bc5f-333e-4895-bfa6-9c9d5bc1db86"), "F_E1_2A_ShelterArea_WeaponRacksDone"},
                        {new Guid("2c79c91f-d2e3-442b-bce8-2a51df9a3442"), "F_E1_2A_RaccoonPoIReached"},
                        {new Guid("beb421d7-fe7f-4c5e-898d-fd3917d0cf1b"), "F_E1_2A_ParkingArea_PayStationSign_MailboxLooked"},
                        {new Guid("9966845b-de1b-4d59-bba2-24e3d0076a1b"), "F_E1_2A_ParkingArea_PayStationSign_MailboxBroken"},
                        {new Guid("079c7a6a-c679-4a92-9120-468771d39332"), "F_E1_2A_PicnicArea_PlayHideAndSeek"},
                        {new Guid("32c9c107-7631-4737-be67-9951f714ca74"), "F_E1_2A_ParkingArea_PayStationSign_TryOpen"},
                        {new Guid("ab3844de-e60a-4bef-a8ce-e6529fbf65ed"), "F_E1_2A_ShelterArea_HelpFireDone"},
                        {new Guid("0faba736-d103-45d6-a691-a3f69df75862"), "F_E1_2A_PicnicArea_TasteBerries02"},
                        {new Guid("270bba5d-e169-4222-8b4e-eea7a7fc2067"), "F_E1_2A_ShelterArea_HelpFire_NeedDumpWood"},
                        {new Guid("5814e354-a0f3-4d5a-a423-74ce5ccfaaf8"), "F_E1_2A_ShelterArea_SkimStone_Teach"},
                        {new Guid("8a82cd1e-4f9f-4180-aa19-5a720701c4e8"), "F_E1_2A_PicnicArea_Berries02_Showed"},
                        {new Guid("6d081d2a-2499-4abb-a98a-80b79bbdcb65"), "F_E1_2A_PicnicArea_Berries03_NeedTesting"},
                        {new Guid("4a5fa37e-6733-477d-9bee-3439f038139f"), "F_E1_2A_PicnicArea_Berries02_Active"},
                        {new Guid("c1dcb439-aa98-4cd8-aff5-ea06216a4cdc"), "F_E1_2A_PicnicArea_Berries02_DanielDone"},
                        {new Guid("4488a09b-ff35-4d8c-83e7-b963ff6d83a0"), "F_E1_2A_PicnicArea_HideAndSeek_SeanRefused"},
                        {new Guid("ba8a784e-7095-485a-83af-ef9f59b1bdfe"), "F_E1_2A_ShelterArea_HelpFire_Spot03_Taken"},
                        {new Guid("03c49ebc-7f8d-44f4-b621-124c6fd12529"), "F_E1_2A_PicnicArea_Berries05_Showed"},
                        {new Guid("fc2567a0-990c-4696-aa7f-33e2badf8832"), "F_E1_2A_WoodRaceResult_DanielWon"},
                        {new Guid("6e4188b5-ca69-4490-a465-999884e0f479"), "F_E1_2A_WoodDump_DanielWaiting"},
                        {new Guid("a8d5b700-9ffb-4b91-bbea-1f14b7e0d6ca"), "F_E1_2A_ParkingArea_Car_Steal"},
                        {new Guid("4935dcd8-f576-4f66-b945-66067662d6ff"), "F_E1_2A_SecondaryPath_DanielFoundPath"},
                        {new Guid("215c24b7-2118-481c-aa28-83f20410861f"), "F_E1_2A_ParkingArea_DialChoice_LOTR"},
                        {new Guid("db9b5381-161a-4fc6-ba9e-a8c184ac2649"), "F_E1_2A_PicnicArea_Berries_DanielStopped"},
                        {new Guid("e4871c30-a3f4-4c0d-bfb8-4129ee14eba4"), "F_E1_2A_PicnicArea_SwordFightDuel"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("c3bb2901-405b-4a8d-8ba3-45793ebe2a84"), "F_E1_2A_ShelterArea_WeaponStick"},
                        {new Guid("4f13630d-02d9-478f-a41b-4deba37fb008"), "F_E1_2A_ShelterArea_LogsInInventory"},
                        {new Guid("f06cc6e3-38c9-4754-9980-56e3380128f5"), "F_E1_2A_PicnicArea_HideAndSeek_InnerVoiceCues"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("ba42465a-612e-4ba3-b7d1-bbd0532c134c"), "F_E1_2A_PicnicArea_HideAndSeek_State"},
                        {new Guid("4f6a59cf-aeae-45c8-b853-03f29f729649"), "F_E1_2A_ShelterArea_DanielActivities"},
                        {new Guid("ceac9bd8-b276-4d4d-b168-6f6e39e05aa8"), "F_E1_2A_DanielStatus"},
                    },
                }
            },
            {
                "975670f7-d8ca-4a4e-a7b8-941dd7c9ba29", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("3f2184fb-d459-403d-9ad9-ecea5ed254af"), "F_E1_2A_IntoTheWoods_ParkingArea_WildLife_C"},
                        {new Guid("689150ce-7dc5-4218-bd62-8378793fdd25"), "F_E1_2A_IntoTheWoods_ShelterArea_DiscoverShelter_C"},
                        {new Guid("2efc9849-9c54-4d60-ba99-44f0b669a34e"), "F_E1_2A_IntoTheWoods_ShelterArea_PreviousMeal_C"},
                        {new Guid("a66756fb-b8c1-45c5-8bf2-25a070486331"), "F_E1_2A_ShelterArea_BrettTalk_C"},
                        {new Guid("672fe880-e72a-4ffe-940e-949607ba1266"), "F_E1_2A_IntoTheWoods_MainTrail_Raccoon_C"},
                        {new Guid("8476b92b-e9b8-47c3-a21a-411d34801e36"), "F_E1_2A_IntoTheWoods_ParkingArea_TrailEntrance_C"},
                        {new Guid("513b2084-9dc8-48d7-a5cd-ce125e67dbee"), "F_E1_2A_IntoTheWoods_ParkingArea_Car_C"},
                        {new Guid("6e403e04-810d-4123-a2cc-d6c7704462ee"), "F_E1_2A_IntoTheWoods_ParkingArea_WildLifeSign_C"},
                        {new Guid("2202c2ef-0d40-464a-913b-2ae865c7fda2"), "F_E1_2A_IntoTheWoods_PicnicArea_Vista_C"},
                        {new Guid("09b0b3ae-5640-4e59-99f9-9f7e1d9687f7"), "F_E1_2A_IntoTheWoods_Parking_NoCampingSign_C"},
                        {new Guid("5ab65a4b-b204-42cc-91b7-9856c3ef396e"), "F_E1_2A_IntoTheWoods_ShelterArea_BuildFort_WeaponRack_C"},
                        {new Guid("3d3798b8-3d5a-4d5d-8e71-be077550ea33"), "F_E1_2A_IntoTheWoods_PicnicArea_TrailBlaze02_C"},
                        {new Guid("606aa441-fffc-4682-bbba-54a24c6910a9"), "F_E1_2A_IntoTheWoods_PicnicArea_TrailBlaze01_C"},
                        {new Guid("f7c4a5d7-c0ba-456c-9bc0-e3da33492138"), "F_E1_2A_ShelterArea_BuildFort_LookAround_WeaponRack_C"},
                        {new Guid("45d267c9-ad4c-488f-a46c-0e9f7b425410"), "F_E1_2A_IntoTheWoods_SecondaryPath_FallenTree_C"},
                        {new Guid("fe04fdfc-ebe8-469a-a7b2-50e3a049d1c6"), "F_E1_2A_IntoTheWoods_PicnicArea_GoodBerries_DanielFoundBerries_C"},
                        {new Guid("c642e5a7-d3c0-47d9-9bff-c82ccf0a26ff"), "F_E1_2A_IntoTheWoods_PicnicArea_BadBerries_DanielFoundBerries_C"},
                        {new Guid("084c86ae-4360-48a3-87a1-9bf999df1f12"), "F_E1_2A_IntoTheWoods_ShelterArea_HiddenVista_C"},
                        {new Guid("4f1c4cb3-28c0-408b-a5ab-963547c02fc3"), "F_E1_2A_IntoTheWoods_ShelterArea_Fishing_C"},
                        {new Guid("15301bea-ad5f-470a-bb7a-f07dd72237b0"), "F_E1_2A_IntoTheWoods_SecondaryPath_TreeFungus_C"},
                        {new Guid("bfcab1c6-baba-4980-981c-b505bd0cf195"), "F_E1_2A_ShelterArea_Weapon03_C"},
                        {new Guid("a2baad2b-dff3-481d-bacf-9976e927adcb"), "F_E1_2A_IntoTheWoods_ShelterArea_BuildFort_PushTrunk_C"},
                        {new Guid("99b5ef50-9601-4d49-ac8b-6525bd0e0d23"), "F_E1_2A_IntoTheWoods_ShelterArea_BuildFort_Spikes_C"},
                        {new Guid("16351941-4a9e-46d5-b303-c0f6a68c36d3"), "F_E1_2A_ShelterArea_Weapon02_C"},
                        {new Guid("03a76524-37ec-4384-89d2-2ccc80ae2bfc"), "F_E1_2A_IntoTheWoods_PicnicArea_SpiderWeb_C"},
                        {new Guid("ad3b0ca2-7c6f-488e-bb4d-3ffa7ab99d35"), "F_E1_2A_IntoTheWoods_ShelterArea_SkimStones_C"},
                        {new Guid("c909fe2e-515f-4f52-8926-46a0690a98e3"), "F_E1_2A_IntoTheWoods_Road_DeadAnimal_C"},
                        {new Guid("a8cea612-d5d7-444c-8441-81c7be84377d"), "F_E1_2A_ShelterArea_SwordFight_C"},
                        {new Guid("523b2dbc-55bb-4785-b9e5-983dea0f4e42"), "F_E1_2A_IntoTheWoods_SecondaryPath_ClimbDown_C"},
                        {new Guid("144d7b71-3783-4ab7-959b-c82aee16fdf9"), "F_E1_2A_IntoTheWoods_PicnicArea_BearMarkings_C"},
                        {new Guid("531c009d-93ef-4de0-a730-791cf8dafd93"), "F_E1_2A_PicnicArea_GoodBerries_KnownSpot_C"},
                        {new Guid("3bd4b46c-0f94-4879-9c85-704bc06df1a0"), "F_E1_2A_IntoTheWoods_SecondaryPath_BirdNest_C"},
                        {new Guid("d0829ed3-ad46-4082-b89b-fd542b02d8eb"), "F_E1_2A_ShelterArea_Weapon01_C"},
                        {new Guid("8e0c8dc1-d08b-4711-9b5d-e9de8d26937b"), "F_E1_2A_IntoTheWoods_ParkingArea_LookingForCar_C"},
                        {new Guid("dae498ed-0825-4c93-8082-6c8c779d33c1"), "F_E1_2A_IntoTheWoods_PicnicArea_PicnicSign_C"},
                        {new Guid("9b5356f8-3a40-4c8a-87e5-fcc177ec1d4d"), "F_E1_2A_IntoTheWoods_PicnicArea_SitTable_C"},
                        {new Guid("d56cd32e-0d77-4460-a65d-b9b71ff61738"), "F_E1_2A_IntoTheWoods_PicnicArea_TrailBlaze03_C"},
                        {new Guid("0074d00b-e9c9-4e02-84c8-7c30bc0f30b0"), "F_E1_2A_IntoTheWoods_Parking_StartHiking_C"},
                        {new Guid("1bb1a43b-fe06-42d3-849b-99fe451e28de"), "F_E1_2A_IntoTheWoods_ParkingArea_DarkeningWoods_C"},
                        {new Guid("185dbb91-c917-4c29-95ba-de99a40b9997"), "F_E1_2A_IntoTheWoods_PicnicArea_AreaDiscovered_C"},
                        {new Guid("6ef7834a-d3b5-419f-8a48-55e2c991efae"), "F_E1_2A_IntoTheWoods_SecondaryPath_SeanFoundPath_C"},
                        {new Guid("a2b38821-b8d5-49f3-9f59-a94580582bda"), "F_E1_2A_IntoTheWoods_PicnicArea_HideAndSeek_C"},
                        {new Guid("d5a1ac2f-bb63-4b58-bb7a-57d81e92f07e"), "F_E1_2A_IntoTheWoods_PicnicArea_HideAndSeek_StartHiding_C"},
                        {new Guid("27ece961-caf1-453d-a74e-fdab49b45e00"), "F_E1_2A_IntoTheWoods_PicnicArea_HideAndSeek_Counting_C"},
                        {new Guid("7333d6e9-22cb-4d48-b377-809010f1c94e"), "F_E1_2A_IntoTheWoods_SecondaryPath_ChitChat_C"},
                        {new Guid("42e37d34-ebfc-438f-9ca9-05694388d170"), "F_E1_2A_IntoTheWoods_HikingTrail_Raccoon_C"},
                        {new Guid("c741257f-d6f7-44dd-8825-594917aa39cd"), "F_E1_2A_IntoTheWoods_PicnicArea_Insertion_C"},
                        {new Guid("f1643b50-c85b-4f10-a03b-3a485f2a7019"), "F_E1_2A_IntoTheWoods_ShelterArea_Howling_C"},
                        {new Guid("00606ab1-ac8d-4ad4-b4ec-6d7c4947fcc8"), "F_E1_2A_IntoTheWoods_ShelterArea_CellphonePlay_C"},
                        {new Guid("00b283ef-ba8e-4059-af90-00244bc54851"), "ORPHAN_F_E1_2A_IntoTheWoods_PicnicArea_HideAndSeek_Call_C"},
                        {new Guid("fa06b7ca-f853-46d3-9e58-7e2fc50bea48"), "F_E1_2A_IntoTheWoods_PicnicArea_TrailBlaze04_C"},
                        {new Guid("51d24579-1b8a-4e94-8c89-346956f7d10f"), "F_E1_2A_IntoTheWoods_HelpFire_Result_C"},
                        {new Guid("20368025-98db-4900-9912-ced44b5863ce"), "F_E1_2A_IntoTheWoods_ShelterArea_HelpFire_2Logs_C"},
                        {new Guid("e51aa456-43f5-42f0-bd9a-5b596807897f"), "F_E1_2A_IntoTheWoods_ShelterArea_HelpFire_3Logs_C"},
                        {new Guid("86269d74-0217-4bd7-9d24-95b3e6c735f7"), "F_E1_2A_IntoTheWoods_Hikingtrail_Landslide_C"},
                        {new Guid("7db31c16-e693-4fa7-86cb-0b5afffe2c45"), "F_E1_2A_IntoTheWoods_PicnicArea_GoodBerries_ShowDaniel_C"},
                        {new Guid("e9a41842-cc82-4c16-8443-e453fbc9f416"), "F_E1_2A_IntoTheWoods_HikingTrail_ChitChat_01_C"},
                        {new Guid("9ec559af-15be-42af-9b45-f490ff259894"), "F_E1_2A_IntoTheWoods_ShelterArea_EatChocoBar_C"},
                        {new Guid("36a4b362-ab59-4169-b66a-4e4d7557fe2a"), "F_E1_2A_IntoTheWoods_SecondaryPath_DanielFoundPath_C"},
                        {new Guid("8a0e2b01-e27a-4cdb-af3c-c2a33fe9dd82"), "F_E1_2A_IntoTheWoods_PicnicArea_TableGraffiti02_C"},
                        {new Guid("4235e9b3-60d4-4d37-bb35-1eebffdc1be7"), "F_E1_2A_IntoTheWoods_PicnicArea_TableCarving_C"},
                        {new Guid("1b59031f-17a2-4173-9879-985d0dfc541b"), "F_E1_2A_IntoTheWoods_PicnicArea_HideAndSeek_Cheating_C"},
                        {new Guid("61f67a1d-ece3-4d93-91ce-2b5fe1dcd9d7"), "F_E1_2A_IntoTheWoods_ParkingToShelter_ChitChat_02_C"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("8d0e4507-a7a2-42f9-aca7-5e501e605234"), "F_E1_2A_ParkingArea_WildLife_Choice"},
                        {new Guid("acfd72fd-64c4-4543-baad-e1773da44e42"), "F_E1_2A_ShelterArea_DiscoverShelter_ActivityChoice"},
                        {new Guid("11cb774a-0ea3-40b1-b5c5-ece021b4cda9"), "F_E1_2A_ShelterArea_PreviousMeal_Choice"},
                        {new Guid("01734494-3d62-42bc-b808-7f2f9381c91f"), "F_E1_2A_ShelterArea_BrettTalk_BrettTalkChoice"},
                        {new Guid("6e51fdbf-aef9-47fe-b450-cda939a27fc5"), "F_E1_2A_PicnicArea_GoodBerries_DanielFoundBerries_Choice00"},
                        {new Guid("61c76900-27ad-4743-8263-572d6068a6f7"), "F_E1_2A_PicnicArea_BadBerries_DanielFoundBerries_Choice00"},
                        {new Guid("746cb2f4-e459-43c8-93ef-454ce7cfcbf5"), "F_E1_2A_ParkingArea_DarkeningWoods_DarkeningWoodChoice"},
                        {new Guid("8fcdbd09-b252-44c0-8b94-72d1bd9825b9"), "F_E1_2A_PicnicArea_HideAndSeek_HideAndSeek"},
                        {new Guid("e86ee3e4-88ff-4322-a01a-8b65a4ecc1a1"), "F_E1_2A_ShelterArea_Howling_HowlingChoice"},
                        {new Guid("c38a395e-863b-412a-982d-80b593de412b"), "F_E1_2A_ShelterArea_CellphonePlay_CellphonePlay"},
                        {new Guid("361487c0-858c-4864-b7fc-f8d218af8550"), "F_E1_2A_LevelChoice_Chocobar"},
                        {new Guid("2c51ddf3-de4d-42df-a7c2-840e860811f0"), "F_E1_2A_LevelChoice_AskToilet"},
                        {new Guid("9668ac83-db40-4a1c-96f9-0b77ff4126ca"), "F_E1_2A_LevelChoice_IgniteFire"},
                        {new Guid("62a97afb-b942-4e01-b2ad-c5fcd315024e"), "F_E1_2A_LevelChoice_SkimStoneChoice01"},
                        {new Guid("11d8925b-2966-4ca7-84c4-d51850747cc9"), "F_E1_2A_LevelChoice_SkimStoneChoice02"},
                        {new Guid("26dd40f9-4f79-490f-9be5-6e41345f0bfa"), "F_E1_2A_LevelChoice_SkimStoneChoice03"},
                        {new Guid("fdc61931-4e8e-4c97-a3bf-c1a28c92b9c3"), "F_E1_2A_LevelChoice_ZenRockChoice"},
                        {new Guid("2c4d3dbb-41e6-4852-8184-2d19f851c593"), "F_E1_2A_LevelChoice_FirstIgnite"},
                        {new Guid("7fc75022-4ad4-4ced-9f08-b8473af92c48"), "F_E1_2A_ParkingArea_Car_Choice00"},
                        {new Guid("293f9b53-3f3f-40cf-a37f-e4fd5092629b"), "F_E1_2A_ShelterArea_EatChocoBar_Choice"},
                    },
                }
            },
            {
                "97632851-6cb5-4253-a9ff-10197157317d", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("6a5cf9f7-2c69-4c62-acc8-03ec67349320"), "F_E1_2A_IntActor_Bench_C2_DanielHere"},
                        {new Guid("4f120696-55d4-419e-a9a4-be2f57a1b660"), "F_E1_2A_IntActor_FallenTree_C2_Help"},
                        {new Guid("08a703b8-7808-43dc-8b2d-76aed133c506"), "F_E1_2A_IntActor_DropDown_C1_Help"},
                        {new Guid("d2064f1b-f879-4c4b-b739-87df9f314b0b"), "F_E1_2A_IntActor_HideAndSeek_C1_Scare"},
                        {new Guid("aa0a6671-83a0-4347-9108-41162557233b"), "F_E1_2A_IntActor_Raccoon_C1_Look"},
                        {new Guid("6410f2a4-05c7-42bb-81cb-d9dd8714a645"), "F_E1_2A_IntActor_Raccoon_C2_Show"},
                        {new Guid("6650d4a5-04b2-487c-8d37-ab26688fb302"), "F_E1_2A_IntActor_SpeakGPSit_C1_Look"},
                        {new Guid("a94116fe-3203-49b7-b3dc-28d725f09f72"), "F_E1_2A_IntActor_SpeakGPSit_C2_Gotosleep"},
                        {new Guid("b360536c-5f9b-48aa-b741-8c599d93f4b5"), "F_E1_2A_IntActor_PushTrunk_C1_Push"},
                        {new Guid("a2e62802-68a2-42c5-81ba-db871b7ee4aa"), "F_E1_2A_IntActor_PushTrunk_C2_Look"},
                        {new Guid("fde17506-4cb6-4d78-b582-68a8ba966d79"), "F_E1_2A_IntActor_ZenRock_C1_Sit"},
                        {new Guid("f686aec4-2e0a-4964-929e-95547ebc1ea5"), "F_E1_2A_IntActor_ZenRock_C2_Sit"},
                        {new Guid("84a0da15-ef37-4371-bb1b-e6c44a5efb21"), "F_E1_2A_IntActor_Firepit_C1_AddLogs"},
                        {new Guid("dfddcd1b-1997-4231-b082-12d3c564aaeb"), "F_E1_2A_IntActor_Firepit_C2_Ignite"},
                        {new Guid("9dc5fc31-4d20-4778-ae48-efcd9618c8db"), "F_E1_2A_IntActor_Firepit_C3_Look"},
                        {new Guid("a50a1aea-eb0c-47ba-af0b-0e2f805cdfa8"), "F_E1_2A_IntActor_Firepit_C4_BuildFire"},
                        {new Guid("8b4065ea-6e7b-4149-86d8-4db94d9c0cf9"), "F_E1_2A_IntActor_Firepit_C5_Ignite"},
                        {new Guid("08d1a63e-13a0-4235-9550-66dd47676363"), "F_E1_2A_IntActor_SkimStone_C1_Skim"},
                        {new Guid("1d381791-6fe7-4b5a-b973-1eef6f7af6cc"), "F_E1_2A_IntActor_SpiderWeb_C1_Look"},
                        {new Guid("55e522f3-0aa2-45e8-aec6-768c5ddb0aa2"), "F_E1_2A_IntActor_Car_C1_Look"},
                        {new Guid("a1a13d32-d466-49d7-a08e-71e9ff0b5f05"), "F_E1_2A_IntActor_Car_C3_Look"},
                        {new Guid("d4d82e88-7418-4613-a4dc-c6423db26fd1"), "F_E1_2A_IntActor_Car_C4_Examine"},
                        {new Guid("1af1f5dc-62ec-4fdd-bc4d-15fa20f1f13a"), "F_E1_2A_IntActor_Toilet_C2_Ask"},
                        {new Guid("19f91ba7-46d2-4c25-b9a0-a2346093a2a7"), "F_E1_2A_IntActor_Sign2_C1_Look"},
                        {new Guid("363181ff-fcd1-4f07-b0f6-37f15a421957"), "F_E1_2A_IntActor_Sign2_C2_Discuss"},
                        {new Guid("b7daf0b4-4c57-4941-8eb6-84a81386ab20"), "F_E1_2A_IntActor_Berries03_C1_Eat"},
                        {new Guid("54167ae9-bf6d-4f31-a84f-7da66d5c546d"), "F_E1_2A_IntActor_Berries03_C3_Look"},
                        {new Guid("41c4eb5f-d8d2-4062-8603-a71e9e688c08"), "F_E1_2A_IntActor_Log01_C1_Take"},
                        {new Guid("14024f80-d94a-4607-880b-c8d42f309188"), "F_E1_2A_IntActor_Log04_C1_Take"},
                        {new Guid("b9abebbe-cc6c-439f-b16f-de1e2352592c"), "F_E1_2A_IntActor_Log15_C1_Take"},
                        {new Guid("a98ff914-1172-4bf4-813f-d7f8c8a7da96"), "F_E1_2A_IntActor_TrailBlaze3_C1_Look"},
                        {new Guid("2d7addea-df00-48b4-992c-c49d75b9ffdd"), "F_E1_2A_IntActor_TrailBlaze1_C1_Look"},
                        {new Guid("7a6ff58c-61e1-4c7e-a39c-c8d60bd91a9d"), "F_E1_2A_IntActor_TrailBlaze01_C1_Look"},
                        {new Guid("48045ae8-3c38-4a0f-8577-a89bbed70bf2"), "F_E1_2A_IntActor_TrailBlaze01_C2_Show"},
                        {new Guid("c46fa48e-5c98-4794-9840-9a0307676bcc"), "F_E1_2A_IntActor_FallenTree_C1_Climbover"},
                        {new Guid("6a29c807-2369-488e-a1ad-adff1345bee1"), "F_E1_2A_IntActor_Berries01_C1_Eat"},
                        {new Guid("b5927dab-3f6c-415b-aac4-237247c9b95f"), "F_E1_2A_IntActor_Berries01_C2_Look"},
                        {new Guid("4c41b432-175b-4eac-a513-d02d17adc54c"), "F_E1_2A_IntActor_Ledge_C1_ClimbDown"},
                        {new Guid("a48eaad9-1ff8-49cb-ad44-c4006b5251d0"), "F_E1_2A_IntActor_Berries04_C1_Eat"},
                        {new Guid("a6e62088-1520-48be-afcb-8ffc43822506"), "F_E1_2A_IntActor_Berries04_C2_Look"},
                        {new Guid("69611505-6f28-48a2-8920-8e7b26804f1c"), "F_E1_2A_IntActor_Berries04_C4_Check"},
                        {new Guid("eb31dfcf-a64b-4fd9-b4b5-b0d52777d59b"), "F_E1_2A_IntActor_SeanPhone_C1_Look"},
                        {new Guid("474d5241-b868-4bb4-ac57-5b7c52a97221"), "F_E1_2A_IntActor_Berries05_C1_Eat"},
                        {new Guid("7a63eb04-7adb-48fe-ae0e-db5d533bfd08"), "F_E1_2A_IntActor_Berries05_C2_Look"},
                        {new Guid("af12ff07-1d89-449f-bf04-4f2a8e313ebb"), "F_E1_2A_IntActor_SeanBag_C1_Look"},
                        {new Guid("c8bc4dba-c21f-4472-9234-56ee38c30963"), "F_E1_2A_IntActor_Drawing_C1_SitandDraw"},
                        {new Guid("22a8d010-dd8e-4cdb-82e7-6791aa9091ec"), "F_E1_2A_IntActor_Wallet_C1_Look"},
                        {new Guid("53e4d085-6981-47bb-87ea-aa80de4a0713"), "F_E1_2A_IntActor_Cookies_C1_Look"},
                        {new Guid("2e6a6d17-49b0-4d7e-9e26-45a7c2cb44f1"), "F_E1_2A_IntActor_Ants_C1_Look"},
                        {new Guid("5d7dde0a-9415-448e-84ac-dcfa3f7baccd"), "F_E1_2A_IntActor_BearMarks02_C2_Look"},
                        {new Guid("bb782cbf-2d1e-4932-953d-f9783bdcdc2a"), "F_E1_2A_IntActor_BirdNest_C1_Show"},
                        {new Guid("0e9b99dd-2800-4f88-a8e1-9b3c4a6344da"), "F_E1_2A_IntActor_Carving2_C1_Look"},
                        {new Guid("f656ab4f-1d16-4fba-a9b5-8d3f0f88a187"), "F_E1_2A_IntActor_CatFood_C1_Look"},
                        {new Guid("12125117-f5ac-4ba4-a682-45caf5596ed3"), "F_E1_2A_IntActor_DeadAnimal_C1_Look"},
                        {new Guid("24ceb230-1d7f-433d-9e07-160cbfb3d1aa"), "F_E1_2A_IntActor_DeadAnimal_C2_Discuss"},
                        {new Guid("5e94151b-b855-4afe-b5fd-1ebd4e48f46f"), "F_E1_2A_IntActor_HygieneSign_C1_Look"},
                        {new Guid("f9970676-d9c6-4ad2-8397-880eda3fc442"), "F_E1_2A_IntActor_Map_C1_Look"},
                        {new Guid("5dd1e409-4fbc-45ad-a8d2-0d2313d69f53"), "F_E1_2A_IntActor_Map_C2_Discuss"},
                        {new Guid("cc0cdb86-2238-4dd5-bdf6-91ea7cd53960"), "F_E1_2A_IntActor_Marks_C1_Look"},
                        {new Guid("5cbb91bf-c810-4c89-a139-a459fe9f63d8"), "F_E1_2A_IntActor_Paper_C1_Look"},
                        {new Guid("21241fa0-9c27-4673-98de-f78fac1ab7ae"), "F_E1_2A_IntActor_Paper_C2_Discuss"},
                        {new Guid("e0b5fbcd-e4a0-48b4-b45f-f627248fafda"), "F_E1_2A_IntActor_PicNicSign_C1_Look"},
                        {new Guid("9d7d8982-8f90-4429-bc21-427476411fff"), "F_E1_2A_IntActor_Polaroid_C1_Look"},
                        {new Guid("62a55a17-1abe-470a-acb6-fc2c5655a68e"), "F_E1_2A_IntActor_ShelfFungusTree_C1_Look"},
                        {new Guid("aca44ce9-898c-4801-b87d-502a6507a2a4"), "F_E1_2A_IntActor_Sign3_C1_Look"},
                        {new Guid("387eefaf-7a4a-4899-a5ab-fc2e08328c9c"), "F_E1_2A_IntActor_Sign4_C1_Look"},
                        {new Guid("f73e069e-4003-4275-979e-0dc79697e771"), "F_E1_2A_IntActor_Spikes02_C1_Look"},
                        {new Guid("c0e3c8c0-6cd7-43b0-a45a-9ed3ff111a70"), "F_E1_2A_IntActor_TagRocks02_C1_Look"},
                        {new Guid("7a4f1fb0-87d3-48e2-858f-68357388df11"), "F_E1_2A_IntActor_TrailDamage01_C1_Look"},
                        {new Guid("52ac87da-a870-4877-9bf6-985e92a99284"), "F_E1_2A_IntActor_TrailDamage02_C1_Look"},
                        {new Guid("633a0cf5-663a-4652-8ed8-f28c3a175596"), "F_E1_2A_IntActor_WaspNest_C1_Look"},
                        {new Guid("8fd24a7f-101d-4865-bf8e-eccbcec29c95"), "F_E1_2A_IntActor_WeaponRacks_C1_Look"},
                        {new Guid("852af7fc-bcf5-45a0-bbad-88fb747a763c"), "F_E1_2A_IntActor_WelcomePaper_C1_Look"},
                        {new Guid("5fa20f96-6175-4a62-9ac1-1a6e6ae7d594"), "F_E1_2A_IntActor_SpiderWeb_C1_Explain"},
                        {new Guid("983782f8-b13b-488b-86e4-2368d9a87abd"), "F_E1_2A_IntActor_DanielSkimStone_C1_Teach"},
                        {new Guid("6fd2a40e-9959-4e0c-bf1e-11625d55aed1"), "F_E1_2A_IntActor_Fishing_C2_Cheerup"},
                        {new Guid("ac9c3f8f-72ab-4df3-b804-dcb51ddf6da3"), "F_E1_2A_IntActor_Log11_C1_Take"},
                        {new Guid("a42b3a9e-f6d0-4649-b7fc-3e50f1e7b31c"), "F_E1_2A_IntActor_SwordFight_C3_Play"},
                        {new Guid("7f7412ef-243c-45c6-a317-72b9d009ae50"), "F_E1_2A_IntActor_Toilet_C1_Look"},
                        {new Guid("07d87600-8826-419e-a1f2-18d19092fb9b"), "F_E1_2A_IntActor_Log13_C1_Take"},
                        {new Guid("3b497320-2b34-4f88-ba49-96120c70e08d"), "F_E1_2A_IntActor_TrailBlaze2_C1_Look"},
                        {new Guid("489d54e9-e59d-48df-a019-4eff078af4c8"), "F_E1_2A_IntActor_Berries01_C3_Look"},
                        {new Guid("95e4c151-1b4b-4161-b5be-e82dccb09175"), "F_E1_2A_IntActor_Berries02_C1_Eat"},
                        {new Guid("d20421be-84a8-4692-bc08-73aa9321432a"), "F_E1_2A_IntActor_Berries02_C2_Look"},
                        {new Guid("8777a262-6fc5-4bfe-9b20-3281f5e2acdc"), "F_E1_2A_IntActor_Berries02_C3_Look"},
                        {new Guid("80e35a58-248e-43e3-bdf0-1ea734b6a9bf"), "F_E1_2A_IntActor_Berries02_C5_Show"},
                        {new Guid("cf68e60d-0e35-45f4-8d00-01a38716dd5b"), "F_E1_2A_IntActor_Berries04_C3_Look"},
                        {new Guid("1baedb9f-c82e-408c-9f98-3d9a0301a2b6"), "F_E1_2A_IntActor_Berries05_C3_Look"},
                        {new Guid("de6aee94-7166-49d8-b0a5-d894eb0bfcf7"), "F_E1_2A_IntActor_Berries05_C5_Show"},
                        {new Guid("38b4f5fe-8a92-4815-a8e1-8a4d1528bf44"), "F_E1_2A_IntActor_Berries06_C3_Look"},
                        {new Guid("ec8b75f2-b94f-4876-810c-bb22d0f0e905"), "F_E1_2A_IntActor_SeanBag_C2_Look"},
                        {new Guid("0a88222e-1d82-4835-a6aa-7dc65ecc7ab5"), "F_E1_2A_IntActor_MailboxRock_C1_BreakBox"},
                        {new Guid("399d8b04-a567-4b56-9790-3347256515c8"), "F_E1_2A_IntActor_LogStack01_C1_Check"},
                        {new Guid("7c7516e2-a2c1-4559-8aa0-17b5b68e8021"), "F_E1_2A_IntActor_SodaCan_C1_Look"},
                        {new Guid("240be55c-3ad2-40b3-9aca-b25e763c3425"), "F_E1_2A_IntActor_BearMarks02_C1_Look"},
                        {new Guid("14c83925-8c6d-4985-abb2-3cb874ab656e"), "F_E1_2A_IntActor_Carving1_C1_Look"},
                        {new Guid("14bc85fd-86e8-4621-a904-04df9ca74e9d"), "F_E1_2A_IntActor_Landslide_C1_Look"},
                        {new Guid("948c6e2b-d86e-4467-9779-f890681fb746"), "F_E1_2A_IntActor_Mailbox_C1_Open"},
                        {new Guid("0a4781fd-720a-4a3f-8dff-0d14876b4a25"), "F_E1_2A_IntActor_Mailbox_C2_Look"},
                        {new Guid("368a90f4-0c05-4b98-9f99-36713aa94e13"), "F_E1_2A_IntActor_Mailbox_C3_Look"},
                        {new Guid("69639c37-a3f3-4724-9736-1e07c8033dd8"), "F_E1_2A_IntActor_Mailbox_C4_Look"},
                        {new Guid("87e13bc5-27e4-48ef-a520-fb56e45b4bcf"), "F_E1_2A_IntActor_Tag01_C1_Look"},
                        {new Guid("7ba5c249-c7cc-44e2-9898-a06415165a9a"), "F_E1_2A_IntActor_TrailBlaze_C1_Look"},
                        {new Guid("59662f4a-9b92-4461-b3f7-29bd8864e21e"), "F_E1_2A_IntActor_TrailDamage01_C2_Discuss"},
                        {new Guid("b5fbd89c-8908-41a2-ace5-40e9414a7637"), "F_E1_2A_IntActor_WelcomePaper_C2_Discuss"},
                        {new Guid("3a5cbb06-4537-4d00-a0a5-843ca53eecfd"), "F_E1_2A_IntActor_Bench_C1_Sit"},
                        {new Guid("0eab79fb-1966-45d5-983f-dddd4e9ac0d9"), "F_E1_2A_IntActor_SwordFight_C2_Duel"},
                        {new Guid("d6101701-0955-41f2-9d0d-57d5c87b81e8"), "F_E1_2A_IntActor_SkimStone_C2_Look"},
                        {new Guid("beb61c48-12ac-410c-b687-fd774d753880"), "F_E1_2A_IntActor_Car_C2_Look"},
                        {new Guid("8f08859e-6382-4efe-8369-5ad50cae4fde"), "F_E1_2A_IntActor_Log17_C1_Take"},
                        {new Guid("22cee9aa-3a59-4093-98f4-2f979442ccc8"), "F_E1_2A_IntActor_SeanPhone_C2_Look"},
                        {new Guid("d8fc4800-e454-4860-ab3e-257df82d5a26"), "F_E1_2A_IntActor_Lighter_C1_Look"},
                        {new Guid("5c7f88b6-9438-4f80-9cc8-070caff72941"), "F_E1_2A_IntActor_BeerCan_C1_Look"},
                        {new Guid("7d252190-fbb2-49f6-886a-7f7a095ef6f0"), "F_E1_2A_IntActor_Ledge2_C1_Getup"},
                        {new Guid("f96c7144-0619-4470-b750-b8ffdad38c89"), "F_E1_2A_IntActor_Spikes01_C1_Look"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "ced8c2ab-0115-4e53-859a-0f56ee663e4a", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("1181851b-18c9-410e-acf1-7b695876297e"), "F_E1_2A_POI_DiscoverShelter"},
                        {new Guid("12d5fa20-534e-463b-acfb-10819308f1a9"), "F_E1_2A_POI_HideAndSeek"},
                        {new Guid("0db3b006-bfcc-4742-8c01-b7c8320de627"), "F_E1_2A_POI_Raccoon"},
                        {new Guid("0844c053-45a3-480f-a7c7-26814f6548f7"), "F_E1_2A_POI_TrailEntrance"},
                        {new Guid("741389e4-645a-4769-bc2a-7aef33559fac"), "F_E1_2A_POI_Car"},
                        {new Guid("a9ff0c52-799a-4b22-ab7d-3e93face9e05"), "F_E1_2A_POI_WildLifeSign"},
                        {new Guid("5ab84e5f-921b-4678-8b9a-a4a041956e9d"), "F_E1_2A_POI_Cliff"},
                        {new Guid("06e51eb8-afcc-4af0-9ad2-b5b2c76c7269"), "F_E1_2A_POI_NoCampingSign"},
                        {new Guid("7f94a4cd-ec0b-43d2-8e38-fadafa9bc95b"), "F_E1_2A_POI_BuildFort_WeaponRacks"},
                        {new Guid("32dc880d-3f3f-4b4c-b860-c89d4e8778e7"), "F_E1_2A_POI_TrailBlaze04"},
                        {new Guid("28fc0591-4709-46ec-81f7-51bca74a5ccc"), "F_E1_2A_POI_TrailBlaze01"},
                        {new Guid("51b7d849-79a5-42d5-a4ab-a9fc8fff92f5"), "F_E1_2A_POI_BuildFort_LookAround5"},
                        {new Guid("38c3d48c-9a45-46a1-91d1-2a303c4f0c71"), "F_E1_2A_POI_FallenTree"},
                        {new Guid("f7e4cd2a-e21f-4119-9607-d7e51784da04"), "F_E1_2A_POI_Berries03_DanielFound"},
                        {new Guid("eaf3eb57-a2e7-482d-9318-5cf5e094a88c"), "F_E1_2A_POI_Berries04_DanielFound"},
                        {new Guid("835cb8a3-e398-47c9-a596-36e7accd5484"), "F_E1_2A_POI_HiddenVista"},
                        {new Guid("fa3c5bcd-df93-4b97-9a84-8daad9cce793"), "F_E1_2A_POI_TreeFungus"},
                        {new Guid("d5eab3dd-cf30-4b4b-aa80-1a6cd6d0371a"), "F_E1_2A_POI_BuildFort_TakeWood03"},
                        {new Guid("53384d89-9b56-4c9b-a0fa-2dd95f2a69cb"), "F_E1_2A_POI_BuildFort_PushTrunk"},
                        {new Guid("06a234c0-e9df-40b4-822d-6983dcc4c178"), "F_E1_2A_POI_Fishing_Forti"},
                        {new Guid("0e882936-ad97-414d-b4e5-fc36d97a67bc"), "F_E1_2A_POI_SmallDropDown01"},
                        {new Guid("651cd961-ff35-4ecb-9886-c4859120e153"), "F_E1_2A_POI_BuildFort_Pikes"},
                        {new Guid("afc90129-1151-4b0c-9d82-a977907c6af1"), "F_E1_2A_POI_SmallDropDown02"},
                        {new Guid("896c00c8-c66b-4c25-bfe5-f400965b1ed2"), "F_E1_2A_POI_SkimStone"},
                        {new Guid("358aefa8-f2f4-46c0-822c-94873b690828"), "F_E1_2A_POI_SwordFight"},
                        {new Guid("52d16bc6-b6e7-4c21-ad74-136d93dcad58"), "F_E1_2A_POI_BuildFort_TakeWood02"},
                        {new Guid("782ca510-3c0c-467a-a0fe-4e2cbd473cfd"), "F_E1_2A_POI_BuildFort_LookAround3"},
                        {new Guid("0a12da26-7810-45b0-a97f-ddf3acfde55e"), "F_E1_2A_POI_SpiderWeb"},
                        {new Guid("9925eeb2-0be5-42ea-91ee-d1663983f2c5"), "F_E1_2A_POI_DeadAnimal"},
                        {new Guid("4e3152f6-0756-4e15-b4b1-f77f6a307074"), "F_E1_2A_POI_ClimbDown"},
                        {new Guid("9563a00d-700a-4b6d-b072-d96e3d3653aa"), "F_E1_2A_POI_BearMarkings"},
                        {new Guid("0f2a157b-266b-4d06-9e87-4c1436d8d39b"), "F_E1_2A_POI_Berries01_FoundKnownSpot"},
                        {new Guid("9b49198e-fedc-4885-ac6d-230f0934489a"), "F_E1_2A_POI_Berries05_FoundKnownSpot"},
                        {new Guid("f1591e0f-53a0-4d71-8279-e6a3f5c1fe45"), "F_E1_2A_POI_BirdNest"},
                        {new Guid("2fd363e6-0ae9-4f8c-811f-f4170316dd63"), "F_E1_2A_POI_BuildFort_TakeWood01"},
                        {new Guid("889a14af-514b-4323-9e93-ce914bb23d1f"), "F_E1_2A_POI_FeeTube"},
                        {new Guid("e9f95fbe-7eb1-488f-a9a5-a1eedb3329d7"), "F_E1_2A_POI_HideAndSeek_Spot07_PoI05"},
                        {new Guid("842ffbbd-6e8f-416b-b836-e99aa508c570"), "F_E1_2A_POI_Lean05"},
                        {new Guid("b81c9b7b-b6d9-42df-8e65-293086c84e16"), "F_E1_2A_POI_leanCar01"},
                        {new Guid("e93cf8ad-bff7-47a6-bde0-10e9eb71c955"), "F_E1_2A_POI_LookAround01"},
                        {new Guid("4dd4783f-a9cb-429c-b406-b7fd79c0bebf"), "F_E1_2A_POI_LookingForCar"},
                        {new Guid("582b8963-8d04-41d4-8bf2-37ee7ba44475"), "F_E1_2A_POI_LookOver03"},
                        {new Guid("1b74374c-36f6-4fdb-96fc-7805d61a8083"), "F_E1_2A_POI_Parking_Vault02"},
                        {new Guid("ea788b53-9a9e-4a5d-b101-62f4bf7dab05"), "F_E1_2A_POI_Parking_Vault03"},
                        {new Guid("426e13dc-325f-49a4-9bb7-a7fe4da9bbb1"), "F_E1_2A_POI_Picnic_Vault01"},
                        {new Guid("1fbf085b-06fa-4caa-8ce2-44a26117b2d7"), "F_E1_2A_POI_Picnic_Vault02"},
                        {new Guid("07fc534e-f45f-484b-a230-487eccfc27bd"), "F_E1_2A_POI_Picnic_Vault06"},
                        {new Guid("dae27385-cd96-4c6f-b95d-bd28a9d0b760"), "F_E1_2A_POI_Picnic_Vault10"},
                        {new Guid("18666e9f-2d7e-40cd-a25a-511bb3bf8754"), "F_E1_2A_POI_PicnicSign"},
                        {new Guid("b67b805d-c5c6-41e5-b529-cc465e1e7243"), "F_E1_2A_POI_ReadTableCarving01"},
                        {new Guid("a955f659-333f-4209-9e73-3cf562bb85aa"), "F_E1_2A_POI_Shelter_Vault01"},
                        {new Guid("71f17f5e-1e5c-4a54-a6f9-f83e7eafd90f"), "F_E1_2A_POI_Shelter_Vault02"},
                        {new Guid("855b99d3-9c7c-4bfe-8ea3-aaf87d871683"), "F_E1_2A_POI_Shelter_Vault03"},
                        {new Guid("ffe45a4f-6082-4ddc-b3d0-0a5730f169cf"), "F_E1_2A_POI_Shelter_Vault06"},
                        {new Guid("003305d3-5d3e-4888-9a93-c7b4e12740a7"), "F_E1_2A_POI_Shelter_Vault07"},
                        {new Guid("d3fd80cf-076a-498b-abed-75642fdae12b"), "F_E1_2A_POI_Shelter_Vault09"},
                        {new Guid("b70fe620-4aee-4737-9436-fa355c00d985"), "F_E1_2A_POI_SitTable"},
                        {new Guid("a4cf65c7-c072-4499-b89f-abc0c3bf6949"), "F_E1_2A_POI_TrailBlaze02"},
                        {new Guid("8ac72f9b-9a0f-4d0a-9766-d65594085d5e"), "F_E1_2A_POI_TrailBlaze03"},
                        {new Guid("62143eaa-7188-4375-adaa-b9bfb8a77522"), "F_E1_2A_POI_HelpFire_DumpWood"},
                        {new Guid("51312153-0159-4362-af6d-82dc63911497"), "F_E1_2A_POI_Fishing"},
                        {new Guid("c0fad90f-b706-482c-a462-de21910375f6"), "F_E1_2A_POI_MainTrail_Vault01"},
                        {new Guid("e3d5f870-b6a9-4e06-a728-e54bdcdb05d6"), "F_E1_2A_POI_HelpFire_TakeWood02_02"},
                        {new Guid("aadc1b89-c740-472d-b9af-b548a041a4b8"), "F_E1_2A_POI_HelpFire_TakeWood03_02"},
                        {new Guid("ee116bf4-4269-4b65-a771-9bffbc6f9ce8"), "F_E1_2A_POI_Berries02_ShowDaniel"},
                        {new Guid("46c45ee6-3b69-4f22-925e-05f28fa0b51b"), "F_E1_2A_POI_Berries05_ShowDaniel"},
                        {new Guid("23e43155-5342-4cb8-a30d-1f50511442f2"), "F_E1_2A_POI_Landslide"},
                        {new Guid("d0277103-f325-4d7e-994d-ef5e78f82f7c"), "F_E1_2A_POI_LookAtSignRoad"},
                        {new Guid("4e805929-ff26-4f47-bcd7-df0028f5fb42"), "F_E1_2A_POI_LookOver06"},
                        {new Guid("d1b36484-1077-4777-a5a9-2f3c5c618c65"), "F_E1_2A_POI_Parking_Vault04"},
                        {new Guid("221a088d-8d02-463f-aac2-bca3be4f1fc9"), "F_E1_2A_POI_SecPath_Vault02"},
                        {new Guid("40dff057-e0f0-4774-8587-c6ff59a180d9"), "F_E1_2A_POI_SitTrunk_16"},
                        {new Guid("e2e59680-0e79-4369-b7c4-70340bf19a75"), "F_E1_2A_POI_SecondaryPathDiscovered"},
                        {new Guid("96c74cfc-5e12-497b-930d-981ad267dea4"), "F_E1_2A_POI_MainTrail_Vault02"},
                        {new Guid("339b5766-1fa5-4999-8d41-9f25a1ad2f24"), "F_E1_2A_POI_HideAndSeek_Spot01_PoI06"},
                        {new Guid("8834a12c-d55e-4ad4-877d-a757087d04af"), "F_E1_2A_POI_HideAndSeek_Spot10_PoI07"},
                        {new Guid("2be733d4-3096-42d7-a993-deae037b4c1f"), "F_E1_2A_POI_ReadTableCarving02"},
                        {new Guid("0b25bfe7-47cf-47a1-bbfd-39fc43713744"), "F_E1_2A_POI_TreeCarving"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "23dce93e-dccf-4487-806b-103a84900ada", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("46542e23-c5c7-4ef7-a04a-c9e3187ea2a9"), "F_E1_5A_GasStation_Outside_BegFoodSean"},
                        {new Guid("5bc425b4-8839-40a9-b82f-efe6c9fc5cb8"), "F_E1_5A_GasStation_Inside_InteruptDanielSpeakGSTL"},
                        {new Guid("3c826176-58d8-4bdb-b304-a8a2a20ec0d7"), "F_E1_5A_GasStation_Inside_HasEnoughMoney"},
                        {new Guid("77d79125-f1b5-4e36-bff2-0ede46d8e205"), "F_E1_5A_GasStation_Inside_DanielGrabMachine"},
                        {new Guid("69fac30e-84ad-4c52-9e65-c10bc0d40c52"), "F_E1_5A_GasStation_Inside_ShouldPlayGrabMachine"},
                        {new Guid("b73a5dad-4c58-443c-b204-d670df91ec77"), "F_E1_5A_GasStation_Inside_Suspicious"},
                        {new Guid("3e519db7-418b-41ce-8f3c-a1f19aa696ce"), "F_E1_5A_GasStation_Inside_SeanHasWonPowerBear"},
                        {new Guid("e410c9cf-1310-45fc-a918-a731cf5f2f5a"), "F_E1_5A_GasStation_Inside_DanielWonPowerBear"},
                        {new Guid("c6a9f5e1-2fc8-4b76-97f8-7a293dd34886"), "F_E1_5A_GasStation_Inside_HasStolenSomething"},
                        {new Guid("72cb2885-1c68-4dbb-b721-bf90c5237c8e"), "F_E1_5A_GasStation_Inside_IsPettingPuppy"},
                        {new Guid("1d5a1339-1d10-47bb-af20-c8a396054811"), "F_E1_5A_GasStation_LookForFood"},
                        {new Guid("ad5e972c-d7ad-4036-9c70-b4c405b8fd7a"), "F_E1_5A_GasStation_LookForDrinks"},
                        {new Guid("930e185b-e20d-4364-bb46-9f78b05db74a"), "F_E1_5A_GasStation_FindAMap"},
                        {new Guid("65ef491a-58f7-4215-b6e8-b1b4bcd3af57"), "F_E1_5A_GasStation_Inside_DanielIsBusy"},
                        {new Guid("34578527-81d8-40c2-8d18-1552a1097218"), "F_E1_5A_GasStation_Inside_HasBoughtSomething"},
                        {new Guid("e13430b4-8d2a-461f-89ae-19269f3c1b41"), "F_E1_5A_GasStation_Inside_TriesPayNotEnought"},
                        {new Guid("6738d43a-c501-4b86-b367-99dddd831378"), "F_E1_5A_GasStation_Outside_HUB_Halloween"},
                        {new Guid("68c44b71-a900-4658-a0a4-7693d75be1a5"), "F_E1_5A_GasStation_Outside_HUB_Food"},
                        {new Guid("0c735771-abde-482d-8b9b-4c724d96c414"), "F_E1_5A_GasStation_IsInside"},
                        {new Guid("1b3d0266-4571-441e-8750-b4db396c3a55"), "F_E1_5A_GasStation_Inside_LadyBusywithSean"},
                        {new Guid("cfe13b5a-b563-4a2b-8b9a-8f356737c7df"), "F_E1_5A_GasStation_Inside_HasSeenLeaveMap"},
                        {new Guid("1c6d0d63-2209-4a97-a7d7-e5b81666eaef"), "F_E1_5A_GasStation_Inside_TalkNearAirVentDone"},
                        {new Guid("d1a59d61-127b-4b4a-86aa-904197203ad9"), "F_E1_5A_GasStation_Night"},
                        {new Guid("2b8d0d9e-8c34-49c6-ae2d-31c7813d9c6f"), "F_E1_5A_GasStation_Objective_Escape"},
                        {new Guid("c9008d79-2dba-4f31-853f-54efb5c637eb"), "F_E1_5A_GasStation_ReachGS"},
                        {new Guid("1892b876-3e03-4005-8aec-3c1ce6c8f7a1"), "F_E1_5A_GasStation_Inside_DanielBroughtTool"},
                        {new Guid("71f8438d-ae2a-44e5-ad0b-1f1356cfd651"), "F_E1_5A_GasStation_KnowsBrodyName"},
                        {new Guid("18cb2aae-ee4d-4a3a-9e28-70834603ff29"), "F_E1_5A_GasStation_KnowsHankName"},
                        {new Guid("e0287535-cdc5-471f-9814-75fd92412cd9"), "F_E1_5A_GasStation_Inside_DoingGMPOI"},
                        {new Guid("1a226813-e810-4ae8-bbf7-bf198f5651cd"), "F_E1_5A_GasStation_Outside_CanLaunchInsertionInnerVoices"},
                        {new Guid("b3b0f1fd-5508-457b-a187-a50fe15615ac"), "F_E1_5A_GasStation_Outside_CanReceivedSMS"},
                        {new Guid("3a8ca174-d471-4053-a597-3eef4fd28a5b"), "F_E1_5A_GasStation_Inside_DanielChocobarPOI"},
                        {new Guid("dc2b7ec0-128a-4ad2-b0da-208c1dc21728"), "F_E1_5A_GasStation_Outside_ZenSequenceCompleted"},
                        {new Guid("d9f27820-2244-49e4-9ede-b48e715f68e3"), "F_E1_5A_GasStation_Outside_DestroyTruck"},
                        {new Guid("1b87364f-ade8-4ed1-94fd-f468436e7946"), "F_E1_5A_GasStation_Inside_IsPuppyAwake"},
                        {new Guid("55e844f7-3f52-4484-9636-55bdba41b350"), "F_E1_5A_GasStation_Inside_PoIDorisPlaying"},
                        {new Guid("93c89fe7-309c-4c93-a519-131ec672b791"), "F_E1_5A_GasStation_Outside_FamilyUpset"},
                        {new Guid("a3de6f7e-e554-4932-8d0e-8e5107972f14"), "F_E1_5A_GasStation_Inside_ComeFromRemoveItem"},
                        {new Guid("73670f77-413c-42b5-aa36-3d5c9e44382a"), "F_E1_5A_GasStation_Outside_HUB_Visiting"},
                        {new Guid("f6c59fd9-b18d-4339-aa54-f0809999041f"), "F_E1_5A_GasStation_Outside_SeanIsInToilets"},
                        {new Guid("799408fd-3e98-4df1-a158-c21df814904d"), "F_E1_5A_GasStation_Outside_DanIsInToilets"},
                        {new Guid("a0618e36-8470-4d7f-aea1-3a21faa8d0a4"), "F_E1_5A_GasStation_Outside_HUB_NoHalloween"},
                        {new Guid("02d2a24c-def3-4b58-a096-2aab2fbf71b6"), "F_E1_5A_GasStation_Inside_DirectRemoveItem"},
                        {new Guid("af9ddd3f-f5a6-4505-ac27-b6a3ea5c9773"), "F_E1_5A_GasStation_Outside_BegFoodDaniel"},
                        {new Guid("23e3f028-f90e-454b-a3ae-a614b52e74e5"), "F_E1_5A_GasStation_Inside_GetOutPuppyStarted"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("68d6eddd-cd4c-4c56-8abf-c2dd792ed53b"), "F_E1_5A_GasStation_Outside_FamilyMood"},
                        {new Guid("76cfb6e5-0807-4721-a38a-02036c843cf8"), "F_E1_5A_GasStation_Inside_PayStep"},
                        {new Guid("203e8c6d-ab32-444b-adfa-c997c060e86e"), "F_E1_5A_GasStation_Inside_GMDanielTries"},
                        {new Guid("6b2aaf71-8ef7-4583-989a-7432175c11b5"), "F_E1_5A_GasStation_Inside_PayNumberOfTime"},
                        {new Guid("fe37b5b9-2901-442f-a32a-95935c629534"), "F_E1_5A_GasStation_Inside_Crosswords"},
                        {new Guid("edd5bce3-b72e-4f04-8dbd-53f6ff26c254"), "F_E1_5A_GasStation_Inside_NumberItemsOnDesk"},
                        {new Guid("46b774f4-3195-4820-9684-5f5748dd5faf"), "F_E1_5A_GasStation_Inside_GMSeanTries"},
                        {new Guid("c3dddc8c-b2c0-4dbb-a550-cd5fd566aba4"), "F_E1_5A_GasStation_Inside_CantStealCues"},
                        {new Guid("5e6505c6-514e-4422-8902-07d821e1343b"), "F_E1_5A_GasStation_Inside_FailedToSteal"},
                        {new Guid("5e862243-5e62-42af-a66b-6f2d208956fc"), "F_E1_5A_GasStation_Inside_PriceToPay"},
                        {new Guid("d9450025-b4cf-44e8-9e63-9982163d87cc"), "F_E1_5A_GasStation_Inside_UsedMoneyOnce"},
                        {new Guid("94509e31-66b1-41ac-920a-1df9d131c390"), "F_E1_5A_GasStation_Inside_PayTotalSequence"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("d683b719-2b46-4d78-bdd8-307e78d04750"), "F_E1_5A_GasStation_Inside_ChocoCrispStatus"},
                        {new Guid("c7a34168-044d-4955-939c-ac3b8c201d37"), "F_E1_5A_GasStation_Inside_WaterBottleStatus"},
                        {new Guid("ba67d013-3636-47ea-9141-4247f02b0431"), "F_E1_5A_GasStation_Inside_CanStatus"},
                        {new Guid("d0c09577-662f-49e6-bdc6-98f19f2a9510"), "F_E1_5A_GasStation_Inside_BroTalkToCustomer"},
                        {new Guid("f52c692a-2c74-4f5f-b743-f429f07e4a0d"), "F_E1_5A_GasStation_Inside_ToolStatus"},
                        {new Guid("dc6649db-57c7-479e-8ff6-7fc904c8f83f"), "F_E1_5A_GasStation_Inside_GMState"},
                        {new Guid("a1bbaf76-b1c4-447c-9449-8690f6d25269"), "F_E1_5A_GasStation_TotalFood"},
                        {new Guid("07fe1bb9-3312-4581-b627-e394f554513c"), "F_E1_5A_GasStation_Inside_SleepingBagStatus"},
                        {new Guid("ab1b4aa2-5515-41b0-8cb9-40ab3e60734a"), "F_E1_5A_GasStation_Inside_SandwichStatus"},
                        {new Guid("20d58722-a5d7-4e52-8869-4555f3a0cef2"), "F_E1_5A_GasStation_Inside_SlicedBreadStatus"},
                    },
                }
            },
            {
                "b26ffabf-a347-4f18-83f6-162f05cc835a", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("1c469ece-649e-467b-9926-3fd9998c4b38"), "F_E1_5A_Inside_SwitchPosGM_C"},
                        {new Guid("a304e54e-3d9f-4606-adf0-3663a36e6e86"), "F_E1_5A_Inside_StartGM_C"},
                        {new Guid("c5016c95-4833-468a-833a-58df0f5d688b"), "F_E1_5A_Inside_Pay_C"},
                        {new Guid("d77ce8fa-4553-400f-ad01-d211eac6ca5d"), "F_E1_5A_GasStation_Office_AskForTool_C"},
                        {new Guid("714e3b88-e49a-4088-8bd8-e5aff442897f"), "F_E1_5A_GasStation_Office_WakeUpInOffice_C"},
                        {new Guid("3af102cd-e526-4ce2-9031-ee7271ac5921"), "F_E1_5A_Office_CheckWindow_C"},
                        {new Guid("b792dde0-32bf-40ed-aff2-61a37aa921cf"), "F_E1_5A_Outside_Family_C"},
                        {new Guid("e03b9a4b-a7be-4c9b-bcbe-05617d314980"), "F_E1_5A_Inside_ExaminePuppy_C"},
                        {new Guid("1880f1bd-0e46-42fb-9a1d-27a885f2935d"), "F_E1_5A_Inside_SpeakShopKeeper_C"},
                        {new Guid("a0f52995-8e67-4046-9ade-6bda225eee63"), "F_E1_5A_Inside_JRNLSpeak_C"},
                        {new Guid("73d0ec94-709a-40f6-b58c-7274cc65b095"), "F_E1_5A_Inside_PuppyPoI_C"},
                        {new Guid("d8123f34-7792-4506-86a1-b3b07d96e159"), "F_E1_5A_Outside_WildPoster_PoI_C"},
                        {new Guid("4747f5b7-b34e-41e1-b862-e590ab0686ef"), "F_E1_5A_Inside_Witch_C"},
                        {new Guid("ef3d0726-1257-4d58-9ff1-12dec347071d"), "F_E1_5A_Inside_GMPoI_C"},
                        {new Guid("8795df56-7459-402a-9f74-81b3de1cd3ad"), "F_E1_5A_Inside_ShockOCrisp_C"},
                        {new Guid("c56bf4d6-51dc-4b18-8fbc-c17bdd6c4ff9"), "F_E1_5A_Inside_BeerPoster_C"},
                        {new Guid("ad168ba0-1e48-4ccb-a5fd-3658a273505d"), "F_E1_5A_Inside_CardboardPowerBear_C"},
                        {new Guid("be25c596-523e-4ce2-8ddf-ed5a2633c941"), "F_E1_5A_Inside_Postcard_C"},
                        {new Guid("b7a704c4-d0cd-4e14-b41a-8440fd0f584f"), "F_E1_5A_Inside_Tent_C"},
                        {new Guid("762e8272-dddf-434a-a548-16a288a85932"), "F_E1_5A_Inside_Pumpkin_C"},
                        {new Guid("2f5d3066-94d3-4fcd-91ff-8702a40cc0a9"), "F_E1_5A_Outside_BearShelves_C"},
                        {new Guid("d829f527-80d1-45bb-bf8d-2f64093e29fa"), "F_E1_5A_Outside_GSDiscovery_C"},
                        {new Guid("1b37f341-9600-42c0-a28a-b36abdaaa471"), "F_E1_5A_Inside_RandomA_C"},
                        {new Guid("1b3578e7-a763-4d61-b0e2-4aed62dccf5c"), "F_E1_5A_Inside_RandomB_C"},
                        {new Guid("ecbf50f5-9c9d-4105-8961-3068deb90d62"), "F_E1_5A_Outside_RandomB_C"},
                        {new Guid("8c6a709f-9479-47b7-a705-6628044f2826"), "F_E1_5A_Outside_RandomC_C"},
                        {new Guid("b2d1e662-424b-4ed0-aabe-2ccc4ca06974"), "F_E1_5A_Inside_HalloweenCostume_C"},
                        {new Guid("0bff652e-0e16-45de-8549-85cd2cc91038"), "F_E1_5A_Inside_FirstEntrance_C"},
                        {new Guid("2e1448f6-5cd5-4699-a36b-58f2a440bdfe"), "F_E1_5A_Outside_SpanishLessons_C"},
                        {new Guid("0e448726-c8f5-4eb2-86b3-6d9bdaefd45d"), "F_E1_5A_Outside_DanielReactFoodBeg_C"},
                        {new Guid("3bf7a049-8218-4fbd-849b-597c5ec4ffc4"), "F_E1_5A_Office_LockedDoor_C"},
                        {new Guid("9c108fc8-7c6e-4abe-a1bb-0ba1b397d420"), "F_E1_5A_Office_ScaredC_C"},
                        {new Guid("76aefa22-230f-4b7a-8037-f1c5262323de"), "F_E1_5A_Office_ScaredD_C"},
                        {new Guid("c28f0b0b-4d2a-4672-ab25-f826fc1f5c27"), "F_E1_5A_Outside_ChitChat_C"},
                        {new Guid("5f7ca12d-dfd0-4c6c-a5b6-5138cb91b39d"), "F_E1_5A_Inside_InteruptBroLady_C"},
                        {new Guid("468afedf-8dc2-48c0-a9a3-183107fde892"), "F_E1_5A_Outside_CampingSign_C"},
                        {new Guid("139de9c0-a3bd-42bf-b498-651cc92bc7de"), "F_E1_5A_Outside_JunkPile_C"},
                        {new Guid("422e296a-1258-4ac5-89cf-8be43b0db697"), "F_E1_5A_Outside_DanielBegFamily_C"},
                        {new Guid("59750b74-59ea-41d4-af4b-48fcdaeeb746"), "F_E1_5A_Inside_Sweater_C"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("98df6f68-feee-4276-b481-9d9343612e41"), "F_E1_5A_Inside_SwitchPosGM_LetHimPlay1"},
                        {new Guid("cf6cd875-0e35-4b03-9e8c-011cb977fe76"), "F_E1_5A_Inside_SwitchPosGM_Play1"},
                        {new Guid("4b26867f-f7c3-4862-87ed-7c8cd4c97ddb"), "F_E1_5A_Inside_SwitchPosGM_Play2"},
                        {new Guid("c29e8009-7e64-4f5b-a81e-80b0010ae313"), "F_E1_5A_Inside_StartGM_WhoFirst"},
                        {new Guid("d46405ba-ea80-4c7a-b908-8b1a6466704a"), "F_E1_5A_Inside_Pay_Pay"},
                        {new Guid("48c45475-eb2b-4908-b4a7-77aacdded1bf"), "F_E1_5A_Office_AskForTool_TypeTool"},
                        {new Guid("4da04555-e876-48a8-a4cb-9885cb0302b9"), "F_E1_5A_Office_WakeUpInOffice_Choice"},
                        {new Guid("2a6084d3-3423-4985-8d33-0e5b7b71b4ed"), "F_E1_5A_Outside_Family_HUB"},
                        {new Guid("8da72c0c-b5d1-4b23-810a-6458e2a718f6"), "F_E1_5A_Inside_ExaminePuppy_TakePuppy"},
                        {new Guid("425c96d5-59f2-4216-a66d-9cc7bda05760"), "F_E1_5A_Inside_SpeakShopKeeper_WhyHere"},
                        {new Guid("5092c9b8-f06b-4fba-94d9-14402a1e900b"), "F_E1_5A_Inside_SpeakShopKeeper_Parents"},
                        {new Guid("3fc008c1-bf32-4628-9363-3a534d1c98df"), "F_E1_5A_Inside_SpeakShopKeeper_LongTrip"},
                        {new Guid("0c203b74-cd4c-4547-8f74-080305eb8e5e"), "F_E1_5A_Inside_JRNLSpeak_People"},
                        {new Guid("98538f69-e306-4f90-8d9b-4c0322b9dbb4"), "F_E1_5A_Inside_JRNLSpeak_Travelling"},
                        {new Guid("a5948bad-e4a4-436d-b90b-d47607999715"), "F_E1_5A_Inside_FirstEntrance_Choice00"},
                        {new Guid("84c6634c-81c7-42a8-8677-23bcc3b257dd"), "F_E1_5A_LevelChoice_HalfEatenApple"},
                        {new Guid("f4bbeeb1-605c-4ed1-af5b-f9bd248fb7ce"), "F_E1_5A_LevelChoice_Owner_PicNic"},
                        {new Guid("ee2d744e-fe9c-4637-89c2-414ae27f5d25"), "F_E1_5A_LevelChoice_NightChoice_1"},
                        {new Guid("5410b798-b722-467e-9061-e83d042583f8"), "F_E1_5A_LevelChoice_NightChoice_2"},
                        {new Guid("eb8c4253-3331-4cdd-9434-e444cffae3c2"), "F_E1_5A_Outside_ChitChat_GetOutReaction"},
                        {new Guid("c94a2565-b121-474f-b887-78d4223c787a"), "F_E1_5A_Office_AskForTool_Location"},
                        {new Guid("67d25768-30c1-4653-a7c9-87444b872f7e"), "F_E1_5A_Outside_Family_Weather"},
                        {new Guid("f13e7ff9-46e0-4728-8fcb-e88ab1114379"), "F_E1_5A_Outside_DanielBegFamily_Convince"},
                    },
                }
            },
            {
                "77d2dd30-8e65-412f-9fc2-b2f4186815f7", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("45e3639b-b7d4-4404-9636-b1913e75faf9"), "F_E1_5A_IntActor_TruckSticker_C1_Take"},
                        {new Guid("249bfc51-5392-414f-b847-d64e0f3c259a"), "F_E1_5A_IntActor_TruckSticker_C2_Look"},
                        {new Guid("b128e310-17d3-4dbd-91a6-7117dada067a"), "F_E1_5A_IntActor_Bears_C1_Look"},
                        {new Guid("9846256b-4c1b-4e13-9932-c0df9c93cc68"), "F_E1_5A_IntActor_WildAnimalsPoster_C1_Look"},
                        {new Guid("bfe3b03e-4c7a-4ce3-88c3-df8d1a17b815"), "F_E1_5A_IntActor_TrappedBird_C1_Look"},
                        {new Guid("fc2f4655-f43c-4ce7-a8a8-ec73a4c9af91"), "F_E1_5A_IntActor_TrappedBird_C2_Move"},
                        {new Guid("9d888568-a90a-45f1-af4f-09670e655ecb"), "F_E1_5A_IntActor_FrontDoor_C1_Goin"},
                        {new Guid("26b8cdd4-69a1-41da-8458-fcbf7d5a6cca"), "F_E1_5A_IntActor_FrontDoor_C2_Goin"},
                        {new Guid("cd233aaa-fa9a-475e-995a-4c3678c802b9"), "F_E1_5A_IntActor_Brody_C3_Interrupt"},
                        {new Guid("2c643680-9a19-416b-8887-e0f52f76483f"), "F_E1_5A_IntActor_Feather_C1_Pickup"},
                        {new Guid("61115a43-2468-4d52-a0a0-2a3fa6e06c34"), "F_E1_5A_IntActor_Feather_C2_Look"},
                        {new Guid("4116af06-ff68-4ad9-8654-c5db3ff7cf71"), "F_E1_5A_IntActor_314_C1_Look"},
                        {new Guid("32d9179f-e719-4a0c-84d2-1cecf02df8a7"), "F_E1_5A_IntActor_Bench_C1_Sit"},
                        {new Guid("921685e5-45bd-4497-98b0-6dda29ddd245"), "F_E1_5A_IntActor_Family_C1_Look"},
                        {new Guid("2f731807-8ea6-46f1-a3ec-18fae37ffad4"), "F_E1_5A_IntActor_Family_C2_Speak"},
                        {new Guid("02351ac8-bb1c-4c87-9015-d1fb80b2b3a6"), "F_E1_5A_IntActor_Trash_C1_Look"},
                        {new Guid("dcfdb960-2a9f-4fc5-8fac-504773d73308"), "F_E1_5A_IntActor_Trash_C2_Lookforfood"},
                        {new Guid("d6f75727-6ba0-4039-a2c3-07d2f9fa1d31"), "F_E1_5A_IntActor_PicnicTable_C1_Look"},
                        {new Guid("c043fdbf-b2e2-49fc-8174-fdc13b82001a"), "F_E1_5A_IntActor_PicnicTable_C2_Eat"},
                        {new Guid("cccbc116-349c-40ce-a660-8f9da8ce2d8b"), "F_E1_5A_IntActor_PicnicTable_C3_LocalMap"},
                        {new Guid("3467ea99-186b-41b4-83e9-b02846feab56"), "F_E1_5A_IntActor_Fallen_C1_Take"},
                        {new Guid("91fdec3c-ec8a-4841-b50d-2510822055ec"), "F_E1_5A_IntActor_ExitDoor_C2_Asktoopen"},
                        {new Guid("c098ae26-2a7a-405f-a470-31376ed4475e"), "F_E1_5A_IntActor_SpanishLessons_C1_Look"},
                        {new Guid("45cb42dc-7751-46a8-9b8e-88d10ffd309e"), "F_E1_5A_IntActor_InflatablePumpkin_C1_Look"},
                        {new Guid("70811abb-92b5-4501-ba64-5298da3489a7"), "F_E1_5A_IntActor_IceContainer_C1_Look"},
                        {new Guid("ef254118-d5af-4a78-b8d5-22af5b133c14"), "F_E1_5A_IntActor_HalloweenPoster2_C1_Look"},
                        {new Guid("93143570-9f18-4e48-8aee-0bf5cd2cf4d9"), "F_E1_5A_IntActor_HalloweenDeco1_C1_Look"},
                        {new Guid("b3232f49-f5e4-4fda-9746-35dc150afb32"), "F_E1_5A_IntActor_HalfCarvedBear_C1_Look"},
                        {new Guid("ca966dd8-3e84-4a4a-918a-5bcd98c17620"), "F_E1_5A_IntActor_GivePuppyPoster_C1_Look"},
                        {new Guid("73cbcabe-6daa-4314-a3e7-b3bbeb1771b9"), "F_E1_5A_IntActor_296_C1_Look"},
                        {new Guid("434d2cd0-ed63-4059-a405-7358c878e4a0"), "F_E1_5A_IntActor_Witch_C1_Look"},
                        {new Guid("427f735f-78f4-4946-a34b-9f7c580b13c7"), "F_E1_5A_IntActor_PowerBear_C1_Look"},
                        {new Guid("c075d95a-5e62-4d4b-9f2a-9044a364aaf5"), "F_E1_5A_IntActor_Poster1_C1_Look"},
                        {new Guid("f67a0b5a-5eaa-426a-a6cd-936d58b595f5"), "F_E1_5A_IntActor_KnifeDisplay_C1_Look"},
                        {new Guid("1fd04838-c5ef-4f6b-bded-29d828834fd9"), "F_E1_5A_IntActor_ATM_C1_Look"},
                        {new Guid("693d87a7-ba0e-40ee-bfb7-a9db39286fbf"), "F_E1_5A_IntActor_AirVent_C1_Asktotearoff"},
                        {new Guid("1a88640c-0613-4584-8b01-cf5fe819c846"), "F_E1_5A_IntActor_AirVent_C2_AnswerDaniel"},
                        {new Guid("6c2f424e-de69-49be-947d-ba0a03a4270a"), "F_E1_5A_IntActor_AirVent_C3_Takethetool"},
                        {new Guid("83ac922e-f7d2-46dc-989f-94c97c56f625"), "F_E1_5A_IntActor_PosterToMove_C2_Push"},
                        {new Guid("ad6ab9fa-ced1-466b-a172-bf4dd6261054"), "F_E1_5A_IntActor_BackDoorKeys_C1_Look"},
                        {new Guid("38d98818-760b-4b75-b53c-48f2cc340f52"), "F_E1_5A_IntActor_BackDoorKeys_C2_Reach"},
                        {new Guid("055b3df4-9b9d-49d6-9f1b-4016b3a6dd67"), "F_E1_5A_IntActor_Tube_C1_Push"},
                        {new Guid("79bd1c08-22a0-4b8a-b8c3-248c6fe64607"), "F_E1_5A_IntActor_StorageDoor_C1_Open"},
                        {new Guid("25dd8f77-d91d-400d-ba83-17c5cd15f035"), "F_E1_5A_IntActor_Computer_C1_Look"},
                        {new Guid("ee1ba46f-1700-4603-86bd-74a0f4f0b490"), "F_E1_5A_IntActor_FamilyPicture_C1_Look"},
                        {new Guid("4aaeac1d-7b1f-4736-a66e-1ef012451ef6"), "F_E1_5A_IntActor_Ties_C1_Break"},
                        {new Guid("51b4e1bd-a881-435a-a2fa-2201d246e34c"), "F_E1_5A_IntActor_Ties_C2_Break"},
                        {new Guid("4db983a8-3001-4383-9750-b5b15b170124"), "F_E1_5A_IntActor_PipeAnchor_C1_Tear"},
                        {new Guid("b55fb716-6d68-4dfd-81df-38ada2ee4f97"), "F_E1_5A_IntActor_PipeAnchor_C2_Look"},
                        {new Guid("18bc9ce7-891a-4da8-8ce7-4f96158a07a3"), "F_E1_5A_IntActor_PipeAnchor_C3_Tear"},
                        {new Guid("12bf8dcd-29db-4ef1-993d-8646fff07bc2"), "F_E1_5A_IntActor_PipeAnchor_C5_Askfortool"},
                        {new Guid("e974645f-27f9-4aa8-88e1-a02d463ef6c6"), "F_E1_5A_IntActor_ChocoCrisp_C3_Steal"},
                        {new Guid("4d361ac2-9aed-4b3d-9dd9-2640ffd28919"), "F_E1_5A_IntActor_GrabMachine_C1_Look"},
                        {new Guid("622d1e44-c793-4e12-be75-7202a78962eb"), "F_E1_5A_IntActor_GrabMachine_C3_Play($1)"},
                        {new Guid("5b46c5c1-d60c-482f-9983-308a0ce0abcf"), "F_E1_5A_IntActor_FrontDoor_C1_Getout"},
                        {new Guid("c3924a3f-dcfb-4b60-ab4e-96e6b3a950d9"), "F_E1_5A_IntActor_Can_C2_Addtobasket($4.50)"},
                        {new Guid("7496edd2-8f6d-4009-bd54-5cce771411eb"), "F_E1_5A_IntActor_GSTL01_C1_Pay"},
                        {new Guid("5dc85b20-1188-40b9-8d7d-835113d31c54"), "F_E1_5A_IntActor_GSTL01_C5_Speak"},
                        {new Guid("fe6a5552-933f-43c6-8ef4-63c0f809fd35"), "F_E1_5A_IntActor_HotDogMachine_C1_Look"},
                        {new Guid("2c3613d0-70b0-4f1c-82ab-94aec440693a"), "F_E1_5A_IntActor_Puppy_C4_Discuss"},
                        {new Guid("bf2d7a93-481a-4f61-a37a-733928f138ec"), "F_E1_5A_IntActor_RegionMap_C1_Take"},
                        {new Guid("2757b077-36ce-46ba-be84-b681945588ff"), "F_E1_5A_IntActor_WaterBottle_C2_Addtobasket($4.50)"},
                        {new Guid("be731f5e-d9fd-47d2-a4f4-0f4c99589b8c"), "F_E1_5A_IntActor_window_C1_Look"},
                        {new Guid("d375a512-1988-4f25-9c4f-ca9f5be54c72"), "F_E1_5A_IntActor_window_C2_Asktoopen"},
                        {new Guid("05a6908f-ec9b-4f89-a320-87ca26d7919e"), "F_E1_5A_IntActor_LicensePlate_C1_Look"},
                        {new Guid("be565a0c-3e75-45bf-b2ee-98d6ebd07e6b"), "F_E1_5A_IntActor_Newspaper_C1_Read"},
                        {new Guid("c94576aa-adfb-4ed5-a67f-38a49e99f6a8"), "F_E1_5A_IntActor_Posters_C1_Look"},
                        {new Guid("83917d24-8eb4-4fae-a70a-d5bcfc5caaf9"), "F_E1_5A_IntActor_Shelve_C2_Discuss"},
                        {new Guid("ac059e09-c118-4aa6-bfa2-39aadaa824ec"), "F_E1_5A_IntActor_Brochures_C1_Look"},
                        {new Guid("6454bf12-11e4-45ac-b459-f2a825e91bab"), "F_E1_5A_IntActor_SportTeam_C1_Look"},
                        {new Guid("e5490026-1035-4291-8aba-7ed7a8d05981"), "F_E1_5A_IntActor_LetterBox_C1_Look"},
                        {new Guid("33463a13-908d-44d2-b709-b060f998975d"), "F_E1_5A_IntActor_Coffee_C1_Look"},
                        {new Guid("0e0efbe2-824c-4847-b61c-f6993dce92d8"), "F_E1_5A_IntActor_JunkPile_C1_Discuss"},
                        {new Guid("97fa15f2-800f-4d97-a1db-55eddf59dc3b"), "F_E1_5A_IntActor_ToiletSink_C1_Fillbottle"},
                        {new Guid("1ffdcd61-8955-4889-8f1b-e4cd74a32b79"), "F_E1_5A_IntActor_ToiletSink_C2_Cleanup"},
                        {new Guid("a1293795-cd2a-477c-b95b-3de35ccd4326"), "F_E1_5A_IntActor_ToiletDoorGetout_C1_Leave"},
                        {new Guid("539afad8-67b1-4259-8a2a-170d0c327303"), "F_E1_5A_IntActor_ToiletDoor_C1_Look"},
                        {new Guid("72a52426-d57e-4dbc-a8b2-090fd0805119"), "F_E1_5A_IntActor_ToiletDoor_C3_Entertogether"},
                        {new Guid("7a8ff2ab-ee21-4438-803a-c86f24e512dd"), "F_E1_5A_IntActor_Brody_C1_Look"},
                        {new Guid("53343ec7-bd33-47c5-a09a-2db3aa6bb10f"), "F_E1_5A_IntActor_Souvenir2_C1_Look"},
                        {new Guid("a5e5089e-4325-4944-a96e-6d3f0b1c7f79"), "F_E1_5A_IntActor_Door_C1_Look"},
                        {new Guid("3f0bd912-ed8c-4c3a-8af0-db417518584d"), "F_E1_5A_IntActor_ExitDoor_C1_Look"},
                        {new Guid("b4f768a9-196f-43d7-b234-9e113373aa66"), "F_E1_5A_IntActor_House_C1_Look"},
                        {new Guid("540bc265-fb4f-4e4c-9bed-2c59b6bca737"), "F_E1_5A_IntActor_CampingSign_C1_Look"},
                        {new Guid("cc43971c-c1ee-4fee-b9a6-42382300ef0f"), "F_E1_5A_IntActor_BigBear_C1_Look"},
                        {new Guid("2356e655-7d76-4746-bf6e-3fa483c2ecc4"), "F_E1_5A_IntActor_Tent_C1_Look"},
                        {new Guid("8bf9fbf2-835c-4595-9f84-9f5c52429b75"), "F_E1_5A_IntActor_Postcard_C1_Look"},
                        {new Guid("e004eb57-41c6-49dc-bf1a-7a47ec11c6a4"), "F_E1_5A_IntActor_CampingGear_C1_Look"},
                        {new Guid("72260f3e-b041-4708-a936-f4ed2ad09db3"), "F_E1_5A_IntActor_PilePaper_C1_Read"},
                        {new Guid("23d42d76-047e-4cae-be95-b48f4da9c6dd"), "F_E1_5A_IntActor_Souvenir_C1_Kick"},
                        {new Guid("06cd8006-3b29-47e3-90d8-58ed3e5a51d3"), "F_E1_5A_IntActor_ChocoCrisp_C1_Look"},
                        {new Guid("a0febc72-a178-4eb8-9675-0d872ed334f7"), "F_E1_5A_IntActor_ChocoCrisp_C2_Addtobasket($1.99)"},
                        {new Guid("b8fb48ea-1da5-4705-aa72-72f429add4cc"), "F_E1_5A_IntActor_SodaBottle_C1_Look"},
                        {new Guid("5ce887e3-3d59-416c-b700-08c2dac37744"), "F_E1_5A_IntActor_InspectorToolDesk_C1_Inspect"},
                        {new Guid("898d7b6d-f814-4d30-9042-3f7f8563f940"), "F_E1_5A_IntActor_KeyChain_C1_Look"},
                        {new Guid("628e6242-ccd8-434c-a5a2-7f7d96d2bd63"), "F_E1_5A_IntActor_KeyChain_C2_Show"},
                        {new Guid("8246f891-3d1c-432e-a96a-63ea960264b4"), "F_E1_5A_IntActor_TShirt_C3_Look"},
                        {new Guid("ba78accd-344b-4dc3-99e0-af94c9b953e1"), "F_E1_5A_IntActor_CelebrityPhoto_C1_Look"},
                        {new Guid("a64f6ad4-c4e7-46f8-9e2c-07249efe1430"), "F_E1_5A_IntActor_GSTL01_C2_Look"},
                        {new Guid("c8eff45f-320a-4a22-8293-ed90ad644838"), "F_E1_5A_IntActor_GSTL01_C4_Interrupt"},
                        {new Guid("f83415c7-8b24-4ccf-87d0-5920ef052001"), "F_E1_5A_IntActor_HotDogMachine_C2_Make2hotdogs($6)"},
                        {new Guid("e9028068-be50-4753-acfc-e4980838c045"), "F_E1_5A_IntActor_Puppy_C1_Look"},
                        {new Guid("f8e175ca-7c03-46d2-9192-78d3250e7da1"), "F_E1_5A_IntActor_RegionMap_C2_Look"},
                        {new Guid("3171b178-e644-4deb-9531-92c3b97febef"), "F_E1_5A_IntActor_SleepingBag_C1_Addtobasket($16)"},
                        {new Guid("64a81bd2-f75d-409e-b6b2-833cd98a7638"), "F_E1_5A_IntActor_SleepingBag_C3_Look"},
                        {new Guid("d7bb5851-fc4c-4e3b-82ca-a92258f8d69d"), "F_E1_5A_IntActor_SlicedBread_C1_Look"},
                        {new Guid("b638d1f5-4325-4409-8bc0-4c0f1cbf57a3"), "F_E1_5A_IntActor_SlicedBread_C2_Addtobasket($5.90)"},
                        {new Guid("49a6af56-ec4d-4c6a-a76a-04747b631e64"), "F_E1_5A_IntActor_WaterBottle_C1_Look"},
                        {new Guid("1b7c06f4-c304-4c30-ab28-06a3bce86694"), "F_E1_5A_IntActor_Sweat_C1_Look"},
                        {new Guid("6962db43-3a3d-4b17-a375-022821c0ce70"), "F_E1_5A_IntActor_Mirror_C1_Look"},
                        {new Guid("7ebf1af9-6cf6-4ea8-bf69-72b4d9a80191"), "F_E1_5A_IntActor_Shelve_C1_Look"},
                        {new Guid("e30d5199-aa7b-4873-9acd-e7239b023b0e"), "F_E1_5A_IntActor_Sign_C1_Look"},
                        {new Guid("3eea9066-774d-47f5-8427-710c13757dfd"), "F_E1_5A_IntActor_ToiletInstruction1_C1_Look"},
                        {new Guid("ba895b79-bdfc-47e8-89da-4b90fb123f6b"), "F_E1_5A_IntActor_ToiletPaperDispenser_C1_Look"},
                        {new Guid("67370e5f-e5e4-4af6-91c3-621ac8d12a7e"), "F_E1_5A_IntActor_Birds_C1_Look"},
                        {new Guid("ead04278-e7ff-45fc-8859-bf76b7816840"), "F_E1_5A_IntActor_Family_C3_SendDanieltobeg"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "44645c7e-038c-4fac-bff6-4ce3a6229f80", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("857d3e14-28ae-4e35-89b8-c27cc80f4b47"), "F_E1_5A_POI_BP_PoI_Int_Airvent_PoI_Infini"},
                        {new Guid("7da6b5da-b7af-4bc7-8995-58488aad62f1"), "F_E1_5A_POI_BP_PoI_Int_GrabMachine"},
                        {new Guid("1173357b-0e2d-4e30-91ff-c9ca8c5fe7f3"), "F_E1_5A_POI_BP_PoI_Out_Shelve"},
                        {new Guid("a960ad8c-a367-48ba-ae12-6401dc2d7ef0"), "F_E1_5A_POI_BP_PoI_int_Brody"},
                        {new Guid("4eec7da7-a8db-4e69-b5d7-b59897c8c8aa"), "F_E1_5A_POI_BP_PoI_Int_Witch"},
                        {new Guid("e7252a54-ddf8-42be-8995-c7e26f941cb8"), "F_E1_5A_POI_BP_PoI_Out_BearPoster"},
                        {new Guid("f2fdfc28-c335-4389-a463-dde98bfa0488"), "F_E1_5A_POI_BP_PoI_Int_Puppy"},
                        {new Guid("4c51523c-a190-4b90-9269-781e285084fc"), "F_E1_5A_POI_BP_PoI_Int_Ketchup_PoI_Infini"},
                        {new Guid("23461862-8970-49fb-8b78-09814527d554"), "F_E1_5A_POI_BP_PoI_Int_Drink_Infini"},
                        {new Guid("5f3d175a-691a-483f-8adc-a4d8e1eef547"), "F_E1_5A_POI_BP_PoI_Out_InfiniZenSqc"},
                        {new Guid("2c7a1423-a4ac-4537-91aa-59cd7a2e0f41"), "F_E1_5A_POI_BP_PoI_Int_Chocobar"},
                        {new Guid("d54e3a03-b991-4c2d-b602-fba747a01f6d"), "F_E1_5A_POI_BP_PoI_Int_Doris"},
                        {new Guid("f283f000-9758-498c-8183-0145000154d1"), "F_E1_5A_POI_BP_PoI_Int_Bear"},
                        {new Guid("c7dfa3ad-3caa-45c6-80e4-56fd48d0ba97"), "F_E1_5A_POI_BP_PoI_Int_Beer"},
                        {new Guid("c627e238-7f7b-4cd4-b8cf-c0dc9b88d315"), "F_E1_5A_POI_BP_PoI_Int_CandyMachine"},
                        {new Guid("d1cadd2d-b3d0-40a4-a18b-e4083314d26f"), "F_E1_5A_POI_BP_PoI_Int_Drinks"},
                        {new Guid("dbd1335e-66b5-48db-b01a-a6b523e574e5"), "F_E1_5A_POI_BP_PoI_Int_Juice"},
                        {new Guid("1263e5eb-61b3-4b79-ac70-446190fc3596"), "F_E1_5A_POI_BP_PoI_Int_Ketchup"},
                        {new Guid("9cebe397-4ed8-4cf6-bdbc-55c322c81a48"), "F_E1_5A_POI_BP_PoI_Int_Kitchen"},
                        {new Guid("397b4b12-a91b-4741-a126-6cf12bf3f065"), "F_E1_5A_POI_BP_PoI_Int_PeanutButter"},
                        {new Guid("d9ff91ed-e4de-4a53-82ea-4f7f35377885"), "F_E1_5A_POI_BP_PoI_Int_PowerBear"},
                        {new Guid("9e380258-c28b-42d2-9a9c-d88da9813ce6"), "F_E1_5A_POI_BP_PoI_Int_SouvenirRack"},
                        {new Guid("60114b12-6b9a-4071-82a9-a25856823334"), "F_E1_5A_POI_BP_PoI_Int_Sweater"},
                        {new Guid("8925b5c3-5e0e-4c6d-93e7-70b8d3af71b5"), "F_E1_5A_POI_BP_PoI_Int_Tea"},
                        {new Guid("ba4f3c87-7d98-4fcf-8d14-6a6bd7928a13"), "F_E1_5A_POI_BP_PoI_Int_Tents"},
                        {new Guid("23ea4c83-8383-4c4f-a29b-e2f2976e5e01"), "F_E1_5A_POI_BP_PoI_Int_Window"},
                        {new Guid("9d651314-85c1-478d-bae2-aa50efa1e82b"), "F_E1_5A_POI_BP_PoI_Out_Curb2"},
                        {new Guid("0aee468f-8866-44fb-a10a-f36b96bbcd67"), "F_E1_5A_POI_BP_PoI_Out_DragFeet2"},
                        {new Guid("2649c76f-9724-4281-b43f-fa4744f29200"), "F_E1_5A_POI_BP_PoI_Out_Pump1"},
                        {new Guid("047c9e4e-09c5-4957-a136-78194a63e36d"), "F_E1_5A_POI_BP_PoI_Out_Pump3"},
                        {new Guid("6250d361-aea2-43f6-851c-50f9fb5070c4"), "F_E1_5A_POI_BP_PoI_Out_Pump4"},
                        {new Guid("ca13ec28-6614-49b0-9850-6483a490ff8d"), "F_E1_5A_POI_BP_PoI_Out_Pumpkin"},
                        {new Guid("09043f8a-2346-492d-b80a-35eb17e2f659"), "F_E1_5A_POI_BP_PoI_Out_SquirrelNut"},
                        {new Guid("f9a91273-d5e7-4f76-be4a-70af8e145d30"), "F_E1_5A_POI_BP_PoI_Out_Table"},
                        {new Guid("297db690-fb8b-447c-8b18-f881fda56ece"), "F_E1_5A_POI_BP_PoI_Out_TouchNeck2"},
                        {new Guid("2039b69a-06a3-47fa-9f0e-4ac926370994"), "F_E1_5A_POI_BP_PoI_Out_Ins_GSDiscovery"},
                        {new Guid("382c1126-cf78-4b17-8918-525991e58bed"), "F_E1_5A_POI_BP_PoI_OutOfbreathe"},
                        {new Guid("4a79866d-4146-4729-ae97-3eae16ae54e2"), "F_E1_5A_POI_BP_PoI_Out_Ins_LeanElectricPole"},
                        {new Guid("0cd70309-08fb-46d3-a7e3-7b5ab683f3d6"), "F_E1_5A_POI_BP_PoI_Out_SitTree2"},
                        {new Guid("f1214068-f6fa-40e9-bfa7-ac6e3a6009a0"), "F_E1_5A_POI_BP_PoI_Out_LeanWoodPile"},
                        {new Guid("8ebfd76e-5e9c-4c05-a370-3045d87336d7"), "F_E1_5A_POI_BP_PoI_Out_ToiletPoster"},
                        {new Guid("9f2a5589-97e9-4b87-bee5-97ac3d3d6697"), "F_E1_5A_POI_BP_PoI_Out_Toilet_Sitting"},
                        {new Guid("d4bb698c-8488-4b61-8532-453786e9c160"), "F_E1_5A_POI_BP_PoI_Int_Cream_PoI_Infini"},
                        {new Guid("4a3cd210-601e-4246-99d4-e334132d3101"), "F_E1_5A_POI_BP_PoI_Int_Knifes"},
                        {new Guid("718bd3df-7cc8-4b76-9113-4f03825ee358"), "F_E1_5A_POI_BP_PoI_Out_CampingSign"},
                        {new Guid("0d56b967-21d9-4746-b8c0-d753fd56540e"), "F_E1_5A_POI_BP_PoI_Out_LeanWallBack"},
                        {new Guid("7248e008-be5e-4927-ac59-1b9cdaea2500"), "F_E1_5A_POI_BP_PoI_Out_SEarch"},
                        {new Guid("f2d5cec5-d37c-4d21-8a40-2ddb23794f97"), "F_E1_5A_POI_BP_PoI_Out_SitJunk"},
                        {new Guid("2fa6d822-8574-4ca3-bbd1-5edcc0ee632a"), "F_E1_5A_POI_BP_PoI_Out_TouchNeck"},
                        {new Guid("55ef92ba-bd04-49c7-8556-a4453d2447d3"), "F_E1_5A_POI_BP_PoI_Out_Workbench"},
                        {new Guid("0372940f-1f07-4ee2-b08d-6950d6105b4e"), "F_E1_5A_POI_BP_PoI_Out_Inst_OldPath"},
                        {new Guid("4ddd63fa-28da-41ea-9514-12bccb76f56f"), "F_E1_5A_POI_BP_PoI_Out_DragFeet4"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "e7651ccc-44a6-445a-bf5d-0cb72d7ec961", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("63631a7e-3a1a-4781-9706-d0a86e2e312a"), "F_E1_6B_Outside_AB_C"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("a59c8980-aafe-4d97-b421-86df077af08a"), "F_E1_6B_Outside_AB_SeanFault"},
                        {new Guid("bfda90fc-9e0b-41f9-873d-2384ba9d1315"), "F_E1_6B_Outside_AB_TravelPlan"},
                        {new Guid("8b82c4be-7b0f-49a6-b5d2-f6efa43157a3"), "F_E1_6B_Outside_AB_TellDanielTruth"},
                        {new Guid("0fdfc038-d696-47b3-bcea-b3fcd1481cb6"), "F_E1_6B_Outside_AB_Recover"},
                    },
                }
            },
            {
                "584d97de-04cb-4a71-99c0-c54b3f967d63", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("9ff56633-c07a-45bf-94a6-7eca959a1936"), "F_E1_7A_BathReady"},
                        {new Guid("8717dfd7-c309-42ae-ad5d-12e7f2402c08"), "F_E1_7A_UsedLiquidSoapInTime"},
                        {new Guid("52458e76-b0fb-49eb-bb19-68b3f0bf710e"), "F_E1_7A_BathWaterTapOpened"},
                        {new Guid("f7df30f0-fa9d-41d4-b4c6-9481b5df0718"), "F_E1_7A_LightBathRoom"},
                        {new Guid("61cd79d3-033b-41ec-9e64-6649452f1b19"), "F_E1_7A_OnBalcony"},
                        {new Guid("34c8b41d-36b3-4320-82ca-4ad2266a377e"), "F_E1_7A_ReceivedLylaMessage"},
                        {new Guid("3a9e028e-819d-4dbc-befa-174f0d0ffa12"), "F_E1_7A_SeanProximity"},
                        {new Guid("3611c705-99d0-4b5a-bd06-1719994a0911"), "F_E1_7A_StealingIsBad"},
                        {new Guid("07581ad2-695d-4c7b-b1dc-47f096f3da17"), "F_E1_7A_ShowBag"},
                        {new Guid("7c293c08-bfbf-4a0f-83e0-dd75bb895a79"), "F_E1_7A_ShowTowels"},
                        {new Guid("642fb0c9-238c-497b-af3a-97fd15ed9dad"), "F_E1_7A_ShowShoes"},
                        {new Guid("c212480d-1d67-4479-af98-000ea0fc0376"), "F_E1_7A_CuddleSoft"},
                        {new Guid("6c8229e1-9b16-4daf-bf5b-9c95ab4a6ce7"), "F_E1_7A_VaniheDiscussionOn"},
                        {new Guid("57339838-c805-47a5-83e7-d552b4f7f541"), "F_E1_7A_CanPlayPowerBear"},
                        {new Guid("3f7b5b9a-fdea-4667-9780-6fb9476e0339"), "F_E1_7A_IsCollectibleMode"},
                        {new Guid("44e1acd8-b75a-49b6-9cdf-5f57c4d76e04"), "F_E1_7A_ShowPowerBear"},
                        {new Guid("b29f42c3-e6d7-4e82-a018-cc96aa502777"), "F_E1_7A_ArguedAboutToy"},
                        {new Guid("82213249-13a3-4b88-b4fa-f70c39bdf297"), "F_E1_7A_WalletLastStatus"},
                        {new Guid("c8836b85-8122-46d9-8849-07cdd4ccaaf5"), "F_E1_7A_ActivateSeagull"},
                        {new Guid("fd29a6b8-487d-4538-a0c7-50fae85bf732"), "F_E1_7A_CanTickle"},
                        {new Guid("1e229bbd-30e5-4553-83da-81705984bf8e"), "F_E1_7A_SpecialDanceShot"},
                        {new Guid("88798867-83a3-4baf-a39a-01e4877c50bf"), "F_E1_7A_SeanLostSHIFUMI"},
                        {new Guid("8cb0b8e8-b38b-4a50-b2a9-a56994d16fd3"), "F_E1_7A_EnoughPowerBear"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("0a925493-1dcb-4bac-9da2-31218466f9be"), "F_E1_7A_NumberOfStickThrow"},
                        {new Guid("87a69e93-637e-4d90-acbb-e1e055b05034"), "F_E1_7A_ToggleLight"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("520f6717-d4dd-4d6c-b729-05578cbc190c"), "F_E1_7A_BedChoosing"},
                        {new Guid("ab399ad9-6066-4535-acf2-774139caed4e"), "F_E1_7A_MotelStatus"},
                    },
                }
            },
            {
                "afca1e71-03e3-46b3-85b0-f55c014e5ac8", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("cea8eca8-d9b4-44bd-8c94-917169851c15"), "F_E1_7A_MotelRoom_JRNLObject_C"},
                        {new Guid("b74c51a2-8acb-4d42-8446-d4e46fda7862"), "F_E1_7A_MotelRoom_AnswerFRND_C"},
                        {new Guid("c7bb90ef-e948-47cd-8773-943687e3cebe"), "F_E1_7A_Beach_Insertion_C"},
                        {new Guid("e2506b49-db24-4829-a03c-e5a61e60a758"), "F_E1_7A_MotelRoom_PowerReveal_C"},
                        {new Guid("a2dde0ad-fcad-451f-b639-d8b740d21108"), "F_E1_7A_Walkway_Room8_C"},
                        {new Guid("ac2d9f6b-c385-49f7-9c93-47445e156176"), "F_E1_7A_Walkway_Room10_C"},
                        {new Guid("26e77363-0da1-40b4-9c14-4fce145ef7ea"), "F_E1_7A_Beach_PlayingMushroomTwo_C"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("9b9a47e1-8a80-46a4-b721-635f72ac868c"), "F_E1_7A_MotelRoom_JRNLObject_JRNLToy"},
                        {new Guid("6ed46ef3-fcff-464f-a017-25cf8d017d91"), "F_E1_7A_MotelRoom_AnswerFRND_CheckLylaNews"},
                        {new Guid("0692d1d4-44d8-4e22-a5ea-cb9e34052c2b"), "F_E1_7A_MotelRoom_AnswerFRND_ComeBack"},
                        {new Guid("65700e37-d19c-4250-bfda-17c367b252cd"), "F_E1_7A_MotelRoom_AnswerFRND_FinalChoice"},
                        {new Guid("45075eca-b039-483b-b864-c796478c86a1"), "F_E1_7A_Beach_Insertion_PhoneTrash"},
                        {new Guid("e4c32d97-6138-4e9b-b5f0-c1e31104730b"), "F_E1_7A_MotelRoom_PowerReveal_SecondChoice"},
                        {new Guid("3efe08cd-e206-40dc-8e23-86fd4539ed5c"), "F_E1_7A_MotelRoom_PowerReveal_FirstChoice "},
                        {new Guid("08dda61a-bc65-49ff-8a5a-a31d03ac5b76"), "F_E1_7A_MotelRoom_PowerReveal_BadOptionalChoice"},
                        {new Guid("78c1f749-18a2-41bd-85d5-833401a6feed"), "F_E1_7A_MotelRoom_PowerReveal_PromiseChoice"},
                        {new Guid("40be204c-c0a8-47cd-9a26-4ecd6208b0e2"), "F_E1_7A_LevelChoice_RPSChoice"},
                        {new Guid("3218275e-c026-4882-98f4-6df47498e231"), "F_E1_7A_LevelChoice_DanceBed"},
                        {new Guid("a912b0d6-38bc-4bdb-ae7a-e8b88cb1afb6"), "F_E1_7A_LevelChoice_AcceptRevenge"},
                        {new Guid("942cc0d1-aa82-4785-b807-8442fba7dba1"), "F_E1_7A_LevelChoice_StaggingChoiceLyla"},
                        {new Guid("edbe169b-3a00-4adf-bd5c-e5f58764bd44"), "F_E1_7A_LevelChoice_AskStickLoop"},
                    },
                }
            },
            {
                "61d63f40-103f-49a4-957e-9e4d64859819", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("6782716e-0f53-4055-a2fb-b8216c3986b3"), "F_E1_7A_IntActor_MotelCardCollectible_C1_Look"},
                        {new Guid("6a4b50b2-3dae-4a2d-a5dd-44a4ab291647"), "F_E1_7A_IntActor_Phone_C1_Pickupthephone"},
                        {new Guid("ff20b1c0-1a22-4d53-83fa-e05687703fe8"), "F_E1_7A_IntActor_BeachDaniel_C1_Look"},
                        {new Guid("5b5b4958-8acf-49e0-8516-7fab0d4677ea"), "F_E1_7A_IntActor_MainDoor_C1_Goinside"},
                        {new Guid("9f405205-6fe3-4c3b-a3ff-037ca5f3eb05"), "F_E1_7A_IntActor_BathTap_C1_Look"},
                        {new Guid("d72bf256-1eec-4689-8487-da4c77211815"), "F_E1_7A_IntActor_BathTap_C2_Open"},
                        {new Guid("d64a3e87-3cf1-40b3-8b63-a2835d7eba06"), "F_E1_7A_IntActor_BathTap_C3_Close"},
                        {new Guid("6b52d733-99d3-46df-bd7c-b15c4e95d5db"), "F_E1_7A_IntActor_Bathtub_C1_Look"},
                        {new Guid("048f8de4-4713-4755-89da-fe29542405c7"), "F_E1_7A_IntActor_Bathtub_C3_Calltobath"},
                        {new Guid("cf595e37-9a9e-448f-bdc9-dab541b2f1c4"), "F_E1_7A_IntActor_SinkTap_C1_Wash"},
                        {new Guid("ce78ccf7-b248-4e06-99b8-b9ce344f0b2f"), "F_E1_7A_IntActor_VendingMachine_C1_Buyasoda($1)"},
                        {new Guid("260175ba-14c3-4828-b59b-165bff79b689"), "F_E1_7A_IntActor_Instructions_C1_Look"},
                        {new Guid("27eaec6c-a977-4e6f-8b1b-a500a8a19ed7"), "F_E1_7A_IntActor_Map_C1_Look"},
                        {new Guid("522d08f9-b3b6-423e-94b8-9ff4607a94e7"), "F_E1_7A_IntActor_Toy_C2_Question"},
                        {new Guid("3cf8ac78-fa98-4196-a2fa-7b7f865adb90"), "F_E1_7A_IntActor_LiquidSoap_C1_Look"},
                        {new Guid("6003db8b-da37-43b2-b02d-8efd7910006a"), "F_E1_7A_IntActor_LiquidSoap_C2_Add"},
                        {new Guid("d871dc58-61ca-4e24-b180-a1bd6f99cced"), "F_E1_7A_IntActor_Wardrobe_C1_Open"},
                        {new Guid("70376d81-7c18-4190-8281-9cc643ed5f1b"), "F_E1_7A_IntActor_WoodStick_C1_Playfetch"},
                        {new Guid("5d487ce9-841c-4621-8095-71d8876746f8"), "F_E1_7A_IntActor_WoodStick_C2_Look"},
                        {new Guid("5f17384e-957b-4a89-93d1-3b5fef615ae9"), "F_E1_7A_IntActor_BrodyCarBeach_C1_Look"},
                        {new Guid("9f583eb9-1301-49b9-8ee1-64bdb1d5ce4f"), "F_E1_7A_IntActor_BagBeach_C1_Look"},
                        {new Guid("f157e3d9-e59b-4db1-9722-093f9a59299b"), "F_E1_7A_IntActor_BrodyBag_C1_Look"},
                        {new Guid("dd364e89-67a1-4a16-9b9b-fdfc03120c4a"), "F_E1_7A_IntActor_SandCastle_C1_Look"},
                        {new Guid("d33180fa-3d4d-489f-90cd-aa2310df50b8"), "F_E1_7A_IntActor_FrenchWindowInside_C1_Gooutside"},
                        {new Guid("160e132b-bd9b-46f2-91b3-71d9801a9b8f"), "F_E1_7A_IntActor_FrenchWindowInside_C2_Goinside"},
                        {new Guid("5daa67fc-2897-42a7-97e5-2a00aa36a83a"), "F_E1_7A_IntActor_Shampoo_C1_Look"},
                        {new Guid("10fe4ef9-082b-45fb-8330-7f6d6a755b72"), "F_E1_7A_IntActor_Painting_C1_Look"},
                        {new Guid("e123d0d8-ce8e-4a9f-8cc7-cd7b9019fb2a"), "F_E1_7A_IntActor_JRNLNote_C1_Look"},
                        {new Guid("239b853c-93f5-4f33-bf2a-0d5c3cb76fac"), "F_E1_7A_IntActor_Card_C1_Look"},
                        {new Guid("835d6953-7e46-42f5-92f4-3efe7b57695b"), "F_E1_7A_IntActor_FreshTowels_C2_Look"},
                        {new Guid("e42f0b7a-ea05-476a-8603-8ff53ec60be8"), "F_E1_7A_IntActor_BagDaniel_C1_Look"},
                        {new Guid("c0ab0b52-1802-4463-a610-0f6f3ca65222"), "F_E1_7A_IntActor_Flyers_C1_Look"},
                        {new Guid("157e0d10-b4fe-4dd7-8698-f1ae7f2e5e1d"), "F_E1_7A_IntActor_Tent_C1_Look"},
                        {new Guid("1d977460-a725-4fca-8f4b-a338338d009c"), "F_E1_7A_IntActor_DanielShoes_C1_Look"},
                        {new Guid("ff30740e-3e13-4833-8ddb-4be1c69bf412"), "F_E1_7A_IntActor_Tie_C1_Look"},
                        {new Guid("1cd18fcb-2e88-4df7-b0d8-337a53cf5c63"), "F_E1_7A_IntActor_246_C1_Look"},
                        {new Guid("15b085eb-b389-4125-b7d0-eaa674a4e52b"), "F_E1_7A_IntActor_338_C1_Look"},
                        {new Guid("94371a0e-5119-451b-ab64-7b6c5dc8b27b"), "F_E1_7A_IntActor_AshTray_C1_Look"},
                        {new Guid("da80b876-e1d6-4846-be27-729995ed2e2f"), "F_E1_7A_IntActor_Balcony_C1_Lean"},
                        {new Guid("abdee6da-e573-44fa-9182-41e438b6f9b8"), "F_E1_7A_IntActor_ForgottenPaper_C1_Look"},
                        {new Guid("87ae6229-9964-4601-870a-5ff241b24108"), "F_E1_7A_IntActor_LightSwitch_C1_TurnOn"},
                        {new Guid("a019195f-0e0f-4ae5-b63d-e1bbf984bb4e"), "F_E1_7A_IntActor_MotelDrawing_C1_Sitanddraw"},
                        {new Guid("5196ed5c-b212-4a73-a892-79096a3f646f"), "F_E1_7A_IntActor_MotelCardCollectible_C2_Take"},
                        {new Guid("4761b8a3-4610-40d5-9823-4691655692ed"), "F_E1_7A_IntActor_Bathtub_C2_Look"},
                        {new Guid("7afdbfa0-43cc-474b-9948-c82cfcaa5615"), "F_E1_7A_IntActor_Daniel_C2_WatchTVtogether"},
                        {new Guid("561de799-672a-4638-8b00-f50ac071a172"), "F_E1_7A_IntActor_TowelHolder_C1_Puttowel"},
                        {new Guid("d39a022e-3562-4cab-966b-80a232a307eb"), "F_E1_7A_IntActor_TV_C1_Look"},
                        {new Guid("5b0058f1-5ea4-424c-8071-637d09e09e7e"), "F_E1_7A_IntActor_Tickle_C1_Tickle"},
                        {new Guid("8ba1206b-01e3-43e0-a4f2-edaaf9f08649"), "F_E1_7A_IntActor_FreshTowels_C1_Take"},
                        {new Guid("3019f7c9-fd80-4476-9eeb-7e61520749c3"), "F_E1_7A_IntActor_Bed2_C1_Look"},
                        {new Guid("b3b71217-a5a0-4731-ba3a-6e7b1c7814f1"), "F_E1_7A_IntActor_Daniel_C1_Sendtobath"},
                        {new Guid("3e54d8af-2a47-4a42-bc0c-a37e6ba65d21"), "F_E1_7A_IntActor_Right_C1_Look"},
                        {new Guid("6a86d696-1249-47ce-a6da-8b8b5d257507"), "F_E1_7A_IntActor_LightSwitch_C2_TurnOff"},
                        {new Guid("3cf0bc25-8576-4813-a2e0-1eae750f6cdf"), "F_E1_7A_IntActor_MotelDrawing_C2_Sitanddraw"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "31542d9d-b83b-4796-835d-3f3917d201f2", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("30239d26-60e8-429b-a175-767def834ace"), "F_E1_7A_POI_Room8"},
                        {new Guid("89bc390d-1b01-429c-95c8-2086f1edfe92"), "F_E1_7A_POI_Chair1"},
                        {new Guid("d90addd3-1aa5-453a-a92a-b089973b5fb6"), "F_E1_7A_POI_Room10"},
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
            {
                "2306ef8a-6020-40cf-be17-13915de8fd94", new FactAsset
                {
                    BoolFacts = new Dictionary<Guid, string>
                    {
                        {new Guid("d0d7ba64-972a-4521-a75f-1bcd2783ee60"), "F_E1_6B_FinishedBrody"},
                    },
                    IntFacts = new Dictionary<Guid, string>
                    {
                    },
                    FloatFacts = new Dictionary<Guid, string>
                    {
                    },
                    EnumFacts = new Dictionary<Guid, string>
                    {
                    },
                }
            },
        };


    }
}
