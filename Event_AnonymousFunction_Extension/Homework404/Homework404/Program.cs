/*
1. Func adinda delegate yaradin hansi ki bir string parametr qebul edir ve void qaytarir.
2. MyClass adinda bir class yaradin hansi ki, ozunde iki static olmayan method saxlayir(Space(), Reverse())
   
   public void Space(string str); // e_x_a_m_p_l_e -> bu metod sadece her herifin arasina _ atir.
   public void Reverse(string str); // elpmaxe -> bu metod ise stringi tersine cevirir.

3. Run adinda bir class yaradin hansi ki, ozunde runFunc(argument) adinda void function saxlayir.

Mesele budur ki, men consoldan bir soz daxil edecem ve asagidaki runFunc i cagiracam. Netice olaraq hemen iki funksiya
yuxarida gosterdiyim kimi cavablar qaytarmalidir.


public static void Main()
{	
	Console.WriteLine("Enter string")
	var str = Console.ReadLine();
        MyClass cls = new MyClass(str);
	Func funcDell = new Func(params) // params sadece sizin ora vereceyiniz parametrlerdi	
	burda funcDell-e functionlari verirsiniz	
	Run run = new Run();
	run.runFunc(funcDell,str); //cagiranda Space() ve Reverse() functionlari ise dusmelidir
}

main-de bunnan artiq kod yaza bilmezsiniz. Amma Classlarda azadsiniz.

Burda esas diqqet etmeli oldugunuz meqam metodlar MyClass dadir ama men onlari Run da cagiriram. Yeni o metodlari delagate 
seklinde Run a gonderib orda invoke elemek lazimdir.
 */



using System;

namespace Homework404
{
    delegate void Func(string st);

    class MyClass
    {
        public void Space(string word)
        {
            char[] cw = new char[word.Length * 2 - 1];
            int j = 0;
            for (int i = 0; i < word.Length * 2 - 1; i++)
            {
                if (i % 2 != 0)
                {
                    cw[i] = '_';
                }
                else
                {
                    cw[i] = word[j];
                    j++;
                }
            }
            Console.WriteLine(cw);
        }

        public void Reverse(string word)
        {
            char[] cw = word.ToCharArray();
            for (int i = 0, j = word.Length - 1; i <= j; i++, j--)
            {
                cw[i] = word[j];
                cw[j] = word[i];
            }
            Console.WriteLine(cw);
        }
    }

    class Run
    {
        public void runFunc(Func func, string str)
        {
            func.Invoke(str);
        }
    }
    class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("Enter string");
            var str = Console.ReadLine();
            MyClass cls = new MyClass();
            Func funcDell = new Func(cls.Reverse);
            funcDell += cls.Space;
            Run run = new Run();
            run.runFunc(funcDell, str);
        }
    }
}