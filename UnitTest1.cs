using Borelli_Autobus;
namespace testlibreriaborelli
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()//controllo la capienza passeggeri
        {
            Autobus bus = new Autobus();
            bus.Partenza();
            bus.Fermata();
            Assert.Throws<Exception>(() => bus.SalitaPasseggeri(2));
        }
        [Fact]
        public void Test2()//
        {
            Autobus bus = new Autobus("IDONFOIFE","AA000AA","locatelli",1);
            
            Assert.Throws<Exception>(() => bus.SalitaPasseggeri(2));
        }
        [Fact]
        public void Test3()// creo un autobus di 60 passeggeri e ne faccio salire 61
        {
            Autobus bus = new Autobus("IDONFOIFE", "AA000AA", "locatelli", 61);
            bus.Partenza();
            bus.Fermata();
            Assert.Throws<Exception>(() =>bus.SalitaPasseggeri(62));
        }
        [Fact]
        public void Test4()
        {
            Autobus bus = new Autobus(".","aa000AA","palla",12);
            Autobus lel = new Autobus("pepitocrazy","aa000bb"," .",82);
            bus.Partenza();
            lel.Partenza();
            lel.Fermata();
            bus.Fermata();
            bus.SpostaPasseggeri(lel);
            lel.SpostaPasseggeri(bus);
            Assert.Throws<Exception>(() => bus.DiscesaPasseggeri(10));
        }
        [Fact]
        public void Test5()// creo un autobus di 60 passeggeri e ne faccio salire 61
        {
            Autobus bus = new Autobus("IDONFOIFE", "AA000AA", "locatelli", 61);
            bus.Partenza();
            bus.Fermata();
            bus.SalitaPasseggeri(61);
            Assert.Throws<Exception>(() => bus.DiscesaPasseggeri(63));
        }
        [Fact]
        public void Test6() // controllo se lancia un eccezione se scendono troppi passeggeri
        {
            Autobus bus = new Autobus("IDONFOIFE", "AA000AA", "locatelli", 61);
            bus.Partenza();
            bus.Fermata();
            bus.SalitaPasseggeri(61);
            bus.Deposita();
            Assert.Throws<Exception>(() => bus.DiscesaPasseggeri(62));
        }
        [Fact]
        public void Test7()//non lancia l'eccezione se 0 persone salgono
        {
            Autobus bus = new Autobus("IDONFOIFE", "AA000AA", "locatelli", 61);
            bus.Partenza();
            bus.Fermata();
            Assert.Throws<Exception>(() => bus.SalitaPasseggeri(0));
        }
        [Fact]
        public void Test8()//non lancia l'eccezione se 0 persone scendono
        {
            Autobus bus = new Autobus("IDONFOIFE", "AA000AA", "locatelli", 61);
            bus.Partenza();
            bus.Fermata();
            bus.SalitaPasseggeri(1);
            Assert.Throws<Exception>(() => bus.DiscesaPasseggeri(0));
        }
        [Fact]
        public void Test9()//controllo se posso spostare dei passeggeri da un autobus allo stesso
        {
            Autobus bus = new Autobus(".", "aa000AA", "palla", 1);
            Autobus lel = new Autobus("pepitocrazy", "aa000bb", " .", 9);
            bus.Partenza();
            lel.Partenza();
            lel.Fermata();
            bus.Fermata();
            lel.SalitaPasseggeri(9);
            Assert.Throws<Exception>(() => lel.SpostaPasseggeri(lel));
        }
        [Fact]
        public void Test10()//controllo se posso scambiare i passeggeri mentre uno è in movimento e l'altro no
        {
            Autobus n3 = new Autobus("iugfd", "aa000aa", "ouiudsgf", 999);
            Autobus bus = new Autobus(".", "aa000AA", "palla", 1);
            Autobus lel = new Autobus("pepitocrazy", "aa000bb", " .", 9);
            bus.Partenza();
            lel.Partenza();
            n3.Partenza();
            lel.Fermata();
            bus.Fermata();
            Assert.Throws<Exception>(() => n3.SpostaPasseggeri(lel));
        }
        public void Test11()
        {
            Autobus bus = new Autobus(".", "aa000AA", "palla", 1);
            Autobus lel = new Autobus("pepitocrazy", "aa000bb", " .", 9);
            bus.Partenza();
            lel.Partenza();
            lel.Fermata();
            bus.Fermata();
            Assert.Throws<Exception>(() =>bus.SpostaPasseggeri(lel));
        }
    }
}