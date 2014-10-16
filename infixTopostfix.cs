using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12253025HW1
{
    class Program
    {
        public static void Main(string[] args)//
        {
            string infix;
            Console.Write("Infix ifadeyi girin:");
            infix = Console.ReadLine();//infix ifadeyi almaya yarar.
            Console.WriteLine(" postfix şekli  : " + cevir(infix));//postfix şeklini ekrana basar.
            Console.WriteLine(hesapla(cevir(infix)));//çevrilen ifadenin sonucunu ekrana basar.
        }
        public static string cevir(string infix)//infix i postfix e çevirir.
        {
            string swap;
            string postfix = "";
            string[] array = new string[infix.Length];//array oluşturdum
            Stack<string> st1 = new Stack<string>(infix.Length);//stack oluşturdum.
            for (int i = 0; i < infix.Length; i++)
            {
                if (infix[i] == '+' || infix[i] == '-' || infix[i] == '*' || infix[i] == '/')//eğer işaretlerden birisi ise içeri girer yoksa else geçer
                {
                    st1.push(infix[i].ToString());//stağe eleman ekledim
                    if (st1.isEmpty())//stack boşsa
                    {
                        postfix = postfix + st1.pop();//stack in üstünden alınan eleman postfix eklenir
                        st1.push(infix[i].ToString());//stack e eleman ekledik
                    }
                    else//stack dolu ise
                    {
                        st1.push(infix[i].ToString());//stack e eleman ekledik
                    }
                    array[i] = st1.pop();//stack in üstündeki elemanı array e atar
                    while (control(array[i]) >= control(array[i + 1]))//swaple infixteki işlemlerinin (+ - * / ) sıralaması için yapmaya çalıştım
                    {
                        swap = array[i];
                        array[i] = array[i + 1];// swap fonk.
                        array[i + 1] = swap;
                        postfix = postfix + array[i];
                    }
                }
                else
                {
                    postfix = postfix + infix[i];
                }
            }
            postfix = postfix + st1.pop();
            return postfix;
        }
        public static int control(string inf)//öncelik sıralaması için return değerleri almaya yarar
        {
            if (inf == "*" || inf == "/")
            {
                return 2;
            }
            else if (inf == "+" || inf == "-")
            {
                return 1;
            }
            return 0;
        }
        public static int hesapla(string postfix)//postfix ifadeyi hesaplar
        {
            Stack<int> stk = new Stack<int>(postfix.Length);
            int islem;
            int sonuc = 0;
            for (int i = 0; i < postfix.Length; i++)//(not: stackteki karakterler ascii olarak alındığını fark ettim ama çözümü henüz bulamadım )
            {
                if (postfix[i] == '+' || postfix[i] == '-' || postfix[i] == '*' || postfix[i] == '/')
                {
                    islem = postfix[i];
                    if (islem == '*')
                    {
                        sonuc = stk.pop() * stk.pop();
                    }
                    if (islem == '/')
                    {
                        sonuc = stk.pop() / stk.pop();
                    }
                    if (islem == '+')
                    {
                        sonuc = stk.pop() + stk.pop();
                    }
                    if (islem == '-')
                    {
                        sonuc = stk.pop() - stk.pop();
                    }
                }
                else
                {
                    stk.push(postfix[i]);
                }
            }
            return sonuc;
        }
    }
}
