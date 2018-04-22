using System;
using System.IO;
using System.Net;
using System.Text;

namespace Khairia.Core
{
	public class SmsService
	{
		private const string ApiKey = "ce61d78b30fc054d48754ec377333d64";
		private const string MobilyPassword = "ADOSSARY";
		private const string MobilyUserName = "966555897704";
		private const string Txtsendername = "dar-alkhair";

		public string Send(string message, string number)
		{
			string Res = SendMessage(MobilyUserName, MobilyPassword, message,
				Txtsendername, number);
			switch (Res)
			{
				case "1":
					//SMS Have Been Send
					return"<script>window.alert('تمت العملية بنجاح')</script>";
					break;
				case "2":
					//balabce is zero (SMS Not Send)
					return
						"<script>window.alert('إن رصيدك لدى موبايلي قد إنتهى ولم يعد به أي رسائل. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى موبايلي. لشحن رصيدك إتبع تعليمات شحن الرصيد)')</script>";
					break;
				case "3":
					//balance not enough (SMS Not Send)
					return
						"<script>window.alert('إن رصيدك الحالي لا يكفي لإتمام عملية الإرسال. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى موبايلي. لشحن رصيدك إتبع تعليمات شحن الرصيد).')</script>";
					break;
				case "4":
					//error in user name (SMS Not Send)
					return
						"<script>window.alert('إن إسم المستخدم الذي إستخدمته للدخول إلى حساب الرسائل غير صحيح (تأكد من أن إسم المستخدم الذي إستخدمته هو نفسه الذي تستخدمه عند دخولك إلى موقع موبايلي).')</script>";
					break;
				case "5":
					//error in password (SMS Not Send)
					return
						"<script>window.alert('هناك خطأ في كلمة المرور (تأكد من أن كلمة المرور التي تم إستخدامها هي نفسها التي تستخدمها عند دخولك موقع موبايلي,إذا نسيت كلمة المرور إضغط على رابط نسيت كلمة المرور لتصلك رسالة على جوالك برقم المرور الخاص بك)')</script>";
					break;
				case "6":
					//there is a problem in sending, try again later  (SMS Not Send)
					return
						"<script>window.alert('إن صفحة الإرسال لاتجيب في الوقت الحالي (قد يكون هناك طلب كبير على الصفحة أو توقف مؤقت للصفحة فقط حاول مرة أخرى أو تواصل مع الدعم الفني إذا إستمر الخطأ)')</script>";
					break;
				case "12":
					return"<script>window.alert('إن حسابك بحاجة إلى تحديث يرجى مراجعة الدعم الفني.')</script>";
					break;
				case "13":
					return
						"<script>window.alert('إن إسم المرسل الذي إستخدمته في هذه الرسالة لم يتم قبوله. (يرجى إرسال الرسالة بإسم مرسل آخر أو تعريف إسم المرسل لدى موبايلي)')</script>";
					break;
				case "14":
					return
						"<script>window.alert('إن إسم المرسل الذي إستخدمته غير معرف لدى موبايلي. (يمكنك تعريف إسم المرسل من خلال صفحة إضافة إسم مرسل)')</script>";
					break;
				case "15":
					return
						"<script>window.alert('يوجد رقم جوال خاطئ في الأرقام التي قمت بالإرسال لها. (تأكد من صحة الأرقام التي تريد الإرسال لها وأنها بالصيغة الدولية)')</script>";
					break;
				case "16":
					return
						"<script>window.alert('الرسالة التي قمت بإرسالها لا تحتوي على إسم مرسل. (أدخل إسم مرسل عند إرسالك الرسالة)')</script>";
					break;
				case "17":
					return
						"<script>window.alert('م يتم ارسال نص الرسالة. الرجاء التأكد من ارسال نص الرسالة والتأكد من تحويل الرسالة الى يوني كود (الرجاء التأكد من استخدام الدالة ConvertToUnicode)')</script>";
					break;
				case "18":
					return"<script>window.alert('الارسال متوقف حاليا')</script>";
					break;
				case "19":
					return"<script>window.alert('applicationType غير موجود في الرابط')</script>";
					break;
				case "-1":
					return
						"<script>window.alert('لم يتم التواصل مع خادم (Server) الإرسال موبايلي بنجاح. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)')</script>";
					break;
				case "-2":
					return
						"<script>window.alert('لم يتم الربط مع قاعدة البيانات (Database) التي تحتوي على حسابك وبياناتك لدى موبايلي. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)')</script>";

					break;
			}
			return "";
		}


		public void GetBalance()
		{
			//int temp = '0';
			//WebResponse myResponse = null;


			HttpWebRequest req = (HttpWebRequest)
				WebRequest.Create("http://www.mobily.ws/api/balance.php");
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			string postData = "mobile=" + MobilyUserName + "&password=" +
			                  MobilyPassword;
			req.ContentLength = postData.Length;

			StreamWriter stOut = new
				StreamWriter(req.GetRequestStream(),
					Encoding.ASCII);
			stOut.Write(postData);
			stOut.Close();
			// Do the request to get the response
			string strResponse;
			StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
			strResponse = stIn.ReadToEnd();
			stIn.Close();
			switch (strResponse)
			{
				case "1":
					Console.Write(
						"window.alert('إن إسم المستخدم الذي إستخدمته للدخول غير صحيح (تأكد من أن إسم المستخدم الذي إستخدمته هو نفسه الذي تدخله عند دخولك إلى موقع موبايلي).')</script>");
					break;
				case "2":
					Console.Write(
						"window.alert('هناك خطأ في كلمة المرور (تأكد من أن كلمة المرور التي تستخدمها هي نفسها التي تستخدمها عند دخولك موقع موبايلي).')</script>");
					break;
				case "-1":
					Console.Write(
						"window.alert('لم يتم التواصل مع خادم (Server) الإرسال موبايلي بنجاح. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)')</script>");
					break;
				case "-2":
					Console.Write(
						"window.alert('لم يتم الربط مع قاعدة البيانات (Database) التي تحتوي على حسابك وبياناتك لدى موبايلي. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)')</script>");
					break;
			}

			Console.Write(strResponse);
		}

		private string ConvertToUnicode(string val)
		{
			string msg2 = string.Empty;

			for (int i = 0; i < val.Length; i++)
				msg2 += convertToUnicode(Convert.ToChar(val.Substring(i, 1)));

			return msg2;
		}

		private string convertToUnicode(char ch)
		{
			UnicodeEncoding class1 = new UnicodeEncoding();
			byte[] msg = class1.GetBytes(Convert.ToString(ch));

			return fourDigits(msg[1] + msg[0].ToString("X"));
		}

		private string fourDigits(string val)
		{
			string result = string.Empty;

			switch (val.Length)
			{
				case 1:
					result = "000" + val;
					break;
				case 2:
					result = "00" + val;
					break;
				case 3:
					result = "0" + val;
					break;
				case 4:
					result = val;
					break;
			}

			return result;
		}

		public string SendMessage(string username, string password, string msg, string sender, string numbers)
		{
			//int temp = '0';

			HttpWebRequest req = (HttpWebRequest)
				WebRequest.Create("http://www.mobily.ws/api/msgSend.php");
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			string postData = "mobile=" + username + "&password=" + password + "&numbers=" + numbers + "&sender=" + sender +
			                  "&msg=" + ConvertToUnicode(msg) + "&applicationType=59";
			req.ContentLength = postData.Length;

			StreamWriter stOut = new
				StreamWriter(req.GetRequestStream(),
					Encoding.ASCII);
			stOut.Write(postData);
			stOut.Close();
			// Do the request to get the response
			string strResponse;
			StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
			strResponse = stIn.ReadToEnd();
			stIn.Close();
			return strResponse;
		}
	}
}