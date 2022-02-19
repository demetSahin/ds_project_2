using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////// 1 - b) //////////
            string[] musteriAdi = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };
            int[] urunSayisi = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };

            ArrayList bilesikVeriYapisi = BilesikVeriYapisi(musteriAdi, urunSayisi);// musteriAdi string dizisi ve urunSayisi int dizisini argüman olarak alan ve elemanları Musteri nesneleri barındıran jenerik listeler olan bir arraylist döndüren metot.

            ////////// 1 - c) //////////
            Console.Write("\n\n\n1. sorunun c) şıkkının cevabı için lütfen ENTER'a basın.\n");
            Console.ReadLine();
            Yazdirmaİslemleri(bilesikVeriYapisi);

            ////////// 2 - a) //////////
            Console.Write("\n\n\n2. sorunun a) şıkkının cevabı için lütfen ENTER'a basın.\n");
            Console.ReadLine();
            YigitOlusturVeYazdir(bilesikVeriYapisi);

            ////////// 2 - b) //////////
            Console.Write("\n\n\n2. sorunun b) şıkkının cevabı için lütfen ENTER'a basın.\n");
            Console.ReadLine();
            QueueFIFO myQueue = KuyrukOlustur(bilesikVeriYapisi); // KuyrukOlustur metodu ile QueueFIFO sınıfından bir kuyruk nesnesi oluşturulur.
            Console.WriteLine("Kuyruktan FIFO mantığına göre çıkartılarak yazdırılan elemanlar :\n");
            Console.WriteLine(myQueue);

            ////////// 3 - a) //////////
            Console.Write("\n\n\n3. sorunun a) şıkkının cevabı için lütfen ENTER'a basın.\n");
            Console.ReadLine();
            DescendingPriorityQueue myDescendingPriorityQueue = AzalanSiradaOncelikliKuyrukOluştur(bilesikVeriYapisi); // AzalanSiradaOncelikliKuyrukOluştur metodu ile DescendingPriorityQueue sınıfından bir azalan öncelikli kuyruk nesnesi oluşturulur.
            Console.WriteLine("Ürün sayısına göre azalan sırada öncelikli kuyruk yapısındaki elemanlar :\n");
            Console.WriteLine(myDescendingPriorityQueue);

            ////////// 4 - a) //////////
            Console.Write("\n\n\n4. sorunun a) şıkkının cevabı için lütfen ENTER'a basın.\n");
            Console.ReadLine();
            AscendingPriorityQueue myAscendingPriorityQueue = ArtanSiradaOncelikliKuyrukOluştur(bilesikVeriYapisi); // ArtanSiradaOncelikliKuyrukOluştur metodu ile AscendingPriorityQueue sınıfından bir artan öncelikli kuyruk nesnesi oluşturulur.
            Console.WriteLine("Ürün sayısına göre artan sırada öncelikli kuyruk yapısındaki elemanlar :\n");
            Console.WriteLine(myAscendingPriorityQueue);

            ////////// 4 - b) //////////
            Console.Write("\n\n\n4. sorunun b) şıkkının cevabı için lütfen ENTER'a basın.\n");
            Console.ReadLine();
            IslemTamamlanmaSureleri(bilesikVeriYapisi);

            Console.ReadKey();
        }

        private static ArrayList BilesikVeriYapisi(string[] musteriAdi, int[] urunSayisi)
        {
            Random random = new Random();
            ArrayList arrayList = new ArrayList();
            List<Musteri> genericList; //Musteri nesneleri tutan jenerik liste.
            int sayac = 0;

            while (sayac < musteriAdi.Length) // argüman olarak gönderilen diziler aynı boyutta olduğu kabul edildiğinden herhangi birinin uzunluğu dikkate alınabilir.
            {
                genericList = new List<Musteri>();
                int genericListLength = random.Next(1, 6); //arrayliste atılacak jenerik listelerin 1'den 5'e kadar rastgele boyutlarda olmasını sağlamak için.
                for (int i = 0; i < genericListLength; i++)  
                {
                    genericList.Add(new Musteri(musteriAdi[sayac], urunSayisi[sayac])); //yukarıda 1-5 arasında rastgele oluşturulan değere göre her bir döngüde musteriAdi dizisinden müşteri adını ve urunSayisi dizisinden ürün sayısı bilgilerini alarak Musteri nesnesi oluşturulup jenerik listeye atılır.
                    sayac++; // her döngüde sayac değişkeni bir artıtılır.

                    if (sayac == musteriAdi.Length) break; // sayac değişkeni, argüman dizinin boyutuna eşit olduğu anda döngü sonlandırılmalıdır.
                }
                arrayList.Add(genericList); // rastgele boyutlarda oluşturulan her bir jenerik liste arrayliste atılır. 
            }

            Console.WriteLine("Bileşik veri yapısındaki elemanlar :\n");
            foreach (List<Musteri> item in arrayList) // burada, yukarıda oluşturulan bileşik veri yapısı iç içe foreach döngüleriyle yazdırılmaktadır.
            {
                Console.WriteLine("{0}. liste :", arrayList.IndexOf(item) + 1);
                foreach (Musteri item1 in item)
                {
                    Console.WriteLine("{0}, {1}", item1.MusteriAdi, item1.UrunSayisi);
                }
                Console.WriteLine();
            }

            return arrayList; // oluşturulan bileşik veri yapısı daha sonraki adımlarda kullanılacağı için döndürülmektedir.
        }

        private static void Yazdirmaİslemleri(ArrayList arrayList) //önceki adımda oluşturduğum arraylist nesnesini argüman olarak gönderdim.
        {
            double listeSayisi = 0;
            double musteriSayisi = 0;
            foreach (List<Musteri> genericList in arrayList) // arraylist'in içinde Musteri nesneleri tutan jenerik listeler vardır. 
            {
                listeSayisi++;
                foreach (Musteri musteri in genericList) //jenerik listelerin elemanları Musteri nesneleridir
                {
                    musteriSayisi++; // dıştaki foreach döngüsü ile arraylist'in içindeki listelere, içteki foreach döngüsü ile listelerin içindeki Musteri nesnelerine erişilir ve her döngüde müsteri sayısı bir artırılır.
                }
            }
            Console.WriteLine("Dinamik dizimizde " + listeSayisi + " tane eleman vardır."); // dinamik dizinin uzunluğu ".Count" ile de bulunabilirdi ancak hazır yukarıdaki döngüyü yapmışken listeSayisi değişkeni ile buldum.
            Console.WriteLine("Ortalama eleman sayısı : " + (double)(musteriSayisi / listeSayisi)); // toplam müşteri sayısı toplam liste sayısına bölünerek her bir listede tutulan ortalama eleman sayısı bulunur.
        }

        private static void YigitOlusturVeYazdir(ArrayList arrayList)
        {
            StackLIFO myStack = new StackLIFO(); // StackLIFO olarak isimlendirdiğim yığıt sınıfından bir nesne oluşturdum.

            foreach (List<Musteri> genericList in arrayList)
            {
                foreach (Musteri musteri in genericList)
                {
                    myStack.Push(musteri); //en başta oluşturduğum bileşik veri yapılı arraylist üzerinde iç içe foreach döngüleriyle işlem yaparak her bir Musteri nesnesine ulaştım ve yığıta ekledim.
                }
            }
            Console.WriteLine("Yığıttan LIFO mantığına göre çıkarılarak yazdırılan elemanlar :\n");
            Console.WriteLine(myStack); //StackLIFO sınıfı içinde ToString metodunu override ettiğimiz için Console.WriteLine içinde yığıtın tüm elemanlarını yazdırabiliyoruz.
        }

        private static QueueFIFO KuyrukOlustur(ArrayList arrayList)
        {
            QueueFIFO myQueue = new QueueFIFO(); // QueueFIFO olarak isimlendirdiğim kuyruk sınıfından bir nesne oluşturdum.

            foreach (List<Musteri> genericList in arrayList)
            {
                foreach (Musteri musteri in genericList)
                {
                    myQueue.Enqueue(musteri); //en başta oluşturduğum bileşik veri yapılı arraylist üzerinde iç içe foreach döngüleriyle işlem yaparak her bir Musteri nesnesine ulaştım ve kuyruğa ekledim.
                }
            }

            return myQueue; //burda oluşturulan kuyruk nesnesi daha sonraki adımlarda kullanılacağı için meodun tipi QueueFIFO'dur ve bu tipte kuyruk nesnesi döndürür.
        }

        private static DescendingPriorityQueue AzalanSiradaOncelikliKuyrukOluştur(ArrayList arrayList)
        {
            DescendingPriorityQueue myDescendingPriorityQueue = new DescendingPriorityQueue(); // DescendingPriorityQueue olarak isimlendirdiğim azalan sırada öncelikli kuyruk sınıfından bir nesne oluşturdum.

            foreach (List<Musteri> genericList in arrayList)
            {
                foreach (Musteri musteri in genericList)
                {
                    myDescendingPriorityQueue.Enqueue(musteri); //en başta oluşturduğum bileşik veri yapılı arraylist üzerinde iç içe foreach döngüleriyle işlem yaparak her bir Musteri nesnesine ulaştım ve öncelikli kuyruğa ekledim.
                }
            }

            return myDescendingPriorityQueue; //burda oluşturulan öncelikli kuyruk nesnesi daha sonraki adımlarda kullanılacağı için meodun tipi DescendingPriorityQueue'dur ve bu tipte öncelikli kuyruk nesnesi döndürür.
        }

        private static AscendingPriorityQueue ArtanSiradaOncelikliKuyrukOluştur(ArrayList arrayList)
        {
            AscendingPriorityQueue myAscendingPriorityQueue = new AscendingPriorityQueue(); // AscendingPriorityQueue olarak isimlendirdiğim artan sırada öncelikli kuyruk sınıfından bir nesne oluşturdum.

            foreach (List<Musteri> genericList in arrayList)
            {
                foreach (Musteri musteri in genericList)
                {
                    myAscendingPriorityQueue.Enqueue(musteri); //en başta oluşturduğum bileşik veri yapılı arraylist üzerinde iç içe foreach döngüleriyle işlem yaparak her bir Musteri nesnesine ulaştım ve öncelikli kuyruğa ekledim.
                }
            }

            return myAscendingPriorityQueue; //burda oluşturulan öncelikli kuyruk nesnesi daha sonraki adımlarda kullanılacağı için meodun tipi AscendingPriorityQueue'dur ve bu tipte öncelikli kuyruk nesnesi döndürür.
        }

        private static void IslemTamamlanmaSureleri(ArrayList arrayList)
        {
            // Önceki adımlarda oluşturulan kuyruklar yazdırılırken ögeleri silindiği için, bu metotta kuyruk ve öncelikli kuyruk sınıflarından yeni nesneler oluşturdum.
            QueueFIFO myQueue = KuyrukOlustur(arrayList);
            OrtakIslemleriYazdir(myQueue.IsEmpty(), myQueue.Dequeue, "Kuyruk yapısında:");

            DescendingPriorityQueue myDescendingPriorityQueue = AzalanSiradaOncelikliKuyrukOluştur(arrayList);
            OrtakIslemleriYazdir(myDescendingPriorityQueue.IsEmpty(), myDescendingPriorityQueue.Dequeue, "Azalan sırada öncelikli kuyruk yapısında:");

            AscendingPriorityQueue myAscendingPriorityQueue = ArtanSiradaOncelikliKuyrukOluştur(arrayList);
            OrtakIslemleriYazdir(myAscendingPriorityQueue.IsEmpty(), myAscendingPriorityQueue.Dequeue, "Artan sırada öncelikli kuyruk yapısında:");
        }

        private static void OrtakIslemleriYazdir(bool isEmpty, Func<Object> dequeue, String message) // her bir kuyruk nesnesi için benzer işlemler yapılacağı için ortak bir metot oluşturdum.
        { // her bir kuyruk sınıfının kuyruk dışına çıkarma metodunu bu metoda argüman olarak gönderdim. Böylece sadece o kuyruk nesnesinin metodu çalışacaktır. 
            int musteriSirası = 0;
            double islemTamamlanmaSuresi = 0;
            double toplamSure = 0;
            Console.WriteLine(message);
            while (!isEmpty) //kuyruk sınıfındaki listede nesne olduğu müddetçe döngü sürer.
            {
                musteriSirası++;
                Musteri musteri = (Musteri)dequeue();
                if (musteri == null) break;
                else
                {
                    islemTamamlanmaSuresi += musteri.UrunSayisi; //her bir müşterinin ürün sayısı işlem tamamlanma süresine kümülatif olarak eklenir.
                    toplamSure += islemTamamlanmaSuresi; // her bir müşterinin işlem tamamlanma süresi toplam süreye kümülatif olarak eklenir.
                }
                Console.WriteLine("{0}. müşterinin işlem tamamlanma süresi {1} birim süredir.", musteriSirası, islemTamamlanmaSuresi);
            }
            Console.WriteLine("\nToplam süre {0} birim süredir.", toplamSure);
            Console.WriteLine("Ortalama işlem tamamlanma süresi {0} birim süredir.\n\n", (toplamSure / (musteriSirası - 1)).ToString("0.00"));
        }
    }

    class Musteri
    {
        public string MusteriAdi;
        public int UrunSayisi;

        public Musteri(string musteriAdi, int urunSayisi)
        {
            this.MusteriAdi = musteriAdi;
            this.UrunSayisi = urunSayisi;
        }

        public override string ToString()
        {
            return MusteriAdi + ", " + UrunSayisi;
        }
    }

    class StackLIFO
    {
        private List<Musteri> genericList; // Müşteri nesnelerini tutacak olan jenerik liste

        public StackLIFO() // yapılandırıcı
        {
            genericList = new List<Musteri>(); // Müşteri nesnelerini tutacak olan liste yaratılır. Bellekte yer açılır.
        }

        public void Push(Musteri musteri) // Yığıtın en üstüne nesne eklemeye yarayan metot. Void olarak herhangi bir şey döndürmez.
        {
            genericList.Add(musteri);
        }

        public Musteri Pop() // Yığıtın en tepesinden Müşteri nesnesini çıkarmaya yarayan metot. Musteri nesnesi döndürür.
        {
            if (IsEmpty())
                return null;
            else
            {
                Musteri temp = genericList[genericList.Count - 1];
                genericList.RemoveAt(genericList.Count - 1);
                return temp;
            }
        }

        public bool IsEmpty() // Yığıt boşsa true, boş değilse false döndüren metot.
        {
            return (genericList.Count == 0);
        }

        public override string ToString() //Yığıtın ögelerini object olarak değil de, string olarak yazdırabilmek için built-in ToString() metodu override edilir.
        {
            string text = "";

            Musteri musteri;
            while ((musteri = Pop()) != null)
                text += musteri.ToString() + "\n";

            return text;
        }
    }

    class QueueFIFO
    {
        private List<Musteri> genericList { get; } // Müşteri nesnelerini tutacak olan jenerik liste

        public QueueFIFO() // yapılandırıcı
        {
            genericList = new List<Musteri>(); // Müşteri nesnelerini tutacak olan liste yaratılır. Bellekte yer açılır.
        }

        public void Enqueue(Musteri musteri) // Kuyruğun en sonuna nesne eklemeye yarayan metot. Void olarak herhangi bir şey döndürmez.
        {
            genericList.Add(musteri);
        }

        public Musteri Dequeue() // Kuyruğun en başından Müşteri nesnesini çıkarmaya yarayan metot. Musteri nesnesi döndürür.
        {
            if (IsEmpty())
                return null;
            else
            {
                Musteri temp = genericList[0];
                genericList.RemoveAt(0);
                return temp;
            }
        }

        public bool IsEmpty() // Kuyruk boşsa true, boş değilse false döndüren metot.
        {
            return (genericList.Count == 0);
        }

        public override string ToString() //Kuyruğun ögelerini object olarak değil de, string olarak yazdırabilmek için built-in ToString() metodu override edilir.
        {
            string text = "";

            Musteri musteri;
            while ((musteri = Dequeue()) != null)
                text += musteri.ToString() + "\n";

            return text;
        }
    }

    class DescendingPriorityQueue // Azalan sıralı öncelikli kuyruk sınıfı
    {
        private List<Musteri> genericList; // Müşteri nesnelerini tutacak olan jenerik liste

        public DescendingPriorityQueue() // yapılandırıcı
        {
            genericList = new List<Musteri>(); // Müşteri nesnelerini tutacak olan liste yaratılır. Bellekte yer açılır.
        }

        public void Enqueue(Musteri musteri) // Kuyruğun en sonuna nesne eklemeye yarayan metot. Void olarak herhangi bir şey döndürmez.
        {
            genericList.Add(musteri);
        }

        public Musteri Dequeue() // Kuyruktan azalan sırada öncelikli olarak Müşteri nesnesi çıkarmaya yarayan metot. Musteri nesnesi döndürür.
        {
            if (IsEmpty())
                return null;
            else
            {
                int enCokUrun = 0;
                int enCokUrunAlanMusteriIndisi = 0;
                for (int i = 0; i < GetSize(); i++)
                {
                    if (genericList[i].UrunSayisi > enCokUrun)
                    {
                        enCokUrun = genericList[i].UrunSayisi;
                        enCokUrunAlanMusteriIndisi = i;
                    }
                }
                Musteri temp = genericList[enCokUrunAlanMusteriIndisi];
                genericList.RemoveAt(enCokUrunAlanMusteriIndisi);
                return temp;
            }
        }

        public bool IsEmpty() // Kuyruk boşsa true, boş değilse false döndüren metot.
        {
            return (genericList.Count == 0);
        }

        public override string ToString() //Kuyruğun ögelerini object olarak değil de, string olarak yazdırabilmek için built-in ToString() metodu override edilir.
        {
            string text = "";

            Musteri musteri;
            while ((musteri = Dequeue()) != null)
                text += musteri.ToString() + "\n";

            return text;
        }

        internal int GetSize()
        {
            return genericList.Count;
        }
    }

    class AscendingPriorityQueue // Artan sıralı öncelikli kuyruk sınıfı
    {
        private List<Musteri> genericList; // Müşteri nesnelerini tutacak olan jenerik liste

        public AscendingPriorityQueue() // yapılandırıcı
        {
            genericList = new List<Musteri>(); // Müşteri nesnelerini tutacak olan liste yaratılır. Bellekte yer açılır.
        }

        public void Enqueue(Musteri musteri) // Kuyruğun en sonuna nesne eklemeye yarayan metot. Void olarak herhangi bir şey döndürmez.
        {
            genericList.Add(musteri);
        }

        public Musteri Dequeue() // Kuyruktan artan sırada öncelikli olarak Müşteri nesnesi çıkarmaya yarayan metot. Musteri nesnesi döndürür.
        {
            if (IsEmpty())
                return null;
            else
            {
                int enAzUrun = genericList[0].UrunSayisi;
                int enAzUrunAlanMusteriIndisi = 0;
                for (int i = 1; i < GetSize(); i++) // Kuyruktaki ilk müşterinin ürün sayısını referans olarak alıp for döngüsü ile diğer müşterilerin ürün sayısıyla karşılaştırır, her defasında daha az ürün sayısı olan müşterinin sırasını alırız.
                {
                    if (genericList[i].UrunSayisi < enAzUrun)
                    {
                        enAzUrun = genericList[i].UrunSayisi;
                        enAzUrunAlanMusteriIndisi = i;
                    }
                }
                Musteri temp = genericList[enAzUrunAlanMusteriIndisi];
                genericList.RemoveAt(enAzUrunAlanMusteriIndisi);
                return temp;
            }
        }

        public bool IsEmpty() // Kuyruk boşsa true, boş değilse false döndüren metot.
        {
            return (genericList.Count == 0);
        }

        public override string ToString() //Kuyruğun ögelerini object olarak değil de, string olarak yazdırabilmek için built-in ToString() metodu override edilir.
        {
            string text = "";

            Musteri musteri;
            while ((musteri = Dequeue()) != null)
                text += musteri.ToString() + "\n";

            return text;
        }

        internal int GetSize() // Kuyruğun uzunluğunu int tipinde döndüren metot
        {
            return genericList.Count;
        }
    }
}
