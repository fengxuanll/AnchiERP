//=======================================================================================
//
// Copyright (C) Yahee. All Rights Reserved.
// 
// All the code, text, graphics, media, design, programs and other works are
// protected by copyright law. Unauthorized reproduction or redistribution of them, 
// or any portion of them, are forbidden.
// 
//=======================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Anchi.ERP.Common.Globalization
{
	public partial class Country
	{
		#region well-known
		
		/// <summary>
        /// AFGHANISTAN
        /// </summary>
		public static readonly Country AF = new Country(CountryCode.AF);
		
		/// <summary>
        /// ALAND ISLANDS
        /// </summary>
		public static readonly Country AX = new Country(CountryCode.AX);
		
		/// <summary>
        /// ALBANIA
        /// </summary>
		public static readonly Country AL = new Country(CountryCode.AL);
		
		/// <summary>
        /// ALGERIA
        /// </summary>
		public static readonly Country DZ = new Country(CountryCode.DZ);
		
		/// <summary>
        /// AMERICAN SAMOA
        /// </summary>
		public static readonly Country AS = new Country(CountryCode.AS);
		
		/// <summary>
        /// ANDORRA
        /// </summary>
		public static readonly Country AD = new Country(CountryCode.AD);
		
		/// <summary>
        /// ANGOLA
        /// </summary>
		public static readonly Country AO = new Country(CountryCode.AO);
		
		/// <summary>
        /// ANGUILLA
        /// </summary>
		public static readonly Country AI = new Country(CountryCode.AI);
		
		/// <summary>
        /// ANTARCTICA
        /// </summary>
		public static readonly Country AQ = new Country(CountryCode.AQ);
		
		/// <summary>
        /// ANTIGUA AND BARBUDA
        /// </summary>
		public static readonly Country AG = new Country(CountryCode.AG);
		
		/// <summary>
        /// ARGENTINA
        /// </summary>
		public static readonly Country AR = new Country(CountryCode.AR);
		
		/// <summary>
        /// ARMENIA
        /// </summary>
		public static readonly Country AM = new Country(CountryCode.AM);
		
		/// <summary>
        /// ARUBA
        /// </summary>
		public static readonly Country AW = new Country(CountryCode.AW);
		
		/// <summary>
        /// AUSTRALIA
        /// </summary>
		public static readonly Country AU = new Country(CountryCode.AU);
		
		/// <summary>
        /// AUSTRIA
        /// </summary>
		public static readonly Country AT = new Country(CountryCode.AT);
		
		/// <summary>
        /// AZERBAIJAN
        /// </summary>
		public static readonly Country AZ = new Country(CountryCode.AZ);
		
		/// <summary>
        /// BAHAMAS
        /// </summary>
		public static readonly Country BS = new Country(CountryCode.BS);
		
		/// <summary>
        /// BAHRAIN
        /// </summary>
		public static readonly Country BH = new Country(CountryCode.BH);
		
		/// <summary>
        /// BANGLADESH
        /// </summary>
		public static readonly Country BD = new Country(CountryCode.BD);
		
		/// <summary>
        /// BARBADOS
        /// </summary>
		public static readonly Country BB = new Country(CountryCode.BB);
		
		/// <summary>
        /// BELARUS
        /// </summary>
		public static readonly Country BY = new Country(CountryCode.BY);
		
		/// <summary>
        /// BELGIUM
        /// </summary>
		public static readonly Country BE = new Country(CountryCode.BE);
		
		/// <summary>
        /// BELIZE
        /// </summary>
		public static readonly Country BZ = new Country(CountryCode.BZ);
		
		/// <summary>
        /// BENIN
        /// </summary>
		public static readonly Country BJ = new Country(CountryCode.BJ);
		
		/// <summary>
        /// BERMUDA
        /// </summary>
		public static readonly Country BM = new Country(CountryCode.BM);
		
		/// <summary>
        /// BHUTAN
        /// </summary>
		public static readonly Country BT = new Country(CountryCode.BT);
		
		/// <summary>
        /// BOLIVIA, PLURINATIONAL STATE OF
        /// </summary>
		public static readonly Country BO = new Country(CountryCode.BO);
		
		/// <summary>
        /// BONAIRE, SAINT EUSTATIUS AND SABA
        /// </summary>
		public static readonly Country BQ = new Country(CountryCode.BQ);
		
		/// <summary>
        /// BOSNIA AND HERZEGOVINA
        /// </summary>
		public static readonly Country BA = new Country(CountryCode.BA);
		
		/// <summary>
        /// BOTSWANA
        /// </summary>
		public static readonly Country BW = new Country(CountryCode.BW);
		
		/// <summary>
        /// BOUVET ISLAND
        /// </summary>
		public static readonly Country BV = new Country(CountryCode.BV);
		
		/// <summary>
        /// BRAZIL
        /// </summary>
		public static readonly Country BR = new Country(CountryCode.BR);
		
		/// <summary>
        /// BRITISH INDIAN OCEAN TERRITORY
        /// </summary>
		public static readonly Country IO = new Country(CountryCode.IO);
		
		/// <summary>
        /// BRUNEI DARUSSALAM
        /// </summary>
		public static readonly Country BN = new Country(CountryCode.BN);
		
		/// <summary>
        /// BULGARIA
        /// </summary>
		public static readonly Country BG = new Country(CountryCode.BG);
		
		/// <summary>
        /// BURKINA FASO
        /// </summary>
		public static readonly Country BF = new Country(CountryCode.BF);
		
		/// <summary>
        /// BURUNDI
        /// </summary>
		public static readonly Country BI = new Country(CountryCode.BI);
		
		/// <summary>
        /// CAMBODIA
        /// </summary>
		public static readonly Country KH = new Country(CountryCode.KH);
		
		/// <summary>
        /// CAMEROON
        /// </summary>
		public static readonly Country CM = new Country(CountryCode.CM);
		
		/// <summary>
        /// CANADA
        /// </summary>
		public static readonly Country CA = new Country(CountryCode.CA);
		
		/// <summary>
        /// CAPE VERDE
        /// </summary>
		public static readonly Country CV = new Country(CountryCode.CV);
		
		/// <summary>
        /// CAYMAN ISLANDS
        /// </summary>
		public static readonly Country KY = new Country(CountryCode.KY);
		
		/// <summary>
        /// CENTRAL AFRICAN REPUBLIC
        /// </summary>
		public static readonly Country CF = new Country(CountryCode.CF);
		
		/// <summary>
        /// CHAD
        /// </summary>
		public static readonly Country TD = new Country(CountryCode.TD);
		
		/// <summary>
        /// CHILE
        /// </summary>
		public static readonly Country CL = new Country(CountryCode.CL);
		
		/// <summary>
        /// CHINA
        /// </summary>
		public static readonly Country CN = new Country(CountryCode.CN);
		
		/// <summary>
        /// CHRISTMAS ISLAND
        /// </summary>
		public static readonly Country CX = new Country(CountryCode.CX);
		
		/// <summary>
        /// COCOS (KEELING) ISLANDS
        /// </summary>
		public static readonly Country CC = new Country(CountryCode.CC);
		
		/// <summary>
        /// COLOMBIA
        /// </summary>
		public static readonly Country CO = new Country(CountryCode.CO);
		
		/// <summary>
        /// COMOROS
        /// </summary>
		public static readonly Country KM = new Country(CountryCode.KM);
		
		/// <summary>
        /// CONGO
        /// </summary>
		public static readonly Country CG = new Country(CountryCode.CG);
		
		/// <summary>
        /// CONGO, THE DEMOCRATIC REPUBLIC OF THE
        /// </summary>
		public static readonly Country CD = new Country(CountryCode.CD);
		
		/// <summary>
        /// COOK ISLANDS
        /// </summary>
		public static readonly Country CK = new Country(CountryCode.CK);
		
		/// <summary>
        /// COSTA RICA
        /// </summary>
		public static readonly Country CR = new Country(CountryCode.CR);
		
		/// <summary>
        /// COTE D'IVOIRE
        /// </summary>
		public static readonly Country CI = new Country(CountryCode.CI);
		
		/// <summary>
        /// CROATIA
        /// </summary>
		public static readonly Country HR = new Country(CountryCode.HR);
		
		/// <summary>
        /// CUBA
        /// </summary>
		public static readonly Country CU = new Country(CountryCode.CU);
		
		/// <summary>
        /// CURACAO
        /// </summary>
		public static readonly Country CW = new Country(CountryCode.CW);
		
		/// <summary>
        /// CYPRUS
        /// </summary>
		public static readonly Country CY = new Country(CountryCode.CY);
		
		/// <summary>
        /// CZECH REPUBLIC
        /// </summary>
		public static readonly Country CZ = new Country(CountryCode.CZ);
		
		/// <summary>
        /// DENMARK
        /// </summary>
		public static readonly Country DK = new Country(CountryCode.DK);
		
		/// <summary>
        /// DJIBOUTI
        /// </summary>
		public static readonly Country DJ = new Country(CountryCode.DJ);
		
		/// <summary>
        /// DOMINICA
        /// </summary>
		public static readonly Country DM = new Country(CountryCode.DM);
		
		/// <summary>
        /// DOMINICAN REPUBLIC
        /// </summary>
		public static readonly Country DO = new Country(CountryCode.DO);
		
		/// <summary>
        /// ECUADOR
        /// </summary>
		public static readonly Country EC = new Country(CountryCode.EC);
		
		/// <summary>
        /// EGYPT
        /// </summary>
		public static readonly Country EG = new Country(CountryCode.EG);
		
		/// <summary>
        /// EL SALVADOR
        /// </summary>
		public static readonly Country SV = new Country(CountryCode.SV);
		
		/// <summary>
        /// EQUATORIAL GUINEA
        /// </summary>
		public static readonly Country GQ = new Country(CountryCode.GQ);
		
		/// <summary>
        /// ERITREA
        /// </summary>
		public static readonly Country ER = new Country(CountryCode.ER);
		
		/// <summary>
        /// ESTONIA
        /// </summary>
		public static readonly Country EE = new Country(CountryCode.EE);
		
		/// <summary>
        /// ETHIOPIA
        /// </summary>
		public static readonly Country ET = new Country(CountryCode.ET);
		
		/// <summary>
        /// FALKLAND ISLANDS (MALVINAS)
        /// </summary>
		public static readonly Country FK = new Country(CountryCode.FK);
		
		/// <summary>
        /// FAROE ISLANDS
        /// </summary>
		public static readonly Country FO = new Country(CountryCode.FO);
		
		/// <summary>
        /// FIJI
        /// </summary>
		public static readonly Country FJ = new Country(CountryCode.FJ);
		
		/// <summary>
        /// FINLAND
        /// </summary>
		public static readonly Country FI = new Country(CountryCode.FI);
		
		/// <summary>
        /// FRANCE
        /// </summary>
		public static readonly Country FR = new Country(CountryCode.FR);
		
		/// <summary>
        /// FRENCH GUIANA
        /// </summary>
		public static readonly Country GF = new Country(CountryCode.GF);
		
		/// <summary>
        /// FRENCH POLYNESIA
        /// </summary>
		public static readonly Country PF = new Country(CountryCode.PF);
		
		/// <summary>
        /// FRENCH SOUTHERN TERRITORIES
        /// </summary>
		public static readonly Country TF = new Country(CountryCode.TF);
		
		/// <summary>
        /// GABON
        /// </summary>
		public static readonly Country GA = new Country(CountryCode.GA);
		
		/// <summary>
        /// GAMBIA
        /// </summary>
		public static readonly Country GM = new Country(CountryCode.GM);
		
		/// <summary>
        /// GEORGIA
        /// </summary>
		public static readonly Country GE = new Country(CountryCode.GE);
		
		/// <summary>
        /// GERMANY
        /// </summary>
		public static readonly Country DE = new Country(CountryCode.DE);
		
		/// <summary>
        /// GHANA
        /// </summary>
		public static readonly Country GH = new Country(CountryCode.GH);
		
		/// <summary>
        /// GIBRALTAR
        /// </summary>
		public static readonly Country GI = new Country(CountryCode.GI);
		
		/// <summary>
        /// GREECE
        /// </summary>
		public static readonly Country GR = new Country(CountryCode.GR);
		
		/// <summary>
        /// GREENLAND
        /// </summary>
		public static readonly Country GL = new Country(CountryCode.GL);
		
		/// <summary>
        /// GRENADA
        /// </summary>
		public static readonly Country GD = new Country(CountryCode.GD);
		
		/// <summary>
        /// GUADELOUPE
        /// </summary>
		public static readonly Country GP = new Country(CountryCode.GP);
		
		/// <summary>
        /// GUAM
        /// </summary>
		public static readonly Country GU = new Country(CountryCode.GU);
		
		/// <summary>
        /// GUATEMALA
        /// </summary>
		public static readonly Country GT = new Country(CountryCode.GT);
		
		/// <summary>
        /// GUERNSEY
        /// </summary>
		public static readonly Country GG = new Country(CountryCode.GG);
		
		/// <summary>
        /// GUINEA
        /// </summary>
		public static readonly Country GN = new Country(CountryCode.GN);
		
		/// <summary>
        /// GUINEA-BISSAU
        /// </summary>
		public static readonly Country GW = new Country(CountryCode.GW);
		
		/// <summary>
        /// GUYANA
        /// </summary>
		public static readonly Country GY = new Country(CountryCode.GY);
		
		/// <summary>
        /// HAITI
        /// </summary>
		public static readonly Country HT = new Country(CountryCode.HT);
		
		/// <summary>
        /// HEARD ISLAND AND MCDONALD ISLANDS
        /// </summary>
		public static readonly Country HM = new Country(CountryCode.HM);
		
		/// <summary>
        /// HOLY SEE (VATICAN CITY STATE)
        /// </summary>
		public static readonly Country VA = new Country(CountryCode.VA);
		
		/// <summary>
        /// HONDURAS
        /// </summary>
		public static readonly Country HN = new Country(CountryCode.HN);
		
		/// <summary>
        /// HONG KONG
        /// </summary>
		public static readonly Country HK = new Country(CountryCode.HK);
		
		/// <summary>
        /// HUNGARY
        /// </summary>
		public static readonly Country HU = new Country(CountryCode.HU);
		
		/// <summary>
        /// ICELAND
        /// </summary>
		public static readonly Country IS = new Country(CountryCode.IS);
		
		/// <summary>
        /// INDIA
        /// </summary>
		public static readonly Country IN = new Country(CountryCode.IN);
		
		/// <summary>
        /// INDONESIA
        /// </summary>
		public static readonly Country ID = new Country(CountryCode.ID);
		
		/// <summary>
        /// IRAN, ISLAMIC REPUBLIC OF
        /// </summary>
		public static readonly Country IR = new Country(CountryCode.IR);
		
		/// <summary>
        /// IRAQ
        /// </summary>
		public static readonly Country IQ = new Country(CountryCode.IQ);
		
		/// <summary>
        /// IRELAND
        /// </summary>
		public static readonly Country IE = new Country(CountryCode.IE);
		
		/// <summary>
        /// ISLE OF MAN
        /// </summary>
		public static readonly Country IM = new Country(CountryCode.IM);
		
		/// <summary>
        /// ISRAEL
        /// </summary>
		public static readonly Country IL = new Country(CountryCode.IL);
		
		/// <summary>
        /// ITALY
        /// </summary>
		public static readonly Country IT = new Country(CountryCode.IT);
		
		/// <summary>
        /// JAMAICA
        /// </summary>
		public static readonly Country JM = new Country(CountryCode.JM);
		
		/// <summary>
        /// JAPAN
        /// </summary>
		public static readonly Country JP = new Country(CountryCode.JP);
		
		/// <summary>
        /// JERSEY
        /// </summary>
		public static readonly Country JE = new Country(CountryCode.JE);
		
		/// <summary>
        /// JORDAN
        /// </summary>
		public static readonly Country JO = new Country(CountryCode.JO);
		
		/// <summary>
        /// KAZAKHSTAN
        /// </summary>
		public static readonly Country KZ = new Country(CountryCode.KZ);
		
		/// <summary>
        /// KENYA
        /// </summary>
		public static readonly Country KE = new Country(CountryCode.KE);
		
		/// <summary>
        /// KIRIBATI
        /// </summary>
		public static readonly Country KI = new Country(CountryCode.KI);
		
		/// <summary>
        /// KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF
        /// </summary>
		public static readonly Country KP = new Country(CountryCode.KP);
		
		/// <summary>
        /// KOREA, REPUBLIC OF
        /// </summary>
		public static readonly Country KR = new Country(CountryCode.KR);
		
		/// <summary>
        /// KUWAIT
        /// </summary>
		public static readonly Country KW = new Country(CountryCode.KW);
		
		/// <summary>
        /// KYRGYZSTAN
        /// </summary>
		public static readonly Country KG = new Country(CountryCode.KG);
		
		/// <summary>
        /// LAO PEOPLE'S DEMOCRATIC REPUBLIC
        /// </summary>
		public static readonly Country LA = new Country(CountryCode.LA);
		
		/// <summary>
        /// LATVIA
        /// </summary>
		public static readonly Country LV = new Country(CountryCode.LV);
		
		/// <summary>
        /// LEBANON
        /// </summary>
		public static readonly Country LB = new Country(CountryCode.LB);
		
		/// <summary>
        /// LESOTHO
        /// </summary>
		public static readonly Country LS = new Country(CountryCode.LS);
		
		/// <summary>
        /// LIBERIA
        /// </summary>
		public static readonly Country LR = new Country(CountryCode.LR);
		
		/// <summary>
        /// LIBYAN ARAB JAMAHIRIYA
        /// </summary>
		public static readonly Country LY = new Country(CountryCode.LY);
		
		/// <summary>
        /// LIECHTENSTEIN
        /// </summary>
		public static readonly Country LI = new Country(CountryCode.LI);
		
		/// <summary>
        /// LITHUANIA
        /// </summary>
		public static readonly Country LT = new Country(CountryCode.LT);
		
		/// <summary>
        /// LUXEMBOURG
        /// </summary>
		public static readonly Country LU = new Country(CountryCode.LU);
		
		/// <summary>
        /// MACAO
        /// </summary>
		public static readonly Country MO = new Country(CountryCode.MO);
		
		/// <summary>
        /// MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF
        /// </summary>
		public static readonly Country MK = new Country(CountryCode.MK);
		
		/// <summary>
        /// MADAGASCAR
        /// </summary>
		public static readonly Country MG = new Country(CountryCode.MG);
		
		/// <summary>
        /// MALAWI
        /// </summary>
		public static readonly Country MW = new Country(CountryCode.MW);
		
		/// <summary>
        /// MALAYSIA
        /// </summary>
		public static readonly Country MY = new Country(CountryCode.MY);
		
		/// <summary>
        /// MALDIVES
        /// </summary>
		public static readonly Country MV = new Country(CountryCode.MV);
		
		/// <summary>
        /// MALI
        /// </summary>
		public static readonly Country ML = new Country(CountryCode.ML);
		
		/// <summary>
        /// MALTA
        /// </summary>
		public static readonly Country MT = new Country(CountryCode.MT);
		
		/// <summary>
        /// MARSHALL ISLANDS
        /// </summary>
		public static readonly Country MH = new Country(CountryCode.MH);
		
		/// <summary>
        /// MARTINIQUE
        /// </summary>
		public static readonly Country MQ = new Country(CountryCode.MQ);
		
		/// <summary>
        /// MAURITANIA
        /// </summary>
		public static readonly Country MR = new Country(CountryCode.MR);
		
		/// <summary>
        /// MAURITIUS
        /// </summary>
		public static readonly Country MU = new Country(CountryCode.MU);
		
		/// <summary>
        /// MAYOTTE
        /// </summary>
		public static readonly Country YT = new Country(CountryCode.YT);
		
		/// <summary>
        /// MEXICO
        /// </summary>
		public static readonly Country MX = new Country(CountryCode.MX);
		
		/// <summary>
        /// MICRONESIA, FEDERATED STATES OF
        /// </summary>
		public static readonly Country FM = new Country(CountryCode.FM);
		
		/// <summary>
        /// MOLDOVA, REPUBLIC OF
        /// </summary>
		public static readonly Country MD = new Country(CountryCode.MD);
		
		/// <summary>
        /// MONACO
        /// </summary>
		public static readonly Country MC = new Country(CountryCode.MC);
		
		/// <summary>
        /// MONGOLIA
        /// </summary>
		public static readonly Country MN = new Country(CountryCode.MN);
		
		/// <summary>
        /// MONTENEGRO
        /// </summary>
		public static readonly Country ME = new Country(CountryCode.ME);
		
		/// <summary>
        /// MONTSERRAT
        /// </summary>
		public static readonly Country MS = new Country(CountryCode.MS);
		
		/// <summary>
        /// MOROCCO
        /// </summary>
		public static readonly Country MA = new Country(CountryCode.MA);
		
		/// <summary>
        /// MOZAMBIQUE
        /// </summary>
		public static readonly Country MZ = new Country(CountryCode.MZ);
		
		/// <summary>
        /// MYANMAR
        /// </summary>
		public static readonly Country MM = new Country(CountryCode.MM);
		
		/// <summary>
        /// NAMIBIA
        /// </summary>
		public static readonly Country NA = new Country(CountryCode.NA);
		
		/// <summary>
        /// NAURU
        /// </summary>
		public static readonly Country NR = new Country(CountryCode.NR);
		
		/// <summary>
        /// NEPAL
        /// </summary>
		public static readonly Country NP = new Country(CountryCode.NP);
		
		/// <summary>
        /// NETHERLANDS
        /// </summary>
		public static readonly Country NL = new Country(CountryCode.NL);
		
		/// <summary>
        /// NEW CALEDONIA
        /// </summary>
		public static readonly Country NC = new Country(CountryCode.NC);
		
		/// <summary>
        /// NEW ZEALAND
        /// </summary>
		public static readonly Country NZ = new Country(CountryCode.NZ);
		
		/// <summary>
        /// NICARAGUA
        /// </summary>
		public static readonly Country NI = new Country(CountryCode.NI);
		
		/// <summary>
        /// NIGER
        /// </summary>
		public static readonly Country NE = new Country(CountryCode.NE);
		
		/// <summary>
        /// NIGERIA
        /// </summary>
		public static readonly Country NG = new Country(CountryCode.NG);
		
		/// <summary>
        /// NIUE
        /// </summary>
		public static readonly Country NU = new Country(CountryCode.NU);
		
		/// <summary>
        /// NORFOLK ISLAND
        /// </summary>
		public static readonly Country NF = new Country(CountryCode.NF);
		
		/// <summary>
        /// NORTHERN MARIANA ISLANDS
        /// </summary>
		public static readonly Country MP = new Country(CountryCode.MP);
		
		/// <summary>
        /// NORWAY
        /// </summary>
		public static readonly Country NO = new Country(CountryCode.NO);
		
		/// <summary>
        /// OMAN
        /// </summary>
		public static readonly Country OM = new Country(CountryCode.OM);
		
		/// <summary>
        /// PAKISTAN
        /// </summary>
		public static readonly Country PK = new Country(CountryCode.PK);
		
		/// <summary>
        /// PALAU
        /// </summary>
		public static readonly Country PW = new Country(CountryCode.PW);
		
		/// <summary>
        /// PALESTINIAN TERRITORY, OCCUPIED
        /// </summary>
		public static readonly Country PS = new Country(CountryCode.PS);
		
		/// <summary>
        /// PANAMA
        /// </summary>
		public static readonly Country PA = new Country(CountryCode.PA);
		
		/// <summary>
        /// PAPUA NEW GUINEA
        /// </summary>
		public static readonly Country PG = new Country(CountryCode.PG);
		
		/// <summary>
        /// PARAGUAY
        /// </summary>
		public static readonly Country PY = new Country(CountryCode.PY);
		
		/// <summary>
        /// PERU
        /// </summary>
		public static readonly Country PE = new Country(CountryCode.PE);
		
		/// <summary>
        /// PHILIPPINES
        /// </summary>
		public static readonly Country PH = new Country(CountryCode.PH);
		
		/// <summary>
        /// PITCAIRN
        /// </summary>
		public static readonly Country PN = new Country(CountryCode.PN);
		
		/// <summary>
        /// POLAND
        /// </summary>
		public static readonly Country PL = new Country(CountryCode.PL);
		
		/// <summary>
        /// PORTUGAL
        /// </summary>
		public static readonly Country PT = new Country(CountryCode.PT);
		
		/// <summary>
        /// PUERTO RICO
        /// </summary>
		public static readonly Country PR = new Country(CountryCode.PR);
		
		/// <summary>
        /// QATAR
        /// </summary>
		public static readonly Country QA = new Country(CountryCode.QA);
		
		/// <summary>
        /// REUNION
        /// </summary>
		public static readonly Country RE = new Country(CountryCode.RE);
		
		/// <summary>
        /// ROMANIA
        /// </summary>
		public static readonly Country RO = new Country(CountryCode.RO);
		
		/// <summary>
        /// RUSSIAN FEDERATION
        /// </summary>
		public static readonly Country RU = new Country(CountryCode.RU);
		
		/// <summary>
        /// RWANDA
        /// </summary>
		public static readonly Country RW = new Country(CountryCode.RW);
		
		/// <summary>
        /// SAINT BARTHELEMY
        /// </summary>
		public static readonly Country BL = new Country(CountryCode.BL);
		
		/// <summary>
        /// SAINT HELENA, ASCENSION AND TRISTAN DA CUNHA
        /// </summary>
		public static readonly Country SH = new Country(CountryCode.SH);
		
		/// <summary>
        /// SAINT KITTS AND NEVIS
        /// </summary>
		public static readonly Country KN = new Country(CountryCode.KN);
		
		/// <summary>
        /// SAINT LUCIA
        /// </summary>
		public static readonly Country LC = new Country(CountryCode.LC);
		
		/// <summary>
        /// SAINT MARTIN (FRENCH PART)
        /// </summary>
		public static readonly Country MF = new Country(CountryCode.MF);
		
		/// <summary>
        /// SAINT PIERRE AND MIQUELON
        /// </summary>
		public static readonly Country PM = new Country(CountryCode.PM);
		
		/// <summary>
        /// SAINT VINCENT AND THE GRENADINES
        /// </summary>
		public static readonly Country VC = new Country(CountryCode.VC);
		
		/// <summary>
        /// SAMOA
        /// </summary>
		public static readonly Country WS = new Country(CountryCode.WS);
		
		/// <summary>
        /// SAN MARINO
        /// </summary>
		public static readonly Country SM = new Country(CountryCode.SM);
		
		/// <summary>
        /// SAO TOME AND PRINCIPE
        /// </summary>
		public static readonly Country ST = new Country(CountryCode.ST);
		
		/// <summary>
        /// SAUDI ARABIA
        /// </summary>
		public static readonly Country SA = new Country(CountryCode.SA);
		
		/// <summary>
        /// SENEGAL
        /// </summary>
		public static readonly Country SN = new Country(CountryCode.SN);
		
		/// <summary>
        /// SERBIA
        /// </summary>
		public static readonly Country RS = new Country(CountryCode.RS);
		
		/// <summary>
        /// SEYCHELLES
        /// </summary>
		public static readonly Country SC = new Country(CountryCode.SC);
		
		/// <summary>
        /// SIERRA LEONE
        /// </summary>
		public static readonly Country SL = new Country(CountryCode.SL);
		
		/// <summary>
        /// SINGAPORE
        /// </summary>
		public static readonly Country SG = new Country(CountryCode.SG);
		
		/// <summary>
        /// SINT MAARTEN (DUTCH PART)
        /// </summary>
		public static readonly Country SX = new Country(CountryCode.SX);
		
		/// <summary>
        /// SLOVAKIA
        /// </summary>
		public static readonly Country SK = new Country(CountryCode.SK);
		
		/// <summary>
        /// SLOVENIA
        /// </summary>
		public static readonly Country SI = new Country(CountryCode.SI);
		
		/// <summary>
        /// SOLOMON ISLANDS
        /// </summary>
		public static readonly Country SB = new Country(CountryCode.SB);
		
		/// <summary>
        /// SOMALIA
        /// </summary>
		public static readonly Country SO = new Country(CountryCode.SO);
		
		/// <summary>
        /// SOUTH AFRICA
        /// </summary>
		public static readonly Country ZA = new Country(CountryCode.ZA);
		
		/// <summary>
        /// SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS
        /// </summary>
		public static readonly Country GS = new Country(CountryCode.GS);
		
		/// <summary>
        /// SPAIN
        /// </summary>
		public static readonly Country ES = new Country(CountryCode.ES);
		
		/// <summary>
        /// SRI LANKA
        /// </summary>
		public static readonly Country LK = new Country(CountryCode.LK);
		
		/// <summary>
        /// SUDAN
        /// </summary>
		public static readonly Country SD = new Country(CountryCode.SD);
		
		/// <summary>
        /// SURINAME
        /// </summary>
		public static readonly Country SR = new Country(CountryCode.SR);
		
		/// <summary>
        /// SVALBARD AND JAN MAYEN
        /// </summary>
		public static readonly Country SJ = new Country(CountryCode.SJ);
		
		/// <summary>
        /// SWAZILAND
        /// </summary>
		public static readonly Country SZ = new Country(CountryCode.SZ);
		
		/// <summary>
        /// SWEDEN
        /// </summary>
		public static readonly Country SE = new Country(CountryCode.SE);
		
		/// <summary>
        /// SWITZERLAND
        /// </summary>
		public static readonly Country CH = new Country(CountryCode.CH);
		
		/// <summary>
        /// SYRIAN ARAB REPUBLIC
        /// </summary>
		public static readonly Country SY = new Country(CountryCode.SY);
		
		/// <summary>
        /// TAIWAN, PROVINCE OF CHINA
        /// </summary>
		public static readonly Country TW = new Country(CountryCode.TW);
		
		/// <summary>
        /// TAJIKISTAN
        /// </summary>
		public static readonly Country TJ = new Country(CountryCode.TJ);
		
		/// <summary>
        /// TANZANIA, UNITED REPUBLIC OF
        /// </summary>
		public static readonly Country TZ = new Country(CountryCode.TZ);
		
		/// <summary>
        /// THAILAND
        /// </summary>
		public static readonly Country TH = new Country(CountryCode.TH);
		
		/// <summary>
        /// TIMOR-LESTE
        /// </summary>
		public static readonly Country TL = new Country(CountryCode.TL);
		
		/// <summary>
        /// TOGO
        /// </summary>
		public static readonly Country TG = new Country(CountryCode.TG);
		
		/// <summary>
        /// TOKELAU
        /// </summary>
		public static readonly Country TK = new Country(CountryCode.TK);
		
		/// <summary>
        /// TONGA
        /// </summary>
		public static readonly Country TO = new Country(CountryCode.TO);
		
		/// <summary>
        /// TRINIDAD AND TOBAGO
        /// </summary>
		public static readonly Country TT = new Country(CountryCode.TT);
		
		/// <summary>
        /// TUNISIA
        /// </summary>
		public static readonly Country TN = new Country(CountryCode.TN);
		
		/// <summary>
        /// TURKEY
        /// </summary>
		public static readonly Country TR = new Country(CountryCode.TR);
		
		/// <summary>
        /// TURKMENISTAN
        /// </summary>
		public static readonly Country TM = new Country(CountryCode.TM);
		
		/// <summary>
        /// TURKS AND CAICOS ISLANDS
        /// </summary>
		public static readonly Country TC = new Country(CountryCode.TC);
		
		/// <summary>
        /// TUVALU
        /// </summary>
		public static readonly Country TV = new Country(CountryCode.TV);
		
		/// <summary>
        /// UGANDA
        /// </summary>
		public static readonly Country UG = new Country(CountryCode.UG);
		
		/// <summary>
        /// UKRAINE
        /// </summary>
		public static readonly Country UA = new Country(CountryCode.UA);
		
		/// <summary>
        /// UNITED ARAB EMIRATES
        /// </summary>
		public static readonly Country AE = new Country(CountryCode.AE);
		
		/// <summary>
        /// UNITED KINGDOM
        /// </summary>
		public static readonly Country GB = new Country(CountryCode.GB);
		
		/// <summary>
        /// UNITED STATES
        /// </summary>
		public static readonly Country US = new Country(CountryCode.US);
		
		/// <summary>
        /// UNITED STATES MINOR OUTLYING ISLANDS
        /// </summary>
		public static readonly Country UM = new Country(CountryCode.UM);
		
		/// <summary>
        /// URUGUAY
        /// </summary>
		public static readonly Country UY = new Country(CountryCode.UY);
		
		/// <summary>
        /// UZBEKISTAN
        /// </summary>
		public static readonly Country UZ = new Country(CountryCode.UZ);
		
		/// <summary>
        /// VANUATU
        /// </summary>
		public static readonly Country VU = new Country(CountryCode.VU);
		
		/// <summary>
        /// VENEZUELA, BOLIVARIAN REPUBLIC OF
        /// </summary>
		public static readonly Country VE = new Country(CountryCode.VE);
		
		/// <summary>
        /// VIET NAM
        /// </summary>
		public static readonly Country VN = new Country(CountryCode.VN);
		
		/// <summary>
        /// VIRGIN ISLANDS, BRITISH
        /// </summary>
		public static readonly Country VG = new Country(CountryCode.VG);
		
		/// <summary>
        /// VIRGIN ISLANDS, U.S.
        /// </summary>
		public static readonly Country VI = new Country(CountryCode.VI);
		
		/// <summary>
        /// WALLIS AND FUTUNA
        /// </summary>
		public static readonly Country WF = new Country(CountryCode.WF);
		
		/// <summary>
        /// WESTERN SAHARA
        /// </summary>
		public static readonly Country EH = new Country(CountryCode.EH);
		
		/// <summary>
        /// YEMEN
        /// </summary>
		public static readonly Country YE = new Country(CountryCode.YE);
		
		/// <summary>
        /// ZAMBIA
        /// </summary>
		public static readonly Country ZM = new Country(CountryCode.ZM);
		
		/// <summary>
        /// ZIMBABWE
        /// </summary>
		public static readonly Country ZW = new Country(CountryCode.ZW);
		
		/// <summary>
        /// APO/FPO
        /// </summary>
		public static readonly Country AA = new Country(CountryCode.AA);
						
		#endregion		

        static Country()
        {            
            allCountries = new Country[] {													
			AF,AX,AL,DZ,AS,AD,AO,AI,AQ,AG,AR,AM,AW,AU,AT,AZ,BS,BH,BD,BB,BY,BE,BZ,BJ,BM,BT,BO,BQ,BA,BW,BV,BR,IO,BN,BG,BF,BI,KH,CM,CA,CV,KY,CF,TD,CL,CN,CX,CC,CO,KM,CG,CD,CK,CR,CI,HR,CU,CW,CY,CZ,DK,DJ,DM,DO,EC,EG,SV,GQ,ER,EE,ET,FK,FO,FJ,FI,FR,GF,PF,TF,GA,GM,GE,DE,GH,GI,GR,GL,GD,GP,GU,GT,GG,GN,GW,GY,HT,HM,VA,HN,HK,HU,IS,IN,ID,IR,IQ,IE,IM,IL,IT,JM,JP,JE,JO,KZ,KE,KI,KP,KR,KW,KG,LA,LV,LB,LS,LR,LY,LI,LT,LU,MO,MK,MG,MW,MY,MV,ML,MT,MH,MQ,MR,MU,YT,MX,FM,MD,MC,MN,ME,MS,MA,MZ,MM,NA,NR,NP,NL,NC,NZ,NI,NE,NG,NU,NF,MP,NO,OM,PK,PW,PS,PA,PG,PY,PE,PH,PN,PL,PT,PR,QA,RE,RO,RU,RW,BL,SH,KN,LC,MF,PM,VC,WS,SM,ST,SA,SN,RS,SC,SL,SG,SX,SK,SI,SB,SO,ZA,GS,ES,LK,SD,SR,SJ,SZ,SE,CH,SY,TW,TJ,TZ,TH,TL,TG,TK,TO,TT,TN,TR,TM,TC,TV,UG,UA,AE,GB,US,UM,UY,UZ,VU,VE,VN,VG,VI,WF,EH,YE,ZM,ZW,AA,							
            };
            allCountries = allCountries.OrderBy(c => c.Code).ToArray();                       
        }
	} // end of class Country

	
	/// <summary>
    /// Defines country/region codes. The names in this enum conform to 2-letter code in ISO 3166.
    /// </summary>
	/// <remarks>
	/// It is intended for simply referencing the country code and programming convenient to define this enum.
	/// The underlying numeric value of this enum is meaningless in the business, so don't use their numeric values
	/// in the business operations.
	/// </remarks>
	[Serializable]
	public enum CountryCode
	{
		/*/// <summary>
        /// Unknown country code		
        /// </summary>
		/// <remark>
		/// This entry is intended to work around the .NET enum annoying default value. should never be used in the appliation.
		/// </remark>
		//[EnumMember]
		//Unknown = 0,*/

		#region well-known
		
		/// <summary>
        /// AFGHANISTAN
        /// </summary>
		[EnumMember]
		AF = 1,
		
		/// <summary>
        /// ALAND ISLANDS
        /// </summary>
		[EnumMember]
		AX = 2,
		
		/// <summary>
        /// ALBANIA
        /// </summary>
		[EnumMember]
		AL = 3,
		
		/// <summary>
        /// ALGERIA
        /// </summary>
		[EnumMember]
		DZ = 4,
		
		/// <summary>
        /// AMERICAN SAMOA
        /// </summary>
		[EnumMember]
		AS = 5,
		
		/// <summary>
        /// ANDORRA
        /// </summary>
		[EnumMember]
		AD = 6,
		
		/// <summary>
        /// ANGOLA
        /// </summary>
		[EnumMember]
		AO = 7,
		
		/// <summary>
        /// ANGUILLA
        /// </summary>
		[EnumMember]
		AI = 8,
		
		/// <summary>
        /// ANTARCTICA
        /// </summary>
		[EnumMember]
		AQ = 9,
		
		/// <summary>
        /// ANTIGUA AND BARBUDA
        /// </summary>
		[EnumMember]
		AG = 10,
		
		/// <summary>
        /// ARGENTINA
        /// </summary>
		[EnumMember]
		AR = 11,
		
		/// <summary>
        /// ARMENIA
        /// </summary>
		[EnumMember]
		AM = 12,
		
		/// <summary>
        /// ARUBA
        /// </summary>
		[EnumMember]
		AW = 13,
		
		/// <summary>
        /// AUSTRALIA
        /// </summary>
		[EnumMember]
		AU = 14,
		
		/// <summary>
        /// AUSTRIA
        /// </summary>
		[EnumMember]
		AT = 15,
		
		/// <summary>
        /// AZERBAIJAN
        /// </summary>
		[EnumMember]
		AZ = 16,
		
		/// <summary>
        /// BAHAMAS
        /// </summary>
		[EnumMember]
		BS = 17,
		
		/// <summary>
        /// BAHRAIN
        /// </summary>
		[EnumMember]
		BH = 18,
		
		/// <summary>
        /// BANGLADESH
        /// </summary>
		[EnumMember]
		BD = 19,
		
		/// <summary>
        /// BARBADOS
        /// </summary>
		[EnumMember]
		BB = 20,
		
		/// <summary>
        /// BELARUS
        /// </summary>
		[EnumMember]
		BY = 21,
		
		/// <summary>
        /// BELGIUM
        /// </summary>
		[EnumMember]
		BE = 22,
		
		/// <summary>
        /// BELIZE
        /// </summary>
		[EnumMember]
		BZ = 23,
		
		/// <summary>
        /// BENIN
        /// </summary>
		[EnumMember]
		BJ = 24,
		
		/// <summary>
        /// BERMUDA
        /// </summary>
		[EnumMember]
		BM = 25,
		
		/// <summary>
        /// BHUTAN
        /// </summary>
		[EnumMember]
		BT = 26,
		
		/// <summary>
        /// BOLIVIA, PLURINATIONAL STATE OF
        /// </summary>
		[EnumMember]
		BO = 27,
		
		/// <summary>
        /// BONAIRE, SAINT EUSTATIUS AND SABA
        /// </summary>
		[EnumMember]
		BQ = 28,
		
		/// <summary>
        /// BOSNIA AND HERZEGOVINA
        /// </summary>
		[EnumMember]
		BA = 29,
		
		/// <summary>
        /// BOTSWANA
        /// </summary>
		[EnumMember]
		BW = 30,
		
		/// <summary>
        /// BOUVET ISLAND
        /// </summary>
		[EnumMember]
		BV = 31,
		
		/// <summary>
        /// BRAZIL
        /// </summary>
		[EnumMember]
		BR = 32,
		
		/// <summary>
        /// BRITISH INDIAN OCEAN TERRITORY
        /// </summary>
		[EnumMember]
		IO = 33,
		
		/// <summary>
        /// BRUNEI DARUSSALAM
        /// </summary>
		[EnumMember]
		BN = 34,
		
		/// <summary>
        /// BULGARIA
        /// </summary>
		[EnumMember]
		BG = 35,
		
		/// <summary>
        /// BURKINA FASO
        /// </summary>
		[EnumMember]
		BF = 36,
		
		/// <summary>
        /// BURUNDI
        /// </summary>
		[EnumMember]
		BI = 37,
		
		/// <summary>
        /// CAMBODIA
        /// </summary>
		[EnumMember]
		KH = 38,
		
		/// <summary>
        /// CAMEROON
        /// </summary>
		[EnumMember]
		CM = 39,
		
		/// <summary>
        /// CANADA
        /// </summary>
		[EnumMember]
		CA = 40,
		
		/// <summary>
        /// CAPE VERDE
        /// </summary>
		[EnumMember]
		CV = 41,
		
		/// <summary>
        /// CAYMAN ISLANDS
        /// </summary>
		[EnumMember]
		KY = 42,
		
		/// <summary>
        /// CENTRAL AFRICAN REPUBLIC
        /// </summary>
		[EnumMember]
		CF = 43,
		
		/// <summary>
        /// CHAD
        /// </summary>
		[EnumMember]
		TD = 44,
		
		/// <summary>
        /// CHILE
        /// </summary>
		[EnumMember]
		CL = 45,
		
		/// <summary>
        /// CHINA
        /// </summary>
		[EnumMember]
		CN = 46,
		
		/// <summary>
        /// CHRISTMAS ISLAND
        /// </summary>
		[EnumMember]
		CX = 47,
		
		/// <summary>
        /// COCOS (KEELING) ISLANDS
        /// </summary>
		[EnumMember]
		CC = 48,
		
		/// <summary>
        /// COLOMBIA
        /// </summary>
		[EnumMember]
		CO = 49,
		
		/// <summary>
        /// COMOROS
        /// </summary>
		[EnumMember]
		KM = 50,
		
		/// <summary>
        /// CONGO
        /// </summary>
		[EnumMember]
		CG = 51,
		
		/// <summary>
        /// CONGO, THE DEMOCRATIC REPUBLIC OF THE
        /// </summary>
		[EnumMember]
		CD = 52,
		
		/// <summary>
        /// COOK ISLANDS
        /// </summary>
		[EnumMember]
		CK = 53,
		
		/// <summary>
        /// COSTA RICA
        /// </summary>
		[EnumMember]
		CR = 54,
		
		/// <summary>
        /// COTE D'IVOIRE
        /// </summary>
		[EnumMember]
		CI = 55,
		
		/// <summary>
        /// CROATIA
        /// </summary>
		[EnumMember]
		HR = 56,
		
		/// <summary>
        /// CUBA
        /// </summary>
		[EnumMember]
		CU = 57,
		
		/// <summary>
        /// CURACAO
        /// </summary>
		[EnumMember]
		CW = 58,
		
		/// <summary>
        /// CYPRUS
        /// </summary>
		[EnumMember]
		CY = 59,
		
		/// <summary>
        /// CZECH REPUBLIC
        /// </summary>
		[EnumMember]
		CZ = 60,
		
		/// <summary>
        /// DENMARK
        /// </summary>
		[EnumMember]
		DK = 61,
		
		/// <summary>
        /// DJIBOUTI
        /// </summary>
		[EnumMember]
		DJ = 62,
		
		/// <summary>
        /// DOMINICA
        /// </summary>
		[EnumMember]
		DM = 63,
		
		/// <summary>
        /// DOMINICAN REPUBLIC
        /// </summary>
		[EnumMember]
		DO = 64,
		
		/// <summary>
        /// ECUADOR
        /// </summary>
		[EnumMember]
		EC = 65,
		
		/// <summary>
        /// EGYPT
        /// </summary>
		[EnumMember]
		EG = 66,
		
		/// <summary>
        /// EL SALVADOR
        /// </summary>
		[EnumMember]
		SV = 67,
		
		/// <summary>
        /// EQUATORIAL GUINEA
        /// </summary>
		[EnumMember]
		GQ = 68,
		
		/// <summary>
        /// ERITREA
        /// </summary>
		[EnumMember]
		ER = 69,
		
		/// <summary>
        /// ESTONIA
        /// </summary>
		[EnumMember]
		EE = 70,
		
		/// <summary>
        /// ETHIOPIA
        /// </summary>
		[EnumMember]
		ET = 71,
		
		/// <summary>
        /// FALKLAND ISLANDS (MALVINAS)
        /// </summary>
		[EnumMember]
		FK = 72,
		
		/// <summary>
        /// FAROE ISLANDS
        /// </summary>
		[EnumMember]
		FO = 73,
		
		/// <summary>
        /// FIJI
        /// </summary>
		[EnumMember]
		FJ = 74,
		
		/// <summary>
        /// FINLAND
        /// </summary>
		[EnumMember]
		FI = 75,
		
		/// <summary>
        /// FRANCE
        /// </summary>
		[EnumMember]
		FR = 76,
		
		/// <summary>
        /// FRENCH GUIANA
        /// </summary>
		[EnumMember]
		GF = 77,
		
		/// <summary>
        /// FRENCH POLYNESIA
        /// </summary>
		[EnumMember]
		PF = 78,
		
		/// <summary>
        /// FRENCH SOUTHERN TERRITORIES
        /// </summary>
		[EnumMember]
		TF = 79,
		
		/// <summary>
        /// GABON
        /// </summary>
		[EnumMember]
		GA = 80,
		
		/// <summary>
        /// GAMBIA
        /// </summary>
		[EnumMember]
		GM = 81,
		
		/// <summary>
        /// GEORGIA
        /// </summary>
		[EnumMember]
		GE = 82,
		
		/// <summary>
        /// GERMANY
        /// </summary>
		[EnumMember]
		DE = 83,
		
		/// <summary>
        /// GHANA
        /// </summary>
		[EnumMember]
		GH = 84,
		
		/// <summary>
        /// GIBRALTAR
        /// </summary>
		[EnumMember]
		GI = 85,
		
		/// <summary>
        /// GREECE
        /// </summary>
		[EnumMember]
		GR = 86,
		
		/// <summary>
        /// GREENLAND
        /// </summary>
		[EnumMember]
		GL = 87,
		
		/// <summary>
        /// GRENADA
        /// </summary>
		[EnumMember]
		GD = 88,
		
		/// <summary>
        /// GUADELOUPE
        /// </summary>
		[EnumMember]
		GP = 89,
		
		/// <summary>
        /// GUAM
        /// </summary>
		[EnumMember]
		GU = 90,
		
		/// <summary>
        /// GUATEMALA
        /// </summary>
		[EnumMember]
		GT = 91,
		
		/// <summary>
        /// GUERNSEY
        /// </summary>
		[EnumMember]
		GG = 92,
		
		/// <summary>
        /// GUINEA
        /// </summary>
		[EnumMember]
		GN = 93,
		
		/// <summary>
        /// GUINEA-BISSAU
        /// </summary>
		[EnumMember]
		GW = 94,
		
		/// <summary>
        /// GUYANA
        /// </summary>
		[EnumMember]
		GY = 95,
		
		/// <summary>
        /// HAITI
        /// </summary>
		[EnumMember]
		HT = 96,
		
		/// <summary>
        /// HEARD ISLAND AND MCDONALD ISLANDS
        /// </summary>
		[EnumMember]
		HM = 97,
		
		/// <summary>
        /// HOLY SEE (VATICAN CITY STATE)
        /// </summary>
		[EnumMember]
		VA = 98,
		
		/// <summary>
        /// HONDURAS
        /// </summary>
		[EnumMember]
		HN = 99,
		
		/// <summary>
        /// HONG KONG
        /// </summary>
		[EnumMember]
		HK = 100,
		
		/// <summary>
        /// HUNGARY
        /// </summary>
		[EnumMember]
		HU = 101,
		
		/// <summary>
        /// ICELAND
        /// </summary>
		[EnumMember]
		IS = 102,
		
		/// <summary>
        /// INDIA
        /// </summary>
		[EnumMember]
		IN = 103,
		
		/// <summary>
        /// INDONESIA
        /// </summary>
		[EnumMember]
		ID = 104,
		
		/// <summary>
        /// IRAN, ISLAMIC REPUBLIC OF
        /// </summary>
		[EnumMember]
		IR = 105,
		
		/// <summary>
        /// IRAQ
        /// </summary>
		[EnumMember]
		IQ = 106,
		
		/// <summary>
        /// IRELAND
        /// </summary>
		[EnumMember]
		IE = 107,
		
		/// <summary>
        /// ISLE OF MAN
        /// </summary>
		[EnumMember]
		IM = 108,
		
		/// <summary>
        /// ISRAEL
        /// </summary>
		[EnumMember]
		IL = 109,
		
		/// <summary>
        /// ITALY
        /// </summary>
		[EnumMember]
		IT = 110,
		
		/// <summary>
        /// JAMAICA
        /// </summary>
		[EnumMember]
		JM = 111,
		
		/// <summary>
        /// JAPAN
        /// </summary>
		[EnumMember]
		JP = 112,
		
		/// <summary>
        /// JERSEY
        /// </summary>
		[EnumMember]
		JE = 113,
		
		/// <summary>
        /// JORDAN
        /// </summary>
		[EnumMember]
		JO = 114,
		
		/// <summary>
        /// KAZAKHSTAN
        /// </summary>
		[EnumMember]
		KZ = 115,
		
		/// <summary>
        /// KENYA
        /// </summary>
		[EnumMember]
		KE = 116,
		
		/// <summary>
        /// KIRIBATI
        /// </summary>
		[EnumMember]
		KI = 117,
		
		/// <summary>
        /// KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF
        /// </summary>
		[EnumMember]
		KP = 118,
		
		/// <summary>
        /// KOREA, REPUBLIC OF
        /// </summary>
		[EnumMember]
		KR = 119,
		
		/// <summary>
        /// KUWAIT
        /// </summary>
		[EnumMember]
		KW = 120,
		
		/// <summary>
        /// KYRGYZSTAN
        /// </summary>
		[EnumMember]
		KG = 121,
		
		/// <summary>
        /// LAO PEOPLE'S DEMOCRATIC REPUBLIC
        /// </summary>
		[EnumMember]
		LA = 122,
		
		/// <summary>
        /// LATVIA
        /// </summary>
		[EnumMember]
		LV = 123,
		
		/// <summary>
        /// LEBANON
        /// </summary>
		[EnumMember]
		LB = 124,
		
		/// <summary>
        /// LESOTHO
        /// </summary>
		[EnumMember]
		LS = 125,
		
		/// <summary>
        /// LIBERIA
        /// </summary>
		[EnumMember]
		LR = 126,
		
		/// <summary>
        /// LIBYAN ARAB JAMAHIRIYA
        /// </summary>
		[EnumMember]
		LY = 127,
		
		/// <summary>
        /// LIECHTENSTEIN
        /// </summary>
		[EnumMember]
		LI = 128,
		
		/// <summary>
        /// LITHUANIA
        /// </summary>
		[EnumMember]
		LT = 129,
		
		/// <summary>
        /// LUXEMBOURG
        /// </summary>
		[EnumMember]
		LU = 130,
		
		/// <summary>
        /// MACAO
        /// </summary>
		[EnumMember]
		MO = 131,
		
		/// <summary>
        /// MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF
        /// </summary>
		[EnumMember]
		MK = 132,
		
		/// <summary>
        /// MADAGASCAR
        /// </summary>
		[EnumMember]
		MG = 133,
		
		/// <summary>
        /// MALAWI
        /// </summary>
		[EnumMember]
		MW = 134,
		
		/// <summary>
        /// MALAYSIA
        /// </summary>
		[EnumMember]
		MY = 135,
		
		/// <summary>
        /// MALDIVES
        /// </summary>
		[EnumMember]
		MV = 136,
		
		/// <summary>
        /// MALI
        /// </summary>
		[EnumMember]
		ML = 137,
		
		/// <summary>
        /// MALTA
        /// </summary>
		[EnumMember]
		MT = 138,
		
		/// <summary>
        /// MARSHALL ISLANDS
        /// </summary>
		[EnumMember]
		MH = 139,
		
		/// <summary>
        /// MARTINIQUE
        /// </summary>
		[EnumMember]
		MQ = 140,
		
		/// <summary>
        /// MAURITANIA
        /// </summary>
		[EnumMember]
		MR = 141,
		
		/// <summary>
        /// MAURITIUS
        /// </summary>
		[EnumMember]
		MU = 142,
		
		/// <summary>
        /// MAYOTTE
        /// </summary>
		[EnumMember]
		YT = 143,
		
		/// <summary>
        /// MEXICO
        /// </summary>
		[EnumMember]
		MX = 144,
		
		/// <summary>
        /// MICRONESIA, FEDERATED STATES OF
        /// </summary>
		[EnumMember]
		FM = 145,
		
		/// <summary>
        /// MOLDOVA, REPUBLIC OF
        /// </summary>
		[EnumMember]
		MD = 146,
		
		/// <summary>
        /// MONACO
        /// </summary>
		[EnumMember]
		MC = 147,
		
		/// <summary>
        /// MONGOLIA
        /// </summary>
		[EnumMember]
		MN = 148,
		
		/// <summary>
        /// MONTENEGRO
        /// </summary>
		[EnumMember]
		ME = 149,
		
		/// <summary>
        /// MONTSERRAT
        /// </summary>
		[EnumMember]
		MS = 150,
		
		/// <summary>
        /// MOROCCO
        /// </summary>
		[EnumMember]
		MA = 151,
		
		/// <summary>
        /// MOZAMBIQUE
        /// </summary>
		[EnumMember]
		MZ = 152,
		
		/// <summary>
        /// MYANMAR
        /// </summary>
		[EnumMember]
		MM = 153,
		
		/// <summary>
        /// NAMIBIA
        /// </summary>
		[EnumMember]
		NA = 154,
		
		/// <summary>
        /// NAURU
        /// </summary>
		[EnumMember]
		NR = 155,
		
		/// <summary>
        /// NEPAL
        /// </summary>
		[EnumMember]
		NP = 156,
		
		/// <summary>
        /// NETHERLANDS
        /// </summary>
		[EnumMember]
		NL = 157,
		
		/// <summary>
        /// NEW CALEDONIA
        /// </summary>
		[EnumMember]
		NC = 158,
		
		/// <summary>
        /// NEW ZEALAND
        /// </summary>
		[EnumMember]
		NZ = 159,
		
		/// <summary>
        /// NICARAGUA
        /// </summary>
		[EnumMember]
		NI = 160,
		
		/// <summary>
        /// NIGER
        /// </summary>
		[EnumMember]
		NE = 161,
		
		/// <summary>
        /// NIGERIA
        /// </summary>
		[EnumMember]
		NG = 162,
		
		/// <summary>
        /// NIUE
        /// </summary>
		[EnumMember]
		NU = 163,
		
		/// <summary>
        /// NORFOLK ISLAND
        /// </summary>
		[EnumMember]
		NF = 164,
		
		/// <summary>
        /// NORTHERN MARIANA ISLANDS
        /// </summary>
		[EnumMember]
		MP = 165,
		
		/// <summary>
        /// NORWAY
        /// </summary>
		[EnumMember]
		NO = 166,
		
		/// <summary>
        /// OMAN
        /// </summary>
		[EnumMember]
		OM = 167,
		
		/// <summary>
        /// PAKISTAN
        /// </summary>
		[EnumMember]
		PK = 168,
		
		/// <summary>
        /// PALAU
        /// </summary>
		[EnumMember]
		PW = 169,
		
		/// <summary>
        /// PALESTINIAN TERRITORY, OCCUPIED
        /// </summary>
		[EnumMember]
		PS = 170,
		
		/// <summary>
        /// PANAMA
        /// </summary>
		[EnumMember]
		PA = 171,
		
		/// <summary>
        /// PAPUA NEW GUINEA
        /// </summary>
		[EnumMember]
		PG = 172,
		
		/// <summary>
        /// PARAGUAY
        /// </summary>
		[EnumMember]
		PY = 173,
		
		/// <summary>
        /// PERU
        /// </summary>
		[EnumMember]
		PE = 174,
		
		/// <summary>
        /// PHILIPPINES
        /// </summary>
		[EnumMember]
		PH = 175,
		
		/// <summary>
        /// PITCAIRN
        /// </summary>
		[EnumMember]
		PN = 176,
		
		/// <summary>
        /// POLAND
        /// </summary>
		[EnumMember]
		PL = 177,
		
		/// <summary>
        /// PORTUGAL
        /// </summary>
		[EnumMember]
		PT = 178,
		
		/// <summary>
        /// PUERTO RICO
        /// </summary>
		[EnumMember]
		PR = 179,
		
		/// <summary>
        /// QATAR
        /// </summary>
		[EnumMember]
		QA = 180,
		
		/// <summary>
        /// REUNION
        /// </summary>
		[EnumMember]
		RE = 181,
		
		/// <summary>
        /// ROMANIA
        /// </summary>
		[EnumMember]
		RO = 182,
		
		/// <summary>
        /// RUSSIAN FEDERATION
        /// </summary>
		[EnumMember]
		RU = 183,
		
		/// <summary>
        /// RWANDA
        /// </summary>
		[EnumMember]
		RW = 184,
		
		/// <summary>
        /// SAINT BARTHELEMY
        /// </summary>
		[EnumMember]
		BL = 185,
		
		/// <summary>
        /// SAINT HELENA, ASCENSION AND TRISTAN DA CUNHA
        /// </summary>
		[EnumMember]
		SH = 186,
		
		/// <summary>
        /// SAINT KITTS AND NEVIS
        /// </summary>
		[EnumMember]
		KN = 187,
		
		/// <summary>
        /// SAINT LUCIA
        /// </summary>
		[EnumMember]
		LC = 188,
		
		/// <summary>
        /// SAINT MARTIN (FRENCH PART)
        /// </summary>
		[EnumMember]
		MF = 189,
		
		/// <summary>
        /// SAINT PIERRE AND MIQUELON
        /// </summary>
		[EnumMember]
		PM = 190,
		
		/// <summary>
        /// SAINT VINCENT AND THE GRENADINES
        /// </summary>
		[EnumMember]
		VC = 191,
		
		/// <summary>
        /// SAMOA
        /// </summary>
		[EnumMember]
		WS = 192,
		
		/// <summary>
        /// SAN MARINO
        /// </summary>
		[EnumMember]
		SM = 193,
		
		/// <summary>
        /// SAO TOME AND PRINCIPE
        /// </summary>
		[EnumMember]
		ST = 194,
		
		/// <summary>
        /// SAUDI ARABIA
        /// </summary>
		[EnumMember]
		SA = 195,
		
		/// <summary>
        /// SENEGAL
        /// </summary>
		[EnumMember]
		SN = 196,
		
		/// <summary>
        /// SERBIA
        /// </summary>
		[EnumMember]
		RS = 197,
		
		/// <summary>
        /// SEYCHELLES
        /// </summary>
		[EnumMember]
		SC = 198,
		
		/// <summary>
        /// SIERRA LEONE
        /// </summary>
		[EnumMember]
		SL = 199,
		
		/// <summary>
        /// SINGAPORE
        /// </summary>
		[EnumMember]
		SG = 200,
		
		/// <summary>
        /// SINT MAARTEN (DUTCH PART)
        /// </summary>
		[EnumMember]
		SX = 201,
		
		/// <summary>
        /// SLOVAKIA
        /// </summary>
		[EnumMember]
		SK = 202,
		
		/// <summary>
        /// SLOVENIA
        /// </summary>
		[EnumMember]
		SI = 203,
		
		/// <summary>
        /// SOLOMON ISLANDS
        /// </summary>
		[EnumMember]
		SB = 204,
		
		/// <summary>
        /// SOMALIA
        /// </summary>
		[EnumMember]
		SO = 205,
		
		/// <summary>
        /// SOUTH AFRICA
        /// </summary>
		[EnumMember]
		ZA = 206,
		
		/// <summary>
        /// SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS
        /// </summary>
		[EnumMember]
		GS = 207,
		
		/// <summary>
        /// SPAIN
        /// </summary>
		[EnumMember]
		ES = 208,
		
		/// <summary>
        /// SRI LANKA
        /// </summary>
		[EnumMember]
		LK = 209,
		
		/// <summary>
        /// SUDAN
        /// </summary>
		[EnumMember]
		SD = 210,
		
		/// <summary>
        /// SURINAME
        /// </summary>
		[EnumMember]
		SR = 211,
		
		/// <summary>
        /// SVALBARD AND JAN MAYEN
        /// </summary>
		[EnumMember]
		SJ = 212,
		
		/// <summary>
        /// SWAZILAND
        /// </summary>
		[EnumMember]
		SZ = 213,
		
		/// <summary>
        /// SWEDEN
        /// </summary>
		[EnumMember]
		SE = 214,
		
		/// <summary>
        /// SWITZERLAND
        /// </summary>
		[EnumMember]
		CH = 215,
		
		/// <summary>
        /// SYRIAN ARAB REPUBLIC
        /// </summary>
		[EnumMember]
		SY = 216,
		
		/// <summary>
        /// TAIWAN, PROVINCE OF CHINA
        /// </summary>
		[EnumMember]
		TW = 217,
		
		/// <summary>
        /// TAJIKISTAN
        /// </summary>
		[EnumMember]
		TJ = 218,
		
		/// <summary>
        /// TANZANIA, UNITED REPUBLIC OF
        /// </summary>
		[EnumMember]
		TZ = 219,
		
		/// <summary>
        /// THAILAND
        /// </summary>
		[EnumMember]
		TH = 220,
		
		/// <summary>
        /// TIMOR-LESTE
        /// </summary>
		[EnumMember]
		TL = 221,
		
		/// <summary>
        /// TOGO
        /// </summary>
		[EnumMember]
		TG = 222,
		
		/// <summary>
        /// TOKELAU
        /// </summary>
		[EnumMember]
		TK = 223,
		
		/// <summary>
        /// TONGA
        /// </summary>
		[EnumMember]
		TO = 224,
		
		/// <summary>
        /// TRINIDAD AND TOBAGO
        /// </summary>
		[EnumMember]
		TT = 225,
		
		/// <summary>
        /// TUNISIA
        /// </summary>
		[EnumMember]
		TN = 226,
		
		/// <summary>
        /// TURKEY
        /// </summary>
		[EnumMember]
		TR = 227,
		
		/// <summary>
        /// TURKMENISTAN
        /// </summary>
		[EnumMember]
		TM = 228,
		
		/// <summary>
        /// TURKS AND CAICOS ISLANDS
        /// </summary>
		[EnumMember]
		TC = 229,
		
		/// <summary>
        /// TUVALU
        /// </summary>
		[EnumMember]
		TV = 230,
		
		/// <summary>
        /// UGANDA
        /// </summary>
		[EnumMember]
		UG = 231,
		
		/// <summary>
        /// UKRAINE
        /// </summary>
		[EnumMember]
		UA = 232,
		
		/// <summary>
        /// UNITED ARAB EMIRATES
        /// </summary>
		[EnumMember]
		AE = 233,
		
		/// <summary>
        /// UNITED KINGDOM
        /// </summary>
		[EnumMember]
		GB = 234,
		
		/// <summary>
        /// UNITED STATES
        /// </summary>
		[EnumMember]
		US = 235,
		
		/// <summary>
        /// UNITED STATES MINOR OUTLYING ISLANDS
        /// </summary>
		[EnumMember]
		UM = 236,
		
		/// <summary>
        /// URUGUAY
        /// </summary>
		[EnumMember]
		UY = 237,
		
		/// <summary>
        /// UZBEKISTAN
        /// </summary>
		[EnumMember]
		UZ = 238,
		
		/// <summary>
        /// VANUATU
        /// </summary>
		[EnumMember]
		VU = 239,
		
		/// <summary>
        /// VENEZUELA, BOLIVARIAN REPUBLIC OF
        /// </summary>
		[EnumMember]
		VE = 240,
		
		/// <summary>
        /// VIET NAM
        /// </summary>
		[EnumMember]
		VN = 241,
		
		/// <summary>
        /// VIRGIN ISLANDS, BRITISH
        /// </summary>
		[EnumMember]
		VG = 242,
		
		/// <summary>
        /// VIRGIN ISLANDS, U.S.
        /// </summary>
		[EnumMember]
		VI = 243,
		
		/// <summary>
        /// WALLIS AND FUTUNA
        /// </summary>
		[EnumMember]
		WF = 244,
		
		/// <summary>
        /// WESTERN SAHARA
        /// </summary>
		[EnumMember]
		EH = 245,
		
		/// <summary>
        /// YEMEN
        /// </summary>
		[EnumMember]
		YE = 246,
		
		/// <summary>
        /// ZAMBIA
        /// </summary>
		[EnumMember]
		ZM = 247,
		
		/// <summary>
        /// ZIMBABWE
        /// </summary>
		[EnumMember]
		ZW = 248,
		
		/// <summary>
        /// APO/FPO
        /// </summary>
		[EnumMember]
		AA = 249,
						
		#endregion		
	
	}
}