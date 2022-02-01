using EllipticCurve.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_LIB
{
    public class Class1
    {
        public Boolean CheckVIN(string vin)
        {
            string VinProverks = vin;
            int LenghtVin = VinProverks.Length;
            var result = 0;
            var index = 0;
            var checkDigit = 0;
            var checkSum = 0;
            var weight = 0;
            if (LenghtVin < 17 && LenghtVin>17 )
            {
                return false;
            }

            
            foreach (var c in VinProverks.ToCharArray())
            {
                index++;
                var character = c.ToString().ToLower();
                if (char.IsNumber(c))
                    result = int.Parse(character);
                else
                {
                    switch (character)
                    {
                        case "a":
                        case "j":
                            result = 1;
                            break;
                        case "b":
                        case "k":
                        case "s":
                            result = 2;
                            break;
                        case "c":
                        case "l":
                        case "t":
                            result = 3;
                            break;
                        case "d":
                        case "m":
                        case "u":
                            result = 4;
                            break;
                        case "e":
                        case "n":
                        case "v":
                            result = 5;
                            break;
                        case "f":
                        case "w":
                            result = 6;
                            break;
                        case "g":
                        case "p":
                        case "x":
                            result = 7;
                            break;
                        case "h":
                        case "y":
                            result = 8;
                            break;
                        case "r":
                        case "z":
                            result = 9;
                            break;
                    }
                }

                if (index >= 1 && index <= 7 || index == 9)
                    weight = 9 - index;
                else if (index == 8)
                    weight = 10;
                else if (index >= 10 && index <= 17)
                    weight = 19 - index;
                if (index == 9)
                    checkDigit = character == "x" ? 10 : result;
                checkSum += (result * weight);
            }

           if (checkSum % 11 == checkDigit)
            {
                return true;
            }
           else return false;
        }

        public string GetVINCountry(string vin)
        {
            string VinCountru = vin.Substring(0, 2);
            string VinRegion = vin.Substring(0, 1);
            if (VinCountru=="AA"|| VinCountru == "AH")
            {
                return "ЮАР";
            }
            if (VinCountru == "AJ" || VinCountru == "AN")
            {
                return "Кот-д Ивуар";
            }
            if (VinCountru == "BA" || VinCountru == "BE")
            {
                return "Кения";
            }
            if (VinCountru == "BF" || VinCountru == "BK")
            {
                return "Танзания";
            }
            if (VinCountru == "CA" || VinCountru == "CE")
            {
                return "Бенин";
            }
            if (VinCountru == "CK")
            {
                return "Мадагаскар";
            }
            if (VinCountru == "CL" || VinCountru == "CR")
            {
                return "Тунис";
            }
            if (VinCountru == "CL" || VinCountru == "CR")
            {
                return "Тунис";
            }
            if (VinCountru == "DA" || VinCountru == "DE")
            {
                return "Египет";
            }
            if (VinCountru == "DA" || VinCountru == "DE")
            {
                return "Марокко";
            }
            if (VinCountru == "DA" || VinCountru == "DE")
            {
                return "Замбия";
            }
            if (VinCountru == "EA" || VinCountru == "EE")
            {
                return "Эфиопия";
            }
            if (VinCountru == "EF" || VinCountru == "EK")
            {
                return "Гана";
            }
            if (VinCountru == "FA" || VinCountru == "FE")
            {
                return "Нигерия";
            }
            if (VinCountru == "JA" || VinCountru == "JT")
            {
                return "Япония";
            }
            if (VinCountru == "KA" || VinCountru == "KE")
            {
                return "Шри Ланка";
            }
            if (VinCountru == "KF" || VinCountru == "KK")
            {
                return "Израиль";
            }
            if (VinCountru == "KL" || VinCountru == "KR")
            {
                return "Южная Корея";
            }
            if (VinCountru == "KS" || VinCountru == "K0")
            {
                return "Казахстан";
            }
            if (VinRegion == "L")
            {
                return "Китай";
            }
            if (VinCountru == "MA" || VinCountru == "Me")
            {
                return "Казахстан";
            }
            if (VinCountru == "MK" || VinCountru == "ML")
            {
                return "Индия";
            }
            if (VinCountru == "MK" )
            {
                return "Индонезия";
            }
            if (VinCountru == "ML" || VinCountru == "MR")
            {
                return "Таиланд";
            }
            if (VinCountru == "NF" || VinCountru == "NK")
            {
                return "Пакистан";
            }
            if (VinCountru == "NL" || VinCountru == "NR")
            {
                return "Турция";
            }
            if (VinCountru == "PA" || VinCountru == "PE")
            {
                return "Филипины";
            }
            if (VinCountru == "PF" || VinCountru == "PK")
            {
                return "Сингапур";
            }
            if (VinCountru == "PL" || VinCountru == "PR")
            {
                return "Малайзия";
            }
            if (VinCountru == "RA" || VinCountru == "RE")
            {
                return "ОАЭ";
            }
            if (VinCountru == "RF" || VinCountru == "RK")
            {
                return "Тайвань";
            }
            if (VinCountru == "RL" || VinCountru == "RR")
            {
                return "Вьетнам";
            }
            if (VinCountru == "RS" || VinCountru == "R0")
            {
                return "Саудовская Аравия";
            }
            if (VinCountru == "SA" || VinCountru == "SM")
            {
                return "Великобритания";
            }
            if (VinCountru == "SN" || VinCountru == "ST")
            {
                return "Германия";
            }
            if (VinCountru == "SU" || VinCountru == "SZ")
            {
                return "Польша";
            }
            if (VinCountru == "S1" || VinCountru == "S4")
            {
                return "Латвия";
            }
            if (VinCountru == "TA" || VinCountru == "TN")
            {
                return "Щвейцария";
            }
            if (VinCountru == "TJ" || VinCountru == "TP")
            {
                return "Чехия";
            }
            if (VinCountru == "TR" || VinCountru == "TV")
            {
                return "Венгрия";
            }
            if (VinCountru == "TW" || VinCountru == "T1")
            {
                return "Португалия";
            }
            if (VinCountru == "UH" || VinCountru == "UM")
            {
                return "Дания";
            }
            if (VinCountru == "UN" || VinCountru == "UT")
            {
                return "Ирландия";
            }
            if (VinCountru == "UU" || VinCountru == "UZ")
            {
                return "Румыния";
            }
            if (VinCountru == "U5" || VinCountru == "U7")
            {
                return "Словакия";
            }
            if (VinCountru == "VA" || VinCountru == "VE")
            {
                return "Австрия";
            }
            if (VinCountru == "VF" || VinCountru == "VR")
            {
                return "Франция";
            }
            if (VinCountru == "VS" || VinCountru == "VW")
            {
                return "Испания";
            }
            if (VinCountru == "VX" || VinCountru == "V2")
            {
                return "Сербия";
            }
            if (VinCountru == "V3" || VinCountru == "V5")
            {
                return "Хорватия";
            }
            if (VinCountru == "V6" || VinCountru == "V0")
            {
                return "Эстония";
            }
            if (VinRegion=="W")
            {
                return "Германия";
            }
            if (VinCountru == "XA" || VinCountru == "XE")
            {
                return "Болгария";
            }
            if (VinCountru == "XF" || VinCountru == "XK")
            {
                return "Греция";
            }
            if (VinCountru == "XL" || VinCountru == "XR")
            {
                return "Нидерланды";
            }
            if (VinCountru == "XS" || VinCountru == "XW")
            {
                return "СССР/СНГ";
            }
            if (VinCountru == "XX" || VinCountru == "X2")
            {
                return "Люксембург";
            }
            if (VinCountru == "X3" || VinCountru == "X0")
            {
                return "Россия";
            }
            if (VinCountru == "YA" || VinCountru == "YE")
            {
                return "Бельгия";
            }
            if (VinCountru == "YF" || VinCountru == "YK")
            {
                return "Финляндия";
            }
            if (VinCountru == "YL" || VinCountru == "YR")
            {
                return "Мальта";
            }
            if (VinCountru == "YS" || VinCountru == "YW")
            {
                return "Щвеция";
            }
            if (VinCountru == "YX" || VinCountru == "Y2")
            {
                return "Норвегия";
            }
            if (VinCountru == "Y3" || VinCountru == "Y5")
            {
                return "Беларусь";
            }
            if (VinCountru == "Y6" || VinCountru == "Y0")
            {
                return "Украина";
            }
            if (VinCountru == "ZA" || VinCountru == "ZR")
            {
                return "Италия";
            }
            if (VinCountru == "ZX" || VinCountru == "Z2")
            {
                return "Словения";
            }
            if (VinCountru == "Z3" || VinCountru == "Z5")
            {
                return "Литва";
            }
            if (VinCountru == "Z6" || VinCountru == "Z0")
            {
                return "Россия";
            }
            if (VinRegion == "1" || VinRegion == "4" || VinRegion == "5")
            {
                return "США";
            }
            if (VinRegion == "2")
            {
                return "Канада";
            }
            if (VinCountru == "3A" || VinCountru == "3W")
            {
                return "Мексика";
            }
            if (VinCountru == "3X" || VinCountru == "37")
            {
                return "Коста Рика";
            }
            if (VinCountru == "38" || VinCountru == "30")
            {
                return "Каймановы острова";
            }
            if (VinRegion == "6")
            {
                return "Австралия";
            }
            if (VinRegion == "7")
            {
                return "Новая Зеландия";
            }
            if (VinCountru == "8A" || VinCountru == "8E")
            {
                return "Аргентина";
            }
            if (VinCountru == "8F" || VinCountru == "8K")
            {
                return "Чили";
            }
            if (VinCountru == "8L" || VinCountru == "8R")
            {
                return "Эквадор";
            }
            if (VinCountru == "8S" || VinCountru == "8W")
            {
                return "Перу";
            }
            if (VinCountru == "8X" || VinCountru == "82")
            {
                return "Венесуэла";
            }
            if (VinCountru == "9A" || VinCountru == "9E")
            {
                return "Бразилия";
            }
            if (VinCountru == "9F" || VinCountru == "9K")
            {
                return "Колумбия";
            }
            if (VinCountru == "9L" || VinCountru == "9R")
            {
                return "Парагвай";
            }
            if (VinCountru == "9S" || VinCountru == "9W")
            {
                return "Уругвай";
            }
            if (VinCountru == "9X" || VinCountru == "92")
            {
                return "Тринидад и Тобаго";
            }
            if (VinCountru == "93" || VinCountru == "99")
            {
                return "Бразилия";
            }
            return " ";
        }
        public int GetTransportYear(string vin)
        {
            string VinYear = vin.Substring(8);
            if (VinYear == "N")
            {
                return 1992;
            }
            if (VinYear == "P")
            {
                return 1993;
            }
            if (VinYear == "R")
            {
                return 1994;
            }
            if (VinYear == "S")
            {
                return 1995;
            }
            if (VinYear == "T")
            {
                return 1996;
            }
            if (VinYear == "V")
            {
                return 1997;
            }
            if (VinYear == "W")
            {
                return 1998;
            }
            if (VinYear == "X")
            {
                return 1999;
            }
            if (VinYear == "Y")
            {
                return 2000;
            }
            if (VinYear == "1")
            {
                return 2001;
            }
            if (VinYear == "2")
            {
                return 2002;
            }
            if (VinYear == "3")
            {
                return 2003;
            }
            if (VinYear == "4")
            {
                return 2004;
            }
            if (VinYear == "5")
            {
                return 2005;
            }
            if (VinYear == "6")
            {
                return 2006;
            }
            if (VinYear == "7")
            {
                return 2007;
            }
            if (VinYear == "8")
            {
                return 2008;
            }
            if (VinYear == "9")
            {
                return 2009;
            }
            if (VinYear == "0")
            {
                return 2010;
            }
            if (VinYear == "A")
            {
                return 2010;
            }
            if (VinYear == "B")
            {
                return 2011;
            }
            if (VinYear == "C")
            {
                return 2012;
            }
            if (VinYear == "D")
            {
                return 2013;
            }
            if (VinYear == "E")
            {
                return 2014;
            }
            if (VinYear == "F")
            {
                return 2015;
            }
            if (VinYear == "G")
            {
                return 2016;
            }
            if (VinYear == "H")
            {
                return 2017;
            }
            if (VinYear == "J")
            {
                return 2018;
            }
            if (VinYear == "K")
            {
                return 2019;
            }
            if (VinYear == "L")
            {
                return 2020;
            }
            if (VinYear == "M")
            {
                return 2021;
            }
            return 0;
        }



    }
    
}
