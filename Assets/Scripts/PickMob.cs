using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp.Mod.PickMob
{
    // Token: 0x020000B2 RID: 178
    public class PickMobController
    {
        // Token: 0x06000913 RID: 2323 RVA: 0x0007BFEC File Offset: 0x0007A1EC
        public static void Update()
        {
            if (PickMobController.IsWaiting())
            {
                return;
            }
            global::Char @char = global::Char.myCharz();
            if (@char.statusMe == 14 || @char.cHP <= 0)
            {
                return;
            }
            if (GameScr.hpPotion >= 1 && (@char.cHP <= (@char.cHPFull * Pk9rPickMob.HpBuff) / 100 || @char.cMP <= (@char.cMPFull * Pk9rPickMob.MpBuff) / 100))
            {
                GameScr.gI().doUseHP();
            }
            bool flag = ItemTime.isExistItem(4387);
            bool flag2 = Pk9rPickMob.IsTanSat && flag;
            if (Pk9rPickMob.IsAutoPickItems && !flag2)
            {
                if (PickMobController.IsPickingItems)
                {
                    if (PickMobController.IndexItemPick >= PickMobController.ItemPicks.Count)
                    {
                        PickMobController.IsPickingItems = false;
                        return;
                    }
                    ItemMap itemMap = PickMobController.ItemPicks[PickMobController.IndexItemPick];
                    switch (PickMobController.GetTpyePickItem(itemMap))
                    {
                        case PickMobController.TpyePickItem.CanNotPickItem:
                            PickMobController.IndexItemPick++;
                            return;
                        case PickMobController.TpyePickItem.PickItemNormal:
                            //if (GameMod.dichChuyenPem)
                            //{
                            //    if (Math.abs(itemMap.xEnd - @char.cx) >= 20 || Math.abs(itemMap.yEnd - @char.cy) >= 20)
                            //    {
                            //        GameMod.GotoXY(itemMap.xEnd, itemMap.yEnd);
                            //    }
                            //}
                            //else
                            //{
                            //    Service.gI().charMove();
                            //}
                            //Char.myCharz().focusManualTo(itemMap);
                            Service.gI().pickItem(itemMap.itemMapID);
                            if (Pk9rPickMob.IsTanSat)
                            {
                                itemMap.countAutoPick++;
                                PickMobController.IndexItemPick++;
                            }
                            PickMobController.Wait(Pk9rPickMob.TimesAutoPickItemMax <= 1 ? 1 : 500);
                            return;
                        case PickMobController.TpyePickItem.PickItemTDLT:
                            //if (GameMod.dichChuyenPem)
                            //{
                            //    if (Math.abs(itemMap.xEnd - @char.cx) >= 20 || Math.abs(itemMap.yEnd - @char.cy) >= 20)
                            //    {
                            //        GameMod.GotoXY(itemMap.xEnd, itemMap.yEnd);
                            //    }
                            //}
                            //else
                            //{
                            //    @char.cx = itemMap.xEnd;
                            //    @char.cy = itemMap.yEnd;
                            //    Service.gI().charMove();
                            //}
                            //Char.myCharz().focusManualTo(itemMap);
                            Service.gI().pickItem(itemMap.itemMapID);
                            if (Pk9rPickMob.IsTanSat)
                            {
                                itemMap.countAutoPick++;
                                PickMobController.IndexItemPick++;
                            }
                            PickMobController.Wait(Pk9rPickMob.TimesAutoPickItemMax <= 1 ? 1 : 500);
                            return;
                        case PickMobController.TpyePickItem.PickItemTanSat:
                            //if (GameMod.dichChuyenPem)
                            //{
                            //    if (Math.abs(itemMap.xEnd - @char.cx) >= 20 || Math.abs(itemMap.yEnd - @char.cy) >= 20)
                            //    {
                            //        GameMod.GotoXY(itemMap.xEnd, itemMap.yEnd);
                            //    }
                            //}
                            //else
                            //{
                            //    PickMobController.Move(itemMap.xEnd, itemMap.yEnd);
                            //}
                            //Char.myCharz().focusManualTo(itemMap);
                            Service.gI().pickItem(itemMap.itemMapID);
                            //@char.mobFocus = null;
                            PickMobController.Wait(Pk9rPickMob.TimesAutoPickItemMax <= 1 ? 1 : 500);
                            return;
                    }
                }
                PickMobController.ItemPicks.Clear();
                PickMobController.IndexItemPick = 0;
                for (int i = 0; i < GameScr.vItemMap.size(); i++)
                {
                    ItemMap itemMap2 = (ItemMap)GameScr.vItemMap.elementAt(i);
                    if (PickMobController.GetTpyePickItem(itemMap2) != PickMobController.TpyePickItem.CanNotPickItem)
                    {
                        PickMobController.ItemPicks.Add(itemMap2);
                    }
                }
                if (PickMobController.ItemPicks.Count > 0)
                {
                    PickMobController.IsPickingItems = true;
                    return;
                }
            }
            if (Pk9rPickMob.IsTanSat)
            {
                if (Char.myCharz().cHP <= (Char.myCharz().cHPFull * 10) / 100 || Char.myCharz().cMP <= (Char.myCharz().cMPFull * 10) / 100)
                {
                    GameScr.gI().doUseHP();
                }
                if (@char.isCharge)
                {
                    PickMobController.Wait(Pk9rPickMob.IsTanSat ? 1 : 500);
                    return;
                }
                @char.clearFocus(0);
                if (@char.mobFocus != null && (!PickMobController.IsMobTanSat(@char.mobFocus) || GameMod.isMob1HP(@char.mobFocus)))
                {
                    @char.mobFocus = null;
                }
                if (@char.mobFocus == null)
                {
                    @char.mobFocus = PickMobController.GetMobTanSat();
                    if (flag && @char.mobFocus != null && GameMod.isMob1HP(@char.mobFocus))
                    {
                        if (GameMod.dichChuyenPem)
                        {
                            if (Math.abs(@char.mobFocus.xFirst - @char.cx) >= 20 || Math.abs(@char.mobFocus.yFirst - @char.cy) >= 20)
                            {
                                GameMod.GotoXY(@char.mobFocus.xFirst, @char.mobFocus.yFirst);
                            }
                            return;
                        }
                        @char.cx = @char.mobFocus.xFirst;
                        @char.cy = @char.mobFocus.yFirst;
                        Service.gI().charMove();
                    }
                }
                if (@char.mobFocus != null && GameMod.isMob1HP(@char.mobFocus))
                {
                    if (@char.skillInfoPaint() == null)
                    {
                        Skill skillAttack = PickMobController.GetSkillAttack();
                        if (skillAttack != null && !skillAttack.paintCanNotUseSkill)
                        {
                            Mob mobFocus = @char.mobFocus;
                            mobFocus.x = mobFocus.xFirst;
                            mobFocus.y = mobFocus.yFirst;
                            if (Char.myCharz().myskill != skillAttack)
                            {
                                GameScr.gI().doSelectSkill(skillAttack, true);
                            }
                            if (Res.distance(mobFocus.xFirst, mobFocus.yFirst, @char.cx, @char.cy) <= 48)
                            {
                                if (GameCanvas.gameTick % 50 == 0 && Mob.arrMobTemplate[Char.myCharz().mobFocus.templateId].type == 4)
                                {
                                    GameMod.GotoXY(mobFocus.xFirst, mobFocus.yFirst + 1);
                                }
                                if (Char.myCharz().myskill.template.iconId == 539 || Char.myCharz().myskill.template.name.ToLower().Contains("liên hoàn") || Char.myCharz().myskill.template.iconId == 540)
                                {
                                    GameMod.Ak();
                                    return;
                                }
                                GameScr.gI().doDoubleClickToObj(mobFocus);
                            }
                            else
                            {
                                if (GameMod.dichChuyenPem)
                                {
                                    if (Math.abs(mobFocus.xFirst - @char.cx) >= 20 || Math.abs(mobFocus.yFirst - @char.cy) >= 20)
                                    {
                                        GameMod.GotoXY(mobFocus.xFirst, mobFocus.yFirst);
                                    }
                                    return;
                                }
                                PickMobController.Move(mobFocus.xFirst, mobFocus.yFirst);
                            }
                        }
                    }
                }
                else if (!flag)
                {
                    Mob mobNext = PickMobController.GetMobNext();
                    if (mobNext != null && GameMod.isMob1HP(mobNext))
                    {
                        Char.myCharz().focusManualTo(mobNext);
                        if (GameMod.dichChuyenPem)
                        {
                            if (Math.abs(mobNext.xFirst - @char.cx) >= 20 || Math.abs(mobNext.yFirst - @char.cy) >= 20)
                            {
                                GameMod.GotoXY(mobNext.xFirst, mobNext.yFirst);
                            }
                            return;
                        }
                        PickMobController.Move(mobNext.xFirst, mobNext.yFirst);
                    }
                }
                PickMobController.Wait(Pk9rPickMob.IsTanSat ? 1 : 500);
            }
        }

        // Token: 0x06000914 RID: 2324 RVA: 0x0007C35C File Offset: 0x0007A55C
        public static void Move(int x, int y)
        {
            global::Char @char = global::Char.myCharz();
            if (!Pk9rPickMob.IsVuotDiaHinh)
            {
                @char.currentMovePoint = new MovePoint(x, y);
                return;
            }
            int[] pointYsdMax = PickMobController.GetPointYsdMax(@char.cx, x);
            if (pointYsdMax[1] >= y || (pointYsdMax[1] >= @char.cy && (@char.statusMe == 2 || @char.statusMe == 1)))
            {
                pointYsdMax[0] = x;
                pointYsdMax[1] = y;
            }
            @char.currentMovePoint = new MovePoint(pointYsdMax[0], pointYsdMax[1]);
        }

        // Token: 0x06000915 RID: 2325 RVA: 0x0007C3D0 File Offset: 0x0007A5D0
        private static PickMobController.TpyePickItem GetTpyePickItem(ItemMap itemMap)
        {
            global::Char @char = global::Char.myCharz();
            bool flag = itemMap.playerId == @char.charID || itemMap.playerId == -1;
            if (Pk9rPickMob.IsItemMe && !flag)
            {
                return PickMobController.TpyePickItem.CanNotPickItem;
            }
            if (Pk9rPickMob.IsLimitTimesPickItem && itemMap.countAutoPick > Pk9rPickMob.TimesAutoPickItemMax)
            {
                return PickMobController.TpyePickItem.CanNotPickItem;
            }
            if (!PickMobController.FilterItemPick(itemMap))
            {
                return PickMobController.TpyePickItem.CanNotPickItem;
            }
            if (Res.abs(@char.cx - itemMap.xEnd) < 60 && Res.abs(@char.cy - itemMap.yEnd) < 60)
            {
                return PickMobController.TpyePickItem.PickItemNormal;
            }
            if (ItemTime.isExistItem(4387))
            {
                return PickMobController.TpyePickItem.PickItemTDLT;
            }
            if (Pk9rPickMob.IsTanSat)
            {
                return PickMobController.TpyePickItem.PickItemTanSat;
            }
            return PickMobController.TpyePickItem.CanNotPickItem;
        }

        // Token: 0x06000916 RID: 2326 RVA: 0x0007C470 File Offset: 0x0007A670
        private static bool FilterItemPick(ItemMap itemMap)
        {
            return (Pk9rPickMob.IdItemPicks.Count == 0 || Pk9rPickMob.IdItemPicks.Contains(itemMap.template.id)) && (Pk9rPickMob.IdItemBlocks.Count == 0 || !Pk9rPickMob.IdItemBlocks.Contains(itemMap.template.id)) && (Pk9rPickMob.TypeItemPicks.Count == 0 || Pk9rPickMob.TypeItemPicks.Contains(itemMap.template.type)) && (Pk9rPickMob.TypeItemBlock.Count == 0 || !Pk9rPickMob.TypeItemBlock.Contains(itemMap.template.type));
        }

        // Token: 0x06000917 RID: 2327 RVA: 0x0007C514 File Offset: 0x0007A714
        private static Mob GetMobTanSat()
        {
            Mob result = null;
            int num = int.MaxValue;
            global::Char @char = global::Char.myCharz();
            for (int i = 0; i < GameScr.vMob.size(); i++)
            {
                Mob mob = (Mob)GameScr.vMob.elementAt(i);
                int num2 = (mob.xFirst - @char.cx) * (mob.xFirst - @char.cx) + (mob.yFirst - @char.cy) * (mob.yFirst - @char.cy);
                if (PickMobController.IsMobTanSat(mob) && num2 < num && GameMod.isMob1HP(mob))
                {
                    result = mob;
                    num = num2;
                }
            }
            return result;
        }

        // Token: 0x06000918 RID: 2328 RVA: 0x0007C5AC File Offset: 0x0007A7AC
        private static Mob GetMobNext()
        {
            Mob result = null;
            long num = mSystem.currentTimeMillis();
            for (int i = 0; i < GameScr.vMob.size(); i++)
            {
                Mob mob = (Mob)GameScr.vMob.elementAt(i);
                if (PickMobController.IsMobNext(mob) && mob.timeLastDie < num && GameMod.isMob1HP(mob))
                {
                    result = mob;
                    num = mob.timeLastDie;
                }
            }
            return result;
        }

        // Token: 0x06000919 RID: 2329 RVA: 0x0007C604 File Offset: 0x0007A804
        private static bool IsMobTanSat(Mob mob)
        {
            if (mob.status == 0 || mob.status == 1 || mob.hp <= 0 || mob.isMobMe)
            {
                return false;
            }
            bool flag = Pk9rPickMob.IsNeSieuQuai && !ItemTime.isExistItem(4387);
            return (mob.levelBoss == 0 || !flag) && PickMobController.FilterMobTanSat(mob) && GameMod.isMob1HP(mob);
        }

        // Token: 0x0600091A RID: 2330 RVA: 0x0007C668 File Offset: 0x0007A868
        private static bool IsMobNext(Mob mob)
        {
            if (mob.isMobMe)
            {
                return false;
            }
            if (!PickMobController.FilterMobTanSat(mob))
            {
                return false;
            }
            if (Pk9rPickMob.IsNeSieuQuai && !ItemTime.isExistItem(4387) && mob.getTemplate().hp >= 3000)
            {
                if (mob.levelBoss != 0)
                {
                    Mob mob2 = null;
                    bool flag = false;
                    for (int i = 0; i < GameScr.vMob.size(); i++)
                    {
                        mob2 = (Mob)GameScr.vMob.elementAt(i);
                        if (mob2.countDie == 10 && (mob2.status == 0 || mob2.status == 1))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        return false;
                    }
                    mob.timeLastDie = mob2.timeLastDie;
                }
                else if (mob.countDie == 10 && (mob.status == 0 || mob.status == 1))
                {
                    return false;
                }
            }
            return true;
        }

        // Token: 0x0600091B RID: 2331 RVA: 0x0007C73C File Offset: 0x0007A93C
        private static bool FilterMobTanSat(Mob mob)
        {
            return (Pk9rPickMob.IdMobsTanSat.Count == 0 || Pk9rPickMob.IdMobsTanSat.Contains(mob.mobId)) && (Pk9rPickMob.TypeMobsTanSat.Count == 0 || Pk9rPickMob.TypeMobsTanSat.Contains(mob.templateId));
        }

        // Token: 0x0600091C RID: 2332 RVA: 0x0007C78C File Offset: 0x0007A98C
        private static Skill GetSkillAttack()
        {
            Skill skill = null;
            SkillTemplate skillTemplate = new SkillTemplate();
            foreach (sbyte id in Pk9rPickMob.IdSkillsTanSat)
            {
                skillTemplate.id = id;
                Skill skill2 = global::Char.myCharz().getSkill(skillTemplate);
                if (PickMobController.IsSkillBetter(skill2, skill))
                {
                    skill = skill2;
                }
            }
            return skill;
        }

        // Token: 0x0600091D RID: 2333 RVA: 0x0007C800 File Offset: 0x0007AA00
        private static bool IsSkillBetter(Skill SkillBetter, Skill skill)
        {
            if (SkillBetter == null)
            {
                return false;
            }
            if (!PickMobController.CanUseSkill(SkillBetter))
            {
                return false;
            }
            bool flag = (SkillBetter.template.id == 17 && skill.template.id == 2) || (SkillBetter.template.id == 9 && skill.template.id == 0);
            return skill == null || skill.coolDown < SkillBetter.coolDown || flag;
        }

        // Token: 0x0600091E RID: 2334 RVA: 0x0007C874 File Offset: 0x0007AA74
        private static bool CanUseSkill(Skill skill)
        {
            if (mSystem.currentTimeMillis() - skill.lastTimeUseThisSkill > (long)skill.coolDown + 25)
            {
                skill.paintCanNotUseSkill = false;
            }
            return (!skill.paintCanNotUseSkill || PickMobController.IdSkillsMelee.Contains(skill.template.id)) && !PickMobController.IdSkillsCanNotAttack.Contains(skill.template.id) && global::Char.myCharz().cMP >= PickMobController.GetManaUseSkill(skill);
        }

        // Token: 0x0600091F RID: 2335 RVA: 0x0007C8EC File Offset: 0x0007AAEC
        private static int GetManaUseSkill(Skill skill)
        {
            if (skill.template.manaUseType == 2)
            {
                return 1;
            }
            if (skill.template.manaUseType == 1)
            {
                return skill.manaUse * global::Char.myCharz().cMPFull / 100;
            }
            return skill.manaUse;
        }

        // Token: 0x06000920 RID: 2336 RVA: 0x0007C928 File Offset: 0x0007AB28
        public static int GetYsd(int xsd)
        {
            global::Char @char = global::Char.myCharz();
            int num = TileMap.pxh;
            int result = -1;
            for (int i = 24; i < TileMap.pxh; i += 24)
            {
                if (TileMap.tileTypeAt(xsd, i, 2))
                {
                    int num2 = Res.abs(i - @char.cy);
                    if (num2 < num)
                    {
                        num = num2;
                        result = i;
                    }
                }
            }
            return result;
        }

        // Token: 0x06000921 RID: 2337 RVA: 0x0007C980 File Offset: 0x0007AB80
        private static int[] GetPointYsdMax(int xStart, int xEnd)
        {
            int num = TileMap.pxh;
            int num2 = -1;
            if (xStart > xEnd)
            {
                for (int i = xEnd; i < xStart; i += 24)
                {
                    int ysd = PickMobController.GetYsd(i);
                    if (ysd < num)
                    {
                        num = ysd;
                        num2 = i;
                    }
                }
            }
            else
            {
                for (int j = xEnd; j > xStart; j -= 24)
                {
                    int ysd2 = PickMobController.GetYsd(j);
                    if (ysd2 < num)
                    {
                        num = ysd2;
                        num2 = j;
                    }
                }
            }
            return new int[]
            {
                num2,
                num
            };
        }

        // Token: 0x06000922 RID: 2338 RVA: 0x0007C9EA File Offset: 0x0007ABEA
        public static void Wait(int time)
        {
            PickMobController.IsWait = true;
            PickMobController.TimeStartWait = mSystem.currentTimeMillis();
            PickMobController.TimeWait = (long)time;
        }

        // Token: 0x06000923 RID: 2339 RVA: 0x0007CA03 File Offset: 0x0007AC03
        public static bool IsWaiting()
        {
            if (PickMobController.IsWait && mSystem.currentTimeMillis() - PickMobController.TimeStartWait >= PickMobController.TimeWait)
            {
                PickMobController.IsWait = false;
            }
            return PickMobController.IsWait;
        }

        // Token: 0x0400113A RID: 4410
        private const int TIME_REPICKITEM = 500;

        // Token: 0x0400113B RID: 4411
        private const int TIME_DELAY_TANSAT = 0;

        // Token: 0x0400113C RID: 4412
        private const int ID_ICON_ITEM_TDLT = 4387;

        // Token: 0x0400113D RID: 4413
        private static readonly sbyte[] IdSkillsMelee = new sbyte[]
        {
            0,
            9,
            2,
            17,
            4
        };

        // Token: 0x0400113E RID: 4414
        private static readonly sbyte[] IdSkillsCanNotAttack = new sbyte[]
        {
            10,
            11,
            14,
            23,
            7
        };

        // Token: 0x0400113F RID: 4415
        private static readonly PickMobController _Instance = new PickMobController();

        // Token: 0x04001140 RID: 4416
        public static bool IsPickingItems;

        // Token: 0x04001141 RID: 4417
        private static bool IsWait;

        // Token: 0x04001142 RID: 4418
        private static long TimeStartWait;

        // Token: 0x04001143 RID: 4419
        private static long TimeWait;

        // Token: 0x04001144 RID: 4420
        public static List<ItemMap> ItemPicks = new List<ItemMap>();

        // Token: 0x04001145 RID: 4421
        private static int IndexItemPick = 0;

        // Token: 0x020000C9 RID: 201
        private enum TpyePickItem
        {
            // Token: 0x040012CF RID: 4815
            CanNotPickItem,
            // Token: 0x040012D0 RID: 4816
            PickItemNormal,
            // Token: 0x040012D1 RID: 4817
            PickItemTDLT,
            // Token: 0x040012D2 RID: 4818
            PickItemTanSat
        }
    }
}
namespace AssemblyCSharp.Mod.PickMob
{
    // Token: 0x020000B3 RID: 179
    public class Pk9rPickMob
    {
        // Token: 0x06000926 RID: 2342 RVA: 0x0007CA88 File Offset: 0x0007AC88
        public static bool Chat(string text)
        {
            if (text == "add")
            {
                Mob mobFocus = global::Char.myCharz().mobFocus;
                ItemMap itemFocus = global::Char.myCharz().itemFocus;
                if (mobFocus != null)
                {
                    if (Pk9rPickMob.IdMobsTanSat.Contains(mobFocus.mobId))
                    {
                        Pk9rPickMob.IdMobsTanSat.Remove(mobFocus.mobId);
                        GameScr.info1.addInfo("Đã xoá mob: " + mobFocus.mobId.ToString(), 0);
                    }
                    else
                    {
                        Pk9rPickMob.IdMobsTanSat.Add(mobFocus.mobId);
                        GameScr.info1.addInfo("Đã thêm mob: " + mobFocus.mobId.ToString(), 0);
                    }
                }
                else if (itemFocus != null)
                {
                    if (Pk9rPickMob.IdItemPicks.Contains(itemFocus.template.id))
                    {
                        Pk9rPickMob.IdItemPicks.Remove(itemFocus.template.id);
                        GameScr.info1.addInfo(string.Format("Đã xoá khỏi danh sách chỉ tự động nhặt item: {0}[{1}]", itemFocus.template.name, itemFocus.template.id), 0);
                    }
                    else
                    {
                        Pk9rPickMob.IdItemPicks.Add(itemFocus.template.id);
                        GameScr.info1.addInfo(string.Format("Đã thêm vào danh sách chỉ tự động nhặt item: {0}[{1}]", itemFocus.template.name, itemFocus.template.id), 0);
                    }
                }
                else
                {
                    GameScr.info1.addInfo("Cần trỏ vào quái hay vật phẩm cần thêm vào danh sách", 0);
                }
            }
            else if (text == "addd")
            {
                Mob mobFocus2 = global::Char.myCharz().mobFocus;
                ItemMap itemFocus2 = global::Char.myCharz().itemFocus;
                if (mobFocus2 != null)
                {
                    if (Pk9rPickMob.TypeMobsTanSat.Contains(mobFocus2.templateId))
                    {
                        Pk9rPickMob.TypeMobsTanSat.Remove(mobFocus2.templateId);
                        GameScr.info1.addInfo(string.Format("Đã xoá loại mob: {0}[{1}]", mobFocus2.getTemplate().name, mobFocus2.templateId), 0);
                    }
                    else
                    {
                        Pk9rPickMob.TypeMobsTanSat.Add(mobFocus2.templateId);
                        GameScr.info1.addInfo(string.Format("Đã thêm loại mob: {0}[{1}]", mobFocus2.getTemplate().name, mobFocus2.templateId), 0);
                    }
                }
                else if (itemFocus2 != null)
                {
                    if (Pk9rPickMob.TypeItemPicks.Contains(itemFocus2.template.type))
                    {
                        Pk9rPickMob.TypeItemPicks.Remove(itemFocus2.template.type);
                        GameScr.info1.addInfo("Đã xoá khỏi danh sách chỉ tự động nhặt loại item:" + itemFocus2.template.type.ToString(), 0);
                    }
                    else
                    {
                        Pk9rPickMob.TypeItemPicks.Add(itemFocus2.template.type);
                        GameScr.info1.addInfo("Đã thêm vào danh sách chỉ tự động nhặt loại item:" + itemFocus2.template.type.ToString(), 0);
                    }
                }
                else
                {
                    GameScr.info1.addInfo("Cần trỏ vào quái hay vật phẩm cần thêm vào danh sách", 0);
                }
            }
            else if (text == "anhatts")
            {
                Pk9rPickMob.IsAutoPickItems = !Pk9rPickMob.IsAutoPickItems;
                GameScr.info1.addInfo("Auto nhặt của tàn sát: " + (Pk9rPickMob.IsAutoPickItems ? "Bật" : "Tắt"), 0);
            }
            else if (text == "itm")
            {
                Pk9rPickMob.IsItemMe = !Pk9rPickMob.IsItemMe;
                GameScr.info1.addInfo("Lọc không nhặt vật phẩm của người khác: " + (Pk9rPickMob.IsItemMe ? "Bật" : "Tắt"), 0);
            }
            else if (text == "sln")
            {
                Pk9rPickMob.IsLimitTimesPickItem = !Pk9rPickMob.IsLimitTimesPickItem;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Giới hạn số lần nhặt là ");
                stringBuilder.Append(Pk9rPickMob.TimesAutoPickItemMax);
                stringBuilder.Append(Pk9rPickMob.IsLimitTimesPickItem ? ": Bật" : ": Tắt");
                GameScr.info1.addInfo(stringBuilder.ToString(), 0);
            }
            else if (Pk9rPickMob.IsGetInfoChat<int>(text, "sln"))
            {
                Pk9rPickMob.TimesAutoPickItemMax = Pk9rPickMob.GetInfoChat<int>(text, "sln");
                GameScr.info1.addInfo("Số lần nhặt giới hạn là: " + Pk9rPickMob.TimesAutoPickItemMax.ToString(), 0);
            }
            else if (Pk9rPickMob.IsGetInfoChat<short>(text, "addi"))
            {
                short infoChat = Pk9rPickMob.GetInfoChat<short>(text, "addi");
                if (Pk9rPickMob.IdItemPicks.Contains(infoChat))
                {
                    Pk9rPickMob.IdItemPicks.Remove(infoChat);
                    GameScr.info1.addInfo(string.Format("Đã xoá khỏi danh sách chỉ tự động nhặt item: {0}[{1}]", ItemTemplates.get(infoChat).name, infoChat), 0);
                }
                else
                {
                    Pk9rPickMob.IdItemPicks.Add(infoChat);
                    GameScr.info1.addInfo(string.Format("Đã thêm vào danh sách chỉ tự động nhặt item: {0}[{1}]", ItemTemplates.get(infoChat).name, infoChat), 0);
                }
            }
            else if (text == "blocki")
            {
                ItemMap itemFocus3 = global::Char.myCharz().itemFocus;
                if (itemFocus3 != null)
                {
                    if (Pk9rPickMob.IdItemBlocks.Contains(itemFocus3.template.id))
                    {
                        Pk9rPickMob.IdItemBlocks.Remove(itemFocus3.template.id);
                        GameScr.info1.addInfo(string.Format("Đã xoá khỏi danh sách không tự động nhặt item: {0}[{1}]", itemFocus3.template.name, itemFocus3.template.id), 0);
                    }
                    else
                    {
                        Pk9rPickMob.IdItemBlocks.Add(itemFocus3.template.id);
                        GameScr.info1.addInfo(string.Format("Đã thêm vào danh sách không tự động nhặt item: {0}[{1}]", itemFocus3.template.name, itemFocus3.template.id), 0);
                    }
                }
                else
                {
                    GameScr.info1.addInfo("Cần trỏ vào vật phẩm cần chặn khi auto nhặt", 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<short>(text, "blocki"))
            {
                short infoChat2 = Pk9rPickMob.GetInfoChat<short>(text, "blocki");
                if (Pk9rPickMob.IdItemBlocks.Contains(infoChat2))
                {
                    Pk9rPickMob.IdItemBlocks.Remove(infoChat2);
                    GameScr.info1.addInfo(string.Format("Đã thêm vào danh sách không tự động nhặt item: {0}[{1}]", ItemTemplates.get(infoChat2).name, infoChat2), 0);
                }
                else
                {
                    Pk9rPickMob.IdItemBlocks.Add(infoChat2);
                    GameScr.info1.addInfo(string.Format("Đã xoá khỏi danh sách không tự động nhặt item: {0}[{1}]", ItemTemplates.get(infoChat2).name, infoChat2), 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<sbyte>(text, "addti"))
            {
                sbyte infoChat3 = Pk9rPickMob.GetInfoChat<sbyte>(text, "addti");
                if (Pk9rPickMob.TypeItemPicks.Contains(infoChat3))
                {
                    Pk9rPickMob.TypeItemPicks.Remove(infoChat3);
                    GameScr.info1.addInfo("Đã xoá khỏi danh sách chỉ tự động nhặt loại item: " + infoChat3.ToString(), 0);
                }
                else
                {
                    Pk9rPickMob.TypeItemPicks.Add(infoChat3);
                    GameScr.info1.addInfo("Đã thêm vào danh sách chỉ tự động nhặt loại item: " + infoChat3.ToString(), 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<sbyte>(text, "blockti"))
            {
                sbyte infoChat4 = Pk9rPickMob.GetInfoChat<sbyte>(text, "blockti");
                if (Pk9rPickMob.TypeItemBlock.Contains(infoChat4))
                {
                    Pk9rPickMob.TypeItemBlock.Remove(infoChat4);
                    GameScr.info1.addInfo("Đã xoá khỏi danh sách không tự động nhặt loại item: " + infoChat4.ToString(), 0);
                }
                else
                {
                    Pk9rPickMob.TypeItemBlock.Add(infoChat4);
                    GameScr.info1.addInfo("Đã thêm vào danh sách không tự động nhặt loại item: " + infoChat4.ToString(), 0);
                }
            }
            else if (text == "clri")
            {
                Pk9rPickMob.IdItemPicks.Clear();
                Pk9rPickMob.TypeItemPicks.Clear();
                Pk9rPickMob.TypeItemBlock.Clear();
                Pk9rPickMob.IdItemBlocks.Clear();
                Pk9rPickMob.IdItemBlocks.AddRange(Pk9rPickMob.IdItemBlockBase);
                GameScr.info1.addInfo("Danh sách lọc item đã được đặt lại mặc định", 0);
            }
            else if (text == "cnnts")
            {
                Pk9rPickMob.IdItemPicks.Clear();
                Pk9rPickMob.TypeItemPicks.Clear();
                Pk9rPickMob.TypeItemBlock.Clear();
                Pk9rPickMob.IdItemBlocks.Clear();
                Pk9rPickMob.IdItemBlocks.AddRange(Pk9rPickMob.IdItemBlockBase);
                Pk9rPickMob.IdItemPicks.Add(77);
                Pk9rPickMob.IdItemPicks.Add(861);
                GameScr.info1.addInfo("Đã cài đặt chỉ nhặt ngọc (của tàn sát)", 0);
            }
            else if (text == "ts")
            {
                Pk9rPickMob.IsTanSat = !Pk9rPickMob.IsTanSat;
                GameScr.info1.addInfo("Tự động đánh quái: " + (Pk9rPickMob.IsTanSat ? "Bật" : "Tắt"), 0);
            }
            else if (text == "nsq")
            {
                Pk9rPickMob.IsNeSieuQuai = !Pk9rPickMob.IsNeSieuQuai;
                GameScr.info1.addInfo("Tàn sát né siêu quái: " + (Pk9rPickMob.IsNeSieuQuai ? "Bật" : "Tắt"), 0);
            }
            else if (Pk9rPickMob.IsGetInfoChat<int>(text, "addm"))
            {
                int infoChat5 = Pk9rPickMob.GetInfoChat<int>(text, "addm");
                if (Pk9rPickMob.IdMobsTanSat.Contains(infoChat5))
                {
                    Pk9rPickMob.IdMobsTanSat.Remove(infoChat5);
                    GameScr.info1.addInfo("Đã xoá mob: " + infoChat5.ToString(), 0);
                }
                else
                {
                    Pk9rPickMob.IdMobsTanSat.Add(infoChat5);
                    GameScr.info1.addInfo("Đã thêm mob: " + infoChat5.ToString(), 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<int>(text, "addtm"))
            {
                int infoChat6 = Pk9rPickMob.GetInfoChat<int>(text, "addtm");
                if (Pk9rPickMob.TypeMobsTanSat.Contains(infoChat6))
                {
                    Pk9rPickMob.TypeMobsTanSat.Remove(infoChat6);
                    GameScr.info1.addInfo(string.Format("Đã xoá loại mob: {0}[{1}]", Mob.arrMobTemplate[infoChat6].name, infoChat6), 0);
                }
                else
                {
                    Pk9rPickMob.TypeMobsTanSat.Add(infoChat6);
                    GameScr.info1.addInfo(string.Format("Đã thêm loại mob: {0}[{1}]", Mob.arrMobTemplate[infoChat6].name, infoChat6), 0);
                }
            }
            else if (text == "clrm")
            {
                Pk9rPickMob.IdMobsTanSat.Clear();
                Pk9rPickMob.TypeMobsTanSat.Clear();
                GameScr.info1.addInfo("Đã xoá danh sách đánh quái", 0);
            }
            else if (text == "skill")
            {
                SkillTemplate template = global::Char.myCharz().myskill.template;
                if (Pk9rPickMob.IdSkillsTanSat.Contains(template.id))
                {
                    Pk9rPickMob.IdSkillsTanSat.Remove(template.id);
                    GameScr.info1.addInfo(string.Format("Đã xoá khỏi danh sách skill sử dụng tự động đánh quái skill: {0}[{1}]", template.name, template.id), 0);
                }
                else
                {
                    Pk9rPickMob.IdSkillsTanSat.Add(template.id);
                    GameScr.info1.addInfo(string.Format("Đã thêm vào danh sách skill sử dụng tự động đánh quái skill: {0}[{1}]", template.name, template.id), 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<int>(text, "skill"))
            {
                int num = Pk9rPickMob.GetInfoChat<int>(text, "skill") - 1;
                SkillTemplate skillTemplate = global::Char.myCharz().nClass.skillTemplates[num];
                if (Pk9rPickMob.IdSkillsTanSat.Contains(skillTemplate.id))
                {
                    Pk9rPickMob.IdSkillsTanSat.Remove(skillTemplate.id);
                    GameScr.info1.addInfo(string.Format("Đã xoá khỏi danh sách skill sử dụng tự động đánh quái skill: {0}[{1}]", skillTemplate.name, skillTemplate.id), 0);
                }
                else
                {
                    Pk9rPickMob.IdSkillsTanSat.Add(skillTemplate.id);
                    GameScr.info1.addInfo(string.Format("Đã thêm vào danh sách skill sử dụng tự động đánh quái skill: {0}[{1}]", skillTemplate.name, skillTemplate.id), 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<sbyte>(text, "skillid"))
            {
                sbyte infoChat7 = Pk9rPickMob.GetInfoChat<sbyte>(text, "skillid");
                if (Pk9rPickMob.IdSkillsTanSat.Contains(infoChat7))
                {
                    Pk9rPickMob.IdSkillsTanSat.Remove(infoChat7);
                    GameScr.info1.addInfo("Đã xoá khỏi danh sách skill sử dụng tự động đánh quái skill: " + infoChat7.ToString(), 0);
                }
                else
                {
                    Pk9rPickMob.IdSkillsTanSat.Add(infoChat7);
                    GameScr.info1.addInfo("Đã thêm vào danh sách skill sử dụng tự động đánh quái skill: " + infoChat7.ToString(), 0);
                }
            }
            else if (text == "clrs")
            {
                Pk9rPickMob.IdSkillsTanSat.Clear();
                Pk9rPickMob.IdSkillsTanSat.AddRange(Pk9rPickMob.IdSkillsBase);
                GameScr.info1.addInfo("Đã đặt danh sách skill sử dụng tự động đánh quái về mặc định", 0);
            }
            else if (text == "abfts")
            {
                if (Pk9rPickMob.HpBuff == 0 && Pk9rPickMob.MpBuff == 0)
                {
                    GameScr.info1.addInfo("Tự động sử dụng đậu thần: Tắt", 0);
                }
                else
                {
                    Pk9rPickMob.HpBuff = 20;
                    Pk9rPickMob.MpBuff = 20;
                    GameScr.info1.addInfo(string.Format("Tự động sử dụng đậu thần khi HP dưới {0}%, MP dưới {1}%", Pk9rPickMob.HpBuff, Pk9rPickMob.MpBuff), 0);
                }
            }
            else if (Pk9rPickMob.IsGetInfoChat<int>(text, "abfts"))
            {
                Pk9rPickMob.HpBuff = Pk9rPickMob.GetInfoChat<int>(text, "abf");
                Pk9rPickMob.MpBuff = 0;
                GameScr.info1.addInfo(string.Format("Tự động sử dụng đậu thần khi HP dưới {0}%", Pk9rPickMob.HpBuff), 0);
            }
            else if (Pk9rPickMob.IsGetInfoChat<int>(text, "abfts", 2))
            {
                int[] infoChat8 = Pk9rPickMob.GetInfoChat<int>(text, "abfts", 2);
                Pk9rPickMob.HpBuff = infoChat8[0];
                Pk9rPickMob.MpBuff = infoChat8[1];
                GameScr.info1.addInfo(string.Format("Tự động sử dụng đậu thần khi HP dưới {0}%, MP dưới {1}%", Pk9rPickMob.HpBuff, Pk9rPickMob.MpBuff), 0);
            }
            else
            {
                if (!(text == "vdhts"))
                {
                    return false;
                }
                Pk9rPickMob.IsVuotDiaHinh = !Pk9rPickMob.IsVuotDiaHinh;
                GameScr.info1.addInfo("Tự động đánh quái vượt địa hình: " + (Pk9rPickMob.IsVuotDiaHinh ? "Bật" : "Tắt"), 0);
            }
            return true;
        }

        // Token: 0x06000927 RID: 2343 RVA: 0x0007D810 File Offset: 0x0007BA10
        public static bool HotKeys()
        {
            int keyAsciiPress = GameCanvas.keyAsciiPress;
            if (keyAsciiPress <= 98)
            {
                if (keyAsciiPress == 97)
                {
                    Pk9rPickMob.Chat("add");
                    return true;
                }
                if (keyAsciiPress == 98)
                {
                    Pk9rPickMob.Chat("abf");
                    return true;
                }
            }
            else
            {
                if (keyAsciiPress == 110)
                {
                    Pk9rPickMob.Chat("anhat");
                    return true;
                }
                if (keyAsciiPress == 116)
                {
                    Pk9rPickMob.Chat("ts");
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06000928 RID: 2344 RVA: 0x0007D875 File Offset: 0x0007BA75
        public static void Update()
        {
            PickMobController.Update();
        }

        // Token: 0x06000929 RID: 2345 RVA: 0x0007D87C File Offset: 0x0007BA7C
        public static void MobStartDie(object obj)
        {
            Mob mob = (Mob)obj;
            if (mob.status != 1 && mob.status != 0)
            {
                mob.timeLastDie = mSystem.currentTimeMillis();
                mob.countDie++;
                if (mob.countDie > 10)
                {
                    mob.countDie = 0;
                }
            }
        }

        // Token: 0x0600092A RID: 2346 RVA: 0x0007D8CB File Offset: 0x0007BACB
        public static void UpdateCountDieMob(Mob mob)
        {
            if (mob.levelBoss != 0)
            {
                mob.countDie = 0;
            }
        }

        // Token: 0x0600092B RID: 2347 RVA: 0x0007D8DC File Offset: 0x0007BADC
        private static bool IsGetInfoChat<T>(string text, string s)
        {
            if (!text.StartsWith(s))
            {
                return false;
            }
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

        // Token: 0x0600092C RID: 2348 RVA: 0x0007D92C File Offset: 0x0007BB2C
        private static T GetInfoChat<T>(string text, string s)
        {
            return (T)((object)Convert.ChangeType(text.Substring(s.Length), typeof(T)));
        }

        // Token: 0x0600092D RID: 2349 RVA: 0x0007D950 File Offset: 0x0007BB50
        private static bool IsGetInfoChat<T>(string text, string s, int n)
        {
            if (!text.StartsWith(s))
            {
                return false;
            }
            try
            {
                string[] array = text.Substring(s.Length).Split(new char[]
                {
                    ' '
                });
                for (int i = 0; i < n; i++)
                {
                    Convert.ChangeType(array[i], typeof(T));
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Token: 0x0600092E RID: 2350 RVA: 0x0007D9C0 File Offset: 0x0007BBC0
        private static T[] GetInfoChat<T>(string text, string s, int n)
        {
            T[] array = new T[n];
            string[] array2 = text.Substring(s.Length).Split(new char[]
            {
                ' '
            });
            for (int i = 0; i < n; i++)
            {
                array[i] = (T)((object)Convert.ChangeType(array2[i], typeof(T)));
            }
            return array;
        }

        // Token: 0x04001146 RID: 4422
        private const int ID_ITEM_GEM = 77;

        // Token: 0x04001147 RID: 4423
        private const int ID_ITEM_GEM_LOCK = 861;

        // Token: 0x04001148 RID: 4424
        private const int DEFAULT_HP_BUFF = 20;

        // Token: 0x04001149 RID: 4425
        private const int DEFAULT_MP_BUFF = 20;

        // Token: 0x0400114A RID: 4426
        private static readonly sbyte[] IdSkillsBase = new sbyte[]
        {
            0,
            2,
            17,
            12,
            4,
            13
        };

        // Token: 0x0400114B RID: 4427
        public static readonly short[] IdItemBlockBase = new short[]
        {
            225,
            353,
            354,
            355,
            356,
            357,
            358,
            359,
            360,
            362
        };

        // Token: 0x0400114C RID: 4428
        public static bool IsTanSat = false;

        // Token: 0x0400114D RID: 4429
        public static bool IsNeSieuQuai = false;

        // Token: 0x0400114E RID: 4430
        public static bool IsVuotDiaHinh = true;

        // Token: 0x0400114F RID: 4431
        public static List<int> IdMobsTanSat = new List<int>();

        // Token: 0x04001150 RID: 4432
        public static List<int> TypeMobsTanSat = new List<int>();

        // Token: 0x04001151 RID: 4433
        public static List<sbyte> IdSkillsTanSat = new List<sbyte>(Pk9rPickMob.IdSkillsBase);

        // Token: 0x04001152 RID: 4434
        public static bool IsAutoPickItems = false;

        // Token: 0x04001153 RID: 4435
        public static bool IsItemMe = true;

        // Token: 0x04001154 RID: 4436
        public static bool IsLimitTimesPickItem = true;

        // Token: 0x04001155 RID: 4437
        public static int TimesAutoPickItemMax = 7;

        // Token: 0x04001156 RID: 4438
        public static List<short> IdItemPicks = new List<short>();

        // Token: 0x04001157 RID: 4439
        public static List<short> IdItemBlocks = new List<short>(Pk9rPickMob.IdItemBlockBase);

        // Token: 0x04001158 RID: 4440
        public static List<sbyte> TypeItemPicks = new List<sbyte>();

        // Token: 0x04001159 RID: 4441
        public static List<sbyte> TypeItemBlock = new List<sbyte>();

        // Token: 0x0400115A RID: 4442
        public static int HpBuff = 0;

        // Token: 0x0400115B RID: 4443
        public static int MpBuff = 0;
    }
}