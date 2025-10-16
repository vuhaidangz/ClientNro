using AssemblyCSharp.Mod.PickMob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000C8 RID: 200
    public struct GroupMap
    {
        // Token: 0x060009DD RID: 2525 RVA: 0x0000815A File Offset: 0x0000635A
        public GroupMap(string nameGroup, List<int> idMaps)
        {
            this.NameGroup = nameGroup;
            this.IdMaps = idMaps;
        }

        // Token: 0x0400123F RID: 4671
        public string NameGroup;

        // Token: 0x04001240 RID: 4672
        public List<int> IdMaps;
    }
}
namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000C9 RID: 201
    public struct MapNext
    {
        // Token: 0x060009DE RID: 2526 RVA: 0x0000816A File Offset: 0x0000636A
        public MapNext(int mapID, TypeMapNext type, int[] info)
        {
            this.MapID = mapID;
            this.Type = type;
            this.Info = info;
        }

        // Token: 0x04001241 RID: 4673
        public int MapID;

        // Token: 0x04001242 RID: 4674
        public TypeMapNext Type;

        // Token: 0x04001243 RID: 4675
        public int[] Info;
    }
}
namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000CA RID: 202
    public class Pk9rXmap
    {
        // Token: 0x060009DF RID: 2527 RVA: 0x00086FA8 File Offset: 0x000851A8
        public static bool Chat(string text)
        {
            if (text == "xmp")
            {
                if (Pk9rXmap.IsXmapRunning)
                {
                    XmapController.FinishXmap();
                    GameScr.info1.addInfo("Đã hủy Xmap", 0);
                }
                else
                {
                    XmapController.ShowXmapMenu();
                }
            }
            else if (Pk9rXmap.IsGetInfoChat<int>(text, "xmp"))
            {
                if (Pk9rXmap.IsXmapRunning)
                {
                    XmapController.FinishXmap();
                    GameScr.info1.addInfo("Đã hủy Xmap", 0);
                }
                else
                {
                    XmapController.StartRunToMapId(Pk9rXmap.GetInfoChat<int>(text, "xmp"));
                }
            }
            else if (text == "csb")
            {
                Pk9rXmap.IsUseCapsuleNormal = !Pk9rXmap.IsUseCapsuleNormal;
                GameScr.info1.addInfo("Sử dụng capsule thường Xmap: " + (Pk9rXmap.IsUseCapsuleNormal ? "Bật" : "Tắt"), 0);
            }
            else
            {
                if (!(text == "csdb"))
                {
                    return false;
                }
                Pk9rXmap.IsUseCapsuleVip = !Pk9rXmap.IsUseCapsuleVip;
                GameScr.info1.addInfo("Sử dụng capsule đặc biệt Xmap: " + (Pk9rXmap.IsUseCapsuleVip ? "Bật" : "Tắt"), 0);
            }
            return true;
        }

        // Token: 0x060009E0 RID: 2528 RVA: 0x000870BC File Offset: 0x000852BC
        public static bool HotKeys()
        {
            int keyAsciiPress = GameCanvas.keyAsciiPress;
            if (keyAsciiPress != 99)
            {
                if (keyAsciiPress != 120)
                {
                    return false;
                }
                Pk9rXmap.Chat("xmp");
            }
            else
            {
                Pk9rXmap.Chat("csb");
            }
            return true;
        }

        // Token: 0x060009E1 RID: 2529 RVA: 0x00008181 File Offset: 0x00006381
        public static void Update()
        {
            if (XmapData.Instance().IsLoading)
            {
                XmapData.Instance().Update();
            }
            if (Pk9rXmap.IsXmapRunning)
            {
                XmapController.Update();
            }
        }

        // Token: 0x060009E2 RID: 2530 RVA: 0x000081A5 File Offset: 0x000063A5
        public static void Info(string text)
        {
            if (text.Equals("Bạn chưa thể đến khu vực này"))
            {
                XmapController.FinishXmap();
            }
            if ((text.ToLower().Contains("chức năng bảo vệ") || text.ToLower().Contains("đã hủy xmap")) && IsXmapRunning)
            {
                XmapController.FinishXmap();
            }
        }

        // Token: 0x060009E3 RID: 2531 RVA: 0x000870F4 File Offset: 0x000852F4
        public static bool XoaTauBay(object obj)
        {
            Teleport teleport = (Teleport)obj;
            if (teleport.isMe)
            {
                global::Char.myCharz().isTeleport = false;
                if (teleport.type == 0)
                {
                    Controller.isStopReadMessage = false;
                    global::Char.ischangingMap = true;
                }
                Teleport.vTeleport.removeElement(teleport);
                return true;
            }
            return false;
        }

        // Token: 0x060009E4 RID: 2532 RVA: 0x000081B9 File Offset: 0x000063B9
        public static void SelectMapTrans(int selected)
        {
            if (Pk9rXmap.IsMapTransAsXmap)
            {
                XmapController.HideInfoDlg();
                XmapController.StartRunToMapId(XmapData.GetIdMapFromPanelXmap(GameCanvas.panel.mapNames[selected]));
                return;
            }
            XmapController.SaveIdMapCapsuleReturn();
            Service.gI().requestMapSelect(selected);
        }

        // Token: 0x060009E5 RID: 2533 RVA: 0x000081EE File Offset: 0x000063EE
        public static void ShowPanelMapTrans()
        {
            Pk9rXmap.IsMapTransAsXmap = false;
            if (Pk9rXmap.IsShowPanelMapTrans)
            {
                GameCanvas.panel.setTypeMapTrans();
                GameCanvas.panel.show();
                return;
            }
            Pk9rXmap.IsShowPanelMapTrans = true;
        }

        // Token: 0x060009E6 RID: 2534 RVA: 0x00008218 File Offset: 0x00006418
        public static void FixBlackScreen()
        {
            Controller.gI().loadCurrMap(0);
            Service.gI().finishLoadMap();
            global::Char.isLoadingMap = false;
        }

        // Token: 0x060009E7 RID: 2535 RVA: 0x00087140 File Offset: 0x00085340
        private static bool IsGetInfoChat<T>(string text, string s)
        {
            if (text.StartsWith(s))
            {
                try
                {
                    Convert.ChangeType(text.Substring(s.Length), typeof(T));
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        // Token: 0x060009E8 RID: 2536 RVA: 0x00008235 File Offset: 0x00006435
        private static T GetInfoChat<T>(string text, string s)
        {
            return (T)((object)Convert.ChangeType(text.Substring(s.Length), typeof(T)));
        }

        // Token: 0x04001244 RID: 4676
        public static bool IsXmapRunning = false;

        // Token: 0x04001245 RID: 4677
        public static bool IsMapTransAsXmap = false;

        // Token: 0x04001246 RID: 4678
        public static bool IsShowPanelMapTrans = true;

        // Token: 0x04001247 RID: 4679
        public static bool IsUseCapsuleNormal = true;

        // Token: 0x04001248 RID: 4680
        public static bool IsUseCapsuleVip = true;

        // Token: 0x04001249 RID: 4681
        public static int IdMapCapsuleReturn = -1;
    }
}
namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000CB RID: 231
    public enum TypeMapNext
    {
        // Token: 0x0400124B RID: 4683
        AutoWaypoint,
        // Token: 0x0400124C RID: 4684
        NpcMenu,
        // Token: 0x0400124D RID: 4685
        NpcPanel,
        // Token: 0x0400124E RID: 4686
        Position,
        // Token: 0x0400124F RID: 4687
        Capsule
    }
}
namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000CC RID: 204
    public class XmapAlgorithm
    {
        // Token: 0x060009EB RID: 2539 RVA: 0x00087190 File Offset: 0x00085390
        public static List<int> FindWay(int idMapStart, int idMapEnd)
        {
            List<int> wayPassedStart = XmapAlgorithm.GetWayPassedStart(idMapStart);
            return XmapAlgorithm.FindWay(idMapEnd, wayPassedStart);
        }

        // Token: 0x060009EC RID: 2540 RVA: 0x000871AC File Offset: 0x000853AC
        private static List<int> FindWay(int idMapEnd, List<int> wayPassed)
        {
            int num = wayPassed[wayPassed.Count - 1];
            if (num == idMapEnd)
            {
                return wayPassed;
            }
            if (!XmapData.Instance().CanGetMapNexts(num))
            {
                return null;
            }
            List<List<int>> list = new List<List<int>>();
            foreach (MapNext mapNext in XmapData.Instance().GetMapNexts(num))
            {
                List<int> list2 = null;
                if (!wayPassed.Contains(mapNext.MapID))
                {
                    List<int> wayPassedNext = XmapAlgorithm.GetWayPassedNext(wayPassed, mapNext.MapID);
                    list2 = XmapAlgorithm.FindWay(idMapEnd, wayPassedNext);
                }
                if (list2 != null)
                {
                    list.Add(list2);
                }
            }
            return XmapAlgorithm.GetBestWay(list);
        }

        // Token: 0x060009ED RID: 2541 RVA: 0x00087264 File Offset: 0x00085464
        private static List<int> GetBestWay(List<List<int>> ways)
        {
            if (ways.Count == 0)
            {
                return null;
            }
            List<int> list = ways[0];
            for (int i = 1; i < ways.Count; i++)
            {
                if (XmapAlgorithm.IsWayBetter(ways[i], list))
                {
                    list = ways[i];
                }
            }
            return list;
        }

        // Token: 0x060009EE RID: 2542 RVA: 0x0000827D File Offset: 0x0000647D
        private static List<int> GetWayPassedStart(int idMapStart)
        {
            return new List<int>
            {
                idMapStart
            };
        }

        // Token: 0x060009EF RID: 2543 RVA: 0x0000828B File Offset: 0x0000648B
        private static List<int> GetWayPassedNext(List<int> wayPassed, int idMapNext)
        {
            return new List<int>(wayPassed)
            {
                idMapNext
            };
        }

        // Token: 0x060009F0 RID: 2544 RVA: 0x000872AC File Offset: 0x000854AC
        private static bool IsWayBetter(List<int> way1, List<int> way2)
        {
            bool flag = XmapAlgorithm.IsBadWay(way1);
            bool flag2 = XmapAlgorithm.IsBadWay(way2);
            return (!flag || flag2) && ((!flag && flag2) || way1.Count < way2.Count);
        }

        // Token: 0x060009F1 RID: 2545 RVA: 0x0000829A File Offset: 0x0000649A
        private static bool IsBadWay(List<int> way)
        {
            return XmapAlgorithm.IsWayGoFutureAndBack(way);
        }

        // Token: 0x060009F2 RID: 2546 RVA: 0x000872EC File Offset: 0x000854EC
        private static bool IsWayGoFutureAndBack(List<int> way)
        {
            List<int> list = new List<int>
            {
                27,
                28,
                29
            };
            for (int i = 1; i < way.Count - 1; i++)
            {
                if (way[i] == 102 && way[i + 1] == 24 && list.Contains(way[i - 1]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000CD RID: 205
    public class XmapController : IActionListener
    {
        // Token: 0x060009F4 RID: 2548 RVA: 0x00087358 File Offset: 0x00085558
        public static void Update()
        {
            if (XmapController.IsWaiting() || XmapData.Instance().IsLoading)
            {
                return;
            }
            if (XmapController.IsWaitNextMap)
            {
                XmapController.Wait(200);
                XmapController.IsWaitNextMap = false;
                return;
            }
            if (XmapController.IsNextMapFailed)
            {
                XmapData.Instance().MyLinkMaps = null;
                XmapController.WayXmap = null;
                XmapController.IsNextMapFailed = false;
                return;
            }
            if (XmapController.WayXmap == null)
            {
                if (XmapData.Instance().MyLinkMaps == null)
                {
                    XmapData.Instance().LoadLinkMaps();
                    return;
                }
                XmapController.WayXmap = XmapAlgorithm.FindWay(TileMap.mapID, XmapController.IdMapEnd);
                XmapController.IndexWay = 0;
                if (XmapController.WayXmap == null)
                {
                    GameScr.info1.addInfo("Không thể tìm thấy đường đi", 0);
                    XmapController.FinishXmap();
                    return;
                }
            }
            if (TileMap.mapID == XmapController.WayXmap[XmapController.WayXmap.Count - 1] && !XmapData.IsMyCharDie())
            {
                GameScr.info1.addInfo("Đã đến: " + (XmapController.get_map_names(TileMap.mapID)), 0);
                XmapController.FinishXmap();
                return;
            }
            if (TileMap.mapID == XmapController.WayXmap[XmapController.IndexWay])
            {
                if (XmapData.IsMyCharDie())
                {
                    Service.gI().returnTownFromDead();
                    XmapController.IsWaitNextMap = (XmapController.IsNextMapFailed = true);
                }
                else if (XmapData.CanNextMap())
                {
                    XmapController.NextMap(XmapController.WayXmap[XmapController.IndexWay + 1]);
                    XmapController.IsWaitNextMap = true;
                }
                XmapController.Wait(500);
                return;
            }
            if (TileMap.mapID == XmapController.WayXmap[XmapController.IndexWay + 1])
            {
                XmapController.IndexWay++;
                return;
            }
            XmapController.IsNextMapFailed = true;
        }

        // Token: 0x060009F5 RID: 2549 RVA: 0x000082A2 File Offset: 0x000064A2
        public void perform(int idAction, object p)
        {
            if (idAction == 1)
            {
                XmapController.ShowPanelXmap((List<int>)p);
            }
        }

        // Token: 0x060009F6 RID: 2550 RVA: 0x000082B3 File Offset: 0x000064B3
        private static void Wait(int time)
        {
            XmapController.IsWait = true;
            XmapController.TimeStartWait = mSystem.currentTimeMillis();
            XmapController.TimeWait = (long)time;
        }

        // Token: 0x060009F7 RID: 2551 RVA: 0x000082CC File Offset: 0x000064CC
        private static bool IsWaiting()
        {
            if (XmapController.IsWait && mSystem.currentTimeMillis() - XmapController.TimeStartWait >= XmapController.TimeWait)
            {
                XmapController.IsWait = false;
            }
            return XmapController.IsWait;
        }

        // Token: 0x060009F8 RID: 2552 RVA: 0x000874E0 File Offset: 0x000856E0
        public static void ShowXmapMenu()
        {
            XmapData.Instance().LoadGroupMapsFromFile("Dragon ball_240_Data\\TextData\\GroupMapsXmap.txt");
            MyVector myVector = new MyVector();
            foreach (GroupMap groupMap in XmapData.Instance().GroupMaps)
            {
                myVector.addElement(new Command(groupMap.NameGroup, XmapController._Instance, 1, groupMap.IdMaps));
            }
            GameCanvas.menu.startAt(myVector, 3);
        }

        public static string get_map_names(int id)
        {
            string name = TileMap.mapName;
            if (id >= 0 && id <= GameMod.MapNames.Length && GameMod.MapNames[id] != null && !string.IsNullOrEmpty(GameMod.MapNames[id]))
            {
                name = GameMod.MapNames[id];
            }
            return name;
        }
        // Token: 0x060009F9 RID: 2553 RVA: 0x00087570 File Offset: 0x00085770
        public static void ShowPanelXmap(List<int> idMaps)
        {
            Pk9rXmap.IsMapTransAsXmap = true;
            int count = idMaps.Count;
            GameCanvas.panel.mapNames = new string[count];
            GameCanvas.panel.planetNames = new string[count];
            for (int i = 0; i < count; i++)
            {
                string str = get_map_names(idMaps[i]);
                GameCanvas.panel.mapNames[i] = idMaps[i].ToString() + ": " + str;
                GameCanvas.panel.planetNames[i] = "";
            }
            GameCanvas.panel.setTypeMapTrans();
            GameCanvas.panel.show();
        }

        // Token: 0x060009FA RID: 2554 RVA: 0x000082F2 File Offset: 0x000064F2
        public static void StartRunToMapId(int idMap)
        {
            XmapController.IdMapEnd = idMap;
            Pk9rXmap.IsXmapRunning = true;
        }

        // Token: 0x060009FB RID: 2555 RVA: 0x00008300 File Offset: 0x00006500
        public static void FinishXmap()
        {
            Pk9rXmap.IsXmapRunning = false;
            XmapController.IsNextMapFailed = false;
            XmapData.Instance().MyLinkMaps = null;
            XmapController.WayXmap = null;
            GameCanvas.panel.hide();
        }

        // Token: 0x060009FC RID: 2556 RVA: 0x0000831F File Offset: 0x0000651F
        public static void SaveIdMapCapsuleReturn()
        {
            Pk9rXmap.IdMapCapsuleReturn = TileMap.mapID;
        }

        // Token: 0x060009FD RID: 2557 RVA: 0x00087610 File Offset: 0x00085810
        private static void NextMap(int idMapNext)
        {
            VuDangMapNext = idMapNext;
            List<MapNext> mapNexts = XmapData.Instance().GetMapNexts(TileMap.mapID);
            if (mapNexts != null)
            {
                foreach (MapNext mapNext in mapNexts)
                {
                    if (mapNext.MapID == idMapNext)
                    {
                        XmapController.NextMap(mapNext);
                        return;
                    }
                }
            }
            GameScr.info1.addInfo("Lỗi tại dữ liệu", 0);
        }
        public static int VuDangMapNext;
        // Token: 0x060009FE RID: 2558 RVA: 0x0008768C File Offset: 0x0008588C
        private static void NextMap(MapNext mapNext)
        {
            switch (mapNext.Type)
            {
                case TypeMapNext.AutoWaypoint:
                    XmapController.NextMapAutoWaypoint(mapNext);
                    return;
                case TypeMapNext.NpcMenu:
                    XmapController.NextMapNpcMenu(mapNext);
                    return;
                case TypeMapNext.NpcPanel:
                    XmapController.NextMapNpcPanel(mapNext);
                    return;
                case TypeMapNext.Position:
                    XmapController.NextMapPosition(mapNext);
                    return;
                case TypeMapNext.Capsule:
                    XmapController.NextMapCapsule(mapNext);
                    return;
                default:
                    return;
            }
        }
        public static int TeleMore(int x)
        {
            int result;
            if (x < TileMap.pxw - TileMap.pxw + 20)
            {
                result = 100;
            }
            else
            {
                result = -100;
            }
            return result;
        }
        // Token: 0x060009FF RID: 2559 RVA: 0x000876E0 File Offset: 0x000858E0
        private static void NextMapAutoWaypoint(MapNext mapNext)
        {
            Waypoint waypoint = XmapData.FindWaypoint(mapNext.MapID);
            if (waypoint != null)
            {
                int posWaypointX = XmapData.GetPosWaypointX(waypoint);
                int posWaypointY = XmapData.GetPosWaypointY(waypoint);
                //if (GameMod.serverNow == 2)
                //{
                //    XmapController.MoveMyChar(posWaypointX + XmapController.TeleMore(posWaypointX), posWaypointY);
                //    PickMobController.Move(posWaypointX, posWaypointY);
                //    XmapController.RequestChangeMap(waypoint);
                //    return;
                //}
                XmapController.MoveMyChar(posWaypointX, posWaypointY);
                Char.myCharz().currentMovePoint = new MovePoint(posWaypointX, posWaypointY);
                XmapController.RequestChangeMap(waypoint);
            }
        }

        // Token: 0x06000A00 RID: 2560 RVA: 0x00087718 File Offset: 0x00085918
        private static void NextMapNpcMenu(MapNext mapNext)
        {
            int num = mapNext.Info[0];
            if (GameScr.findNPCInMap((short)num) == null)
            {
                XmapController.fixtl();
                return;
            }
            GameMod.GotoNpc(num);
            Service.gI().openMenu(num);
            for (int i = 0; i < GameCanvas.menu.menuItems.size(); i++)
            {
                if (((Command)GameCanvas.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("tương lai") && VuDangMapNext >= 92 && VuDangMapNext <= 103)
                {
                    Service.gI().confirmMenu((short)num, (sbyte)i);
                    return;
                }
                if (((Command)GameCanvas.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("yardart") && VuDangMapNext >= 131 && VuDangMapNext <= 133)
                {
                    Service.gI().confirmMenu((short)num, (sbyte)i);
                    return;
                }
                if (VuDangMapNext >= 161 && VuDangMapNext <= 164)
                {
                    if (((Command)GameCanvas.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("thực vật"))
                        Service.gI().confirmMenu((short)num, (sbyte)i);
                    else
                        Service.gI().useItem(0, 1, (sbyte)GameMod.FindIndexItem(992), -1);
                    return;
                }
            }
            for (int i = 1; i < mapNext.Info.Length; i++)
            {
                int num2 = mapNext.Info[i];
                Service.gI().confirmMenu((short)num, (sbyte)num2);
            }
        }
        private static void fixtl()
        {
            if (TileMap.mapID == 27)
            {
                XmapController.NextMap(28);
                XmapController.IsWaitNextMap = true;
                XmapController.step = 0;
                return;
            }
            if (TileMap.mapID == 29)
            {
                XmapController.NextMap(28);
                XmapController.IsWaitNextMap = true;
                XmapController.step = 1;
                return;
            }
            if (XmapController.step == 0)
            {
                XmapController.NextMap(29);
                XmapController.IsWaitNextMap = true;
                return;
            }
            if (XmapController.step == 1)
            {
                XmapController.NextMap(27);
                XmapController.IsWaitNextMap = true;
            }
        }
        private static int step;
        // Token: 0x06000A01 RID: 2561 RVA: 0x00087764 File Offset: 0x00085964
        private static void NextMapNpcPanel(MapNext mapNext)
        {
            int num = mapNext.Info[0];
            int num2 = mapNext.Info[1];
            int selected = mapNext.Info[2];
            GameMod.GotoNpc(num);
            Service.gI().openMenu(num);
            Service.gI().confirmMenu((short)num, (sbyte)num2);
            Service.gI().requestMapSelect(selected);
        }

        // Token: 0x06000A02 RID: 2562 RVA: 0x000877B0 File Offset: 0x000859B0
        private static void NextMapPosition(MapNext mapNext)
        {
            int x = mapNext.Info[0];
            int y = mapNext.Info[1];
            XmapController.MoveMyChar(x, y);
            Service.gI().requestChangeMap();
            if (GameMod.isMapOffline(mapNext.MapID))
                Service.gI().getMapOffline();
        }

        // Token: 0x06000A03 RID: 2563 RVA: 0x000877E8 File Offset: 0x000859E8
        private static void NextMapCapsule(MapNext mapNext)
        {
            XmapController.SaveIdMapCapsuleReturn();
            int selected = mapNext.Info[0];
            Service.gI().requestMapSelect(selected);
        }

        // Token: 0x06000A04 RID: 2564 RVA: 0x0000832B File Offset: 0x0000652B
        public static void UseCapsuleNormal()
        {
            Pk9rXmap.IsShowPanelMapTrans = false;
            Service.gI().useItem(0, 1, (sbyte)GameMod.FindIndexItem(193), -1);
        }

        // Token: 0x06000A05 RID: 2565 RVA: 0x00008345 File Offset: 0x00006545
        public static void UseCapsuleVip()
        {
            Pk9rXmap.IsShowPanelMapTrans = false;
            Service.gI().useItem(0, 1, (sbyte)GameMod.FindIndexItem(194), -1);
        }

        // Token: 0x06000A06 RID: 2566 RVA: 0x0000835F File Offset: 0x0000655F
        public static void HideInfoDlg()
        {
            InfoDlg.hide();
        }

        // Token: 0x06000A07 RID: 2567 RVA: 0x000414C4 File Offset: 0x0003F6C4
        private static void MoveMyChar(int x, int y)
        {
            GameMod.GotoXY(x, y);
        }

        // Token: 0x06000A08 RID: 2568 RVA: 0x00008366 File Offset: 0x00006566
        private static void RequestChangeMap(Waypoint waypoint)
        {
            waypoint.popup.command.performAction();
            if (waypoint.isOffline)
            {
                //Service.gI().getMapOffline();
                return;
            }
            Service.gI().requestChangeMap();
        }

        // Token: 0x04001250 RID: 4688
        private const int TIME_DELAY_NEXTMAP = 200;

        // Token: 0x04001251 RID: 4689
        private const int TIME_DELAY_RENEXTMAP = 500;

        // Token: 0x04001252 RID: 4690
        private const int ID_ITEM_CAPSULE_VIP = 194;

        // Token: 0x04001253 RID: 4691
        private const int ID_ITEM_CAPSULE = 193;

        // Token: 0x04001254 RID: 4692
        private const int ID_ICON_ITEM_TDLT = 4387;

        // Token: 0x04001255 RID: 4693
        private static readonly XmapController _Instance = new XmapController();

        // Token: 0x04001256 RID: 4694
        public static int IdMapEnd;

        // Token: 0x04001257 RID: 4695
        private static List<int> WayXmap;

        // Token: 0x04001258 RID: 4696
        private static int IndexWay;

        // Token: 0x04001259 RID: 4697
        private static bool IsNextMapFailed;

        // Token: 0x0400125A RID: 4698
        private static bool IsWait;

        // Token: 0x0400125B RID: 4699
        private static long TimeStartWait;

        // Token: 0x0400125C RID: 4700
        private static long TimeWait;

        // Token: 0x0400125D RID: 4701
        private static bool IsWaitNextMap;
    }
}
namespace AssemblyCSharp.Mod.Xmap
{
    // Token: 0x020000CE RID: 206
    public class XmapData
    {
        // Token: 0x06000A0B RID: 2571 RVA: 0x00008391 File Offset: 0x00006591
        private XmapData()
        {
            this.GroupMaps = new List<GroupMap>();
            this.MyLinkMaps = null;
            this.IsLoading = false;
            this.IsLoadingCapsule = false;
        }

        // Token: 0x06000A0C RID: 2572 RVA: 0x000083B9 File Offset: 0x000065B9
        public static XmapData Instance()
        {
            if (XmapData._Instance == null)
            {
                XmapData._Instance = new XmapData();
            }
            return XmapData._Instance;
        }

        // Token: 0x06000A0D RID: 2573 RVA: 0x000083D1 File Offset: 0x000065D1
        public void LoadLinkMaps()
        {
            this.IsLoading = true;
        }

        // Token: 0x06000A0E RID: 2574 RVA: 0x00087810 File Offset: 0x00085A10
        public void Update()
        {
            if (this.IsLoadingCapsule)
            {
                if (!this.IsWaitInfoMapTrans())
                {
                    this.LoadLinkMapCapsule();
                    this.IsLoadingCapsule = false;
                    this.IsLoading = false;
                }
                return;
            }
            this.LoadLinkMapBase();
            if (XmapData.CanUseCapsuleVip())
            {
                XmapController.UseCapsuleVip();
                this.IsLoadingCapsule = true;
                return;
            }
            if (XmapData.CanUseCapsuleNormal())
            {
                XmapController.UseCapsuleNormal();
                this.IsLoadingCapsule = true;
                return;
            }
            this.IsLoading = false;
        }

        // Token: 0x06000A0F RID: 2575 RVA: 0x00087878 File Offset: 0x00085A78
        public void LoadGroupMapsFromFile(string path)
        {
            this.GroupMaps.Clear();
            this.GroupMaps = new List<GroupMap>
            {
                new GroupMap("Trái đất", new List<int>{42, 21, 0, 1, 2, 3, 4, 5, 6, 27, 28, 29, 30, 47, 46, 45, 48, 50, 111, 24, 53, 58, 59, 60, 61, 62, 55, 56, 54, 57}),
                new GroupMap("Namec", new List<int>{43, 22, 7, 8, 9, 11, 12, 13, 10, 31, 32, 33, 34, 25}),
                new GroupMap("Xayda", new List<int>{44, 23, 14, 15, 16, 17, 18, 20, 19, 35, 36, 37, 38, 26, 52, 84, 129}),
                new GroupMap("Nappa", new List<int>{68, 69, 70, 71, 72, 64, 65, 63, 66, 67, 73, 74, 75, 76, 77, 81, 82, 83, 79, 80, 131, 132, 133}),
                new GroupMap("Siêu thị", new List<int>{84, 104}),
                new GroupMap("Tương lai", new List<int>{102, 92, 93, 94, 96, 97, 98, 99, 100, 103}),
                new GroupMap("Cold", new List<int>{109, 108, 107, 110, 106, 105}),
                new GroupMap("Hành tinh Thực vật", new List<int>{160, 161, 162, 163}),
                new GroupMap("Potaufeu", new List<int>{139, 140}),
                new GroupMap("Khí Gas", new List<int>{149, 147, 152, 151, 148}),
                new GroupMap("Ngũ Hành Sơn", new List<int>{122, 123, 124})
            };
            this.RemoveMapsHomeInGroupMaps();
        }

        // Token: 0x06000A10 RID: 2576 RVA: 0x0008794C File Offset: 0x00085B4C
        private void RemoveMapsHomeInGroupMaps()
        {
            int cgender = global::Char.myCharz().cgender;
            foreach (GroupMap groupMap in this.GroupMaps)
            {
                if (cgender != 0)
                {
                    if (cgender != 1)
                    {
                        groupMap.IdMaps.Remove(21);
                        groupMap.IdMaps.Remove(22);
                    }
                    else
                    {
                        groupMap.IdMaps.Remove(21);
                        groupMap.IdMaps.Remove(23);
                    }
                }
                else
                {
                    groupMap.IdMaps.Remove(22);
                    groupMap.IdMaps.Remove(23);
                }
            }
        }

        // Token: 0x06000A11 RID: 2577 RVA: 0x00087A04 File Offset: 0x00085C04
        private void LoadLinkMapCapsule()
        {
            this.AddKeyLinkMaps(TileMap.mapID);
            string[] mapNames = GameCanvas.panel.mapNames;
            for (int i = 0; i < mapNames.Length; i++)
            {
                int idMapFromName = XmapData.GetIdMapFromName(mapNames[i]);
                if (idMapFromName != -1)
                {
                    int[] info = new int[]
                    {
                        i
                    };
                    this.MyLinkMaps[TileMap.mapID].Add(new MapNext(idMapFromName, TypeMapNext.Capsule, info));
                }
            }
        }

        // Token: 0x06000A12 RID: 2578 RVA: 0x000083DA File Offset: 0x000065DA
        private void LoadLinkMapBase()
        {
            this.MyLinkMaps = new Dictionary<int, List<MapNext>>();
            this.LoadLinkMapsFromFile();
            this.LoadLinkMapsAutoWaypointFromFile();
            this.LoadLinkMapsHome();
            this.LoadLinkMapSieuThi();
            this.LoadLinkMapToCold();
        }

        // Token: 0x06000A13 RID: 2579 RVA: 0x00087A6C File Offset: 0x00085C6C
        private void LoadLinkMapsFromFile()
        {
            // Generated from LinkMapsXmap.txt
            LoadLinkMap(24, 25, TypeMapNext.NpcMenu, new int[] { 10, 0 });
            LoadLinkMap(25, 24, TypeMapNext.NpcMenu, new int[] { 11, 0 });
            LoadLinkMap(45, 48, TypeMapNext.NpcMenu, new int[] { 19, 3 });
            LoadLinkMap(48, 45, TypeMapNext.NpcMenu, new int[] { 20, 3, 0 });
            LoadLinkMap(48, 50, TypeMapNext.NpcMenu, new int[] { 20, 3, 1 });
            LoadLinkMap(50, 48, TypeMapNext.NpcMenu, new int[] { 44, 0 });
            LoadLinkMap(24, 26, TypeMapNext.NpcMenu, new int[] { 10, 1 });
            LoadLinkMap(26, 24, TypeMapNext.NpcMenu, new int[] { 12, 0 });
            LoadLinkMap(25, 26, TypeMapNext.NpcMenu, new int[] { 11, 1 });
            LoadLinkMap(26, 25, TypeMapNext.NpcMenu, new int[] { 12, 1 });
            LoadLinkMap(24, 84, TypeMapNext.NpcMenu, new int[] { 10, 2 });
            LoadLinkMap(25, 84, TypeMapNext.NpcMenu, new int[] { 11, 2 });
            LoadLinkMap(26, 84, TypeMapNext.NpcMenu, new int[] { 12, 2 });
            LoadLinkMap(19, 68, TypeMapNext.NpcMenu, new int[] { 12, 2 });
            LoadLinkMap(68, 19, TypeMapNext.NpcMenu, new int[] { 12, 0 });
            LoadLinkMap(80, 131, TypeMapNext.NpcMenu, new int[] { 60, 0 });
            LoadLinkMap(27, 102, TypeMapNext.NpcMenu, new int[] { 38, 1 });
            LoadLinkMap(28, 102, TypeMapNext.NpcMenu, new int[] { 38, 1 });
            LoadLinkMap(29, 102, TypeMapNext.NpcMenu, new int[] { 38, 1 });
            LoadLinkMap(102, 24, TypeMapNext.NpcMenu, new int[] { 38, 1 });
            LoadLinkMap(27, 53, TypeMapNext.NpcMenu, new int[] { 25, 0 });
            LoadLinkMap(52, 129, TypeMapNext.NpcMenu, new int[] { 23, 3 });
            LoadLinkMap(0, 149, TypeMapNext.NpcMenu, new int[] { 67, 3, 0 });
            LoadLinkMap(45, 48, TypeMapNext.NpcMenu, new int[] { 19, 3 });
            LoadLinkMap(50, 48, TypeMapNext.NpcMenu, new int[] { 44, 0 });
            LoadLinkMap(139, 25, TypeMapNext.NpcMenu, new int[] { 63, 1 });
            LoadLinkMap(139, 26, TypeMapNext.NpcMenu, new int[] { 63, 2 });
            LoadLinkMap(24, 139, TypeMapNext.NpcMenu, new int[] { 63, 0 });
            LoadLinkMap(139, 24, TypeMapNext.NpcMenu, new int[] { 63, 0 });
            LoadLinkMap(19, 126, TypeMapNext.NpcMenu, new int[] { 53, 0 });
            LoadLinkMap(126, 19, TypeMapNext.NpcMenu, new int[] { 53, 0 });
            LoadLinkMap(0, 122, TypeMapNext.NpcMenu, new int[] { 49, 0 });
            LoadLinkMap(19, 160, TypeMapNext.NpcMenu, new int[] { 12, 0 });
            LoadLinkMap(19, 109, TypeMapNext.NpcMenu, new int[] { 12, 1 });
        }

        // Token: 0x06000A14 RID: 2580 RVA: 0x00087B3C File Offset: 0x00085D3C
        private void LoadLinkMapsAutoWaypointFromFile()
        {
            try
            {
                // Generated from AutoLinkMapsWaypoint.txt
                LoadLinkMap(42, 0, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(0, 42, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(0, 1, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(1, 0, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(1, 2, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(2, 1, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(2, 3, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(3, 2, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(3, 4, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(4, 3, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(4, 5, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(5, 4, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(5, 6, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(6, 5, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(3, 27, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(27, 3, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(27, 28, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(28, 27, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(28, 29, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(29, 28, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(29, 30, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(30, 29, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(2, 24, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(24, 2, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(1, 47, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(47, 1, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(47, 46, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(46, 47, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(46, 45, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(45, 46, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(5, 29, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(29, 5, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(47, 111, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(111, 47, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(53, 58, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(58, 53, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(58, 59, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(59, 58, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(59, 60, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(60, 59, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(60, 61, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(61, 60, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(61, 62, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(62, 61, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(62, 55, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(55, 62, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(55, 56, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(56, 55, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(56, 54, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(54, 56, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(54, 57, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(57, 54, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(53, 27, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(27, 53, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(43, 7, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(7, 43, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(7, 8, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(8, 7, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(8, 9, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(9, 8, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(9, 11, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(11, 9, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(11, 12, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(12, 11, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(12, 13, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(13, 12, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(13, 10, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(10, 13, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(11, 31, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(31, 11, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(31, 32, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(32, 31, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(32, 33, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(33, 32, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(33, 34, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(34, 33, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(9, 25, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(25, 9, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(13, 33, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(33, 13, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(52, 44, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(44, 52, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(44, 14, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(14, 44, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(14, 15, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(15, 14, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(15, 16, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(16, 15, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(16, 17, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(17, 16, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(17, 18, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(18, 17, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(18, 20, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(20, 18, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(20, 19, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(19, 20, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(17, 35, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(35, 17, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(35, 36, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(36, 35, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(36, 37, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(37, 36, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(37, 38, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(38, 37, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(16, 26, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(26, 16, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(20, 37, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(37, 20, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(68, 69, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(69, 68, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(69, 70, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(70, 69, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(70, 71, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(71, 70, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(71, 72, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(72, 71, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(72, 64, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(64, 72, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(64, 65, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(65, 64, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(65, 63, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(63, 65, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(63, 66, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(66, 63, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(66, 67, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(67, 66, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(67, 73, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(73, 67, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(73, 74, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(74, 73, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(74, 75, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(75, 74, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(75, 76, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(76, 75, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(76, 77, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(77, 76, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(77, 81, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(81, 77, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(81, 82, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(82, 81, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(82, 83, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(83, 82, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(83, 79, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(79, 83, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(79, 80, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(80, 79, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(102, 92, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(92, 102, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(92, 93, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(93, 92, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(93, 94, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(94, 93, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(94, 96, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(96, 94, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(96, 97, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(97, 96, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(97, 98, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(98, 97, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(98, 99, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(99, 98, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(99, 100, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(100, 99, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(100, 103, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(103, 100, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(109, 108, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(108, 109, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(108, 107, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(107, 108, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(107, 110, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(110, 107, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(110, 106, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(106, 110, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(109, 105, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(105, 109, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(109, 106, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(106, 109, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(106, 107, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(107, 106, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(108, 105, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(105, 108, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(131, 132, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(132, 131, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(132, 133, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(133, 132, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(80, 105, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(105, 80, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(160, 161, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(161, 160, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(161, 162, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(162, 161, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(162, 163, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(163, 162, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(139, 140, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(140, 139, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(149, 147, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(147, 149, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(147, 152, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(152, 147, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(152, 151, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(151, 152, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(151, 148, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(148, 151, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(122, 123, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(123, 122, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(123, 124, TypeMapNext.AutoWaypoint, null);
                LoadLinkMap(124, 123, TypeMapNext.AutoWaypoint, null);
            }
            catch (Exception ex)
            {
                GameScr.info1.addInfo(ex.Message, 0);
            }
        }

        // Token: 0x06000A15 RID: 2581 RVA: 0x00087C1C File Offset: 0x00085E1C
        private void LoadLinkMapsHome()
        {
            int cgender = global::Char.myCharz().cgender;
            int num = 21 + cgender;
            int num2 = 7 * cgender;
            this.LoadLinkMap(num2, num, TypeMapNext.AutoWaypoint, null);
            this.LoadLinkMap(num, num2, TypeMapNext.AutoWaypoint, null);
        }

        // Token: 0x06000A16 RID: 2582 RVA: 0x00087C54 File Offset: 0x00085E54
        private void LoadLinkMapSieuThi()
        {
            int cgender = global::Char.myCharz().cgender;
            int idMapNext = 24 + cgender;
            int[] array = new int[2];
            array[0] = 10;
            int[] info = array;
            this.LoadLinkMap(84, idMapNext, TypeMapNext.NpcMenu, info);
        }

        // Token: 0x06000A17 RID: 2583 RVA: 0x00087C88 File Offset: 0x00085E88
        private void LoadLinkMapToCold()
        {
            if (global::Char.myCharz().taskMaint.taskId > 30)
            {
                int[] array = new int[2];
                array[0] = 12;
                int[] info = array;
                this.LoadLinkMap(19, 109, TypeMapNext.NpcMenu, info);
            }
        }

        // Token: 0x06000A18 RID: 2584 RVA: 0x0000840F File Offset: 0x0000660F
        public List<MapNext> GetMapNexts(int idMap)
        {
            if (this.CanGetMapNexts(idMap))
            {
                return this.MyLinkMaps[idMap];
            }
            return null;
        }

        // Token: 0x06000A19 RID: 2585 RVA: 0x00008428 File Offset: 0x00006628
        public bool CanGetMapNexts(int idMap)
        {
            return this.MyLinkMaps.ContainsKey(idMap);
        }

        // Token: 0x06000A1A RID: 2586 RVA: 0x00087CC0 File Offset: 0x00085EC0
        private void LoadLinkMap(int idMapStart, int idMapNext, TypeMapNext type, int[] info)
        {
            this.AddKeyLinkMaps(idMapStart);
            MapNext item = new MapNext(idMapNext, type, info);
            this.MyLinkMaps[idMapStart].Add(item);
        }

        // Token: 0x06000A1B RID: 2587 RVA: 0x00008436 File Offset: 0x00006636
        private void AddKeyLinkMaps(int idMap)
        {
            if (!this.MyLinkMaps.ContainsKey(idMap))
            {
                this.MyLinkMaps.Add(idMap, new List<MapNext>());
            }
        }

        // Token: 0x06000A1C RID: 2588 RVA: 0x00008457 File Offset: 0x00006657
        private bool IsWaitInfoMapTrans()
        {
            return !Pk9rXmap.IsShowPanelMapTrans;
        }

        // Token: 0x06000A1D RID: 2589 RVA: 0x00008461 File Offset: 0x00006661
        public static int GetIdMapFromPanelXmap(string mapName)
        {
            return int.Parse(mapName.Split(new char[]
            {
                ':'
            })[0]);
        }

        // Token: 0x06000A1E RID: 2590 RVA: 0x00087CF4 File Offset: 0x00085EF4
        public static Waypoint FindWaypoint(int idMap)
        {
            for (int i = 0; i < TileMap.vGo.size(); i++)
            {
                Waypoint waypoint = (Waypoint)TileMap.vGo.elementAt(i);
                if (XmapController.IdMapEnd == 124 && TileMap.mapID == 123)
                {
                    for (int j = 0; j < TileMap.vGo.size(); j++)
                    {
                        Waypoint waypoint2 = (Waypoint)TileMap.vGo.elementAt(j);
                        if (j == TileMap.vGo.size() - 1)
                            return waypoint2;
                    }
                }
                if (XmapData.GetTextPopup(waypoint.popup).Trim().ToLower().Equals(XmapController.get_map_names(idMap).Trim().ToLower()))
                {
                    return waypoint;
                }
            }
            return null;
        }

        // Token: 0x06000A1F RID: 2591 RVA: 0x0000847B File Offset: 0x0000667B
        public static int GetPosWaypointX(Waypoint waypoint)
        {
            if (waypoint.maxX < 60)
            {
                return 15;
            }
            if ((int)waypoint.minX > TileMap.pxw - 60)
            {
                return TileMap.pxw - 15;
            }
            return (int)(waypoint.minX + 30);
        }

        // Token: 0x06000A20 RID: 2592 RVA: 0x000084AC File Offset: 0x000066AC
        public static int GetPosWaypointY(Waypoint waypoint)
        {
            return (int)waypoint.maxY;
        }

        // Token: 0x06000A21 RID: 2593 RVA: 0x000084B4 File Offset: 0x000066B4
        public static bool IsMyCharDie()
        {
            return global::Char.myCharz().statusMe == 14 || global::Char.myCharz().cHP <= 0;
        }

        // Token: 0x06000A22 RID: 2594 RVA: 0x000084D6 File Offset: 0x000066D6
        public static bool CanNextMap()
        {
            return !global::Char.isLoadingMap && !global::Char.ischangingMap && !Controller.isStopReadMessage;
        }

        // Token: 0x06000A23 RID: 2595 RVA: 0x00087D44 File Offset: 0x00085F44
        private static int GetIdMapFromName(string mapName)
        {
            int cgender = global::Char.myCharz().cgender;
            if (mapName.Equals("Về nhà"))
            {
                return 21 + cgender;
            }
            if (mapName.Equals("Trạm tàu vũ trụ"))
            {
                return 24 + cgender;
            }
            if (mapName.Contains("Về chỗ cũ: "))
            {
                mapName = mapName.Replace("Về chỗ cũ: ", "");
                if (XmapController.get_map_names(Pk9rXmap.IdMapCapsuleReturn).Equals(mapName))
                {
                    return Pk9rXmap.IdMapCapsuleReturn;
                }
                if (mapName.Equals("Rừng đá"))
                {
                    return -1;
                }
            }
            for (int i = 0; i < TileMap.mapNames.Length; i++)
            {
                if (mapName.Equals(XmapController.get_map_names(i)))
                {
                    return i;
                }
            }
            return -1;
        }

        // Token: 0x06000A24 RID: 2596 RVA: 0x00087DEC File Offset: 0x00085FEC
        public static string GetTextPopup(PopUp popUp)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < popUp.says.Length; i++)
            {
                stringBuilder.Append(popUp.says[i]);
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString().Trim();
        }

        // Token: 0x06000A25 RID: 2597 RVA: 0x000084F0 File Offset: 0x000066F0
        private static bool CanUseCapsuleNormal()
        {
            return !XmapData.IsMyCharDie() && Pk9rXmap.IsUseCapsuleNormal && XmapData.HasItemCapsuleNormal();
        }

        // Token: 0x06000A26 RID: 2598 RVA: 0x00087E38 File Offset: 0x00086038
        private static bool HasItemCapsuleNormal()
        {
            Item[] arrItemBag = global::Char.myCharz().arrItemBag;
            for (int i = 0; i < arrItemBag.Length; i++)
            {
                if (arrItemBag[i] != null && arrItemBag[i].template.id == 193)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000A27 RID: 2599 RVA: 0x00008507 File Offset: 0x00006707
        private static bool CanUseCapsuleVip()
        {
            return !XmapData.IsMyCharDie() && Pk9rXmap.IsUseCapsuleVip && XmapData.HasItemCapsuleVip();
        }

        // Token: 0x06000A28 RID: 2600 RVA: 0x00087E7C File Offset: 0x0008607C
        private static bool HasItemCapsuleVip()
        {
            Item[] arrItemBag = global::Char.myCharz().arrItemBag;
            for (int i = 0; i < arrItemBag.Length; i++)
            {
                if (arrItemBag[i] != null && arrItemBag[i].template.id == 194)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0400125E RID: 4702
        private const int ID_MAP_HOME_BASE = 21;

        // Token: 0x0400125F RID: 4703
        private const int ID_MAP_TTVT_BASE = 24;

        // Token: 0x04001260 RID: 4704
        private const int ID_ITEM_CAPSUAL_VIP = 194;

        // Token: 0x04001261 RID: 4705
        private const int ID_ITEM_CAPSUAL_NORMAL = 193;

        // Token: 0x04001262 RID: 4706
        private const int ID_MAP_TPVGT = 19;

        // Token: 0x04001263 RID: 4707
        private const int ID_MAP_TO_COLD = 109;

        // Token: 0x04001264 RID: 4708
        public List<GroupMap> GroupMaps;

        // Token: 0x04001265 RID: 4709
        public Dictionary<int, List<MapNext>> MyLinkMaps;

        // Token: 0x04001266 RID: 4710
        public bool IsLoading;

        // Token: 0x04001267 RID: 4711
        private bool IsLoadingCapsule;

        // Token: 0x04001268 RID: 4712
        private static XmapData _Instance;
    }
}