// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

namespace HelloWorld
{
    class Programme
    {
        static void Main(String[] args)
        {
            /*Console.WriteLine("Hello World");
            Console.Write("Hi");
            Console.WriteLine("Pratik");

            /* Data types 
            String s1 = new String("StringObjectEx");
            Console.WriteLine(s1);
            Console.ReadLine();*/
            //ABC a1 = new ABC();
            string base64String = "CfDJ8Cg_6iT_40JAsLjOhrOzj0mTIa2ihZS0B_ple2fj5g8b8kYKahkCxtYGlC1-pgOommzsHe5P16pjiJHTUP4x99KAczyVi4Bz2d9mrxF1WidMQ2nTwXnombQFvALKJZ6OW94_thI9llg8leVovfWeUZ2A_VN7nNsZ9uV1TKhzxMNCYP8NRqofxQsCcYznbR7hwZt9FK8bmW_f4wqxBcKjsGnPDLyRVDgEBARrnDwoIB_UANXI7ug47iwN9HUl9BU80o79Dz35CFXVbmOw4YJFb2iu6S_9cEgMnRrKyAlhnvnvWWUCqdGH88oPc9PcDFwiCnxk-7WOXfH9W2gjRLW2DxSYW9ZFOwrlcVjcvJMCBA41x7aa2QWRz8DtrOcc0d86Ad6f7BozsYpHK7DZPWSeMeHoKbRIu3zunmlH7VF5p3uIVW2QcwG9AgYZv77XWY0FF4IkmlcSsm2E-dlUGaAr0ToraZ6dzB0E0MxuIxmAlUWcCoI4h9_6HXXgoNVuhT1cXprbNhxE4STKJL9KqdowYidiAgcaC3E-bW2ru15GqQzPxFyS57M5G75CR6cWW6IExPe0ewLQbgwXZxz8Ja2jPCcvQiPnhuZh9CnK4gcN2NKtQBtuAeKb_QlKWxJsmEjpx1GMclGQSYza8_PnQIqjtPyENAjFRZNHVllXh_-f65Gsy06oFfEuoJgkdk-tByQncQ";

            // Decode from Base64 to byte array
            byte[] data = Convert.FromBase64String(base64String);

            // Convert byte array to string (if it's text-based data)
            string decodedString = Encoding.UTF8.GetString(data);

            Console.WriteLine(decodedString);
            Console.ReadLine();


        }
    }
}