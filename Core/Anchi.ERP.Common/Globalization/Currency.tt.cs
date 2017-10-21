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
	public partial class Currency
	{
		#region well-known
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AED = new Currency(784,CurrencyCode.AED,"UAE Dirham","L");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AFN = new Currency(971,CurrencyCode.AFN,"Afghani","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ALL = new Currency(8,CurrencyCode.ALL,"Lek","DA");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AMD = new Currency(51,CurrencyCode.AMD,"Armenian Dram","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ANG = new Currency(532,CurrencyCode.ANG,"Netherlands Antillean Guilder","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AOA = new Currency(973,CurrencyCode.AOA,"Kwanza","KZ");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ARS = new Currency(32,CurrencyCode.ARS,"Argentine Peso","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AUD = new Currency(36,CurrencyCode.AUD,"Australian Dollar","$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AWG = new Currency(533,CurrencyCode.AWG,"Aruban Guilder","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency AZN = new Currency(944,CurrencyCode.AZN,"Azerbaijanian Manat","?");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BAM = new Currency(977,CurrencyCode.BAM,"Convertible Mark","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BBD = new Currency(52,CurrencyCode.BBD,"Barbados Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BDT = new Currency(50,CurrencyCode.BDT,"Taka","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BGN = new Currency(975,CurrencyCode.BGN,"Bulgarian Lev","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BHD = new Currency(48,CurrencyCode.BHD,"Bahraini Dinar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BIF = new Currency(108,CurrencyCode.BIF,"Burundi Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BMD = new Currency(60,CurrencyCode.BMD,"Bermudian Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BND = new Currency(96,CurrencyCode.BND,"Brunei Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BOB = new Currency(68,CurrencyCode.BOB,"Boliviano","S");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BOV = new Currency(984,CurrencyCode.BOV,"Mvdol","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BRL = new Currency(986,CurrencyCode.BRL,"Brazilian Real","BF");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BSD = new Currency(44,CurrencyCode.BSD,"Bahamian Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BTN = new Currency(64,CurrencyCode.BTN,"Ngultrum?","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BWP = new Currency(72,CurrencyCode.BWP,"Pula","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BYR = new Currency(974,CurrencyCode.BYR,"Belarussian Ruble","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency BZD = new Currency(84,CurrencyCode.BZD,"Belize Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CAD = new Currency(124,CurrencyCode.CAD,"Canadian Dollar","$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CDF = new Currency(976,CurrencyCode.CDF,"Congolese Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CHE = new Currency(947,CurrencyCode.CHE,"WIR Euro","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CHF = new Currency(756,CurrencyCode.CHF,"Swiss Franc","R$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CHW = new Currency(948,CurrencyCode.CHW,"WIR Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CLF = new Currency(990,CurrencyCode.CLF,"Unidades de fomento?","CFAF");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CLP = new Currency(152,CurrencyCode.CLP,"Chilean Peso","Can $");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CNY = new Currency(156,CurrencyCode.CNY,"Yuan Renminbi","￥");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency COP = new Currency(170,CurrencyCode.COP,"Colombian Peso","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency COU = new Currency(970,CurrencyCode.COU,"Unidad de Valor Real","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CRC = new Currency(188,CurrencyCode.CRC,"Costa Rican Colon","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CUC = new Currency(931,CurrencyCode.CUC,"Peso Convertible","Ch$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CUP = new Currency(192,CurrencyCode.CUP,"Cuban Peso","?");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CVE = new Currency(132,CurrencyCode.CVE,"Cape Verde Escudo","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency CZK = new Currency(203,CurrencyCode.CZK,"Czech Koruna","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency DJF = new Currency(262,CurrencyCode.DJF,"Djibouti Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency DKK = new Currency(208,CurrencyCode.DKK,"Danish Krone","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency DOP = new Currency(214,CurrencyCode.DOP,"Dominican Peso","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency DZD = new Currency(12,CurrencyCode.DZD,"Algerian Dinar","HRK");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency EGP = new Currency(818,CurrencyCode.EGP,"Egyptian Pound","Cu$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ERN = new Currency(232,CurrencyCode.ERN,"Nakfa","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ETB = new Currency(230,CurrencyCode.ETB,"Ethiopian Birr","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency EUR = new Currency(978,CurrencyCode.EUR,"Euro","€");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency FJD = new Currency(242,CurrencyCode.FJD,"Fiji Dollar","RlS");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency FKP = new Currency(238,CurrencyCode.FKP,"Falkland Islands Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GBP = new Currency(826,CurrencyCode.GBP,"Pound Sterling","￡");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GEL = new Currency(981,CurrencyCode.GEL,"Lari","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GGP = new Currency(9001,CurrencyCode.GGP,"Guernsey Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GHS = new Currency(936,CurrencyCode.GHS,"Cedi","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GIP = new Currency(292,CurrencyCode.GIP,"Gibraltar Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GMD = new Currency(270,CurrencyCode.GMD,"Dalasi","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GNF = new Currency(324,CurrencyCode.GNF,"Guinea Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GTQ = new Currency(320,CurrencyCode.GTQ,"Quetzal","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency GYD = new Currency(328,CurrencyCode.GYD,"Guyana Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency HKD = new Currency(344,CurrencyCode.HKD,"Hong Kong Dollar","$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency HNL = new Currency(340,CurrencyCode.HNL,"Lempira","ID");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency HRK = new Currency(191,CurrencyCode.HRK,"Croatian Kuna","ID");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency HTG = new Currency(332,CurrencyCode.HTG,"Gourde","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency HUF = new Currency(348,CurrencyCode.HUF,"Forint","Lit");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency IDR = new Currency(360,CurrencyCode.IDR,"Rupiah","J￥");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ILS = new Currency(376,CurrencyCode.ILS,"New Israeli Sheqel","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency IMP = new Currency(9002,CurrencyCode.IMP,"Isle of Man Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency INR = new Currency(356,CurrencyCode.INR,"Indian Rupee","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency IQD = new Currency(368,CurrencyCode.IQD,"Iraqi Dinar","KD");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency IRR = new Currency(364,CurrencyCode.IRR,"Iranian Rial","P");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ISK = new Currency(352,CurrencyCode.ISK,"Iceland Krona","RM");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency JEP = new Currency(9003,CurrencyCode.JEP,"Jersey Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency JMD = new Currency(388,CurrencyCode.JMD,"Jamaican Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency JOD = new Currency(400,CurrencyCode.JOD,"Jordanian Dinar","Lm");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency JPY = new Currency(392,CurrencyCode.JPY,"Yen","¥");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KES = new Currency(404,CurrencyCode.KES,"Kenyan Shilling","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KGS = new Currency(417,CurrencyCode.KGS,"Som","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KHR = new Currency(116,CurrencyCode.KHR,"Riel","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KMF = new Currency(174,CurrencyCode.KMF,"Comoro Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KPW = new Currency(408,CurrencyCode.KPW,"North Korean Won","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KRW = new Currency(410,CurrencyCode.KRW,"Won","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KWD = new Currency(414,CurrencyCode.KWD,"Kuwaiti Dinar","Mex$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KYD = new Currency(136,CurrencyCode.KYD,"Cayman Islands Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency KZT = new Currency(398,CurrencyCode.KZT,"Tenge","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LAK = new Currency(418,CurrencyCode.LAK,"Kip","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LBP = new Currency(422,CurrencyCode.LBP,"Lebanese Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LKR = new Currency(144,CurrencyCode.LKR,"Sri Lanka Rupee","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LRD = new Currency(430,CurrencyCode.LRD,"Liberian Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LSL = new Currency(426,CurrencyCode.LSL,"Loti","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LTL = new Currency(440,CurrencyCode.LTL,"Lithuanian Litas","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LVL = new Currency(428,CurrencyCode.LVL,"Latvian Lats","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency LYD = new Currency(434,CurrencyCode.LYD,"Libyan Dinar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MAD = new Currency(504,CurrencyCode.MAD,"Moroccan Dirham","Tug");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MDL = new Currency(498,CurrencyCode.MDL,"Moldovan Leu","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MGA = new Currency(969,CurrencyCode.MGA,"Malagasy Ariary","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MKD = new Currency(807,CurrencyCode.MKD,"Denar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MMK = new Currency(104,CurrencyCode.MMK,"Kyat","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MNT = new Currency(496,CurrencyCode.MNT,"Tugrik","DH");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MOP = new Currency(446,CurrencyCode.MOP,"Pataca","NE$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MRO = new Currency(478,CurrencyCode.MRO,"Ouguiya","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MUR = new Currency(480,CurrencyCode.MUR,"Mauritius Rupee","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MVR = new Currency(462,CurrencyCode.MVR,"Rufiyaa","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MWK = new Currency(454,CurrencyCode.MWK,"Kwacha","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MXN = new Currency(484,CurrencyCode.MXN,"Mexican Peso","NKr");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MXV = new Currency(979,CurrencyCode.MXV,"Mexican Unidad de Inversion (UDI)","Rs");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MYR = new Currency(458,CurrencyCode.MYR,"Malaysian Ringgit","Rs");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency MZN = new Currency(943,CurrencyCode.MZN,"Metical","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency NAD = new Currency(516,CurrencyCode.NAD,"Namibia Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency NGN = new Currency(566,CurrencyCode.NGN,"Naira","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency NIO = new Currency(558,CurrencyCode.NIO,"Cordoba Oro","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency NOK = new Currency(578,CurrencyCode.NOK,"Norwegian Krone","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency NPR = new Currency(524,CurrencyCode.NPR,"Nepalese Rupee","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency NZD = new Currency(554,CurrencyCode.NZD,"New Zealand Dollar","$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency OMR = new Currency(512,CurrencyCode.OMR,"Rial Omani","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PAB = new Currency(590,CurrencyCode.PAB,"Balboa","deshed P");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PEN = new Currency(9004,CurrencyCode.PEN,"Peruvian Nuevo Sol","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PGK = new Currency(598,CurrencyCode.PGK,"Kina","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PHP = new Currency(608,CurrencyCode.PHP,"Philippine Peso","L");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PKR = new Currency(586,CurrencyCode.PKR,"Pakistan Rupee","R");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PLN = new Currency(985,CurrencyCode.PLN,"Zloty","RF");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency PYG = new Currency(600,CurrencyCode.PYG,"Guarani","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency QAR = new Currency(634,CurrencyCode.QAR,"Qatari Rial","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency RON = new Currency(946,CurrencyCode.RON,"Leu","SRlS");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency RSD = new Currency(941,CurrencyCode.RSD,"Serbian Dinar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency RUB = new Currency(643,CurrencyCode.RUB,"Russian Ruble","£");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency RWF = new Currency(646,CurrencyCode.RWF,"Rwanda Franc","SlT");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SAR = new Currency(682,CurrencyCode.SAR,"Saudi Riyal","R");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SBD = new Currency(90,CurrencyCode.SBD,"Solomon Islands Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SCR = new Currency(690,CurrencyCode.SCR,"Seychelles Rupee","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SDG = new Currency(938,CurrencyCode.SDG,"Sudanese Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SEK = new Currency(752,CurrencyCode.SEK,"Swedish Krona","Ptas");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SGD = new Currency(702,CurrencyCode.SGD,"Singapore Dollar","SK");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SHP = new Currency(654,CurrencyCode.SHP,"Saint Helena Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SLL = new Currency(694,CurrencyCode.SLL,"Leone","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SOS = new Currency(706,CurrencyCode.SOS,"Somali Shilling","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SPL = new Currency(9005,CurrencyCode.SPL,"Seborgan Luigino","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SRD = new Currency(968,CurrencyCode.SRD,"Surinam Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency STD = new Currency(678,CurrencyCode.STD,"Dobra","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SVC = new Currency(222,CurrencyCode.SVC,"El Salvador Colon","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SYP = new Currency(760,CurrencyCode.SYP,"Syrian Pound","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency SZL = new Currency(748,CurrencyCode.SZL,"Lilangeni","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency THB = new Currency(764,CurrencyCode.THB,"Baht","SWF");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TJS = new Currency(972,CurrencyCode.TJS,"Somoni","?");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TMT = new Currency(934,CurrencyCode.TMT,"New Manat","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TND = new Currency(788,CurrencyCode.TND,"Tunisian Dinar","NT$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TOP = new Currency(776,CurrencyCode.TOP,"Paanga","Bht(Bt)");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TRY = new Currency(949,CurrencyCode.TRY,"Turkish Lira","PT(T$)");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TTD = new Currency(780,CurrencyCode.TTD,"Trinidad and Tobago Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TVD = new Currency(9006,CurrencyCode.TVD,"Tuvaluan Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TWD = new Currency(901,CurrencyCode.TWD,"New Taiwan Dollar","TD");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency TZS = new Currency(834,CurrencyCode.TZS,"Tanzanian Shilling","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency UAH = new Currency(980,CurrencyCode.UAH,"Hryvnia","?");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency UGX = new Currency(800,CurrencyCode.UGX,"Uganda Shilling","TL");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency USD = new Currency(840,CurrencyCode.USD,"US Dollar","$");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency USN = new Currency(997,CurrencyCode.USN,"US Dollar (Next day)?","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency USS = new Currency(998,CurrencyCode.USS,"US Dollar (Same day)?","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency UYI = new Currency(940,CurrencyCode.UYI,"Uruguay Peso en Unidades Indexadas (URUIURUI)","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency UYU = new Currency(858,CurrencyCode.UYU,"Peso Uruguayo","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency UZS = new Currency(860,CurrencyCode.UZS,"Uzbekistan Sum","?");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency VEF = new Currency(937,CurrencyCode.VEF,"Bolivar Fuerte","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency VND = new Currency(704,CurrencyCode.VND,"Dong","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency VUV = new Currency(548,CurrencyCode.VUV,"Vatu","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency WST = new Currency(882,CurrencyCode.WST,"Tala","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XAF = new Currency(950,CurrencyCode.XAF,"CFA Franc BEAC?","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XAG = new Currency(9007,CurrencyCode.XAG,"Silver Ounce","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XAU = new Currency(9008,CurrencyCode.XAU,"Gold Ounce","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XCD = new Currency(951,CurrencyCode.XCD,"East Caribbean Dollar","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XDR = new Currency(960,CurrencyCode.XDR,"SDR (Special Drawing Right)","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XOF = new Currency(952,CurrencyCode.XOF,"CFA Franc BCEAO?","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XPD = new Currency(9009,CurrencyCode.XPD,"Palladium Ounce","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XPF = new Currency(953,CurrencyCode.XPF,"CFP Franc","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XPT = new Currency(9010,CurrencyCode.XPT,"Platinum Ounce","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XSU = new Currency(994,CurrencyCode.XSU,"Sucre","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency XUA = new Currency(965,CurrencyCode.XUA,"ADB Unit of Account","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency YER = new Currency(886,CurrencyCode.YER,"Yemeni Rial","S");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ZAR = new Currency(710,CurrencyCode.ZAR,"Rand","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ZMK = new Currency(9011,CurrencyCode.ZMK,"Zambian Kwacha","");
		
		/// <summary>
        /// System.String[]
        /// </summary>
		public static readonly Currency ZWD = new Currency(9012,CurrencyCode.ZWD,"Zimbabwean Dollar","");
						
		#endregion

        static Currency()
        {           
            allCurrencies = new Currency[] {													
			AED,AFN,ALL,AMD,ANG,AOA,ARS,AUD,AWG,AZN,BAM,BBD,BDT,BGN,BHD,BIF,BMD,BND,BOB,BOV,BRL,BSD,BTN,BWP,BYR,BZD,CAD,CDF,CHE,CHF,CHW,CLF,CLP,CNY,COP,COU,CRC,CUC,CUP,CVE,CZK,DJF,DKK,DOP,DZD,EGP,ERN,ETB,EUR,FJD,FKP,GBP,GEL,GGP,GHS,GIP,GMD,GNF,GTQ,GYD,HKD,HNL,HRK,HTG,HUF,IDR,ILS,IMP,INR,IQD,IRR,ISK,JEP,JMD,JOD,JPY,KES,KGS,KHR,KMF,KPW,KRW,KWD,KYD,KZT,LAK,LBP,LKR,LRD,LSL,LTL,LVL,LYD,MAD,MDL,MGA,MKD,MMK,MNT,MOP,MRO,MUR,MVR,MWK,MXN,MXV,MYR,MZN,NAD,NGN,NIO,NOK,NPR,NZD,OMR,PAB,PEN,PGK,PHP,PKR,PLN,PYG,QAR,RON,RSD,RUB,RWF,SAR,SBD,SCR,SDG,SEK,SGD,SHP,SLL,SOS,SPL,SRD,STD,SVC,SYP,SZL,THB,TJS,TMT,TND,TOP,TRY,TTD,TVD,TWD,TZS,UAH,UGX,USD,USN,USS,UYI,UYU,UZS,VEF,VND,VUV,WST,XAF,XAG,XAU,XCD,XDR,XOF,XPD,XPF,XPT,XSU,XUA,YER,ZAR,ZMK,ZWD,							
            };
            allCurrencies = allCurrencies.OrderBy(c => c.Code).ToArray();                       
        }

	} // end of class Currency

	/// <summary>
    /// Defines currency codes. The names conform to the 3-letter alphabetic code 
	/// and the values conform to the numeric code in ISO 4217.
    /// </summary>
	[DataContract]
	public enum CurrencyCode
	{
		/*/// <summary>
        /// Unknown currency code
        /// </summary>
		/// <remark>
		/// This entry is intended to work around the .NET enum annoying default value. It should never be used in the appliation.
		/// </remark>
		[EnumMember]
		Unknown = 0,*/

		#region well-known
		
		/// <summary>
        /// UAE Dirham
        /// </summary>
		[EnumMember]
		AED = 784,
		
		/// <summary>
        /// Afghani
        /// </summary>
		[EnumMember]
		AFN = 971,
		
		/// <summary>
        /// Lek
        /// </summary>
		[EnumMember]
		ALL = 8,
		
		/// <summary>
        /// Armenian Dram
        /// </summary>
		[EnumMember]
		AMD = 51,
		
		/// <summary>
        /// Netherlands Antillean Guilder
        /// </summary>
		[EnumMember]
		ANG = 532,
		
		/// <summary>
        /// Kwanza
        /// </summary>
		[EnumMember]
		AOA = 973,
		
		/// <summary>
        /// Argentine Peso
        /// </summary>
		[EnumMember]
		ARS = 32,
		
		/// <summary>
        /// Australian Dollar
        /// </summary>
		[EnumMember]
		AUD = 36,
		
		/// <summary>
        /// Aruban Guilder
        /// </summary>
		[EnumMember]
		AWG = 533,
		
		/// <summary>
        /// Azerbaijanian Manat
        /// </summary>
		[EnumMember]
		AZN = 944,
		
		/// <summary>
        /// Convertible Mark
        /// </summary>
		[EnumMember]
		BAM = 977,
		
		/// <summary>
        /// Barbados Dollar
        /// </summary>
		[EnumMember]
		BBD = 52,
		
		/// <summary>
        /// Taka
        /// </summary>
		[EnumMember]
		BDT = 50,
		
		/// <summary>
        /// Bulgarian Lev
        /// </summary>
		[EnumMember]
		BGN = 975,
		
		/// <summary>
        /// Bahraini Dinar
        /// </summary>
		[EnumMember]
		BHD = 48,
		
		/// <summary>
        /// Burundi Franc
        /// </summary>
		[EnumMember]
		BIF = 108,
		
		/// <summary>
        /// Bermudian Dollar
        /// </summary>
		[EnumMember]
		BMD = 60,
		
		/// <summary>
        /// Brunei Dollar
        /// </summary>
		[EnumMember]
		BND = 96,
		
		/// <summary>
        /// Boliviano
        /// </summary>
		[EnumMember]
		BOB = 68,
		
		/// <summary>
        /// Mvdol
        /// </summary>
		[EnumMember]
		BOV = 984,
		
		/// <summary>
        /// Brazilian Real
        /// </summary>
		[EnumMember]
		BRL = 986,
		
		/// <summary>
        /// Bahamian Dollar
        /// </summary>
		[EnumMember]
		BSD = 44,
		
		/// <summary>
        /// Ngultrum?
        /// </summary>
		[EnumMember]
		BTN = 64,
		
		/// <summary>
        /// Pula
        /// </summary>
		[EnumMember]
		BWP = 72,
		
		/// <summary>
        /// Belarussian Ruble
        /// </summary>
		[EnumMember]
		BYR = 974,
		
		/// <summary>
        /// Belize Dollar
        /// </summary>
		[EnumMember]
		BZD = 84,
		
		/// <summary>
        /// Canadian Dollar
        /// </summary>
		[EnumMember]
		CAD = 124,
		
		/// <summary>
        /// Congolese Franc
        /// </summary>
		[EnumMember]
		CDF = 976,
		
		/// <summary>
        /// WIR Euro
        /// </summary>
		[EnumMember]
		CHE = 947,
		
		/// <summary>
        /// Swiss Franc
        /// </summary>
		[EnumMember]
		CHF = 756,
		
		/// <summary>
        /// WIR Franc
        /// </summary>
		[EnumMember]
		CHW = 948,
		
		/// <summary>
        /// Unidades de fomento?
        /// </summary>
		[EnumMember]
		CLF = 990,
		
		/// <summary>
        /// Chilean Peso
        /// </summary>
		[EnumMember]
		CLP = 152,
		
		/// <summary>
        /// Yuan Renminbi
        /// </summary>
		[EnumMember]
		CNY = 156,
		
		/// <summary>
        /// Colombian Peso
        /// </summary>
		[EnumMember]
		COP = 170,
		
		/// <summary>
        /// Unidad de Valor Real
        /// </summary>
		[EnumMember]
		COU = 970,
		
		/// <summary>
        /// Costa Rican Colon
        /// </summary>
		[EnumMember]
		CRC = 188,
		
		/// <summary>
        /// Peso Convertible
        /// </summary>
		[EnumMember]
		CUC = 931,
		
		/// <summary>
        /// Cuban Peso
        /// </summary>
		[EnumMember]
		CUP = 192,
		
		/// <summary>
        /// Cape Verde Escudo
        /// </summary>
		[EnumMember]
		CVE = 132,
		
		/// <summary>
        /// Czech Koruna
        /// </summary>
		[EnumMember]
		CZK = 203,
		
		/// <summary>
        /// Djibouti Franc
        /// </summary>
		[EnumMember]
		DJF = 262,
		
		/// <summary>
        /// Danish Krone
        /// </summary>
		[EnumMember]
		DKK = 208,
		
		/// <summary>
        /// Dominican Peso
        /// </summary>
		[EnumMember]
		DOP = 214,
		
		/// <summary>
        /// Algerian Dinar
        /// </summary>
		[EnumMember]
		DZD = 12,
		
		/// <summary>
        /// Egyptian Pound
        /// </summary>
		[EnumMember]
		EGP = 818,
		
		/// <summary>
        /// Nakfa
        /// </summary>
		[EnumMember]
		ERN = 232,
		
		/// <summary>
        /// Ethiopian Birr
        /// </summary>
		[EnumMember]
		ETB = 230,
		
		/// <summary>
        /// Euro
        /// </summary>
		[EnumMember]
		EUR = 978,
		
		/// <summary>
        /// Fiji Dollar
        /// </summary>
		[EnumMember]
		FJD = 242,
		
		/// <summary>
        /// Falkland Islands Pound
        /// </summary>
		[EnumMember]
		FKP = 238,
		
		/// <summary>
        /// Pound Sterling
        /// </summary>
		[EnumMember]
		GBP = 826,
		
		/// <summary>
        /// Lari
        /// </summary>
		[EnumMember]
		GEL = 981,
		
		/// <summary>
        /// Guernsey Pound
        /// </summary>
		[EnumMember]
		GGP = 9001,
		
		/// <summary>
        /// Cedi
        /// </summary>
		[EnumMember]
		GHS = 936,
		
		/// <summary>
        /// Gibraltar Pound
        /// </summary>
		[EnumMember]
		GIP = 292,
		
		/// <summary>
        /// Dalasi
        /// </summary>
		[EnumMember]
		GMD = 270,
		
		/// <summary>
        /// Guinea Franc
        /// </summary>
		[EnumMember]
		GNF = 324,
		
		/// <summary>
        /// Quetzal
        /// </summary>
		[EnumMember]
		GTQ = 320,
		
		/// <summary>
        /// Guyana Dollar
        /// </summary>
		[EnumMember]
		GYD = 328,
		
		/// <summary>
        /// Hong Kong Dollar
        /// </summary>
		[EnumMember]
		HKD = 344,
		
		/// <summary>
        /// Lempira
        /// </summary>
		[EnumMember]
		HNL = 340,
		
		/// <summary>
        /// Croatian Kuna
        /// </summary>
		[EnumMember]
		HRK = 191,
		
		/// <summary>
        /// Gourde
        /// </summary>
		[EnumMember]
		HTG = 332,
		
		/// <summary>
        /// Forint
        /// </summary>
		[EnumMember]
		HUF = 348,
		
		/// <summary>
        /// Rupiah
        /// </summary>
		[EnumMember]
		IDR = 360,
		
		/// <summary>
        /// New Israeli Sheqel
        /// </summary>
		[EnumMember]
		ILS = 376,
		
		/// <summary>
        /// Isle of Man Pound
        /// </summary>
		[EnumMember]
		IMP = 9002,
		
		/// <summary>
        /// Indian Rupee
        /// </summary>
		[EnumMember]
		INR = 356,
		
		/// <summary>
        /// Iraqi Dinar
        /// </summary>
		[EnumMember]
		IQD = 368,
		
		/// <summary>
        /// Iranian Rial
        /// </summary>
		[EnumMember]
		IRR = 364,
		
		/// <summary>
        /// Iceland Krona
        /// </summary>
		[EnumMember]
		ISK = 352,
		
		/// <summary>
        /// Jersey Pound
        /// </summary>
		[EnumMember]
		JEP = 9003,
		
		/// <summary>
        /// Jamaican Dollar
        /// </summary>
		[EnumMember]
		JMD = 388,
		
		/// <summary>
        /// Jordanian Dinar
        /// </summary>
		[EnumMember]
		JOD = 400,
		
		/// <summary>
        /// Yen
        /// </summary>
		[EnumMember]
		JPY = 392,
		
		/// <summary>
        /// Kenyan Shilling
        /// </summary>
		[EnumMember]
		KES = 404,
		
		/// <summary>
        /// Som
        /// </summary>
		[EnumMember]
		KGS = 417,
		
		/// <summary>
        /// Riel
        /// </summary>
		[EnumMember]
		KHR = 116,
		
		/// <summary>
        /// Comoro Franc
        /// </summary>
		[EnumMember]
		KMF = 174,
		
		/// <summary>
        /// North Korean Won
        /// </summary>
		[EnumMember]
		KPW = 408,
		
		/// <summary>
        /// Won
        /// </summary>
		[EnumMember]
		KRW = 410,
		
		/// <summary>
        /// Kuwaiti Dinar
        /// </summary>
		[EnumMember]
		KWD = 414,
		
		/// <summary>
        /// Cayman Islands Dollar
        /// </summary>
		[EnumMember]
		KYD = 136,
		
		/// <summary>
        /// Tenge
        /// </summary>
		[EnumMember]
		KZT = 398,
		
		/// <summary>
        /// Kip
        /// </summary>
		[EnumMember]
		LAK = 418,
		
		/// <summary>
        /// Lebanese Pound
        /// </summary>
		[EnumMember]
		LBP = 422,
		
		/// <summary>
        /// Sri Lanka Rupee
        /// </summary>
		[EnumMember]
		LKR = 144,
		
		/// <summary>
        /// Liberian Dollar
        /// </summary>
		[EnumMember]
		LRD = 430,
		
		/// <summary>
        /// Loti
        /// </summary>
		[EnumMember]
		LSL = 426,
		
		/// <summary>
        /// Lithuanian Litas
        /// </summary>
		[EnumMember]
		LTL = 440,
		
		/// <summary>
        /// Latvian Lats
        /// </summary>
		[EnumMember]
		LVL = 428,
		
		/// <summary>
        /// Libyan Dinar
        /// </summary>
		[EnumMember]
		LYD = 434,
		
		/// <summary>
        /// Moroccan Dirham
        /// </summary>
		[EnumMember]
		MAD = 504,
		
		/// <summary>
        /// Moldovan Leu
        /// </summary>
		[EnumMember]
		MDL = 498,
		
		/// <summary>
        /// Malagasy Ariary
        /// </summary>
		[EnumMember]
		MGA = 969,
		
		/// <summary>
        /// Denar
        /// </summary>
		[EnumMember]
		MKD = 807,
		
		/// <summary>
        /// Kyat
        /// </summary>
		[EnumMember]
		MMK = 104,
		
		/// <summary>
        /// Tugrik
        /// </summary>
		[EnumMember]
		MNT = 496,
		
		/// <summary>
        /// Pataca
        /// </summary>
		[EnumMember]
		MOP = 446,
		
		/// <summary>
        /// Ouguiya
        /// </summary>
		[EnumMember]
		MRO = 478,
		
		/// <summary>
        /// Mauritius Rupee
        /// </summary>
		[EnumMember]
		MUR = 480,
		
		/// <summary>
        /// Rufiyaa
        /// </summary>
		[EnumMember]
		MVR = 462,
		
		/// <summary>
        /// Kwacha
        /// </summary>
		[EnumMember]
		MWK = 454,
		
		/// <summary>
        /// Mexican Peso
        /// </summary>
		[EnumMember]
		MXN = 484,
		
		/// <summary>
        /// Mexican Unidad de Inversion (UDI)
        /// </summary>
		[EnumMember]
		MXV = 979,
		
		/// <summary>
        /// Malaysian Ringgit
        /// </summary>
		[EnumMember]
		MYR = 458,
		
		/// <summary>
        /// Metical
        /// </summary>
		[EnumMember]
		MZN = 943,
		
		/// <summary>
        /// Namibia Dollar
        /// </summary>
		[EnumMember]
		NAD = 516,
		
		/// <summary>
        /// Naira
        /// </summary>
		[EnumMember]
		NGN = 566,
		
		/// <summary>
        /// Cordoba Oro
        /// </summary>
		[EnumMember]
		NIO = 558,
		
		/// <summary>
        /// Norwegian Krone
        /// </summary>
		[EnumMember]
		NOK = 578,
		
		/// <summary>
        /// Nepalese Rupee
        /// </summary>
		[EnumMember]
		NPR = 524,
		
		/// <summary>
        /// New Zealand Dollar
        /// </summary>
		[EnumMember]
		NZD = 554,
		
		/// <summary>
        /// Rial Omani
        /// </summary>
		[EnumMember]
		OMR = 512,
		
		/// <summary>
        /// Balboa
        /// </summary>
		[EnumMember]
		PAB = 590,
		
		/// <summary>
        /// Peruvian Nuevo Sol
        /// </summary>
		[EnumMember]
		PEN = 9004,
		
		/// <summary>
        /// Kina
        /// </summary>
		[EnumMember]
		PGK = 598,
		
		/// <summary>
        /// Philippine Peso
        /// </summary>
		[EnumMember]
		PHP = 608,
		
		/// <summary>
        /// Pakistan Rupee
        /// </summary>
		[EnumMember]
		PKR = 586,
		
		/// <summary>
        /// Zloty
        /// </summary>
		[EnumMember]
		PLN = 985,
		
		/// <summary>
        /// Guarani
        /// </summary>
		[EnumMember]
		PYG = 600,
		
		/// <summary>
        /// Qatari Rial
        /// </summary>
		[EnumMember]
		QAR = 634,
		
		/// <summary>
        /// Leu
        /// </summary>
		[EnumMember]
		RON = 946,
		
		/// <summary>
        /// Serbian Dinar
        /// </summary>
		[EnumMember]
		RSD = 941,
		
		/// <summary>
        /// Russian Ruble
        /// </summary>
		[EnumMember]
		RUB = 643,
		
		/// <summary>
        /// Rwanda Franc
        /// </summary>
		[EnumMember]
		RWF = 646,
		
		/// <summary>
        /// Saudi Riyal
        /// </summary>
		[EnumMember]
		SAR = 682,
		
		/// <summary>
        /// Solomon Islands Dollar
        /// </summary>
		[EnumMember]
		SBD = 90,
		
		/// <summary>
        /// Seychelles Rupee
        /// </summary>
		[EnumMember]
		SCR = 690,
		
		/// <summary>
        /// Sudanese Pound
        /// </summary>
		[EnumMember]
		SDG = 938,
		
		/// <summary>
        /// Swedish Krona
        /// </summary>
		[EnumMember]
		SEK = 752,
		
		/// <summary>
        /// Singapore Dollar
        /// </summary>
		[EnumMember]
		SGD = 702,
		
		/// <summary>
        /// Saint Helena Pound
        /// </summary>
		[EnumMember]
		SHP = 654,
		
		/// <summary>
        /// Leone
        /// </summary>
		[EnumMember]
		SLL = 694,
		
		/// <summary>
        /// Somali Shilling
        /// </summary>
		[EnumMember]
		SOS = 706,
		
		/// <summary>
        /// Seborgan Luigino
        /// </summary>
		[EnumMember]
		SPL = 9005,
		
		/// <summary>
        /// Surinam Dollar
        /// </summary>
		[EnumMember]
		SRD = 968,
		
		/// <summary>
        /// Dobra
        /// </summary>
		[EnumMember]
		STD = 678,
		
		/// <summary>
        /// El Salvador Colon
        /// </summary>
		[EnumMember]
		SVC = 222,
		
		/// <summary>
        /// Syrian Pound
        /// </summary>
		[EnumMember]
		SYP = 760,
		
		/// <summary>
        /// Lilangeni
        /// </summary>
		[EnumMember]
		SZL = 748,
		
		/// <summary>
        /// Baht
        /// </summary>
		[EnumMember]
		THB = 764,
		
		/// <summary>
        /// Somoni
        /// </summary>
		[EnumMember]
		TJS = 972,
		
		/// <summary>
        /// New Manat
        /// </summary>
		[EnumMember]
		TMT = 934,
		
		/// <summary>
        /// Tunisian Dinar
        /// </summary>
		[EnumMember]
		TND = 788,
		
		/// <summary>
        /// Paanga
        /// </summary>
		[EnumMember]
		TOP = 776,
		
		/// <summary>
        /// Turkish Lira
        /// </summary>
		[EnumMember]
		TRY = 949,
		
		/// <summary>
        /// Trinidad and Tobago Dollar
        /// </summary>
		[EnumMember]
		TTD = 780,
		
		/// <summary>
        /// Tuvaluan Dollar
        /// </summary>
		[EnumMember]
		TVD = 9006,
		
		/// <summary>
        /// New Taiwan Dollar
        /// </summary>
		[EnumMember]
		TWD = 901,
		
		/// <summary>
        /// Tanzanian Shilling
        /// </summary>
		[EnumMember]
		TZS = 834,
		
		/// <summary>
        /// Hryvnia
        /// </summary>
		[EnumMember]
		UAH = 980,
		
		/// <summary>
        /// Uganda Shilling
        /// </summary>
		[EnumMember]
		UGX = 800,
		
		/// <summary>
        /// US Dollar
        /// </summary>
		[EnumMember]
		USD = 840,
		
		/// <summary>
        /// US Dollar (Next day)?
        /// </summary>
		[EnumMember]
		USN = 997,
		
		/// <summary>
        /// US Dollar (Same day)?
        /// </summary>
		[EnumMember]
		USS = 998,
		
		/// <summary>
        /// Uruguay Peso en Unidades Indexadas (URUIURUI)
        /// </summary>
		[EnumMember]
		UYI = 940,
		
		/// <summary>
        /// Peso Uruguayo
        /// </summary>
		[EnumMember]
		UYU = 858,
		
		/// <summary>
        /// Uzbekistan Sum
        /// </summary>
		[EnumMember]
		UZS = 860,
		
		/// <summary>
        /// Bolivar Fuerte
        /// </summary>
		[EnumMember]
		VEF = 937,
		
		/// <summary>
        /// Dong
        /// </summary>
		[EnumMember]
		VND = 704,
		
		/// <summary>
        /// Vatu
        /// </summary>
		[EnumMember]
		VUV = 548,
		
		/// <summary>
        /// Tala
        /// </summary>
		[EnumMember]
		WST = 882,
		
		/// <summary>
        /// CFA Franc BEAC?
        /// </summary>
		[EnumMember]
		XAF = 950,
		
		/// <summary>
        /// Silver Ounce
        /// </summary>
		[EnumMember]
		XAG = 9007,
		
		/// <summary>
        /// Gold Ounce
        /// </summary>
		[EnumMember]
		XAU = 9008,
		
		/// <summary>
        /// East Caribbean Dollar
        /// </summary>
		[EnumMember]
		XCD = 951,
		
		/// <summary>
        /// SDR (Special Drawing Right)
        /// </summary>
		[EnumMember]
		XDR = 960,
		
		/// <summary>
        /// CFA Franc BCEAO?
        /// </summary>
		[EnumMember]
		XOF = 952,
		
		/// <summary>
        /// Palladium Ounce
        /// </summary>
		[EnumMember]
		XPD = 9009,
		
		/// <summary>
        /// CFP Franc
        /// </summary>
		[EnumMember]
		XPF = 953,
		
		/// <summary>
        /// Platinum Ounce
        /// </summary>
		[EnumMember]
		XPT = 9010,
		
		/// <summary>
        /// Sucre
        /// </summary>
		[EnumMember]
		XSU = 994,
		
		/// <summary>
        /// ADB Unit of Account
        /// </summary>
		[EnumMember]
		XUA = 965,
		
		/// <summary>
        /// Yemeni Rial
        /// </summary>
		[EnumMember]
		YER = 886,
		
		/// <summary>
        /// Rand
        /// </summary>
		[EnumMember]
		ZAR = 710,
		
		/// <summary>
        /// Zambian Kwacha
        /// </summary>
		[EnumMember]
		ZMK = 9011,
		
		/// <summary>
        /// Zimbabwean Dollar
        /// </summary>
		[EnumMember]
		ZWD = 9012,
						
		#endregion       

	} // end of class Currency
}// end of namespace Yahee.Model