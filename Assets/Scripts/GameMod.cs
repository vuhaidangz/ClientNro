using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using UnityEngine;
using AssemblyCSharp.Mod.PickMob;
using AssemblyCSharp.Mod.Xmap;
using UnityEngine.UIElements;

internal class GameMod
{
    public static bool isVaoKhu = false;

    public static bool nvat2 = true;

    public static Char[] chars2 = new Char[50];

    public static bool isAutoNhatXa = false;

    static int xNhatXa;

    static int yNhatXa;

    static long currNhatXa;

    static bool isAK = false;

    public static bool isAutoBT = false;

    static int timeBT = 2;

    static long currAutoBT;

    public static sbyte petStatus;

    public static bool autoHoiSinh = true;

    public static bool isGMT;

    public static Char charMT;

    public static bool xoamap = false;

    public static bool XoaBackground = false;

    static string backgroundColor = "0.6 0.8 0.9";

    static bool isBossM = false;

    public static bool isPKM = false;

    public static bool trangThai = true;

    public static bool dichChuyenPem = true;

    static string ListMap = "Làng Aru,Đồi hoa cúc,Thung lũng tre,Rừng nấm,Rừng xương,Đảo Kamê,Đông Karin,Làng Mori,Đồi nấm tím,Thị trấn Moori,Thung lũng Namếc,Thung lũng Maima,Vực maima,Đảo Guru,Làng Kakarot,Đồi hoang,Làng Plant,Rừng nguyên sinh,Rừng thông Xayda,Thành phố Vegeta,Vách núi đen,Nhà Gôhan,Nhà Moori,Nhà Broly,Trạm tàu vũ trụ,Trạm tàu vũ trụ,Trạm tàu vũ trụ,Rừng Bamboo,Rừng dương xỉ,Nam Kamê,Đảo Bulông,Núi hoa vàng,Núi hoa tím,Nam Guru,Đông Nam Guru,Rừng cọ,Rừng đá,Thung lũng đen,Bờ vực đen,Vách núi Aru,Vách núi Moori,Vực Plant,Vách núi Aru,Vách núi Moori,Vách núi Kakarot,Thần điện,Tháp Karin,Rừng Karin,Hành tinh Kaio,Phòng tập thời gian,Thánh địa Kaio,Đấu trường,Đại hội võ thuật,Tường thành 1,Tầng 3,Tầng 1,Tầng 2,Tầng 4,Tường thành 2,Tường thành 3,Trại độc nhãn 1,Trại độc nhãn 2,Trại độc nhãn 3,Trại lính Fide,Núi dây leo,Núi cây quỷ,Trại qủy già,Vực chết,Thung lũng Nappa,Vực cấm,Núi Appule,Căn cứ Raspberry,Thung lũng Raspberry,Thung lũng chết,Đồi cây Fide,Khe núi tử thần,Núi đá,Rừng đá,Lãnh  địa Fize,Núi khỉ đỏ,Núi khỉ vàng,Hang quỷ chim,Núi khỉ đen,Hang khỉ đen,Siêu Thị,Hành tinh M-2,Hành tinh Polaris,Hành tinh Cretaceous,Hành tinh Monmaasu,Hành tinh Rudeeze,Hành tinh Gelbo,Hành tinh Tigere,Thành phố phía đông,Thành phố phía nam,Đảo Balê,95,Cao nguyên,Thành phố phía bắc,Ngọn núi phía bắc,Thung lũng phía bắc,Thị trấn Ginder,101,Nhà Bunma,Võ đài Xên bọ hung,Sân sau siêu thị,Cánh đồng tuyết,Rừng tuyết,Núi tuyết,Dòng sông băng,Rừng băng,Hang băng,Đông Nam Karin,Võ đài Hạt Mít,Đại hội võ thuật,Cổng phi thuyền,Phòng chờ,Thánh địa Kaio,Cửa Ải 1,Cửa Ải 2,Cửa Ải 3,Phòng chỉ huy,Đấu trường,Ngũ Hành Sơn,Ngũ Hành Sơn,Ngũ Hành Sơn,Võ đài Bang,Thành phố Santa,Cổng phi thuyền,Bụng Mabư,Đại hội võ thuật,Đại hội võ thuật Vũ Trụ,Hành Tinh Yardart,Hành Tinh Yardart 2,Hành Tinh Yardart 3,Đại hội võ thuật Vũ Trụ 6-7,Động hải tặc,Hang Bạch Tuộc,Động kho báu,Cảng hải tặc,Hành tinh Potaufeu,Hang động Potaufeu,Con đường rắn độc,Con đường rắn độc,Con đường rắn độc,Hoang mạc,Võ Đài Siêu Cấp,Tây Karin,Sa mạc,Lâu đài Lychee,Thành phố Santa,Lôi Đài,Hành tinh bóng tối,Vùng đất băng giá,Lãnh địa bang hội,Hành tinh Bill,Hành tinh ngục tù,Tây thánh địa,Đông thánh Địa,Bắc thánh địa,Nam thánh Địa,Khu hang động,Bìa rừng nguyên thủy,Rừng nguyên thủy,Làng Plant nguyên thủy,Tranh ngọc Namếc";

    public static string[] MapNames = ListMap.Split(',');

    public static bool thongBaoBoss = true;

    public static MyVector bossVip = new MyVector();

    public static bool lineboss = true;

    public static int ghimX;

    public static int ghimY;

    public static bool isKhoaViTri = false;

    public static bool xoaHieuUngHopThe = true;

    public static bool isThongTinDeTu = false;

    public static bool isThongTinSuPhu = false;

    public static bool isKSBoss = false;

    public static int HPKSBoss;

    public static bool isKSBossBangSkill5 = false;

    public static int ngocHienTai;

    public static bool hoiSinhNgoc = false;

    public static int ngocDuocDungDeHoiSinh;

    public static bool updateKhu = true;

    static long currUpdateKhu;

    public static bool ModChat(string text)
    {
        if (text.StartsWith("speed_"))
        {
            Time.timeScale = float.Parse(text.Remove(0, 6));
            Char.myCharz().addInfo("Tốc Độ Game: " + Time.timeScale);
            return true;
        }
        if (text.StartsWith("tdc_"))
        {
            Char.myCharz().cspeed = int.Parse(text.Replace("tdc_", ""));
            Char.myCharz().addInfo("Tốc Độ Chạy: " + Char.myCharz().cspeed);
            return true;
        }
        if (text.StartsWith("kx_"))
        {
            StartVaoKhu(int.Parse(text.Replace("kx_", "")), TileMap.zoneID, TileMap.mapID);
            return true;
        }
        if (text.StartsWith("k_"))
        {
            Service.gI().requestChangeZone(int.Parse(text.Replace("k_", "")), -1);
            return true;
        }
        if (text == "showhp")
        {
            nvat2 = !nvat2;
            Char.myCharz().addInfo("Thông Tin Nhân Vật: " + (nvat2 ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "anz")
        {
            isAutoNhatXa = !isAutoNhatXa;
            if (isAutoNhatXa)
            {
                xNhatXa = Char.myCharz().cx;
                yNhatXa = Char.myCharz().cy;
                Char.myCharz().addInfo("Tọa Độ : " + Char.myCharz().cx + "|" + Char.myCharz().cy);
            }
            Char.myCharz().addInfo("Auto Nhặt Xa: " + (isAutoNhatXa ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "ak")
        {
            isAK = !isAK;
            Char.myCharz().addInfo("Tự Động Đánh: " + (isAK ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "abt")
        {
            isAutoBT = !isAutoBT;
            Char.myCharz().addInfo("Auto Bông Tai: " + (isAutoBT ? "Bật" : "Tắt"));
            return true;
        }
        if (text.StartsWith("bt_"))
        {
            timeBT = int.Parse(text.Replace("bt_", ""));
            Char.myCharz().addInfo("Delay Auto Bông Tai: " + timeBT + "s");
            return true;
        }
        if (text == "gmt")
        {
            isGMT = false;
            return true;
        }
        if (text.StartsWith("gmt_"))
        {
            int num2 = int.Parse(text.Remove(0, 4));
            if (num2 < GameScr.vCharInMap.size())
            {
                isGMT = true;
                charMT = (Char)GameScr.vCharInMap.elementAt(num2);
            }
            return true;
        }
        if (text == "xoamap")
        {
            xoamap = !xoamap;
            Char.myCharz().addInfo("Xóa Map: " + (xoamap ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "xbg")
        {
            XoaBackground = !XoaBackground;
            Char.myCharz().addInfo("Xóa Background: " + (XoaBackground ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "bossm")
        {
            isBossM = !isBossM;
            isPKM = false;
            trangThai = false;
            Char.myCharz().addInfo("Boss Trong Khu: " + (isBossM ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "pkm")
        {
            isPKM = !isPKM;
            isBossM = false;
            trangThai = false;
            Char.myCharz().addInfo("Địch Trong Khu: " + (isPKM ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "ttnv")
        {
            isBossM = false;
            isPKM = false;
            trangThai = !trangThai;
            Char.myCharz().addInfo("Trạng Thái Nhân Vật Đang Trỏ: " + (trangThai ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "pem1hp")
        {
            isPemMob1HP = !isPemMob1HP;
            Char.myCharz().addInfo("Auto Pem Quái Xuống 1 HP: " + (isPemMob1HP ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "tlq")
        {
            dichChuyenPem = !dichChuyenPem;
            Char.myCharz().addInfo("Tele Quái: " + (dichChuyenPem ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "sb")
        {
            thongBaoBoss = !thongBaoBoss;
            Char.myCharz().addInfo("Thông Báo Boss: " + (thongBaoBoss ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "line")
        {
            lineboss = !lineboss;
            Char.myCharz().addInfo("Chỉ Boss: " + (lineboss ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "kvt")
        {
            ghimX = Char.myCharz().cx;
            ghimY = Char.myCharz().cy;
            isKhoaViTri = !isKhoaViTri;
            Char.myCharz().addInfo("Khóa vị trí: " + (isKhoaViTri ? "Bật" : "Tắt"));
            return true;
        }
        if (text.StartsWith("l "))
        {
            Char.myCharz().cx -= int.Parse(text.Replace("l ", ""));
            Service.gI().charMove();
            Char.myCharz().addInfo("Dịch trái " + int.Parse(text.Replace("l ", "")));
            return true;
        }
        if (text.StartsWith("r "))
        {
            Char.myCharz().cx += int.Parse(text.Replace("r ", ""));
            Service.gI().charMove();
            Char.myCharz().addInfo("Dịch phải " + int.Parse(text.Replace("r ", "")));
            return true;
        }
        if (text.StartsWith("u "))
        {
            Char.myCharz().cy -= int.Parse(text.Replace("u ", ""));
            Service.gI().charMove();
            Char.myCharz().addInfo("Khinh công " + int.Parse(text.Replace("u ", "")));
            return true;
        }
        if (text.StartsWith("d "))
        {
            Char.myCharz().cy += int.Parse(text.Replace("d ", ""));
            Service.gI().charMove();
            Char.myCharz().addInfo("Đi vào lòng đất " + int.Parse(text.Replace("d ", "")));
            return true;
        }
        if (text == "xht")
        {
            xoaHieuUngHopThe = !xoaHieuUngHopThe;
            Char.myCharz().addInfo("Hiệu ứng hợp thể: " + (!xoaHieuUngHopThe ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "ttsp")
        {
            isThongTinSuPhu = !isThongTinSuPhu;
            Char.myCharz().addInfo("Thông Tin Sư Phụ: " + (isThongTinSuPhu ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "ttdt")
        {
            isThongTinDeTu = !isThongTinDeTu;
            Char.myCharz().addInfo("Thông Tin Đệ Tử: " + (isThongTinDeTu ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "ksbs5")
        {
            isKSBoss = false;
            isKSBossBangSkill5 = !isKSBossBangSkill5;
            Char.myCharz().addInfo((isKSBossBangSkill5 ? "KS Boss Bằng Skill 5: Bật" : "KS Boss Bằng Skill 5: Tắt") ?? "");
            return true;
        }
        if (text == "ksb")
        {
            isKSBossBangSkill5 = false;
            isKSBoss = !isKSBoss;
            Char.myCharz().addInfo((isKSBoss ? "KS Boss bằng đấm thường: Bật" : "KS Boss bằng đấm thường: Tắt") ?? "");
            return true;
        }
        if (text.StartsWith("hpboss_"))
        {
            HPKSBoss = int.Parse(text.Replace("hpboss_", ""));
            Char.myCharz().addInfo("HP Boss khi đạt " + NinjaUtil.getMoneys(HPKSBoss) + " sẽ oánh bỏ con mẹ boss");
            return true;
        }
        if (text == "ahs")
        {
            hoiSinhNgoc = !hoiSinhNgoc;
            Char.myCharz().addInfo((hoiSinhNgoc ? "Auto hồi sinh bằng số ngọc được chỉ định: Bật" : "Auto hồi sinh bằng số ngọc được chỉ định: Tắt") ?? "");
            return true;
        }
        if (text.StartsWith("ngochs_"))
        {
            ngocHienTai = Char.myCharz().luongKhoa + Char.myCharz().luong;
            ngocDuocDungDeHoiSinh = int.Parse(text.Replace("ngochs_", ""));
            Char.myCharz().addInfo("Ngọc được sử dụng để hồi sinh là " + ngocDuocDungDeHoiSinh);
            return true;
        }
        if (text == "tgt")
        {
            updateKhu = !updateKhu;
            Char.myCharz().addInfo("Update khu: " + (!updateKhu ? "Tắt" : "Bật"));
            return true;
        }
        if (text == "nmtr")
        {
            if (getX(3) > 0 && getY(3) > 0)
            {
                GotoXY(getX(3), getY(3));
            }
            return true;
        }
        if (text == "nmt")
        {
            if (getX(0) > 0 && getY(0) > 0)
            {
                GotoXY(getX(0), getY(0));
            }
            else
                GotoXY(30, PickMobController.GetYsd(30));
            return true;
        }
        if (text == "nmg")
        {
            if (getX(1) > 0 && getY(1) > 0)
            {
                GotoXY(getX(1), getY(1));
                Service.gI().requestChangeMap();
            }
            else
                GotoXY(TileMap.pxw / 2, PickMobController.GetYsd(TileMap.pxw / 2));
            return true;
        }
        if (text == "nmp")
        {
            if (getX(2) > 0 && getY(2) > 0)
            {
                GotoXY(getX(2), getY(2));
            }
            else
                GotoXY(TileMap.pxw - 30, PickMobController.GetYsd(TileMap.pxw - 30));
            return true;
        }
        if (text == "dapdo")
        {
            isDapDo = !isDapDo;
            Char.myCharz().addInfo("Đập đồ: " + (isDapDo ? "Bật" : "Tắt"));
            return true;
        }
        if (text == "mont")
        {
            isNoitai = !isNoitai;
            Char.myCharz().addInfo("Auto mở nội tại : " + (isNoitai ? "Bật" : "Tắt"));
            return true;
        }
        if (text.StartsWith("td_"))
        {
            int type = int.Parse(text.Replace("td_", ""));
            if (type < 1 && type > 3)
            {
                Char.myCharz().addInfo("Không hợp lệ, vui lòng chọn loại muốn quay từ 1-3");
                return true;
            }
            isThuongDe = !isThuongDe;
            Char.myCharz().addInfo("Auto vòng quay thượng đế bằng " + TypeThuongDe() + ": " + (isThuongDe ? "Bật" : "Tắt"));
            typeThuongDe = (sbyte)(type - 1);
            return true;
        }
        return false;
    }

    public static void update()
    {
        AutoNhatXa();
        if (isAK)
            Ak();
        AutoBT();
        AutoHoiSinh();
        GMT();
        khoaViTri();
        KSBoss();
        KSBossBangSkill5();
        AutoDapDo();
        VaoKhu();
        AutoThuongDe();
        if (isNoitai)
        {
            ntNow = int.Parse(CutString(Panel.specialInfo.Substring(0, Panel.specialInfo.IndexOf('%')).LastIndexOf(' ') + 1, Panel.specialInfo.IndexOf('%'), Panel.specialInfo));
        }
        AutoNoiTai();
        if (isDapDo && doDeDap != null)
        {
            saoHienTai = soSao(findItemBagWithIndexUI(doDeDap.indexUI));
        }
        else
        {
            saoHienTai = -1;
        }
        if (hoiSinhNgoc && mSystem.currentTimeMillis() - currHoiSinh >= 1000L)
        {
            HoiSinhTheoNgocChiDinh();
            currHoiSinh = mSystem.currentTimeMillis();
        }
        if (updateKhu && mSystem.currentTimeMillis() - currUpdateKhu >= 500L && !TileMap.isOfflineMap() && !isMapOffline(TileMap.mapID))
        {
            Service.gI().openUIZone();
            currUpdateKhu = mSystem.currentTimeMillis();
        }
        if (!isPKM || isGMT || (Char.myCharz().charFocus != null && (Char.myCharz().charFocus == null || Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus))))
        {
            return;
        }
        else
        {
            for (int l = 0; l < GameScr.vCharInMap.size(); l++)
            {
                Char char2 = (Char)GameScr.vCharInMap.elementAt(l);
                if (char2 != null && Char.myCharz().isMeCanAttackOtherPlayer(char2) && !char2.isPet && !char2.isMiniPet && !char2.cName.StartsWith("$") && !char2.cName.StartsWith("#") && char2.charID >= 0)
                {
                    Char.myCharz().focusManualTo(char2);
                    break;
                }
            }
        }
    }

    public static void Paint(mGraphics g)
    {
        if (nvat2)
        {
            int num6 = 95;
            for (int i = 0; i < chars2.Length; i++)
            {
                chars2[i] = null;
            }
            for (int num7 = 0; num7 < GameScr.vCharInMap.size(); num7++)
            {
                Char char7 = (Char)GameScr.vCharInMap.elementAt(num7);
                if (char7 != null && !char7.cName.Contains("Đệ") && (char7.charID > 0 || char7.cTypePk == 5) && !string.IsNullOrEmpty(char7.cName))
                {
                    g.fillRect(GameCanvas.w - 155, num6, 150, 10, 2721889, 90);
                    if (char7 == Char.myCharz().charFocus && char7.cTypePk != 5)
                    {
                        mFont.tahoma_7b_red.drawString(g, num7 + "." + char7.cName + "[ " + NinjaUtil.getMoneys(char7.cHP).ToString() + " ] [ " + hanhTinhNhanVat(char7) + " ]", GameCanvas.w - 150, num6, mFont.LEFT);
                    }
                    else if (char7 == Char.myCharz().charFocus)
                    {
                        mFont.tahoma_7b_red.drawString(g, num7 + "." + char7.cName + "[ " + NinjaUtil.getMoneys(char7.cHP).ToString() + " ] [ " + hanhTinhNhanVat(char7) + " ]", GameCanvas.w - 150, num6, mFont.LEFT);
                    }
                    else if (char7.cTypePk == 5 || (char7.charID < 0 && char7.charID > -1000 && char7.charID != -114))
                    {
                        mFont.tahoma_7b_yellowSmall.drawString(g, num7 + "." + char7.cName + "[ " + NinjaUtil.getMoneys(char7.cHP).ToString() + " ] [ " + hanhTinhNhanVat(char7) + " ]", GameCanvas.w - 150, num6, mFont.LEFT);
                    }
                    else if (char7.charID > 0 && char7.clanID == Char.myCharz().clanID)
                    {
                        mFont.tahoma_7_blue1.drawString(g, num7 + "." + char7.cName + "[ " + NinjaUtil.getMoneys(char7.cHP).ToString() + " ] [ " + hanhTinhNhanVat(char7) + " ]", GameCanvas.w - 150, num6, mFont.LEFT);
                    }
                    else if (char7.charID > 0)
                    {
                        mFont.tahoma_7.drawString(g, num7 + "." + char7.cName + "[ " + NinjaUtil.getMoneys(char7.cHP).ToString() + " ] [ " + hanhTinhNhanVat(char7) + " ]", GameCanvas.w - 150, num6, mFont.LEFT);
                    }
                    chars2[num7] = char7;
                    num6 += 10;
                }
            }
        }
        if (isBossM)
        {
            mFont.tahoma_7b_unfocus.drawString(g, "Boss :", GameCanvas.w / 2, 72, mFont.CENTER);
            int num2 = 82;
            for (int j = 0; j < GameScr.vCharInMap.size(); j++)
            {
                Char @char = (Char)GameScr.vCharInMap.elementAt(j);
                if (@char != null && (@char.cTypePk == 5 || (@char.charID < 0 && @char.charID > -1000 && @char.charID != -114)) && !@char.isMiniPet)
                {
                    mFont.tahoma_7b_red.drawString(g, j + " - " + (@char.isPet ? "$" : "") + (@char.isMiniPet ? "#" : "") + @char.cName + "[ " + NinjaUtil.getMoneys(@char.cHP).ToString() + " / " + NinjaUtil.getMoneys(@char.cHPFull).ToString() + " ]" + " [ " + hanhTinhNhanVat(@char) + " ]", GameCanvas.w / 2, num2, mFont.CENTER);
                    num2 += 10;
                }
            }
        }
        if (isPKM)
        {
            mFont.tahoma_7b_unfocus.drawString(g, "Địch :", GameCanvas.w / 2, 72, mFont.CENTER);
            int num3 = 82;
            Char char2 = null;
            for (int k = 0; k < GameScr.vCharInMap.size(); k++)
            {
                Char char3 = (Char)GameScr.vCharInMap.elementAt(k);
                if (char3 != null && Char.myCharz().isMeCanAttackOtherPlayer(char3))
                {
                    if (Char.myCharz().charFocus != null && Char.myCharz().charFocus == char3)
                    {
                        char2 = char3;
                    }
                    g.setColor(Color.red);
                    g.drawLine(Char.myCharz().cx - GameScr.cmx, Char.myCharz().cy - GameScr.cmy, char3.cx - GameScr.cmx, char3.cy - GameScr.cmy);
                    mFont.tahoma_7b_red.drawString(g, k + " - " + (char3.isPet ? "$" : "") + (char3.isMiniPet ? "#" : "") + char3.cName + "[" + NinjaUtil.getMoneys(char3.cHP).ToString() + " / " + NinjaUtil.getMoneys(char3.cHPFull).ToString() + " ]" + " [ " + hanhTinhNhanVat(char3) + " ]", GameCanvas.w / 2, num3, mFont.CENTER);
                    num3 += 10;
                }
            }
            if (char2 != null)
            {
                g.setColor(Color.green);
                g.drawLine(Char.myCharz().cx - GameScr.cmx, Char.myCharz().cy - GameScr.cmy, char2.cx - GameScr.cmx, char2.cy - GameScr.cmy);
            }
        }
        if (trangThai)
        {
            for (int i = 0; i < GameScr.vCharInMap.size(); i++)
            {
                int num = 72;
                global::Char @char = (global::Char)GameScr.vCharInMap.elementAt(i);
                if (@char != null && @char == global::Char.myCharz().charFocus)
                {
                    mFont.tahoma_7b_red.drawString(g, string.Concat(new object[]
                    {
                        @char.cName,
                        " [",
                        NinjaUtil.getMoneys((long)@char.cHP),
                        " / ",
                        NinjaUtil.getMoneys((long)@char.cHPFull),
                        "] [",
                        hanhTinhNhanVat(@char),
                        "]"
                    }), GameCanvas.w / 2, num, mFont.CENTER);
                    num += 10;
                    if (@char.protectEff)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Đang khiên: " + @char.timeProtectEff.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.isMonkey == 1)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Đang biến khỉ: " + @char.timeMonkey.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.sleepEff)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Bị thôi miên: " + @char.timeSleep.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.holdEffID != 0)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Bị trói: " + @char.timeBiTroi.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.isFreez)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Bị TDHS: " + @char.freezSeconds.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.blindEff)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Bị choáng: " + @char.timeBlind.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.timeHuytSao > 0)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Có huýt sáo: " + @char.timeHuytSao.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                    if (@char.isNRD)
                    {
                        mFont.tahoma_7b_red.drawString(g, "Ôm NRD còn: " + @char.timeNRD.ToString(), GameCanvas.w / 2, num, mFont.CENTER);
                        num += 10;
                    }
                }
            }
        }
        if (thongBaoBoss)
        {
            int num = 35;
            for (int i = 0; i < bossVip.size(); i++)
            {
                g.setColor(2721889, 0.5f);
                g.fillRect(GameCanvas.w - 23, num + 2, 25, 9);
                ((ShowBoss)bossVip.elementAt(i)).paintBoss(g, GameCanvas.w - 2, num, mFont.RIGHT);
                num += 10;
            }
        }
        if (lineboss)
        {
            for (int l = 0; l < GameScr.vCharInMap.size(); l++)
            {
                Char char4 = (Char)GameScr.vCharInMap.elementAt(l);
                if (char4 != null && char4 != null && char4.cTypePk == 5)
                {
                    if (Char.myCharz().charFocus == char4)
                    {
                        g.setColor(Color.green);
                        g.drawLine(Char.myCharz().cx - GameScr.cmx, Char.myCharz().cy - GameScr.cmy, char4.cx - GameScr.cmx, char4.cy - GameScr.cmy);

                    }
                    else
                    {
                        g.setColor(Color.red);
                        g.drawLine(Char.myCharz().cx - GameScr.cmx, Char.myCharz().cy - GameScr.cmy, char4.cx - GameScr.cmx, char4.cy - GameScr.cmy);
                    }
                }
            }
        }
        int thongTin = GameCanvas.w / 4;
        if (isThongTinSuPhu)
        {
            mFont.tahoma_7b_red.drawString(g, "Sư Phụ :", thongTin, GameCanvas.h - 110, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "Sức Mạnh : " + NinjaUtil.getMoneys(Char.myCharz().cPower), thongTin, GameCanvas.h - 100, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "Tiềm Năng : " + NinjaUtil.getMoneys(Char.myCharz().cTiemNang), thongTin, GameCanvas.h - 90, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "Sức Đánh : " + NinjaUtil.getMoneys(Char.myCharz().cDamFull) + "  Giáp : " + Char.myCharz().cDefull, thongTin, GameCanvas.h - 80, mFont.LEFT);
            thongTin += GameCanvas.w / 4;
        }
        if (isThongTinDeTu)
        {
            mFont.tahoma_7b_red.drawString(g, "Đệ Tử :", thongTin, GameCanvas.h - 110, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "Sức Mạnh : " + NinjaUtil.getMoneys(Char.myPetz().cPower), thongTin, GameCanvas.h - 100, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "Tiềm Năng : " + NinjaUtil.getMoneys(Char.myPetz().cTiemNang), thongTin, GameCanvas.h - 90, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "Sức Đánh : " + NinjaUtil.getMoneys(Char.myPetz().cDamFull) + "  Giáp : " + Char.myPetz().cDefull, thongTin, GameCanvas.h - 80, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "HP : " + NinjaUtil.getMoneys(Char.myPetz().cHP), thongTin, GameCanvas.h - 70, mFont.LEFT);
            mFont.tahoma_7b_yellowSmall2.drawString(g, "MP : " + NinjaUtil.getMoneys(Char.myPetz().cMP), thongTin, GameCanvas.h - 60, mFont.LEFT);
            thongTin += GameCanvas.w / 4;
        }
        if (isDapDo )
        {
            mFont.tahoma_7b_red.drawString(g, "Ngọc Xanh : " + NinjaUtil.getMoneys(Char.myCharz().luong) + " Ngọc Hồng : " + NinjaUtil.getMoneys(Char.myCharz().luongKhoa), GameCanvas.w / 2, 102, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Vàng : " + NinjaUtil.getMoneys(Char.myCharz().xu) + " Thỏi Vàng : " + thoiVang(), GameCanvas.w / 2, 112, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Item sẽ bán khi hết vàng : " + itemDapDo, GameCanvas.w / 2, 122, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Bán vàng" + " khi vàng < " + NinjaUtil.getMoneys(vangDapDo), GameCanvas.w / 2, 132, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, (doDeDap != null) ? ("Item đang đập: " + doDeDap.template.name) : ("Item đang đập: Không có"), GameCanvas.w / 2, 142, mFont.CENTER);
        }
        if (isNoitai)
        {
            mFont.tahoma_7b_red.drawString(g, "Ngọc Xanh : " + NinjaUtil.getMoneys(Char.myCharz().luong) + " Ngọc Hồng : " + NinjaUtil.getMoneys(Char.myCharz().luongKhoa), GameCanvas.w / 2, 102, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Vàng : " + NinjaUtil.getMoneys(Char.myCharz().xu) + " Thỏi Vàng : " + thoiVang(), GameCanvas.w / 2, 112, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Item sẽ bán khi hết vàng : " + itemDapDo, GameCanvas.w / 2, 122, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Bán vàng" + " khi vàng < " + NinjaUtil.getMoneys(vangDapDo), GameCanvas.w / 2, 132, mFont.CENTER);
            mFont.tahoma_7b_red.drawString(g, "Đang mở: " + tennoitaicanmo + " >= " + ntMin + "%", GameCanvas.w / 2, 142, mFont.CENTER);
        }
        if (!GameScr.isPaintOther)
        {
            int status = 30;
            mFont.tahoma_7.drawString(g, "Time : " + DateTime.Now, 10, GameCanvas.h / 2 - status, mFont.LEFT);
            status -= 10;
            try
            {
                mFont.tahoma_7.drawString(g, "Map : " + XmapController.get_map_names(TileMap.mapID) + " [" + TileMap.mapID + "]  - Khu : " + TileMap.zoneID, 10, GameCanvas.h / 2 - status, mFont.LEFT);
                status -= 10;
            }
            catch
            {
                mFont.tahoma_7.drawString(g, "Map : " + TileMap.mapName + " [" + TileMap.mapID + "]  - Khu : " + TileMap.zoneID, 10, GameCanvas.h / 2 - status, mFont.LEFT);
                status -= 10;
            }
            mFont.tahoma_7.drawString(g, "Tọa độ X : " + Char.myCharz().cx + " - Y : " + Char.myCharz().cy, 10, GameCanvas.h / 2 - status, mFont.LEFT);
            status -= 10;
            if (isAK)
            {
                mFont.tahoma_7.drawString(g, "Tự động đánh : " + (isAK ? "Bật" : "Tắt"), 10, GameCanvas.h / 2 - status, mFont.LEFT);
                status -= 10;
            }
            if (autoHoiSinh)
            {
                mFont.tahoma_7.drawString(g, "Auto hồi sinh : " + (autoHoiSinh ? "Bật" : "Tắt"), 10, GameCanvas.h / 2 - status, mFont.LEFT);
                status -= 10;
            }
            for (int i = 0; i < GameScr.vCharInMap.size(); i++)
            {
                Char @char = (Char)GameScr.vCharInMap.elementAt(i);
                if (@char != null && @char.isStandAndCharge)
                {
                    mFont.tahoma_7b_red.drawString(g, @char.cName + " : " + NinjaUtil.getMoneys(@char.cHP) + dangBom(@char) + trongTamBom(@char), 10, GameCanvas.h / 2 - status, mFont.LEFT);
                    status -= 10;
                }
            }
        }
        if (Char.myCharz().isFreez)
        {
            mFont.tahoma_7b_red.drawString(g, "Bị TDHS: " + Char.myCharz().freezSeconds + "s", GameCanvas.w / 2, 140, mFont.CENTER);
        }
        mFont.tahoma_7b_yellowSmall2.drawString(g, NinjaUtil.getMoneys(Char.myCharz().cHP), 90, 5, mFont.LEFT);
        mFont.tahoma_7b_yellowSmall2.drawString(g, NinjaUtil.getMoneys(Char.myCharz().cMP), 90, 17, mFont.LEFT);
    }

    public static void PhimTat(int key)
    {

        if (key == 0 || GameScr.gI().mobCapcha != null || !TField.isQwerty)
        {
            return;
        }
        //if (key == 'q')
        //{
        //    File.WriteAllText("nr_part.txt", BitConverter.ToString(File.ReadAllBytes("Data Game\\NR_part")));
        //}
        if (key == 'i')
        {
            if (getX(3) > 0 && getY(3) > 0)
            {
                GotoXY(getX(3), getY(3));
            }
        }
        if (key == 'j')
        {
            if (getX(0) > 0 && getY(0) > 0)
            {
                GotoXY(getX(0), getY(0));
            }
            else
                GotoXY(30, PickMobController.GetYsd(30));
        }
        if (key == 'k')
        {
            if (getX(1) > 0 && getY(1) > 0)
            {
                GotoXY(getX(1), getY(1));
                Service.gI().requestChangeMap();
            }
            else
                GotoXY(TileMap.pxw / 2, PickMobController.GetYsd(TileMap.pxw / 2));
        }
        if (key == 'l')
        {
            if (getX(2) > 0 && getY(2) > 0)
            {
                GotoXY(getX(2), getY(2));
            }
            else
                GotoXY(TileMap.pxw - 30, PickMobController.GetYsd(TileMap.pxw - 30));
        }
        if (key == 'b' && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            BongTai();
        }
        if (key == 'm' && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            Service.gI().openUIZone();
            GameCanvas.panel.setTypeZone();
            GameCanvas.panel.show();
        }
        if (key == 'c' && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            Capsule();
        }
        if (key == 'x')
        {
            GameScr.gI().onChatFromMe("xmp", "xmp");
        }
    }
    public static int getX(sbyte type)
    {
        for (int i = 0; i < TileMap.vGo.size(); i++)
        {
            Waypoint waypoint = (Waypoint)TileMap.vGo.elementAt(i);
            if (waypoint.maxX < 60 && type == 0)
            {
                return 15;
            }
            if (waypoint.minX <= TileMap.pxw - 60 && waypoint.maxX >= 60 && type == 1)
            {
                return (waypoint.minX + waypoint.maxX) / 2;
            }
            if (waypoint.minX <= TileMap.pxw - 60 || type != 2)
            {
                if (type == 3)
                {
                    if (waypoint.maxX < 60)
                    {
                        return 15;
                    }
                    if (waypoint.minX > TileMap.pxw - 60)
                    {
                        return TileMap.pxw - 15;
                    }
                }
                continue;
            }
            return TileMap.pxw - 15;
        }
        return 0;
    }

    public static int getY(sbyte type)
    {
        for (int i = 0; i < TileMap.vGo.size(); i++)
        {
            Waypoint waypoint = (Waypoint)TileMap.vGo.elementAt(i);
            if (waypoint.maxX < 60 && type == 0)
            {
                return waypoint.maxY;
            }
            if (waypoint.minX <= TileMap.pxw - 60 && waypoint.maxX >= 60 && type == 1)
            {
                return waypoint.maxY;
            }
            if (waypoint.minX <= TileMap.pxw - 60 || type != 2)
            {
                if (type == 3 && waypoint.maxY != Char.myCharz().cy)
                {
                    if (waypoint.maxX < 60)
                    {
                        return waypoint.maxY;
                    }
                    if (waypoint.minX > TileMap.pxw - 60)
                    {
                        return waypoint.maxY;
                    }
                }
                continue;
            }
            return waypoint.maxY;
        }
        return 0;
    }

    public static void LoadGame()
    {
        petStatus = 3;
    }

    static long currVaoKhu;
    public static int okhu;
    public static int zoneVaoKhu;
    public static int mapVaoKhu;
    public static void VaoKhu()
    {
        if (isVaoKhu && mSystem.currentTimeMillis() - currVaoKhu >= 500L)
        {
            currVaoKhu = mSystem.currentTimeMillis();
            if (TileMap.zoneID == zoneVaoKhu && TileMap.mapID == mapVaoKhu && TileMap.zoneID != okhu)
            {
                if (Input.GetKey("q"))
                {
                    Char.myCharz().addInfo("Đã dừng auto vào khu");
                    EndVaoKhu();
                    return;
                }
                if (!isVaoKhu)
                {
                    return;
                }
                if (GameScr.gI().numPlayer[okhu] < GameScr.gI().maxPlayer[okhu])
                {
                    Service.gI().requestChangeZone(okhu, -1);
                }
            }
        }
    }

    public static void EndVaoKhu()
    {
        okhu = -1;
        zoneVaoKhu = -1;
        mapVaoKhu = -1;
        isVaoKhu = false;
    }

    public static void StartVaoKhu(int okhu, int zoneVaoKhu, int mapVaoKhu)
    {
        Char.myCharz().addInfo("Vào khu: " + okhu);
        GameMod.okhu = okhu;
        GameMod.zoneVaoKhu = zoneVaoKhu;
        GameMod.mapVaoKhu = mapVaoKhu;
        isVaoKhu = true;
    }

    public static void GotoXY(int x, int y)
    {
        Char.myCharz().cx = x;
        Char.myCharz().cy = y;
        Service.gI().charMove();
    }

    public static string hanhTinhNhanVat(Char @char)
    {
        if (@char.cTypePk == 5)
        {
            return "BOSS";
        }
        else if (@char.cgender == 0)
        {
            return "TD";
        }
        else if (@char.cgender == 1)
        {
            return "NM";
        }
        else if (@char.cgender == 2)
        {
            return "XD";
        }
        return "";
    }
    public static long[] currTimeAK = new long[8];
    public static void Ak()
    {
        if (Char.myCharz().stone || Char.isLoadingMap || Char.myCharz().meDead || Char.myCharz().statusMe == 14 || Char.myCharz().statusMe == 5 || Char.myCharz().myskill.template.type == 3 || Char.myCharz().myskill.template.id == 10 || Char.myCharz().myskill.template.id == 11 || Char.myCharz().myskill.paintCanNotUseSkill)
        {
            return;
        }
        int skill = getSkill();
        if (mSystem.currentTimeMillis() - currTimeAK[skill] > getTimeSkill(Char.myCharz().myskill))
        {
            if (GameScr.gI().isMeCanAttackMob(Char.myCharz().mobFocus) && ((double)Res.abs(Char.myCharz().mobFocus.xFirst - Char.myCharz().cx) < (double)Char.myCharz().myskill.dx * 1.5))
            {
                Char.myCharz().myskill.lastTimeUseThisSkill = mSystem.currentTimeMillis();
                AkMob();
                currTimeAK[skill] = mSystem.currentTimeMillis();
                return;
            }
            if (Char.myCharz().charFocus != null && Char.myCharz().isMeCanAttackOtherPlayer(Char.myCharz().charFocus) && (double)Res.abs(Char.myCharz().charFocus.cx - Char.myCharz().cx) < (double)Char.myCharz().myskill.dx * 1.5)
            {
                Char.myCharz().myskill.lastTimeUseThisSkill = mSystem.currentTimeMillis();
                AkChar();
                currTimeAK[skill] = mSystem.currentTimeMillis();
            }
        }
    }
    public static void AkChar()
    {
        try
        {
            MyVector myVector = new MyVector();
            myVector.addElement(global::Char.myCharz().charFocus);
            Service.gI().sendPlayerAttack(new MyVector(), myVector, 2);
            Char.myCharz().cMP -= Char.myCharz().myskill.manaUse;
        }
        catch
        {
        }
    }

    public static void AkMob()
    {
        try
        {
            MyVector myVector = new MyVector();
            myVector.addElement(global::Char.myCharz().mobFocus);
            Service.gI().sendPlayerAttack(myVector, new MyVector(), 1);
            Char.myCharz().cMP -= Char.myCharz().myskill.manaUse;
        }
        catch
        {
        }
    }
    private static int getSkill()
    {
        for (int i = 0; i < GameScr.keySkill.Length; i++)
        {
            if (GameScr.keySkill[i] == global::Char.myCharz().myskill)
            {
                return i;
            }
        }
        return 0;
    }
    public static long getTimeSkill(Skill s)
    {
        if (s.template.id == 29 || s.template.id == 22 || s.template.id == 7 || s.template.id == 18 || s.template.id == 23)
        {
            return (long)s.coolDown + 500L;
        }
        long num = (long)((double)s.coolDown * 1.2);
        if (num < 406L)
        {
            return 406L;
        }
        return num;
    }
    public static void GotoNpc(int npcID)
    {
        for (int i = 0; i < GameScr.vNpc.size(); i++)
        {
            Npc npc = (Npc)GameScr.vNpc.elementAt(i);
            if (npc.template.npcTemplateId == npcID && Math.abs(npc.cx - Char.myCharz().cx) >= 50)
            {
                GotoXY(npc.cx, npc.cy - 10);
                Char.myCharz().focusManualTo(npc);
                break;
            }
        }
    }

    public static void AutoNhatXa()
    {
        if (isAutoNhatXa && mSystem.currentTimeMillis() - currNhatXa >= 2000L)
        {
            currNhatXa = mSystem.currentTimeMillis();
            for (int i = 0; i < GameScr.vItemMap.size(); i++)
            {
                ItemMap itemMap = (ItemMap)GameScr.vItemMap.elementAt(i);
                if (itemMap != null && itemMap.itemMapID == Char.myCharz().charID)
                {
                    GotoXY(itemMap.x, itemMap.y);
                    Service.gI().pickItem(itemMap.itemMapID);
                    GotoXY(xNhatXa, yNhatXa);
                    break;
                }
                if (itemMap != null)
                {
                    GotoXY(itemMap.x, itemMap.y);
                    Service.gI().pickItem(itemMap.itemMapID);
                    GotoXY(xNhatXa, yNhatXa);
                    break;
                }
            }
        }
    }

    public static void AutoBT()
    {
        if (isAutoBT && mSystem.currentTimeMillis() - currAutoBT >= timeBT * 1000)
        {
            currAutoBT = mSystem.currentTimeMillis();
            BongTai();
            if (Char.myCharz().isNhapThe)
            {
                BongTai();
            }
        }
    }

    public static void BongTai()
    {
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            if (Char.myCharz().arrItemBag[i] != null && Char.myCharz().arrItemBag[i].template.id == 921)
            {
                Service.gI().useItem(0, 1, (sbyte)i, -1);
                Service.gI().petStatus(petStatus);
                return;
            }
        }
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            if (Char.myCharz().arrItemBag[i] != null && Char.myCharz().arrItemBag[i].template.id == 454)
            {
                Service.gI().useItem(0, 1, (sbyte)i, -1);
                Service.gI().petStatus(petStatus);
                return;
            }
        }
        Char.myCharz().addInfo("Không Có Bông Tai Trong Hành Trang");
    }
    public static void Capsule()
    {
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            if (Char.myCharz().arrItemBag[i] != null && Char.myCharz().arrItemBag[i].template.id == 194)
            {
                Service.gI().useItem(0, 1, (sbyte)i, -1);
                return;
            }
        }
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            if (Char.myCharz().arrItemBag[i] != null && Char.myCharz().arrItemBag[i].template.id == 193)
            {
                Service.gI().useItem(0, 1, (sbyte)i, -1);
                return;
            }
        }
        Char.myCharz().addInfo("Không có capsule trong balo");
    }

    static string dangBom(Char @char)
    {
        if (@char.isStandAndCharge && @char.cgender == 2)
            return " - Đang bom";
        if ((@char.isFlyAndCharge || @char.isStandAndCharge) && @char.cgender == 0)
            return " - Đang quả cầu kinh khi";
        if (@char.isStandAndCharge && @char.cgender == 1)
            return " - Đang laze";
        return "";
    }
    static string trongTamBom(Char @char)
    {
        if (@char.isStandAndCharge && (Math.abs(@char.cx - Char.myCharz().cx) <= 880) && (Math.abs(@char.cy - Char.myCharz().cy) <= 880))
            return " - Trong tầm";
        return "- Ngoài tầm";
    }

    static long currAutoHoiSinh;
    static void AutoHoiSinh()
    {
        if (autoHoiSinh && (Char.myCharz().cHP <= 0 || Char.myCharz().meDead || Char.myCharz().statusMe == 14) && !Char.myCharz().isFreez && mSystem.currentTimeMillis() - currAutoHoiSinh >= 700L)
        {
            currAutoHoiSinh = mSystem.currentTimeMillis();
            Service.gI().wakeUpFromDead();
        }
    }
    public static void GMT()
    {
        if (isGMT && GameScr.findCharInMap(charMT.charID) != null)
        {
            Char.myCharz().focusManualTo(GameScr.findCharInMap(charMT.charID));
        }
    }
    public static Color GetColor()
    {
        string[] array = backgroundColor.Split(' ');
        return new Color(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
    }
    public static bool MapNRD()
    {
        return TileMap.mapID >= 85 && TileMap.mapID <= 91;
    }

    public static bool isPemMob1HP;
    public static bool isKillMob1HP;
    public static bool isMob1HP(Mob mob)
    {
        if (isPemMob1HP)
            return mob.hp > 1;
        if (isKillMob1HP)
            return mob.hp == 1;
        return true;
    }
    public static int FindIndexItem(int idItem)
    {
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            if (Char.myCharz().arrItemBag[i] != null && Char.myCharz().arrItemBag[i].template.id == idItem)
            {
                return Char.myCharz().arrItemBag[i].indexUI;
            }
        }
        return -1;
    }
    public static Item FindItem(int idItem)
    {
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            if (Char.myCharz().arrItemBag[i] != null && Char.myCharz().arrItemBag[i].template.id == idItem)
            {
                return Char.myCharz().arrItemBag[i];
            }
        }
        return null;
    }
    public static int GetIDMap(string mapName)
    {
        int idMap = -1;
        for (int i = 0; i < MapNames.Length; i++)
        {
            if (MapNames[i].Trim().ToLower().Equals(mapName.Trim().ToLower()))
                idMap = i;
        }
        return idMap;
    }

    public static int MapID(string a)
    {
        for (int i = 0; i < TileMap.mapNames.Length; i++)
        {
            if (TileMap.mapNames[i].Trim().ToLower() == a.Trim().ToLower())
            {
                return i;
            }
        }
        return -1;
    }

    static long currKhoaViTri;
    public static void khoaViTri()
    {
        if (isKhoaViTri && mSystem.currentTimeMillis() - currKhoaViTri >= 600L && Char.myCharz().statusMe != 14 && Char.myCharz().cHP > 0)
        {
            currKhoaViTri = mSystem.currentTimeMillis();
            Char.myCharz().cx = ghimX;
            Char.myCharz().cy = ghimY;
            Service.gI().charMove();
        }
    }

    public static void KSBoss()
    {
        if (isKSBoss)
        {
            for (int i = 0; i < GameScr.vCharInMap.size(); i++)
            {
                Char @char = (Char)GameScr.vCharInMap.elementAt(i);
                if (HPKSBoss == 0)
                {
                    isKSBoss = false;
                    Char.myCharz().addInfo("HP Boss = 0 thì ks sao ba =))");
                    Char.myCharz().addInfo("KS Boss đã tắt");
                    return;
                }
                if (@char != null && @char.charID < 0 && @char.cTypePk == 5 && !@char.cName.StartsWith("Đ") && @char.cHP <= HPKSBoss && @char.cHP > 0)
                {
                    GetSkillByIconID(539);
                    if (Math.abs(@char.cx - Char.myCharz().cx) >= 25)
                    {
                        GotoXY(@char.cx, @char.cy - 1);
                    }
                    Char.myCharz().focusManualTo(@char);
                    Ak();
                }
            }
        }
    }
    static int ulti()
    {
        if (Char.myCharz().cgender == 0)
        {
            return 3783;
        }
        if (Char.myCharz().cgender == 1)
        {
            return 723;
        }
        return 2248;
    }
    public static void KSBossBangSkill5()
    {
        if (isKSBossBangSkill5)
        {
            Char @char = BossInMap();
            if ((Char.myCharz().isStandAndCharge || Char.myCharz().isCharge || Char.myCharz().isFlyAndCharge || GetCoolDownSkill(GetSkillByIconID(ulti())) > 0) && GetSkillByIconID(ulti()) == null && @char == null)
            {
                return;
            }
            if (HPKSBoss == 0)
            {
                isKSBossBangSkill5 = false;
                Char.myCharz().addInfo("HP Boss = 0 thì ks sao ba =))");
                Char.myCharz().addInfo("KS Boss đã tắt");
                return;
            }
            if ((@char.cHP <= HPKSBoss || ((DameToBoss() + Char.myCharz().cHPFull) / 2 >= @char.cHP)) && GetSkillByIconID(ulti()) != null)
            {
                if (Math.abs(@char.cx - Char.myCharz().cx) >= 500)
                    GotoXY(@char.cx, @char.cy - 1);
                Char.myCharz().focusManualTo(@char);
                Combo();
            }
        }
    }
    public static Char BossInMap()
    {
        for (int i = 0; i < GameScr.vCharInMap.size(); i++)
        {
            Char @char = (Char)GameScr.vCharInMap.elementAt(i);
            if (@char.cTypePk == 5 && @char != null && @char.cHP > 0 && Char.myCharz().isMeCanAttackOtherPlayer(@char))
            {
                return @char;
            }
        }
        return null;
    }
    static int DameToBoss()
    {
        int result = -Char.myCharz().cHPFull;
        for (int i = 0; i < GameScr.vCharInMap.size(); i++)
        {
            Char @char = (Char)GameScr.vCharInMap.elementAt(i);
            if (@char != null && @char.isStandAndCharge && Char.myCharz().cgender == 2 && BossInMap() != null)
            {
                if (result < 0)
                {
                    result = 0;
                }
                result += @char.cHPFull;
            }
        }
        return result;
    }
    public static void Combo()
    {
        if (Char.myCharz().cgender == 0)
            DcttKame();
        else
            BomLaze();
    }
    static bool isDcttKame;
    static void DcttKame()
    {
        if (!isDcttKame)
        {
            new Thread(() =>
            {
                isDcttKame = true;
                Skill dctt = GetSkillByIconID(3783);
                Skill kame = GetSkillByIconID(540);
                Char @char = BossInMap();
                while (Char.myCharz().charFocus != @char)
                    Char.myCharz().focusManualTo(@char);
                while ((GetCoolDownSkill(dctt) <= 0 || dctt.lastTimeUseThisSkill == 0) && Char.myCharz().cMP >= dctt.manaUse)
                {
                    GameScr.gI().doSelectSkill(dctt, true);
                    Thread.Sleep(250);
                }
                Thread.Sleep(1000);
                while ((GetCoolDownSkill(kame) <= 0 || kame.lastTimeUseThisSkill == 0) && Char.myCharz().cMP >= kame.manaUse)
                {
                    GameScr.gI().doSelectSkill(kame, true);
                    Thread.Sleep(250);
                }
                isDcttKame = false;
            }).Start();
        }
    }

    static bool isBomLaze;
    static void BomLaze()
    {
        if (!isBomLaze)
        {
            new Thread(() =>
            {
                isBomLaze = true;
                Skill bom = GetSkillByIconID(2248);
                Skill laze = GetSkillByIconID(723);
                Char @char = BossInMap();
                while (Char.myCharz().charFocus != @char)
                    Char.myCharz().focusManualTo(@char);
                if (Char.myCharz().cgender == 2)
                {
                    while ((GetCoolDownSkill(bom) <= 0 || bom.lastTimeUseThisSkill == 0) && !Char.myCharz().isStandAndCharge && Char.myCharz().cMP >= bom.manaUse)
                    {
                        GameScr.gI().doSelectSkill(bom, true);
                        Thread.Sleep(250);
                    }
                }
                if (Char.myCharz().cgender == 1)
                {
                    while ((GetCoolDownSkill(laze) <= 0 || laze.lastTimeUseThisSkill == 0) && !Char.myCharz().isStandAndCharge && Char.myCharz().cMP >= laze.manaUse)
                    {
                        GameScr.gI().doSelectSkill(laze, true);
                        Thread.Sleep(250);
                    }
                }
                isBomLaze = false;
            }).Start();
        }
    }
    public static Skill GetSkillByIconID(int iconID)
    {
        for (int i = 0; i < GameScr.keySkill.Length; i++)
        {
            if (GameScr.keySkill[i] != null && GameScr.keySkill[i].template.iconId == iconID)
            {
                return GameScr.keySkill[i];
            }
        }
        return null;
    }
    public static int GetCoolDownSkill(Skill skill)
    {
        return (int)(skill.coolDown - mSystem.currentTimeMillis() + skill.lastTimeUseThisSkill);
    }

    static long currHoiSinh;
    public static void HoiSinhTheoNgocChiDinh()
    {
        if (ngocHienTai == 0 || Char.myCharz().luongKhoa + Char.myCharz().luong == 0 || ngocDuocDungDeHoiSinh == 0)
        {
            Char.myCharz().addInfo("Không còn ngọc để hồi sinh hoặc chưa set up số ngọc được phép sử dụng hoặc số ngọc được hồi sinh đã dùng hết");
            Char.myCharz().addInfo("Đã tắt tự hồi sinh với số ngọc chỉ định");
            hoiSinhNgoc = false;
        }
        if (ngocDuocDungDeHoiSinh > 0 && Char.myCharz().cHP <= 0 && Char.myCharz().statusMe == 14)
        {
            Service.gI().wakeUpFromDead();
            ngocDuocDungDeHoiSinh--;
        }
    }


    public static bool isDapDo;
    public static Item doDeDap;
    public static int soSaoCanDap = -1;
    static int saoHienTai = -1;
    static long currDapdo;
    public static void AutoDapDo()
    {
        if (isDapDo && mSystem.currentTimeMillis() - currDapdo >= 500L)
        {
            currDapdo = mSystem.currentTimeMillis();
            int npcDapDo = 21;
            bool isDoneNhanVang = false;
            if (Input.GetKey("q"))
            {
                Char.myCharz().addInfo("Đồ để đập đã reset hãy add đồ");
                soSaoCanDap = -1;
                doDeDap = null;
            }
            if (TileMap.mapID != 5 && !Pk9rXmap.IsXmapRunning)
                XmapController.StartRunToMapId(5);
            if (TileMap.mapID != 5)
                return;
            if (saoHienTai >= soSaoCanDap && doDeDap != null && saoHienTai >= 0 && soSaoCanDap > 0)
            {
                Sound.start(1f, Sound.l1);
                Char.myCharz().addInfo("Đồ Cần Đập Đã Đạt Số Sao Yêu Cầu");
                soSaoCanDap = -1;
                return;
            }
            if (Char.myCharz().xu > vangDapDo)
            {
                long xuNow = Char.myCharz().xu;
                GotoNpc(21);
                if (doDeDap != null && soSaoCanDap > 0)
                {
                    Service.gI().combine(1, GameCanvas.panel.vItemCombine);
                    Service.gI().confirmMenu(21, 0);
                }
            }
            else
            {
                if (doDeDap != null)
                {
                    BanVang();
                }
            }
        }
    }

    public static int itemDapDo = 457;
    public static int vangDapDo = 200000000;
    static bool dangBanVang;
    public static void BanVang()
    {
        if (!dangBanVang)
        {
            new Thread(() =>
            {
                dangBanVang = true;
                if (TileMap.mapID != 5)
                {
                    XmapController.StartRunToMapId(5);
                    Thread.Sleep(1000);
                }
                while (TileMap.mapID != 5)
                {
                    Thread.Sleep(500);
                }
                if (Input.GetKey("q"))
                {
                    Char.myCharz().addInfo("Dừng bán vàng");
                    dangBanVang = false;
                    return;
                }
                GotoNpc(39);
                while (Char.myCharz().xu <= 1500000000 && !Input.GetKey("q"))
                {
                    if (thoiVang() > 0)
                    {
                        Service.gI().saleItem(1, 1, (short)FindIndexItem(itemDapDo));
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Char.myCharz().addInfo("Hết vàng");
                        if (isDapDo)
                        {
                            isDapDo = false;
                            Char.myCharz().addInfo("Đập đồ đã tắt do bạn quá nghèo :v");
                        }
                        dangBanVang = false;
                        return;
                    }
                    Thread.Sleep(500);
                }
                Char.myCharz().addInfo("Đã bán xong");
                Thread.Sleep(500);
                dangBanVang = false;
            }).Start();
        }
    }

    public static bool isAutoBanVang;
    public static void AutoBanVang()
    {
        if (isAutoBanVang)
        {
            if (Input.GetKey("q"))
            {
                isAutoBanVang = false;
                Char.myCharz().addInfo("Dừng auto bán vàng");
                return;
            }
            if (dangBanVang)
                return;
            if (Char.myCharz().xu <= vangDapDo)
                BanVang();
        }
    }
    public static int soSao(Item item)
    {
        for (int i = 0; i < item.itemOption.Length; i++)
        {
            if (item.itemOption[i].optionTemplate.id == 107)
            {
                return item.itemOption[i].param;
            }
        }
        return 0;
    }

    public static int thoiVang()
    {
        int num = 0;
        for (int i = 0; i < Char.myCharz().arrItemBag.Length; i++)
        {
            Item item = Char.myCharz().arrItemBag[i];
            if (item != null && item.template.id == 457)
            {
                num += item.quantity;
            }
        }
        return num;
    }

    public static string saoTrongBalo(Item item)
    {
        if ((item != null && item.template.type <= 5) || item.template.type == 32)
        {
            return soSao(item) + " sao";
        }
        return "";
    }

    public static Item findItemBagWithIndexUI(int index)
    {
        Item[] arrItemBag = Char.myCharz().arrItemBag;
        foreach (Item item in arrItemBag)
        {
            if (item != null && item.indexUI == index)
            {
                return item;
            }
        }
        return null;
    }
    public static string tennoitaicanmo;
    public static bool isNoitai;
    public static int ntMin;
    public static int ntNow;
    static bool isOpeningNT;
    static long currNoiTai;
    public static void AutoNoiTai()
    {
        if (isNoitai && mSystem.currentTimeMillis() - currNoiTai >= 1000L)
        {
            currNoiTai = mSystem.currentTimeMillis();
            if (ntMin == 0)
            {
                Char.myCharz().addInfo("Chưa set up chỉ số nội tại", 0);
                isNoitai = false;
                return;
            }
            if (Panel.specialInfo.Contains(tennoitaicanmo) && ntMin <= ntNow)
            {
                Char.myCharz().addInfo("Đã Ra Nội Tại Cần Mở", 0);
                isNoitai = false;
                return;
            }
            if (Input.GetKey("q"))
            {
                Char.myCharz().addInfo("Auto Mở Nội Tại Đã Tắt", 0);
                isNoitai = false;
                return;
            }
            //if (global::Char.myCharz().xu <= 40000000)
            //{
            //    BanVang();
            //}
            //else
            //{
            //Service.gI().speacialSkill(0);
            //for (int l = 0; l < 3; l++)
            //{
            //    Service.gI().confirmMenu(5, 1);
            //    Service.gI().confirmMenu(5, 0);
            //    Thread.Sleep(700);
            //}
            Service.gI().speacialSkill(0);
                Service.gI().confirmMenu(5, 2);
                Service.gI().confirmMenu(5, 0);
            //}
        }
    }

    public static string CutString(int start, int end, string s)
    {
        string str = "";
        for (int i = start; i < end; i++)
        {
            str += s[i].ToString();
        }
        return str;
    }

    public static bool isMapOffline(int idMap)
    {
        return (idMap >= 45 && idMap <= 50) || (idMap >= 53 && idMap <= 62) || idMap == 155;
    }

    static bool isThuongDe;
    static long currThuongDe;
    static sbyte typeThuongDe = 0;
    public static void AutoThuongDe()
    {
        if (isThuongDe && mSystem.currentTimeMillis() - currThuongDe >= 1000L)
        {
            currThuongDe = mSystem.currentTimeMillis();
            if (TileMap.mapID != 45)
            {
                GameScr.info1.addInfo("Vui lòng đến Thần điện để bắt đầu", 0);
                isThuongDe = false;
                return;
            }
            if (Input.GetKey("q"))
            {
                Char.myCharz().addInfo("Auto đã tắt", 0);
                isThuongDe = false;
                return;
            }
            GotoNpc(19);
            Service.gI().openMenu(19);
            if (typeThuongDe == 0 && Char.myCharz().xu < 175000000)
            {
                if (thoiVang() > 0)
                {
                    Service.gI().confirmMenu(19, 1);
                    Service.gI().saleItem(1, 1, (short)FindIndexItem(itemDapDo));
                    return;
                }
            }
            Service.gI().confirmMenu(19, 0);
            Service.gI().confirmMenu(19, typeThuongDe);
            Service.gI().SendCrackBall(2, 7);
        }
    }

    static string TypeThuongDe()
    {
        if (typeThuongDe == 0)
            return "Vàng";
        if (typeThuongDe == 1)
            return "Ngọc xanh";
        if (typeThuongDe == 2)
            return "Hồng ngọc";
        return "";
    }
}
