using Rekrutacja.Workers.Calculator;
using Rekrutacja.Workers.Operations;
using Rekrutacja.Workers.Template;
using Soneta.Business;
using Soneta.Kadry;
using Soneta.Tools;
using Soneta.Types;

//Rejetracja Workera - Pierwszy TypeOf określa jakiego typu ma być wyświetlany Worker, Drugi parametr wskazuje na jakim Typie obiektów będzie wyświetlany Worker
[assembly: Worker(typeof(TemplateWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers.Template
{
    public class TemplateWorker
    {
        //Aby parametry działały prawidłowo dziedziczymy po klasie ContextBase
        public class TemplateWorkerParametry : ContextBase
        {
            [Caption("A"), Priority(1)]
            public double VariableX { get; set; }

            [Caption("B"), Priority(2)]
            public double VariableY { get; set; }

            [Caption("Data obliczeń"), Priority(3)]
            public Date CalculationDate { get; set; }

            [Caption("Operacja"), Priority(4)]
            public Operation Operation { get; set; }

            public TemplateWorkerParametry(Context context) : base(context)
            {
                VariableX = 0;
                VariableY = 0;
                CalculationDate = Date.Today;
                Operation = Operation.Addition;
            }
        }
        //Obiekt Context jest to pudełko które przechowuje Typy danych, aktualnie załadowane w aplikacji
        //Atrybut Context pobiera z "Contextu" obiekty które aktualnie widzimy na ekranie
        [Context]
        public Context Cx { get; set; }
        //Pobieramy z Contextu parametry, jeżeli nie ma w Context Parametrów mechanizm sam utworzy nowy obiekt oraz wyświetli jego formatkę
        [Context]
        public TemplateWorkerParametry Parametry { get; set; }
        //Atrybut Action - Wywołuje nam metodę która znajduje się poniżej
        [Action("Kalkulator",
           Description = "Prosty kalkulator ",
           Priority = 10,
           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]
        public void WykonajAkcje()
        {
            //Włączenie Debug, aby działał należy wygenerować DLL w trybie DEBUG
            DebuggerSession.MarkLineAsBreakPoint();
            //Pobieranie danych z Contextu
            Pracownik[] pracownicy = null;

            if(this.Cx.Contains(typeof(Pracownik[])))
            {
                pracownicy = (Pracownik[])this.Cx[typeof(Pracownik[])];
            }

            if(pracownicy.Length == 0)
                return;

            //Modyfikacja danych
            //Aby modyfikować dane musimy mieć otwartą sesję, któa nie jest read only
            using(var nowaSesja = this.Cx.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
            {
                //Otwieramy Transaction aby można było edytować obiekt z sesji
                using(var trans = nowaSesja.Logout(true))
                {
                    foreach(var pracownik in pracownicy)
                    {
                        //Pobieramy obiekt z Nowo utworzonej sesji
                        var pracownikZSesja = nowaSesja.Get(pracownik);
                        //Features - są to pola rozszerzające obiekty w bazie danych, dzięki czemu nie jestesmy ogarniczeni to kolumn jakie zostały utworzone przez producenta
                        pracownikZSesja.Features["DataObliczen"] = this.Parametry.DataObliczen;
                        pracownikZSesja.Features["Wynik"] = CalculatorService.Calculate(this.Parametry.ZmiennaX, this.Parametry.ZmiennaY, this.Parametry.Operacja);
                    }
                    //Zatwierdzamy zmiany wykonane w sesji
                    trans.CommitUI();

                }
                //Zapisujemy zmiany
                nowaSesja.Save();
            }
        }
    }
}