// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

namespace Cytaty
{
    internal class Program
    {
        public const string FILE_NAME= @"cytaty.txt";
        public static List<string> cytaty = new List<string>();
        static void Main(string[] args)
        {
           
            Console.WriteLine("Program Cytaty");

            WyswietlMenu();

        }
            static void MenuItem()
        {
            List<string> menuList = new List<string>();
            menuList.Add("1.Pokaż cytaty");
            menuList.Add("2.Dodaj nowy cytat");
            menuList.Add("3.Edytuj cytat");
            menuList.Add("4.Zapisz cytaty do pliku");
            menuList.Add("5.Wczytaj cytaty z pliku");
            menuList.Add("6.Usuń cytat");
            menuList.Add("7.Exit");

            foreach (var item in menuList)
            {
                Console.WriteLine(item);
            }
        }
        static void WyswietlMenu()
            {
                Console.Clear();            
                Console.WriteLine($"W bazie znajduje się {IloscCytatow(cytaty)} cytatów ");
                Console.WriteLine("Wybierze opcje z menu podając cyfrę od 1 do 7:");

                MenuItem();
                if(!int.TryParse(Console.ReadLine(), out int itemId))
                {
                    Console.WriteLine("Wybrano złą opcję! Powrót do menu");
                    Console.ReadKey();
                    WyswietlMenu();
                    return;
                 }
            Console.WriteLine($"Wybrana opcja to : {itemId}");
            switch (itemId)
                {
                    case 1:
                        WyswietlCystaty();
                        break;
                    case 2:
                       AddCytat(cytaty);
                        break;
                    case 3:
                        //  EdytujCytat();
                        break;
                    case 4:
                         ZapiszDoPliku(cytaty);
                        break;
                    case 5:
                        WczytajZpliku();
                        break;
                    case 6:
                        DelCytaty(cytaty);
                        break;
                    case 7:
                    Console.WriteLine("Wyjście potwierdź");
                        break;
                    default:
                    Console.WriteLine("Wybrano złą opcje! Powrót do Menu");
                    break;
                }
            Console.ReadKey();
            WyswietlMenu();
        }
        

        static void WyswietlCystaty()
        {
           
            Console.Clear();
            if (NoEmptyLis())
            {
                foreach (var item in cytaty)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("Należy załadować cytaty z pliku lub dodać nowe. Czy to zrobić Y lub N");
                char pytanie=char.Parse(Console.ReadLine().ToLower());
                switch (pytanie)
                {
                    case 'y':
                        WczytajZpliku();
                        break;
                    case 'n':
                        WyswietlMenu();
                        break;
                    default :
                        Console.WriteLine("Wybrano złą opcje! Powrót do Menu:");
                        Console.ReadKey();
                        WyswietlMenu();
                        break;
                }

            } 
            Console.ReadKey();
            WyswietlMenu();
        }

        static bool NoEmptyLis() {

            return cytaty.Count>0;
        }

        static List<string> AddCytat(List<string> list)
        {
            int index = 0;
            Console.Clear();
            Console.WriteLine("Ile chcesz dodać cytatów:");

            if(int.TryParse(Console.ReadLine(), out int iloscCytatow))
            {
                while (index < iloscCytatow)
                {
                    Console.WriteLine("Podaj cytat:");
                    list.Add(Console.ReadLine());
                    index++;
                }
                Console.WriteLine("Dodanie cytatu do bazy powiodło się! Powrót do Menu");
                Console.ReadKey();
                WyswietlMenu();
                return list;
            }
            else
            {
             Console.WriteLine("Wybrano złą opcje! Powrót do Menu");
             return list;
            }
        }

        static void WczytajZpliku()
        {
            if (!NoEmptyLis())
            {
                StreamReader sr = File.OpenText(FILE_NAME);
                string linia = "";
                while ((linia = sr.ReadLine()) != null)
                {
                    cytaty.Add(linia);
                }
                sr.Close();
                Console.WriteLine("Wczytanie z pliku powiodło się! Powrót do Menu:");
                Console.ReadKey();
                WyswietlMenu();
            }
            else
            {
                Console.WriteLine("W bazie znajdują się nie zapisane cytaty zapisz lub usuń aby ponownie wczytać");
                Console.ReadKey();
                WyswietlMenu();
            }

        }

        static void ZapiszDoPliku(List<string> list)
        {
            if (NoEmptyLis())
            {
                StreamWriter sw;
                if (!File.Exists(FILE_NAME))
                {
                    sw = File.CreateText(FILE_NAME);

                }
                else
                {
                    sw = new StreamWriter(FILE_NAME, true);
                }
                foreach (string s in list)
                {
                    sw.WriteLine(s);
                }

                sw.Close();
                Console.WriteLine("Zapis powiódł się! Powrót do Menu:");
                Console.ReadKey();
                WyswietlMenu();
            }
            else
            {
                Console.WriteLine("Baz nie zawiera cytatów - niema nic do zapisania! Powrót do Menu");
                Console.ReadKey();
                WyswietlMenu();
            }

        }
        static int IloscCytatow(List<string> list)

        {
           int licznikC = 0;
            for (int i = 0; i<list.Count;i++)
            {
                licznikC++;
            }
            return licznikC;
        }

        static void DelCytaty(List<string> lista)
        {
            if(NoEmptyLis())
            {
                Console.WriteLine($"Chcesz usunąć { IloscCytatow(lista)} z bazy");
                lista.Clear();
                Console.WriteLine("Cytaty zostały usunięte! Powrót do Menu:");
                Console.ReadLine();
                WyswietlMenu();
            }
            else {
                Console.WriteLine("Baza pusta! Powrót co Menu:");
                Console.ReadLine();
                WyswietlMenu();
            }
            
        }
    }
}




























